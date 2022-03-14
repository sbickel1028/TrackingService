using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracking.Models.Tracking;

namespace Tracking.Models.TrackingServices.Abstract
{
    public interface IFedExManager
    {
        public string GetFedexTracking(string TrackingNumber, TrackingContext context, TrackingCreds creds, bool IsGround = false);
        public List<StagingServiceDatum> RawToStaging(string rawJson, AwbtoProcess awb, int rawId);
    }
}
