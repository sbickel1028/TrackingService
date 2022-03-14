using System;
using System.Collections.Generic;

#nullable disable

namespace Tracking.Models.Tracking
{
    public partial class ServiceTrackingEventLookup
    {
        public int Id { get; set; }
        public int TrackingServiceId { get; set; }
        public int? SubscriberId { get; set; }
        public bool IsActive { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool DeliveredEvent { get; set; }
        public bool SurpressEvent { get; set; }
        public int? CustomTrackingEventId { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual TrackingService TrackingService { get; set; }
    }
}
