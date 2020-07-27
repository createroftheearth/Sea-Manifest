using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Models
{
    public class SupportDocMasterConsignmentModel
    {
        public string sReportingEvent { get; set; }

        public int iSupportDocsId { get; set; }
        public int? iMasterConsignmentId { get; set; }
        public int? iMessageImplementationId { get; set; }
        [Display(Name = "Tag Ref")]
        [MaxLength(5, ErrorMessage = "Tag Ref cannot exceed 5 character.")]
        [Required(ErrorMessage = "Tag Ref is a required field.")]
        public string sTagRef { get; set; }
        [Display(Name = "Ref Serial No.")]
        [MaxLength(2, ErrorMessage = "Ref Serial No. cannot exceed 2 character.")]
        [Required(ErrorMessage = "Ref Serial No. is a required field.")]
        public string sRefSerialNo { get; set; }
        [Display(Name = "Sub Ref Serial No. Ref")]
        [MaxLength(2, ErrorMessage = "Sub Ref Serial No. Ref cannot exceed 2 character.")]
        [Required(ErrorMessage = "Sub Ref Serial No. Ref is a required field.")]
        public string sSubSerialNoRef { get; set; }
        [Display(Name = "Ice gate User Id")]
        [MaxLength(15, ErrorMessage = "Ice gate User Id cannot exceed 15 character.")]
        [Required(ErrorMessage = "Icegate User Id is a required field.")]
        public string sIcegateUserId { get; set; }
        [Display(Name = "IRN No.")]
        [MaxLength(3, ErrorMessage = "IRN No. cannot exceed 3 character.")]
        [Required(ErrorMessage = "IRN No. is a required field.")]
        public string sIRNNo { get; set; }
        [Display(Name = "Doc Ref No.")]
        [MaxLength(3, ErrorMessage = "Doc Ref No. cannot exceed 3 character.")]
        [Required(ErrorMessage = "Doc Ref No. is a required field.")]
        public string sDocRefNo { get; set; }
        [Display(Name = "Doc Type Cd")]
        [MaxLength(6, ErrorMessage = "Doc Type Cd cannot exceed 6 character.")]
        [Required(ErrorMessage = "Doc Type Cd is a required field.")]
        public string sDocTypeCd { get; set; }
        [Display(Name = "Beneficiary Cd")]
        [MaxLength(35, ErrorMessage = "Beneficiary Cd cannot exceed 35 character.")]
        [Required(ErrorMessage = "Beneficiary Cd is a required field.")]
        public string sBeneficiaryCd { get; set; }

    }
}
