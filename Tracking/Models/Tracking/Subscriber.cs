using System;
using System.Collections.Generic;

#nullable disable

namespace Tracking.Models.Tracking
{
    public partial class Subscriber
    {
        public Subscriber()
        {
            AwbtoProcesses = new HashSet<AwbtoProcess>();
            CustomTrackingEvents = new HashSet<CustomTrackingEvent>();
        }

        public int Id { get; set; }
        public string Subscriber1 { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? UnsubscribeDate { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual ICollection<AwbtoProcess> AwbtoProcesses { get; set; }
        public virtual ICollection<CustomTrackingEvent> CustomTrackingEvents { get; set; }
    }
}
