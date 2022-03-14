<?xml version="1.0" encoding="utf-8"?>
<wsdl:definitions xmlns:s="http://www.w3.org/2001/XMLSchema" xmlns:soap12="http://schemas.xmlsoap.org/wsdl/soap12/" xmlns:http="http://schemas.xmlsoap.org/wsdl/http/" xmlns:mime="http://schemas.xmlsoap.org/wsdl/mime/" xmlns:tns="https://gss.usps.com/usps-cpas/GSSAPI/" xmlns:s1="http://microsoft.com/wsdl/types/" xmlns:soap="http://schemas.xmlsoap.org/wsdl/soap/" xmlns:tm="http://microsoft.com/wsdl/mime/textMatching/" xmlns:soapenc="http://schemas.xmlsoap.org/soap/encoding/" targetNamespace="https://gss.usps.com/usps-cpas/GSSAPI/" xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">
  <wsdl:types>
    <s:schema elementFormDefault="qualified" targetNamespace="https://gss.usps.com/usps-cpas/GSSAPI/">
      <s:import namespace="http://microsoft.com/wsdl/types/" />
      <s:element name="RefreshWebComponent">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Val" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="RefreshWebComponentResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="1" maxOccurs="1" name="RefreshWebComponentResult" type="s:boolean" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="AuthenticateUser">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="UserID" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="Password" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="LocationID" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="WorkstationID" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="AuthenticateUserResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="AuthenticateUserResult" type="tns:AuthenticateResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="AuthenticateResult">
        <s:sequence>
          <s:element minOccurs="1" maxOccurs="1" name="ResponseCode" type="s:int" />
          <s:element minOccurs="0" maxOccurs="1" name="Message" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
        </s:sequence>
      </s:complexType>
      <s:element name="LoadAndRecordLabeledPackage">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="xmlDoc">
              <s:complexType mixed="true">
                <s:sequence>
                  <s:any />
                </s:sequence>
              </s:complexType>
            </s:element>
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="LoadAndRecordLabeledPackageResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="LoadAndRecordLabeledPackageResult">
              <s:complexType mixed="true">
                <s:sequence>
                  <s:any />
                </s:sequence>
              </s:complexType>
            </s:element>
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="DetermineIfPackageCanBeShipped">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="RateType" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="ServiceType" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="DestinationCountryCode" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="weight" type="s:decimal" />
            <s:element minOccurs="0" maxOccurs="1" name="WeightUnit" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="Length" type="s:int" />
            <s:element minOccurs="1" maxOccurs="1" name="Width" type="s:int" />
            <s:element minOccurs="1" maxOccurs="1" name="Height" type="s:int" />
            <s:element minOccurs="0" maxOccurs="1" name="UnitOfMeasurement" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="PackageValueInUSD" type="s:decimal" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="DetermineIfPackageCanBeShippedResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="DetermineIfPackageCanBeShippedResult" type="tns:CommonResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="CommonResult">
        <s:sequence>
          <s:element minOccurs="1" maxOccurs="1" name="ResponseCode" type="s:int" />
          <s:element minOccurs="0" maxOccurs="1" name="Message" type="s:string" />
        </s:sequence>
      </s:complexType>
      <s:element name="GetPackageLabels">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="PackageID" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="MailingAgentID" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="BoxNumber" type="s:int" />
            <s:element minOccurs="0" maxOccurs="1" name="FileFormat" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetPackageLabelsResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetPackageLabelsResult" type="tns:LabelResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="LabelResult">
        <s:sequence>
          <s:element minOccurs="1" maxOccurs="1" name="ResponseCode" type="s:int" />
          <s:element minOccurs="0" maxOccurs="1" name="Message" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="Label" type="tns:ArrayOfBase64Binary" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="ArrayOfBase64Binary">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="unbounded" name="base64Binary" nillable="true" type="s:base64Binary" />
        </s:sequence>
      </s:complexType>
      <s:element name="SearchForProcessedPackage">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="PackageID" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="OrderID" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="RecipientLastName" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="RecipientFirstName" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="RecipientBusinessName" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="RecipientCountryCode" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="SearchForProcessedPackageResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="SearchForProcessedPackageResult">
              <s:complexType mixed="true">
                <s:sequence>
                  <s:any />
                </s:sequence>
              </s:complexType>
            </s:element>
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="RegeneratePackageCustomsLabel">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="PackageID" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="MailingAgentID" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="BoxNumber" type="s:int" />
            <s:element minOccurs="0" maxOccurs="1" name="FileFormat" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="RegeneratePackageCustomsLabelResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="RegeneratePackageCustomsLabelResult" type="tns:LabelResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="LogoutUser">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="LogoutUserResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="LogoutUserResult" type="tns:CommonResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="CreatePMODReceptacleByFacilityTypeInCurrentShipment">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="FacilityType" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="FacilityZipCode" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="ReceptacleType" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="DateOfMailing" type="s:dateTime" />
            <s:element minOccurs="0" maxOccurs="1" name="FacilityName" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="CreatePMODReceptacleByFacilityTypeInCurrentShipmentResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="CreatePMODReceptacleByFacilityTypeInCurrentShipmentResult" type="tns:ReceptacleResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="ReceptacleResult">
        <s:sequence>
          <s:element minOccurs="1" maxOccurs="1" name="ResponseCode" type="s:int" />
          <s:element minOccurs="0" maxOccurs="1" name="Message" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="ReceptacleID" type="s:string" />
        </s:sequence>
      </s:complexType>
      <s:element name="CreatePMODReceptacleInCurrentShipment">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="ProductCode" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="pmodDDU" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="dduCity" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="dduState" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="ReceptacleType" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="DateOfMailing" type="s:dateTime" />
            <s:element minOccurs="0" maxOccurs="1" name="LocationID" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="UserID" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="WorkstationID" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="WeightInLbs" type="s:decimal" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="CreatePMODReceptacleInCurrentShipmentResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="CreatePMODReceptacleInCurrentShipmentResult" type="tns:ReceptacleResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="CreateNewReceptacleInCurrentShipment">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="ProductCode" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="ServiceCode" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="ReceptacleType" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="ForeignCountryCode" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="ForeignOECode" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="DateOfMailing" type="s:dateTime" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="CreateNewReceptacleInCurrentShipmentResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="CreateNewReceptacleInCurrentShipmentResult" type="tns:ReceptacleResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="CreateReceptacleInCurrentShipmentV2">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="ProductCode" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="ServiceCode" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="ReceptacleType" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="ForeignCountryCode" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="ForeignOECode" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="DateOfMailing" type="s:dateTime" />
            <s:element minOccurs="1" maxOccurs="1" name="PieceCount" type="s:int" />
            <s:element minOccurs="1" maxOccurs="1" name="WeightInLbs" type="s:decimal" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="CreateReceptacleInCurrentShipmentV2Response">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="CreateReceptacleInCurrentShipmentV2Result" type="tns:ReceptacleResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="CreateReceptacleForRateType">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="RateType" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="Dutiable" type="s:boolean" />
            <s:element minOccurs="0" maxOccurs="1" name="ReceptacleType" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="ForeignOECode" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="DateOfMailing" type="s:dateTime" />
            <s:element minOccurs="1" maxOccurs="1" name="PieceCount" type="s:int" />
            <s:element minOccurs="1" maxOccurs="1" name="WeightInLbs" type="s:decimal" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="CreateReceptacleForRateTypeResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="CreateReceptacleForRateTypeResult" type="tns:ReceptacleResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="CreateMixedReceptacleInCurrentShipment">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="RateType" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="RateGroup" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="PieceCount" type="s:int" />
            <s:element minOccurs="1" maxOccurs="1" name="WeightInLbs" type="s:decimal" />
            <s:element minOccurs="0" maxOccurs="1" name="PackageShape" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="CreateMixedReceptacleInCurrentShipmentResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="CreateMixedReceptacleInCurrentShipmentResult" type="tns:ReceptacleResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="CreateMixedReceptacleInCurrentShipmentV2">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="ProductCode" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="RateGroup" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="PieceCount" type="s:int" />
            <s:element minOccurs="1" maxOccurs="1" name="WeightInLbs" type="s:decimal" />
            <s:element minOccurs="0" maxOccurs="1" name="PackageShape" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="CreateMixedReceptacleInCurrentShipmentV2Response">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="CreateMixedReceptacleInCurrentShipmentV2Result" type="tns:ReceptacleResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="CreateMixedReceptacleForRateType">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="RateType" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="RateGroup" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="Dutiable" type="s:boolean" />
            <s:element minOccurs="0" maxOccurs="1" name="ReceptacleType" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="DateOfMailing" type="s:dateTime" />
            <s:element minOccurs="1" maxOccurs="1" name="PieceCount" type="s:int" />
            <s:element minOccurs="1" maxOccurs="1" name="WeightInLbs" type="s:decimal" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="CreateMixedReceptacleForRateTypeResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="CreateMixedReceptacleForRateTypeResult" type="tns:ReceptacleResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="CreateMixedReceptacleForRateTypeWithTareWeight">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="RateType" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="RateGroup" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="Dutiable" type="s:boolean" />
            <s:element minOccurs="0" maxOccurs="1" name="ReceptacleType" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="DateOfMailing" type="s:dateTime" />
            <s:element minOccurs="1" maxOccurs="1" name="PieceCount" type="s:int" />
            <s:element minOccurs="1" maxOccurs="1" name="WeightInLbs" type="s:decimal" />
            <s:element minOccurs="1" maxOccurs="1" name="TareWeight" type="s:decimal" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="CreateMixedReceptacleForRateTypeWithTareWeightResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="CreateMixedReceptacleForRateTypeWithTareWeightResult" type="tns:ReceptacleResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetReceptacleLabel">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="ReceptacleID" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="FileFormat" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetReceptacleLabelResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetReceptacleLabelResult" type="tns:LabelResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="AddReceptacleToCurrentShipment">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="ReceptacleID" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="AddReceptacleToCurrentShipmentResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="AddReceptacleToCurrentShipmentResult" type="tns:CommonResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="SetPPMODIReceptacleInCurrentShipment">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="ReceptacleID" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="PPMODIReceptacleID" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="SetPPMODIReceptacleInCurrentShipmentResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="SetPPMODIReceptacleInCurrentShipmentResult" type="tns:ReceptacleResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="CreatePassThroughReceptacleInCurrentShipment">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="ProductCode" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="ServiceCode" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="ReceptacleType" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="ForeignCountryCode" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="ForeignOECode" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="DateOfMailing" type="s:dateTime" />
            <s:element minOccurs="1" maxOccurs="1" name="PieceCount" type="s:int" />
            <s:element minOccurs="1" maxOccurs="1" name="WeightInLbs" type="s:decimal" />
            <s:element minOccurs="0" maxOccurs="1" name="ppmodISC" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="ReceptacleTypeName" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="CreatePassThroughReceptacleInCurrentShipmentResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="CreatePassThroughReceptacleInCurrentShipmentResult" type="tns:ReceptacleResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="AddReceptacleToCurrentShipmentV2">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="ReceptacleID" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="PieceCount" type="s:int" />
            <s:element minOccurs="1" maxOccurs="1" name="WeightInLbs" type="s:decimal" />
            <s:element minOccurs="0" maxOccurs="1" name="DestinationCountryCode" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="AddReceptacleToCurrentShipmentV2Response">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="AddReceptacleToCurrentShipmentV2Result" type="tns:AddReceptacleResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="AddReceptacleResult">
        <s:sequence>
          <s:element minOccurs="1" maxOccurs="1" name="ResponseCode" type="s:int" />
          <s:element minOccurs="0" maxOccurs="1" name="Message" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="DestinationCountryList" type="tns:ArrayOfString" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="ArrayOfString">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="unbounded" name="string" nillable="true" type="s:string" />
        </s:sequence>
      </s:complexType>
      <s:element name="RemovePackageFromDefaultShipment">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="USPSPackageTrackingID" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="RemovePackageFromDefaultShipmentResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="RemovePackageFromDefaultShipmentResult" type="tns:CommonResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="AddRemovedPackageToDefaultShipment">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="USPSPackageTrackingID" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="AddRemovedPackageToDefaultShipmentResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="AddRemovedPackageToDefaultShipmentResult" type="tns:CommonResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="RemoveReceptacleFromDefaultShipment">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="ReceptacleID" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="RemoveReceptacleFromDefaultShipmentResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="RemoveReceptacleFromDefaultShipmentResult" type="tns:CommonResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="MoveShipmentToOpenDispatch">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="ShipmentID" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="MoveShipmentToOpenDispatchResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="MoveShipmentToOpenDispatchResult" type="tns:CommonResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="MoveReceptacleToOpenDispatch">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="ReceptacleID" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="MoveReceptacleToOpenDispatchResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="MoveReceptacleToOpenDispatchResult" type="tns:CommonResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GenerateReportByPermitNumber">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="DispatchID" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="ReportName" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="RequestFormat" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="PermitNumber" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GenerateReportByPermitNumberResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GenerateReportByPermitNumberResult" type="tns:GenerateReportResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="GenerateReportResult">
        <s:sequence>
          <s:element minOccurs="1" maxOccurs="1" name="ResponseCode" type="s:int" />
          <s:element minOccurs="0" maxOccurs="1" name="Message" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="Report" type="s:base64Binary" />
        </s:sequence>
      </s:complexType>
      <s:element name="GetDispatchReport">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="DispatchID" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="ReportName" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="RequestFormat" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetDispatchReportResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetDispatchReportResult" type="tns:GenerateReportResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="RemoveReceptacleFromOpenDispatch">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="ReceptacleID" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="RemoveReceptacleFromOpenDispatchResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="RemoveReceptacleFromOpenDispatchResult" type="tns:CommonResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="RemovePackageFromOpenDispatch">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="USPSPackageTrackingID" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="RemovePackageFromOpenDispatchResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="RemovePackageFromOpenDispatchResult" type="tns:CommonResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="MovePackageToOpenDispatch">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="USPSPackageTrackingID" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="MovePackageToOpenDispatchResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="MovePackageToOpenDispatchResult" type="tns:CommonResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="MovePackagesToOpenDispatch">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="USPSPackageID" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="MovePackagesToOpenDispatchResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="MovePackagesToOpenDispatchResult" type="tns:CommonResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetCurrentShipment">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetCurrentShipmentResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetCurrentShipmentResult" type="tns:ShipmentDetailResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="ShipmentDetailResult">
        <s:sequence>
          <s:element minOccurs="1" maxOccurs="1" name="ResponseCode" type="s:int" />
          <s:element minOccurs="0" maxOccurs="1" name="ShipmentDetail" type="tns:ShipmentDetail" />
          <s:element minOccurs="0" maxOccurs="1" name="Message" type="s:string" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="ShipmentDetail">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="1" name="Package" type="tns:ArrayOfPackage" />
          <s:element minOccurs="0" maxOccurs="1" name="Receptacle" type="tns:ArrayOfReceptacle" />
          <s:element minOccurs="0" maxOccurs="1" name="Shipment" type="tns:Shipment" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="ArrayOfPackage">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="unbounded" name="Package" nillable="true" type="tns:Package" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="Package">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="1" name="PackageWeightUnit" type="s:string" />
          <s:element minOccurs="1" maxOccurs="1" name="PackageGUID" type="s1:guid" />
          <s:element minOccurs="0" maxOccurs="1" name="RecipientCountryCode" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="RecipientCountryName" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="USPSPackageID" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="MailerPackageID" type="s:string" />
          <s:element minOccurs="1" maxOccurs="1" name="PackageWeight" type="s:decimal" />
          <s:element minOccurs="0" maxOccurs="1" name="RecipientName" type="s:string" />
          <s:element minOccurs="1" maxOccurs="1" name="InshipmentQueue" type="s:boolean" />
          <s:element minOccurs="0" maxOccurs="1" name="ShipmentID" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="ReceptacleID" type="s:string" />
          <s:element minOccurs="1" maxOccurs="1" name="IsPackageBlocked" type="s:boolean" />
          <s:element minOccurs="0" maxOccurs="1" name="ForeignPortCode" type="s:string" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="ArrayOfReceptacle">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="unbounded" name="Receptacle" nillable="true" type="tns:Receptacle" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="Receptacle">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="1" name="ReceptacleID" type="s:string" />
          <s:element minOccurs="1" maxOccurs="1" name="InshipmentQueue" type="s:boolean" />
          <s:element minOccurs="0" maxOccurs="1" name="ShipmentID" type="s:string" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="Shipment">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="1" name="Status" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="ShipmentNote" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="ConsolidatorLocationName" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="ShipperLocationName" type="s:string" />
          <s:element minOccurs="1" maxOccurs="1" name="RemainingReceptacleCount" type="s:int" />
          <s:element minOccurs="1" maxOccurs="1" name="RemainingPackageCount" type="s:int" />
          <s:element minOccurs="0" maxOccurs="1" name="DestinationLocation" type="s:string" />
          <s:element minOccurs="1" maxOccurs="1" name="ReceptacleCount" type="s:int" />
          <s:element minOccurs="1" maxOccurs="1" name="PackageCount" type="s:int" />
          <s:element minOccurs="0" maxOccurs="1" name="ShipmentGUID" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="ShipmentID" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="Shipper" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="VehicleType" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="VehicleNumber" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="OriginLocationID" type="s:string" />
          <s:element minOccurs="1" maxOccurs="1" name="ClosedDateTime" type="s:dateTime" />
          <s:element minOccurs="1" maxOccurs="1" name="ArrivalDateTime" type="s:dateTime" />
          <s:element minOccurs="0" maxOccurs="1" name="ShipmentStateCode" type="s:string" />
        </s:sequence>
      </s:complexType>
      <s:element name="GetCurrentDispatch">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetCurrentDispatchResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetCurrentDispatchResult" type="tns:ShipmentDetailResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="CloseDispatch">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="VehicleNum" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="VehicleType" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="DepDateTime" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="ArrDateTime" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="CloseDispatchResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="CloseDispatchResult" type="tns:CloseDispatchResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="CloseDispatchResult">
        <s:sequence>
          <s:element minOccurs="1" maxOccurs="1" name="ResponseCode" type="s:int" />
          <s:element minOccurs="0" maxOccurs="1" name="Message" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="DispatchID" type="s:string" />
          <s:element minOccurs="1" maxOccurs="1" name="PackageCount" type="s:int" />
        </s:sequence>
      </s:complexType>
      <s:element name="GetShipmentQueue">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetShipmentQueueResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetShipmentQueueResult" type="tns:ShipmentQueueResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="ShipmentQueueResult">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="1" name="ShipmentQueue" type="tns:ShipmentQueue" />
          <s:element minOccurs="0" maxOccurs="1" name="Message" type="s:string" />
          <s:element minOccurs="1" maxOccurs="1" name="ResponseCode" type="s:int" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="ShipmentQueue">
        <s:sequence>
          <s:element minOccurs="1" maxOccurs="1" name="ShipmentReceivedByDate" type="s:dateTime" />
          <s:element minOccurs="0" maxOccurs="1" name="Shipment" type="tns:ArrayOfShipment" />
          <s:element minOccurs="0" maxOccurs="1" name="DefaultOpenShipment" type="tns:ShipmentDetail" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="ArrayOfShipment">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="unbounded" name="Shipment" nillable="true" type="tns:Shipment" />
        </s:sequence>
      </s:complexType>
      <s:element name="GetShipmentReport">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="ShipmentID" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="ReportName" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="RequestFormat" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetShipmentReportResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetShipmentReportResult" type="tns:GenerateReportResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetShipmentDetails">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="ShipmentID" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetShipmentDetailsResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetShipmentDetailsResult" type="tns:ShipmentDetailResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetClosedDispatchesList">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="StartDate" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="EndDate" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetClosedDispatchesListResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetClosedDispatchesListResult">
              <s:complexType mixed="true">
                <s:sequence>
                  <s:any />
                </s:sequence>
              </s:complexType>
            </s:element>
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="LoadPackageData">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="xmlDoc">
              <s:complexType mixed="true">
                <s:sequence>
                  <s:any />
                </s:sequence>
              </s:complexType>
            </s:element>
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="LoadPackageDataResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="LoadPackageDataResult">
              <s:complexType mixed="true">
                <s:sequence>
                  <s:any />
                </s:sequence>
              </s:complexType>
            </s:element>
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="VerifyGXGPackage">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="PackageID" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="MailingAgentID" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="BoxNumber" type="s:int" />
            <s:element minOccurs="0" maxOccurs="1" name="GXGRequest">
              <s:complexType mixed="true">
                <s:sequence>
                  <s:any />
                </s:sequence>
              </s:complexType>
            </s:element>
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="VerifyGXGPackageResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="VerifyGXGPackageResult">
              <s:complexType mixed="true">
                <s:sequence>
                  <s:any />
                </s:sequence>
              </s:complexType>
            </s:element>
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="VerifyGXGPackageToDestinationLocation">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="PackageID" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="MailingAgentID" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="BoxNumber" type="s:int" />
            <s:element minOccurs="0" maxOccurs="1" name="DestinationLocationID" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="GXGRequest">
              <s:complexType mixed="true">
                <s:sequence>
                  <s:any />
                </s:sequence>
              </s:complexType>
            </s:element>
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="VerifyGXGPackageToDestinationLocationResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="VerifyGXGPackageToDestinationLocationResult">
              <s:complexType mixed="true">
                <s:sequence>
                  <s:any />
                </s:sequence>
              </s:complexType>
            </s:element>
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetGXGCommodityInfo">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetGXGCommodityInfoResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetGXGCommodityInfoResult" type="tns:GXGCommodityInfoResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="GXGCommodityInfoResult">
        <s:sequence>
          <s:element minOccurs="1" maxOccurs="1" name="ResponseCode" type="s:int" />
          <s:element minOccurs="0" maxOccurs="1" name="Message" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="CommodityNames" type="tns:ArrayOfString" />
          <s:element minOccurs="0" maxOccurs="1" name="CommodityEffectiveDate" type="s:string" />
        </s:sequence>
      </s:complexType>
      <s:element name="LabelGXGPackage">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="PackageID" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="MailingAgentID" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="BoxNumber" type="s:int" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="LabelGXGPackageResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="LabelGXGPackageResult" type="tns:CommonResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="LabelGXGPackageToDestinationLocation">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="PackageID" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="MailingAgentID" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="BoxNumber" type="s:int" />
            <s:element minOccurs="0" maxOccurs="1" name="DestinationLocationID" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="LabelGXGPackageToDestinationLocationResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="LabelGXGPackageToDestinationLocationResult" type="tns:CommonResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetAvailableReportsForDispatch">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="DispatchID" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetAvailableReportsForDispatchResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetAvailableReportsForDispatchResult" type="tns:GetAvailableReportResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="GetAvailableReportResult">
        <s:sequence>
          <s:element minOccurs="1" maxOccurs="1" name="ResponseCode" type="s:int" />
          <s:element minOccurs="0" maxOccurs="1" name="Message" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="Report" type="tns:ArrayOfString" />
        </s:sequence>
      </s:complexType>
      <s:element name="GetRequiredReportsForDispatch">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="DispatchID" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetRequiredReportsForDispatchResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetRequiredReportsForDispatchResult" type="tns:GetAvailableReportResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetDestinationLocations">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetDestinationLocationsResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetDestinationLocationsResult" type="tns:DestinationLocationsResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="DestinationLocationsResult">
        <s:sequence>
          <s:element minOccurs="1" maxOccurs="1" name="ResponseCode" type="s:int" />
          <s:element minOccurs="0" maxOccurs="1" name="Message" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="DestinationLoc" type="tns:ArrayOfString" />
        </s:sequence>
      </s:complexType>
      <s:element name="GetExpectedShipDate">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="DestinationLocationID" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetExpectedShipDateResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetExpectedShipDateResult" type="tns:ExpectedShipResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="ExpectedShipResult">
        <s:sequence>
          <s:element minOccurs="1" maxOccurs="1" name="ResponseCode" type="s:int" />
          <s:element minOccurs="0" maxOccurs="1" name="Message" type="s:string" />
          <s:element minOccurs="1" maxOccurs="1" name="ReadOnly" type="s:boolean" />
          <s:element minOccurs="0" maxOccurs="1" name="ExpectedShipDate" type="s:string" />
        </s:sequence>
      </s:complexType>
      <s:element name="SetExpectedShipDate">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="DestinationLocationID" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="ExpectedShipDate" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="SetExpectedShipDateResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="SetExpectedShipDateResult" type="tns:CommonResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="AddPackageInReceptacle">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="USPSPackageTrackingID" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="ReceptacleID" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="AddPackageInReceptacleResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="AddPackageInReceptacleResult" type="tns:CommonResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="AddPackagesToReceptacle">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="USPSPackageID" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="ReceptacleID" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="AddPackagesToReceptacleResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="AddPackagesToReceptacleResult" type="tns:CommonResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="RemovePackageFromReceptacle">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="USPSPackageTrackingID" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="ReceptacleID" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="RemovePackageFromReceptacleResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="RemovePackageFromReceptacleResult" type="tns:CommonResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetOpenReceptacles">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="AvailableForPackagesOnly" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetOpenReceptaclesResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetOpenReceptaclesResult" type="tns:OpenReceptaclesResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="OpenReceptaclesResult">
        <s:sequence>
          <s:element minOccurs="1" maxOccurs="1" name="ResponseCode" type="s:int" />
          <s:element minOccurs="0" maxOccurs="1" name="OpenReceptacleList" type="tns:ArrayOfOpenReceptacle" />
          <s:element minOccurs="0" maxOccurs="1" name="Message" type="s:string" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="ArrayOfOpenReceptacle">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="unbounded" name="OpenReceptacle" nillable="true" type="tns:OpenReceptacle" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="OpenReceptacle">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="1" name="AgentName" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="ReceptacleID" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="RateType" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="RateGroup" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="ReceptacleCategory" type="s:string" />
          <s:element minOccurs="1" maxOccurs="1" name="InShipmentQueue" type="s:boolean" />
          <s:element minOccurs="0" maxOccurs="1" name="ShipmentID" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="OriginLocationID" type="s:string" />
          <s:element minOccurs="1" maxOccurs="1" name="PieceCount" type="s:int" />
          <s:element minOccurs="1" maxOccurs="1" name="WeightInLbs" type="s:decimal" />
          <s:element minOccurs="0" maxOccurs="1" name="DestinationCountryCode" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="DestinationCountryName" type="s:string" />
          <s:element minOccurs="1" maxOccurs="1" name="CanMoveToDispatch" type="s:boolean" />
          <s:element minOccurs="0" maxOccurs="1" name="RateZone" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="ParentReceptacleGUID" type="s:string" />
          <s:element minOccurs="1" maxOccurs="1" name="PassThrough" type="s:boolean" />
          <s:element minOccurs="0" maxOccurs="1" name="RateTypeDisplayAbbreviation" type="s:string" />
        </s:sequence>
      </s:complexType>
      <s:element name="TrackPackageWithPostalCode">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="PackageID" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="MailingAgentID" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="BoxNumber" type="s:int" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="TrackPackageWithPostalCodeResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="TrackPackageWithPostalCodeResult" type="tns:TrackingWithPostalCodeResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="TrackingWithPostalCodeResult">
        <s:sequence>
          <s:element minOccurs="1" maxOccurs="1" name="ResponseCode" type="s:int" />
          <s:element minOccurs="0" maxOccurs="1" name="Message" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="TrackingId" type="tns:ArrayOfString" />
          <s:element minOccurs="0" maxOccurs="1" name="TrackingEventWithPostalCode" type="tns:ArrayOfTrackingEventWithPostalCode" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="ArrayOfTrackingEventWithPostalCode">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="unbounded" name="TrackingEventWithPostalCode" nillable="true" type="tns:TrackingEventWithPostalCode" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="TrackingEventWithPostalCode">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="1" name="TrackingCode" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="Description" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="DetailInfo" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="EventDate" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="TimeZone" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="EventPostalCode" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="EventLocationName" type="s:string" />
        </s:sequence>
      </s:complexType>
      <s:element name="TrackPackage">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="PackageID" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="MailingAgentID" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="BoxNumber" type="s:int" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="TrackPackageResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="TrackPackageResult" type="tns:TrackResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="TrackResult">
        <s:sequence>
          <s:element minOccurs="1" maxOccurs="1" name="ResponseCode" type="s:int" />
          <s:element minOccurs="0" maxOccurs="1" name="Message" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="TrackingId" type="tns:ArrayOfString" />
          <s:element minOccurs="0" maxOccurs="1" name="TrackingEvent" type="tns:ArrayOfTrackingEvent" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="ArrayOfTrackingEvent">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="unbounded" name="TrackingEvent" nillable="true" type="tns:TrackingEvent" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="TrackingEvent">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="1" name="TrackingCode" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="Description" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="Location" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="DetailInfo" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="EventDate" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="TimeZone" type="s:string" />
        </s:sequence>
      </s:complexType>
      <s:element name="RetrieveTrackingEventsSinceDate">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="sinceDate" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="RetrieveTrackingEventsSinceDateResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="RetrieveTrackingEventsSinceDateResult">
              <s:complexType mixed="true">
                <s:sequence>
                  <s:any />
                </s:sequence>
              </s:complexType>
            </s:element>
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="RetrieveReceptacleTrackingEventsSinceDate">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="sinceDate" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="RetrieveReceptacleTrackingEventsSinceDateResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="RetrieveReceptacleTrackingEventsSinceDateResult">
              <s:complexType mixed="true">
                <s:sequence>
                  <s:any />
                </s:sequence>
              </s:complexType>
            </s:element>
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="CreatePassThroughReceptacleForRateType">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="RateType" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="Dutiable" type="s:boolean" />
            <s:element minOccurs="0" maxOccurs="1" name="ReceptacleType" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="ForeignOECode" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="CountryCode" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="DateOfMailing" type="s:dateTime" />
            <s:element minOccurs="1" maxOccurs="1" name="PieceCount" type="s:int" />
            <s:element minOccurs="1" maxOccurs="1" name="WeightInLbs" type="s:decimal" />
            <s:element minOccurs="0" maxOccurs="1" name="ppmodISC" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="CreatePassThroughReceptacleForRateTypeResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="CreatePassThroughReceptacleForRateTypeResult" type="tns:ReceptacleResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="CreateReceptacleForRateTypeToDestination">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="RateType" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="Dutiable" type="s:boolean" />
            <s:element minOccurs="0" maxOccurs="1" name="ReceptacleType" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="ForeignOECode" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="CountryCode" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="DateOfMailing" type="s:dateTime" />
            <s:element minOccurs="1" maxOccurs="1" name="PieceCount" type="s:int" />
            <s:element minOccurs="1" maxOccurs="1" name="WeightInLbs" type="s:decimal" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="CreateReceptacleForRateTypeToDestinationResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="CreateReceptacleForRateTypeToDestinationResult" type="tns:ReceptacleResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="CreateReceptacleForRateTypeToDestinationWithTareWeight">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="RateType" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="Dutiable" type="s:boolean" />
            <s:element minOccurs="0" maxOccurs="1" name="ReceptacleType" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="ForeignOECode" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="CountryCode" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="DateOfMailing" type="s:dateTime" />
            <s:element minOccurs="1" maxOccurs="1" name="PieceCount" type="s:int" />
            <s:element minOccurs="1" maxOccurs="1" name="WeightInLbs" type="s:decimal" />
            <s:element minOccurs="1" maxOccurs="1" name="TareWeight" type="s:decimal" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="CreateReceptacleForRateTypeToDestinationWithTareWeightResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="CreateReceptacleForRateTypeToDestinationWithTareWeightResult" type="tns:ReceptacleResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="USPSPartnerPackageProcessing">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="USPSPackageID" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="DestinationLocationID" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="xmlDoc">
              <s:complexType mixed="true">
                <s:sequence>
                  <s:any />
                </s:sequence>
              </s:complexType>
            </s:element>
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="USPSPartnerPackageProcessingResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="USPSPartnerPackageProcessingResult" type="tns:CommonResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetZPLLabelsForPackage">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="PackageID" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="MailingAgentID" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="BoxNumber" type="s:int" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetZPLLabelsForPackageResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetZPLLabelsForPackageResult" type="tns:LabelResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetCurrentShipmentByRange">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="StartRowNumber" type="s:int" />
            <s:element minOccurs="1" maxOccurs="1" name="EndRowNumber" type="s:int" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetCurrentShipmentByRangeResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetCurrentShipmentByRangeResult" type="tns:ShipmentDetailResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetPortCodeListForRateTypeAndDestination">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="RateType" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="CountryCode" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetPortCodeListForRateTypeAndDestinationResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetPortCodeListForRateTypeAndDestinationResult" type="tns:CommonResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="CalculatePostage">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="xmlDoc">
              <s:complexType mixed="true">
                <s:sequence>
                  <s:any />
                </s:sequence>
              </s:complexType>
            </s:element>
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="CalculatePostageResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="CalculatePostageResult" type="tns:CalculatePostageResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="CalculatePostageResult">
        <s:sequence>
          <s:element minOccurs="1" maxOccurs="1" name="ResponseCode" type="s:int" />
          <s:element minOccurs="0" maxOccurs="1" name="Message" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="CurrencyCode" type="s:string" />
          <s:element minOccurs="1" maxOccurs="1" name="ExtraServiceCodeFee" type="s:decimal" />
          <s:element minOccurs="1" maxOccurs="1" name="CalculatedPostage" type="s:decimal" />
          <s:element minOccurs="0" maxOccurs="1" name="DestinationLocationName" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="DestinationLocationID" type="s:string" />
        </s:sequence>
      </s:complexType>
      <s:element name="CalculatePotentialPostage">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="xmlDoc">
              <s:complexType mixed="true">
                <s:sequence>
                  <s:any />
                </s:sequence>
              </s:complexType>
            </s:element>
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="CalculatePotentialPostageResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="CalculatePotentialPostageResult">
              <s:complexType mixed="true">
                <s:sequence>
                  <s:any />
                </s:sequence>
              </s:complexType>
            </s:element>
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetAvailableCustomInsuredAmountList">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="RateType" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="ServiceType" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetAvailableCustomInsuredAmountListResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetAvailableCustomInsuredAmountListResult" type="tns:CommonResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="UploadPackageFile">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="fileData" type="s:base64Binary" />
            <s:element minOccurs="0" maxOccurs="1" name="fileName" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="UploadPackageFileResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="UploadPackageFileResult" type="tns:CommonResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="UpdatePackageWeight">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="PackageID" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="Weight" type="s:decimal" />
            <s:element minOccurs="0" maxOccurs="1" name="WeightUnit" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="UpdatePackageWeightResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="UpdatePackageWeightResult" type="tns:CommonResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="UpdateDomesticPackageWeight">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="USPSPackageID" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="Weight" type="s:decimal" />
            <s:element minOccurs="0" maxOccurs="1" name="WeightUnit" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="UpdateDomesticPackageWeightResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="UpdateDomesticPackageWeightResult" type="tns:CommonResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="ReopenDispatch">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="DispatchID" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="ReopenDispatchResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="ReopenDispatchResult" type="tns:CommonResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="ValidateAddress">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="RecipientAddressLine1" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="RecipientAddressLine2" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="RecipientCity" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="RecipientState" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="RecipientPostalCode" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="RecipientCountryCode" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="ValidateAddressResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="ValidateAddressResult">
              <s:complexType mixed="true">
                <s:sequence>
                  <s:any />
                </s:sequence>
              </s:complexType>
            </s:element>
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="LookupForeignPortCodeForPackage">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="packageId" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="LookupForeignPortCodeForPackageResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="LookupForeignPortCodeForPackageResult" type="tns:ForeignPortResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="ForeignPortResult">
        <s:sequence>
          <s:element minOccurs="1" maxOccurs="1" name="ResponseCode" type="s:int" />
          <s:element minOccurs="0" maxOccurs="1" name="Message" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="ForeignPortsAndRecTypeList" type="tns:ArrayOfForeignPortAndRecType" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="ArrayOfForeignPortAndRecType">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="unbounded" name="ForeignPortAndRecType" nillable="true" type="tns:ForeignPortAndRecType" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="ForeignPortAndRecType">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="1" name="ReceptacleType" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="ForeignPort" type="s:string" />
        </s:sequence>
      </s:complexType>
      <s:element name="LoadShippingPartnerEvent">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="PackageID" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="EventCode" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="EventDate" type="s:dateTime" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="LoadShippingPartnerEventResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="LoadShippingPartnerEventResult" type="tns:CommonResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetReceptacleDetails">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="ReceptacleID" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetReceptacleDetailsResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetReceptacleDetailsResult" type="tns:ReceptacleDetailResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="ReceptacleDetailResult">
        <s:sequence>
          <s:element minOccurs="1" maxOccurs="1" name="ResponseCode" type="s:int" />
          <s:element minOccurs="0" maxOccurs="1" name="Message" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="ReceptacleDetail" type="tns:ReceptacleDetail" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="ReceptacleDetail">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="1" name="ReceptacleID" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="RateType" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="ForeignPortCode" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="DestinationCountryCode" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="DestinationCountryName" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="Status" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="DispatchID" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="Packages" type="tns:ArrayOfReceptaclePackage" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="ArrayOfReceptaclePackage">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="unbounded" name="Package" nillable="true" type="tns:ReceptaclePackage" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="ReceptaclePackage">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="1" name="USPSPackageID" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="MailerPackageID" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="PackageWeight" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="RecipientName" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="RecipientCountryCode" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="RecipientCountryName" type="s:string" />
          <s:element minOccurs="1" maxOccurs="1" name="InshipmentQueue" type="s:boolean" />
          <s:element minOccurs="0" maxOccurs="1" name="ShipmentID" type="s:string" />
          <s:element minOccurs="1" maxOccurs="1" name="IsPackageBlocked" type="s:boolean" />
        </s:sequence>
      </s:complexType>
      <s:element name="GetSystemStatusMessage">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetSystemStatusMessageResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetSystemStatusMessageResult">
              <s:complexType mixed="true">
                <s:sequence>
                  <s:any />
                </s:sequence>
              </s:complexType>
            </s:element>
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="RemovePackageFromClosedShipment">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="USPSPackageTrackingID" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="RemovePackageFromClosedShipmentResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="RemovePackageFromClosedShipmentResult" type="tns:CommonResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="LoadAndRecordLabeledPackageAndPrintLabel">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="xmlDoc">
              <s:complexType mixed="true">
                <s:sequence>
                  <s:any />
                </s:sequence>
              </s:complexType>
            </s:element>
            <s:element minOccurs="0" maxOccurs="1" name="FileFormat" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="AccessToken" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="LoadAndRecordLabeledPackageAndPrintLabelResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="LoadAndRecordLabeledPackageAndPrintLabelResult" type="tns:LabelResult" />
          </s:sequence>
        </s:complexType>
      </s:element>
    </s:schema>
    <s:schema elementFormDefault="qualified" targetNamespace="http://microsoft.com/wsdl/types/">
      <s:simpleType name="guid">
        <s:restriction base="s:string">
          <s:pattern value="[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}" />
        </s:restriction>
      </s:simpleType>
    </s:schema>
  </wsdl:types>
  <wsdl:message name="RefreshWebComponentSoapIn">
    <wsdl:part name="parameters" element="tns:RefreshWebComponent" />
  </wsdl:message>
  <wsdl:message name="RefreshWebComponentSoapOut">
    <wsdl:part name="parameters" element="tns:RefreshWebComponentResponse" />
  </wsdl:message>
  <wsdl:message name="AuthenticateUserSoapIn">
    <wsdl:part name="parameters" element="tns:AuthenticateUser" />
  </wsdl:message>
  <wsdl:message name="AuthenticateUserSoapOut">
    <wsdl:part name="parameters" element="tns:AuthenticateUserResponse" />
  </wsdl:message>
  <wsdl:message name="LoadAndRecordLabeledPackageSoapIn">
    <wsdl:part name="parameters" element="tns:LoadAndRecordLabeledPackage" />
  </wsdl:message>
  <wsdl:message name="LoadAndRecordLabeledPackageSoapOut">
    <wsdl:part name="parameters" element="tns:LoadAndRecordLabeledPackageResponse" />
  </wsdl:message>
  <wsdl:message name="DetermineIfPackageCanBeShippedSoapIn">
    <wsdl:part name="parameters" element="tns:DetermineIfPackageCanBeShipped" />
  </wsdl:message>
  <wsdl:message name="DetermineIfPackageCanBeShippedSoapOut">
    <wsdl:part name="parameters" element="tns:DetermineIfPackageCanBeShippedResponse" />
  </wsdl:message>
  <wsdl:message name="GetPackageLabelsSoapIn">
    <wsdl:part name="parameters" element="tns:GetPackageLabels" />
  </wsdl:message>
  <wsdl:message name="GetPackageLabelsSoapOut">
    <wsdl:part name="parameters" element="tns:GetPackageLabelsResponse" />
  </wsdl:message>
  <wsdl:message name="SearchForProcessedPackageSoapIn">
    <wsdl:part name="parameters" element="tns:SearchForProcessedPackage" />
  </wsdl:message>
  <wsdl:message name="SearchForProcessedPackageSoapOut">
    <wsdl:part name="parameters" element="tns:SearchForProcessedPackageResponse" />
  </wsdl:message>
  <wsdl:message name="RegeneratePackageCustomsLabelSoapIn">
    <wsdl:part name="parameters" element="tns:RegeneratePackageCustomsLabel" />
  </wsdl:message>
  <wsdl:message name="RegeneratePackageCustomsLabelSoapOut">
    <wsdl:part name="parameters" element="tns:RegeneratePackageCustomsLabelResponse" />
  </wsdl:message>
  <wsdl:message name="LogoutUserSoapIn">
    <wsdl:part name="parameters" element="tns:LogoutUser" />
  </wsdl:message>
  <wsdl:message name="LogoutUserSoapOut">
    <wsdl:part name="parameters" element="tns:LogoutUserResponse" />
  </wsdl:message>
  <wsdl:message name="CreatePMODReceptacleByFacilityTypeInCurrentShipmentSoapIn">
    <wsdl:part name="parameters" element="tns:CreatePMODReceptacleByFacilityTypeInCurrentShipment" />
  </wsdl:message>
  <wsdl:message name="CreatePMODReceptacleByFacilityTypeInCurrentShipmentSoapOut">
    <wsdl:part name="parameters" element="tns:CreatePMODReceptacleByFacilityTypeInCurrentShipmentResponse" />
  </wsdl:message>
  <wsdl:message name="CreatePMODReceptacleInCurrentShipmentSoapIn">
    <wsdl:part name="parameters" element="tns:CreatePMODReceptacleInCurrentShipment" />
  </wsdl:message>
  <wsdl:message name="CreatePMODReceptacleInCurrentShipmentSoapOut">
    <wsdl:part name="parameters" element="tns:CreatePMODReceptacleInCurrentShipmentResponse" />
  </wsdl:message>
  <wsdl:message name="CreateNewReceptacleInCurrentShipmentSoapIn">
    <wsdl:part name="parameters" element="tns:CreateNewReceptacleInCurrentShipment" />
  </wsdl:message>
  <wsdl:message name="CreateNewReceptacleInCurrentShipmentSoapOut">
    <wsdl:part name="parameters" element="tns:CreateNewReceptacleInCurrentShipmentResponse" />
  </wsdl:message>
  <wsdl:message name="CreateReceptacleInCurrentShipmentV2SoapIn">
    <wsdl:part name="parameters" element="tns:CreateReceptacleInCurrentShipmentV2" />
  </wsdl:message>
  <wsdl:message name="CreateReceptacleInCurrentShipmentV2SoapOut">
    <wsdl:part name="parameters" element="tns:CreateReceptacleInCurrentShipmentV2Response" />
  </wsdl:message>
  <wsdl:message name="CreateReceptacleForRateTypeSoapIn">
    <wsdl:part name="parameters" element="tns:CreateReceptacleForRateType" />
  </wsdl:message>
  <wsdl:message name="CreateReceptacleForRateTypeSoapOut">
    <wsdl:part name="parameters" element="tns:CreateReceptacleForRateTypeResponse" />
  </wsdl:message>
  <wsdl:message name="CreateMixedReceptacleInCurrentShipmentSoapIn">
    <wsdl:part name="parameters" element="tns:CreateMixedReceptacleInCurrentShipment" />
  </wsdl:message>
  <wsdl:message name="CreateMixedReceptacleInCurrentShipmentSoapOut">
    <wsdl:part name="parameters" element="tns:CreateMixedReceptacleInCurrentShipmentResponse" />
  </wsdl:message>
  <wsdl:message name="CreateMixedReceptacleInCurrentShipmentV2SoapIn">
    <wsdl:part name="parameters" element="tns:CreateMixedReceptacleInCurrentShipmentV2" />
  </wsdl:message>
  <wsdl:message name="CreateMixedReceptacleInCurrentShipmentV2SoapOut">
    <wsdl:part name="parameters" element="tns:CreateMixedReceptacleInCurrentShipmentV2Response" />
  </wsdl:message>
  <wsdl:message name="CreateMixedReceptacleForRateTypeSoapIn">
    <wsdl:part name="parameters" element="tns:CreateMixedReceptacleForRateType" />
  </wsdl:message>
  <wsdl:message name="CreateMixedReceptacleForRateTypeSoapOut">
    <wsdl:part name="parameters" element="tns:CreateMixedReceptacleForRateTypeResponse" />
  </wsdl:message>
  <wsdl:message name="CreateMixedReceptacleForRateTypeWithTareWeightSoapIn">
    <wsdl:part name="parameters" element="tns:CreateMixedReceptacleForRateTypeWithTareWeight" />
  </wsdl:message>
  <wsdl:message name="CreateMixedReceptacleForRateTypeWithTareWeightSoapOut">
    <wsdl:part name="parameters" element="tns:CreateMixedReceptacleForRateTypeWithTareWeightResponse" />
  </wsdl:message>
  <wsdl:message name="GetReceptacleLabelSoapIn">
    <wsdl:part name="parameters" element="tns:GetReceptacleLabel" />
  </wsdl:message>
  <wsdl:message name="GetReceptacleLabelSoapOut">
    <wsdl:part name="parameters" element="tns:GetReceptacleLabelResponse" />
  </wsdl:message>
  <wsdl:message name="AddReceptacleToCurrentShipmentSoapIn">
    <wsdl:part name="parameters" element="tns:AddReceptacleToCurrentShipment" />
  </wsdl:message>
  <wsdl:message name="AddReceptacleToCurrentShipmentSoapOut">
    <wsdl:part name="parameters" element="tns:AddReceptacleToCurrentShipmentResponse" />
  </wsdl:message>
  <wsdl:message name="SetPPMODIReceptacleInCurrentShipmentSoapIn">
    <wsdl:part name="parameters" element="tns:SetPPMODIReceptacleInCurrentShipment" />
  </wsdl:message>
  <wsdl:message name="SetPPMODIReceptacleInCurrentShipmentSoapOut">
    <wsdl:part name="parameters" element="tns:SetPPMODIReceptacleInCurrentShipmentResponse" />
  </wsdl:message>
  <wsdl:message name="CreatePassThroughReceptacleInCurrentShipmentSoapIn">
    <wsdl:part name="parameters" element="tns:CreatePassThroughReceptacleInCurrentShipment" />
  </wsdl:message>
  <wsdl:message name="CreatePassThroughReceptacleInCurrentShipmentSoapOut">
    <wsdl:part name="parameters" element="tns:CreatePassThroughReceptacleInCurrentShipmentResponse" />
  </wsdl:message>
  <wsdl:message name="AddReceptacleToCurrentShipmentV2SoapIn">
    <wsdl:part name="parameters" element="tns:AddReceptacleToCurrentShipmentV2" />
  </wsdl:message>
  <wsdl:message name="AddReceptacleToCurrentShipmentV2SoapOut">
    <wsdl:part name="parameters" element="tns:AddReceptacleToCurrentShipmentV2Response" />
  </wsdl:message>
  <wsdl:message name="RemovePackageFromDefaultShipmentSoapIn">
    <wsdl:part name="parameters" element="tns:RemovePackageFromDefaultShipment" />
  </wsdl:message>
  <wsdl:message name="RemovePackageFromDefaultShipmentSoapOut">
    <wsdl:part name="parameters" element="tns:RemovePackageFromDefaultShipmentResponse" />
  </wsdl:message>
  <wsdl:message name="AddRemovedPackageToDefaultShipmentSoapIn">
    <wsdl:part name="parameters" element="tns:AddRemovedPackageToDefaultShipment" />
  </wsdl:message>
  <wsdl:message name="AddRemovedPackageToDefaultShipmentSoapOut">
    <wsdl:part name="parameters" element="tns:AddRemovedPackageToDefaultShipmentResponse" />
  </wsdl:message>
  <wsdl:message name="RemoveReceptacleFromDefaultShipmentSoapIn">
    <wsdl:part name="parameters" element="tns:RemoveReceptacleFromDefaultShipment" />
  </wsdl:message>
  <wsdl:message name="RemoveReceptacleFromDefaultShipmentSoapOut">
    <wsdl:part name="parameters" element="tns:RemoveReceptacleFromDefaultShipmentResponse" />
  </wsdl:message>
  <wsdl:message name="MoveShipmentToOpenDispatchSoapIn">
    <wsdl:part name="parameters" element="tns:MoveShipmentToOpenDispatch" />
  </wsdl:message>
  <wsdl:message name="MoveShipmentToOpenDispatchSoapOut">
    <wsdl:part name="parameters" element="tns:MoveShipmentToOpenDispatchResponse" />
  </wsdl:message>
  <wsdl:message name="MoveReceptacleToOpenDispatchSoapIn">
    <wsdl:part name="parameters" element="tns:MoveReceptacleToOpenDispatch" />
  </wsdl:message>
  <wsdl:message name="MoveReceptacleToOpenDispatchSoapOut">
    <wsdl:part name="parameters" element="tns:MoveReceptacleToOpenDispatchResponse" />
  </wsdl:message>
  <wsdl:message name="GenerateReportByPermitNumberSoapIn">
    <wsdl:part name="parameters" element="tns:GenerateReportByPermitNumber" />
  </wsdl:message>
  <wsdl:message name="GenerateReportByPermitNumberSoapOut">
    <wsdl:part name="parameters" element="tns:GenerateReportByPermitNumberResponse" />
  </wsdl:message>
  <wsdl:message name="GetDispatchReportSoapIn">
    <wsdl:part name="parameters" element="tns:GetDispatchReport" />
  </wsdl:message>
  <wsdl:message name="GetDispatchReportSoapOut">
    <wsdl:part name="parameters" element="tns:GetDispatchReportResponse" />
  </wsdl:message>
  <wsdl:message name="RemoveReceptacleFromOpenDispatchSoapIn">
    <wsdl:part name="parameters" element="tns:RemoveReceptacleFromOpenDispatch" />
  </wsdl:message>
  <wsdl:message name="RemoveReceptacleFromOpenDispatchSoapOut">
    <wsdl:part name="parameters" element="tns:RemoveReceptacleFromOpenDispatchResponse" />
  </wsdl:message>
  <wsdl:message name="RemovePackageFromOpenDispatchSoapIn">
    <wsdl:part name="parameters" element="tns:RemovePackageFromOpenDispatch" />
  </wsdl:message>
  <wsdl:message name="RemovePackageFromOpenDispatchSoapOut">
    <wsdl:part name="parameters" element="tns:RemovePackageFromOpenDispatchResponse" />
  </wsdl:message>
  <wsdl:message name="MovePackageToOpenDispatchSoapIn">
    <wsdl:part name="parameters" element="tns:MovePackageToOpenDispatch" />
  </wsdl:message>
  <wsdl:message name="MovePackageToOpenDispatchSoapOut">
    <wsdl:part name="parameters" element="tns:MovePackageToOpenDispatchResponse" />
  </wsdl:message>
  <wsdl:message name="MovePackagesToOpenDispatchSoapIn">
    <wsdl:part name="parameters" element="tns:MovePackagesToOpenDispatch" />
  </wsdl:message>
  <wsdl:message name="MovePackagesToOpenDispatchSoapOut">
    <wsdl:part name="parameters" element="tns:MovePackagesToOpenDispatchResponse" />
  </wsdl:message>
  <wsdl:message name="GetCurrentShipmentSoapIn">
    <wsdl:part name="parameters" element="tns:GetCurrentShipment" />
  </wsdl:message>
  <wsdl:message name="GetCurrentShipmentSoapOut">
    <wsdl:part name="parameters" element="tns:GetCurrentShipmentResponse" />
  </wsdl:message>
  <wsdl:message name="GetCurrentDispatchSoapIn">
    <wsdl:part name="parameters" element="tns:GetCurrentDispatch" />
  </wsdl:message>
  <wsdl:message name="GetCurrentDispatchSoapOut">
    <wsdl:part name="parameters" element="tns:GetCurrentDispatchResponse" />
  </wsdl:message>
  <wsdl:message name="CloseDispatchSoapIn">
    <wsdl:part name="parameters" element="tns:CloseDispatch" />
  </wsdl:message>
  <wsdl:message name="CloseDispatchSoapOut">
    <wsdl:part name="parameters" element="tns:CloseDispatchResponse" />
  </wsdl:message>
  <wsdl:message name="GetShipmentQueueSoapIn">
    <wsdl:part name="parameters" element="tns:GetShipmentQueue" />
  </wsdl:message>
  <wsdl:message name="GetShipmentQueueSoapOut">
    <wsdl:part name="parameters" element="tns:GetShipmentQueueResponse" />
  </wsdl:message>
  <wsdl:message name="GetShipmentReportSoapIn">
    <wsdl:part name="parameters" element="tns:GetShipmentReport" />
  </wsdl:message>
  <wsdl:message name="GetShipmentReportSoapOut">
    <wsdl:part name="parameters" element="tns:GetShipmentReportResponse" />
  </wsdl:message>
  <wsdl:message name="GetShipmentDetailsSoapIn">
    <wsdl:part name="parameters" element="tns:GetShipmentDetails" />
  </wsdl:message>
  <wsdl:message name="GetShipmentDetailsSoapOut">
    <wsdl:part name="parameters" element="tns:GetShipmentDetailsResponse" />
  </wsdl:message>
  <wsdl:message name="GetClosedDispatchesListSoapIn">
    <wsdl:part name="parameters" element="tns:GetClosedDispatchesList" />
  </wsdl:message>
  <wsdl:message name="GetClosedDispatchesListSoapOut">
    <wsdl:part name="parameters" element="tns:GetClosedDispatchesListResponse" />
  </wsdl:message>
  <wsdl:message name="LoadPackageDataSoapIn">
    <wsdl:part name="parameters" element="tns:LoadPackageData" />
  </wsdl:message>
  <wsdl:message name="LoadPackageDataSoapOut">
    <wsdl:part name="parameters" element="tns:LoadPackageDataResponse" />
  </wsdl:message>
  <wsdl:message name="VerifyGXGPackageSoapIn">
    <wsdl:part name="parameters" element="tns:VerifyGXGPackage" />
  </wsdl:message>
  <wsdl:message name="VerifyGXGPackageSoapOut">
    <wsdl:part name="parameters" element="tns:VerifyGXGPackageResponse" />
  </wsdl:message>
  <wsdl:message name="VerifyGXGPackageToDestinationLocationSoapIn">
    <wsdl:part name="parameters" element="tns:VerifyGXGPackageToDestinationLocation" />
  </wsdl:message>
  <wsdl:message name="VerifyGXGPackageToDestinationLocationSoapOut">
    <wsdl:part name="parameters" element="tns:VerifyGXGPackageToDestinationLocationResponse" />
  </wsdl:message>
  <wsdl:message name="GetGXGCommodityInfoSoapIn">
    <wsdl:part name="parameters" element="tns:GetGXGCommodityInfo" />
  </wsdl:message>
  <wsdl:message name="GetGXGCommodityInfoSoapOut">
    <wsdl:part name="parameters" element="tns:GetGXGCommodityInfoResponse" />
  </wsdl:message>
  <wsdl:message name="LabelGXGPackageSoapIn">
    <wsdl:part name="parameters" element="tns:LabelGXGPackage" />
  </wsdl:message>
  <wsdl:message name="LabelGXGPackageSoapOut">
    <wsdl:part name="parameters" element="tns:LabelGXGPackageResponse" />
  </wsdl:message>
  <wsdl:message name="LabelGXGPackageToDestinationLocationSoapIn">
    <wsdl:part name="parameters" element="tns:LabelGXGPackageToDestinationLocation" />
  </wsdl:message>
  <wsdl:message name="LabelGXGPackageToDestinationLocationSoapOut">
    <wsdl:part name="parameters" element="tns:LabelGXGPackageToDestinationLocationResponse" />
  </wsdl:message>
  <wsdl:message name="GetAvailableReportsForDispatchSoapIn">
    <wsdl:part name="parameters" element="tns:GetAvailableReportsForDispatch" />
  </wsdl:message>
  <wsdl:message name="GetAvailableReportsForDispatchSoapOut">
    <wsdl:part name="parameters" element="tns:GetAvailableReportsForDispatchResponse" />
  </wsdl:message>
  <wsdl:message name="GetRequiredReportsForDispatchSoapIn">
    <wsdl:part name="parameters" element="tns:GetRequiredReportsForDispatch" />
  </wsdl:message>
  <wsdl:message name="GetRequiredReportsForDispatchSoapOut">
    <wsdl:part name="parameters" element="tns:GetRequiredReportsForDispatchResponse" />
  </wsdl:message>
  <wsdl:message name="GetDestinationLocationsSoapIn">
    <wsdl:part name="parameters" element="tns:GetDestinationLocations" />
  </wsdl:message>
  <wsdl:message name="GetDestinationLocationsSoapOut">
    <wsdl:part name="parameters" element="tns:GetDestinationLocationsResponse" />
  </wsdl:message>
  <wsdl:message name="GetExpectedShipDateSoapIn">
    <wsdl:part name="parameters" element="tns:GetExpectedShipDate" />
  </wsdl:message>
  <wsdl:message name="GetExpectedShipDateSoapOut">
    <wsdl:part name="parameters" element="tns:GetExpectedShipDateResponse" />
  </wsdl:message>
  <wsdl:message name="SetExpectedShipDateSoapIn">
    <wsdl:part name="parameters" element="tns:SetExpectedShipDate" />
  </wsdl:message>
  <wsdl:message name="SetExpectedShipDateSoapOut">
    <wsdl:part name="parameters" element="tns:SetExpectedShipDateResponse" />
  </wsdl:message>
  <wsdl:message name="AddPackageInReceptacleSoapIn">
    <wsdl:part name="parameters" element="tns:AddPackageInReceptacle" />
  </wsdl:message>
  <wsdl:message name="AddPackageInReceptacleSoapOut">
    <wsdl:part name="parameters" element="tns:AddPackageInReceptacleResponse" />
  </wsdl:message>
  <wsdl:message name="AddPackagesToReceptacleSoapIn">
    <wsdl:part name="parameters" element="tns:AddPackagesToReceptacle" />
  </wsdl:message>
  <wsdl:message name="AddPackagesToReceptacleSoapOut">
    <wsdl:part name="parameters" element="tns:AddPackagesToReceptacleResponse" />
  </wsdl:message>
  <wsdl:message name="RemovePackageFromReceptacleSoapIn">
    <wsdl:part name="parameters" element="tns:RemovePackageFromReceptacle" />
  </wsdl:message>
  <wsdl:message name="RemovePackageFromReceptacleSoapOut">
    <wsdl:part name="parameters" element="tns:RemovePackageFromReceptacleResponse" />
  </wsdl:message>
  <wsdl:message name="GetOpenReceptaclesSoapIn">
    <wsdl:part name="parameters" element="tns:GetOpenReceptacles" />
  </wsdl:message>
  <wsdl:message name="GetOpenReceptaclesSoapOut">
    <wsdl:part name="parameters" element="tns:GetOpenReceptaclesResponse" />
  </wsdl:message>
  <wsdl:message name="TrackPackageWithPostalCodeSoapIn">
    <wsdl:part name="parameters" element="tns:TrackPackageWithPostalCode" />
  </wsdl:message>
  <wsdl:message name="TrackPackageWithPostalCodeSoapOut">
    <wsdl:part name="parameters" element="tns:TrackPackageWithPostalCodeResponse" />
  </wsdl:message>
  <wsdl:message name="TrackPackageSoapIn">
    <wsdl:part name="parameters" element="tns:TrackPackage" />
  </wsdl:message>
  <wsdl:message name="TrackPackageSoapOut">
    <wsdl:part name="parameters" element="tns:TrackPackageResponse" />
  </wsdl:message>
  <wsdl:message name="RetrieveTrackingEventsSinceDateSoapIn">
    <wsdl:part name="parameters" element="tns:RetrieveTrackingEventsSinceDate" />
  </wsdl:message>
  <wsdl:message name="RetrieveTrackingEventsSinceDateSoapOut">
    <wsdl:part name="parameters" element="tns:RetrieveTrackingEventsSinceDateResponse" />
  </wsdl:message>
  <wsdl:message name="RetrieveReceptacleTrackingEventsSinceDateSoapIn">
    <wsdl:part name="parameters" element="tns:RetrieveReceptacleTrackingEventsSinceDate" />
  </wsdl:message>
  <wsdl:message name="RetrieveReceptacleTrackingEventsSinceDateSoapOut">
    <wsdl:part name="parameters" element="tns:RetrieveReceptacleTrackingEventsSinceDateResponse" />
  </wsdl:message>
  <wsdl:message name="CreatePassThroughReceptacleForRateTypeSoapIn">
    <wsdl:part name="parameters" element="tns:CreatePassThroughReceptacleForRateType" />
  </wsdl:message>
  <wsdl:message name="CreatePassThroughReceptacleForRateTypeSoapOut">
    <wsdl:part name="parameters" element="tns:CreatePassThroughReceptacleForRateTypeResponse" />
  </wsdl:message>
  <wsdl:message name="CreateReceptacleForRateTypeToDestinationSoapIn">
    <wsdl:part name="parameters" element="tns:CreateReceptacleForRateTypeToDestination" />
  </wsdl:message>
  <wsdl:message name="CreateReceptacleForRateTypeToDestinationSoapOut">
    <wsdl:part name="parameters" element="tns:CreateReceptacleForRateTypeToDestinationResponse" />
  </wsdl:message>
  <wsdl:message name="CreateReceptacleForRateTypeToDestinationWithTareWeightSoapIn">
    <wsdl:part name="parameters" element="tns:CreateReceptacleForRateTypeToDestinationWithTareWeight" />
  </wsdl:message>
  <wsdl:message name="CreateReceptacleForRateTypeToDestinationWithTareWeightSoapOut">
    <wsdl:part name="parameters" element="tns:CreateReceptacleForRateTypeToDestinationWithTareWeightResponse" />
  </wsdl:message>
  <wsdl:message name="USPSPartnerPackageProcessingSoapIn">
    <wsdl:part name="parameters" element="tns:USPSPartnerPackageProcessing" />
  </wsdl:message>
  <wsdl:message name="USPSPartnerPackageProcessingSoapOut">
    <wsdl:part name="parameters" element="tns:USPSPartnerPackageProcessingResponse" />
  </wsdl:message>
  <wsdl:message name="GetZPLLabelsForPackageSoapIn">
    <wsdl:part name="parameters" element="tns:GetZPLLabelsForPackage" />
  </wsdl:message>
  <wsdl:message name="GetZPLLabelsForPackageSoapOut">
    <wsdl:part name="parameters" element="tns:GetZPLLabelsForPackageResponse" />
  </wsdl:message>
  <wsdl:message name="GetCurrentShipmentByRangeSoapIn">
    <wsdl:part name="parameters" element="tns:GetCurrentShipmentByRange" />
  </wsdl:message>
  <wsdl:message name="GetCurrentShipmentByRangeSoapOut">
    <wsdl:part name="parameters" element="tns:GetCurrentShipmentByRangeResponse" />
  </wsdl:message>
  <wsdl:message name="GetPortCodeListForRateTypeAndDestinationSoapIn">
    <wsdl:part name="parameters" element="tns:GetPortCodeListForRateTypeAndDestination" />
  </wsdl:message>
  <wsdl:message name="GetPortCodeListForRateTypeAndDestinationSoapOut">
    <wsdl:part name="parameters" element="tns:GetPortCodeListForRateTypeAndDestinationResponse" />
  </wsdl:message>
  <wsdl:message name="CalculatePostageSoapIn">
    <wsdl:part name="parameters" element="tns:CalculatePostage" />
  </wsdl:message>
  <wsdl:message name="CalculatePostageSoapOut">
    <wsdl:part name="parameters" element="tns:CalculatePostageResponse" />
  </wsdl:message>
  <wsdl:message name="CalculatePotentialPostageSoapIn">
    <wsdl:part name="parameters" element="tns:CalculatePotentialPostage" />
  </wsdl:message>
  <wsdl:message name="CalculatePotentialPostageSoapOut">
    <wsdl:part name="parameters" element="tns:CalculatePotentialPostageResponse" />
  </wsdl:message>
  <wsdl:message name="GetAvailableCustomInsuredAmountListSoapIn">
    <wsdl:part name="parameters" element="tns:GetAvailableCustomInsuredAmountList" />
  </wsdl:message>
  <wsdl:message name="GetAvailableCustomInsuredAmountListSoapOut">
    <wsdl:part name="parameters" element="tns:GetAvailableCustomInsuredAmountListResponse" />
  </wsdl:message>
  <wsdl:message name="UploadPackageFileSoapIn">
    <wsdl:part name="parameters" element="tns:UploadPackageFile" />
  </wsdl:message>
  <wsdl:message name="UploadPackageFileSoapOut">
    <wsdl:part name="parameters" element="tns:UploadPackageFileResponse" />
  </wsdl:message>
  <wsdl:message name="UpdatePackageWeightSoapIn">
    <wsdl:part name="parameters" element="tns:UpdatePackageWeight" />
  </wsdl:message>
  <wsdl:message name="UpdatePackageWeightSoapOut">
    <wsdl:part name="parameters" element="tns:UpdatePackageWeightResponse" />
  </wsdl:message>
  <wsdl:message name="UpdateDomesticPackageWeightSoapIn">
    <wsdl:part name="parameters" element="tns:UpdateDomesticPackageWeight" />
  </wsdl:message>
  <wsdl:message name="UpdateDomesticPackageWeightSoapOut">
    <wsdl:part name="parameters" element="tns:UpdateDomesticPackageWeightResponse" />
  </wsdl:message>
  <wsdl:message name="ReopenDispatchSoapIn">
    <wsdl:part name="parameters" element="tns:ReopenDispatch" />
  </wsdl:message>
  <wsdl:message name="ReopenDispatchSoapOut">
    <wsdl:part name="parameters" element="tns:ReopenDispatchResponse" />
  </wsdl:message>
  <wsdl:message name="ValidateAddressSoapIn">
    <wsdl:part name="parameters" element="tns:ValidateAddress" />
  </wsdl:message>
  <wsdl:message name="ValidateAddressSoapOut">
    <wsdl:part name="parameters" element="tns:ValidateAddressResponse" />
  </wsdl:message>
  <wsdl:message name="LookupForeignPortCodeForPackageSoapIn">
    <wsdl:part name="parameters" element="tns:LookupForeignPortCodeForPackage" />
  </wsdl:message>
  <wsdl:message name="LookupForeignPortCodeForPackageSoapOut">
    <wsdl:part name="parameters" element="tns:LookupForeignPortCodeForPackageResponse" />
  </wsdl:message>
  <wsdl:message name="LoadShippingPartnerEventSoapIn">
    <wsdl:part name="parameters" element="tns:LoadShippingPartnerEvent" />
  </wsdl:message>
  <wsdl:message name="LoadShippingPartnerEventSoapOut">
    <wsdl:part name="parameters" element="tns:LoadShippingPartnerEventResponse" />
  </wsdl:message>
  <wsdl:message name="GetReceptacleDetailsSoapIn">
    <wsdl:part name="parameters" element="tns:GetReceptacleDetails" />
  </wsdl:message>
  <wsdl:message name="GetReceptacleDetailsSoapOut">
    <wsdl:part name="parameters" element="tns:GetReceptacleDetailsResponse" />
  </wsdl:message>
  <wsdl:message name="GetSystemStatusMessageSoapIn">
    <wsdl:part name="parameters" element="tns:GetSystemStatusMessage" />
  </wsdl:message>
  <wsdl:message name="GetSystemStatusMessageSoapOut">
    <wsdl:part name="parameters" element="tns:GetSystemStatusMessageResponse" />
  </wsdl:message>
  <wsdl:message name="RemovePackageFromClosedShipmentSoapIn">
    <wsdl:part name="parameters" element="tns:RemovePackageFromClosedShipment" />
  </wsdl:message>
  <wsdl:message name="RemovePackageFromClosedShipmentSoapOut">
    <wsdl:part name="parameters" element="tns:RemovePackageFromClosedShipmentResponse" />
  </wsdl:message>
  <wsdl:message name="LoadAndRecordLabeledPackageAndPrintLabelSoapIn">
    <wsdl:part name="parameters" element="tns:LoadAndRecordLabeledPackageAndPrintLabel" />
  </wsdl:message>
  <wsdl:message name="LoadAndRecordLabeledPackageAndPrintLabelSoapOut">
    <wsdl:part name="parameters" element="tns:LoadAndRecordLabeledPackageAndPrintLabelResponse" />
  </wsdl:message>
  <wsdl:portType name="ConsolidatorWebServiceSoap">
    <wsdl:operation name="RefreshWebComponent">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">For GSS support use only. Refreshes the Web Component.</wsdl:documentation>
      <wsdl:input message="tns:RefreshWebComponentSoapIn" />
      <wsdl:output message="tns:RefreshWebComponentSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="AuthenticateUser">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">This method is called first to consume GSS Mailer Web Services. Use the returned access token for each subsequent request.  The token has a session timeout of 20 minutes.</wsdl:documentation>
      <wsdl:input message="tns:AuthenticateUserSoapIn" />
      <wsdl:output message="tns:AuthenticateUserSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="LoadAndRecordLabeledPackage">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Accepts package data from an originating mailer in the predefined XML format. Used by labeling locations only.</wsdl:documentation>
      <wsdl:input message="tns:LoadAndRecordLabeledPackageSoapIn" />
      <wsdl:output message="tns:LoadAndRecordLabeledPackageSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="DetermineIfPackageCanBeShipped">
      <wsdl:input message="tns:DetermineIfPackageCanBeShippedSoapIn" />
      <wsdl:output message="tns:DetermineIfPackageCanBeShippedSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetPackageLabels">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Retrieves labels for a specified package in JPG or PNG image format.</wsdl:documentation>
      <wsdl:input message="tns:GetPackageLabelsSoapIn" />
      <wsdl:output message="tns:GetPackageLabelsSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="SearchForProcessedPackage">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Search for a processed package.</wsdl:documentation>
      <wsdl:input message="tns:SearchForProcessedPackageSoapIn" />
      <wsdl:output message="tns:SearchForProcessedPackageSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="RegeneratePackageCustomsLabel">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Retrieves customs label for a specified package ID processed up to 6 months.</wsdl:documentation>
      <wsdl:input message="tns:RegeneratePackageCustomsLabelSoapIn" />
      <wsdl:output message="tns:RegeneratePackageCustomsLabelSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="LogoutUser">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Logs out the user.</wsdl:documentation>
      <wsdl:input message="tns:LogoutUserSoapIn" />
      <wsdl:output message="tns:LogoutUserSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="CreatePMODReceptacleByFacilityTypeInCurrentShipment">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Creates a PMOD receptacle by facility type in the current shipment</wsdl:documentation>
      <wsdl:input message="tns:CreatePMODReceptacleByFacilityTypeInCurrentShipmentSoapIn" />
      <wsdl:output message="tns:CreatePMODReceptacleByFacilityTypeInCurrentShipmentSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="CreatePMODReceptacleInCurrentShipment">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Creates a PMOD receptacle the current shipment</wsdl:documentation>
      <wsdl:input message="tns:CreatePMODReceptacleInCurrentShipmentSoapIn" />
      <wsdl:output message="tns:CreatePMODReceptacleInCurrentShipmentSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="CreateNewReceptacleInCurrentShipment">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Creates a new receptacle and adds it to the current shipment</wsdl:documentation>
      <wsdl:input message="tns:CreateNewReceptacleInCurrentShipmentSoapIn" />
      <wsdl:output message="tns:CreateNewReceptacleInCurrentShipmentSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="CreateReceptacleInCurrentShipmentV2">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Creates a receptacle and adds it to the current shipment. Version 2.0</wsdl:documentation>
      <wsdl:input message="tns:CreateReceptacleInCurrentShipmentV2SoapIn" />
      <wsdl:output message="tns:CreateReceptacleInCurrentShipmentV2SoapOut" />
    </wsdl:operation>
    <wsdl:operation name="CreateReceptacleForRateType">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Creates a receptacle for a rate type</wsdl:documentation>
      <wsdl:input message="tns:CreateReceptacleForRateTypeSoapIn" />
      <wsdl:output message="tns:CreateReceptacleForRateTypeSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="CreateMixedReceptacleInCurrentShipment">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Creates a mixed receptacle and adds it to the current shipment. Version 2.0</wsdl:documentation>
      <wsdl:input message="tns:CreateMixedReceptacleInCurrentShipmentSoapIn" />
      <wsdl:output message="tns:CreateMixedReceptacleInCurrentShipmentSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="CreateMixedReceptacleInCurrentShipmentV2">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Creates a mixed receptacle and adds it to the current shipment. Version 2.1</wsdl:documentation>
      <wsdl:input message="tns:CreateMixedReceptacleInCurrentShipmentV2SoapIn" />
      <wsdl:output message="tns:CreateMixedReceptacleInCurrentShipmentV2SoapOut" />
    </wsdl:operation>
    <wsdl:operation name="CreateMixedReceptacleForRateType">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Creates a mixed receptacle for rate type and adds it to the current shipment.</wsdl:documentation>
      <wsdl:input message="tns:CreateMixedReceptacleForRateTypeSoapIn" />
      <wsdl:output message="tns:CreateMixedReceptacleForRateTypeSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="CreateMixedReceptacleForRateTypeWithTareWeight">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Creates a mixed receptacle for rate type with Tare Weight and adds it to the current shipment.</wsdl:documentation>
      <wsdl:input message="tns:CreateMixedReceptacleForRateTypeWithTareWeightSoapIn" />
      <wsdl:output message="tns:CreateMixedReceptacleForRateTypeWithTareWeightSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetReceptacleLabel">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Retrieves labels for a specified Receptacle in JPG or PNG image format.</wsdl:documentation>
      <wsdl:input message="tns:GetReceptacleLabelSoapIn" />
      <wsdl:output message="tns:GetReceptacleLabelSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="AddReceptacleToCurrentShipment">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Add a receptacle to the current shipment</wsdl:documentation>
      <wsdl:input message="tns:AddReceptacleToCurrentShipmentSoapIn" />
      <wsdl:output message="tns:AddReceptacleToCurrentShipmentSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="SetPPMODIReceptacleInCurrentShipment">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Sets PPMODI receptacle as a Parent Receptacle in the current shipment.</wsdl:documentation>
      <wsdl:input message="tns:SetPPMODIReceptacleInCurrentShipmentSoapIn" />
      <wsdl:output message="tns:SetPPMODIReceptacleInCurrentShipmentSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="CreatePassThroughReceptacleInCurrentShipment">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Creates a Pass-Through receptacle in the current shipment.</wsdl:documentation>
      <wsdl:input message="tns:CreatePassThroughReceptacleInCurrentShipmentSoapIn" />
      <wsdl:output message="tns:CreatePassThroughReceptacleInCurrentShipmentSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="AddReceptacleToCurrentShipmentV2">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Adds a receptacle to a current shipment. Version 2.0</wsdl:documentation>
      <wsdl:input message="tns:AddReceptacleToCurrentShipmentV2SoapIn" />
      <wsdl:output message="tns:AddReceptacleToCurrentShipmentV2SoapOut" />
    </wsdl:operation>
    <wsdl:operation name="RemovePackageFromDefaultShipment">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Removes package from default shipment.</wsdl:documentation>
      <wsdl:input message="tns:RemovePackageFromDefaultShipmentSoapIn" />
      <wsdl:output message="tns:RemovePackageFromDefaultShipmentSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="AddRemovedPackageToDefaultShipment">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Re-add a removed package to the default shipment listing.</wsdl:documentation>
      <wsdl:input message="tns:AddRemovedPackageToDefaultShipmentSoapIn" />
      <wsdl:output message="tns:AddRemovedPackageToDefaultShipmentSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="RemoveReceptacleFromDefaultShipment">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Removes a receptacle from the default shipment listing</wsdl:documentation>
      <wsdl:input message="tns:RemoveReceptacleFromDefaultShipmentSoapIn" />
      <wsdl:output message="tns:RemoveReceptacleFromDefaultShipmentSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="MoveShipmentToOpenDispatch">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Moves a shipment to open dispatch</wsdl:documentation>
      <wsdl:input message="tns:MoveShipmentToOpenDispatchSoapIn" />
      <wsdl:output message="tns:MoveShipmentToOpenDispatchSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="MoveReceptacleToOpenDispatch">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Moves a shipment to open dispatch</wsdl:documentation>
      <wsdl:input message="tns:MoveReceptacleToOpenDispatchSoapIn" />
      <wsdl:output message="tns:MoveReceptacleToOpenDispatchSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GenerateReportByPermitNumber">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Generates the requested report per permit number for a closed dispatch.</wsdl:documentation>
      <wsdl:input message="tns:GenerateReportByPermitNumberSoapIn" />
      <wsdl:output message="tns:GenerateReportByPermitNumberSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetDispatchReport">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Generates the requested report for a closed dispatch.</wsdl:documentation>
      <wsdl:input message="tns:GetDispatchReportSoapIn" />
      <wsdl:output message="tns:GetDispatchReportSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="RemoveReceptacleFromOpenDispatch">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Moves a shipment to open dispatch</wsdl:documentation>
      <wsdl:input message="tns:RemoveReceptacleFromOpenDispatchSoapIn" />
      <wsdl:output message="tns:RemoveReceptacleFromOpenDispatchSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="RemovePackageFromOpenDispatch">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Moves a shipment to open dispatch</wsdl:documentation>
      <wsdl:input message="tns:RemovePackageFromOpenDispatchSoapIn" />
      <wsdl:output message="tns:RemovePackageFromOpenDispatchSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="MovePackageToOpenDispatch">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Moves a shipment to open dispatch</wsdl:documentation>
      <wsdl:input message="tns:MovePackageToOpenDispatchSoapIn" />
      <wsdl:output message="tns:MovePackageToOpenDispatchSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="MovePackagesToOpenDispatch">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Moves a shipments to open dispatch</wsdl:documentation>
      <wsdl:input message="tns:MovePackagesToOpenDispatchSoapIn" />
      <wsdl:output message="tns:MovePackagesToOpenDispatchSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetCurrentShipment">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Retrieves current shipment for a location</wsdl:documentation>
      <wsdl:input message="tns:GetCurrentShipmentSoapIn" />
      <wsdl:output message="tns:GetCurrentShipmentSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetCurrentDispatch">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Retrieves current dispatch for a location</wsdl:documentation>
      <wsdl:input message="tns:GetCurrentDispatchSoapIn" />
      <wsdl:output message="tns:GetCurrentDispatchSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="CloseDispatch">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Closes a currently open dispatch </wsdl:documentation>
      <wsdl:input message="tns:CloseDispatchSoapIn" />
      <wsdl:output message="tns:CloseDispatchSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetShipmentQueue">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Returns the list of shipments in the queue including the default Shipment</wsdl:documentation>
      <wsdl:input message="tns:GetShipmentQueueSoapIn" />
      <wsdl:output message="tns:GetShipmentQueueSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetShipmentReport">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Generates the requested report for a closed shipment</wsdl:documentation>
      <wsdl:input message="tns:GetShipmentReportSoapIn" />
      <wsdl:output message="tns:GetShipmentReportSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetShipmentDetails">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Retrieves shipment details for a location.</wsdl:documentation>
      <wsdl:input message="tns:GetShipmentDetailsSoapIn" />
      <wsdl:output message="tns:GetShipmentDetailsSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetClosedDispatchesList">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Retrieves shipment history for the location.</wsdl:documentation>
      <wsdl:input message="tns:GetClosedDispatchesListSoapIn" />
      <wsdl:output message="tns:GetClosedDispatchesListSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="LoadPackageData">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Accepts package data from a mailer in the predefined XML format. Overwrites previous version if reloaded.</wsdl:documentation>
      <wsdl:input message="tns:LoadPackageDataSoapIn" />
      <wsdl:output message="tns:LoadPackageDataSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="VerifyGXGPackage">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Verifies the GXG package for processing.</wsdl:documentation>
      <wsdl:input message="tns:VerifyGXGPackageSoapIn" />
      <wsdl:output message="tns:VerifyGXGPackageSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="VerifyGXGPackageToDestinationLocation">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Verifies the GXG package for processing, with destination location ID as an additional parameter.</wsdl:documentation>
      <wsdl:input message="tns:VerifyGXGPackageToDestinationLocationSoapIn" />
      <wsdl:output message="tns:VerifyGXGPackageToDestinationLocationSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetGXGCommodityInfo">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Returns a list of commodity names used for GXG.</wsdl:documentation>
      <wsdl:input message="tns:GetGXGCommodityInfoSoapIn" />
      <wsdl:output message="tns:GetGXGCommodityInfoSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="LabelGXGPackage">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Processes a removed/re-entered or new GXG package.</wsdl:documentation>
      <wsdl:input message="tns:LabelGXGPackageSoapIn" />
      <wsdl:output message="tns:LabelGXGPackageSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="LabelGXGPackageToDestinationLocation">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Processes a GXG package to a destination location. Used by mailers who use multiple destination locations. </wsdl:documentation>
      <wsdl:input message="tns:LabelGXGPackageToDestinationLocationSoapIn" />
      <wsdl:output message="tns:LabelGXGPackageToDestinationLocationSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetAvailableReportsForDispatch">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Returns a list of all reports that are available for a dispatch.</wsdl:documentation>
      <wsdl:input message="tns:GetAvailableReportsForDispatchSoapIn" />
      <wsdl:output message="tns:GetAvailableReportsForDispatchSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetRequiredReportsForDispatch">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Returns a list of all required reports that are available for a dispatch.</wsdl:documentation>
      <wsdl:input message="tns:GetRequiredReportsForDispatchSoapIn" />
      <wsdl:output message="tns:GetRequiredReportsForDispatchSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetDestinationLocations">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Returns a list of all destination locations that are available for a mailer.</wsdl:documentation>
      <wsdl:input message="tns:GetDestinationLocationsSoapIn" />
      <wsdl:output message="tns:GetDestinationLocationsSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetExpectedShipDate">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Get Expected Ship Date</wsdl:documentation>
      <wsdl:input message="tns:GetExpectedShipDateSoapIn" />
      <wsdl:output message="tns:GetExpectedShipDateSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="SetExpectedShipDate">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Set Expected Ship Date</wsdl:documentation>
      <wsdl:input message="tns:SetExpectedShipDateSoapIn" />
      <wsdl:output message="tns:SetExpectedShipDateSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="AddPackageInReceptacle">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Add package to receptacle</wsdl:documentation>
      <wsdl:input message="tns:AddPackageInReceptacleSoapIn" />
      <wsdl:output message="tns:AddPackageInReceptacleSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="AddPackagesToReceptacle">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Add package to receptacle</wsdl:documentation>
      <wsdl:input message="tns:AddPackagesToReceptacleSoapIn" />
      <wsdl:output message="tns:AddPackagesToReceptacleSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="RemovePackageFromReceptacle">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Remove package from receptacle</wsdl:documentation>
      <wsdl:input message="tns:RemovePackageFromReceptacleSoapIn" />
      <wsdl:output message="tns:RemovePackageFromReceptacleSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetOpenReceptacles">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">List receptacle allow to add packages or all receptacle</wsdl:documentation>
      <wsdl:input message="tns:GetOpenReceptaclesSoapIn" />
      <wsdl:output message="tns:GetOpenReceptaclesSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="TrackPackageWithPostalCode">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Retrieves the history of tracking events with the Postal Code for a package.</wsdl:documentation>
      <wsdl:input message="tns:TrackPackageWithPostalCodeSoapIn" />
      <wsdl:output message="tns:TrackPackageWithPostalCodeSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="TrackPackage">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Retrieves the history of tracking events for a package.</wsdl:documentation>
      <wsdl:input message="tns:TrackPackageSoapIn" />
      <wsdl:output message="tns:TrackPackageSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="RetrieveTrackingEventsSinceDate">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Retrieves the history of tracking events for an agent.</wsdl:documentation>
      <wsdl:input message="tns:RetrieveTrackingEventsSinceDateSoapIn" />
      <wsdl:output message="tns:RetrieveTrackingEventsSinceDateSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="RetrieveReceptacleTrackingEventsSinceDate">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Retrieves Receptacle tracking events for an agent.</wsdl:documentation>
      <wsdl:input message="tns:RetrieveReceptacleTrackingEventsSinceDateSoapIn" />
      <wsdl:output message="tns:RetrieveReceptacleTrackingEventsSinceDateSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="CreatePassThroughReceptacleForRateType">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Creates a Pass-Through receptacle for a rate type</wsdl:documentation>
      <wsdl:input message="tns:CreatePassThroughReceptacleForRateTypeSoapIn" />
      <wsdl:output message="tns:CreatePassThroughReceptacleForRateTypeSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="CreateReceptacleForRateTypeToDestination">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Creates a receptacle for a rate type</wsdl:documentation>
      <wsdl:input message="tns:CreateReceptacleForRateTypeToDestinationSoapIn" />
      <wsdl:output message="tns:CreateReceptacleForRateTypeToDestinationSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="CreateReceptacleForRateTypeToDestinationWithTareWeight">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Creates a receptacle for a rate type</wsdl:documentation>
      <wsdl:input message="tns:CreateReceptacleForRateTypeToDestinationWithTareWeightSoapIn" />
      <wsdl:output message="tns:CreateReceptacleForRateTypeToDestinationWithTareWeightSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="USPSPartnerPackageProcessing">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Process USPS Partner Mailer package</wsdl:documentation>
      <wsdl:input message="tns:USPSPartnerPackageProcessingSoapIn" />
      <wsdl:output message="tns:USPSPartnerPackageProcessingSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetZPLLabelsForPackage">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Retrieves labels for a specified package in ZPL image format.</wsdl:documentation>
      <wsdl:input message="tns:GetZPLLabelsForPackageSoapIn" />
      <wsdl:output message="tns:GetZPLLabelsForPackageSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetCurrentShipmentByRange">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Retrieves current shipment for a location Version 2.0</wsdl:documentation>
      <wsdl:input message="tns:GetCurrentShipmentByRangeSoapIn" />
      <wsdl:output message="tns:GetCurrentShipmentByRangeSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetPortCodeListForRateTypeAndDestination">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Retrieves Port Code list for a particular service level and  destination.</wsdl:documentation>
      <wsdl:input message="tns:GetPortCodeListForRateTypeAndDestinationSoapIn" />
      <wsdl:output message="tns:GetPortCodeListForRateTypeAndDestinationSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="CalculatePostage">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Allow a mailer to query for the postage amount, prior to processing a package.</wsdl:documentation>
      <wsdl:input message="tns:CalculatePostageSoapIn" />
      <wsdl:output message="tns:CalculatePostageSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="CalculatePotentialPostage">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Allow a mailer to query for the postage amount, prior to processing a package return result as XML.</wsdl:documentation>
      <wsdl:input message="tns:CalculatePotentialPostageSoapIn" />
      <wsdl:output message="tns:CalculatePotentialPostageSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetAvailableCustomInsuredAmountList">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Retrieves available custom insured amount list for a service type.</wsdl:documentation>
      <wsdl:input message="tns:GetAvailableCustomInsuredAmountListSoapIn" />
      <wsdl:output message="tns:GetAvailableCustomInsuredAmountListSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="UploadPackageFile">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Uploads a package file to the GSS server.</wsdl:documentation>
      <wsdl:input message="tns:UploadPackageFileSoapIn" />
      <wsdl:output message="tns:UploadPackageFileSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="UpdatePackageWeight">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Update Package Weight.</wsdl:documentation>
      <wsdl:input message="tns:UpdatePackageWeightSoapIn" />
      <wsdl:output message="tns:UpdatePackageWeightSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="UpdateDomesticPackageWeight">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Update Domestic Package Weight.</wsdl:documentation>
      <wsdl:input message="tns:UpdateDomesticPackageWeightSoapIn" />
      <wsdl:output message="tns:UpdateDomesticPackageWeightSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="ReopenDispatch">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Reopen Dispatch</wsdl:documentation>
      <wsdl:input message="tns:ReopenDispatchSoapIn" />
      <wsdl:output message="tns:ReopenDispatchSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="ValidateAddress">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Validate Recipient Address</wsdl:documentation>
      <wsdl:input message="tns:ValidateAddressSoapIn" />
      <wsdl:output message="tns:ValidateAddressSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="LookupForeignPortCodeForPackage">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Foreign Port Lookup</wsdl:documentation>
      <wsdl:input message="tns:LookupForeignPortCodeForPackageSoapIn" />
      <wsdl:output message="tns:LookupForeignPortCodeForPackageSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="LoadShippingPartnerEvent">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Load Shipping Partner Event to be send to PTR</wsdl:documentation>
      <wsdl:input message="tns:LoadShippingPartnerEventSoapIn" />
      <wsdl:output message="tns:LoadShippingPartnerEventSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetReceptacleDetails">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Returns details for a receptacle, including: rate type, port, status and package list</wsdl:documentation>
      <wsdl:input message="tns:GetReceptacleDetailsSoapIn" />
      <wsdl:output message="tns:GetReceptacleDetailsSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetSystemStatusMessage">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Retrieves system status message.</wsdl:documentation>
      <wsdl:input message="tns:GetSystemStatusMessageSoapIn" />
      <wsdl:output message="tns:GetSystemStatusMessageSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="RemovePackageFromClosedShipment">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Removes package from Closed shipment.</wsdl:documentation>
      <wsdl:input message="tns:RemovePackageFromClosedShipmentSoapIn" />
      <wsdl:output message="tns:RemovePackageFromClosedShipmentSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="LoadAndRecordLabeledPackageAndPrintLabel">
      <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">Accepts package data from an originating mailer in the predefined XML format and print label.</wsdl:documentation>
      <wsdl:input message="tns:LoadAndRecordLabeledPackageAndPrintLabelSoapIn" />
      <wsdl:output message="tns:LoadAndRecordLabeledPackageAndPrintLabelSoapOut" />
    </wsdl:operation>
  </wsdl:portType>
  <wsdl:binding name="ConsolidatorWebServiceSoap" type="tns:ConsolidatorWebServiceSoap">
    <soap:binding transport="http://schemas.xmlsoap.org/soap/http" />
    <wsdl:operation name="RefreshWebComponent">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/RefreshWebComponent" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="AuthenticateUser">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/AuthenticateUser" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="LoadAndRecordLabeledPackage">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/LoadAndRecordLabeledPackage" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="DetermineIfPackageCanBeShipped">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/DetermineIfPackageCanBeShipped" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetPackageLabels">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/GetPackageLabels" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="SearchForProcessedPackage">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/SearchForProcessedPackage" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="RegeneratePackageCustomsLabel">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/RegeneratePackageCustomsLabel" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="LogoutUser">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/LogoutUser" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="CreatePMODReceptacleByFacilityTypeInCurrentShipment">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/CreatePMODReceptacleByFacilityTypeInCurrentShipment" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="CreatePMODReceptacleInCurrentShipment">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/CreatePMODReceptacleInCurrentShipment" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="CreateNewReceptacleInCurrentShipment">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/CreateNewReceptacleInCurrentShipment" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="CreateReceptacleInCurrentShipmentV2">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/CreateReceptacleInCurrentShipmentV2" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="CreateReceptacleForRateType">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/CreateReceptacleForRateType" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="CreateMixedReceptacleInCurrentShipment">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/CreateMixedReceptacleInCurrentShipment" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="CreateMixedReceptacleInCurrentShipmentV2">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/CreateMixedReceptacleInCurrentShipmentV2" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="CreateMixedReceptacleForRateType">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/CreateMixedReceptacleForRateType" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="CreateMixedReceptacleForRateTypeWithTareWeight">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/CreateMixedReceptacleForRateTypeWithTareWeight" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetReceptacleLabel">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/GetReceptacleLabel" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="AddReceptacleToCurrentShipment">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/AddReceptacleToCurrentShipment" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="SetPPMODIReceptacleInCurrentShipment">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/SetPPMODIReceptacleInCurrentShipment" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="CreatePassThroughReceptacleInCurrentShipment">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/CreatePassThroughReceptacleInCurrentShipment" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="AddReceptacleToCurrentShipmentV2">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/AddReceptacleToCurrentShipmentV2" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="RemovePackageFromDefaultShipment">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/RemovePackageFromDefaultShipment" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="AddRemovedPackageToDefaultShipment">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/AddRemovedPackageToDefaultShipment" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="RemoveReceptacleFromDefaultShipment">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/RemoveReceptacleFromDefaultShipment" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="MoveShipmentToOpenDispatch">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/MoveShipmentToOpenDispatch" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="MoveReceptacleToOpenDispatch">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/MoveReceptacleToOpenDispatch" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GenerateReportByPermitNumber">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/GenerateReportByPermitNumber" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetDispatchReport">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/GetDispatchReport" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="RemoveReceptacleFromOpenDispatch">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/RemoveReceptacleFromOpenDispatch" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="RemovePackageFromOpenDispatch">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/RemovePackageFromOpenDispatch" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="MovePackageToOpenDispatch">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/MovePackageToOpenDispatch" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="MovePackagesToOpenDispatch">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/MovePackagesToOpenDispatch" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetCurrentShipment">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/GetCurrentShipment" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetCurrentDispatch">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/GetCurrentDispatch" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="CloseDispatch">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/CloseDispatch" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetShipmentQueue">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/GetShipmentQueue" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetShipmentReport">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/GetShipmentReport" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetShipmentDetails">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/GetShipmentDetails" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetClosedDispatchesList">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/GetClosedDispatchesList" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="LoadPackageData">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/LoadPackageData" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="VerifyGXGPackage">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/VerifyGXGPackage" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="VerifyGXGPackageToDestinationLocation">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/VerifyGXGPackageToDestinationLocation" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetGXGCommodityInfo">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/GetGXGCommodityInfo" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="LabelGXGPackage">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/LabelGXGPackage" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="LabelGXGPackageToDestinationLocation">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/LabelGXGPackageToDestinationLocation" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetAvailableReportsForDispatch">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/GetAvailableReportsForDispatch" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetRequiredReportsForDispatch">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/GetRequiredReportsForDispatch" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetDestinationLocations">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/GetDestinationLocations" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetExpectedShipDate">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/GetExpectedShipDate" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="SetExpectedShipDate">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/SetExpectedShipDate" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="AddPackageInReceptacle">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/AddPackageInReceptacle" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="AddPackagesToReceptacle">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/AddPackagesToReceptacle" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="RemovePackageFromReceptacle">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/RemovePackageFromReceptacle" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetOpenReceptacles">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/GetOpenReceptacles" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="TrackPackageWithPostalCode">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/TrackPackageWithPostalCode" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="TrackPackage">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/TrackPackage" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="RetrieveTrackingEventsSinceDate">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/RetrieveTrackingEventsSinceDate" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="RetrieveReceptacleTrackingEventsSinceDate">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/RetrieveReceptacleTrackingEventsSinceDate" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="CreatePassThroughReceptacleForRateType">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/CreatePassThroughReceptacleForRateType" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="CreateReceptacleForRateTypeToDestination">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/CreateReceptacleForRateTypeToDestination" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="CreateReceptacleForRateTypeToDestinationWithTareWeight">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/CreateReceptacleForRateTypeToDestinationWithTareWeight" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="USPSPartnerPackageProcessing">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/USPSPartnerPackageProcessing" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetZPLLabelsForPackage">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/GetZPLLabelsForPackage" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetCurrentShipmentByRange">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/GetCurrentShipmentByRange" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetPortCodeListForRateTypeAndDestination">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/GetPortCodeListForRateTypeAndDestination" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="CalculatePostage">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/CalculatePostage" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="CalculatePotentialPostage">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/CalculatePotentialPostage" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetAvailableCustomInsuredAmountList">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/GetAvailableCustomInsuredAmountList" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="UploadPackageFile">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/UploadPackageFile" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="UpdatePackageWeight">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/UpdatePackageWeight" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="UpdateDomesticPackageWeight">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/UpdateDomesticPackageWeight" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="ReopenDispatch">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/ReopenDispatch" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="ValidateAddress">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/ValidateAddress" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="LookupForeignPortCodeForPackage">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/LookupForeignPortCodeForPackage" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="LoadShippingPartnerEvent">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/LoadShippingPartnerEvent" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetReceptacleDetails">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/GetReceptacleDetails" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetSystemStatusMessage">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/GetSystemStatusMessage" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="RemovePackageFromClosedShipment">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/RemovePackageFromClosedShipment" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="LoadAndRecordLabeledPackageAndPrintLabel">
      <soap:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/LoadAndRecordLabeledPackageAndPrintLabel" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
  </wsdl:binding>
  <wsdl:binding name="ConsolidatorWebServiceSoap12" type="tns:ConsolidatorWebServiceSoap">
    <soap12:binding transport="http://schemas.xmlsoap.org/soap/http" />
    <wsdl:operation name="RefreshWebComponent">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/RefreshWebComponent" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="AuthenticateUser">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/AuthenticateUser" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="LoadAndRecordLabeledPackage">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/LoadAndRecordLabeledPackage" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="DetermineIfPackageCanBeShipped">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/DetermineIfPackageCanBeShipped" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetPackageLabels">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/GetPackageLabels" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="SearchForProcessedPackage">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/SearchForProcessedPackage" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="RegeneratePackageCustomsLabel">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/RegeneratePackageCustomsLabel" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="LogoutUser">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/LogoutUser" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="CreatePMODReceptacleByFacilityTypeInCurrentShipment">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/CreatePMODReceptacleByFacilityTypeInCurrentShipment" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="CreatePMODReceptacleInCurrentShipment">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/CreatePMODReceptacleInCurrentShipment" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="CreateNewReceptacleInCurrentShipment">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/CreateNewReceptacleInCurrentShipment" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="CreateReceptacleInCurrentShipmentV2">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/CreateReceptacleInCurrentShipmentV2" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="CreateReceptacleForRateType">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/CreateReceptacleForRateType" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="CreateMixedReceptacleInCurrentShipment">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/CreateMixedReceptacleInCurrentShipment" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="CreateMixedReceptacleInCurrentShipmentV2">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/CreateMixedReceptacleInCurrentShipmentV2" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="CreateMixedReceptacleForRateType">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/CreateMixedReceptacleForRateType" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="CreateMixedReceptacleForRateTypeWithTareWeight">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/CreateMixedReceptacleForRateTypeWithTareWeight" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetReceptacleLabel">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/GetReceptacleLabel" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="AddReceptacleToCurrentShipment">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/AddReceptacleToCurrentShipment" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="SetPPMODIReceptacleInCurrentShipment">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/SetPPMODIReceptacleInCurrentShipment" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="CreatePassThroughReceptacleInCurrentShipment">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/CreatePassThroughReceptacleInCurrentShipment" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="AddReceptacleToCurrentShipmentV2">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/AddReceptacleToCurrentShipmentV2" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="RemovePackageFromDefaultShipment">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/RemovePackageFromDefaultShipment" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="AddRemovedPackageToDefaultShipment">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/AddRemovedPackageToDefaultShipment" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="RemoveReceptacleFromDefaultShipment">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/RemoveReceptacleFromDefaultShipment" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="MoveShipmentToOpenDispatch">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/MoveShipmentToOpenDispatch" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="MoveReceptacleToOpenDispatch">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/MoveReceptacleToOpenDispatch" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GenerateReportByPermitNumber">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/GenerateReportByPermitNumber" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetDispatchReport">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/GetDispatchReport" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="RemoveReceptacleFromOpenDispatch">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/RemoveReceptacleFromOpenDispatch" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="RemovePackageFromOpenDispatch">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/RemovePackageFromOpenDispatch" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="MovePackageToOpenDispatch">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/MovePackageToOpenDispatch" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="MovePackagesToOpenDispatch">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/MovePackagesToOpenDispatch" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetCurrentShipment">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/GetCurrentShipment" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetCurrentDispatch">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/GetCurrentDispatch" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="CloseDispatch">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/CloseDispatch" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetShipmentQueue">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/GetShipmentQueue" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetShipmentReport">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/GetShipmentReport" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetShipmentDetails">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/GetShipmentDetails" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetClosedDispatchesList">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/GetClosedDispatchesList" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="LoadPackageData">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/LoadPackageData" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="VerifyGXGPackage">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/VerifyGXGPackage" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="VerifyGXGPackageToDestinationLocation">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/VerifyGXGPackageToDestinationLocation" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetGXGCommodityInfo">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/GetGXGCommodityInfo" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="LabelGXGPackage">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/LabelGXGPackage" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="LabelGXGPackageToDestinationLocation">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/LabelGXGPackageToDestinationLocation" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetAvailableReportsForDispatch">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/GetAvailableReportsForDispatch" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetRequiredReportsForDispatch">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/GetRequiredReportsForDispatch" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetDestinationLocations">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/GetDestinationLocations" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetExpectedShipDate">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/GetExpectedShipDate" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="SetExpectedShipDate">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/SetExpectedShipDate" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="AddPackageInReceptacle">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/AddPackageInReceptacle" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="AddPackagesToReceptacle">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/AddPackagesToReceptacle" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="RemovePackageFromReceptacle">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/RemovePackageFromReceptacle" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetOpenReceptacles">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/GetOpenReceptacles" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="TrackPackageWithPostalCode">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/TrackPackageWithPostalCode" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="TrackPackage">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/TrackPackage" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="RetrieveTrackingEventsSinceDate">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/RetrieveTrackingEventsSinceDate" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="RetrieveReceptacleTrackingEventsSinceDate">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/RetrieveReceptacleTrackingEventsSinceDate" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="CreatePassThroughReceptacleForRateType">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/CreatePassThroughReceptacleForRateType" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="CreateReceptacleForRateTypeToDestination">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/CreateReceptacleForRateTypeToDestination" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="CreateReceptacleForRateTypeToDestinationWithTareWeight">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/CreateReceptacleForRateTypeToDestinationWithTareWeight" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="USPSPartnerPackageProcessing">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/USPSPartnerPackageProcessing" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetZPLLabelsForPackage">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/GetZPLLabelsForPackage" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetCurrentShipmentByRange">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/GetCurrentShipmentByRange" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetPortCodeListForRateTypeAndDestination">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/GetPortCodeListForRateTypeAndDestination" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="CalculatePostage">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/CalculatePostage" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="CalculatePotentialPostage">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/CalculatePotentialPostage" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetAvailableCustomInsuredAmountList">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/GetAvailableCustomInsuredAmountList" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="UploadPackageFile">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/UploadPackageFile" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="UpdatePackageWeight">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/UpdatePackageWeight" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="UpdateDomesticPackageWeight">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/UpdateDomesticPackageWeight" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="ReopenDispatch">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/ReopenDispatch" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="ValidateAddress">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/ValidateAddress" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="LookupForeignPortCodeForPackage">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/LookupForeignPortCodeForPackage" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="LoadShippingPartnerEvent">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/LoadShippingPartnerEvent" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetReceptacleDetails">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/GetReceptacleDetails" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetSystemStatusMessage">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/GetSystemStatusMessage" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="RemovePackageFromClosedShipment">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/RemovePackageFromClosedShipment" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="LoadAndRecordLabeledPackageAndPrintLabel">
      <soap12:operation soapAction="https://gss.usps.com/usps-cpas/GSSAPI/LoadAndRecordLabeledPackageAndPrintLabel" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
  </wsdl:binding>
  <wsdl:service name="ConsolidatorWebService">
    <wsdl:port name="ConsolidatorWebServiceSoap" binding="tns:ConsolidatorWebServiceSoap">
      <soap:address location="http://gss.usps.com/usps-cpas/testgssapi/consolidatorwebservice.asmx" />
    </wsdl:port>
    <wsdl:port name="ConsolidatorWebServiceSoap12" binding="tns:ConsolidatorWebServiceSoap12">
      <soap12:address location="http://gss.usps.com/usps-cpas/testgssapi/consolidatorwebservice.asmx" />
    </wsdl:port>
  </wsdl:service>
</wsdl:definitions>