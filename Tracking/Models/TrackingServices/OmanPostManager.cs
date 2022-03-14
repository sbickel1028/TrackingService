using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Tracking.Caching;
using Tracking.Models.Tracking;
using Tracking.Models.TrackingServices.Abstract;

namespace Tracking.Models.TrackingServices
{
    public partial class OmanPostTrackingResponse
    {
        [JsonProperty("Eventdesc")]
        public string Eventdesc { get; set; }

        [JsonProperty("office")]
        public string Office { get; set; }

        [JsonProperty("eventdate")]
        public System.DateTimeOffset Eventdate { get; set; }
    }
    public class AsyadExpressDatum
    {
        public string status { get; set; }
        public string statusTime { get; set; }
        public string remarks { get; set; }
        public string statusCode { get; set; }
    }

    public class AsyadExpressTrackingResponse
    {
        public int status { get; set; }
        public string message { get; set; }
        public IList<AsyadExpressDatum> data { get; set; }
    }

    public partial class OmanPostTrackingResponse
    {
        public static OmanPostTrackingResponse[] FromJson(string json) { return JsonConvert.DeserializeObject<OmanPostTrackingResponse[]>(json, Converter.Settings); }
        public static AsyadExpressTrackingResponse FromAEJson(string json) { return JsonConvert.DeserializeObject<AsyadExpressTrackingResponse>(json, Converter.Settings); }
    }
    #region Order/Label Request Response Objects

    // Auth Objects
    public class AsyadAuthResponseObject
    {
        public int status { get; set; }
        public string message { get; set; }
        public AsyadAuthResponseObjectData data { get; set; }

        public class AsyadAuthResponseObjectData
        {
            public string id { get; set; }
            public string token { get; set; }
            public string email { get; set; }
            public string merchant_code { get; set; }
        }
    }
    public class AsyadAuthRequestObject
    {
        public string username { get; set; }
        public string password { get; set; }
    }
    public class AsyadAuthResponseErrorObject
    {
        public string error_description { get; set; }
        public string error { get; set; }
    }

    // Order Request Objects
    public class AsyadOrderJourneyOptions
    {
        public bool NOReturn { get; set; }
        //public AsyadOrderExtra Extra { get; set; }
    }
    public class AsyadOrderConsignee
    {
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string What3Words { get; set; }
        public string NationalId { get; set; }
        public string ReferenceNo { get; set; }
        public string CompanyName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Instruction { get; set; }
        public string Vattaxcode { get; set; }
        public string Eorinumber { get; set; }
    }
    public class AsyadOrderShipper
    {
        public bool ReturnAsSame { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string MobileNo { get; set; }
        public string TelephoneNo { get; set; }
        public string Email { get; set; }
        public string ReferenceOrderNo { get; set; }
        public string NationalId { get; set; }
        public string What3Words { get; set; }
        public string Vattaxcode { get; set; }
        public string Eorinumber { get; set; }
    }
    public class AsyadOrderReturn
    {
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Area { get; set; }
        public bool City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public int Latitude { get; set; }
        public int Longitude { get; set; }
        public string MobileNo { get; set; }
        public string TelephoneNo { get; set; }
        public string Email { get; set; }
        public string NationalId { get; set; }
        public string What3Words { get; set; }
        public string Vattaxcode { get; set; }
        public string Eorinumber { get; set; }
    }
    public class AsyadOrderPackageDetail
    {
        public int Weight { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
        public int Height { get; set; }
    }
    public class AsyadOrderShipmentPerformaInvoice
    {
        public string HSCode { get; set; }
        public string ProductDescription { get; set; }
        public int ItemQuantity { get; set; }
        public int ProductDeclaredValue { get; set; }
        public string itemRef { get; set; }
        public string ShipmentTypeCode { get; set; }
        public string PackageTypeCode { get; set; }
    }
    public class AsyadOrderRequest
    {
        public string ClientOrderRef { get; set; }
        public string Description { get; set; }
        public string HandlingType { get; set; }
        public int ShippingCost { get; set; }
        public string PaymentType { get; set; }
        public int CODAmount { get; set; }
        public string ShipmentProduct { get; set; }
        public string ShipmentService { get; set; }
        public string OrderType { get; set; }
        public string PickupType { get; set; }
        public string PickupDate { get; set; }
        public string TotalShipmentValue { get; set; }
        public AsyadOrderJourneyOptions JourneyOptions { get; set; }
        public AsyadOrderConsignee Consignee { get; set; }
        public AsyadOrderShipper Shipper { get; set; }
        public AsyadOrderReturn Return { get; set; }
        public List<AsyadOrderPackageDetail> PackageDetails { get; set; }
        public List<AsyadOrderShipmentPerformaInvoice> ShipmentPerformaInvoice { get; set; }
    }

    // Order Response Objects
    public class AsyadOrderResponseData
    {
        public string ClientOrderRef { get; set; }
        public string order_awb_number { get; set; }
    }
    public class AsyadOrderResponse
    {
        public int status { get; set; }
        public bool success { get; set; }
        public AsyadOrderResponseData data { get; set; }
        public string message { get; set; }
    }
    public class AsyadOrderErrorResponseData
    {
        public List<string> errors { get; set; }
    }
    public class AsyadOrderErrorResponse
    {
        public int status { get; set; }
        public bool success { get; set; }
        public AsyadOrderErrorResponseData data { get; set; }
        public string message { get; set; }
    }
    public class AsyadOrderErrorDetailResponse
    {
        public string name { get; set; }
        public string message { get; set; }
        public int code { get; set; }
        public string type { get; set; }
        public string file { get; set; }
        public int line { get; set; }

        [JsonProperty("stack-trace")]
        public List<string> StackTrace { get; set; }
    }

    public class AsyadCreateOrderResponseGrantError
    {
        public string name { get; set; }
        public string message { get; set; }
        public int code { get; set; }
        public int status { get; set; }
    }

    // Label Objects
    public class AsyadGetLabelResponseError
    {
        public int status { get; set; }
        public string message { get; set; }
        public IList<object> data { get; set; }
    }
    public class AsyadGetLabelResponseAwb
    {
        public string labelx4 { get; set; }
        public string a5 { get; set; }
    }
    public class AsyadGetLabelResponseData
    {
        public AsyadGetLabelResponseAwb awb { get; set; }
    }
    public class AsyadGetLabelResponse
    {
        public int status { get; set; }
        public string message { get; set; }
        public AsyadGetLabelResponseData data { get; set; }
    }

    #endregion

    internal class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            NullValueHandling = NullValueHandling.Ignore,
            Converters = {
                new IsoDateTimeConverter()
                {
                    DateTimeStyles = DateTimeStyles.AssumeUniversal,
                },
            },
        };
    }
    public class OmanPostManager : IOmanPostManager, IDisposable
    {
        private static string _Token;
        private TrackingCreds _creds;
        public string Token
        {
            get
            {
                var token = DoAsyadAuthPost();
                if (string.IsNullOrEmpty(token))
                    token = DoAsyadAuthPost();
                return token;
            }
            set
            {
                _Token = value;
            }
        }
        [Cache(cacheKey = "OmanPostManager|OmanPostAuthTokenPostResult", minutesToCache = 1440, group = "Core", subGroup = "CarrierTracking")]
        public string DoAsyadAuthPost()
        {
            string token = string.Empty;
            object retVal = null;
            AsyadAuthResponseObject aro = null;
            AsyadAuthResponseErrorObject areo = null;

            retVal = GetAsyadAPIAuthToken();

            if (retVal != null)
            {
                try
                {
                    aro = JsonConvert.DeserializeObject<AsyadAuthResponseObject>((string)retVal, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                    if (aro != null && aro.data != null)
                    {
                        if (!string.IsNullOrEmpty(aro.data.token))
                        {
                            token = aro.data.token;
                        }
                    }
                    else
                    {
                        areo = JsonConvert.DeserializeObject<AsyadAuthResponseErrorObject>((string)retVal, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                        if (!string.IsNullOrEmpty(areo.error))
                        {
                            if (areo.error == "invalid_grant")
                                return DoAsyadAuthPost();
                            else
                            {
                               // UdpLog.SendUdpLog("OmanPostManager.DoAsyadAuthPost", "OmanPost Asyad get Auth Token failure Master Order Number: " + areo.error + " | " + areo.error_description, (int)ApplicationError.Severity.Serious, null, null);
                            }
                        }
                    }
                }
                catch
                {
                    areo = JsonConvert.DeserializeObject<AsyadAuthResponseErrorObject>((string)retVal, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                    if (!string.IsNullOrEmpty(areo.error))
                    {
                        if (areo.error == "invalid_grant")
                            return DoAsyadAuthPost();
                        //else
                         //   UdpLog.SendUdpLog("OmanPostManager.DoAsyadAuthPost", "OmanPost Asyad get Auth Token failure Master Order Number: " + areo.error + " | " + areo.error_description, (int)ApplicationError.Severity.Serious, null, null);
                    }
                }
            }
            return token;
        }
        public object GetAsyadAPIAuthToken()
        {
            object result = null;
            AsyadAuthRequestObject request = new AsyadAuthRequestObject();
            request.password = _creds.Password;
            request.username = _creds.UserName;

            try
            {
                result = ApiTools.PostWebApi((object)request, new Uri( _creds.AuthUrl));
                return result;
            }
            catch (Exception ex)
            {
               // UdpLog.SendUdpLog("OmanPostManager.GetAsyadAPIAuthToken", "OmanPost Asyad Generate Auth Token API Failure: Error : " + ex.Message, (int)ApplicationError.Severity.Serious, null, null);
            }

            return result;
        }
        public string GetAETrackingDetails(string LastMileAWBNumber, TrackingContext context, TrackingCreds creds)
        {
            string result = null;
            object request = string.Empty;
            var trkURL = string.Format(creds.Url, LastMileAWBNumber);
            _creds = creds;
            try
            {
                Dictionary<string, string> headers = new Dictionary<string, string>();
                headers.Add("Authorization", string.Format("Bearer {0}", Token));
                result = ApiTools.GetWebApi((object)request, new Uri(trkURL), headers).ToString();
                return result;
            }
            catch (Exception ex)
            {
               // UdpLog.SendUdpLog("Error in OmanPostManager.GetAETrackingDetails", "OmanPost Get Tracking Details Error, Last Mile AWB: " + LastMileAWBNumber, (int)ApplicationError.Severity.Critical, null, ex);
            }

            return result;
        }
        public List<StagingServiceDatum> RawToStaging(string rawJson, AwbtoProcess awb, int rawId)
        {
            var data = OmanPostTrackingResponse.FromAEJson((string)rawJson);
            List<StagingServiceDatum> response = null;

            try
            {
                response = (from t in data.data
                            select new StagingServiceDatum { AwbtoProcessId = awb.Id, Code = t.statusCode, Description = t.status, EventDate = DateTime.Parse(t.statusTime), ImportDate = DateTime.Now, RawServiceDataId = rawId }).ToList();
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
