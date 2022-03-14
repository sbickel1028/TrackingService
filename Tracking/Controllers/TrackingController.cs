using Tracking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracking.Applications.Interfaces;
using Tracking.Models.TrackingDTO;
using Tracking.Models.TrackingServices;

namespace Tracking.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrackingController : ControllerBase
    {
        private readonly ILogger<TrackingController> _logger;
        private readonly ITrackingService _iTrackingService;
        public TrackingController(ITrackingService iTrackingService, ILogger<TrackingController> logger)
        {
            _logger = logger;
            _iTrackingService = iTrackingService;
        }
        [HttpPost]
        [Route("CreateNewCustomEvent")]
        public CustomTrackingEventDTO CreateNewCustomEvent(CustomTrackingEventDTO request)
        {
            return _iTrackingService.CreateNewCustomEvent(request);
        }
        [HttpPost]
        [Route("InsertTrackingRaw")]
        public RawTrackingResponse InsertTrackingRaw(RawTrackingRequest request)
        {
            return _iTrackingService.InsertTrackingRaw(request);
        }

        [HttpPost]
        [Route("CreateTrackingEvent")]
        public CreateTrackingResponse CreateTrackingEvent(TrackingEventDTO trackingEvent)
        {
            return _iTrackingService.CreateTrackingEvent(trackingEvent);
        }



        [HttpGet]
        [Route("DeleteCustomEvent/{id}")]
        public ResponseBase DeleteCustomEvent(long id)
        {
            return _iTrackingService.DeleteCustomEvent(id);
        }
        [HttpGet]
        [Route("DeleteTrackingEvent/{id}")]
        public ResponseBase DeleteTrackingEvent(long id)
        {
            return _iTrackingService.DeleteTrackingEvent(id);
        }
        [HttpPost]
        [Route("EditCustomEvent")]
        public CustomTrackingEventDTO EditCustomEvent(CustomTrackingEventDTO request)
        {
            return _iTrackingService.EditCustomEvent(request);
        }
        [HttpGet]
        [Route("GetDeliveredDate")]
        public DeliveredResponse GetDeliveredDate(int TrackingServiceId, int SubscriberId, string AWB = null, string CustomAWB = null, string UniqueId = null)
        {
            return _iTrackingService.GetDeliveredDate(TrackingServiceId, SubscriberId, AWB, CustomAWB, UniqueId);
        }
        [HttpGet]
        [Route("GetTracking")]
        public AllTrackingResponse GetTracking(int TrackingServiceId, int SubscriberId, string AWB = null, string CustomAWB = null, string UniqueId = null)
        {
            return _iTrackingService.GetTracking(TrackingServiceId, SubscriberId, AWB, CustomAWB, UniqueId);
        }
        [HttpGet]
        [Route("GetCarrierTracking")]
        public CarrierTrackingResponse GetCarrierTracking(int TrackingServiceId, int SubscriberId, string AWB = null, string CustomAWB = null, string UniqueId = null)
        {
            return _iTrackingService.GetCarrierTracking(TrackingServiceId, SubscriberId, AWB, CustomAWB, UniqueId);
        }
        [HttpGet]
        [Route("ConvertRawToStaging/{rawId}")]
        public ResponseBase ConvertRawToStaging(int rawId)
        {
            return _iTrackingService.ConvertRawToStaging(rawId);
        }
        [HttpPost]
        [Route("ConvertMultipleRawToStaging")]
        public void ConvertMultipleRawToStaging(List<int> rawids)
        {
            _iTrackingService.ConvertMultipleRawToStaging(rawids);
        }
        [HttpPost]
        [Route("InsertAwbToProcess")]
        public AwbToProcessResponse InsertAwbToProcess(AwbToProcessResponse request)
        {
            return _iTrackingService.InsertAwbToProcess(request);
        }
        [HttpPost]
        [Route("InsertSubscriber")]
        public SubscriberReponse InsertSubscriber(SubscriberReponse request)
        {
            return _iTrackingService.InsertSubscriber(request);
        }


    }
}
