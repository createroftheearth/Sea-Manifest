using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Models
{
    public class ItineraryHouseCargoModel
    {
        public string sReportingEvent { get; set; }

        public int iItineraryId { get; set; }
        public int? iMasterConsignmentId { get; set; }
        public int? iHouseCargoDescId { get; set; }
        [Display(Name = "Port Of Call Sequence No.")]
        [Required(ErrorMessage = "Port Of Call Sequence No. is a required field.")]
        public decimal dPortOfCallSequenceNo { get; set; }
        [Display(Name = "Port Of Call Code")]
        [MaxLength(10, ErrorMessage = "Port Of Call Code cannot exceed 10 character.")]
        [Required(ErrorMessage = "Port Of Call Code is a required field.")]
        public string sPortOfCallCd { get; set; }
        [Display(Name = "Port Of Call Name")]
        [MaxLength(10, ErrorMessage = "Port Of Call Name cannot exceed 10 character.")]
        [Required(ErrorMessage = "Port Of Call Name is a required field.")]
        public string sPortOfCallName { get; set; }
        [Display(Name = "Next Port Of Call Code")]
        [MaxLength(10, ErrorMessage = "Next Port Of Call Code cannot exceed 10 character.")]
        [Required(ErrorMessage = "Next Port Of Call Code is a required field.")]
        public string sNextPortOfCallCdd { get; set; }
        [Display(Name = "Next Port Of Call Name")]
        [MaxLength(256, ErrorMessage = "Next Port Of Call Name cannot exceed 256 character.")]
        [Required(ErrorMessage = "Next Port Of Call Name is a required field.")]
        public string sNextPortOfCallName { get; set; }
        [Display(Name = "Mode Of Transport")]
        [MaxLength(1, ErrorMessage = "Mode Of Transport cannot exceed 1 character.")]
        [Required(ErrorMessage = "Mode Of Transport is a required field.")]
        public string sModeOfTransport { get; set; }
    }
}
