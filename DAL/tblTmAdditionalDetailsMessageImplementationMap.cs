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
    
    public partial class tblTmAdditionalDetailsMessageImplementationMap
    {
        public int iTmAdditionalDetailsId { get; set; }
        public Nullable<int> iMessageImplementationId { get; set; }
        public string sTagRef { get; set; }
        public Nullable<decimal> dRefSerialNo { get; set; }
        public string sInfoType { get; set; }
        public string sInfoQualifier { get; set; }
        public string sInfoCd { get; set; }
        public string sInfoText { get; set; }
        public string sInfoMsr { get; set; }
        public Nullable<System.DateTime> dtInfoDate { get; set; }
        public Nullable<System.DateTime> dtActionDate { get; set; }
        public Nullable<int> iActionBy { get; set; }
    
        public virtual tblMessageImplementation tblMessageImplementation { get; set; }
    }
}
