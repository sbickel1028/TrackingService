using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracking.Models.Tracking;
using Tracking.Models.TrackingServices.Abstract;

namespace Tracking.Models.TrackingServices
{
    #region Request and Response classes

    public class ExternalTrackingRequest
    {
        public string Key { get; set; }
        public string method { get; set; }
        public string extr_nmr { get; set; }
        public string copa_id { get; set; }
        public string lang_cdg { get; set; }
    }
    public class ExternalTrackingResponse
    {
        public class Response
        {
            public string TRDE_FCH_USER { get; set; }
            public string TPSH_CDG { get; set; }
            public string SHIP_MERCHANT_NAME { get; set; }
            public string SHIP_CONTENT { get; set; }
            public string SHIP_PRICE_VALUE { get; set; }
            public string SHIP_QUANTITY_PIECE { get; set; }
            public string CTRY_NAME { get; set; }
            public string CITY_NAME { get; set; }
            public string TRCK_NMR_FOL { get; set; }
            public string SHIP_CHARGE_WEIGHT { get; set; }
            public string SHIP_PHYSICAL_WEIGHT { get; set; }
            public string SHIP_VOLUMETRIC_WEIGHT { get; set; }
            public string SHIP_SUBTOTAL_CUSTOM { get; set; }
            public string CUSTOM_DATE_PROCESS { get; set; }
            public string SHIP_DATE_PROCESS { get; set; }
            public string SHIP_DATE_CHARGE { get; set; }
            public string SHIP_RATE { get; set; }
            public string SHIP_DISCOUNT { get; set; }
            public string SHIP_INSURANCE_VALUE { get; set; }
            public string SHIP_TOTAL { get; set; }
            public string SHIP_SWT_TYPE_CHARGE_WEIGTH { get; set; }
            public string STATUS { get; set; }
            public string LOCALITY { get; set; }
            public string CHCK_CDG { get; set; }
            public string TRDE_OBS { get; set; }
            public string EXT_TRACK { get; set; }
            public string CHCK_ORDER { get; set; }
            public string TRCK_ID_UNIQUE { get; set; }
        }
        public string success { get; set; }
        public List<Response> response { get; set; }
    }
    public class InsertOrderRequest
    {
        public class Header
        {
            public string EXTR_TRACKING { get; set; }
            public string COUNTRY_CODE { get; set; }
            public string STATE_CODE { get; set; }
            public string CITY_CODE { get; set; }
            public string STATE_NAME { get; set; }
            public string CITY_NAME { get; set; }
            public string FIRST_NAME { get; set; }
            public string LAST_NAME { get; set; }
            public string ADDRESS_CONSIGNEE { get; set; }
            public string ADDRESS2 { get; set; }
            public string ZIPCODE { get; set; }
            public string PHONE { get; set; }
            public string MOBILE_PHONE { get; set; }
            public string EMAIL { get; set; }
            public string ID_NUMBER { get; set; }
            public string MERCHANT_NAME { get; set; }
            public string MERCHANT_NUMBER { get; set; }
            public string MERCHANT_BOX { get; set; }
            public string MERCHANT_CS_EMAIL { get; set; }
            public string MERCHANT_RETURN_ADDRESS { get; set; }
            public string MERCHANT_CS_NAME { get; set; }
            public string ORDER_NUMBER { get; set; }
            public string ORDER_AMOUNT { get; set; }
            public string ORDER_DATE { get; set; }
            public string INTERNAL_NUMBER { get; set; }
            public string MANIFEST_TYPE { get; set; }
            public string CONSOLIDATED { get; set; }
            public string CURRENCY_ISO_CODE { get; set; }
            public string SHIPMENT_FREIGHT { get; set; }
            public string SHIPMENT_INSURANCE { get; set; }
            public string SHIPMENT_DISCOUNT { get; set; }
        }

        public class Detail
        {
            public string HSC { get; set; }
            public string FMPR_CDG { get; set; }
            public string CONTENT_OF_PRODUCT { get; set; }
            public string PHYSICAL_WEIGHT { get; set; }
            public string WEIGHT_TYPE { get; set; }
            public string DIMEN_LENGTH { get; set; }
            public string DIMEN_HEIGHT { get; set; }
            public string DIMEN_WIDTH { get; set; }
            public string DIMEN_UNIT { get; set; }
            public string MERCHANDISE_VALUE { get; set; }
            public string QUANTITY { get; set; }
        }

        public string Key { get; set; }
        public string method { get; set; }
        public string include_label_data { get; set; }
        public string include_label_zpl { get; set; }
        public string zpl_encode_base64 { get; set; }
        public Header header { get; set; }
        public List<Detail> detail { get; set; }
    }

    public class LABELDATA
    {
        public string TRCK_NMR_FOL { get; set; }
        public string SETTINGS_CONTRACT_NUMBER { get; set; }
        public string SETTINGS_USER_NAME { get; set; }
        public string ORDER_LABEL { get; set; }
        public string REMITENTE_NAME { get; set; }
        public string REMITENTE_ADDRESS { get; set; }
        public string REMITENTE_ZIPCODE { get; set; }
        public string REMITENTE_CITY { get; set; }
        public string REMITENTE_ABREVIATION { get; set; }
        public string city_name { get; set; }
        public string consignee_name { get; set; }
        public string consignee_address { get; set; }
        public string consignee_phone { get; set; }
        public string label_url { get; set; }
        public string label_url_pdf { get; set; }
        public string zpl_data { get; set; }
        public string consignee_postal_code { get; set; }
        public string state_abreviation { get; set; }
        public string physical_weight_grams { get; set; }
    }

    public class InsertOrderResponse
    {
        public string TRCK_NMR_FOL { get; set; }
        public string REFERENCE_NUMBER { get; set; }
        public string PRE_RECEPT_HEADER_ID { get; set; }
        public string INVOICE_URL { get; set; }
        public string LABEL_URL { get; set; }
        public string LABEL_URL_PDF { get; set; }
        public string LABEL_ZPL { get; set; }
        public LABELDATA LABEL_DATA { get; set; }
    }

    public class InsertOrderRootObject
    {
        public int success { get; set; }
        public List<InsertOrderResponse> response { get; set; }
    }

    public class ErrorResponse
    {
        [JsonProperty("0")]
        public string __invalid_name__0 { get; set; }

        [JsonProperty("1")]
        public string __invalid_name__1 { get; set; }
    }

    public class ErrorRootObject
    {
        public int success { get; set; }
        public List<ErrorResponse> response { get; set; }
    }
    public class Response
    {
        public DateTime TRDE_FCH_USER { get; set; }
        public string TPSH_CDG { get; set; }
        public string SHIP_MERCHANT_NAME { get; set; }
        public string SHIP_CONTENT { get; set; }
        public double SHIP_PRICE_VALUE { get; set; }
        public int SHIP_QUANTITY_PIECE { get; set; }
        public string CTRY_NAME { get; set; }
        public string CITY_NAME { get; set; }
        public double TRCK_NMR_FOL { get; set; }
        public double SHIP_CHARGE_WEIGHT { get; set; }
        public double SHIP_PHYSICAL_WEIGHT { get; set; }
        public double SHIP_VOLUMETRIC_WEIGHT { get; set; }
        public double SHIP_SUBTOTAL_CUSTOM { get; set; }
        public object CUSTOM_DATE_PROCESS { get; set; }
        public DateTime SHIP_DATE_PROCESS { get; set; }
        public DateTime SHIP_DATE_CHARGE { get; set; }
        public double SHIP_RATE { get; set; }
        public double SHIP_DISCOUNT { get; set; }
        public double SHIP_INSURANCE_VALUE { get; set; }
        public double SHIP_TOTAL { get; set; }
        public object SHIP_SWT_TYPE_CHARGE_WEIGTH { get; set; }
        public string STATUS { get; set; }
        public string LOCALITY { get; set; }
        public string CHCK_CDG { get; set; }
        public string TRDE_OBS { get; set; }
        public string EXT_TRACK { get; set; }
        public double CHCK_ORDER { get; set; }
        public double TRCK_ID_UNIQUE { get; set; }
    }
    #endregion
    public class SkyPostalManager : ISkyPostalManager, IDisposable
    {
        public static class SkypostalClientDefinedFields
        {
            public const string _SKSettings_username = "SkypostalManagerSettings_key";
            public const string _SkypostalTrackingClient_EndpointAddress = "SkypostalManagerSettings_URL";
            public const string _SKSettings_URL = "SkypostalManagerSettings_URL";
            public const string _externalTrackingMethod = "search_tracking_info_by_external_tracking";
            public const string _MerchantName = "Access Shipping LLC dba MyUS.com";
            public const string _MerchantNumber = "689";
            public const string _LangCDG = "lang_cdg";
            public const string _ConsolidatedCode = "0";
            public const string _CurrencyISOCode = "USD";
            public const string _codeStationKWI = "KWI";
            public const string _insertOrderMethod = "insert_order";
            public const string _includeZPL = "1";
            public const string _CountryIsoBR = "BR";
            public const string _CountryIsoCO = "CO";
            public const string _CountryIsoCL = "CL";
            public const string _CountryIsoMX = "MX";
            public const string _CountryIsoCR = "CR";
            public const string _MerchantBoxBR = "735769";
            public const string _MerchantBoxCO = "735770";
            public const string _MerchantBoxCL = "735771";
            public const string _MerchantBoxMX = "735742";
            public const string _MerchantBoxCR = "943857";

            public const string _WeightTypeCode = "LB";
            public const string _DimenUnitCode = "IN";
            public const string _ManifestType = "DDP";

            public const string _True = "1";
            public const string _False = "0";

            public const string _UnknownSender = "Unknown Sender";
        }
        public string GetSKTrackingDetails(string LastMileAWBNumber, TrackingContext context, TrackingCreds creds)
        {
            ExternalTrackingRequest request = new ExternalTrackingRequest();
            string result = null;

            try
            {
                request.Key = creds.UserName;
                request.method = SkypostalClientDefinedFields._externalTrackingMethod;
                request.extr_nmr = LastMileAWBNumber;
                request.copa_id = SkypostalClientDefinedFields._MerchantNumber;
                request.lang_cdg = SkypostalClientDefinedFields._LangCDG;

                // post to the web api
                result = ApiTools.PostWebApi((object)request, new Uri(creds.Url)).ToString();

                return result;
            }
            catch (Exception ex)
            {
                //UdpLog.SendUdpLog(string.Empty, "Error in SkypostalManager.GetSKTrackingDetails", (int)ApplicationError.Severity.Warning, null, ex);
            }

            return result;
        }
        public List<StagingServiceDatum> RawToStaging(string rawJson, AwbtoProcess awb, int rawId)
        {
            var data = JsonConvert.DeserializeObject<ExternalTrackingResponse>(rawJson);
            List<StagingServiceDatum> response = null;

            try
            {
                response = (from t in data.response
                            select new StagingServiceDatum { AwbtoProcessId = awb.Id, Code = t.STATUS, Description = t.STATUS, EventDate = DateTime.Parse(t.TRDE_FCH_USER).ToUniversalTime(), ImportDate = DateTime.Now, RawServiceDataId = rawId, Location = string.Format("{0} {1} {2}", t.LOCALITY, t.CITY_NAME, t.CTRY_NAME) }).ToList();
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
