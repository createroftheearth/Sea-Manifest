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
        public string sTrnsprtrDocPartyPortOfAcceptedName { get; set; }
        [Display(Name = "Party Port Of Receipt CCD ")]
        [MaxLength(10, ErrorMessage = "Party Port Of Receipt CCD  cannot exceed 10 character.")]
        [Required(ErrorMessage = "Party Port Of Receipt CCD  is a required field.")]
        public string sTrnsprtrDocPartyPortOfReceiptCcd { get; set; }
        [Display(Name = "Party Port Of Receipt Name")]
        [MaxLength(256, ErrorMessage = "Party Port Of Receipt Name cannot exceed 256 character.")]
        [Required(ErrorMessage = "Party Port Of Receipt Name is a required field.")]
        public string sTrnsprtrDocPartyPortOfReceiptName { get; set; }
        [Display(Name = "Party Consignor Name")]
        [MaxLength(70, ErrorMessage = "Party Consignor Name cannot exceed 70 character.")]
        [Required(ErrorMessage = "Party Consignor Name is a required field.")]
        public string sTrnsprtrDocPartyConsignorName { get; set; }
        [Display(Name = "Party Consignor CD")]
        [MaxLength(17, ErrorMessage = "Party Consignor CD cannot exceed 17 character.")]
        [Required(ErrorMessage = "Party Consignor CD is a required field.")]
        public string sTrnsprtrDocPartyConsignorCd { get; set; }
        [Display(Name = "Party Consignor CD Type")]
        [MaxLength(3, ErrorMessage = "Party Consignor CD Type cannot exceed 3 character.")]
        [Required(ErrorMessage = "Party Consignor CD Type is a required field.")]
        public string sTrnsprtrDocPartyConsignorCdType { get; set; }
        [Display(Name = "Party Consignor Street Address")]
        [MaxLength(70, ErrorMessage = "Party Consignor Street Address cannot exceed 70 character.")]
        [Required(ErrorMessage = "Party Consignor Street Address is a required field.")]
        public string sTrnsprtrDocPartyConsignorStreetAddress { get; set; }
        [Display(Name = "Party Consignor City")]
        [MaxLength(70, ErrorMessage = "Party Consignor City cannot exceed 70 character.")]
        [Required(ErrorMessage = "Party Consignor City is a required field.")]
        public string sTrnsprtrDocPartyConsignorCity { get; set; }
        [Display(Name = "Party Consignor Country Sub Div Name")]
        [MaxLength(35, ErrorMessage = "Party Consignor Country Sub Div Name cannot exceed 35 character.")]
        [Required(ErrorMessage = "Party Consignor Country Sub Div Name is a required field.")]
        public string sTrnsprtrDocPartyConsignorCountrySubDivName { get; set; }
        [Display(Name = "Party Consignor Country Sub Div CD")]
        [MaxLength(9, ErrorMessage = "Party Consignor Country Sub Div CD cannot exceed 9 character.")]
        [Required(ErrorMessage = "Party Consignor Country Sub Div CD is a required field.")]
        public string sTrnsprtrDocPartyConsignorCountrySubDivCd { get; set; }
        [Display(Name = "Party Consignor Country CD")]
        [MaxLength(2, ErrorMessage = "Party Consignor Country CD cannot exceed 2 character.")]
        [Required(ErrorMessage = "Party Consignor Country CD is a required field.")]
        public string sTrnsprtrDocPartyConsignorCountryCd { get; set; }
        [Display(Name = "Party Consignor Post CD")]
        [MaxLength(9, ErrorMessage = "Party Consignor Post CD cannot exceed 9 character.")]
        [Required(ErrorMessage = "Party Consignor Post CD is a required field.")]
        public string sTrnsprtrDocPartyConsignorPostCd { get; set; }
        [Display(Name = "Party Consignor Name")]
        [MaxLength(70, ErrorMessage = "Party Consignor Name cannot exceed 70 character.")]
        [Required(ErrorMessage = "Party Consignor Name is a required field.")]
        public string sTrnsprtrDocPartyConsigneeName { get; set; }
        [Display(Name = "Party Consignor CD")]
        [MaxLength(17, ErrorMessage = "Party Consignor CD cannot exceed 17 character.")]
        [Required(ErrorMessage = "Party Consignor CD is a required field.")]
        public string sTrnsprtrDocPartyConsigneeCd { get; set; }
        [Display(Name = "Party Type Of CD")]
        [MaxLength(3, ErrorMessage = "Party Type Of CD cannot exceed 3 character.")]
        [Required(ErrorMessage = "Party Type Of CD is a required field.")]
        public string sTrnsprtrDocPartyTypeOfCd { get; set; }
        [Display(Name = "Party Consignee Street Address")]
        [MaxLength(70, ErrorMessage = "Party Consignee Street Address cannot exceed 70 character.")]
        [Required(ErrorMessage = "Party Consignee Street Address is a required field.")]
        public string sTrnsprtrDocPartyConsigneeStreetAddress { get; set; }
        [Display(Name = "Party Consignee City")]
        [MaxLength(70, ErrorMessage = "Party Consignee City cannot exceed 70 character.")]
        [Required(ErrorMessage = "Party Consignee City is a required field.")]
        public string sTrnsprtrDocPartyConsigneeCity { get; set; }
        [Display(Name = "Party Consignee Country Sub Div Name")]
        [MaxLength(35, ErrorMessage = "Party Consignee Country Sub Div Name cannot exceed 35 character.")]
        [Required(ErrorMessage = "Party Consignee Country Sub Div Name is a required field.")]
        public string sTrnsprtrDocPartyConsigneeCountrySubDivName { get; set; }
        [Display(Name = "Party Consignee Country Sub Div")]
        [MaxLength(9, ErrorMessage = "Party Consignee Country Sub Div cannot exceed 9 character.")]
        [Required(ErrorMessage = "Party Consignee Country Sub Div is a required field.")]
        public string sTrnsprtrDocPartyConsigneeCountrySubDiv { get; set; }
        [Display(Name = "Party Consignee Country CD")]
        [MaxLength(2, ErrorMessage = "Party Consignee Country CD cannot exceed 2 character.")]
        [Required(ErrorMessage = "Party Consignee Country CD is a required field.")]
        public string sTrnsprtrDocPartyConsigneeCountryCd { get; set; }
        [Display(Name = "Party Consignee Post CD")]
        [MaxLength(9, ErrorMessage = "Party Consignee Post CD cannot exceed 9 character.")]
        [Required(ErrorMessage = "Party Consignee Post CD is a required field.")]
        public string sTrnsprtrDocPartyConsigneePostCd { get; set; }
        [Display(Name = "Party Name Of Any Other Not Fd Party")]
        [MaxLength(70, ErrorMessage = "Party Name Of Any Other Not Fd Party cannot exceed 70 character.")]
        [Required(ErrorMessage = "Party Name Of Any Other Not Fd Party is a required field.")]
        public string sTrnsprtrDocPartyNameOfAnyOtherNotFdParty { get; set; }
        [Display(Name = "Party PAN Of Not Fd Party")]
        [MaxLength(17, ErrorMessage = "Party PAN Of Not Fd Party cannot exceed 17 character.")]
        [Required(ErrorMessage = "Party PAN Of Not Fd Party is a required field.")]
        public string sTrnsprtrDocPartyPANOfNotFdParty { get; set; }
        [Display(Name = "Party Type Of Not Fd Party")]
        [MaxLength(3, ErrorMessage = "Party Type Of Not Fd Party cannot exceed 3 character.")]
        [Required(ErrorMessage = "Party Type Of Not Fd Party is a required field.")]
        public string sTrnsprtrDocPartyTypeOfNotFdPartyCd { get; set; }
        [Display(Name = "Party Not Fd Party Street Address")]
        [MaxLength(70, ErrorMessage = "Party Not Fd Party Street Address cannot exceed 70 character.")]
        [Required(ErrorMessage = "Party Not Fd Party Street Address is a required field.")]
        public string sTrnsprtrDocPartyNotFdPartyStreetAddress { get; set; }
        [Display(Name = "Party Not Fd Party City")]
        [MaxLength(70, ErrorMessage = "Party Not Fd Party City cannot exceed 70 character.")]
        [Required(ErrorMessage = "Party Not Fd Party City is a required field.")]
        public string sTrnsprtrDocPartyNotFdPartyCity { get; set; }
        [Display(Name = "Party Not Fd Party Country Sub Div Name")]
        [MaxLength(35, ErrorMessage = "Party Not Fd Party Country Sub Div Name cannot exceed 35 character.")]
        [Required(ErrorMessage = "Party Not Fd Party Country Sub Div Name is a required field.")]
        public string sTrnsprtrDocPartyNotFdPartyCountrySubDivName { get; set; }
        [Display(Name = "Party Not Fd Party Country Sub Div")]
        [MaxLength(9, ErrorMessage = "Party Not Fd Party Country Sub Div cannot exceed 9 character.")]
        [Required(ErrorMessage = "Party Not Fd Party Country Sub Div is a required field.")]
        public string sTrnsprtrDocPartyNotFdPartyCountrySubDiv { get; set; }
        [Display(Name = "Party Not Fd Party Country CD")]
        [MaxLength(3, ErrorMessage = "Party Not Fd Party Country CD cannot exceed 3 character.")]
        [Required(ErrorMessage = "Party Not Fd Party Country CD is a required field.")]
        public string sTrnsprtrDocPartyNotFdPartyCountryCd { get; set; }
        [Display(Name = "Party Not Fd Party Post CD")]
        [MaxLength(9, ErrorMessage = "Party Not Fd Party Post CD cannot exceed 9 character.")]
        [Required(ErrorMessage = "Party Not Fd Party Post CD is a required field.")]
        public string sTrnsprtrDocPartyNotFdPartyPostCd { get; set; }
        [Display(Name = "Party Goods Desc AsPerBill")]
        [MaxLength(512, ErrorMessage = "Party Goods Desc AsPerBill cannot exceed 512 character.")]
        [Required(ErrorMessage = "Party Goods Desc AsPerBill is a required field.")]
        public string sTrnsprtrDocPartyGoodsDescAsPerBill { get; set; }
        [Display(Name = "Party UCR Type")]
        [MaxLength(3, ErrorMessage = "Party UCR Type cannot exceed 3 character.")]
        [Required(ErrorMessage = "Party UCR Type is a required field.")]
        public string sTrnsprtrDocPartyUCRType { get; set; }
        [Display(Name = "Party UCR CD")]
        [MaxLength(35, ErrorMessage = "Party UCR CD cannot exceed 35 character.")]
        [Required(ErrorMessage = "Party UCR CD is a required field.")]
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
        [Display(Name = "Msr Currency CD")]
        [MaxLength(3, ErrorMessage = "Msr Currency CD cannot exceed 3 character.")]
        [Required(ErrorMessage = "Msr Currency CD is a required field.")]
        public string sTrnsprtrDocMsrCurrencyCd { get; set; }
    }
}
