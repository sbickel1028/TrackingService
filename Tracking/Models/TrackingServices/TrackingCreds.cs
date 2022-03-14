using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracking.Models.TrackingServices
{
    public class TrackingCreds
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string Key { get; set; }
        public string Url { get; set; }
        public string SecondUrl { get; set; }
        public string StatusUrl { get; set; }
        public string LocationId { get; set; }
        public string Account { get; set; }
        public string Meter { get; set; }
        public string AuthUrl { get; set; }
        public string Version { get; set; }
    }
}
