using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Models
{
    public class HouseCargoModel
    {
        public int iHouseCargoDescId { get; set; }
        public int? iMasterConsignmentId { get; set; }
        public int? iMessageImplementationId { get; set; }
        [Display(Name = "Sub Line no.")]
        [Required(ErrorMessage = "Sub Line no. is a required field.")]
        public decimal? dHCRefSubLineNo { get; set; }
        [Display(Name = "Ref Bill no.")]
        [MaxLength(3, ErrorMessage = "Ref Bill no. cannot exceed 3 character.")]
        [Required(ErrorMessage = "Ref Bill no. is a required field.")]
        public string sHCRefBillNo { get; set; }
        [Display(Name = "Ref Bill Date")]
        [Required(ErrorMessage = "Ref Bill Date is a required field.")]
        public string sHCRefBillDate { get; set; }
        [Display(Name = "Ref Consolidated Indicator")]
        [MaxLength(4, ErrorMessage = "Ref Consolidated Indicator cannot exceed 4 character.")]
        [Required(ErrorMessage = "Ref Consolidated Indicator is a required field.")]
        public string sHCRefConsolidatedIndicator { get; set; }
        [Display(Name = "Ref Consolidated PAN")]
        [MaxLength(35, ErrorMessage = "Ref Consolidated PAN cannot exceed 35 character.")]
        [Required(ErrorMessage = "Ref Consolidated PAN is a required field.")]
        public string sHCRefConsolidatorPan { get; set; }
        [Display(Name = "Ref Previous Description")]
        [MaxLength(4, ErrorMessage = "Ref Previous Description cannot exceed 4 character.")]
        [Required(ErrorMessage = "Ref Previous Description is a required field.")]
        public string sHCRefPreviousDescription { get; set; }
        [Display(Name = "First Party Of Entry")]
        [MaxLength(6, ErrorMessage = "First Party Of Entry cannot exceed 6 character.")]
        [Required(ErrorMessage = "First Party Of Entry is a required field.")]
        public string sLocCstmFirstPartyOfEntry { get; set; }
        [Display(Name = "Destination Port")]
        [MaxLength(10, ErrorMessage = "Destination Port cannot exceed 10 character.")]
        [Required(ErrorMessage = "First Party Of Entry is a required field.")]
        public string sLocCstmDestinationPort { get; set; }
        [Display(Name = "Port Of Unlanding")]
        [MaxLength(6, ErrorMessage = "Port Of Unlanding cannot exceed 6 character.")]
        [Required(ErrorMessage = "Port Of Unlanding is a required field.")]
        public string sLocCstmNextPortOfUnlading { get; set; }
        [Display(Name = "Type Of Cargo")]
        [MaxLength(2, ErrorMessage = "Type Of Cargo cannot exceed 2 character.")]
        [Required(ErrorMessage = "Type Of Cargo is a required field.")]
        public string sLocCstmTypeOfCargo { get; set; }
        [Display(Name = "Item Type")]
        [MaxLength(2, ErrorMessage = "Item Type cannot exceed 2 character.")]
        [Required(ErrorMessage = "Item Type is a required field.")]
        public string sLocCstmItemType { get; set; }
        [Display(Name = "Cargo Movement")]
        [MaxLength(2, ErrorMessage = "Cargo Movement exceed 2 character.")]
        [Required(ErrorMessage = "Cargo Movement is a required field.")]
        public string sLocCstmCargoMovement { get; set; }
        [Display(Name = "Nature Of Cargo")]
        [MaxLength(4, ErrorMessage = "Nature Of Cargo exceed 4 character.")]
        [Required(ErrorMessage = "Nature Of Cargo is a required field.")]
        public string sLocCstmNatureOfCargo { get; set; }
        [Display(Name = "Split Indicator")]
        [MaxLength(2, ErrorMessage = "Split Indicator exceed 2 character.")]
        [Required(ErrorMessage = "Split Indicator is a required field.")]
        public string sLocCstmSplitIndicator { get; set; }
        [Display(Name = "No. Of Packages")]
        [Required(ErrorMessage = "No. Of Packages is a required field.")]
        public decimal? dLocCstmNoOfPackages { get; set; }
        [Display(Name = "Types Of Packages")]
        [MaxLength(4, ErrorMessage = "Types Of Packages exceed 4 character.")]
        [Required(ErrorMessage = "Types Of Packages is a required field.")]
        public string sLocCstmTypeOfPakages { get; set; }
        [Display(Name = "Transhipper CD")]
        [MaxLength(10, ErrorMessage = "Transhipper CD cannot exceed 10 character.")]
        [Required(ErrorMessage = "Transhipper CD is a required field.")]
        public string sTrnshprTranshipperCd { get; set; }
        [Display(Name = "Transhipper Bond")]
        [MaxLength(10, ErrorMessage = "Transhipper Bond cannot exceed 10 character.")]
        [Required(ErrorMessage = "Transhipper Bond is a required field.")]
        public string sTrnshprTranshipperBond { get; set; }
        [Display(Name = "Party Port Of Accepted CCD")]
        [MaxLength(6, ErrorMessage = "Party Port Of Accepted CCD cannot exceed 6 character.")]
        [Required(ErrorMessage = "Party Port Of Accepted CCD is a required field.")]
        public string sTrnsprtrDocPartyPortOfAcceptedCCd { get; set; }
        [Display(Name = "Party Port Of Accepted Name")]
        [MaxLength(256, ErrorMessage = "Party Port Of Accepted Name cannot exceed 256 character.")]
        [Required(ErrorMessage = "Party Port Of Accepted Name is a required field.")]

        //pending
        public string sTrnsprtrDocPartyPortOfAcceptedName { get; set; }
        public string sTrnsprtrDocPartyPortOfReceiptCcd { get; set; }
        public string sTrnsprtrDocPartyPortOfReceiptName { get; set; }
        public string sTrnsprtrDocPartyConsignorName { get; set; }
        public string sTrnsprtrDocPartyConsignorCd { get; set; }
        public string sTrnsprtrDocPartyConsignorCdType { get; set; }
        public string sTrnsprtrDocPartyConsignorStreetAddress { get; set; }
        public string sTrnsprtrDocPartyConsignorCity { get; set; }
        public string sTrnsprtrDocPartyConsignorCountrySubDivName { get; set; }
        public string sTrnsprtrDocPartyConsignorCountrySubDivCd { get; set; }
        public string sTrnsprtrDocPartyConsignorCountryCd { get; set; }
        public string sTrnsprtrDocPartyConsignorPostCd { get; set; }
        public string sTrnsprtrDocPartyConsigneeName { get; set; }
        public string sTrnsprtrDocPartyConsigneeCd { get; set; }
        public string sTrnsprtrDocPartyTypeOfCd { get; set; }
        public string sTrnsprtrDocPartyConsigneeStreetAddress { get; set; }
        public string sTrnsprtrDocPartyConsigneeCity { get; set; }
        public string sTrnsprtrDocPartyConsigneeCountrySubDivName { get; set; }
        public string sTrnsprtrDocPartyConsigneeCountrySubDiv { get; set; }
        public string sTrnsprtrDocPartyConsigneeCountryCd { get; set; }
        public string sTrnsprtrDocPartyConsigneePostCd { get; set; }
        public string sTrnsprtrDocPartyNameOfAnyOtherNotFdParty { get; set; }
        public string sTrnsprtrDocPartyPANOfNotFdParty { get; set; }
        public string sTrnsprtrDocPartyTypeOfNotFdPartyCd { get; set; }
        public string sTrnsprtrDocPartyNotFdPartyStreetAddress { get; set; }
        public string sTrnsprtrDocPartyNotFdPartyCity { get; set; }
        public string sTrnsprtrDocPartyNotFdPartyCountrySubDivName { get; set; }
        public string sTrnsprtrDocPartyNotFdPartyCountrySubDiv { get; set; }
        public string sTrnsprtrDocPartyNotFdPartyCountryCd { get; set; }
        public string sTrnsprtrDocPartyNotFdPartyPostCd { get; set; }
        public string sTrnsprtrDocPartyGoodsDescAsPerBill { get; set; }
        public string sTrnsprtrDocPartyUCRType { get; set; }
        public string sTrnsprtrDocPartyUCRCd { get; set; }
        public decimal? dTrnsprtrDocMsrNoOfPackages { get; set; }
        public string sTrnsprtrDocMsrTypesOfPackages { get; set; }
        public string sTrnsprtrDocMsrMarksNoOnPackages { get; set; }
        public decimal? dTrnsprtrDocMsrGrossWeight { get; set; }
        public decimal? dTrnsprtrDocMsrNetWeight { get; set; }
        public string sTrnsprtrDocMsrUnitOfWeight { get; set; }
        public decimal? dTrnsprtrDocMsrGrossVolume { get; set; }
        public string sTrnsprtrDocMsrUnitOfVolume { get; set; }
        public decimal? dTrnsprtrDocMsrInvoiceValueOfConsigment { get; set; }
        public string sTrnsprtrDocMsrCurrencyCd { get; set; }
    }
}
