using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Models
{
    public class TransportEquipmentMasterConsignmentModel
    {
        public string sReportingEvent { get; set; }

        public int iTransporterEquipmentId { get; set; }
        public int? iMessageImplementationId { get; set; }
        public int? iMasterConsignmentId { get; set; }
        [Display(Name = "Equipment Sequence No.")]
        [Required(ErrorMessage = "Equipment Sequence No. is a required field.")]
        public int iEquipmentSequenceNo { get; set; }
        [Display(Name = "Equipment Id")]
        [MaxLength(17, ErrorMessage = "Equipment Id cannot exceed 17 character.")]
        public string sEquipmentId { get; set; }
        [Display(Name = "Equipment Type")]
        [MaxLength(3, ErrorMessage = "Equipment Type cannot exceed 3 character.")]
        public string sEquipmentType { get; set; }
        [Display(Name = "Equipment Size")]
        [MaxLength(4, ErrorMessage = "Equipment Size cannot exceed 4 character.")]
        public string sEquipmentSize { get; set; }
        [Display(Name = "Equipment Load Status")]
        [MaxLength(3, ErrorMessage = "Equipment Load Status cannot exceed 3 character.")]
        public string sEquipmentLoadStatus { get; set; }
        [Display(Name = "Additional Equipment Hold")]
        [MaxLength(256, ErrorMessage = "Additional Equipment Hold cannot exceed 256 character.")]
        public string sAdditionalEquipmentHold { get; set; }
        [Display(Name = "Equipment Seal Type")]
        [MaxLength(5, ErrorMessage = "Equipment Seal Type cannot exceed 5 character.")]
        public string sEquipmentSealType { get; set; }
        [Display(Name = "Equipment Seal No.")]
        [MaxLength(15, ErrorMessage = "Equipment Seal No. cannot exceed 15 character.")]
        public string sEquipmentSealNo { get; set; }
        [Display(Name = "Other Equipment Id")]
        [MaxLength(256, ErrorMessage = "Other Equipment Id cannot exceed 256 character.")]
        public string sOtherEquipmentId { get; set; }
        [Display(Name = "SOC Flag")]
        [MaxLength(1, ErrorMessage = "SOC Flag cannot exceed 1 character.")]
        public string sSOCFlag { get; set; }
        [Display(Name = "Container Agent Cd")]
        [MaxLength(17, ErrorMessage = "Container Agent Cd cannot exceed 17 character.")]
        public string sContainerAgentCd { get; set; }
        [Display(Name = "Container Weight")]
        public decimal dContainerWeight { get; set; }
        [Display(Name = "Total No Of Packages")]
        public decimal dTotalNoOfPackages { get; set; }
    }
}
