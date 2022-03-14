using Tracking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracking.Models.TrackingDTO;
using Tracking.Models.TrackingServices;

namespace Tracking.Applications.Interfaces
{
    public interface ITrackingService
    {
        public CreateTrackingResponse CreateTrackingEvent(TrackingEventDTO trackingEvent);
        public ResponseBase DeleteTrackingEvent(long id);
        public AllTrackingResponse GetTracking(int TrackingServiceId, int SubscriberId, string AWB = null, string CustomAWB = null, string UniqueId = null);
        public CarrierTrackingResponse GetCarrierTracking(int TrackingServiceId, int SubscriberId, string AWB = null, string CustomAWB = null, string UniqueId = null);
        public DeliveredResponse GetDeliveredDate(int TrackingServiceId, int SubscriberId, string AWB = null, string CustomAWB = null, string UniqueId = null);

        public CustomTrackingEventDTO CreateNewCustomEvent(CustomTrackingEventDTO request);
        public ResponseBase DeleteCustomEvent(long id);
        public CustomTrackingEventDTO EditCustomEvent(CustomTrackingEventDTO request);
        public RawTrackingResponse InsertTrackingRaw(RawTrackingRequest request);
        public ResponseBase ConvertRawToStaging(int rawId);
        public void ConvertMultipleRawToStaging(List<int> rawids);
        public AwbToProcessResponse InsertAwbToProcess(AwbToProcessResponse request);
        public SubscriberReponse InsertSubscriber(SubscriberReponse request);
    }
}
