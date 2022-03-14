using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Tracking.Models.Tracking;
using Tracking.Models.TrackingServices.Abstract;
using static Tracking.Models.TrackingServices.MassarRequestResponseXML;

namespace Tracking.Models.TrackingServices
{
    #region Massar classes
    public class MassarLoginRequest
    {
        public string userName { get; set; }
        public string password { get; set; }
    }
    public class MassarLoginResponse
    {
        public string token { get; set; }
        public List<string> errors { get; set; }
    }
    public class MassarScannedResponse
    {
        public string orderNumber { get; set; }
        public string location { get; set; }

        public DateTime utcDateTime { get; set; }
    }
    public class MassarRequestResponseXML
    {
        public class apiRequest
        {
            public string sessionID { get; set; }
            public filter filter { get; set; }
        }
        public class filter
        {
            public refs refs { get; set; }
        }
        public class refs
        {
            [XmlElement("reference")]
            public string reference { get; set; }
        }

        [XmlRoot("apiResponse")]
        public class MassarOrderStatus
        {
            [XmlElement("orderStatusResponse")]
            public MassarOrderStatusResponse orderStatusResponse { get; set; }
        }
        [XmlRoot("orderStatusResponse")]
        public class MassarOrderStatusResponse
        {
            [XmlElement("orders")]
            public MassarStatusOrders orders { get; set; }
        }
        [XmlRoot("orders")]
        public class MassarStatusOrders
        {
            [XmlElement("order")]
            public MassarStatusOrder order { get; set; }
        }
        [XmlRoot("order")]
        public class MassarStatusOrder
        {
            [XmlAttribute("referenceNumber")]
            public string referenceNumber { get; set; }
            [XmlAttribute("status")]
            public string status { get; set; }
            [XmlElement("orderItem")]
            public List<MassarOrderItem> orderItem { get; set; }
            [XmlElement("aggregatedItemsStatus")]
            public MassarItemStatus aggregatedItemsStatus { get; set; }
        }
        [XmlRoot("orderItem")]
        public class MassarOrderItem
        {
            [XmlAttribute("name")]
            public string name { get; set; }
            [XmlAttribute("barcode")]
            public string barcode { get; set; }
            [XmlAttribute("status")]
            public string status { get; set; }
            [XmlAttribute("costPerUnit")]
            public string costPerUnit { get; set; }
            [XmlAttribute("totalCost")]
            public string totalCost { get; set; }
            [XmlAttribute("quantity")]
            public string quantity { get; set; }
            [XmlAttribute("actualQuantity")]
            public string actualQuantity { get; set; }
            [XmlAttribute("description")]
            public string description { get; set; }
            [XmlAttribute("externalId")]
            public string externalId { get; set; }
            [XmlAttribute("failReason")]
            public string failReason { get; set; }
            [XmlAttribute("comment")]
            public string comment { get; set; }
        }
        [XmlRoot("aggregatedItemsStatus")]
        public class MassarItemStatus
        {
            [XmlAttribute("actualDelivery")]
            public string actualDelivery { get; set; }
            [XmlAttribute("scheduledDelivery")]
            public string scheduledDelivery { get; set; }
            [XmlAttribute("completionStatus")]
            public string completionStatus { get; set; }

        }

        [XmlRoot("apiResponse")]
        public class MassarOrderLog
        {
            [XmlElement("apiResponse")]
            public MassarOrderLogInnerResponse apiResponse { get; set; }
        }

        [XmlRoot("apiResponse")]
        public class MassarOrderLogInnerResponse
        {
            [XmlElement("orders")]
            public MassarOrders orders { get; set; }
        }

        [XmlRoot("order")]
        public class MassarOrders
        {
            [XmlElement("order")]
            public List<MassarOrder> order { get; set; }
        }

        [XmlRoot("order")]
        public class MassarOrder
        {
            [XmlAttribute]
            public string referenceNumber { get; set; }
            [XmlAttribute]
            public string status { get; set; }
            [XmlAttribute]
            public string fullNotes { get; set; }

            [XmlAttribute]
            public string date { get; set; }

            [XmlElement("warnings")]
            public MassarWarnings warnings { get; set; }

        }

        [XmlRoot("warnings")]
        public class MassarWarnings
        {
            [XmlElement("warning")]
            public List<MassarWarning> warning { get; set; }
        }
        [XmlRoot("warning")]
        public class MassarWarning
        {
            [XmlElement("warningCode")]
            public string warningCode { get; set; }
            [XmlElement("warningMessage")]
            public string warningMessage { get; set; }
        }

        [XmlRoot("apiResponse")]
        public class MassarAuthApiResponse
        {
            [XmlElement("authResponse")]
            public AuthResponse authResponse { get; set; }
        }
        [XmlRoot("authResponse")]
        public class AuthResponse
        {
            [XmlElement("sessionID")]
            public string sessionID { get; set; }
        }

    }
    #endregion

    public class MassarManager : IMassarManager
    {
        public string GetauthenticationScanSessionID(TrackingCreds creds)
        {
            string sessionID = string.Empty;

            MassarLoginRequest request = new MassarLoginRequest { userName = creds.UserName, password = creds.Password };
            var resp = ApiTools.PostWebApiJson(request, new Uri(creds.AuthUrl));
            MassarLoginResponse response = JsonConvert.DeserializeObject<MassarLoginResponse>(resp.ToString());
            if (response != null && response.errors == null)
                sessionID = response.token;
            else
            {
                //UdpLog.SendUdpLog("Error in EmiratesManager.GetauthenticationScanSessionID", "Massar Tracking failed error: " + response.errors[0], (int)ApplicationError.Severity.Critical, null);
            }

            return sessionID;
        }
        public string GetAuthenticationSessionID(TrackingCreds creds)
        {
            string sessionID = string.Empty;

            WebClient client = new WebClient();

            client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";

            string authUrl = creds.AuthUrl;
            string clientID = creds.UserName;
            string password = creds.Password;
            string url = string.Format(authUrl, clientID, password);
            // Make the request
            string response = client.UploadString(url, String.Empty);
            XmlSerializer serializer = new XmlSerializer(typeof(MassarAuthApiResponse));
            using (TextReader reader = new StringReader(response))
            {
                try
                {
                    MassarAuthApiResponse resp = (MassarAuthApiResponse)serializer.Deserialize(reader);
                    sessionID = resp.authResponse.sessionID;
                }
                catch { }
            }
            return sessionID;
        }
        public string GetMassarTrackingLog(string lastMileAWBNumber, TrackingContext context, TrackingCreds creds)
        {
            MassarOrderLog result = null;
            string response = null;
            MassarOrderLog holdResult = null;
            MassarScannedResponse scanResponse = null;
            try
            {
                //Check to see if the package has been scanned by Massar yet
                try
                {
                    string scanSessionID = GetauthenticationScanSessionID(creds);
                    Dictionary<string, string> headers = new Dictionary<string, string>();
                    headers.Add("Authorization", string.Format("Bearer {0}", scanSessionID));
                    string url = string.Format(creds.Url, lastMileAWBNumber);
                    var resp = ApiTools.GetWebApi(null, new Uri(url), headers);
                    scanResponse = JsonConvert.DeserializeObject<MassarScannedResponse>(resp.ToString());
                    scanResponse.utcDateTime = new DateTime(scanResponse.utcDateTime.Year, scanResponse.utcDateTime.Month, scanResponse.utcDateTime.Day, scanResponse.utcDateTime.Hour, scanResponse.utcDateTime.Minute, scanResponse.utcDateTime.Second, DateTimeKind.Utc);

                    result = new MassarOrderLog();
                    result.apiResponse = new MassarOrderLogInnerResponse();
                    result.apiResponse.orders = new MassarOrders();
                    result.apiResponse.orders.order = new List<MassarOrder>();
                    MassarOrder order = new MassarOrder { date = scanResponse.utcDateTime.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'"), status = scanResponse.location, fullNotes = scanResponse.location, referenceNumber = scanResponse.orderNumber };
                    result.apiResponse.orders.order.Add(order);
                    result.apiResponse.orders.order.Add(order);
                }
                catch { }

                //only after it's been scanned should we look for everything else
                if (scanResponse != null)
                {
                    string sessionID = GetAuthenticationSessionID(creds);
                    refs myTracking = new refs();

                    myTracking.reference = lastMileAWBNumber;
                    apiRequest myRequest = new apiRequest { sessionID = sessionID, filter = new filter { refs = myTracking } };
                    string url = creds.SecondUrl;
                    using (var stringwriter = new System.IO.StringWriter())
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(apiRequest));
                        serializer.Serialize(stringwriter, myRequest);
                        var myString = stringwriter.ToString();
                        using (WebClient client = new WebClient())
                        {
                            string ret = client.UploadString(url, myString);
                            serializer = new XmlSerializer(typeof(MassarOrderLog));
                            using (TextReader reader = new StringReader(ret))
                            {
                                holdResult = (MassarOrderLog)serializer.Deserialize(reader);
                            }
                        }
                    }

                    if (holdResult != null && holdResult.apiResponse != null && holdResult.apiResponse.orders != null && holdResult.apiResponse.orders.order != null && holdResult.apiResponse.orders.order.Count > 0)
                        result.apiResponse.orders.order.AddRange(holdResult.apiResponse.orders.order);

                    //Get the current status of the order to see if it's closed and why
                    string statusUrl =creds.StatusUrl;
                    url = string.Format(statusUrl, sessionID, lastMileAWBNumber);
                    using (WebClient client = new WebClient())
                    {
                        string ret = client.UploadString(url, string.Empty);
                        XmlSerializer serializer = new XmlSerializer(typeof(MassarOrderStatus));
                        using (TextReader reader = new StringReader(ret))
                        {
                            MassarOrderStatus status = (MassarOrderStatus)serializer.Deserialize(reader);
                            if (result.apiResponse.orders.order.Where(x => x.status == "CLOSED").ToList().Count == 0 && status.orderStatusResponse.orders.order.status == "CLOSED" && status.orderStatusResponse.orders.order.aggregatedItemsStatus != null && status.orderStatusResponse.orders.order.aggregatedItemsStatus.completionStatus != null)
                                result.apiResponse.orders.order.Add(new MassarOrder { referenceNumber = lastMileAWBNumber, date = DateTime.Now.ToString(), status = status.orderStatusResponse.orders.order.aggregatedItemsStatus.completionStatus });
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                //UdpLog.SendUdpLog("Error in EmiratesManager.GetMassarTrackingLog", "Massar Tracking failed lastawbnumber: " + lastMileAWBNumber, (int)ApplicationError.Severity.Serious, null, ex);
            }
            response = result.ToString();
            return response;
        }
        public List<StagingServiceDatum> RawToStaging(string rawJson, AwbtoProcess awb, int rawId)
        {
            var data = JsonConvert.DeserializeObject<MassarOrderLog>(rawJson);
            List<StagingServiceDatum> response = null;

            try
            {
                response = (from t in data.apiResponse.orders.order
                            select new StagingServiceDatum { AwbtoProcessId = awb.Id, Code = t.status, Description = t.fullNotes, EventDate = DateTime.Parse(t.date).ToUniversalTime(), ImportDate = DateTime.Now, RawServiceDataId = rawId }).ToList();
            }
            catch (Exception ex)
            {

            }
            return response;
        }
    }
}
