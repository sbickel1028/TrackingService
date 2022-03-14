using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracking.Models.TrackingDTO
{
    public class CarrierTrackingResponse
    {
        public string TrackingNumber { get; set; }
        public string TrackingNumberUniqueIdentifier { get; set; }
        public DateTime ShipDate { get; set; }
        public decimal BillWeight { get; set; }
        public DateTime ActualDelivery { get; set; }
        public string ShipAddress { get; set; }
        public string DestinationAddress { get; set; }
        public string ShipmentStatus { get; set; }
        public bool IsSuccess { get; set; }
        public bool IsDelivered { get; set; }
        public List<CarrierEvent> Events { get; set; }
    }

    public class CarrierEvent
    {
        public DateTime Timestamp { get; set; }
        public string EventType { get; set; }
        public string EventDescription { get; set; }
        public string City { get; set; }
        public string StateOrProvinceCode { get; set; }
        public string CountryName { get; set; }
        public string ArrivalLocation { get; set; }
        public int SortOrder { get; set; }
    }
}
