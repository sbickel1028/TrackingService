using System;
using System.Collections.Generic;

#nullable disable

namespace Tracking.Models.Tracking
{
    public partial class TrackingService
    {
        public TrackingService()
        {
            AwbtoProcesses = new HashSet<AwbtoProcess>();
            ServiceTrackingEventLookups = new HashSet<ServiceTrackingEventLookup>();
            UnMappedServiceEvents = new HashSet<UnMappedServiceEvent>();
        }

        public int Id { get; set; }
        public string ServiceName { get; set; }
        public bool? IsActive { get; set; }
        public int IntegrationType { get; set; }
        public int StopProcessingAfterXdays { get; set; }
        public string ServiceTrackingUrl { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual ICollection<AwbtoProcess> AwbtoProcesses { get; set; }
        public virtual ICollection<ServiceTrackingEventLookup> ServiceTrackingEventLookups { get; set; }
        public virtual ICollection<UnMappedServiceEvent> UnMappedServiceEvents { get; set; }
    }
}
