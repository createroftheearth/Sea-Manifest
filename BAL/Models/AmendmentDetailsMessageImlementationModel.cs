using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Models
{
    public class AmendmentDetailsMessageImlementationModel
    {
        public string sReportingEvent { get; set; }
        public int iAmendmentId { get; set; }
        public int? iMessageImplementationId { get; set; }
        [Display(Name = "Amendment Ref No.")]
         [MaxLength(15, ErrorMessage = "Amendment Ref No. cannot exceed 15 character.")]
        public string sAmendRefNo { get; set; }
        [Display(Name = "Amendment Flag")]
        [MaxLength(2, ErrorMessage = "Amendment Flag cannot exceed 2 character.")]
        public string sAmendFlag { get; set; }
        [Display(Name = "Amendment Type")]
        [MaxLength(10, ErrorMessage = "Amendment Type cannot exceed 10 character.")]
        public string sAmendType { get; set; }

    }
}
