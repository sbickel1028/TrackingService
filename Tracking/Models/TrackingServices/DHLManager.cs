using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using Tracking.Models.Tracking;
using Tracking.Models.TrackingServices.Abstract;

namespace Tracking.Models.TrackingServices
{
    public class DHLResponse
    {
        //public class Header
        //{
        //    public string version { get; set; }
        //    public string encoding { get; set; }
        //}

        // public class ServiceHeader
        // {
        //     public string MessageTime { get; set; }
        //     public string MessageReference { get; set; }
        //      public string SiteID { get; set; }
        // }

        //public class Response
        //{
        //     public ServiceHeader ServiceHeader { get; set; }
        //}

        public class Status
        {
            public string ActionStatus { get; set; }
        }

        public class OriginServiceArea
        {
            public string ServiceAreaCode { get; set; }
            public string Description { get; set; }
        }

        public class DestinationServiceArea
        {
            public string ServiceAreaCode { get; set; }
            public string Description { get; set; }
        }

        public class Shipper
        {
            public string City { get; set; }
            public string DivisionCode { get; set; }
            public string PostalCode { get; set; }
            public string CountryCode { get; set; }
        }

        public class Consignee
        {
            public string City { get; set; }
            public string CountryCode { get; set; }
        }

        public class ShipperReference
        {
            public string ReferenceID { get; set; }
        }

        public class ServiceEvent
        {
            public string EventCode { get; set; }
            public string Description { get; set; }
        }

        public class ServiceArea
        {
            public string ServiceAreaCode { get; set; }
            public string Description { get; set; }
        }

        public class ShipmentEvent
        {
            public string Date { get; set; }
            public string Time { get; set; }
            public ServiceEvent ServiceEvent { get; set; }
            public string Signatory { get; set; }
            public ServiceArea ServiceArea { get; set; }
        }

        public class ShipmentInfo
        {
            public OriginServiceArea OriginServiceArea { get; set; }
            public DestinationServiceArea DestinationServiceArea { get; set; }
            public string ShipperName { get; set; }
            public string ShipperAccountNumber { get; set; }
            public string ConsigneeName { get; set; }
            public string ShipmentDate { get; set; }
            public string Pieces { get; set; }
            public string Weight { get; set; }
            public string WeightUnit { get; set; }
            public string EstDlvyDate { get; set; }
            public string EstDlvyDateUTC { get; set; }
            public string GlobalProductCode { get; set; }
            public string ShipmentDesc { get; set; }
            public string DlvyNotificationFlag { get; set; }
            public Shipper Shipper { get; set; }
            public Consignee Consignee { get; set; }
            public ShipperReference ShipperReference { get; set; }
            public List<ShipmentEvent> ShipmentEvent { get; set; }
        }

        public class AWBInfo
        {
            public string AWBNumber { get; set; }
            public Status Status { get; set; }
            public ShipmentInfo ShipmentInfo { get; set; }
        }

        public class TrackingResponse
        {
            public string xmlns { get; set; }
            public string xmlns2 { get; set; }
            public string schemaLocation { get; set; }
            //public Response Response { get; set; }
            public AWBInfo AWBInfo { get; set; }
            public string LanguageCode { get; set; }
        }

        public class RootObject
        {
            public TrackingResponse TrackingResponse { get; set; }
        }
    }
    #region Global_Defination 
    public class DHLTrackxml
    {
        public string DhlTrack = @"<?xml version=""1.0"" encoding=""UTF-8""?><req:KnownTrackingRequest xsi:schemaLocation=""http://www.dhl.com TrackingRequestKnown.xsd"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:req=""http://www.dhl.com""><Request><ServiceHeader><MessageTime>%MessageTime</MessageTime><MessageReference>%MessageReference</MessageReference><SiteID>%SiteId</SiteID><Password>%Password</Password></ServiceHeader></Request><LanguageCode>String</LanguageCode><AWBNumber>%AWBNumber</AWBNumber><LevelOfDetails>ALL_CHECK_POINTS</LevelOfDetails></req:KnownTrackingRequest>";
    }
    #endregion
    public class DHLManager : IDHLManager
    {

        private string SplitMutipleDataReturn(string output)
        {
            string result = null;
            try
            {
                do
                {
                    output = output.Replace("{\"Header\"", "||||||||||{\"Header\"");
                } while (output.IndexOf("{\"Header\"") > 0);

                if (output.IndexOf("{\"Header\"") > 0)
                {

                }
            }
            catch { }

            return result;
        }
        private string DhlMergedata(string output, int[] tmpLocation)
        {
            string result = null;
            try
            {
                // Possible merege of data

                int MainEventTransaction = -1;
                int LargestEvents = -1;
                bool IsMergeable = false;
                List<DHLResponse.AWBInfo> _filterData = new List<DHLResponse.AWBInfo>();

                for (int i = 0; tmpLocation[i] > 0; i++)
                {
                    string tmpString;
                    if (tmpLocation[i + 1] < 1)
                    {
                        tmpString = output.Substring(tmpLocation[i], output.IndexOf("],\"LanguageCode\"") - tmpLocation[i]);
                        tmpString = tmpString.Trim(',');
                    }
                    else
                    {
                        tmpString = output.Substring(tmpLocation[i], tmpLocation[i + 1] - tmpLocation[i]);
                        tmpString = tmpString.Trim(',');
                    }

                    try
                    {
                        var PossibleDataExtract = JsonConvert.DeserializeObject<DHLResponse.AWBInfo>(tmpString);
                        if (PossibleDataExtract.ShipmentInfo.ShipmentEvent.Count() > 0)
                        {
                            if (PossibleDataExtract.ShipmentInfo.ShipmentEvent.Count() < 3)
                            {
                                int cntSenderMsg = PossibleDataExtract.ShipmentInfo.ShipmentEvent.Where(sa => sa.ServiceEvent.EventCode == "SD" && sa.ServiceEvent.Description == "Shipment information received").Count();
                                if (cntSenderMsg > 0) continue;
                            }

                            _filterData.Add(PossibleDataExtract);
                            if (PossibleDataExtract.ShipmentInfo.ShipmentEvent.Count() > LargestEvents)
                            {
                                LargestEvents = PossibleDataExtract.ShipmentInfo.ShipmentEvent.Count();
                                MainEventTransaction = _filterData.Count(); IsMergeable = true;
                            }
                        }
                    }
                    catch
                    {
                        IsMergeable = false;
                    }
                }

                if (IsMergeable)
                {
                    for (int i = 0; i < _filterData.Count(); i++)
                    {
                        if (i == MainEventTransaction - 1) continue;

                        _filterData[i].ShipmentInfo.ShipmentEvent.ForEach(sa =>
                        {
                            var _row = new DHLResponse.ShipmentEvent();

                            _row.Date = sa.Date;
                            _row.Time = sa.Time;
                            if (sa.ServiceEvent != null)
                            {
                                _row.ServiceEvent = new DHLResponse.ServiceEvent();
                                _row.ServiceEvent.EventCode = sa.ServiceEvent.EventCode;
                                _row.ServiceEvent.Description = sa.ServiceEvent.Description;
                            }
                            _row.Signatory = sa.Signatory;
                            if (sa.ServiceArea != null)
                            {
                                _row.ServiceArea = new DHLResponse.ServiceArea();
                                _row.ServiceArea.ServiceAreaCode = sa.ServiceArea.ServiceAreaCode;
                                _row.ServiceArea.Description = sa.ServiceArea.Description;
                            }

                            _filterData[MainEventTransaction - 1].ShipmentInfo.ShipmentEvent.Add(_row);
                        });

                        _filterData[MainEventTransaction - 1].ShipmentInfo.ShipmentEvent = _filterData[MainEventTransaction - 1].ShipmentInfo.ShipmentEvent.OrderBy(sa => sa.Date).ThenBy(sa => sa.Time).ToList();
                    }


                    if (IsMergeable)
                    {
                        int lastrecord = tmpLocation.Where(sa => sa > 0).Count();
                        output = output.Remove(tmpLocation[0], output.IndexOf("],\"LanguageCode\"") - tmpLocation[0]);
                        string insertData = JsonConvert.SerializeObject(_filterData[MainEventTransaction - 1]);
                        output = output.Insert(tmpLocation[0], insertData);

                        output = output.Replace("],\"LanguageCode\"", ",\"LanguageCode\"");
                        if (output.IndexOf(",{\"AWBNumber\":") > 0) output = output.Replace(",{\"AWBNumber\":", "{\"AWBNumber\":");
                        output = output.Replace("\"AWBInfo\":[{\"AWBNumber\":", "\"AWBInfo\":{\"AWBNumber\":");

                        result = output;
                    }
                }

            }
            catch (Exception ex)
            {
               // UdpLog.SendUdpLog(string.Empty, "Error in ShipmentRepository.DhlMergedata", (int)ApplicationError.Severity.Serious, null, ex);
            }

            return result;
        }
        private string AWBNumberCheck(string output)
        {
            string result = null;
            try
            {
                int[] tmpLocation = new int[40];
                tmpLocation[0] = output.IndexOf("{\"AWBNumber\":");
                DHLResponse.AWBInfo _testData = new DHLResponse.AWBInfo();

                for (int i = 1; tmpLocation[i - 1] > 0; i++)
                {
                    string tmpString = output.Substring(tmpLocation[i - 1]);
                    tmpLocation[i] = output.IndexOf(",{\"AWBNumber\":", tmpLocation[i - 1] + 5) > 0 ? output.IndexOf(",{\"AWBNumber\":", tmpLocation[i - 1] + 5) : -1;
                }

                // Determine If we can Merge data
                result = DhlMergedata(output, tmpLocation);
                if (result != null)
                {

                    return result;
                }

                for (int i = 0; tmpLocation[i] > 0; i++)
                {
                    string tmpString;
                    if (tmpLocation[i + 1] < 1)
                        tmpString = output.Substring(tmpLocation[i], output.IndexOf("],\"LanguageCode\"") - tmpLocation[i]);
                    else
                        tmpString = output.Substring(tmpLocation[i], tmpLocation[i + 1] - tmpLocation[i]);



                    if ((tmpString.IndexOf("\"ShipperName\":\"ACCESS USA\"") < 0 && tmpLocation[i + 1] > 0) ||
                         (tmpString.IndexOf("\"ShipperName\":null,\"ConsigneeName\":null,") > 0 && tmpLocation[i + 1] > 0) ||
                         (tmpString.IndexOf("\"EventCode\":\"PU\",\"Description\":\"Shipment picked up\"") < 0 && tmpLocation[i + 1] > 0)
                       )
                    {
                        output = output.Remove(tmpLocation[i], tmpLocation[i + 1] - tmpLocation[i]);
                        for (int x = i + 1; tmpLocation[x] > 0; x++) tmpLocation[x] = tmpLocation[x] - tmpString.Length;
                        continue;
                    }


                    if ((tmpString.IndexOf("\"ShipperName\":\"ACCESS USA\"") < 0 && tmpLocation[i + 1] < 0) ||
                        (tmpString.IndexOf("\"ShipperName\":null,\"ConsigneeName\":null,") > 0 && tmpLocation[i + 1] < 0) ||
                        (tmpString.IndexOf("\"EventCode\":\"PU\",\"Description\":\"Shipment picked up\"") < 0 && tmpLocation[i + 1] < 0)
                        )
                    {
                        output = output.Remove(tmpLocation[i], tmpString.Length);
                        continue;
                    }

                }

                output = output.Replace("],\"LanguageCode\"", ",\"LanguageCode\"");
                if (output.IndexOf(",{\"AWBNumber\":") > 0) output = output.Replace(",{\"AWBNumber\":", "{\"AWBNumber\":");
                output = output.Replace("\"AWBInfo\":[{\"AWBNumber\":", "\"AWBInfo\":{\"AWBNumber\":");

                result = output;
            }
            catch { }
            return result;
        }
        public string GetDHLTracking(string TrackingNumber, TrackingCreds creds, TrackingContext context)
        {
            string result = string.Empty;

            try
            {
                string postData = new DHLTrackxml().DhlTrack;                
                postData = postData.Replace("%MessageTime", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz"));
                postData = postData.Replace("%MessageReference", DateTime.Now.ToString("yyyyMMddhhmmss") + "111111" + TrackingNumber);
                postData = postData.Replace("%SiteId", creds.UserName);
                postData = postData.Replace("%Password", creds.Password);
                postData = postData.Replace("%AWBNumber", TrackingNumber);

                string output;
                if (ApiTools.WebCall(creds.Url, postData, out output) && output != null)
                {
                    output = output.Replace("@version", "version");
                    output = output.Replace("?xml", "Header");
                    output = output.Replace("@encoding", "encoding");

                    output = output.Replace("req:TrackingResponse", "TrackingResponse");
                    output = output.Replace("@xmlns:req", "xmlns");
                    output = output.Replace("@xmlns:xsi", "xmlns2");
                    output = output.Replace("@xsi:schemaLocation", "schemaLocation");

                    if (Regex.Matches(Regex.Escape(output), "\"Header\"").Count > 1)     //Mutiple response return              
                        output = SplitMutipleDataReturn(output);


                    //More than one AWBInfo, delete the bad one  
                    if (output.IndexOf("\"AWBInfo\":[{\"AWBNumber\":") > 0)
                        output = AWBNumberCheck(output);

                    if (output.IndexOf("\"ShipmentEvent\":{") > 0)
                    {
                        output = output.Replace("\"ShipmentEvent\":{", "\"ShipmentEvent\":[{");
                        output = output.Replace("}}}},\"LanguageCode", "}},]}},\"LanguageCode");
                    }

                    return output;
                }

            }
            catch (Exception ex)
            {
                //UdpLog.SendUdpLog(string.Empty, "Error in ShipmentRepository.GetDHLTracking", (int)ApplicationError.Severity.Serious, null, ex);
            }
            return result;
        }
        public List<StagingServiceDatum> RawToStaging(string rawJson, AwbtoProcess awb, int rawId)
        {
            var data = JsonConvert.DeserializeObject<DHLResponse.RootObject>(rawJson);
            List<StagingServiceDatum> response = null;

            try
            {
                response = (from t in data.TrackingResponse.AWBInfo.ShipmentInfo.ShipmentEvent
                            select new StagingServiceDatum { AwbtoProcessId = awb.Id, Code = t.ServiceEvent.EventCode, Description = t.ServiceEvent.Description, EventDate = DateTime.ParseExact(t.Date + " " + t.Time, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture), ImportDate = DateTime.Now, RawServiceDataId = rawId, Location = t.ServiceArea.Description }).ToList();
            }
            catch (Exception ex)
            {

            }
            return response;
        }
    }
}
