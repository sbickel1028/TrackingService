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
    public class EgyptPostResponse
    {
        public List<EgyptEvents> ShipmentEvents { get; set; }
    }
    public class EgyptEvents
    {
        public DateTime Timestamp { get; set; }
        public string EventCode { get; set; }
        public string EventDescription { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public string StateOrProvince { get; set; }
        public string Country { get; set; }
    }
    public class EgyptPostManager : IEgyptPostManager
    {
        public string GetEgyptPostTracking(string lastMileAWBNumber, TrackingContext context, TrackingCreds creds)
        {
            string response = null;
            var url = string.Format(creds.Url, lastMileAWBNumber);
            Dictionary<string, string> headers = new Dictionary<string, string>();
            var token = Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", creds.UserName, creds.Password)));
            headers.Add("Authorization", string.Format("Basic {0}", token));
            response = JsonConvert.SerializeObject((ApiTools.GetWebApi(null, new Uri(url), headers)).ToString());
            return response;
        }
        public List<StagingServiceDatum> RawToStaging(string rawJson, AwbtoProcess awb, int rawId)
        {
            var data = JsonConvert.DeserializeObject<EgyptPostResponse>(rawJson);
            List<StagingServiceDatum> response = null;

            try
            {
                response = (from t in data.ShipmentEvents
                            select new StagingServiceDatum { AwbtoProcessId = awb.Id, Code = t.EventCode, Description = t.EventDescription, EventDate = t.Timestamp, ImportDate = DateTime.Now, RawServiceDataId = rawId, Location = string.Format("{0} {1}, {2} {3}", t.Location, t.City, t.StateOrProvince, t.Country) }).ToList();
            }
            catch (Exception ex)
            {

            }
            return response;
        }
    }
}
