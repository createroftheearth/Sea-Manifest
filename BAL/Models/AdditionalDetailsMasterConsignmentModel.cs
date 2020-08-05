using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Models
{
    public class AdditionalDetailsMasterConsignmentModel
    {
        public string sReportingEvent { get; set; }

        public int? iAdditionalDetailsId { get; set; }
        public int? iMasterConsignmentId { get; set; }
        public int? iMessageImplementationId { get; set; }
        [Display(Name = "Tag Ref")]
        [MaxLength(5, ErrorMessage = "Tag Ref cannot exceed 5 character.")]
        [Required(ErrorMessage = "Tag Ref is a required field.")]
        public string sTagRef { get; set; }
        [Display(Name = "Ref Serial No.")]
        [Required(ErrorMessage = "Ref Serial No. is a required field.")]
        [Range(0,99999,ErrorMessage ="Ref Serial No should be in range between 0 to 99999")]
        public decimal dRefSerialNo { get; set; }
        [Display(Name = "Info Type")]
        [MaxLength(10, ErrorMessage = "Info Type cannot exceed 10 character.")]
        [Required(ErrorMessage = "Info Type is a required field.")]
        public string sInfoType { get; set; }
        [Display(Name = "Info Qualifier")]
        [MaxLength(10, ErrorMessage = "Info Qualifier cannot exceed 10 character.")]
        [Required(ErrorMessage = "Info Qualifier is a required field.")]
        public string sInfoQualifier { get; set; }
        [Display(Name = "Info Code")]
        [MaxLength(35, ErrorMessage = "Info Code cannot exceed 35 character.")]
        [Required(ErrorMessage = "Info Code is a required field.")]
        public string sInfoCd { get; set; }
        [Display(Name = "Info Text ")]
        [MaxLength(100, ErrorMessage = "Info Text cannot exceed 100 character.")]
        [Required(ErrorMessage = "Info Text is a required field.")]
        public string sInfoText { get; set; }
        [Display(Name = "Info MSR")]
        [MaxLength(5, ErrorMessage = "Info MSR cannot exceed 5 character.")]
        [Required(ErrorMessage = "Info MSR is a required field.")]
        public string sInfoMsr { get; set; }
        [Display(Name = "Info Date")]
        [Required(ErrorMessage = "Info Date is a required field.")]
        public string sInfoDate { get; set; }
    }
}
