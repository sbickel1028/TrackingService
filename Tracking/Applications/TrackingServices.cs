using Tracking.Models;
using Tracking.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracking.Applications.Interfaces;
using Tracking.Models.TrackingDTO;
using Tracking.Models.TrackingServices;

namespace Tracking.Applications
{
    public class TrackingServices : ITrackingService
    {
        private readonly ITrackingRepository _trackingRespository;

        public TrackingServices(ITrackingRepository trackingRepository)
        {
            _trackingRespository = trackingRepository;
        }
        public CustomTrackingEventDTO CreateNewCustomEvent(CustomTrackingEventDTO request)
        {
            return _trackingRespository.CreateNewCustomEvent(request);
        }

        public CreateTrackingResponse CreateTrackingEvent(TrackingEventDTO trackingEvent)
        {
            return _trackingRespository.CreateTrackingEvent(trackingEvent);
        }

        public RawTrackingResponse InsertTrackingRaw(RawTrackingRequest request)
        {
            return _trackingRespository.InsertTrackingRaw(request);
        }
        public ResponseBase DeleteCustomEvent(long id)
        {
            return _trackingRespository.DeleteCustomEvent(id);
        }

        public ResponseBase DeleteTrackingEvent(long id)
        {
            return _trackingRespository.DeleteTrackingEvent(id);
        }

        public CustomTrackingEventDTO EditCustomEvent(CustomTrackingEventDTO request)
        {
            return _trackingRespository.EditCustomEvent(request);
        }

        public DeliveredResponse GetDeliveredDate(int TrackingServiceId, int SubscriberId, string AWB = null, string CustomAWB = null, string UniqueId = null)
        {
            return _trackingRespository.GetDeliveredDate(TrackingServiceId, SubscriberId, AWB, CustomAWB, UniqueId);
        }

        public CarrierTrackingResponse GetCarrierTracking(int TrackingServiceId, int SubscriberId, string AWB = null, string CustomAWB = null, string UniqueId = null)
        {
            return _trackingRespository.GetCarrierTracking(TrackingServiceId, SubscriberId, AWB, CustomAWB, UniqueId);
        }
        public AllTrackingResponse GetTracking(int TrackingServiceId, int SubscriberId, string AWB = null, string CustomAWB = null, string UniqueId = null)
        {
            return _trackingRespository.GetTracking(TrackingServiceId, SubscriberId, AWB, CustomAWB, UniqueId);
        }

        public void ConvertMultipleRawToStaging(List<int> rawids)
        {
            _trackingRespository.ConvertMultipleRawToStaging(rawids);
        }
        public ResponseBase ConvertRawToStaging(int rawId)
        {
            return _trackingRespository.ConvertRawToStaging(rawId);
        }
        public AwbToProcessResponse InsertAwbToProcess(AwbToProcessResponse request)
        {
            return _trackingRespository.InsertAwbToProcess(request);
        }
        public SubscriberReponse InsertSubscriber(SubscriberReponse request)
        {
            return _trackingRespository.InsertSubscriber(request);
        }
    }
}
