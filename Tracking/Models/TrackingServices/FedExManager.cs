using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracking.Models.Tracking;
using Tracking.Models.TrackingServices.Abstract;

namespace Tracking.Models.TrackingServices
{
    #region Global_Defination

    public class FedExResponseXml
    {
        public class Notifications
        {
            public string Severity { get; set; }
            public string Source { get; set; }
            public string Code { get; set; }
            public string Message { get; set; }
            public string LocalizedMessage { get; set; }
        }

        public class Localization
        {
            public string LanguageCode { get; set; }
            public string LocaleCode { get; set; }
        }

        public class TransactionDetail
        {
            public string CustomerTransactionId { get; set; }
            public Localization Localization { get; set; }
        }

        public class Version
        {
            public string ServiceId { get; set; }
            public string Major { get; set; }
            public string Intermediate { get; set; }
            public string Minor { get; set; }
        }

        public class Notifications2
        {
            public string Severity { get; set; }
            public string Source { get; set; }
            public string Code { get; set; }
            public string Message { get; set; }
            public string LocalizedMessage { get; set; }
        }

        public class Notification
        {
            public string Severity { get; set; }
            public string Source { get; set; }
            public string Code { get; set; }
            public string Message { get; set; }
            public string LocalizedMessage { get; set; }
        }

        public class StatusDetail
        {
            public string CreationTime { get; set; }
            public string Code { get; set; }
            public string Description { get; set; }
            public Address Location { get; set; }
        }

        public class PackageIdentifier
        {
            public string Type { get; set; }
            public string Value { get; set; }
            public string TrackingNumberUniqueIdentifier { get; set; }
        }

        public class OtherIdentifier
        {
            public List<PackageIdentifier> PackageIdentifiers { get; set; }
            public string TrackingNumberUniqueIdentifier { get; set; }
        }

        public class Service
        {
            public string Type { get; set; }
            public string Description { get; set; }
            public string ShortDescription { get; set; }
        }

        public class PackageWeight
        {
            public string Units { get; set; }
            public string Value { get; set; }
        }

        public class PackageDimensions
        {
            public string Length { get; set; }
            public string Width { get; set; }
            public string Height { get; set; }
            public string Units { get; set; }
        }

        public class ShipmentWeight
        {
            public string Units { get; set; }
            public string Value { get; set; }
        }

        public class Commodity
        {
            public string NumberOfPieces { get; set; }
            public string Quantity { get; set; }
        }

        public class SpecialHandling
        {
            public string Type { get; set; }
            public string Description { get; set; }
            public string PaymentType { get; set; }
        }


        public class DeliveryOptionEligibilityDetail
        {
            public string Option { get; set; }
            public string Eligibility { get; set; }
        }

        public class Address
        {
            public string City { get; set; }
            public string CountryCode { get; set; }
            public string CountryName { get; set; }
            public string Residential { get; set; }
            public string PostalCode { get; set; }
            public string StateOrProvinceCode { get; set; }
        }

        public class Event
        {
            public string Timestamp { get; set; }
            public string EventType { get; set; }
            public string EventDescription { get; set; }
            public Address Address { get; set; }
            public string ArrivalLocation { get; set; }
            public string StatusExceptionCode { get; set; }
            public string StatusExceptionDescription { get; set; }
        }

        public class TrackDetails
        {
            public Notification Notification { get; set; }
            public string TrackingNumber { get; set; }
            public string TrackingNumberUniqueIdentifier { get; set; }
            public StatusDetail StatusDetail { get; set; }
            public string ServiceCommitMessage { get; set; }
            public string DestinationServiceArea { get; set; }
            public string DestinationServiceAreaDescription { get; set; }
            public string CarrierCode { get; set; }
            public string OperatingCompanyOrCarrierDescription { get; set; }
            //       public List<OtherIdentifier> OtherIdentifiers { get; set; }
            public Service Service { get; set; }
            public PackageWeight PackageWeight { get; set; }
            public PackageDimensions PackageDimensions { get; set; }
            public ShipmentWeight ShipmentWeight { get; set; }
            public string Packaging { get; set; }
            public string PackagingType { get; set; }
            public string PackageSequenceNumber { get; set; }
            public string PackageCount { get; set; }
            //     public List<Commodity> Commodities { get; set; }
            //     public List<SpecialHandling> SpecialHandlings { get; set; }
            public Address ShipperAddress { get; set; }
            public string ShipTimestamp { get; set; }
            public string EstimatedDeliveryTimestamp { get; set; }
            public Address DestinationAddress { get; set; }
            public string ActualDeliveryTimestamp { get; set; }
            public Address ActualDeliveryAddress { get; set; }
            public string DeliveryLocationType { get; set; }
            public string DeliveryLocationDescription { get; set; }
            public string DeliveryAttempts { get; set; }
            public string DeliverySignatureName { get; set; }
            public string TotalUniqueAddressCountInConsolidation { get; set; }
            //    public string NotificationEventsAvailable { get; set; }
            public List<DeliveryOptionEligibilityDetail> DeliveryOptionEligibilityDetails { get; set; }
            public List<Event> Events { get; set; }
        }

        public class CompletedTrackDetails
        {
            public string HighestSeverity { get; set; }
            public Notifications2 Notifications { get; set; }
            public string DuplicateWaybill { get; set; }
            public string MoreData { get; set; }
            public string TrackDetailsCount { get; set; }
            public TrackDetails TrackDetails { get; set; }
        }

        public class TrackReply
        {
            public string xmlns { get; set; }
            public string HighestSeverity { get; set; }
            public Notifications Notifications { get; set; }
            public TransactionDetail TransactionDetail { get; set; }
            public Version Version { get; set; }
            public CompletedTrackDetails CompletedTrackDetails { get; set; }
        }

        public class SOAPENVBody
        {
            public TrackReply TrackReply { get; set; }
        }

        public class SOAPENVEnvelope
        {
            public string ENV { get; set; }
            public object Header { get; set; }
            public SOAPENVBody Body { get; set; }
        }

        public class RootObject
        {
            public SOAPENVEnvelope Envelope { get; set; }
        }
    }
    public class FedexTrackxml
    {
        public string FedexTrack = @"
<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/""
		xmlns:v10=""http://fedex.com/ws/track/v10"">
	<soapenv:Header/>
	<soapenv:Body>
		<v10:TrackRequest>
			<v10:WebAuthenticationDetail>
				<v10:ParentCredential>
					<v10:Key>%FedExServiceKey</v10:Key>
					<v10:Password>%FedExServicePassword</v10:Password>
				</v10:ParentCredential>
				<v10:UserCredential>
					<v10:Key>%FedExServiceKey</v10:Key>
					<v10:Password>%FedExServicePassword</v10:Password>
				</v10:UserCredential>
			</v10:WebAuthenticationDetail>
			<v10:ClientDetail>
				<v10:AccountNumber>%FedExServiceAccountNumber</v10:AccountNumber>
				<v10:MeterNumber>%FedExServiceMeterNumber</v10:MeterNumber>
				<v10:IntegratorId/>
				<v10:Localization>
					<v10:LanguageCode>EN</v10:LanguageCode>
					<v10:LocaleCode>US</v10:LocaleCode>
				</v10:Localization>
			</v10:ClientDetail>
			<v10:TransactionDetail>
				<v10:CustomerTransactionId>Ground Track By Number_v10</v10:CustomerTransactionId>
				<v10:Localization>
					<v10:LanguageCode>EN</v10:LanguageCode>
					<v10:LocaleCode>US</v10:LocaleCode>
				</v10:Localization>
			</v10:TransactionDetail>
			<v10:Version>
				<v10:ServiceId>trck</v10:ServiceId>
				<v10:Major>10</v10:Major>
				<v10:Intermediate>0</v10:Intermediate>
				<v10:Minor>0</v10:Minor>
			</v10:Version>
			<v10:SelectionDetails>
				<v10:CarrierCode>%1</v10:CarrierCode>
				<v10:PackageIdentifier>
					<v10:Type>TRACKING_NUMBER_OR_DOORTAG</v10:Type>
					<v10:Value>%2</v10:Value>
				</v10:PackageIdentifier>
			</v10:SelectionDetails>
			<v10:ProcessingOptions>INCLUDE_DETAILED_SCANS</v10:ProcessingOptions>
		</v10:TrackRequest>
	</soapenv:Body>
</soapenv:Envelope>";
    }
    #endregion
    public class FedExManager : IFedExManager
    {
        public string GetFedexTracking(string TrackingNumber, TrackingContext context, TrackingCreds creds, bool IsGround = false)
        {
            string result = string.Empty;

            try
            {                
                string postData = new FedexTrackxml().FedexTrack;
                postData = postData.Replace("%FedExServiceKey", creds.Key);
                postData = postData.Replace("%FedExServicePassword", creds.Password);
                postData = postData.Replace("%FedExServiceAccountNumber", creds.Account);
                postData = postData.Replace("%FedExServiceMeterNumber", creds.Meter);
                string output;
                if (IsGround)
                    postData = postData.Replace("%1", "FDXG");
                else
                    postData = postData.Replace("%1", "FDXE");
                postData = postData.Replace("%2", TrackingNumber.Trim());

                if (ApiTools.WebCall(creds.Url, postData, out output) && output != null)
                {
                    output = output.Replace("SOAP-ENV:Envelope", "Envelope");
                    output = output.Replace("@xmlns:SOAP-ENV", "ENV");
                    output = output.Replace("SOAP-ENV:Header", "Header");
                    output = output.Replace("SOAP-ENV:Body", "Body");
                    output = output.Replace("@xmlns", "xmlns");
                    // var json = JToken.Parse(output);

                    if (output.IndexOf("\"Events\":{") > 0)
                    {
                        output = output.Replace("\"Events\":{", "\"Events\":[{");
                        output = output.Replace("\"}}}}}}}", "\"}]}}}}}}");
                    }

                    if (output.IndexOf("\"TrackDetails\":[{") > 0)
                        output = FedexOlderNoEvents(output);

                    var carrieroutput = JsonConvert.DeserializeObject<FedExResponseXml.RootObject>(output);
                    result = output;
                    //Allow basic messages to be populated - turn on at later date
                    // if (carrieroutput.Envelope.Body.TrackReply.CompletedTrackDetails.TrackDetails.PackageCount == "0")
                    //     result = null;
                }
            }
            catch (Exception ex)
            {
                //UdpLog.SendUdpLog(string.Empty, "Error in ShipmentRepository.GetFedexTracking", (int)ApplicationError.Severity.Serious, null, ex);
            }
            return result;
        }
        private string FedexOlderNoEvents(string output)
        {
            bool IsRemoved = false;
            string result = null;
            try
            {
                int[] tmpLocation = new int[40];
                tmpLocation[0] = output.IndexOf("{\"Notification\":{");
                for (int i = 1; tmpLocation[i - 1] > 0; i++)
                {
                    string tmpString = output.Substring(tmpLocation[i - 1]);
                    tmpLocation[i] = output.IndexOf("{\"Notification\":{", tmpLocation[i - 1] + 5) > 0 ? output.IndexOf("{\"Notification\":{", tmpLocation[i - 1] + 5) : -1;
                }

                for (int i = 0; tmpLocation[i] > 0; i++)
                {
                    string tmpString;
                    if (tmpLocation[i + 1] < 1)
                        tmpString = output.Substring(tmpLocation[i], output.IndexOf("\"TotalUniqueAddressCountInConsolidation\":\"0\"}]") - (tmpLocation[i] - 46));
                    else
                    {
                        tmpString = output.Substring(tmpLocation[i], tmpLocation[i + 1] - tmpLocation[i]);
                        tmpString = tmpString.TrimEnd(',');
                    }

                    if ((tmpString.IndexOf("\"DestinationAddress\":{\"City\":") < 0 && tmpLocation[i + 1] > 0))
                    {
                        output = output.Remove(tmpLocation[i], tmpLocation[i + 1] - tmpLocation[i]);
                        for (int x = i + 1; tmpLocation[x] > 0; x++) tmpLocation[x] = tmpLocation[x] - tmpString.Length;
                        IsRemoved = true;
                        continue;
                    }


                    if (tmpString.IndexOf("\"DestinationAddress\":{\"City\":") < 0 && tmpLocation[i + 1] < 0)
                    {
                        output = output.Remove(tmpLocation[i], tmpString.Length);
                        IsRemoved = true;
                        continue;
                    }

                    if (!IsRemoved && tmpLocation[i + 1] == -1)
                    {
                        output = output.Remove(tmpLocation[i], tmpString.Length);
                        continue;
                    }
                }

                output = output.Replace("\"TrackDetails\":[{", "\"TrackDetails\":{");


                if (output.IndexOf("\"TotalUniqueAddressCountInConsolidation\":\"0\"},") > 0) output = output.Replace("\"TotalUniqueAddressCountInConsolidation\":\"0\"},", "\"TotalUniqueAddressCountInConsolidation\":\"0\"}");

                result = output;
            }
            catch { }
            return result;
        }

        public List<StagingServiceDatum> RawToStaging(string rawJson, AwbtoProcess awb, int rawId)
        {
            var data = JsonConvert.DeserializeObject<FedExResponseXml.RootObject>(rawJson);
            List<StagingServiceDatum> response = null;

            try
            {
                response = (from t in data.Envelope.Body.TrackReply.CompletedTrackDetails.TrackDetails.Events
                            select new StagingServiceDatum { AwbtoProcessId = awb.Id, Code = t.EventType, Description = t.EventDescription, EventDate = DateTime.Parse(t.Timestamp), ImportDate = DateTime.Now, RawServiceDataId = rawId, Location = string.Format("{0}, {1} {2}", t.Address.City, t.Address.StateOrProvinceCode, t.Address.CountryName) }).ToList();
            }
            catch (Exception ex)
            {

            }
            return response;
        }
    }
}
