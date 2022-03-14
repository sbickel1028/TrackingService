using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using SC = Tracking.Models.TrackingServices.SkyChain;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Tracking.Models.Tracking;
using Tracking.Models.TrackingServices.Abstract;
using Tracking.Models.TrackingServices.SkyChain;
using System.Globalization;

namespace Tracking.Models.TrackingServices
{

    public class SkyCargoAuthResponseObject
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
    }

    public class SkyCargoAuthResponseErrorObject
    {
        public string error_description { get; set; }
        public string error { get; set; }
    }

    public class SkyCargoManager : ISkyCargoManager
    {
        private static string _Token;
        private TrackingCreds _creds;
        public string Token
        {
            get
            {
                var token = DoSCAuthPost();
                return token;
            }
            set
            {
                _Token = value;
            }
        }
        public string DoSCAuthPost()
        {
            string token = string.Empty;
            object retVal = null;
            SkyCargoAuthResponseObject scaro = null;
            SkyCargoAuthResponseErrorObject scareo = null;

            retVal = GetSCAPIAuthToken();

            if (retVal != null)
            {
                try
                {
                    scaro = JsonConvert.DeserializeObject<SkyCargoAuthResponseObject>((string)retVal, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                    if (scaro != null)
                    {
                        if (!string.IsNullOrEmpty(scaro.access_token) && scaro.token_type == "Bearer")
                        {
                            token = scaro.access_token;
                        }
                    }
                    else
                    {
                        scareo = JsonConvert.DeserializeObject<SkyCargoAuthResponseErrorObject>((string)retVal, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                        if (!string.IsNullOrEmpty(scareo.error))
                        {
                            if (scareo.error == "invalid_grant")
                                return DoSCAuthPost();
                            //else
                               // UdpLog.SendUdpLog("Error in EmiratesManager.DoSCAuthPost", "SkyCargo get Autho Token failure, Error: " + scareo.error + " | " + scareo.error_description, (int)ApplicationError.Severity.Critical, null);
                        }
                    }
                }
                catch
                {
                    scareo = JsonConvert.DeserializeObject<SkyCargoAuthResponseErrorObject>((string)retVal, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                    if (!string.IsNullOrEmpty(scareo.error))
                    {
                        if (scareo.error == "invalid_grant")
                            return DoSCAuthPost();
                        //else
                            //UdpLog.SendUdpLog("Error in EmiratesManager.DoSCAuthPost", "SkyCargo get Autho Token failure, Error: " + scareo.error + " | " + scareo.error_description, (int)ApplicationError.Severity.Critical, null);
                    }
                }
            }
            return token;
        }
        public object GetSCAPIAuthToken()
        {
            object result = null;
            object request = string.Empty;
            var authURL = string.Format(_creds.AuthUrl, _creds.Token);

            try
            {
                // post to the web api
                Dictionary<string, string> headers = new Dictionary<string, string>();
                headers.Add("Authorization", string.Format("Basic {0}", _creds.Token));
                request = "grant_type=client_credentials&scope=";

                result = ApiTools.PostWebApi((object)request, new Uri(authURL), headers);
                return result;
            }
            catch (Exception ex)
            {
          //      UdpLog.SendUdpLog("Error in EmiratesManager.GetSCAPIAuthToken", "SkyCargo Generate Auth Token API Failure, Shipment Invoice Number", (int)ApplicationError.Severity.Critical, null, ex);
            }

            return result;
        }
        public string GetSkyCargoTrackingDetails(string AWBNumber, TrackingContext context, TrackingCreds creds)
        {
            string result = null;
            _creds = creds;
            if (AWBNumber == "Awaiting AWB")
                return result;
            object request = string.Empty;

            try
            {

                var basicBinding = new BasicHttpBinding();
                basicBinding.Security.Mode = BasicHttpSecurityMode.Transport;

                var awbList = AWBNumber.Split('-');
                var wsBinding = new WSHttpBinding();
                wsBinding.Security.Mode = SecurityMode.Transport;

                CustomBinding currentBinding = new CustomBinding(wsBinding);
                MessageEncodingBindingElement encodingElement = currentBinding.Elements.Find<MessageEncodingBindingElement>();
                encodingElement.MessageVersion = MessageVersion.Soap11WSAddressingAugust2004;

                //wsBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.InheritedFromHost;
                var endPointAddress = new EndpointAddress(creds.Url);

                var client = new SC.SkyChainEndpointClient(basicBinding, endPointAddress);

                using (var scope = new OperationContextScope(client.InnerChannel))
                {
                    var httpRequestProperty = new HttpRequestMessageProperty();
                    httpRequestProperty.Headers[System.Net.HttpRequestHeader.Authorization] = string.Format("Bearer {0}", Token);
                    httpRequestProperty.Headers[System.Net.HttpRequestHeader.ContentType] = "text/xml";
                    //httpRequestProperty.Headers["SOAPAction"] = "/Service/SkyChainPlatformService.serviceagent/getTrackShipmentDetails";

                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = httpRequestProperty;

                    SC.TrackServiceRequest req = new SC.TrackServiceRequest();
                    req.documentType = "AWB";
                    req.documentPrefix = awbList[0];
                    if (awbList.Length > 1)
                        req.documentNumber = awbList[1];

                    result = JsonConvert.SerializeObject(client.getTrackShipmentDetails(req));
                }

            }
            catch (Exception ex)
            {
               // UdpLog.SendUdpLog("Error in EmiratesManager.GetSCTrackingDetails", "SkyCargo Get Label Status API Failure, Shipment Invoice Number", (int)ApplicationError.Severity.Critical, null, ex);
            }

            return result;

        }
        public List<StagingServiceDatum> RawToStaging(string rawJson, AwbtoProcess awb, int rawId)
        {
            var data = JsonConvert.DeserializeObject<TrackServiceResponse>(rawJson);
            List<StagingServiceDatum> response = null;

            try
            {
                response = (from t in data.result.FirstOrDefault().response.FirstOrDefault().movementstatuses
                            select new StagingServiceDatum { AwbtoProcessId = awb.Id, Code = t.status, Description = t.status, EventDate = DateTime.Parse(t.statusDate, CultureInfo.InvariantCulture), ImportDate = DateTime.Now, RawServiceDataId = rawId, Location = t.station }).ToList();
            }
            catch (Exception ex)
            {

            }
            return response;
        }
    }
}
