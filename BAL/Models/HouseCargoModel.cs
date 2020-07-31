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
        public string sReportingEvent { get; set; }

        public int iHouseCargoDescId { get; set; }
        public int? iMasterConsignmentId { get; set; }
        public int? iMessageImplementationId { get; set; }
        [Display(Name = "Sub Line no.")]
        [Required(ErrorMessage = "Sub Line no. is a required field.")]
        [Range(0, 9999, ErrorMessage = "Sub Line no should come between 0 to 9999.")]
        public decimal? dHCRefSubLineNo { get; set; }
        [Display(Name = "Bill no.")]
        [MaxLength(3, ErrorMessage = "Bill no. cannot exceed 3 character.")]
        [Required(ErrorMessage = "Bill no. is a required field.")]
        public string sHCRefBillNo { get; set; }
        [Display(Name = "Bill Date")]
        [Required(ErrorMessage = "Bill Date is a required field.")]
        public string sHCRefBillDate { get; set; }
        [Display(Name = "Consolidated Indicator")]
        [MaxLength(4, ErrorMessage = "Consolidated Indicator cannot exceed 4 character.")]
        [Required(ErrorMessage = "Consolidated Indicator is a required field.")]
        public string sHCRefConsolidatedIndicator { get; set; }
        [Display(Name = "Consolidated PAN")]
        [MaxLength(35, ErrorMessage = "Consolidated PAN cannot exceed 35 character.")]
        [Required(ErrorMessage = "Consolidated PAN is a required field.")]
        public string sHCRefConsolidatorPan { get; set; }
        [Display(Name = "Previous Description")]
        [MaxLength(4, ErrorMessage = "Previous Description cannot exceed 4 character.")]
        [Required(ErrorMessage = "Previous Description is a required field.")]
        public string sHCRefPreviousDescription { get; set; }
        [Display(Name = "First Port Of Entry")]
        [MaxLength(6, ErrorMessage = "First Port Of Entry cannot exceed 6 character.")]
        public string sLocCstmFirstPortOfEntry { get; set; }
        [Display(Name = "Destination Port")]
        [MaxLength(10, ErrorMessage = "Destination Port cannot exceed 10 character.")]
        public string sLocCstmDestinationPort { get; set; }
        [Display(Name = "Port Of Unlanding")]
        [MaxLength(6, ErrorMessage = "Port Of Unlanding cannot exceed 6 character.")]
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
        public string sLocCstmSplitIndicator { get; set; }
        [Display(Name = "No. Of Packages")]
        [Range(0, 9999999999999999, ErrorMessage = "No. of Packages should be in range between 0 to 9999999999999999")]
        public decimal? dLocCstmNoOfPackages { get; set; }
        [Display(Name = "Types Of Packages")]
        [Required(ErrorMessage = "Types Of Packages is a required field.")]
        public string sLocCstmTypeOfPakages { get; set; }
        [Display(Name = "Transhipper Code")]
        [MaxLength(10, ErrorMessage = "Transhipper Code cannot exceed 10 character.")]
        [Required(ErrorMessage = "Transhipper Code is a required field.")]
        public string sTrnshprTranshipperCd { get; set; }
        [Display(Name = "Transhipper Bond")]
        [MaxLength(10, ErrorMessage = "Transhipper Bond cannot exceed 10 character.")]
        [Required(ErrorMessage = "Transhipper Bond is a required field.")]
        public string sTrnshprTranshipperBond { get; set; }
        [Display(Name = "Port Of Accepted Code")]
        [MaxLength(6, ErrorMessage = "Port Of Accepted Code cannot exceed 6 character.")]
        [Required(ErrorMessage = "Port Of Accepted Code is a required field.")]
        public string sTrnsprtrDocPartyPortOfAcceptedCCd { get; set; }
        [Display(Name = "Port Of Accepted Name")]
        [MaxLength(256, ErrorMessage = "Port Of Accepted Name cannot exceed 256 character.")]
        public string sTrnsprtrDocPartyPortOfAcceptedName { get; set; }
        [Display(Name = "Port Of Receipt Code ")]
        [MaxLength(10, ErrorMessage = "Port Of Receipt Code  cannot exceed 10 character.")]
        [Required(ErrorMessage = "Port Of Receipt Code  is a required field.")]
        public string sTrnsprtrDocPartyPortOfReceiptCcd { get; set; }
        [Display(Name = "Port Of Receipt Name")]
        [MaxLength(256, ErrorMessage = "Port Of Receipt Name cannot exceed 256 character.")]
        public string sTrnsprtrDocPartyPortOfReceiptName { get; set; }
        [Display(Name = "Consignee Name")]
        [MaxLength(70, ErrorMessage = "Consignee Name cannot exceed 70 character.")]
        public string sTrnsprtrDocPartyConsignorName { get; set; }
        [Display(Name = "Consignee Code")]
        [MaxLength(17, ErrorMessage = "Consignee Code cannot exceed 17 character.")]
        public string sTrnsprtrDocPartyConsignorCd { get; set; }
        [Display(Name = "Consignee Code Type")]
        [MaxLength(3, ErrorMessage = "Consignee Code Type cannot exceed 3 character.")]
        public string sTrnsprtrDocPartyConsignorCdType { get; set; }
        [Display(Name = "Consignee Street Address")]
        [MaxLength(70, ErrorMessage = "Consignee Street Address cannot exceed 70 character.")]
        [Required(ErrorMessage = "Consignee Street Address is a required field.")]
        public string sTrnsprtrDocPartyConsignorStreetAddress { get; set; }
        [Display(Name = "Consignee City")]
        [MaxLength(70, ErrorMessage = "Consignee City cannot exceed 70 character.")]
        [Required(ErrorMessage = "Consignee City is a required field.")]
        public string sTrnsprtrDocPartyConsignorCity { get; set; }
        [Display(Name = "Consignee Country Sub Div Name")]
        [MaxLength(35, ErrorMessage = "Consignee Country Sub Div Name cannot exceed 35 character.")]
        public string sTrnsprtrDocPartyConsignorCountrySubDivName { get; set; }
        [Display(Name = "Consignee Country Sub Div Code")]
        [MaxLength(9, ErrorMessage = "Consignee Country Sub Div Code cannot exceed 9 character.")]
        public string sTrnsprtrDocPartyConsignorCountrySubDivCd { get; set; }
        [Display(Name = "Consignee Country Code")]
        [MaxLength(2, ErrorMessage = "Consignee Country Code cannot exceed 2 character.")]
        [Required(ErrorMessage = "Consignee Country Code is a required field.")]
        public string sTrnsprtrDocPartyConsignorCountryCd { get; set; }
        [Display(Name = "Consignee Post Code")]
        [MaxLength(9, ErrorMessage = "Consignee Post Code cannot exceed 9 character.")]
        public string sTrnsprtrDocPartyConsignorPostCd { get; set; }
        [Display(Name = "Consignee Name")]
        [MaxLength(70, ErrorMessage = "Consignee Name cannot exceed 70 character.")]
        [Required(ErrorMessage = "Consignee Name is a required field.")]
        public string sTrnsprtrDocPartyConsigneeName { get; set; }
        [Display(Name = "Consignee Code")]
        [MaxLength(17, ErrorMessage = "Consignee Code cannot exceed 17 character.")]
        [Required(ErrorMessage = "Consignee Code is a required field.")]
        public string sTrnsprtrDocPartyConsigneeCd { get; set; }
        [Display(Name = "Type of code")]
        [MaxLength(3, ErrorMessage = "Type of code cannot exceed 3 character.")]
        [Required(ErrorMessage = "Type of code is a required field.")]
        public string sTrnsprtrDocPartyTypeOfCd { get; set; }
        [Display(Name = "Consignee Street Address")]
        [MaxLength(70, ErrorMessage = "Consignee Street Address cannot exceed 70 character.")]
        [Required(ErrorMessage = "Consignee Street Address is a required field.")]
        public string sTrnsprtrDocPartyConsigneeStreetAddress { get; set; }
        [Display(Name = "Consignee City")]
        [MaxLength(70, ErrorMessage = "Consignee City cannot exceed 70 character.")]
        [Required(ErrorMessage = "Consignee City is a required field.")]
        public string sTrnsprtrDocPartyConsigneeCity { get; set; }
        [Display(Name = "Consignee Country Sub Div Name")]
        [MaxLength(35, ErrorMessage = "Consignee Country Sub Div Name cannot exceed 35 character.")]
        [Required(ErrorMessage = "Consignee Country Sub Div Name is a required field.")]
        public string sTrnsprtrDocPartyConsigneeCountrySubDivName { get; set; }
        [Display(Name = "Consignee Country Sub Div")]
        [MaxLength(9, ErrorMessage = "Consignee Country Sub Div cannot exceed 9 character.")]
        [Required(ErrorMessage = "Consignee Country Sub Div is a required field.")]
        public string sTrnsprtrDocPartyConsigneeCountrySubDiv { get; set; }
        [Display(Name = "Consignee Country Code")]
        [MaxLength(2, ErrorMessage = "Consignee Country Code cannot exceed 2 character.")]
        [Required(ErrorMessage = "Consignee Country Code is a required field.")]
        public string sTrnsprtrDocPartyConsigneeCountryCd { get; set; }
        [Display(Name = "Consignee Post Code")]
        [MaxLength(9, ErrorMessage = "Consignee Post Code cannot exceed 9 character.")]
        [Required(ErrorMessage = "Consignee Post Code is a required field.")]
        public string sTrnsprtrDocPartyConsigneePostCd { get; set; }
        [Display(Name = "Name Of Any Other Not Fd Party")]
        [MaxLength(70, ErrorMessage = "Name Of Any Other Not Fd Party cannot exceed 70 character.")]
        [Required(ErrorMessage = "Name Of Any Other Not Fd Party is a required field.")]
        public string sTrnsprtrDocPartyNameOfAnyOtherNotFdParty { get; set; }
        [Display(Name = "PAN Of Not Fd Party")]
        [MaxLength(17, ErrorMessage = "PAN Of Not Fd Party cannot exceed 17 character.")]
        [Required(ErrorMessage = "PAN Of Not Fd Party is a required field.")]
        public string sTrnsprtrDocPartyPANOfNotFdParty { get; set; }
        [Display(Name = "Type Of Not Fd Party")]
        [MaxLength(3, ErrorMessage = "Type Of Not Fd Party cannot exceed 3 character.")]
        [Required(ErrorMessage = "Type Of Not Fd Party is a required field.")]
        public string sTrnsprtrDocPartyTypeOfNotFdPartyCd { get; set; }
        [Display(Name = "Not Fd Party Street Address")]
        [MaxLength(70, ErrorMessage = "Not Fd Party Street Address cannot exceed 70 character.")]
        [Required(ErrorMessage = "Not Fd Party Street Address is a required field.")]
        public string sTrnsprtrDocPartyNotFdPartyStreetAddress { get; set; }
        [Display(Name = "Not Fd Party City")]
        [MaxLength(70, ErrorMessage = "Not Fd Party City cannot exceed 70 character.")]
        [Required(ErrorMessage = "Not Fd Party City is a required field.")]
        public string sTrnsprtrDocPartyNotFdPartyCity { get; set; }
        [Display(Name = "Not Fd Party Country Sub Div Name")]
        [MaxLength(35, ErrorMessage = "Not Fd Party Country Sub Div Name cannot exceed 35 character.")]
        [Required(ErrorMessage = "Not Fd Party Country Sub Div Name is a required field.")]
        public string sTrnsprtrDocPartyNotFdPartyCountrySubDivName { get; set; }
        [Display(Name = "Not Fd Party Country Sub Div")]
        [MaxLength(9, ErrorMessage = "Not Fd Party Country Sub Div cannot exceed 9 character.")]
        [Required(ErrorMessage = "Not Fd Party Country Sub Div is a required field.")]
        public string sTrnsprtrDocPartyNotFdPartyCountrySubDiv { get; set; }
        [Display(Name = "Not Fd Party Country Code")]
        [MaxLength(3, ErrorMessage = "Not Fd Party Country Code cannot exceed 3 character.")]
        [Required(ErrorMessage = "Not Fd Party Country Code is a required field.")]
        public string sTrnsprtrDocPartyNotFdPartyCountryCd { get; set; }
        [Display(Name = "Not Fd Party Post Code")]
        [MaxLength(9, ErrorMessage = "Not Fd Party Post Code cannot exceed 9 character.")]
        [Required(ErrorMessage = "Not Fd Party Post Code is a required field.")]
        public string sTrnsprtrDocPartyNotFdPartyPostCd { get; set; }
        [Display(Name = "Goods Desc AsPerBill")]
        [MaxLength(512, ErrorMessage = "Goods Desc AsPerBill cannot exceed 512 character.")]
        [Required(ErrorMessage = "Goods Desc AsPerBill is a required field.")]
        public string sTrnsprtrDocPartyGoodsDescAsPerBill { get; set; }
        [Display(Name = "UCR Type")]
        [MaxLength(3, ErrorMessage = "UCR Type cannot exceed 3 character.")]
        [Required(ErrorMessage = "UCR Type is a required field.")]
        public string sTrnsprtrDocPartyUCRType { get; set; }
        [Display(Name = "UCR Code")]
        [MaxLength(35, ErrorMessage = "UCR Code cannot exceed 35 character.")]
        [Required(ErrorMessage = "UCR Code is a required field.")]
        public string sTrnsprtrDocPartyUCRCd { get; set; }
        [Display(Name = "Msr No Of Packages")]
        [Required(ErrorMessage = "Msr No Of Packages is a required field.")]
        public decimal? dTrnsprtrDocMsrNoOfPackages { get; set; }
        [Display(Name = "Msr Types Of Packages")]
        [MaxLength(3, ErrorMessage = "Msr Types Of Packages cannot exceed 3 character.")]
        [Required(ErrorMessage = "Msr Types Of Packages is a required field.")]
        public string sTrnsprtrDocMsrTypesOfPackages { get; set; }
        [Display(Name = "Msr Marks No. On Packages")]
        [MaxLength(512, ErrorMessage = "Msr Marks No. On Packages cannot exceed 512 character.")]
        [Required(ErrorMessage = "Msr Marks No. On Packages is a required field.")]
        public string sTrnsprtrDocMsrMarksNoOnPackages { get; set; }
        [Display(Name = "Msr Gross Weight")]
        [Required(ErrorMessage = "Msr Gross Weight is a required field.")]
        public decimal? dTrnsprtrDocMsrGrossWeight { get; set; }
        [Display(Name = "Msr Net Weight")]
        [Required(ErrorMessage = "Msr Net Weight is a required field.")]
        public decimal? dTrnsprtrDocMsrNetWeight { get; set; }
        [Display(Name = "Msr Unit Of Weight")]
        [MaxLength(3, ErrorMessage = "Msr Unit Of Weight cannot exceed 3 character.")]
        [Required(ErrorMessage = "Msr Unit Of Weight is a required field.")]
        public string sTrnsprtrDocMsrUnitOfWeight { get; set; }
        [Display(Name = "Msr Gross Value")]
        [Required(ErrorMessage = "Msr Gross Value is a required field.")]
        public decimal? dTrnsprtrDocMsrGrossVolume { get; set; }
        [Display(Name = "Msr Unit Of Volume")]
        [MaxLength(3, ErrorMessage = "Msr Unit Of Volume cannot exceed 3 character.")]
        [Required(ErrorMessage = "Msr Unit Of Volume is a required field.")]
        public string sTrnsprtrDocMsrUnitOfVolume { get; set; }
        [Display(Name = "Msr Invoice Value Of Consigment")]
        [Required(ErrorMessage = "Msr Invoice Value Of Consigment is a required field.")]
        public decimal? dTrnsprtrDocMsrInvoiceValueOfConsigment { get; set; }
        [Display(Name = "Msr Currency Code")]
        [MaxLength(3, ErrorMessage = "Msr Currency Code cannot exceed 3 character.")]
        [Required(ErrorMessage = "Msr Currency Code is a required field.")]
        public string sTrnsprtrDocMsrCurrencyCd { get; set; }
    }
}
