using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Models
{
    public class PortModel
    {
        public string sReportingEvent { get; set; }
        public int iPortId { get; set; }
        [Display(Name = "Port Code")]
        [Required(ErrorMessage = "Port Code is a required field.")]
        [MaxLength(10, ErrorMessage = "Port Code cannot exceed 10 character.")]
        public string sPortCode { get; set; }
        [Display(Name = "Port Description")]
        [Required(ErrorMessage = "Port Description is a required field.")]
        [MaxLength(100, ErrorMessage = "Port Description cannot exceed 100 character.")]
        public string sPortDescription { get; set; }
        [Display(Name = "Country")]
        [Required(ErrorMessage = "Country is a required field.")]
        public string sCountryCode { get; set; }
        [Display(Name = "State")]
        [Required(ErrorMessage = "State is a required field.")]
        public string SstateCode { get; set; }
    }
}
