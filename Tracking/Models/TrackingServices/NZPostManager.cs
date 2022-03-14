using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracking.Models.Tracking;
using Tracking.Models.TrackingServices.Abstract;

namespace Tracking.Models.TrackingServices
{
    #region Tracking Request/Response
    public class AuthResponseObject
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
    }
    public class AuthResponseErrorObject
    {
        public string error_description { get; set; }
        public string error { get; set; }
    }

    public class SignedBy
    {
        public string name { get; set; }
        public string signature { get; set; }
    }

    public class ExternalTrackingEvents
    {
        public string tracking_reference { get; set; }
        public string source { get; set; }
        public string status_description { get; set; }
        public string event_description { get; set; }
        public DateTime event_datetime { get; set; }
        public SignedBy signed_by { get; set; }
        public string event_edifact_code { get; set; }
    }

    public class ExternalTrackingResults
    {
        public string message_id { get; set; }
        public string tracking_reference { get; set; }
        public DateTime message_datetime { get; set; }
        public string service { get; set; }
        public string carrier { get; set; }
        public List<ExternalTrackingEvents> tracking_events { get; set; }
    }

    public class ExternalTrackingParcelResponse
    {
        public bool success { get; set; }
        public ExternalTrackingResults results { get; set; }
    }

    #endregion
    public class NZPostManager : INZPostManager, IDisposable
    {
        public void Dispose()
        {
            
        }

        public string GetNZPTrackingDetails(string LastMileAWBNumber, TrackingContext context, TrackingCreds creds)
        {
            string result = null;
            object request = string.Empty;
            var trkURL = string.Format(creds.Url, LastMileAWBNumber);

            try
            {
                // post to the web api
                Dictionary<string, string> headers = new Dictionary<string, string>();
                headers.Add("Authorization", string.Format("Bearer {0}", creds.Token));
                headers.Add("client_id", creds.UserName);

                result = ApiTools.GetWebApi((object)request, new Uri(trkURL), headers).ToString();
                return result;
            }
            catch (Exception ex)
            {
               // UdpLog.SendUdpLog("Error in NZPostManager.GetNZPTrackingDetails", "NZPost Get Label Status API Failure, Shipment Invoice Number", (int)ApplicationError.Severity.Critical, null, ex);
            }

            return result;

        }

        public List<StagingServiceDatum> RawToStaging(string rawJson, AwbtoProcess awb, int rawId)
        {
            var data = JsonConvert.DeserializeObject<ExternalTrackingParcelResponse>(rawJson);
            List<StagingServiceDatum> response = null;

            try
            {
                response = (from t in data.results.tracking_events
                            select new StagingServiceDatum { AwbtoProcessId = awb.Id, Code = t.status_description, Description = t.event_description, EventDate = t.event_datetime.ToUniversalTime(), ImportDate = DateTime.Now, RawServiceDataId = rawId }).ToList();
            }
            catch (Exception ex)
            {

            }
            return response;
        }
    }
}
