using Newtonsoft.Json;
using Ninject.Activation.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracking.Caching;
using Tracking.Models.Tracking;
using Tracking.Models.TrackingServices.Abstract;

namespace Tracking.Models.TrackingServices
{
    public static class XpressITClientDefinedFields
    {
        public const string _XpITSettings_ClientId = "XpressITManagerSettings_ClientId";
        public const string _XpITSettings_ClientSecret = "XpressITManagerSettings_ClientSecret";
        //public const string _XpITSettings_AppID = "XpressITManagerSettings_AppID";
        public const string _XpITSettings_SubscriptionKey = "XpressITManagerSettings_SubscriptionKey";
        public const string _XpITTrackingClient_EndpointAddress = "XpressITManagerSettings_TrackingURL";
        public const string _XpITSettings_AuthURL = "XpressITManagerSettings_AuthURL";

        public const string _XpITSettings_grantTypeKey = "grant_type";
        public const string _XpITSettings_grantTypeValue = "client_credentials";
        public const string _XpITSettings_clientIdKey = "client_id";
        public const string _XpITSettings_clientSecretKey = "client_secret";
        public const string _XpITSettings_scopeKey = "scope";
        public const string _XpITSettings_scopeValue = "tracking";
    }
    #region Request/Response
    public class AccessTokenResponseObject
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
    }
    public class AccessTokenResponseErrorObject
    {
        public string error_description { get; set; }
        public string error { get; set; }
    }

    public class LatestStatus
    {
        public string city { get; set; }
        public string date { get; set; }
        public string location { get; set; }
        public string stateProvince { get; set; }
        public string status { get; set; }
        public string statusMessage { get; set; }
        public string time { get; set; }
        public string zipPostalCode { get; set; }
    }

    public class SearchParameter
    {
        public string trackingNumber { get; set; }
        public string carrierCode { get; set; }
    }

    public class CustomProperty
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class Track
    {
        public List<LatestStatus> activities { get; set; }
        public string addressRerouteToDestination { get; set; }
        public string carrierCode { get; set; }
        public List<CustomProperty> customProperties { get; set; }
        public string destination { get; set; }
        public LatestStatus latestStatus { get; set; }
        public string origin { get; set; }
        public List<object> relatedShipments { get; set; }
        public string resultsLastUpdatedUtcDateTime { get; set; }
        public string scheduledDeliveryDateTime { get; set; }
        public SearchParameter searchParameter { get; set; }
        public string trackingNumber { get; set; }
    }

    public class ExternalTrackITResponse
    {
        public string failureInformation { get; set; }
        public bool success { get; set; }
        public List<Track> tracks { get; set; }
    }

    #endregion
    public class XpITTrackManager : IXpITTrackManager, IDisposable
    {
        private static string _Token;
        private TrackingCreds _creds;
        public string Token
        {
            get
            {
                var token = DoXpITAuthPost();
                return token;
            }
            set
            {
                _Token = value;
            }
        }

        /// <summary>
        /// get token method
        /// </summary>
        /// <returns></returns>
        public object GetXpressITAPIAuthToken()
        {
            object result = null;
            object request = string.Empty;
            //var authURL = string.Format(authUrl, clientId, clientSecret);
            Dictionary<string, string> formValues = new Dictionary<string, string>();
            formValues.Add(XpressITClientDefinedFields._XpITSettings_grantTypeKey, XpressITClientDefinedFields._XpITSettings_grantTypeValue);
            formValues.Add(XpressITClientDefinedFields._XpITSettings_clientIdKey, _creds.UserName);
            formValues.Add(XpressITClientDefinedFields._XpITSettings_clientSecretKey, _creds.Password);
            formValues.Add(XpressITClientDefinedFields._XpITSettings_scopeKey, XpressITClientDefinedFields._XpITSettings_scopeValue);

            try
            {
                result = ApiTools.PostWebApi((object)request, new Uri(_creds.AuthUrl), formValues);
                return result;
            }
            catch (Exception ex)
            {
               // UdpLog.SendUdpLog("Error in XpressITManager.GetXpressITAPIAuthToken", "XpressIT Generate Auth Token API Failure, Shipment Invoice Number", (int)ApplicationError.Severity.Critical, null, ex);
            }

            return result;
        }

        [Cache(cacheKey = "XpressITManager|XpressITAuthTokenPostResult", minutesToCache = 1440, group = "Core", subGroup = "CarrierTracking")]
        public string DoXpITAuthPost()
        {
            string token = string.Empty;
            object retVal = null;
            AccessTokenResponseObject aro = null;
            AccessTokenResponseErrorObject areo = null;

            retVal = GetXpressITAPIAuthToken();

            if (retVal != null)
            {
                try
                {
                    aro = JsonConvert.DeserializeObject<AccessTokenResponseObject>((string)retVal, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                    if (aro != null)
                    {
                        if (!string.IsNullOrEmpty(aro.access_token) && aro.token_type == "Bearer")
                        {
                            token = aro.access_token;
                        }
                    }
                    else
                    {
                        areo = JsonConvert.DeserializeObject<AccessTokenResponseErrorObject>((string)retVal, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                        if (!string.IsNullOrEmpty(areo.error))
                        {
                            if (areo.error == "invalid_grant")
                                return DoXpITAuthPost();
                            //else
                              //  UdpLog.SendUdpLog("Error in XpressITManager.DoXpITAuthPost", "XpressIT get Autho Token failure, Error: " + areo.error + " | " + areo.error_description, (int)ApplicationError.Severity.Critical, null);
                        }
                    }
                }
                catch
                {
                    areo = JsonConvert.DeserializeObject<AccessTokenResponseErrorObject>((string)retVal, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                    if (!string.IsNullOrEmpty(areo.error))
                    {
                        if (areo.error == "invalid_grant")
                            return DoXpITAuthPost();
                        //else
                            //UdpLog.SendUdpLog("Error in XpressITManager.DoXpITAuthPost", "XpressIT get Autho Token failure, Error: " + areo.error + " | " + areo.error_description, (int)ApplicationError.Severity.Critical, null);
                    }
                }
            }
            return token;
        }
        public string GetXpITTrackingDetails(string LastMileAWBNumber, TrackingContext context, TrackingCreds creds)
        {
            string result = null;
            object request = string.Empty;
            var trkURL = string.Format(creds.Url, LastMileAWBNumber);
            _creds = creds;
            try
            {
                // post to the web api
                Dictionary<string, string> headers = new Dictionary<string, string>();
                // get token if necessary else token should last for 24 hours ( use cache) 
                headers.Add("Authorization", string.Format("Bearer {0}", Token));
                headers.Add("Ocp-Apim-Subscription-Key", "subkey");

                result = ApiTools.GetWebApi((object)request, new Uri(trkURL), headers).ToString();
                return result;
            }
            catch (Exception ex)
            {
                //UdpLog.SendUdpLog("Error in XpressITManager.GetXpITTrackingDetails", "XpressIT Get Label Status API Failure, Shipment Invoice Number", (int)ApplicationError.Severity.Critical, null, ex);
            }

            return result;

        }
        public List<StagingServiceDatum> RawToStaging(string rawJson, AwbtoProcess awb, int rawId)
        {
            var data = JsonConvert.DeserializeObject<ExternalTrackITResponse>(rawJson);
            List<StagingServiceDatum> response = null;

            try
            {
                response = (from t in data.tracks.FirstOrDefault().activities
                            select new StagingServiceDatum { AwbtoProcessId = awb.Id, Code = t.status, Description = t.statusMessage, EventDate = DateTime.Parse(t.date), ImportDate = DateTime.Now, RawServiceDataId = rawId, Location = string.Format("{0} {1},{2}", t.location, t.city, t.stateProvince) }).ToList();
            }
            catch (Exception ex)
            {

            }
            return response;
        }
        public void Dispose()
        {
            
        }
    }
}
