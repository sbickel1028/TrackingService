using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracking.Models.Tracking;

namespace Tracking.Models.TrackingServices.Abstract
{
    public interface INaqelManager
    {
        public string GetNaqelTrackingDetails(string lastMileAWBNumber, TrackingContext context, TrackingCreds creds);
        public List<StagingServiceDatum> RawToStaging(string rawJson, AwbtoProcess awb, int rawId);
    }
}
