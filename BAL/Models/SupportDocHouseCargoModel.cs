using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Models
{
    public class SupportDocHouseCargoModel
    {
        public string sReportingEvent { get; set; }

        public int iSupportDocsId { get; set; }
        public int? iMasterConsignmentId { get; set; }
        public int? iHouseCargoDescId { get; set; }
        [Display(Name = "Tag Ref")]
        [MaxLength(5, ErrorMessage = "Tag Ref cannot exceed 5 character.")]
        public string sTagRef { get; set; }
        [Display(Name = "Ref Serial No.")]
        [MaxLength(2, ErrorMessage = "Ref Serial No. cannot exceed 2 character.")]
        public string sRefSerialNo { get; set; }
        [Display(Name = "Sub Ref Serial No. Ref")]
        [MaxLength(2, ErrorMessage = "Sub Ref Serial No. Ref cannot exceed 2 character.")]
        public string sSubSerialNoRef { get; set; }
        [Display(Name = "Ice gate User Id")]
        [MaxLength(15, ErrorMessage = "Ice gate User Id cannot exceed 15 character.")]
        public string sIcegateUserId { get; set; }
        [Display(Name = "IRN No.")]
        [MaxLength(3, ErrorMessage = "IRN No. cannot exceed 3 character.")]
        public string sIRNNo { get; set; }
        [Display(Name = "Doc Ref No.")]
        [MaxLength(3, ErrorMessage = "Doc Ref No. cannot exceed 3 character.")]
        public string sDocRefNo { get; set; }
        [Display(Name = "Doc Type Code")]
        [MaxLength(6, ErrorMessage = "Doc Type Code cannot exceed 6 character.")]
        public string sDocTypeCd { get; set; }
        [Display(Name = "Beneficiary Code")]
        [MaxLength(35, ErrorMessage = "Beneficiary Code cannot exceed 35 character.")]
        public string sBeneficiaryCd { get; set; }

    }
}
