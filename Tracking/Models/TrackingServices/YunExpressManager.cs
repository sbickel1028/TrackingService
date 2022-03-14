using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracking.Models.Tracking;
using Tracking.Models.TrackingServices.Abstract;

namespace Tracking.Models.TrackingServices
{
    #region Yun Express Tracking Response classes

    public class YunTrackingResponse
    {
        public YunTrackItems Item { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
        public string RequestId { get; set; }
        public string TimeStamp { get; set; }
    }
    public class YunTrackItems
    {
        public string CountryCode { get; set; }
        public string WaybillNumber { get; set; }
        public string TrackingNumber { get; set; }
        public string CreatedBy { get; set; }
        public int PackageState { get; set; }
        public int TrackingStatus { get; set; }
        public decimal IntervalDays { get; set; }
        public List<YunExpressTrackingDetails> OrderTrackingDetails { get; set; }
    }
    public class YunExpressTrackingDetails
    {
        public string ProcessDate { get; set; }
        public string ProcessContent { get; set; }
        public string ProcessLocation { get; set; }
        public int TrackingStatus { get; set; }
    }
    #endregion

    #region Yun Express WayBill and Label classes
    #region WayBill Request and Response classes
    public class YunVoidShipmentResponse
    {
        public string Voided { get; set; }
        public string ErrorMessage { get; set; }
    }
    public class YunWayBillRequest
    {
        public string CustomerOrderNumber { get; set; }
        public string ShippingMethodCode { get; set; }
        public int PackageCount { get; set; }
        public decimal Weight { get; set; }
        public string WeightUnits { get; set; }

        public YunReceiver Receiver { get; set; }
        public YunSender Sender { get; set; }
        public List<YunParcels> Parcels { get; set; }
    }
    public class YunWayBillResponse
    {
        public List<YunWayOrder> Item { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
        public string RequestId { get; set; }
        public string TimeStamp { get; set; }
    }
    public class YunWayOrder
    {
        public string CustomerOrderNumber { get; set; }
        public int Success { get; set; }
        public string TrackType { get; set; }
        public string Remark { get; set; }
        public int RequireSenderAddress { get; set; }
        public string AgentNumber { get; set; }
        public string WayBillNumber { get; set; }
        public string TrackingNumber { get; set; }
        public List<YunShipperBox> ShipperBoxs { get; set; }
    }

    public class YunShipperBox
    {
        public string BoxNumber { get; set; }
        public string ShipperHawbcode { get; set; }
    }
    public class YunReceiver
    {
        public string CountryCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Street { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
    public class YunSender
    {
        public string CountryCode { get; set; }
        public string Company { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
    }
    public class YunParcels
    {
        public string EName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitWeight { get; set; }
        public string Remark { get; set; }
        public string CurrencyCode { get; set; }
    }
    #endregion


    #region Label classes

    public class YunLabelResponse
    {
        public List<YunOrderLabelPrintTypes> Item { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
        public string RequestId { get; set; }
        public string TimeStamp { get; set; }
    }
    public class YunOrderLabelPrintTypes
    {
        public string Url { get; set; }
        public List<YunLabelOrderInfo> OrderInfos { get; set; }
    }
    public class YunLabelOrderInfo
    {
        public string CustomerOrderNumber { get; set; }
        public string Error { get; set; }
        public int Code { get; set; }
    }
    #endregion

    #region Transportation mode classes
    public class YunExpressShippingMethod
    {
        public string Code { get; set; }
        public string EName { get; set; }
        public string HasTrackingNumber { get; set; }
    }
    public class YunTransResponse
    {
        public List<YunExpressShippingMethod> Items { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
        public string RequestId { get; set; }
        public string TimeStamp { get; set; }
    }
    #endregion

    #region Delete classes
    public class YunDeleteRequest
    {
        public int OrderType { get; set; }
        public string OrderNumber { get; set; }
    }

    public class YunDeleteResponse
    {
        public YunOrderDeleteTypes Item { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
        public string RequestId { get; set; }
        public string TimeStamp { get; set; }
    }

    public class YunOrderDeleteTypes
    {
        public string Status { get; set; }
        public int Type { get; set; }
        public string OrderNumber { get; set; }
        public string Remark { get; set; }
    }
    #endregion
    #endregion
    public class YunExpressManager : IYunExpressManager
    {
        public string GetYunExpressTrackingDetails(string lastMileAWBNumber, TrackingContext context, TrackingCreds creds)
        {
            string result = null;
            string trackUrl = creds.Url;
            string url = String.Format(trackUrl, lastMileAWBNumber);
            try
            {
                string clientID = creds.UserName;
                string pw = creds.Password;
                string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(clientID + "&" + pw));
                Dictionary<string, string> headers = new Dictionary<string, string>();
                headers.Add("Authorization", string.Format("Basic {0}", credentials));
                result = ApiTools.GetWebApi(null, new Uri(url), headers).ToString();
            }
            catch (Exception ex)
            {
               // UdpLog.SendUdpLog("Error in YunExpressManager.GetYunExpressTrackingDetails", "Yun Express Tracking Failed for last AWBNumber: " + lastMileAWBNumber, (int)ApplicationError.Severity.Critical, null, ex);
            }

            return result;
        }
        public List<StagingServiceDatum> RawToStaging(string rawJson, AwbtoProcess awb, int rawId)
        {
            var data = JsonConvert.DeserializeObject<YunTrackingResponse>(rawJson);
            List<StagingServiceDatum> response = null;

            try
            {
                response = (from t in data.Item.OrderTrackingDetails
                            select new StagingServiceDatum { AwbtoProcessId = awb.Id, Code = t.TrackingStatus.ToString(), Description = t.ProcessContent, EventDate = DateTime.Parse(t.ProcessDate).ToUniversalTime(), ImportDate = DateTime.Now, RawServiceDataId = rawId, Location = t.ProcessLocation }).ToList();
            }
            catch (Exception ex)
            {

            }
            return response;
        }
    }
}
