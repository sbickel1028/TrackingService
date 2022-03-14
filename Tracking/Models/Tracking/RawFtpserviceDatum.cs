using System;
using System.Collections.Generic;

#nullable disable

namespace Tracking.Models.Tracking
{
    public partial class RawFtpserviceDatum
    {
        public int Id { get; set; }
        public string Awb { get; set; }
        public string RawData { get; set; }
        public DateTime ImportDate { get; set; }
        public DateTime? ProcessedDate { get; set; }
    }
}
