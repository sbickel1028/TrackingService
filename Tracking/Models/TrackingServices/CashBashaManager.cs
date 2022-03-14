using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracking.Models.Tracking;
using Tracking.Models.TrackingServices.Abstract;

namespace Tracking.Models.TrackingServices
{
    #region Tracking Classes

    public class Attempt
    {
        public string status { get; set; }
        public DateTime timestamp { get; set; }
        public int attempt { get; set; }
        public long timestamp_seconds { get; set; }
    }

    public class Status
    {
        public string status { get; set; }
        public DateTime timestamp { get; set; }
        public long timestamp_seconds { get; set; }
    }

    public class Payload
    {
        public int attempts_number { get; set; }
        public string receiver_name { get; set; }
        public List<Attempt> attempts { get; set; }
        public string awb { get; set; }
        public List<Status> statuses { get; set; }
    }

    public class CashbashaTrackingResponse
    {
        public string status { get; set; }
        public string reason { get; set; }
        public int code { get; set; }
        public Payload payload { get; set; }
    }
    #endregion

    public class CashBashaManager : ICashbashaManager
    {
        public string GetCBTrackingDetails(string LastMileAWBNumber, TrackingContext context, TrackingCreds creds)
        {
            string result = null;
            object request = string.Empty;
            var trkURL = string.Format(creds.Url, LastMileAWBNumber);

            try
            {
                // post to the web api
                Dictionary<string, string> headers = new Dictionary<string, string>();
                String encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(creds.UserName + ":" + creds.Password));
                headers.Add("Authorization", string.Format("Basic {0}", encoded));

                result = ApiTools.GetWebApi((object)request, new Uri(trkURL), headers).ToString();
                return result;
            }
            catch (Exception ex)
            {
                //UdpLog.SendUdpLog("Error in CashbashaManager.GetCBTrackingDetails", "Cashbasha Get Label Status API Failure, Shipment Invoice Number", (int)ApplicationError.Severity.Critical, null, ex);
            }

            return result;
        }
        public List<StagingServiceDatum> RawToStaging(string rawJson, AwbtoProcess awb, int rawId)
        {
            var data = JsonConvert.DeserializeObject<CashbashaTrackingResponse>(rawJson);
            List<StagingServiceDatum> response = null;

            try
            {
                response = (from t in data.payload.statuses
                            select new StagingServiceDatum { AwbtoProcessId = awb.Id, Code = t.status, Description = t.status, EventDate = t.timestamp, ImportDate = DateTime.Now, RawServiceDataId = rawId }).ToList();
            }
            catch (Exception ex)
            {

            }
            return response;
        }
    }
}
