using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracking.Models.TrackingServices.SkyChain
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace = "http://xmlns.example.com/1516679344905", ConfigurationName = "TrackingServices.SkyChain.SkyChainEndpoint")]
    public interface SkyChainEndpoint
    {

        // CODEGEN: Generating message contract since the operation getTrackShipmentDetails is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action = "/Service/SkyChainPlatformService.serviceagent/getTrackShipmentDetails", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        
        TrackingServices.SkyChain.getTrackShipmentDetailsResponse getTrackShipmentDetails(TrackingServices.SkyChain.getTrackShipmentDetailsRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "/Service/SkyChainPlatformService.serviceagent/getTrackShipmentDetails", ReplyAction = "*")]
        System.Threading.Tasks.Task<TrackingServices.SkyChain.getTrackShipmentDetailsResponse> getTrackShipmentDetailsAsync(TrackingServices.SkyChain.getTrackShipmentDetailsRequest request);
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("svcutil", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.emirates.com/pss/integration/xmlschemas/cargo/SkyChainTrackShipment-rq" +
        "/v1.0/2018/01")]
    public partial class TrackServiceRequest
    {

        private string documentTypeField;

        private string documentPrefixField;

        private string documentNumberField;

        private string jobReferenceNumberField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string documentType
        {
            get
            {
                return this.documentTypeField;
            }
            set
            {
                this.documentTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string documentPrefix
        {
            get
            {
                return this.documentPrefixField;
            }
            set
            {
                this.documentPrefixField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string documentNumber
        {
            get
            {
                return this.documentNumberField;
            }
            set
            {
                this.documentNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string jobReferenceNumber
        {
            get
            {
                return this.jobReferenceNumberField;
            }
            set
            {
                this.jobReferenceNumberField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("svcutil", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.emirates.com/pss/integration/xmlschemas/cargo/SkyChainTrackShipment-rs" +
        "/v1.0/2018/01")]
    public partial class ErrorDTO
    {

        private string errorTypeField;

        private string errorCodeField;

        private string errorDescriptionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string errorType
        {
            get
            {
                return this.errorTypeField;
            }
            set
            {
                this.errorTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string errorCode
        {
            get
            {
                return this.errorCodeField;
            }
            set
            {
                this.errorCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string errorDescription
        {
            get
            {
                return this.errorDescriptionField;
            }
            set
            {
                this.errorDescriptionField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("svcutil", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.emirates.com/pss/integration/xmlschemas/cargo/SkyChainTrackShipment-rs" +
        "/v1.0/2018/01")]
    public partial class TrackFlightDetailsDTO
    {

        private string carrierCodeField;

        private string flightNumberField;

        private string scheduleDepDateAndTimeField;

        private string estimatedDepDateAndTimeField;

        private string actualDepDateAndTimeField;

        private string bordPointField;

        private string bordPointDescriptionField;

        private string offPointField;

        private string offPointDescriptionField;

        private string scheduleArrivalDateAndTimeField;

        private string estimatedArrDateAndTimeField;

        private string actualArrDateAndTimeField;

        private string serviceCodeField;

        private string serviceDescriptionField;

        private string serviceStatusDateField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string carrierCode
        {
            get
            {
                return this.carrierCodeField;
            }
            set
            {
                this.carrierCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string flightNumber
        {
            get
            {
                return this.flightNumberField;
            }
            set
            {
                this.flightNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string scheduleDepDateAndTime
        {
            get
            {
                return this.scheduleDepDateAndTimeField;
            }
            set
            {
                this.scheduleDepDateAndTimeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string estimatedDepDateAndTime
        {
            get
            {
                return this.estimatedDepDateAndTimeField;
            }
            set
            {
                this.estimatedDepDateAndTimeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string actualDepDateAndTime
        {
            get
            {
                return this.actualDepDateAndTimeField;
            }
            set
            {
                this.actualDepDateAndTimeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string bordPoint
        {
            get
            {
                return this.bordPointField;
            }
            set
            {
                this.bordPointField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string bordPointDescription
        {
            get
            {
                return this.bordPointDescriptionField;
            }
            set
            {
                this.bordPointDescriptionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string offPoint
        {
            get
            {
                return this.offPointField;
            }
            set
            {
                this.offPointField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string offPointDescription
        {
            get
            {
                return this.offPointDescriptionField;
            }
            set
            {
                this.offPointDescriptionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public string scheduleArrivalDateAndTime
        {
            get
            {
                return this.scheduleArrivalDateAndTimeField;
            }
            set
            {
                this.scheduleArrivalDateAndTimeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public string estimatedArrDateAndTime
        {
            get
            {
                return this.estimatedArrDateAndTimeField;
            }
            set
            {
                this.estimatedArrDateAndTimeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        public string actualArrDateAndTime
        {
            get
            {
                return this.actualArrDateAndTimeField;
            }
            set
            {
                this.actualArrDateAndTimeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        public string serviceCode
        {
            get
            {
                return this.serviceCodeField;
            }
            set
            {
                this.serviceCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        public string serviceDescription
        {
            get
            {
                return this.serviceDescriptionField;
            }
            set
            {
                this.serviceDescriptionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        public string serviceStatusDate
        {
            get
            {
                return this.serviceStatusDateField;
            }
            set
            {
                this.serviceStatusDateField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("svcutil", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.emirates.com/pss/integration/xmlschemas/cargo/SkyChainTrackShipment-rs" +
        "/v1.0/2018/01")]
    public partial class TrackMovementStatusDTO
    {

        private string stationField;

        private string stationDescriptionField;

        private string statusDateField;

        private string statusField;

        private string piecesField;

        private string weightField;

        private string weightUnitField;

        private string shipmentDescriptionCodeField;

        private TrackFlightDetailsDTO flightDetailsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string station
        {
            get
            {
                return this.stationField;
            }
            set
            {
                this.stationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string stationDescription
        {
            get
            {
                return this.stationDescriptionField;
            }
            set
            {
                this.stationDescriptionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string statusDate
        {
            get
            {
                return this.statusDateField;
            }
            set
            {
                this.statusDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string pieces
        {
            get
            {
                return this.piecesField;
            }
            set
            {
                this.piecesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string weight
        {
            get
            {
                return this.weightField;
            }
            set
            {
                this.weightField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string weightUnit
        {
            get
            {
                return this.weightUnitField;
            }
            set
            {
                this.weightUnitField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string shipmentDescriptionCode
        {
            get
            {
                return this.shipmentDescriptionCodeField;
            }
            set
            {
                this.shipmentDescriptionCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public TrackFlightDetailsDTO flightDetails
        {
            get
            {
                return this.flightDetailsField;
            }
            set
            {
                this.flightDetailsField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("svcutil", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.emirates.com/pss/integration/xmlschemas/cargo/SkyChainTrackShipment-rs" +
        "/v1.0/2018/01")]
    public partial class TrackHeaderDTO
    {

        private string documentTypeField;

        private string documentPrefixField;

        private string documentNumberField;

        private string jobReferenceNumberField;

        private string originField;

        private string originDescriptionField;

        private string destinationField;

        private string destinationDescriptionField;

        private string piecesField;

        private string weightField;

        private string weightUnitField;

        private string volumeField;

        private string volumeUnitField;

        private string natureOfGoodsField;

        private string productField;

        private string productDescriptionField;

        private string shcCodeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string documentType
        {
            get
            {
                return this.documentTypeField;
            }
            set
            {
                this.documentTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string documentPrefix
        {
            get
            {
                return this.documentPrefixField;
            }
            set
            {
                this.documentPrefixField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string documentNumber
        {
            get
            {
                return this.documentNumberField;
            }
            set
            {
                this.documentNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string jobReferenceNumber
        {
            get
            {
                return this.jobReferenceNumberField;
            }
            set
            {
                this.jobReferenceNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string origin
        {
            get
            {
                return this.originField;
            }
            set
            {
                this.originField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string originDescription
        {
            get
            {
                return this.originDescriptionField;
            }
            set
            {
                this.originDescriptionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string destination
        {
            get
            {
                return this.destinationField;
            }
            set
            {
                this.destinationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string destinationDescription
        {
            get
            {
                return this.destinationDescriptionField;
            }
            set
            {
                this.destinationDescriptionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string pieces
        {
            get
            {
                return this.piecesField;
            }
            set
            {
                this.piecesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public string weight
        {
            get
            {
                return this.weightField;
            }
            set
            {
                this.weightField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public string weightUnit
        {
            get
            {
                return this.weightUnitField;
            }
            set
            {
                this.weightUnitField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        public string volume
        {
            get
            {
                return this.volumeField;
            }
            set
            {
                this.volumeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        public string volumeUnit
        {
            get
            {
                return this.volumeUnitField;
            }
            set
            {
                this.volumeUnitField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        public string natureOfGoods
        {
            get
            {
                return this.natureOfGoodsField;
            }
            set
            {
                this.natureOfGoodsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        public string product
        {
            get
            {
                return this.productField;
            }
            set
            {
                this.productField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        public string productDescription
        {
            get
            {
                return this.productDescriptionField;
            }
            set
            {
                this.productDescriptionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        public string shcCode
        {
            get
            {
                return this.shcCodeField;
            }
            set
            {
                this.shcCodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("svcutil", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.emirates.com/pss/integration/xmlschemas/cargo/SkyChainTrackShipment-rs" +
        "/v1.0/2018/01")]
    public partial class TrackServiceResponseRecord
    {

        private TrackHeaderDTO headerField;

        private TrackMovementStatusDTO[] movementstatusesField;

        private ErrorDTO[] errorsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TrackHeaderDTO header
        {
            get
            {
                return this.headerField;
            }
            set
            {
                this.headerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 1)]
        [System.Xml.Serialization.XmlArrayItemAttribute("movementStatus")]
        public TrackMovementStatusDTO[] movementstatuses
        {
            get
            {
                return this.movementstatusesField;
            }
            set
            {
                this.movementstatusesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 2)]
        [System.Xml.Serialization.XmlArrayItemAttribute("errors")]
        public ErrorDTO[] errors
        {
            get
            {
                return this.errorsField;
            }
            set
            {
                this.errorsField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("svcutil", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.emirates.com/pss/integration/xmlschemas/cargo/SkyChainTrackShipment-rs" +
        "/v1.0/2018/01")]
    public partial class TrackServiceRequestRecord
    {

        private string documentTypeField;

        private string documentPrefixField;

        private string documentNumberField;

        private string jobReferenceNumberField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string documentType
        {
            get
            {
                return this.documentTypeField;
            }
            set
            {
                this.documentTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string documentPrefix
        {
            get
            {
                return this.documentPrefixField;
            }
            set
            {
                this.documentPrefixField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string documentNumber
        {
            get
            {
                return this.documentNumberField;
            }
            set
            {
                this.documentNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string jobReferenceNumber
        {
            get
            {
                return this.jobReferenceNumberField;
            }
            set
            {
                this.jobReferenceNumberField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("svcutil", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.emirates.com/pss/integration/xmlschemas/cargo/SkyChainTrackShipment-rs" +
        "/v1.0/2018/01")]
    public partial class TrackServiceResult
    {

        private TrackServiceRequestRecord[] requestField;

        private TrackServiceResponseRecord[] responseField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true, Order = 0)]
        [System.Xml.Serialization.XmlArrayItemAttribute("record", typeof(TrackServiceRequestRecord))]
        public TrackServiceRequestRecord[] request
        {
            get
            {
                return this.requestField;
            }
            set
            {
                this.requestField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true, Order = 1)]
        [System.Xml.Serialization.XmlArrayItemAttribute("record", typeof(TrackServiceResponseRecord))]
        public TrackServiceResponseRecord[] response
        {
            get
            {
                return this.responseField;
            }
            set
            {
                this.responseField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("svcutil", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.emirates.com/pss/integration/xmlschemas/cargo/SkyChainTrackShipment-rs" +
        "/v1.0/2018/01")]
    public partial class TrackServiceResponse
    {

        private TrackServiceResult[] resultField;

        private ErrorDTO[] errorsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("result", IsNullable = true, Order = 0)]
        public TrackServiceResult[] result
        {
            get
            {
                return this.resultField;
            }
            set
            {
                this.resultField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("errors", IsNullable = true, Order = 1)]
        public ErrorDTO[] errors
        {
            get
            {
                return this.errorsField;
            }
            set
            {
                this.errorsField = value;
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class getTrackShipmentDetailsRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.emirates.com/pss/integration/xmlschemas/cargo/SkyChainTrackShipment-rq" +
            "/v1.0/2018/01", Order = 0)]
        public TrackingServices.SkyChain.TrackServiceRequest trackShipmentServiceRequest;

        public getTrackShipmentDetailsRequest()
        {
        }

        public getTrackShipmentDetailsRequest(TrackingServices.SkyChain.TrackServiceRequest trackShipmentServiceRequest)
        {
            this.trackShipmentServiceRequest = trackShipmentServiceRequest;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class getTrackShipmentDetailsResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.emirates.com/pss/integration/xmlschemas/cargo/SkyChainTrackShipment-rs" +
            "/v1.0/2018/01", Order = 0)]
        public TrackingServices.SkyChain.TrackServiceResponse trackShipmentServiceResponse;

        public getTrackShipmentDetailsResponse()
        {
        }

        public getTrackShipmentDetailsResponse(TrackingServices.SkyChain.TrackServiceResponse trackShipmentServiceResponse)
        {
            this.trackShipmentServiceResponse = trackShipmentServiceResponse;
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface SkyChainEndpointChannel : TrackingServices.SkyChain.SkyChainEndpoint, System.ServiceModel.IClientChannel
    {
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SkyChainEndpointClient : System.ServiceModel.ClientBase<TrackingServices.SkyChain.SkyChainEndpoint>, TrackingServices.SkyChain.SkyChainEndpoint
    {

        public SkyChainEndpointClient()
        {
        }

        public SkyChainEndpointClient(string endpointConfigurationName) :
                base(endpointConfigurationName)
        {
        }

        public SkyChainEndpointClient(string endpointConfigurationName, string remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public SkyChainEndpointClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public SkyChainEndpointClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
                base(binding, remoteAddress)
        {
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        TrackingServices.SkyChain.getTrackShipmentDetailsResponse TrackingServices.SkyChain.SkyChainEndpoint.getTrackShipmentDetails(TrackingServices.SkyChain.getTrackShipmentDetailsRequest request)
        {
            return base.Channel.getTrackShipmentDetails(request);
        }

        public TrackingServices.SkyChain.TrackServiceResponse getTrackShipmentDetails(TrackingServices.SkyChain.TrackServiceRequest trackShipmentServiceRequest)
        {
            TrackingServices.SkyChain.getTrackShipmentDetailsRequest inValue = new TrackingServices.SkyChain.getTrackShipmentDetailsRequest();
            inValue.trackShipmentServiceRequest = trackShipmentServiceRequest;
            TrackingServices.SkyChain.getTrackShipmentDetailsResponse retVal = ((TrackingServices.SkyChain.SkyChainEndpoint)(this)).getTrackShipmentDetails(inValue);
            return retVal.trackShipmentServiceResponse;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<TrackingServices.SkyChain.getTrackShipmentDetailsResponse> TrackingServices.SkyChain.SkyChainEndpoint.getTrackShipmentDetailsAsync(TrackingServices.SkyChain.getTrackShipmentDetailsRequest request)
        {
            return base.Channel.getTrackShipmentDetailsAsync(request);
        }

        public System.Threading.Tasks.Task<TrackingServices.SkyChain.getTrackShipmentDetailsResponse> getTrackShipmentDetailsAsync(TrackingServices.SkyChain.TrackServiceRequest trackShipmentServiceRequest)
        {
            TrackingServices.SkyChain.getTrackShipmentDetailsRequest inValue = new TrackingServices.SkyChain.getTrackShipmentDetailsRequest();
            inValue.trackShipmentServiceRequest = trackShipmentServiceRequest;
            return ((TrackingServices.SkyChain.SkyChainEndpoint)(this)).getTrackShipmentDetailsAsync(inValue);
        }
    }
}
