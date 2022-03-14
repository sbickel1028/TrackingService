using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracking.Models.Tracking;
using Tracking.Models.TrackingServices.Abstract;

namespace Tracking.Models.TrackingServices
{
    #region Freightmark Classes
    public class FreightworkRequest
    {
        public List<string> AwbNumber { get; set; }
        public FreightworkRequest()
        {
            AwbNumber = new List<string>();
        }
    }
    public class FreightworkResponse
    {
        public string success { get; set; }
        public string message { get; set; }
        public List<FreighworkTrack> TrackResponse { get; set; }
    }
    public class FreighworkTrack
    {
        public FreightWorkShipment Shipment { get; set; }



    }
    public class FreightWorkShipment
    {
        public string awb_number { get; set; }
        public string current_status { get; set; }
        public string status_datetime { get; set; }
        public FreightworkAddress ShipmentAddress { get; set; }
        public List<FreightworkActivity> Activity { get; set; }
    }
    public class FreightworkAddress
    {
        public string address { get; set; }
        public string city { get; set; }
        public string country { get; set; }
    }
    public class FreightworkActivity
    {
        public string datetime { get; set; }
        public string status { get; set; }
        public string details { get; set; }
        public string location { get; set; }
    }
    #endregion
    #region Shipment Request and Response classes
    public class FreightworkShipRequest
    {
        public string ToCompany { get; set; }
        public string ToAddress { get; set; }
        public string ToLocation { get; set; }
        public string ToCountry { get; set; }
        public string ToCity { get; set; }
        public string ToCperson { get; set; }
        public string ToContactno { get; set; }
        public string ToMobileno { get; set; }
        public string ReferenceNumber { get; set; }
        public string CompanyCode { get; set; }
        public string Weight { get; set; }
        public int Pieces { get; set; }
        public string PackageType { get; set; }
        public string CurrencyCode { get; set; }
        public decimal NcndAmount { get; set; }
        public string ItemDescription { get; set; }
        public string SpecialInstruction { get; set; }
        public string BranchName { get; set; }
    }

    public class FreightWorkShipResponse
    {
        public string success { get; set; }
        public string message { get; set; }
        public string AwbNumber { get; set; }
        public string AwbPdf { get; set; }
        public string LabelPdf { get; set; }
    }
    #endregion
    public class FreightWorkManager : IFreightWorksManager
    {
        public string GetFreightworkTrackingDetails(string lastAwbNumber, TrackingContext context, TrackingCreds creds)
        {
            FreightworkRequest request = new FreightworkRequest();
            request.AwbNumber.Add(lastAwbNumber);
            string url = creds.Url;
            var credentials = creds.Token;
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("API-KEY", credentials);
            return ApiTools.PostWebApi(request, new Uri(url), headers).ToString();
        }
        public List<StagingServiceDatum> RawToStaging(string rawJson, AwbtoProcess awb, int rawId)
        {
            var data = JsonConvert.DeserializeObject<FreightworkResponse>(rawJson);
            List<StagingServiceDatum> response = null;

            try
            {
                response = (from t in data.TrackResponse[0].Shipment.Activity
                            select new StagingServiceDatum { AwbtoProcessId = awb.Id, Code = t.status, Description = t.status, EventDate = DateTime.Parse(t.datetime), ImportDate = DateTime.Now, RawServiceDataId = rawId, Location = t.location }).ToList();
            }
            catch (Exception ex)
            {

            }
            return response;
        }
    }
}
