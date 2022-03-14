using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracking.Models
{
    public class SampleResponse : ResponseBase
    {
        public List<int> Items { get; set; }
    }

    public class GetItemResponse : ResponseBase
    {
        public int ItemId { get; set; }
    }
}
