using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracking.Models.Tracking;
using Tracking.Models.TrackingServices.Abstract;

namespace Tracking.Models.TrackingServices
{
    public class RedBoxResponse
    {
        public bool success { get; set; }
        public RedboxData data { get; set; }
        public string message { get; set; }
    }

    public class RedboxData
    {
        public int id { get; set; }
        public string reference_no { get; set; }
        public int tracking_id { get; set; }
        public Nullable<int> last_tracking_status_id { get; set; }
        public string tracking_no { get; set; }
        public Nullable<DateTime> estimated_delivery_date { get; set; }
        public string destination_island { get; set; }
        public string destination_address { get; set; }
        public string desctination_contact_number { get; set; }
        public string address_name { get; set; }
        public string trasport_medium { get; set; }
        public int item_count { get; set; }
        public RedBoxStatus status { get; set; }
        public List<RedboxTrackingLog> tracking_log { get; set; }
        public string picking_location { get; set; }
    }


    public class RedBoxStatus
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime created_at { get; set; }
        public Nullable<DateTime> updated_at { get; set; }
        public Nullable<DateTime> deleted_at { get; set; }
    }

    public class RedboxTrackingLog
    {
        public int id { get; set; }
        public int tracking_id { get; set; }
        public int location_id { get; set; }
        public int status_id { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public Nullable<DateTime> created_at { get; set; }
        public Nullable<DateTime> updated_at { get; set; }
        public Nullable<DateTime> deleted_at { get; set; }
        public Nullable<int> country_id { get; set; }
        public Nullable<int> profile_id { get; set; }
        public RedBoxStatus status { get; set; }
        public RedBoxLocaion location { get; set; }
    }
    public class RedBoxLocaion
    {
        public int id { get; set; }
        public string name { get; set; }
        public Nullable<int> parent_id { get; set; }
        public string type { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
        public Nullable<DateTime> created_at { get; set; }
        public Nullable<DateTime> updated_at { get; set; }
        public Nullable<DateTime> deleted_at { get; set; }
        public string prefix { get; set; }
        public string code { get; set; }

    }
    public class RedboxManager : IRedboxManger
    {
        public string GetRedboxTrackingDetails(string lastAwbNumber, TrackingContext context, TrackingCreds creds)
        {
            string response = null;

            try
            {
                string url = string.Format(creds.UserName, lastAwbNumber);
                response = JsonConvert.SerializeObject(ApiTools.GetWebApi(null, new Uri(url)));

            }
            catch (Exception ex)
            {
                //UdpLog.SendUdpLog("Error in RedBoxManager.GetRedboxTrackingDetails", "Redbox Tracking Failed for last AWBNumber: " + lastAwbNumber, (int)MyUs.Logging.ApplicationError.Severity.Critical, null, ex);
            }

            return response;
        }

        public List<StagingServiceDatum> RawToStaging(string rawJson, AwbtoProcess awb, int rawId)
        {
            var data = JsonConvert.DeserializeObject<RedBoxResponse>(rawJson);
            List<StagingServiceDatum> response = null;

            try
            {
                response = (from t in data.data.tracking_log
                            select new StagingServiceDatum { AwbtoProcessId = awb.Id, Code = t.status.name, Description = t.status.name, EventDate = t.created_at.Value, ImportDate = DateTime.Now, RawServiceDataId = rawId, Location = t.location.name }).ToList();
            }
            catch (Exception ex)
            {

            }
            return response;
        }
    }
}
