using Newtonsoft.Json;
using SMSAServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracking.Models.Tracking;
using Tracking.Models.TrackingServices.Abstract;

namespace Tracking.Models.TrackingServices
{
    public class SMSAManager : ISMSAManager, IDisposable
    {
        public void Dispose()
        {

        }

        public string GetSMSATrackingDetails(string LastMileAWBNumber, TrackingContext context, TrackingCreds creds)
        {
            string response = null;

            try
            {
                DateTime requestTime = DateTime.Now;

                var remoteAddr = new System.ServiceModel.EndpointAddress(creds.Url);
                iTrackClient _client = new iTrackClient(iTrackClient.EndpointConfiguration.BasicHttpBinding_iTrack);
                _client.Endpoint.Address = remoteAddr;

                // call the service
                var retVal = _client.getSMSATrackingDetails("EN", LastMileAWBNumber, creds.UserName, creds.Password);
                response = JsonConvert.SerializeObject(retVal);
            }
            catch (Exception ex)
            {
               // UdpLog.SendUdpLog(string.Empty, "ExternalTrackServiceRepository.GetSMSATrackingDetails: API Failure, AWB # " + LastMileAWBNumber, (int)ApplicationError.Severity.Serious, null, ex);
            }

            return response;
        }

        public List<StagingServiceDatum> RawToStaging(string rawJson, AwbtoProcess awb, int rawId)
        {
            var data = JsonConvert.DeserializeObject<TrackRslt[]>(rawJson);
            List<StagingServiceDatum> response = null;

            try
            {
                response = (from t in data
                            select new StagingServiceDatum { AwbtoProcessId = awb.Id, Code = t.StatusCode, Description = t.EventDesc, EventDate = t.EventTime, ImportDate = DateTime.Now, RawServiceDataId = rawId, Location = string.Format("{0} {1}", t.Office, t.CountryCode) }).ToList();
            }
            catch (Exception ex)
            {

            }
            return response;
        }
    }
}
