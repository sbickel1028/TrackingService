using Tracking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracking.Models.TrackingDTO
{
    public class DeliveredResponse : ResponseBase
    {
        public Nullable<DateTime> DeliveredDate { get; set; }
        public bool IsDelivered { get; set; }
        public DeliveredResponse()
        {
            IsSuccess = false;
            Errors = new List<ResponseError>();
        }
    }
}
