using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Models
{
    public class HeaderFieldModel
    {
        public int iMessageImplementationId { get; set; }
        [Display(Name = "Sender ID")]
        [MaxLength(30,ErrorMessage ="Sender ID cannot exceed 30 character.")]
        [Required(ErrorMessage = "Sender ID is a required field.")]
        public string sSenderID { get; set; }
        [Display(Name = "Receiver ID")]
        [MaxLength(30, ErrorMessage = "Receiver ID cannot exceed 30 character.")]
        [Required(ErrorMessage = "Receiver ID is a required field.")]
        public string sReceiverID { get; set; }
        [Display(Name = "Version No")]
        [MaxLength(7, ErrorMessage = "Version No cannot exceed 1 character.")]
        [Required(ErrorMessage = "Version No is a required field.")]
        public string sVersionNo { get; set; }
        [Display(Name = "Indicator")]
        [MaxLength(1, ErrorMessage = "Indicator cannot exceed 1 character.")]
        [Required(ErrorMessage = "Indicator is a required field.")]
        public string sIndicator { get; set; }
        [Display(Name = "Message ID")]
        [MaxLength(7, ErrorMessage = "Message ID cannot exceed 7 character.")]
        [Required(ErrorMessage = "Message ID is a required field.")]
        public string sMessageID { get; set; }
        [Display(Name = "SequenceOrControlNumber")]
        [MaxLength(18, ErrorMessage = "SequenceOrControlNumber cannot exceed 18 character.")]
        [Required(ErrorMessage = "SequenceOrControlNumber is a required field.")]
        public string sSequenceOrControlNumber { get; set; }
        [Display(Name = "Date")]
        [Required(ErrorMessage = "Date is a required field.")] 
        public string sDate { get; set; }
        [Display(Name = "Time")]
        [Required(ErrorMessage = "Time is a required field.")]
        public string sTime { get; set; }
        [Display(Name = "Reporting Event")]
        [MaxLength(4, ErrorMessage = "Reporting Event cannot exceed 4 character.")]
        [Required(ErrorMessage = "Reporting Event is a required field.")]
        public string sReportingEvent { get; set; }

    }
}
