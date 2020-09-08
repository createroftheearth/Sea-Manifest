//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblMasterConsignmentMessageImplementationMap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblMasterConsignmentMessageImplementationMap()
        {
            this.tblAdditionalDetailsHouseCargoMaps = new HashSet<tblAdditionalDetailsHouseCargoMap>();
            this.tblHouseCargoDescriptionMasterConsignmentMaps = new HashSet<tblHouseCargoDescriptionMasterConsignmentMap>();
            this.tblItemDetailsHouseCargoMaps = new HashSet<tblItemDetailsHouseCargoMap>();
            this.tblItemDetailsMasterConsignmentMaps = new HashSet<tblItemDetailsMasterConsignmentMap>();
            this.tblItineraryHouseCargoMaps = new HashSet<tblItineraryHouseCargoMap>();
            this.tblItineraryMasterConsignmentMaps = new HashSet<tblItineraryMasterConsignmentMap>();
            this.tblSupportDocHouseCargoMaps = new HashSet<tblSupportDocHouseCargoMap>();
            this.tblSupportDocMasterConsignmentMaps = new HashSet<tblSupportDocMasterConsignmentMap>();
            this.tblTransportEquipmentHouseCargoMaps = new HashSet<tblTransportEquipmentHouseCargoMap>();
            this.tblTransportEquipmentMasterConsignmentMaps = new HashSet<tblTransportEquipmentMasterConsignmentMap>();
        }
    
        public int iMasterConsignmentId { get; set; }
        public Nullable<int> iMessageImplementationId { get; set; }
        public Nullable<int> iMCRefLineNo { get; set; }
        public string sMCRefMasterBillNo { get; set; }
        public Nullable<System.DateTime> dtMCRefMasterBillDate { get; set; }
        public string sMCRefConsolidatedIndicator { get; set; }
        public string sMCRefPreviousDeclaration { get; set; }
        public string sMCRefConsolidatorPan { get; set; }
        public string sPrevRefCinType { get; set; }
        public string sPrevRefMcinPcin { get; set; }
        public string sPrevRefCSNSubmtdType { get; set; }
        public string sPrevRefCSNSubmtdBy { get; set; }
        public string sPrevRefCSNReportingType { get; set; }
        public string sPrevRefCSNSiteId { get; set; }
        public Nullable<int> iPrevRefCSNNo { get; set; }
        public Nullable<System.DateTime> dtPrevRefCSNDate { get; set; }
        public string sPrevRefSplitIndicator { get; set; }
        public Nullable<decimal> dPrevRefNoOfPackages { get; set; }
        public string sPrevRefTypeOfPackage { get; set; }
        public string sLocCustomFirstPortOfEntry { get; set; }
        public string sLocCustomDestPort { get; set; }
        public string sLocCustomNextPortOfUnlanding { get; set; }
        public string sLocCustomTypeOfCargo { get; set; }
        public string sLocCustomItemType { get; set; }
        public string sLocCustomCargoMovement { get; set; }
        public string sLocCustomNatureOfCargo { get; set; }
        public string sLocCustomSplitIndicator { get; set; }
        public Nullable<decimal> dLocCustomNoOfPackages { get; set; }
        public string sLocCustomTypeOfPackage { get; set; }
        public string sTrnshprCd { get; set; }
        public string sTrnshprBond { get; set; }
        public string sTrnsprtrDocPortOfAcceptedCCd { get; set; }
        public string sTrnsprtrDocPortOfAcceptedName { get; set; }
        public string sTrnsprtrDocPortOfReceiptCcd { get; set; }
        public string sTrnsprtrDocPortOfReceiptName { get; set; }
        public string sTrnsprtrDocConsignorName { get; set; }
        public string sTrnsprtrDocConsignorCd { get; set; }
        public string sTrnsprtrDocConsignorCdType { get; set; }
        public string sTrnsprtrDocConsignorStreetAddress { get; set; }
        public string sTrnsprtrDocConsignorCity { get; set; }
        public string sTrnsprtrDocConsignorCountrySubDivName { get; set; }
        public string sTrnsprtrDocConsignorCountrySubDivCd { get; set; }
        public string sTrnsprtrDocConsignorCountryCd { get; set; }
        public string sTrnsprtrDocConsignorPostCd { get; set; }
        public string sTrnsprtrDocConsigneeName { get; set; }
        public string sTrnsprtrDocConsigneeCd { get; set; }
        public string sTrnsprtrDocTypeOfCd { get; set; }
        public string sTrnsprtrDocConsigneeStreetAddress { get; set; }
        public string sTrnsprtrDocConsigneeCity { get; set; }
        public string sTrnsprtrDocConsigneeCountrySubDivName { get; set; }
        public string sTrnsprtrDocConsigneeCountrySubDiv { get; set; }
        public string sTrnsprtrDocConsigneeCountryCd { get; set; }
        public string sTrnsprtrDocConsigneePostCd { get; set; }
        public string sTrnsprtrDocNameOfAnyOtherNotFdParty { get; set; }
        public string sTrnsprtrDocPANOfNotFdParty { get; set; }
        public string sTrnsprtrDocTypeOfNotFdPartyCd { get; set; }
        public string sTrnsprtrDocNotFdPartyStreetAddress { get; set; }
        public string sTrnsprtrDocNotFdPartyCity { get; set; }
        public string sTrnsprtrDocNotFdPartyCountrySubDivName { get; set; }
        public string sTrnsprtrDocNotFdPartyCountrySubDiv { get; set; }
        public string sTrnsprtrDocNotFdPartyCountryCd { get; set; }
        public string sTrnsprtrDocNotFdPartyPostCd { get; set; }
        public string sTrnsprtrDocGoodsDescAsPerBill { get; set; }
        public string sTrnsprtrDocUCRType { get; set; }
        public string sTrnsprtrDocUCRCd { get; set; }
        public Nullable<decimal> dTrnsprtrDocMsrNoOfPackages { get; set; }
        public string sTrnsprtrDocMsrTypesOfPackages { get; set; }
        public string sTrnsprtrDocMsrMarksNoOnPackages { get; set; }
        public Nullable<decimal> dTrnsprtrDocMsrGrossWeight { get; set; }
        public Nullable<decimal> dTrnsprtrDocMsrNetWeight { get; set; }
        public string sTrnsprtrDocMsrUnitOfWeight { get; set; }
        public Nullable<decimal> dTrnsprtrDocMsrGrossVolume { get; set; }
        public string sTrnsprtrDocMsrUnitOfVolume { get; set; }
        public Nullable<decimal> dTrnsprtrDocMsrInvoiceValueOfConsigment { get; set; }
        public string sTrnsprtrDocMsrCurrencyCd { get; set; }
        public string sSuplmntryDecCinType { get; set; }
        public string sSuplmntryDecMCinPCin { get; set; }
        public string sSuplmntryDecCSNSubmtdType { get; set; }
        public string sSuplmntryDecCSNSubmtdBy { get; set; }
        public string sSuplmntryDecCSNReportingType { get; set; }
        public string sSuplmntryDecCSNSiteId { get; set; }
        public Nullable<decimal> dSuplmntryDecCSNNo { get; set; }
        public Nullable<System.DateTime> dtSuplmntryDecCSNDate { get; set; }
        public string sSuplmntryDecPrevMCIN { get; set; }
        public string sSuplmntryDecSplitIndicator { get; set; }
        public Nullable<decimal> dSuplmntryDecNoOfPackages { get; set; }
        public string sSuplmntryDecTypeOfPackages { get; set; }
        public Nullable<System.DateTime> dtActionDate { get; set; }
        public Nullable<int> iActionBy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblAdditionalDetailsHouseCargoMap> tblAdditionalDetailsHouseCargoMaps { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblHouseCargoDescriptionMasterConsignmentMap> tblHouseCargoDescriptionMasterConsignmentMaps { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblItemDetailsHouseCargoMap> tblItemDetailsHouseCargoMaps { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblItemDetailsMasterConsignmentMap> tblItemDetailsMasterConsignmentMaps { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblItineraryHouseCargoMap> tblItineraryHouseCargoMaps { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblItineraryMasterConsignmentMap> tblItineraryMasterConsignmentMaps { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSupportDocHouseCargoMap> tblSupportDocHouseCargoMaps { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSupportDocMasterConsignmentMap> tblSupportDocMasterConsignmentMaps { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblTransportEquipmentHouseCargoMap> tblTransportEquipmentHouseCargoMaps { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblTransportEquipmentMasterConsignmentMap> tblTransportEquipmentMasterConsignmentMaps { get; set; }
        public virtual tblMessageImplementation tblMessageImplementation { get; set; }
    }
}
