using Tracking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracking.Models.TrackingDTO
{
    public class AwbToProcessResponse : ResponseBase
    {
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

        public AwbToProcessResponse()
        {
            IsSuccess = false;
            Errors = new List<ResponseError>();
        }
    }
}
