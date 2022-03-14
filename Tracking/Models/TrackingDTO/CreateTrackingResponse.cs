using Tracking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracking.Models.TrackingDTO
{
    public class CreateTrackingResponse : ResponseBase 
    {
        public CreateTrackingResponse()
        {
            IsSuccess = false;
            Errors = new List<ResponseError>();
        }
        public TrackingEventDTO trackingEvent { get; set; }
    }
}
