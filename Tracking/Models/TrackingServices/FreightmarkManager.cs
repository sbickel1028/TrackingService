using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Tracking.Models.Tracking;
using Tracking.Models.TrackingServices.Abstract;

namespace Tracking.Models.TrackingServices
{
    #region Tracking classes


    public class FreightMarkTrackRequest
    {
        public string AccountKey { get; set; }
        public string CompanyCode { get; set; }
        public string Value { get; set; }
        public int GetOptions { get; set; }
        public int IsConType { get; set; }
    }
    public class FreightMarkTrackResponse
    {
        public string APIStatus { get; set; }
        public string PodStatus { get; set; }
        public string PodDesc { get; set; }

        public Nullable<DateTime> PodDate { get; set; }

        public string PodBranch { get; set; }

        public string Reason { get; set; }
    }
    #endregion
    #region Close Manifest request and response classes

    public class FMCoseManResponse
    {
        public string Status { get; set; }
        public string ResponseMessage { get; set; }
        public List<string> ResponseMessages { get; set; }
        public string Code { get; set; }

    }

    public class FreightMarkCloseManifestRequest
    {
        public string DestinationCode { get; set; }
        public string OriginCode { get; set; }
        public List<FreightMarkConsign> ConsignmentLists { get; set; }
    }
    public class FreightMarkConsign
    {
        public string ConsignmentNo { get; set; }
        public List<FreightMarkCargoDetails> CargoDetails { get; set; }

        public FreightMarkConsign()
        {
            CargoDetails = new List<FreightMarkCargoDetails>();
        }
    }
    public class FreightMarkCargoDetails
    {
        public string CargoID { get; set; }
        public decimal ActualWeight { get; set; }
        public decimal Width { get; set; }
        public decimal Length { get; set; }
        public decimal Height { get; set; }
        public decimal VolumetricWeight { get; set; }
        public decimal Value { get; set; }
        public string Commodity { get; set; }
    }

    #endregion
    #region prealert and label classes
    public class FreightAuthResponse
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string expires_in { get; set; }
        public string userName { get; set; }
        public string name { get; set; }
        public string programId { get; set; }
        public string companyCode { get; set; }
        public string location { get; set; }
        public string roles { get; set; }

        [DataMember(Name = ".issued")]
        public string issued { get; set; }
        [DataMember(Name = ".expires")]
        public string expires { get; set; }

        public string error { get; set; }
    }

    public class FreightMarkRequest
    {
        public string CompanyCode { get; set; }
        public string ProgramId { get; set; }
        public string OrderDate { get; set; }
        public string CustomerReference1 { get; set; }
        public string Remark { get; set; }
        public string AccountKey { get; set; }
        public string AccountName { get; set; }
        //What will we be using?
        public string ServiceCode { get; set; }
        public string Commodity { get; set; }
        public string Currency { get; set; }
        public string Value { get; set; }
        public string Weight { get; set; }
        public string Volume { get; set; }
        public string Quantity { get; set; }
        //unit of measure? PAR for parcels?
        public string Uom { get; set; }
        public string ShipperName { get; set; }
        public string ShipperAddress1 { get; set; }
        public string ShipperPostcode { get; set; }
        public string ShipperCity { get; set; }
        public string ShipperState { get; set; }
        public string ShipperCountry { get; set; }
        //what do we use here?
        public string ShipperContactName { get; set; }
        public string ShipperContactTel { get; set; }
        public string ShipperMobileNo { get; set; }
        public string ShipperEmail { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverAddress1 { get; set; }
        public string ReceiverAddress2 { get; set; }
        public string ReceiverPostcode { get; set; }
        public string ReceiverCity { get; set; }
        public string ReceiverState { get; set; }
        public string ReceiverRegion { get; set; }
        public string ReceiverCountry { get; set; }
        public string ReceiverContactName { get; set; }
        public string ReceiverContactTel { get; set; }
        public string ReceiverMobileNo { get; set; }
        public string ReceiverEmail { get; set; }
        public string LabelImg { get; set; }

    }

    public class FreightMarkConResponse
    {
        public string APIStatus { get; set; }
        public string CnoteNo { get; set; }
        public string RouteID { get; set; }
        public string NearUID { get; set; }
        public string Reason { get; set; }
        public string pdf { get; set; }
    }
    public class FreightMarkLabelResponse
    {
        public string pdf { get; set; }
    }
    #endregion
    public class FreightmarkManager : IFreightmarkManager
    {
        public string FreightMarkAuthorization(TrackingCreds creds)
        {
            string token = string.Empty;
            string AuthURL = creds.AuthUrl;
            string userName = creds.UserName;
            string pw = creds.Password;
            string data = String.Format("username={0}&password={1}&grant_type=password", userName, pw);
            string url = string.Format(AuthURL);
            FreightAuthResponse resp = JsonConvert.DeserializeObject<FreightAuthResponse>((ApiTools.PostWebApiURLEncode(data, new Uri(url))).ToString());
            if (resp != null)
            {
                if (!String.IsNullOrEmpty(resp.error))
                {

                    return token;
                }
                token = resp.access_token;
            }
            return token;
        }
        public string GetFreightMarkTrackingDetails(string lastMileAWBNumber, TrackingContext context, TrackingCreds creds)
        {
            string result = null;
            string clientID = creds.UserName;
            string token = FreightMarkAuthorization(creds);
            string trackURL = creds.Url;
            if (String.IsNullOrEmpty(token))
            {
                //UdpLog.SendUdpLog("Error in FreightMarkManager.GetFreightMarkTrackingDetails", "Unable to get Freight Mark Authorization token for last AWBNumber: " + lastMileAWBNumber, (int)ApplicationError.Severity.Critical, null, null);
            }
            try
            {
                string data = String.Format("AccountKey={0}&CompanyCode=FXFX&ConsignmentNo={1}&GetOptions=2&IsConType=1", clientID, lastMileAWBNumber);
                Dictionary<string, string> headers = new Dictionary<string, string>();
                headers.Add("Authorization", string.Format("Bearer {0}", token));
                result = ApiTools.PostWebApiURLEncode(data, new Uri(trackURL), headers).ToString();
            }
            catch (Exception ex)
            {
                //UdpLog.SendUdpLog("Error in FreightMarkManager.GetFreightMarkTrackingDetails", "Freight Mark Tracking Failed for last AWBNumber: " + lastMileAWBNumber, (int)ApplicationError.Severity.Critical, null, ex);
            }

            return result;
        }
        public List<StagingServiceDatum> RawToStaging(string rawJson, AwbtoProcess awb, int rawId)
        {
            var data = JsonConvert.DeserializeObject<List<FreightMarkTrackResponse>>(rawJson);
            List<StagingServiceDatum> response = null;

            try
            {
                response = (from t in data
                            select new StagingServiceDatum { AwbtoProcessId = awb.Id, Code = t.PodDesc, Description = t.PodDesc, EventDate = t.PodDate.Value, ImportDate = DateTime.Now, RawServiceDataId = rawId, Location = t.PodBranch }).ToList();
            }
            catch (Exception ex)
            {

            }
            return response;
        }
    }
}
