using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracking.Models.TrackingDTO
{
    public class TrackingEventDTO
    {
        public int Id { get; set; }
        public int AwbtoProcessId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime LastProcessedDate { get; set; }
        public DateTime? DeliveredDate { get; set; }
        
    }
}
