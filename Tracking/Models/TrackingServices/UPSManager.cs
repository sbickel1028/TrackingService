using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Tracking.Models.Tracking;
using Tracking.Models.TrackingServices.Abstract;

namespace Tracking.Models.TrackingServices
{
    public class UPSResponse
    {
        public class Xml
        {
            public string version { get; set; }
        }

        public class TransactionReference
        {
            public string CustomerContext { get; set; }
            public string XpciVersion { get; set; }
        }

        public class Response
        {
            public TransactionReference TransactionReference { get; set; }
            public string ResponseStatusCode { get; set; }
            public string ResponseStatusDescription { get; set; }
        }

        public class Address
        {
            public string AddressLine1 { get; set; }
            public string City { get; set; }
            public string StateProvinceCode { get; set; }
            public string PostalCode { get; set; }
            public string CountryCode { get; set; }
        }

        public class Shipper
        {
            public string ShipperNumber { get; set; }
            public Address Address { get; set; }
        }

        public class ShipTo
        {
            public Address Address { get; set; }
        }

        public class UnitOfMeasurement
        {
            public string Code { get; set; }
        }

        public class ShipmentWeight
        {
            public UnitOfMeasurement UnitOfMeasurement { get; set; }
            public string Weight { get; set; }
        }

        public class Service
        {
            public string Code { get; set; }
            public string Description { get; set; }
        }

        public class ReferenceNumber
        {
            public string Code { get; set; }
            public string Value { get; set; }
        }

        public class ActivityLocation
        {
            public Address Address { get; set; }
        }

        public class StatusType
        {
            public string Code { get; set; }
            public string Description { get; set; }
        }

        public class StatusCode
        {
            public string Code { get; set; }
        }

        public class Status
        {
            public StatusType StatusType { get; set; }
            public StatusCode StatusCode { get; set; }
        }

        public class Activity
        {
            public ActivityLocation ActivityLocation { get; set; }
            public Status Status { get; set; }
            public string Date { get; set; }
            public string Time { get; set; }
        }

        public class Message
        {
            public string Code { get; set; }
            public string Description { get; set; }
        }

        public class UnitOfMeasurement2
        {
            public string Code { get; set; }
        }

        public class PackageWeight
        {
            public UnitOfMeasurement2 UnitOfMeasurement { get; set; }
            public string Weight { get; set; }
        }

        public class Package
        {
            public string TrackingNumber { get; set; }
            public List<Activity> Activity { get; set; }
            public Message Message { get; set; }
            public PackageWeight PackageWeight { get; set; }
        }

        public class Shipment
        {
            public Shipper Shipper { get; set; }
            public ShipTo ShipTo { get; set; }
            public ShipmentWeight ShipmentWeight { get; set; }
            public Service Service { get; set; }
            public ReferenceNumber ReferenceNumber { get; set; }
            public string ShipmentIdentificationNumber { get; set; }
            public string PickupDate { get; set; }
            public string ScheduledDeliveryDate { get; set; }
            public Package Package { get; set; }
        }

        public class TrackResponse
        {
            public Response Response { get; set; }
            public Shipment Shipment { get; set; }
        }

        public class RootObject
        {
            public Xml Header { get; set; }
            public TrackResponse TrackResponse { get; set; }
        }
    }


    #region Global_Defination 
    public class UPSTrackxml
    {
        public string UpsTrack = @"<?xml version=""1.0""?><AccessRequest xml:lang=""en-US""><AccessLicenseNumber>%AccessLicenseNumber</AccessLicenseNumber><UserId>%UserId</UserId><Password>%Password</Password></AccessRequest><?xml version=""1.0""?><TrackRequest xml:lang=""en-US""><Request><TransactionReference><CustomerContext>QAST Track</CustomerContext><XpciVersion>1.0</XpciVersion></TransactionReference><RequestAction>Track</RequestAction><RequestOption>activity</RequestOption></Request><TrackingNumber>%TrackingNumber</TrackingNumber></TrackRequest>";
    }
    #endregion
    public class UPSManager : IUPSManager, IDisposable
    {
        public void Dispose()
        {
            
        }

        public string GetUpsTracking( string TrackingNumber, bool hasLastMile, TrackingContext context, TrackingCreds creds)
        {
            string result = null;

            try
            {
                string postData = new UPSTrackxml().UpsTrack;
                postData = postData.Replace("%AccessLicenseNumber", creds.Account);
                postData = postData.Replace("%UserId", creds.UserName);
                postData = postData.Replace("%Password", creds.Password);
                postData = postData.Replace("%TrackingNumber", TrackingNumber);

                string output;
                if (ApiTools.WebCall(creds.Url, postData, out output) && output != null)
                {
                    output = output.Replace("@version", "version");
                    output = output.Replace("?xml", "Header");

                    //if (output.IndexOf("\"ActivityLocation\":{") > 0)
                    //{
                    //    output=output.Replace("\"ActivityLocation\":{", "\"ActivityLocation\":[{" );
                    //    output=output.Replace(",\"Status\":", ",],\"Status\":");
                    //}

                    result = output;
                }


            }
            catch { }
            return result;
        }

        public List<StagingServiceDatum> RawToStaging(string rawJson, AwbtoProcess awb, int rawId)
        {
            var data = JsonConvert.DeserializeObject<UPSResponse.RootObject>(rawJson);
            List<StagingServiceDatum> response = null;

            try
            {
                response = (from t in data.TrackResponse.Shipment.Package.Activity
                            select new StagingServiceDatum { AwbtoProcessId = awb.Id, Code = t.Status.StatusType.Code, Description = t.Status.StatusType.Description, EventDate = DateTime.ParseExact(t.Date + t.Time, "yyyyMMddHHmmss", (IFormatProvider)CultureInfo.InvariantCulture), ImportDate = DateTime.Now, RawServiceDataId = rawId, Location = string.Format("{0}, {1} {2}", t.ActivityLocation.Address.City, t.ActivityLocation.Address.StateProvinceCode, t.ActivityLocation.Address.CountryCode) }).ToList();
            }
            catch (Exception ex)
            {

            }
            return response;
        }
    }
}
