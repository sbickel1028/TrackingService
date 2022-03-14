using System;
using System.Collections.Generic;

#nullable disable

namespace Tracking.Models.Tracking
{
    public partial class TrackingEvent
    {
        public int Id { get; set; }
        public int AwbtoProcessId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime LastProcessedDate { get; set; }
        public DateTime? DeliveredDate { get; set; }

        public virtual AwbtoProcess AwbtoProcess { get; set; }
    }
}
