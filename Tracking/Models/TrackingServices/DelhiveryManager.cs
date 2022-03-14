using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracking.Models.Tracking;
using Tracking.Models.TrackingServices.Abstract;

namespace Tracking.Models.TrackingServices
{
    #region Request/Response
    public class Status1
    {
        public string Status { get; set; }
        public string StatusLocation { get; set; }
        public DateTime StatusDateTime { get; set; }
        public string RecievedBy { get; set; }
        public string Instructions { get; set; }
        public string StatusType { get; set; }
        public string StatusCode { get; set; }
    }

    public class Consignee
    {
        public string City { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public List<object> Address2 { get; set; }
        public string Address3 { get; set; }
        public int PinCode { get; set; }
        public string State { get; set; }
        public string Telephone2 { get; set; }
        public List<string> Telephone1 { get; set; }
        public List<string> Address1 { get; set; }
    }

    public class ScanDetail
    {
        public DateTime ScanDateTime { get; set; }
        public string ScanType { get; set; }
        public string Scan { get; set; }
        public DateTime StatusDateTime { get; set; }
        public string ScannedLocation { get; set; }
        public string Instructions { get; set; }
        public string StatusCode { get; set; }
    }

    public class Scan
    {
        public ScanDetail ScanDetail { get; set; }
    }

    public class Shipments
    {
        public string Origin { get; set; }
        public Status1 Status { get; set; }
        public DateTime PickUpDate { get; set; }
        public object ChargedWeight { get; set; }
        public string OrderType { get; set; }
        public string Destination { get; set; }
        public Consignee Consignee { get; set; }
        public string ReferenceNo { get; set; }
        public object ReturnedDate { get; set; }
        public object DestRecieveDate { get; set; }
        public object OriginRecieveDate { get; set; }
        public object OutDestinationDate { get; set; }
        public int CODAmount { get; set; }
        public object FirstAttemptDate { get; set; }
        public bool ReverseInTransit { get; set; }
        public List<Scan> Scans { get; set; }
        public string SenderName { get; set; }
        public string AWB { get; set; }
        public int DispatchCount { get; set; }
        public int InvoiceAmount { get; set; }
    }

    public class ShipmentData
    {
        public Shipments Shipment { get; set; }
    }

    public class ExternalTrackingRootResponse
    {
        public List<ShipmentData> ShipmentData { get; set; }
    }

    #endregion
    public class DelhiveryManager : IDelhiveryManager, IDisposable
    {
        public void Dispose()
        {
            
        }

        public string GetDELTrackingDetails(string LastMileAWBNumber, TrackingContext context, TrackingCreds creds)
        {
            string result = null;
            object request = string.Empty;
            var trkURL = string.Format(creds.Url, creds.Token, LastMileAWBNumber);

            try
            {
                Dictionary<string, string> headers = new Dictionary<string, string>();

                result = ApiTools.GetWebApi((object)request, new Uri(trkURL), headers).ToString();
                return result;
            }
            catch (Exception ex)
            {
                //UdpLog.SendUdpLog("Error in DelhiveryManager.GetDELTrackingDetails", "Delhivery Get Label Status API Failure, Shipment Invoice Number", (int)ApplicationError.Severity.Critical, null, ex);
            }

            return result;
        }
        public List<StagingServiceDatum> RawToStaging(string rawJson, AwbtoProcess awb, int rawId)
        {
            var data = JsonConvert.DeserializeObject<ExternalTrackingRootResponse>(rawJson);
            List<StagingServiceDatum> response = null;

            try
            {
                response = (from t in data.ShipmentData.FirstOrDefault().Shipment.Scans
                            select new StagingServiceDatum { AwbtoProcessId = awb.Id, Code = t.ScanDetail.Scan, Description = t.ScanDetail.Instructions, EventDate = t.ScanDetail.ScanDateTime, ImportDate = DateTime.Now, RawServiceDataId = rawId, Location = t.ScanDetail.ScannedLocation }).ToList();
            }
            catch (Exception ex)
            {

            }
            return response;
        }
    }
}
