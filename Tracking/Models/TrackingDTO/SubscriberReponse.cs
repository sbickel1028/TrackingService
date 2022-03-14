using Tracking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracking.Models.TrackingDTO
{
    public class SubscriberReponse : ResponseBase
    {
        public int Id { get; set; }
        public string Subscriber1 { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? UnsubscribeDate { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public SubscriberReponse()
        {
            IsSuccess = false;
            Errors = new List<ResponseError>();
        }
    }
}
