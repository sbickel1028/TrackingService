using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracking.Models.Tracking;
using Tracking.Models.TrackingServices.Abstract;

namespace Tracking.Models.TrackingServices
{
    public class BermudaResponse
    {
        public string MailItemId { get; set; }
        public List<BermudaEvent> Events { get; set; }
        public bool MatchFound { get; set; }
    }
    public class BermudaEvent
    {
        public BermudaGenericEvent MailItemEvent { get; set; }
        public DateTime LocalDate { get; set; }
        public BermudaGenericEvent Country { get; set; }
        public string Location { get; set; }
        public BermudaGenericEvent MailCategory { get; set; }
        public string NextOffice { get; set; }
        public BermudaGenericEvent NonDeliveryReason { get; set; }
        public BermudaGenericEvent NonDeliveryMeasure { get; set; }
        public BermudaGenericEvent RetentionReason { get; set; }
        public string SignatoryName { get; set; }
        public string SignatureBase64 { get; set; }
    }
    public class BermudaGenericEvent
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string LocalName { get; set; }
    }
    public class BermudaManager : IBermudaManager
    {
        public string GetBermudaTrackingDetails(string lastMileAWBNumber, TrackingContext context, TrackingCreds creds)
        {
            string response = null;
            string url = string.Format(creds.Url, lastMileAWBNumber);
            response = ApiTools.GetWebApi(null, new Uri(url)).ToString();
            return response;
        }

        public List<StagingServiceDatum> RawToStaging(string rawJson, AwbtoProcess awb, int rawId)
        {
            var data = JsonConvert.DeserializeObject<BermudaResponse>(rawJson);
            List<StagingServiceDatum> response = null;

            try
            {
                response = (from t in data.Events
                            select new StagingServiceDatum { AwbtoProcessId = awb.Id, Code = t.MailItemEvent.Code, Description = t.MailItemEvent.Name, EventDate = t.LocalDate, ImportDate = DateTime.Now, RawServiceDataId = rawId }).ToList();
            }
            catch(Exception ex)
            {

            }
            return response;
        }
    }
}
