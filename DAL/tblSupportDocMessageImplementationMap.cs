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
    
    public partial class tblSupportDocMessageImplementationMap
    {
        public int iSupportDocsId { get; set; }
        public Nullable<int> iMessageImplementationId { get; set; }
        public string sTagRef { get; set; }
        public string sRefSerialNo { get; set; }
        public string sSubSerialNoRef { get; set; }
        public string sIcegateUserId { get; set; }
        public string sIRNNo { get; set; }
        public string sDocRefNo { get; set; }
        public string sDocTypeCd { get; set; }
        public string sBeneficiaryCd { get; set; }
        public Nullable<System.DateTime> dtActionDate { get; set; }
        public Nullable<int> iActionBy { get; set; }
    
        public virtual tblMessageImplementation tblMessageImplementation { get; set; }
    }
}