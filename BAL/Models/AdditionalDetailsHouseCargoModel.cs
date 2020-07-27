﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Models
{
    public class AdditionalDetailsHouseCargoModel
    {
        public string sReportingEvent { get; set; }

        public int iAdditionalDetailsId { get; set; }
        public int? iMasterConsignmentId { get; set; }
        public int? iHouseCargoDescId { get; set; }
        [Display(Name = "Tag Ref")]
        [MaxLength(2, ErrorMessage = "Tag Ref cannot exceed 2 character.")]
        [Required(ErrorMessage = "Tag Ref is a required field.")]
        public string sTagRef { get; set; }
        [Display(Name = "Ref Serial No.")]
        [MaxLength(2, ErrorMessage = "Ref Serial No. cannot exceed 2 character.")]
        [Required(ErrorMessage = "Ref Serial No. is a required field.")]
        public string sRefSerialNo { get; set; }
        [Display(Name = "Info Type")]
        [MaxLength(2, ErrorMessage = "Info Type cannot exceed 2 character.")]
        [Required(ErrorMessage = "Info Type is a required field.")]
        public string sInfoType { get; set; }
        [Display(Name = "Info Qualifier")]
        [MaxLength(2, ErrorMessage = "Info Qualifier cannot exceed 2 character.")]
        [Required(ErrorMessage = "Info Qualifier is a required field.")]
        public string sInfoQualifier { get; set; }
        [Display(Name = "Info CD")]
        [MaxLength(2, ErrorMessage = "Info CD cannot exceed 2 character.")]
        [Required(ErrorMessage = "Info CD is a required field.")]
        public string sInfoCd { get; set; }
        [Display(Name = "Info Text ")]
        [MaxLength(100, ErrorMessage = "Info Text cannot exceed 100 character.")]
        [Required(ErrorMessage = "Info Text is a required field.")]
        public string sInfoText { get; set; }
        [Display(Name = "Info MSR")]
        [MaxLength(2, ErrorMessage = "Info MSR cannot exceed 2 character.")]
        [Required(ErrorMessage = "Info MSR is a required field.")]
        public string sInfoMsr { get; set; }
        [Display(Name = "Info Date")]
        [Required(ErrorMessage = "Info Date is a required field.")]
        public string sInfoDate { get; set; }
    }
}