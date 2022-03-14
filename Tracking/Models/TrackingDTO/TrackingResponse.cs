using Tracking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracking.Models.TrackingDTO
{
    public class AllTrackingResponse : ResponseBase
    {
        public List<TrackingResponse> tracking { get; set; }
        public AllTrackingResponse()
        {
            IsSuccess = false;
            Errors = new List<ResponseError>();

        }
    }

    public class TrackingResponse 
    {
        public int Id { get; set; }
        public int TrackingServiceId { get; set; }
        public int SubscriberId { get; set; }
        public string UniqueId { get; set; }
        public string AWB { get; set; }
        public string CustomAWB { get; set; }
        public DateTime EventDate { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public Nullable<DateTime> DeliveredDate { get; set; }
        public DateTime LastProcessedDate { get; set; }
    }
}
