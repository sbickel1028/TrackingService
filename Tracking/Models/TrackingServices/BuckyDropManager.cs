using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracking.Models.Tracking;
using Tracking.Models.TrackingServices.Abstract;

namespace Tracking.Models.TrackingServices
{
    #region BuckyDrop Classes
    public class BuckyDropAuthRequest
    {
        public string appCode { get; set; }
        public long currentTime { get; set; }
        public string sign { get; set; }
    }

    public class BuckyDropAuthResponse
    {
        public bool IsSuccess { get; set; }
        public string Token { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ExpDate { get; set; }
        public String Exception { get; set; }
        public string Message { get; set; }

    }
    public class BuckyDropAuthData
    {
        public string appCode { get; set; }
        public string token { get; set; }
        public long createTime { get; set; }
        public long expireTime { get; set; }
    }
    public class BuckyDropTrackRequest
    {
        public string packageCode { get; set; }
    }
    public class BuckyDropTrackResponse
    {
        public bool success { get; set; }
        public BuckyDropTrackData data { get; set; }
        public string errKey { get; set; }
        public int? code { get; set; }
        public string info { get; set; }
        public long currentTime { get; set; }
    }
    public class BuckyDropTrackData
    {
        public string traceNo { get; set; }
        public string serviceName { get; set; }
        public string providerTraceNo { get; set; }
        public string carrierTraceNo { get; set; }
        public string originalCountry { get; set; }
        public string destinationCountry { get; set; }
        public int traceStatus { get; set; }
        public long createTime { get; set; }
        public long updateTime { get; set; }
        public BuckyDropOriginTraceInfo originTraceInfo { get; set; }
        public BuckyDropDestinationTraceInfo destinationTraceInfo { get; set; }

    }
    public class BuckyDropDestinationTraceInfo
    {
        public string carrierName { get; set; }
        public string carrierTraceNo { get; set; }
        public string carrierLink { get; set; }
        public string carrierPhone { get; set; }
        public string carrierLogo { get; set; }
        public List<BuckyDropTraceNodes> traceNodes { get; set; }
    }
    public class BuckyDropOriginTraceInfo
    {
        public string carrierName { get; set; }
        public string carrierTraceNo { get; set; }
        public string carrierLink { get; set; }
        public string carrierPhone { get; set; }
        public string carrierLogo { get; set; }
        public List<BuckyDropTraceNodes> traceNodes { get; set; }
    }
    public class BuckyDropTraceNodes
    {
        public long recordTime { get; set; }
        public string pos { get; set; }
        public string description { get; set; }

    }

    #endregion
    #region BuckyDrop Package Detail classes
    public class BDPackageDetailResponse
    {
        public bool success { get; set; }
        public BDParcelData data { get; set; }
        public string errKey { get; set; }
        public int code { get; set; }
        public string info { get; set; }
        public long currentTime { get; set; }
    }
    public class BDPackageDetailRequest
    {
        public string packageCode { get; set; }
    }
    public class BDParcelData
    {
        public string packageCode { get; set; }
        public int packageStatus { get; set; }
        public int packageType { get; set; }
        public int pkgNormalStatus { get; set; }
        public int pkgAbnormalStatus { get; set; }
        public int packageLockStatus { get; set; }
        public int packageDeclareStatus { get; set; }
        public int packageRisk { get; set; }
        public string packageCommitRemark { get; set; }
        public string buyerNick { get; set; }
        public string buyerPostCode { get; set; }
        public string countryCode { get; set; }
        public string provinceCode { get; set; }
        public string cityName { get; set; }
        public string address { get; set; }
        public decimal packageLength { get; set; }
        public decimal packageWidth { get; set; }
        public decimal packageHeight { get; set; }
        public int packageApprovedStatus { get; set; }
        public string packageApprovedTime { get; set; }
        public string packageApprovedContent { get; set; }
        public int signStatus { get; set; }
        public string createTime { get; set; }
        public string origin { get; set; }
        public List<BDPackageDetail> packageDetailList { get; set; }
        public string packageStatusName { get; set; }
        public int showStatus { get; set; }
        public string showStatusName { get; set; }
        public string packageLockStatusName { get; set; }
        public string packageDeclareStatusName { get; set; }
        public string packageApprovedTypeName { get; set; }
        public string packageApprovedStatusName { get; set; }
    }
    public class BDPackageDetail
    {
        public string packageCode { get; set; }
        public string orderCode { get; set; }
        public int quantity { get; set; }
        public int packageQuantity { get; set; }
        public decimal packageWeight { get; set; }
        public decimal productLength { get; set; }
        public decimal productWidth { get; set; }
        public decimal productHeight { get; set; }
        public string salePrice { get; set; }
        public string categoryCode { get; set; }
        public string categoryName { get; set; }
        public string specifications { get; set; }
        public string productName { get; set; }
        public string productCode { get; set; }
        public string productSkuCode { get; set; }
        public string storeCode { get; set; }
        public string storeName { get; set; }
        public string externalStoreCode { get; set; }
        public string externalStoreName { get; set; }

    }
    #endregion
    public class BuckyDropManager : IBuckyDropManager
    {
        private string GetBuckyDropAuthToken(bool newToken, TrackingCreds creds)
        {
            string token = string.Empty;
            string url = string.Format(creds.AuthUrl, newToken);
            var response = JsonConvert.DeserializeObject<BuckyDropAuthResponse>(ApiTools.GetWebApi(null, new Uri(url)).ToString());
            if (response.IsSuccess)
                token = response.Token;
            return token;
        }        
        public string GetBuckyDropTrackingDetails(string lastMileAWBNumber, TrackingContext context, TrackingCreds creds)
        {
            BuckyDropTrackRequest request = new BuckyDropTrackRequest { packageCode = lastMileAWBNumber };
            string response = null;
            bool isSuccess = false;
            int maxAttempt = 3;
            int attempt = 0;
            try
            {
                string url = creds.Url;
                string token = GetBuckyDropAuthToken(false, creds);
                while (!isSuccess && attempt != maxAttempt)
                {
                    if (token == null)
                        token = GetBuckyDropAuthToken(true, creds);
                    if (token != null)
                    {
                        Dictionary<string, string> headers = new Dictionary<string, string>();
                        headers.Add("Authorization", token);


                        var ret = JsonConvert.DeserializeObject<BuckyDropTrackResponse>(ApiTools.PostWebApi(request, new Uri(url), headers).ToString());
                        if (ret != null && ret.code == 70000012)
                        {
                            token = GetBuckyDropAuthToken(true, creds);
                            attempt++;
                        }
                        else if (ret != null)
                        {
                            isSuccess = true;
                            response = JsonConvert.SerializeObject(ret);
                        }
                    }
                }                
            }
            catch (Exception ex)
            {
               // UdpLog.SendUdpLog("Error in BuckyDropManager.GetBuckyDropTrackingDetails", "Bucky Drop Tracking Failed for last AWBNumber: " + lastMileAWBNumber, (int)ApplicationError.Severity.Critical, null, ex);
            }
            return response;
        }

        public List<StagingServiceDatum> RawToStaging(string rawJson, AwbtoProcess awb, int rawId)
        {
            var data = JsonConvert.DeserializeObject<BuckyDropTrackResponse>(rawJson);
            List<StagingServiceDatum> response = null;

            try
            {
                response = (from t in data.data.originTraceInfo.traceNodes
                            select new StagingServiceDatum { AwbtoProcessId = awb.Id, Code = t.description, Description = t.description, EventDate = new DateTime(1970, 1, 1, 0, 0, 0).AddMilliseconds(Convert.ToDouble(t.recordTime)), ImportDate = DateTime.Now, RawServiceDataId = rawId, Location = t.pos }).ToList();
            }
            catch (Exception ex)
            {

            }
            return response;
        }
    }
}
