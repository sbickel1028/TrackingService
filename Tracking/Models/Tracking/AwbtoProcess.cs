using System;
using System.Collections.Generic;

#nullable disable

namespace Tracking.Models.Tracking
{
    public partial class AwbtoProcess
    {
        public AwbtoProcess()
        {
            RawServiceData = new HashSet<RawServiceDatum>();
            StagingServiceData = new HashSet<StagingServiceDatum>();
            TrackingEvents = new HashSet<TrackingEvent>();
        }

        public int Id { get; set; }
        public int TrackingServiceId { get; set; }
        public int SubscriberId { get; set; }
        public string UniqueId { get; set; }
        public int? TrackingLeg { get; set; }
        public string Awb { get; set; }
        public DateTime ShipDate { get; set; }
        public string CustomAwb { get; set; }
        public int StopProcessingAfterXdays { get; set; }
        public DateTime? LastProcessedDate { get; set; }
        public DateTime? StopProcessingDate { get; set; }
        public string TrackingServiceCredentials { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual Subscriber Subscriber { get; set; }
        public virtual TrackingService TrackingService { get; set; }
        public virtual ICollection<RawServiceDatum> RawServiceData { get; set; }
        public virtual ICollection<StagingServiceDatum> StagingServiceData { get; set; }
        public virtual ICollection<TrackingEvent> TrackingEvents { get; set; }
    }
}
