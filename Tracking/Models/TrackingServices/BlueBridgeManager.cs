using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracking.Models.Tracking;
using Tracking.Models.TrackingServices.Abstract;

namespace Tracking.Models.TrackingServices
{

    #region Blue Bridge Response classes
    public class BridgeBlueStatus
    {
        public string status { get; set; }
        public string timestamp { get; set; }
        public BridgeBlueLocation location { get; set; }
    }
    public class BridgeBlueLocation
    {
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string country { get; set; }
    }
    #endregion
    public class BlueBridgeManager : IBlueBridgeManager,IDisposable
    {
        public void Dispose()
        {
        }

        public string GetBridgeBlueTracking(string lastMileAWBNumber, TrackingContext context, TrackingCreds creds)
        {
            string response = null;
            try
            {
                var url = string.Format(creds.Url, lastMileAWBNumber);
                Dictionary<string, string> headers = new Dictionary<string, string>();
                string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(creds.UserName + ":" + creds.Password));
                headers.Add("Authorization", "Basic " + credentials);
                response = ApiTools.GetWebApi(null, new Uri(url), headers).ToString();
            }
            catch (Exception ex)
            {

            }
            return response;
        }

        public List<StagingServiceDatum> RawToStaging(string rawJson, AwbtoProcess awb, int rawId)
        {
            var data = JsonConvert.DeserializeObject<List<BridgeBlueStatus>>(rawJson);
            List<StagingServiceDatum> response = null;

            try
            {
                response = (from t in data
                            select new StagingServiceDatum { AwbtoProcessId = awb.Id, Code = t.status, Description = t.status, EventDate = DateTime.Parse(t.timestamp), ImportDate = DateTime.Now, RawServiceDataId = rawId, Location = string.Format("{0}, {1} {2}", t.location.city, t.location.state, t.location.country) }).ToList();
            }
            catch (Exception ex)
            {

            }
            return response;
        }
    }
}
