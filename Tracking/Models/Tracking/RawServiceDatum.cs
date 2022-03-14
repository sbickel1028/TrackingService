using System;
using System.Collections.Generic;

#nullable disable

namespace Tracking.Models.Tracking
{
    public partial class RawServiceDatum
    {
        public RawServiceDatum()
        {
            StagingServiceData = new HashSet<StagingServiceDatum>();
        }

        public int Id { get; set; }
        public int AwbtoProcessId { get; set; }
        public string Awb { get; set; }
        public string RawData { get; set; }
        public DateTime ImportDate { get; set; }
        public DateTime? ProcessedDate { get; set; }

        public virtual AwbtoProcess AwbtoProcess { get; set; }
        public virtual ICollection<StagingServiceDatum> StagingServiceData { get; set; }
    }
}
