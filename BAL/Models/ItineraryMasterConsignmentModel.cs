using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Models
{
    public class ItineraryMasterConsignmentModel
    {
        public string sReportingEvent { get; set; }

        public int iItineraryId { get; set; }
        public int? iMasterConsignmentId { get; set; }
        public int? iMessageImplementationId { get; set; }
        [Display(Name = "Port Of Call Sequence No.")]
        public decimal dPortOfCallSequenceNo { get; set; }
        [Display(Name = "Port Of Call CD")]
        [MaxLength(10, ErrorMessage = "Port Of Call CD cannot exceed 10 character.")]
        public string sPortOfCallCd { get; set; }
        [Display(Name = "Port Of Call Name")]
        [MaxLength(256, ErrorMessage = "Port Of Call Name cannot exceed 256 character.")]
        public string sPortOfCallName { get; set; }
        [Display(Name = "Next Port Of Call CDD")]
        [MaxLength(10, ErrorMessage = "Next Port Of Call CDD cannot exceed 10 character.")]
        public string sNextPortOfCallCdd { get; set; }
        [Display(Name = "Next Port Of Call Name")]
        [MaxLength(256, ErrorMessage = "Next Port Of Call Name cannot exceed 256 character.")]
        public string sNextPortOfCallName { get; set; }
        [Display(Name = "Mode Of Transport")]
        [MaxLength(1, ErrorMessage = "Mode Of Transport cannot exceed 1 character.")]
        public string sModeOfTransport { get; set; }
    }
}
