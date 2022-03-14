using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using Tracking.Models.Tracking;
using Tracking.Models.TrackingServices.Abstract;
using USPSConsolidationService;

namespace Tracking.Models.TrackingServices
{
    public class USPSManager : IUSPSManager, IDisposable
    {
        private ConsolidatorWebServiceSoapClient _GSSClient = null;
        private TrackingCreds _creds;
        private static DateTime _USPSFirstClassAccessTokenExpiration = DateTime.Now.AddMinutes(-30);
        private static string _USPSFirstClassAccessToken = string.Empty;
        private const string USPSGSS_USER_ID = "USPSGSS_UserID";
        private const string USPSGSS_PASSWORD = "USPSGSS_Password";
        private const string USPSGSS_LOCATION_ID = "USPSGSS_LocationID";
        private const string USPSGSS_ENDPOINT = "USPSGSS_Endpoint";
        private const string USPSGSS_MAILING_AGENT_ID = "MYUSSARFLUSM";
        private const string USPSGSS_RECEIVING_AGENT_ID = "USPSERVICUSD";
        private ConsolidatorWebServiceSoapClient GSSClient
        {
            get
            {
                if (_GSSClient == null)
                {
                    _GSSClient = new ConsolidatorWebServiceSoapClient(ConsolidatorWebServiceSoapClient.EndpointConfiguration.ConsolidatorWebServiceSoap);
                    _GSSClient.Endpoint.Address = new EndpointAddress(new Uri("url"));
                }

                return _GSSClient;
            }
        }

        public void Dispose()
        {
            
        }

        private string USPSFirstClassAccessToken
        {
            get
            {
                string result = string.Empty;
                TimeSpan span = DateTime.Now - _USPSFirstClassAccessTokenExpiration;

                if (string.IsNullOrEmpty(_USPSFirstClassAccessToken) || span.TotalMinutes >= 0)
                {
                    AuthenticateResult auth = GSSClient.AuthenticateUser(_creds.UserName, _creds.Password, _creds.LocationId, "SYSTEM");
                    if (auth != null && auth.ResponseCode == 0)
                    {
                        _USPSFirstClassAccessToken = auth.AccessToken;
                        _USPSFirstClassAccessTokenExpiration = DateTime.Now.AddMinutes(15);         // The access token expires after 20 minutes so we are setting this to be safe.
                    }
                    else
                    {
                        _USPSFirstClassAccessTokenExpiration = DateTime.Today.AddMinutes(-30);
                    }
                }

                return _USPSFirstClassAccessToken;
            }
        }
        public string GetUSPSFirstClassTrackingDetails(string LastMileAWBNumber, TrackingContext context, TrackingCreds creds)
        {
            string response = null;
            _creds = creds;
            try
            {
                // Get tracking information for shipment.  Detail end to end tracking is only available for a small list of countries.
                TrackResult trkResult = GSSClient.TrackPackage(LastMileAWBNumber, USPSGSS_MAILING_AGENT_ID, 1, USPSFirstClassAccessToken);
                response = trkResult.ToString();
            }
            catch (Exception ex)
            {
                // UdpLog.SendUdpLog(string.Empty, "ExternalTrackServiceRepository.GetUSPSFirstClassTrackingDetails: API Failure, AWB # " + LastMileAWBNumber + " | Response: " + (string)retVal, (int)ApplicationError.Severity.Serious, null, ex);
            }
            return response;
        }

        public List<StagingServiceDatum> RawToStaging(string rawJson, AwbtoProcess awb, int rawId)
        {
            var data = JsonConvert.DeserializeObject<TrackResult>(rawJson);
            List<StagingServiceDatum> response = null;

            try
            {
                response = (from t in data.TrackingEvent
                            select new StagingServiceDatum { AwbtoProcessId = awb.Id, Code = t.TrackingCode, Description = t.Description, EventDate = DateTime.Parse(t.EventDate), ImportDate = DateTime.Now, RawServiceDataId = rawId, Location = t.Location }).ToList();
            }
            catch (Exception ex)
            {

            }
            return response;
        }
    }
}
