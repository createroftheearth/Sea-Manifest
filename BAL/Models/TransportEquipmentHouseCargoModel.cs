using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Models
{
    public class TransportEquipmentHouseCargoModel
    {
        public string sReportingEvent { get; set; }

        public int iTransporterEquipmentId { get; set; }
        public int? iMasterConsignmentId { get; set; }
        public int? iHouseCargoDescId { get; set; }
        [Display(Name = "Equipment Sequence No.")]
        [Required(ErrorMessage = "Equipment Sequence No. is a required field.")]
        public int iEquipmentSequenceNo { get; set; }
        [Display(Name = "Equipment Id")]
        [MaxLength(17, ErrorMessage = "Equipment Id cannot exceed 17 character.")]
        [Required(ErrorMessage = "Equipment Id is a required field.")]
        public string sEquipmentId { get; set; }
        [Display(Name = "Equipment Type")]
        [MaxLength(3, ErrorMessage = "Equipment Type cannot exceed 3 character.")]
        [Required(ErrorMessage = "Equipment Type is a required field.")]
        public string sEquipmentType { get; set; }
        [Display(Name = "Equipment Size")]
        [MaxLength(4, ErrorMessage = "Equipment Size cannot exceed 4 character.")]
        [Required(ErrorMessage = "Equipment Size is a required field.")]
        public string sEquipmentSize { get; set; }
        [Display(Name = "Equipment Load Status")]
        [MaxLength(3, ErrorMessage = "Equipment Load Status cannot exceed 3 character.")]
        [Required(ErrorMessage = "Equipment Load Status is a required field.")]
        public string sEquipmentLoadStatus { get; set; }
        [Display(Name = "Additional Equipment Hold")]
        [MaxLength(256, ErrorMessage = "Additional Equipment Hold cannot exceed 256 character.")]
        [Required(ErrorMessage = "Additional Equipment Hold is a required field.")]
        public string sAdditionalEquipmentHold { get; set; }
        [Display(Name = "Event Date")]
        [Required(ErrorMessage = "Event Date is a required field.")]
        public string sEventDate { get; set; }
        [Display(Name = "Equipment Seal Type")]
        [MaxLength(5, ErrorMessage = "Equipment Seal Type cannot exceed 5 character.")]
        [Required(ErrorMessage = "Equipment Seal Type is a required field.")]
        public string sEquipmentSealType { get; set; }
        [Display(Name = "Equipment Seal No.")]
        [MaxLength(15, ErrorMessage = "Equipment Seal No. cannot exceed 15 character.")]
        [Required(ErrorMessage = "Equipment Seal No. is a required field.")]
        public string sEquipmentSealNo { get; set; }
        [Display(Name = "Other Equipment Id")]
        [MaxLength(256, ErrorMessage = "Other Equipment Id cannot exceed 256 character.")]
        [Required(ErrorMessage = "Other Equipment Id is a required field.")]
        public string sOtherEquipmentId { get; set; }
        [Display(Name = "SOC Flag")]
        [MaxLength(1, ErrorMessage = "SOC Flag cannot exceed 1 character.")]
        [Required(ErrorMessage = "SOC Flag is a required field.")]
        public string sSOCFlag { get; set; }
        [Display(Name = "Container Agent Cd")]
        [MaxLength(17, ErrorMessage = "Container Agent Cd cannot exceed 17 character.")]
        [Required(ErrorMessage = "Container Agent Cd is a required field.")]
        public string sContainerAgentCd { get; set; }
        [Display(Name = "Container Weight")]
        [Required(ErrorMessage = "Container Weight is a required field.")]
        public decimal dContainerWeight { get; set; }
        [Display(Name = "Total No Of Packages")]
        [Required(ErrorMessage = "Total No Of Packages is a required field.")]
        public decimal dTotalNoOfPackages { get; set; }
    }
}
