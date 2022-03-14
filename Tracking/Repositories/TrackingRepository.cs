using Tracking.Models;
using Tracking.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Tracking.Models.Tracking;
using Tracking.Models.TrackingDTO;
using Tracking.Models.TrackingServices;
using Tracking.Models.TrackingServices.Abstract;
using Elastic.Apm;
using Tracking.Helper;

namespace Tracking.Repositories
{
    public class TrackingRepository : ITrackingRepository
    {
        private readonly TrackingContext _trackingContext;
        private readonly IOptions<ConnectionString> _connectionString;
        private IBermudaManager _bermudaManager;
        private IBlueBridgeManager _blueBridgeManager;
        private IBuckyDropManager _buckyDropManager;
        private ICashbashaManager _cashbashaManager;
        private IDelhiveryManager _delhiveryManager;
        private IDHLManager _dHLManager;
        private IEgyptPostManager _egyptPostManager;
        private IFedExManager _fedExManager;
        private IFreightmarkManager _freightmarkManager;
        private IFreightWorksManager _freightWorksManager;
        private IMassarManager _massarManager;
        private INaqelManager _naqelManager;
        private IOmanPostManager _omanPostManager;
        private IRedboxManger _redboxManger;
        private ISkyCargoManager _skyCargoManager;
        private ISkyPostalManager _skyPostalManager;
        private ISMSAManager _sMSAManager;
        private IUSPSManager _uSPSManager;
        private IXpITTrackManager _xpITTrackManager;
        private IYunExpressManager _yunExpressManager;
        public TrackingRepository(TrackingContext trackingContext, IOptions<ConnectionString> connectionString, IBermudaManager bermudaManager,  IBlueBridgeManager blueBridgeManager,
                                  IBuckyDropManager buckyDropManager, ICashbashaManager cashbashaManager,IDelhiveryManager delhiveryManager, IDHLManager dHLManager,
                                  IEgyptPostManager egyptPostManager,IFedExManager fedExManager, IFreightmarkManager freightmarkManager, IFreightWorksManager freightWorksManager,
                                  IMassarManager massarManager,INaqelManager naqelManager,IOmanPostManager omanPostManager,IRedboxManger redboxManger, ISkyCargoManager skyCargoManager,
                                  ISkyPostalManager skyPostalManager,ISMSAManager sMSAManager,IUSPSManager uSPSManager, IXpITTrackManager xpITTrackManager,  IYunExpressManager yunExpressManager)
        {
            _trackingContext = trackingContext;
            _connectionString = connectionString;
            _bermudaManager = bermudaManager;
            _blueBridgeManager = blueBridgeManager;
            _buckyDropManager = buckyDropManager;
            _cashbashaManager = cashbashaManager;
            _delhiveryManager = delhiveryManager;
            _dHLManager = dHLManager;
            _egyptPostManager = egyptPostManager;
            _fedExManager = fedExManager;
            _freightmarkManager = freightmarkManager;
            _freightWorksManager = freightWorksManager;
            _massarManager = massarManager;
            _naqelManager = naqelManager;
            _omanPostManager = omanPostManager;
            _redboxManger = redboxManger;
            _skyCargoManager = skyCargoManager;
            _skyPostalManager = skyPostalManager;
            _sMSAManager = sMSAManager;
            _uSPSManager = uSPSManager;
            _xpITTrackManager = xpITTrackManager;
            _yunExpressManager = yunExpressManager;
        }
        public CustomTrackingEventDTO CreateNewCustomEvent(CustomTrackingEventDTO request)
        {
            CustomTrackingEventDTO response = new CustomTrackingEventDTO();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString.Value.Tracking))
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "usp_CreateCustomEvent";
                        command.Parameters.AddWithValue("@SubscriberId", request.SubscriberId);
                        command.Parameters.AddWithValue("@Code", request.Code);
                        command.Parameters.AddWithValue("@Description", request.Description);
                        command.Parameters.AddWithValue("@user", request.CreatedBy);
                        SqlParameter codeParam = command.CreateParameter();
                        codeParam.ParameterName = "@ReturnCode";
                        codeParam.DbType = System.Data.DbType.Int64;
                        codeParam.Direction = System.Data.ParameterDirection.Output;
                        command.Parameters.Add(codeParam);

                        SqlParameter msgParam = command.CreateParameter();
                        msgParam.ParameterName = "@ReturnMessage";
                        msgParam.DbType = System.Data.DbType.String;
                        msgParam.Direction = System.Data.ParameterDirection.Output;
                        command.Parameters.Add(msgParam);

                        connection.Open();
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            long? code = null;
                            string err = string.Empty;

                            if (command.Parameters["@ReturnCode"].Value != null) code = Convert.ToInt64(command.Parameters["@ReturnCode"].Value);
                            if (command.Parameters["@ReturnMessage"].Value != null) err = Convert.ToString(command.Parameters["@ReturnMessage"].Value);

                            if (code != null || !string.IsNullOrEmpty(err))
                            {
                                response.Errors.Add(new ResponseError { Code = code.ToString(), Message = err });
                            }
                            else
                            {
                                response.IsSuccess = true;
                            }
                        }
                    }
                }
            }catch(Exception ex)
            {
                UdpLog.SendUdpLog($"Issue in CreateNewCustomEvent.", UdpLog.ApplicationError.Severity.Serious, null, ex);
                Agent.Tracer.CaptureException(ex, "Failed to CreateNewCustomEvent.", false, null,
                   new Dictionary<string, Elastic.Apm.Api.Label>() {
                        { "Request", new Elastic.Apm.Api.Label(JsonConvert.SerializeObject(request))},
                        {"Response", new Elastic.Apm.Api.Label(JsonConvert.SerializeObject(response)) }
                   });
                response.Errors.Add(new ResponseError { Message = ex.Message });
            }

            return response;
        }

        public CreateTrackingResponse CreateTrackingEvent(TrackingEventDTO trackingEvent)
        {
            CreateTrackingResponse response = new CreateTrackingResponse();
            try
            {
                TrackingEvent trackEvent = new TrackingEvent { AwbtoProcessId = trackingEvent.AwbtoProcessId, Code = trackingEvent.Code, DeliveredDate = trackingEvent.DeliveredDate, Description = trackingEvent.Description, EventDate = trackingEvent.EventDate, LastProcessedDate = trackingEvent.LastProcessedDate };
                _trackingContext.TrackingEvents.Add(trackEvent);
                _trackingContext.SaveChanges();
            }catch(Exception ex)
            {
                UdpLog.SendUdpLog($"Issue in CreateTrackingEvent.", UdpLog.ApplicationError.Severity.Serious, null, ex);
                Agent.Tracer.CaptureException(ex, "Failed to CreateTrackingEvent.", false, null,
                   new Dictionary<string, Elastic.Apm.Api.Label>() {
                        { "trackingEvent", new Elastic.Apm.Api.Label(JsonConvert.SerializeObject(trackingEvent))}
                   });
                response.Errors.Add(new ResponseError { Message = ex.Message });
            }
            return response;
        }

        public ResponseBase DeleteCustomEvent(long id)
        {
            ResponseBase response = new ResponseBase();
            try
            {
                var current = _trackingContext.CustomTrackingEvents.FirstOrDefault(c => c.Id == id);
                _trackingContext.Remove(current);
                _trackingContext.SaveChanges();
                response.IsSuccess = true;
            }catch(Exception ex)
            {
                UdpLog.SendUdpLog($"Issue in DeleteCustomEvent with id {id}.", UdpLog.ApplicationError.Severity.Serious, null, ex);
                Agent.Tracer.CaptureException(ex, "Failed to DeleteCustomEvent.", false, null,
                   new Dictionary<string, Elastic.Apm.Api.Label>() {
                        { "id", new Elastic.Apm.Api.Label(id)}
                   });
                response.Errors.Add(new ResponseError { Message = ex.Message });
            }
            return response;
        }

        public ResponseBase DeleteTrackingEvent(long id)
        {
            ResponseBase response = new ResponseBase();
            try
            {
                var current = _trackingContext.TrackingEvents.FirstOrDefault(t => t.Id == id);
                if (current == null)
                {
                    response.Errors.Add(new ResponseError { Message = "Tracking Event Id " + id + " not found" });
                }
                else
                {
                    _trackingContext.Remove(current);
                    _trackingContext.SaveChanges();
                }
            }catch(Exception ex)
            {
                UdpLog.SendUdpLog($"Issue in DeleteTrackingEvent with id {id}.", UdpLog.ApplicationError.Severity.Serious, null, ex);
                Agent.Tracer.CaptureException(ex, "Failed to DeleteTrackingEvent.", false, null,
                   new Dictionary<string, Elastic.Apm.Api.Label>() {
                        { "id", new Elastic.Apm.Api.Label(id)}
                   });
                response.Errors.Add(new ResponseError { Message = ex.Message });
            }
            return response;
        }

        public CustomTrackingEventDTO EditCustomEvent(CustomTrackingEventDTO request)
        {
            CustomTrackingEventDTO response = new CustomTrackingEventDTO();
            try
            {
                var current = _trackingContext.CustomTrackingEvents.FirstOrDefault(c => c.Id == request.Id);
                if (current == null)
                {
                    response.Errors.Add(new ResponseError { Message = "Tracking event not found." });
                    return response;
                }
                current.Active = request.Active;
                current.Code = request.Code;
                current.CreatedBy = request.CreatedBy;
                current.CreatedDate = request.CreatedDate;
                current.Description = request.Description;
                current.ModifiedBy = request.ModifiedBy;
                current.ModifiedDate = request.ModifiedDate;
                current.SubscriberId = request.SubscriberId;
                _trackingContext.SaveChanges();
                response = request;
                response.IsSuccess = true;
            }catch(Exception ex)
            {
                UdpLog.SendUdpLog($"Issue in EditCustomEvent.", UdpLog.ApplicationError.Severity.Serious, null, ex);
                Agent.Tracer.CaptureException(ex, "Failed to EditCustomEvent.", false, null,
                   new Dictionary<string, Elastic.Apm.Api.Label>() {
                        { "Request", new Elastic.Apm.Api.Label(JsonConvert.SerializeObject(request))},
                        {"Response", new Elastic.Apm.Api.Label(JsonConvert.SerializeObject(response)) }
                   });
                response.Errors.Add(new ResponseError { Message = ex.Message });
            }
            return response;
        }

        public DeliveredResponse GetDeliveredDate(int TrackingServiceId, int SubscriberId, string AWB = null, string CustomAWB = null, string UniqueId = null)
        {
            DeliveredResponse response = new DeliveredResponse();
            try
            {
                var ret = GetTracking(TrackingServiceId, SubscriberId, AWB, CustomAWB, UniqueId);
                if (ret.tracking.Count(t => t.DeliveredDate != null) > 0)
                {
                    response.DeliveredDate = ret.tracking.FirstOrDefault(t => t.DeliveredDate != null).DeliveredDate;
                    response.IsDelivered = true;
                }
                else
                {
                    response.IsDelivered = false;
                    response.Errors.Add(new ResponseError { Message = "No delivered event found" });
                }

            }catch(Exception ex)
            {
                UdpLog.SendUdpLog($"Issue in GetDeliveredDate with {TrackingServiceId} subscriber {SubscriberId} and awb {AWB}.", UdpLog.ApplicationError.Severity.Serious, null, ex);
                Agent.Tracer.CaptureException(ex, "Failed to GetDeliveredDate.", false, null,
                   new Dictionary<string, Elastic.Apm.Api.Label>() {
                        { "TrackingServiceId", new Elastic.Apm.Api.Label(TrackingServiceId)},
                        { "SubscriberId", new Elastic.Apm.Api.Label(SubscriberId)},
                        { "AWB", new Elastic.Apm.Api.Label(AWB)},
                        { "CustomAWB", new Elastic.Apm.Api.Label(CustomAWB)},
                        { "UniqueId", new Elastic.Apm.Api.Label(UniqueId)}
                   });
                response.Errors.Add(new ResponseError { Message = ex.Message });
            }
            return response;
        }

        public RawTrackingResult InsertRawTracking(int awbtoprocessid)
        {
            RawTrackingResult response = new RawTrackingResult();
            try
            {
                string json = string.Empty;
                var awbToProcess = _trackingContext.AwbtoProcesses.FirstOrDefault(t => t.Id == awbtoprocessid);                
                TrackingCreds trackingCreds = JsonConvert.DeserializeObject<TrackingCreds>(awbToProcess.TrackingServiceCredentials);
                if (awbToProcess == null)
                {
                    response.Errors.Add(new ResponseError { Message = "Record with id " + awbtoprocessid + "not found." });
                    return response;
                }
                switch (awbToProcess.TrackingServiceId)
                {
                    case (int)Services.BermudaPost:
                        json = _bermudaManager.GetBermudaTrackingDetails(awbToProcess.Awb, _trackingContext, trackingCreds);
                        break;
                    case (int)Services.OTSD:
                        json = _cashbashaManager.GetCBTrackingDetails(awbToProcess.Awb, _trackingContext, trackingCreds);
                        break;
                    case (int)Services.BluePostal:
                        json = _xpITTrackManager.GetXpITTrackingDetails(awbToProcess.Awb, _trackingContext, trackingCreds);
                        break;
                    case (int)Services.DHL:
                        json = _dHLManager.GetDHLTracking(awbToProcess.Awb, trackingCreds, _trackingContext);
                        break;
                    case (int)Services.EgyptPost:
                        json = _egyptPostManager.GetEgyptPostTracking(awbToProcess.Awb, _trackingContext, trackingCreds);
                        break;
                    case (int)Services.FedEx:
                        json = _fedExManager.GetFedexTracking(awbToProcess.Awb, _trackingContext, trackingCreds);
                        break;
                    case (int)Services.FreightMark:
                        json = _freightmarkManager.GetFreightMarkTrackingDetails(awbToProcess.Awb, _trackingContext, trackingCreds);
                        break;
                    case (int)Services.Emirates:
                        json = _massarManager.GetMassarTrackingLog(awbToProcess.Awb, _trackingContext, trackingCreds);
                        break;
                    case (int)Services.Naqel:
                        json = _naqelManager.GetNaqelTrackingDetails(awbToProcess.Awb, _trackingContext, trackingCreds);
                        break;
                    case (int)Services.OmanPost:
                        json = _omanPostManager.GetAETrackingDetails(awbToProcess.Awb, _trackingContext, trackingCreds);
                        break;
                    case (int)Services.Redbox:
                        json = _redboxManger.GetRedboxTrackingDetails(awbToProcess.Awb, _trackingContext, trackingCreds);
                        break;
                    case (int)Services.SkyCargo:
                        json = _skyCargoManager.GetSkyCargoTrackingDetails(awbToProcess.Awb, _trackingContext, trackingCreds);
                        break;
                    case (int)Services.SkyPostal:
                        json = _skyPostalManager.GetSKTrackingDetails(awbToProcess.Awb, _trackingContext, trackingCreds);
                        break;
                    case (int)Services.SMSA:
                        json = _sMSAManager.GetSMSATrackingDetails(awbToProcess.Awb, _trackingContext, trackingCreds);
                        break;
                    case (int)Services.UPS:
                        json = _uSPSManager.GetUSPSFirstClassTrackingDetails(awbToProcess.Awb, _trackingContext, trackingCreds);
                        break;
                    case (int)Services.USPS:
                        json = _uSPSManager.GetUSPSFirstClassTrackingDetails(awbToProcess.Awb, _trackingContext, trackingCreds);
                        break;
                    case (int)Services.YunExpress:
                        json = _yunExpressManager.GetYunExpressTrackingDetails(awbToProcess.Awb, _trackingContext, trackingCreds);
                        break;
                }
                if (!string.IsNullOrEmpty(json))
                {
                    RawServiceDatum rawServiceDatum = new RawServiceDatum { Awb = awbToProcess.Awb, AwbtoProcessId = awbtoprocessid, ImportDate = DateTime.Now, RawData = json };                  
                    _trackingContext.RawServiceData.Add(rawServiceDatum);
                    _trackingContext.SaveChanges();
                    awbToProcess.LastProcessedDate = DateTime.Now;
                    _trackingContext.SaveChanges();
                    response.IsSuccess = true;
                }
            }catch(Exception ex)
            {
                UdpLog.SendUdpLog($"Issue in InsertRawTracking with awbprocessid {awbtoprocessid}.", UdpLog.ApplicationError.Severity.Serious, null, ex);
                Agent.Tracer.CaptureException(ex, "Failed to InsertRawTracking.", false, null,
                   new Dictionary<string, Elastic.Apm.Api.Label>() {
                        { "awbtoprocessid", new Elastic.Apm.Api.Label(awbtoprocessid)}
                   });
                response.Errors.Add(new ResponseError { Message = ex.Message });
            }
            return response;
        }

        public RawTrackingResponse InsertTrackingRaw(RawTrackingRequest request)
        {
            RawTrackingResponse response = new RawTrackingResponse();
            try
            {
                foreach(var id in request.AwbToProcessId)
                {
                    var ret = InsertRawTracking(id);
                    response.results.Add(ret);
                }
                response.IsSuccess = !response.results.Any(r => r.IsSuccess == false);
                if (!response.IsSuccess)
                {
                    response.Errors.Add(new ResponseError { Message = "One or more errors occured. See inner errors for details." });
                }

            }catch(Exception ex)
            {
                UdpLog.SendUdpLog($"Issue in InsertTrackingRaw.", UdpLog.ApplicationError.Severity.Serious, null, ex);
                Agent.Tracer.CaptureException(ex, "Failed to InsertTrackingRaw.", false, null,
                   new Dictionary<string, Elastic.Apm.Api.Label>() {
                        { "Request", new Elastic.Apm.Api.Label(JsonConvert.SerializeObject(request))},
                        {"Response", new Elastic.Apm.Api.Label(JsonConvert.SerializeObject(response)) }
                   });
                response.Errors.Add(new ResponseError { Message = ex.Message });
            }
            return response;
        }

        public CarrierTrackingResponse GetCarrierTracking(int TrackingServiceId, int SubscriberId, string AWB = null, string CustomAWB = null, string UniqueId = null)
        {
            CarrierTrackingResponse response = null;
            try
            {
                var awbToProcess = _trackingContext.AwbtoProcesses.FirstOrDefault(t => t.Awb == AWB);
                var ret = GetTracking(TrackingServiceId, SubscriberId, AWB, CustomAWB, UniqueId);
                if (ret != null && ret.IsSuccess)
                {
                    response = new CarrierTrackingResponse();
                    response.IsDelivered = ret.tracking.Any(t => t.DeliveredDate != null);
                    response.IsSuccess = true;
                    response.ShipDate = awbToProcess.ShipDate;
                    response.ShipmentStatus = ret.tracking.OrderByDescending(t => t.EventDate).FirstOrDefault().Description;
                    response.TrackingNumber = AWB;
                    response.Events = (from e in ret.tracking
                                       select new CarrierEvent { ArrivalLocation = e.Location, EventDescription = e.Description, EventType = e.Code, Timestamp = e.EventDate }).ToList();
                }


            }catch(Exception ex)
            {
                UdpLog.SendUdpLog($"Issue in GetCarrierTracking with {TrackingServiceId} subscriber {SubscriberId} and awb {AWB}.", UdpLog.ApplicationError.Severity.Serious, null, ex);
                Agent.Tracer.CaptureException(ex, "Failed to GetCarrierTracking.", false, null,
                   new Dictionary<string, Elastic.Apm.Api.Label>() {
                        { "TrackingServiceId", new Elastic.Apm.Api.Label(TrackingServiceId)},
                        {"SubscriberId", new Elastic.Apm.Api.Label(SubscriberId) },
                        {"AWB", new Elastic.Apm.Api.Label(AWB) },
                        {"CustomAWB", new Elastic.Apm.Api.Label(CustomAWB) },
                        {"UniqueId", new Elastic.Apm.Api.Label(UniqueId) }
                   });
            }
            return response;
        }
        public AllTrackingResponse GetTracking(int TrackingServiceId, int SubscriberId, string AWB = null, string CustomAWB = null, string UniqueId = null)
        {
            AllTrackingResponse response = new AllTrackingResponse();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString.Value.Tracking))
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "usp_GetTracking";
                        command.Parameters.AddWithValue("@TrackingServiceId", TrackingServiceId);
                        command.Parameters.AddWithValue("@SubscriberId", SubscriberId);
                        if (!string.IsNullOrEmpty(UniqueId)) command.Parameters.AddWithValue("@UniqueId", UniqueId);
                        if (!string.IsNullOrEmpty(AWB)) command.Parameters.AddWithValue("@AWB", AWB);
                        if (!string.IsNullOrEmpty(CustomAWB)) command.Parameters.AddWithValue("@CustomAWB", CustomAWB);

                        SqlParameter codeParam = command.CreateParameter();
                        codeParam.ParameterName = "@ReturnCode";
                        codeParam.DbType = System.Data.DbType.Int64;
                        codeParam.Direction = System.Data.ParameterDirection.Output;
                        command.Parameters.Add(codeParam);

                        SqlParameter msgParam = command.CreateParameter();
                        msgParam.ParameterName = "@ReturnCode";
                        msgParam.DbType = System.Data.DbType.String;
                        msgParam.Direction = System.Data.ParameterDirection.Output;
                        command.Parameters.Add(msgParam);

                        connection.Open();
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            long? code = null;
                            string err = string.Empty;

                            if (command.Parameters["@ReturnCode"].Value != null) code = Convert.ToInt64(command.Parameters["@ReturnCode"].Value);
                            if (command.Parameters["@ReturnMessage"].Value != null) err = Convert.ToString(command.Parameters["@ReturnMessage"].Value);

                            if (code != null || !string.IsNullOrEmpty(err))
                            {
                                response.Errors.Add(new ResponseError { Code = code.ToString(), Message = err });
                            }
                            else
                            {
                                response.tracking = new List<TrackingResponse>();
                                while (dr.Read())
                                {
                                    TrackingResponse t = new TrackingResponse();
                                    t.TrackingServiceId = TrackingServiceId;
                                    t.SubscriberId = SubscriberId;
                                    t.Id = Convert.ToInt32(dr["TrackingEventsId"]);
                                    if (!(dr["awb"] is DBNull)) t.AWB = Convert.ToString(dr["awb"]);
                                    if (!(dr["uniqueid"] is DBNull)) t.UniqueId = Convert.ToString(dr["uniqueid"]);
                                    if (!(dr["customawb"] is DBNull)) t.CustomAWB = Convert.ToString(dr["customawb"]);
                                    t.EventDate = Convert.ToDateTime(dr["EventDate"]);
                                    if (!(dr["Code"] is DBNull)) t.Code = Convert.ToString(dr["Code"]);
                                    if (!(dr["Description"] is DBNull)) t.Description = Convert.ToString(dr["Description"]);
                                    if (!(dr["DeliveredDate"] is DBNull)) t.DeliveredDate = Convert.ToDateTime(dr["DeliveredDate"]);
                                    if (!(dr["LastProcessedDate"] is DBNull)) t.LastProcessedDate = Convert.ToDateTime(dr["LastProcessedDate"]);
                                    if (!(dr["Location"] is DBNull)) t.Location = Convert.ToString(dr["Location"]);
                                    response.tracking.Add(t);
                                }
                            }
                        }
                    }
                }
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                UdpLog.SendUdpLog($"Issue in GetDeliveredDate with {TrackingServiceId} subscriber {SubscriberId} and awb {AWB}.", UdpLog.ApplicationError.Severity.Serious, null, ex);
                Agent.Tracer.CaptureException(ex, "Failed to GetDeliveredDate.", false, null,
                   new Dictionary<string, Elastic.Apm.Api.Label>() {
                        { "TrackingServiceId", new Elastic.Apm.Api.Label(TrackingServiceId)},
                        { "SubscriberId", new Elastic.Apm.Api.Label(SubscriberId)},
                        { "AWB", new Elastic.Apm.Api.Label(AWB)},
                        { "CustomAWB", new Elastic.Apm.Api.Label(CustomAWB)},
                        { "UniqueId", new Elastic.Apm.Api.Label(UniqueId)}
                   });
                response.Errors.Add(new ResponseError { Message = ex.Message });
            }
            return response;
        }


        public void ConvertMultipleRawToStaging(List<int> rawids)
        {
            try
            {
                foreach(int id in rawids)
                {
                    ConvertRawToStaging(id);
                }
            }catch(Exception ex)
            {
                UdpLog.SendUdpLog($"Issue in ConvertMultipleRawToStaging.", UdpLog.ApplicationError.Severity.Serious, null, ex);
                Agent.Tracer.CaptureException(ex, "Failed to ConvertMultipleRawToStaging.", false, null,
                   new Dictionary<string, Elastic.Apm.Api.Label>() {
                        { "rawids", new Elastic.Apm.Api.Label(JsonConvert.SerializeObject(rawids))}
                   });
            }
        }
        public ResponseBase ConvertRawToStaging(int rawId)
        {
            RawTrackingResult response = new RawTrackingResult();
            try
            {
                List<StagingServiceDatum> json = null;
                var rawRec = _trackingContext.RawServiceData.FirstOrDefault(t => t.Id == rawId);


                if (rawRec == null)
                {
                    response.Errors.Add(new ResponseError { Message = "Raw record " + rawId + " not foung" });
                    return response;
                }

                var awb = _trackingContext.AwbtoProcesses.FirstOrDefault(t => t.Id == rawRec.AwbtoProcessId);

                switch (awb.TrackingServiceId)
                {
                    case (int)Services.BermudaPost:
                        json = _bermudaManager.RawToStaging(rawRec.RawData, awb, rawId);
                        break;
                    case (int)Services.OTSD:
                        json = _cashbashaManager.RawToStaging(rawRec.RawData, awb, rawId);
                        break;
                    case (int)Services.DHL:
                        json = _dHLManager.RawToStaging(rawRec.RawData, awb, rawId);
                        break;
                    case (int)Services.EgyptPost:
                        json = _egyptPostManager.RawToStaging(rawRec.RawData, awb, rawId);
                        break;
                    case (int)Services.FedEx:
                        json = _fedExManager.RawToStaging(rawRec.RawData, awb, rawId);
                        break;
                    case (int)Services.FreightMark:
                        json = _freightmarkManager.RawToStaging(rawRec.RawData, awb, rawId);
                        break;
                    case (int)Services.Emirates:
                        json = _massarManager.RawToStaging(rawRec.RawData, awb, rawId);
                        break;
                    case (int)Services.Naqel:
                        json = _naqelManager.RawToStaging(rawRec.RawData, awb, rawId);
                        break;
                    case (int)Services.OmanPost:
                        json = _omanPostManager.RawToStaging(rawRec.RawData, awb, rawId);
                        break;
                    case (int)Services.Redbox:
                        json = _redboxManger.RawToStaging(rawRec.RawData, awb, rawId);
                        break;
                    case (int)Services.SkyCargo:
                        json = _skyCargoManager.RawToStaging(rawRec.RawData, awb, rawId);
                        break;
                    case (int)Services.SkyPostal:
                        json = _skyPostalManager.RawToStaging(rawRec.RawData, awb, rawId);
                        break;
                    case (int)Services.SMSA:
                        json = _sMSAManager.RawToStaging(rawRec.RawData, awb, rawId);
                        break;
                    case (int)Services.UPS:
                        json = _uSPSManager.RawToStaging(rawRec.RawData, awb, rawId);
                        break;
                    case (int)Services.USPS:
                        json = _uSPSManager.RawToStaging(rawRec.RawData, awb, rawId);
                        break;
                    case (int)Services.YunExpress:
                        json = _yunExpressManager.RawToStaging(rawRec.RawData, awb, rawId);
                        break;
                }
                var currStaging = _trackingContext.StagingServiceData.Where(t => t.RawServiceDataId == rawId).ToList();
                var inserts = (from t in json
                               where !currStaging.Any(c => c.Location == t.Location && c.Code == t.Code && c.Description == t.Description)
                               select t).ToList();
                _trackingContext.StagingServiceData.AddRange(inserts);
                rawRec.ProcessedDate = DateTime.Now;
                _trackingContext.SaveChanges();                
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                UdpLog.SendUdpLog($"Issue in ConvertRawToStaging with {rawId}.", UdpLog.ApplicationError.Severity.Serious, null, ex);
                Agent.Tracer.CaptureException(ex, "Failed to ConvertRawToStaging.", false, null,
                   new Dictionary<string, Elastic.Apm.Api.Label>() {
                        { "rawId", new Elastic.Apm.Api.Label(rawId)}
                   });
                response.Errors.Add(new ResponseError { Message = ex.Message });
            }
            return response;
        }

        public AwbToProcessResponse InsertAwbToProcess(AwbToProcessResponse request)
        {
            AwbToProcessResponse response = new AwbToProcessResponse();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString.Value.Tracking))
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "usp_CreateAWBToProccess";
                        command.Parameters.AddWithValue("@TrackingServiceId", request.TrackingServiceId);
                        command.Parameters.AddWithValue("@SubscriberId", request.SubscriberId);
                        if (!string.IsNullOrEmpty(request.UniqueId)) command.Parameters.AddWithValue("@UniqueId", request.UniqueId);
                        command.Parameters.AddWithValue("@TrackingLeg", request.TrackingLeg);
                        command.Parameters.AddWithValue("@AWB", request.Awb);
                        command.Parameters.AddWithValue("@ShipDate", request.ShipDate);
                        if (!string.IsNullOrEmpty(request.CustomAwb)) command.Parameters.AddWithValue("@CustomAWB", request.CustomAwb);
                        command.Parameters.AddWithValue("@CreatedDate", request.CreateDate);
                        command.Parameters.AddWithValue("@TrackingServiceCredentials", request.TrackingServiceCredentials);
                        SqlParameter codeParam = command.CreateParameter();
                        codeParam.ParameterName = "@ReturnCode";
                        codeParam.DbType = System.Data.DbType.Int32;
                        codeParam.Direction = System.Data.ParameterDirection.Output;
                        command.Parameters.Add(codeParam);


                        command.Parameters.Add("@ReturnMessage", SqlDbType.NVarChar, 2000);
                        command.Parameters["@ReturnMessage"].Direction = ParameterDirection.Output;
                        connection.Open();
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            long? code = null;
                            string err = string.Empty;

                            if (command.Parameters["@ReturnCode"].Value != null) code = Convert.ToInt64(command.Parameters["@ReturnCode"].Value);
                            if (command.Parameters["@ReturnMessage"].Value != null) err = Convert.ToString(command.Parameters["@ReturnMessage"].Value);

                            if (code != null || !string.IsNullOrEmpty(err))
                            {
                                response.Errors.Add(new ResponseError { Code = code.ToString(), Message = err });
                            }
                            else
                            {
                                response = request;
                                response.IsSuccess = true;
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                UdpLog.SendUdpLog($"Issue in InsertAwbToProcess.", UdpLog.ApplicationError.Severity.Serious, null, ex);
                Agent.Tracer.CaptureException(ex, "Failed to InsertAwbToProcess.", false, null,
                   new Dictionary<string, Elastic.Apm.Api.Label>() {
                        { "Request", new Elastic.Apm.Api.Label(JsonConvert.SerializeObject(request))},
                        {"Response", new Elastic.Apm.Api.Label(JsonConvert.SerializeObject(response)) }
                   });
                response.Errors.Add(new ResponseError { Message = ex.Message });
            }
            return response;
        }

        public SubscriberReponse InsertSubscriber(SubscriberReponse request)
        {
            SubscriberReponse response = new SubscriberReponse();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString.Value.Tracking))
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "usp_CreateSubscriber";
                        command.Parameters.AddWithValue("@Subscriber", request.Subscriber1);
                        command.Parameters.AddWithValue("@username", request.CreatedBy);
                        SqlParameter codeParam = command.CreateParameter();
                        codeParam.ParameterName = "@ReturnCode";
                        codeParam.DbType = System.Data.DbType.Int64;
                        codeParam.Direction = System.Data.ParameterDirection.Output;
                        command.Parameters.Add(codeParam);

                        SqlParameter msgParam = command.CreateParameter();
                        msgParam.ParameterName = "@ReturnMessage";
                        msgParam.DbType = System.Data.DbType.String;
                        msgParam.Direction = System.Data.ParameterDirection.Output;
                        command.Parameters.Add(msgParam);

                        connection.Open();
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            long? code = null;
                            string err = string.Empty;

                            if (command.Parameters["@ReturnCode"].Value != null) code = Convert.ToInt64(command.Parameters["@ReturnCode"].Value);
                            if (command.Parameters["@ReturnMessage"].Value != null) err = Convert.ToString(command.Parameters["@ReturnMessage"].Value);

                            if (code != null || !string.IsNullOrEmpty(err))
                            {
                                response.Errors.Add(new ResponseError { Code = code.ToString(), Message = err });
                            }
                            else
                            {
                                response.IsSuccess = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                UdpLog.SendUdpLog($"Issue in InsertSubscriber.", UdpLog.ApplicationError.Severity.Serious, null, ex);
                Agent.Tracer.CaptureException(ex, "Failed to InsertSubscriber.", false, null,
                   new Dictionary<string, Elastic.Apm.Api.Label>() {
                        { "Request", new Elastic.Apm.Api.Label(JsonConvert.SerializeObject(request))},
                        {"Response", new Elastic.Apm.Api.Label(JsonConvert.SerializeObject(response)) }
                   });
                response.Errors.Add(new ResponseError { Message = ex.Message });
            }
            return response;
        }

    }
}
