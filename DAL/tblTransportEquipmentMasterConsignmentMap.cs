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
    
    public partial class tblTransportEquipmentMasterConsignmentMap
    {
        public int iTransporterEquipmentId { get; set; }
        public Nullable<int> iMasterConsignmentId { get; set; }
        public Nullable<int> iMessageImplementationId { get; set; }
        public Nullable<int> iEquipmentSequenceNo { get; set; }
        public string sEquipmentId { get; set; }
        public string sEquipmentType { get; set; }
        public string sEquipmentSize { get; set; }
        public string sEquipmentLoadStatus { get; set; }
        public string sAdditionalEquipmentHold { get; set; }
        public string sEquipmentSealType { get; set; }
        public string sEquipmentSealNo { get; set; }
        public string sOtherEquipmentId { get; set; }
        public string sSOCFlag { get; set; }
        public string sContainerAgentCd { get; set; }
        public Nullable<decimal> dContainerWeight { get; set; }
        public Nullable<decimal> dTotalNoOfPackages { get; set; }
        public Nullable<System.DateTime> dtActionDate { get; set; }
        public Nullable<int> iActionBy { get; set; }
    
        public virtual tblMasterConsignmentMessageImplementationMap tblMasterConsignmentMessageImplementationMap { get; set; }
        public virtual tblMessageImplementation tblMessageImplementation { get; set; }
    }
}
