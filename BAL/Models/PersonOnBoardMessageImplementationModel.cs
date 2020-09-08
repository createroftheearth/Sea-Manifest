using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Models
{
    public class PersonOnBoardMessageImplementationModel
    {
        public string sReportingEvent { get; set; }


        public int iPersonOnBoardId { get; set; }
        public int? iMessageImplementationId { get; set; }
        [Display(Name = "Person On Baord Seq No")]
        [Required(ErrorMessage = "Person On Baord Seq No is a required field.")]
        public decimal? dPersonOnBaordSeqNo { get; set; }
        [Display(Name = "Person Type")]
        [MaxLength(3, ErrorMessage = "Person Type cannot exceed 3 character.")]
        [Required(ErrorMessage = "Person Type is a required field.")]

        public string sPersonDetailsPersonTypeCdd { get; set; }
        [Display(Name = "Person Family Name")]
        [Required(ErrorMessage = "Person Family Name is a required field.")]
        [MaxLength(70, ErrorMessage = "Person Family Name cannot exceed 70 character.")]
        public string sPersonDetailsPersonFamilyName { get; set; }
        [Display(Name = "Person Given Name")]
        [Required(ErrorMessage = "Person Given Name is a required field.")]
        [MaxLength(70, ErrorMessage = "Person Given Name cannot exceed 70 character.")]
        public string sPersonDetailsPersonGivenName { get; set; }
        [Display(Name = "Person Nationality")]
        [Required(ErrorMessage = "Person Nationality is a required field.")]
        [MaxLength(2, ErrorMessage = "Person Nationality cannot exceed 2 character.")]
        public string sPersonDetailsPersonNationalityCdd { get; set; }
        [Display(Name = "Passengers In Transit Indicator")]
        [Required(ErrorMessage = "Passengers In Transit Indicator is a required field.")]
        public decimal? dPersonDetailsPassengersInTransitIndicator { get; set; }
        [Display(Name = "Crew Member Rank Or Rating Name")]
        [MaxLength(70, ErrorMessage = "Crew Member Rank Or Rating Name cannot exceed 70 character.")]
        public string sPersonDetailsCrewMemberRankOrRatingName { get; set; }
        [Display(Name = "Crew Member Rank Or Rating")]
        [MaxLength(10, ErrorMessage = "Crew Member Rank Or Rating cannot exceed 10 character.")]
        public string sPersonDetailsCrewMemberRankOrRatingCdd { get; set; }
        [Display(Name = "Passanger Part Of Embark Tn Cdd")]
        [MaxLength(5, ErrorMessage = "Passanger Part Of Embark Tn Cdd cannot exceed 5 character.")]
        public string sPersonDetailsPassangerPartOfEmbarkTnCdd { get; set; }
        [Display(Name = "Passanger Part Of Embark Tn Name")]
        [MaxLength(256, ErrorMessage = "Passanger Part Of Embark Tn Name cannot exceed 256 character.")]
        public string sPersonDetailsPassangerPartOfEmbarkTnName { get; set; }
        [Display(Name = "Passanger Part Of Dsmbark Tn Cdd")]
        [MaxLength(5, ErrorMessage = "Passanger Part Of Dsmbark Tn Cdd cannot exceed 5 character.")]
        public string sPersonDetailsPassangerPartOfDsmbarkTnCdd { get; set; }
        [Display(Name = "Passanger Part Of Dsmbark Tn Name")]
        [MaxLength(256, ErrorMessage = "Passanger Part Of Dsmbark Tn Name cannot exceed 256 character.")]
        public string sPersonDetailsPassangerPartOfDsmbarkTnName { get; set; }
        [Display(Name = "Person Gender Cdd")]
        [Required(ErrorMessage = "Person Gender is a required field.")]
        [MaxLength(3, ErrorMessage = "Person Gender Cdd cannot exceed 3 character.")]
        public string sPersonDetailsPersonGenderCdd { get; set; }
        [Display(Name = "Person Date Of Birth")]
        [Required(ErrorMessage = "Person Date Of Birth is a required field.")]

        public string dtPersonDetailsPersonDateOfBirth { get; set; }
        [Display(Name = "Person Place Of Birth Name")]
        [Required(ErrorMessage = "Person Place Of Birth Name is a required field.")]
        [MaxLength(35, ErrorMessage = "Person Place Of Birth Name cannot exceed 35 character.")]
        public string sPersonDetailsPersonPlaceOfBirthName { get; set; }
        [Display(Name = "Person Country Of Birth Cdd")]
        [Required(ErrorMessage = "Person Country Of Birth Name is a required field.")]
        [MaxLength(2, ErrorMessage = "Person Country Of Birth Cdd Name cannot exceed 2 character.")]
        public string sPersonDetailsPersonCountryOfBirthCdd { get; set; }
        [Display(Name = "Person Id Doc Expiry Date")]
        public string dtPersonIdDocExpiryDate { get; set; }
        [Display(Name = "Person Id Or Travel Doc Issuing Nation Cdd")]
        [MaxLength(2, ErrorMessage = "Person Id Or Travel Doc Issuing Nation Cdd cannot exceed 2 character.")]
        public string sPersonIdOrTravelDocIssuingNationCdd { get; set; }
        [Display(Name = "Person Id Or Travel Doc No")]
        [MaxLength(70, ErrorMessage = "Person Id Or Travel Doc No cannot exceed 70 character.")]
        public string sPersonIdOrTravelDocNo { get; set; }
        [Display(Name = "Person Id Or Travel Doc Type Cdd")]
        [MaxLength(3, ErrorMessage = "Person Id Or Travel Doc Type Cdd cannot exceed 3 character.")]
        public string sPersonIdOrTravelDocTypeCdd { get; set; }
        [Display(Name = "Visa Details Person Visa")]
        [Required(ErrorMessage = "Visa Details Person Visa is a required field.")]
        [MaxLength(70, ErrorMessage = "Visa Details Person Visa cannot exceed 70 character.")]
        public string sVisaDetailsPersonVisa { get; set; }
        [Display(Name = "Visa Details PNR No")]
        [Required(ErrorMessage = "Visa Details PNR No is a required field.")]
        [MaxLength(20, ErrorMessage = "Visa Details PNR No cannot exceed 20 character.")]
        public string sVisaDetailsPNRNo { get; set; }

    }
}
