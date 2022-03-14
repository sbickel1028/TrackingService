using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using Tracking.Models.Tracking;
using Tracking.Models.TrackingServices.Abstract;

namespace Tracking.Models.TrackingServices
{
    #region Request class

    #region Client Info
    [XmlRoot(ElementName = "ClientAddress", Namespace = "http://tempuri.org/")]
    [Serializable]
    public class ClientAddress
    {
        [XmlElement(ElementName = "PhoneNumber", Namespace = "http://tempuri.org/")]
        public string PhoneNumber { get; set; }
        [XmlElement(ElementName = "POBox", Namespace = "http://tempuri.org/")]
        public string POBox { get; set; }
        [XmlElement(ElementName = "ZipCode", Namespace = "http://tempuri.org/")]
        public string ZipCode { get; set; }
        [XmlElement(ElementName = "Fax", Namespace = "http://tempuri.org/")]
        public string Fax { get; set; }
        [XmlElement(ElementName = "FirstAddress", Namespace = "http://tempuri.org/")]
        public string FirstAddress { get; set; }
        [XmlElement(ElementName = "Location", Namespace = "http://tempuri.org/")]
        public string Location { get; set; }
        [XmlElement(ElementName = "CountryCode", Namespace = "http://tempuri.org/")]
        public string CountryCode { get; set; }
        [XmlElement(ElementName = "CityCode", Namespace = "http://tempuri.org/")]
        public string CityCode { get; set; }
    }

    [XmlRoot(ElementName = "ClientContact", Namespace = "http://tempuri.org/")]
    [Serializable]
    public class ClientContact
    {
        [XmlElement(ElementName = "Name", Namespace = "http://tempuri.org/")]
        public string Name { get; set; }
        [XmlElement(ElementName = "Email", Namespace = "http://tempuri.org/")]
        public string Email { get; set; }
        [XmlElement(ElementName = "PhoneNumber", Namespace = "http://tempuri.org/")]
        public string PhoneNumber { get; set; }
        [XmlElement(ElementName = "MobileNo", Namespace = "http://tempuri.org/")]
        public string MobileNo { get; set; }
    }

    [XmlRoot(ElementName = "ClientInfo", Namespace = "http://tempuri.org/")]
    [Serializable]
    public class ClientInfo
    {
        [XmlElement(ElementName = "ClientAddress", Namespace = "http://tempuri.org/")]
        public ClientAddress ClientAddress { get; set; }
        [XmlElement(ElementName = "ClientContact", Namespace = "http://tempuri.org/")]
        public ClientContact ClientContact { get; set; }
        [XmlElement(ElementName = "ClientID", Namespace = "http://tempuri.org/")]
        public string ClientID { get; set; }
        [XmlElement(ElementName = "Password", Namespace = "http://tempuri.org/")]
        public string Password { get; set; }
        [XmlElement(ElementName = "Version", Namespace = "http://tempuri.org/")]
        public string Version { get; set; }
    }
    #endregion
    [XmlType(Namespace = NaqelTrackRequest.t, IncludeInSchema = true)]
    public class NaqelTrackRequest
    {
        private const string v = "http://schemas.xmlsoap.org/soap/envelope/";
        private const string t = "http://tempuri.org/";


        [XmlRoot(Namespace = v)]
        public class Envelope
        {
            static Envelope()
            {
                staticxmlns = new XmlSerializerNamespaces();
                staticxmlns.Add("ns1", t);
                staticxmlns.Add("soapenv", v);
            }

            private static XmlSerializerNamespaces staticxmlns;
            [XmlNamespaceDeclarations]
            public XmlSerializerNamespaces xmlns { get { return staticxmlns; } set { } }

            [XmlElement(ElementName = "Header")]
            public string Header { get; set; }
            [XmlElement(ElementName = "Body", Namespace = v)]
            public TrackRequestBody Body { get; set; }
            [XmlAttribute(AttributeName = "soapenv")]
            public string Soapenv { get; set; }
            [XmlAttribute(AttributeName = "ns1")]
            public string Ns1 { get; set; }


        }
        [XmlRoot(ElementName = "GetWaybillSticker", Namespace = t)]
        public class TraceByWaybillNo
        {
            [XmlElement(ElementName = "WaybillNo", Namespace = t)]
            public string WaybillNo { get; set; }
            [XmlElement(ElementName = "ClientInfo", Namespace = t)]
            public ClientInfo ClientInfo { get; set; }
        }
        [XmlRoot(ElementName = "Body", Namespace = v)]
        public class TrackRequestBody
        {

            [XmlElement(ElementName = "TraceByWaybillNo", Namespace = t)]
            public TraceByWaybillNo TraceByWaybillNo { get; set; }
        }

    }
    #endregion
    public class NaqelManager : INaqelManager
    {
        public string GetNaqelTrackingDetails(string lastMileAWBNumber, TrackingContext context, TrackingCreds creds)
        {
            string response = null;
            try
            {
                var clientId = creds.UserName;
                var passWord = creds.Password;
                var url = creds.Url;                
                NaqelTrackRequest.Envelope request = new NaqelTrackRequest.Envelope();
                request.Body = new NaqelTrackRequest.TrackRequestBody();
                request.Body.TraceByWaybillNo = new NaqelTrackRequest.TraceByWaybillNo();
                ClientInfo client = new ClientInfo();
                client.ClientID = clientId;
                client.Password = passWord;
                client.Version = creds.Version;
                request.Body.TraceByWaybillNo.ClientInfo = client;
                request.Body.TraceByWaybillNo.WaybillNo = lastMileAWBNumber;
                Dictionary<string, string> headers = new Dictionary<string, string>();
                headers.Add("Content-Type", "text/xml; charset=utf-8");
                response = ApiTools.PostWebApiSoap(request, new Uri(url), typeof(NaqelTrackRequest.Envelope), headers, null, request.xmlns).ToString();
            }
            catch (Exception ex)
            {

            }
            return response;

        }

        public List<StagingServiceDatum> RawToStaging(string rawJson, AwbtoProcess awb, int rawId)
        {
            var data = rawJson;
            List<StagingServiceDatum> response = null;

            try
            {
                XDocument xd = XDocument.Parse(response.ToString());
                XNamespace ns = "http://tempuri.org/";
                var resp = xd.Descendants(ns + "TraceByWaybillNoResult")?.Elements(ns + "Tracking")?.ToList();
                for (int i = 0; i < resp.Count; i++)
                {
                    StagingServiceDatum s = new StagingServiceDatum();
                    
                    s.EventDate= DateTime.Parse(resp[i].Element(ns + "Date")?.FirstNode?.ToString());
                    s.Description = resp[i].Element(ns + "Activity")?.FirstNode?.ToString();
                    s.Code = resp[i].Element(ns + "EventCode")?.FirstNode?.ToString();
                    s.Location = resp[i].Element(ns + "StationCode")?.FirstNode?.ToString();
                    response.Add(s);
                }
            }
            catch (Exception ex)
            {

            }
            return response;
        }
    }
}
