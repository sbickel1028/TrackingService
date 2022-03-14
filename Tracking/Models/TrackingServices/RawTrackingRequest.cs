using Tracking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracking.Models.TrackingServices
{
    public class RawTrackingRequest
    {
        public List<int> AwbToProcessId { get; set; }
    }

    public class RawTrackingResponse : ResponseBase
    {
        public List<RawTrackingResult> results { get; set; }
        public RawTrackingResponse()
        {
            IsSuccess = false;
            Errors = new List<ResponseError>();
            results = new List<RawTrackingResult>();
        }
    }
    public class RawTrackingResult : ResponseBase
    {
        public int AwbToProcessId { get; set; }

        public RawTrackingResult()
        {
            IsSuccess = false;
            Errors = new List<ResponseError>();
        }
    }

}
