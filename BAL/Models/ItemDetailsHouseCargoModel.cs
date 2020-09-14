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

        public int? iItemsDetailsId { get; set; }
        public int? iMasterConsignmentId { get; set; }
        public int? iHouseCargoDescId { get; set; }
        [Display(Name = "Cargo Item Sequence No.")]
        [Required(ErrorMessage = "Cargo Item Sequence No. is a required field.")]
        public decimal dCargoItemSequenceNo { get; set; }
        [Display(Name = "HS Code")]
        [MaxLength(8, ErrorMessage = "HS Code cannot exceed 8 character.")]
        [Required(ErrorMessage = "HS Code is a required field.")]
        public string sHsCd { get; set; }
        [Display(Name = "Cargo Item Description")]
        [MaxLength(256, ErrorMessage = "Cargo Item Description cannot exceed 256 character.")]
        public string sCargoItemDesc { get; set; }
        [Display(Name = "UNO Code")]
        [MaxLength(5, ErrorMessage = "UNO Code cannot exceed 5 character.")]
        [Required(ErrorMessage = "UNO Code is a required field.")]
        public string sUnoCd { get; set; }
        [Display(Name = "IMDG Code")]
        [MaxLength(3, ErrorMessage = "IMDG Code cannot exceed 3 character.")]
        [Required(ErrorMessage = "IMDG Code is a required field.")]
        public string sIMDGCd { get; set; }
        [Display(Name = "No Of Pakages")]
        public decimal dNoOfPakages { get; set; }
        [Display(Name = "Types Of Packages")]
        [MaxLength(3, ErrorMessage = "Types Of Packages cannot exceed 3 character.")]
        public string sTypesOfPackages { get; set; }
    }
}
