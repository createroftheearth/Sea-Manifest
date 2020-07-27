using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Models
{
    public class ItemDetailsHouseCargoModel
    {
        public string sReportingEvent { get; set; }

        public int iItemsDetailsId { get; set; }
        public int? iMasterConsignmentId { get; set; }
        public int? iHouseCargoDescId { get; set; }
        [Display(Name = "Cargo Item Sequence No.")]
        [Required(ErrorMessage = "Cargo Item Sequence No. is a required field.")]
        public decimal dCargoItemSequenceNo { get; set; }
        [Display(Name = "HS CD")]
        [MaxLength(8, ErrorMessage = "HS CD cannot exceed 8 character.")]
        [Required(ErrorMessage = "HS CD is a required field.")]
        public string sHsCd { get; set; }
        [Display(Name = "Cargo Item Description")]
        [MaxLength(256, ErrorMessage = "Cargo Item Description cannot exceed 256 character.")]
        [Required(ErrorMessage = "Cargo Item Description is a required field.")]
        public string sCargoItemDesc { get; set; }
        [Display(Name = "Uno Code")]
        [MaxLength(5, ErrorMessage = "Uno Code cannot exceed 5 character.")]
        [Required(ErrorMessage = "Uno Code is a required field.")]
        public string sUnoCd { get; set; }
        [Display(Name = "IMDG CD")]
        [MaxLength(5, ErrorMessage = "IMDG CD cannot exceed 5 character.")]
        [Required(ErrorMessage = "IMDG CD is a required field.")]
        public string sIMDGCd { get; set; }
        [Display(Name = "No Of Pakages")]
        [Required(ErrorMessage = "No Of Pakages is a required field.")]
        public decimal dNoOfPakages { get; set; }
        [Display(Name = "Types Of Packages")]
        [MaxLength(5, ErrorMessage = "Types Of Packages cannot exceed 5 character.")]
        [Required(ErrorMessage = "Types Of Packages is a required field.")]
        public string sTypesOfPackages { get; set; }
    }
}
