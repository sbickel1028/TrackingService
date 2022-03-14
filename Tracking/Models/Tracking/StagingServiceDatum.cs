using System;
using System.Collections.Generic;

#nullable disable

namespace Tracking.Models.Tracking
{
    public partial class StagingServiceDatum
    {
        public int Id { get; set; }
        public int RawServiceDataId { get; set; }
        public int AwbtoProcessId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime ImportDate { get; set; }
        public DateTime? ProcessedDate { get; set; }

        public virtual AwbtoProcess AwbtoProcess { get; set; }
        public virtual RawServiceDatum RawServiceData { get; set; }
    }
}
