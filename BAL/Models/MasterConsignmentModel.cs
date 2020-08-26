using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Models
{
    public class MasterConsignmentModel
    {
        public string sReportingEvent { get; set; }
        public int iMasterConsignmentId { get; set; }
        public int? iMessageImplementationId { get; set; }
        [Display(Name = "Line no.")]
        [Range(0,9999,ErrorMessage ="Line no should come between 0 to 9999.")]
        [Required(ErrorMessage = "Line no. is a required field.")]
        public int? iMCRefLineNo { get; set; }
        [Display(Name = "Master Bill no.")]
        [MaxLength(20, ErrorMessage = "Master Bill no. cannot exceed 20 character.")]
        [Required(ErrorMessage = "Master Bill no. is a required field.")]
        public string sMCRefMasterBillNo { get; set; }
        [Display(Name = "Master Bill Date")]
        [Required(ErrorMessage = "Master Bill Date is a required field.")]
        public string sMCRefMasterBillDate { get; set; }
        [Display(Name = "Consolidated Indicator")]
        [MaxLength(4, ErrorMessage = "Consolidated Indicator cannot exceed 4 character.")]
        [Required(ErrorMessage = "Consolidated Indicator is a required field.")]
        public string sMCRefConsolidatedIndicator { get; set; }
        [Display(Name = "Previous Declaration")]
        [MaxLength(4, ErrorMessage = "Previous Declaration cannot exceed 4 character.")]
        [Required(ErrorMessage = "Previous Declaration is a required field.")]
        public string sMCRefPreviousDeclaration { get; set; }
        [Display(Name = "Consolidator PAN")]
        [MaxLength(35, ErrorMessage = "Consolidator PAN cannot exceed 35 character.")]
        [Required(ErrorMessage = "Consolidator PAN is a required field.")]
        public string sMCRefConsolidatorPan { get; set; }
        [Display(Name = "No. Of Packages")]
        [Range(0,9999999999999999,ErrorMessage ="No of Packages should be in range between 0 to 9999999999999999")]
        public decimal? dPrevRefNoOfPackages { get; set; }
        [Display(Name = "Type Of Packages")]
        [MaxLength(4, ErrorMessage = "Type Of Packages cannot exceed 4 character.")]
        public string sPrevRefTypeOfPackage { get; set; }
        [Display(Name = "CIN Type")]
        [MaxLength(4, ErrorMessage = "CIN Type cannot exceed 4 character.")]
        public string sPrevRefCinType { get; set; }
        [Display(Name = "MCIN/PCIN")]
        [MaxLength(20, ErrorMessage = "MCIN/PCIN cannot exceed 20 character.")]
        public string sPrevRefMcinPcin { get; set; }
        [Display(Name = "CSN Submited Type")]
        [MaxLength(4, ErrorMessage = "CSN Submited Type cannot exceed 4 character.")]
        public string sPrevRefCSNSubmtdType { get; set; }
        [Display(Name = "CSN Submited By")]
        [MaxLength(20, ErrorMessage = "CSN Submited By cannot exceed 20 character.")]
        public string sPrevRefCSNSubmtdBy { get; set; }
        [Display(Name = "CSN Reporting Type")]
        [MaxLength(4, ErrorMessage = "CSN Reporting Type cannot exceed 4 character.")]
        public string sPrevRefCSNReportingType { get; set; }
        [Display(Name = "CSN Site Id")]
        [MaxLength(6, ErrorMessage = "CSN Site Id cannot exceed 6 character.")]
        public string sPrevRefCSNSiteId { get; set; }
        [Display(Name = "CSN No.")]
        [Range(0,9999,ErrorMessage = "CSN no should come between 0 to 9999.")]
        public int? iPrevRefCSNNo { get; set; }
        [Display(Name = "Previous Ref CSN Date")]
        public string sPrevRefCSNDate { get; set; }
        [Display(Name = "Previous Ref Split Indicator")]
        [MaxLength(2, ErrorMessage = "Previous Ref Split Indicator cannot exceed 2 character.")]
        public string sPrevRefSplitIndicator { get; set; }
        
        [Display(Name = "First Port Of Entry")]
        [MaxLength(6, ErrorMessage = "First Port Of Entry cannot exceed 6 character.")]
        public string sLocCustomFirstPortOfEntry { get; set; }
        [Display(Name = "Destination Port")]
        [MaxLength(10, ErrorMessage = "Destination Port cannot exceed 10 character.")]
        public string sLocCustomDestPort { get; set; }
        [Display(Name = "Next Port Of Unlanding")]
        [MaxLength(6, ErrorMessage = "Next Port Of Unlanding cannot exceed 6 character.")]
        public string sLocCustomNextPortOfUnlanding { get; set; }
        [Display(Name = "Type Of Cargo")]
        [MaxLength(6, ErrorMessage = "Type Of Cargo cannot exceed 6 character.")]
        [Required(ErrorMessage = "Type Of Cargo is a required field.")]
        public string sLocCustomTypeOfCargo { get; set; }
        [Display(Name = "Item Type")]
        [MaxLength(2, ErrorMessage = "Item Type cannot exceed 2 character.")]
        [Required(ErrorMessage = "Type is a required field.")]
        public string sLocCustomItemType { get; set; }
        [Display(Name = "Cargo Movement")]
        [MaxLength(4, ErrorMessage = "Cargo Movement cannot exceed 4 character.")]
        [Required(ErrorMessage = "Cargo Movement is a required field.")]
        public string sLocCustomCargoMovement { get; set; }
        [Display(Name = "Nature Of Cargo")]
        [MaxLength(4, ErrorMessage = "Nature Of Cargo cannot exceed 4 character.")]
        [Required(ErrorMessage = "Nature Of Cargo is a required field.")]
        public string sLocCustomNatureOfCargo { get; set; }
        [Display(Name = "Split Indicator")]
        [MaxLength(2, ErrorMessage = "Split Indicator cannot exceed 2 character.")]
        public string sLocCustomSplitIndicator { get; set; }
        [Display(Name = "No. Of Packages")]
        [Range(0, 9999999999999, ErrorMessage = "No of packages should be in between 0 to 9999999999999")]
        public decimal? dLocCustomNoOfPackages { get; set; }
        [Display(Name = "Types Of Packages")]
        [MaxLength(4, ErrorMessage = "Types Of Packages cannot exceed 4 character.")]
        public string sLocCustomTypeOfPackage { get; set; }
        [Display(Name = "Transhipper Code")]
        [MaxLength(10, ErrorMessage = "Transhipper Code cannot exceed 10 character.")]
        [Required(ErrorMessage = "Transhipper Code is a required field.")]
        [RegularExpression(@"[A-Z]{5}\d{4}[A-Z]{1}", ErrorMessage = "Please Enter valid PAN Card")]
        public string sTrnshprCd { get; set; }
        [Display(Name = "Transhipper Bond")]
        [MaxLength(10, ErrorMessage = "Transhipper Bond cannot exceed 10 character.")]
        [Required(ErrorMessage = "Transhipper Bond is a required field.")]
        public string sTrnshprBond { get; set; }
        [Display(Name = "Port Of Accepted Code")]
        [MaxLength(6, ErrorMessage = "Port Of Accepted Code cannot exceed 6 character.")]
        public string sTrnsprtrDocPortOfAcceptedCCd { get; set; }
        [Display(Name = "Port Of Accepted Name")]
        [MaxLength(256, ErrorMessage = "Port Of Accepted Name cannot exceed 256 character.")]
        public string sTrnsprtrDocPortOfAcceptedName { get; set; }
        [Display(Name = "Port Of Receipt Code")]
        [MaxLength(10, ErrorMessage = "Port Of Receipt Code cannot exceed 10 character.")]
        public string sTrnsprtrDocPortOfReceiptCcd { get; set; }
        [Display(Name = "Port Of Receipt Name")]
        [MaxLength(256, ErrorMessage = "Port Of Receipt Name cannot exceed 256 character.")]
        public string sTrnsprtrDocPortOfReceiptName { get; set; }
        [Display(Name = "Consignor Name")]
        [MaxLength(70, ErrorMessage = "Consignor Name cannot exceed 70 character.")]
        public string sTrnsprtrDocConsignorName { get; set; }
        [Display(Name = "Consignor Code")]
        [MaxLength(17, ErrorMessage = "Consignor Code cannot exceed 17 character.")]
        public string sTrnsprtrDocConsignorCd { get; set; }
        [Display(Name = "Consignor Code Type")]
        [MaxLength(3, ErrorMessage = "Consignor Code Type cannot exceed 3 character.")]
        public string sTrnsprtrDocConsignorCdType { get; set; }
        [Display(Name = "Consignor Street Address")]
        [MaxLength(70, ErrorMessage = "Consignor Street Address cannot exceed 70 character.")]
        [Required(ErrorMessage = "Consignor Street Address is a required field.")]
        public string sTrnsprtrDocConsignorStreetAddress { get; set; }
        [Display(Name = "Consignor City")]
        [MaxLength(70, ErrorMessage = "Consignor City cannot exceed 70 character.")]
        [Required(ErrorMessage = "Consignor City is a required field.")]
        public string sTrnsprtrDocConsignorCity { get; set; }
        [Display(Name = "Consignor Country Sub Div Name")]
        [MaxLength(35, ErrorMessage = "Consignor Country Sub Div Name cannot exceed 35 character.")]
        public string sTrnsprtrDocConsignorCountrySubDivName { get; set; }
        [Display(Name = "Consignor Country Sub Div Code")]
        [MaxLength(9, ErrorMessage = "Consignor Country Sub Div Code cannot exceed 9 character.")]
        public string sTrnsprtrDocConsignorCountrySubDivCd { get; set; }
        [Display(Name = "Consignor Country Code")]
        [MaxLength(2, ErrorMessage = "Consignor Country Code cannot exceed 2 character.")]
        [Required(ErrorMessage = "Consignor Country Code is a required field.")]
        public string sTrnsprtrDocConsignorCountryCd { get; set; }
        [Display(Name = "Consignor Post Code")]
        [MaxLength(9, ErrorMessage = "Consignor Post Code cannot exceed 9 character.")]
        public string sTrnsprtrDocConsignorPostCd { get; set; }
        [Display(Name = "Consignee Name")]
        [MaxLength(70, ErrorMessage = "Consignee Name cannot exceed 70 character.")]
        [Required(ErrorMessage = "Consignee Name is a required field.")]
        public string sTrnsprtrDocConsigneeName { get; set; }
        [Display(Name = "Consignee Code")]
        [MaxLength(17, ErrorMessage = "Consignee Code cannot exceed 17 character.")]
        public string sTrnsprtrDocConsigneeCd { get; set; }
        [Display(Name = "Type Of Code")]
        [MaxLength(3, ErrorMessage = "Type Of Code cannot exceed 3 character.")]
        public string sTrnsprtrDocTypeOfCd { get; set; }
        [Display(Name = "Consignee Street Address")]
        [MaxLength(70, ErrorMessage = "Consignee Street Address cannot exceed 70 character.")]
        [Required(ErrorMessage = "Consignee Street Address is a required field.")]
        public string sTrnsprtrDocConsigneeStreetAddress { get; set; }
        [Display(Name = "Consignee City")]
        [MaxLength(70, ErrorMessage = "Consignee City cannot exceed 70 character.")]
        [Required(ErrorMessage = "Consignee City is a required field.")]
        public string sTrnsprtrDocConsigneeCity { get; set; }
        [Display(Name = "Consignee Country Sub Div Name")]
        [MaxLength(35, ErrorMessage = "Consignee Country Sub Div Name cannot exceed 35 character.")]
        public string sTrnsprtrDocConsigneeCountrySubDivName { get; set; }
        [Display(Name = "Consignee Country Sub Div")]
        [MaxLength(9, ErrorMessage = "Consignee Country Sub Div cannot exceed 9 character.")]
        public string sTrnsprtrDocConsigneeCountrySubDiv { get; set; }
        [Display(Name = "Consignee Country Code")]
        [MaxLength(2, ErrorMessage = "Consignee Country Code cannot exceed 2 character.")]
        public string sTrnsprtrDocConsigneeCountryCd { get; set; }
        [Display(Name = "Consignee Post Code")]
        [MaxLength(9, ErrorMessage = "Consignee Post Code cannot exceed 9 character.")]
        public string sTrnsprtrDocConsigneePostCd { get; set; }
        [Display(Name = "Name Of Any Other Notified Party")]
        [MaxLength(70, ErrorMessage = "Name Of Any Other Notified Party cannot exceed 70 character.")]
        [Required(ErrorMessage = "Name Of Any Other Notified Party is a required field.")]
        public string sTrnsprtrDocNameOfAnyOtherNotFdParty { get; set; }
        [Display(Name = "PAN Of Notified Party")]
        [MaxLength(17, ErrorMessage = "PAN Of Notified Party cannot exceed 17 character.")]
        public string sTrnsprtrDocPANOfNotFdParty { get; set; }
        [Display(Name = "Type Of Notified Party Code")]
        [MaxLength(3, ErrorMessage = "Type Of Notified Party Code cannot exceed 3 character.")]
        public string sTrnsprtrDocTypeOfNotFdPartyCd { get; set; }
        [Display(Name = "Notified Party Street Address")]
        [MaxLength(70, ErrorMessage = "Notified Party Street Address cannot exceed 70 character.")]
        [Required(ErrorMessage = "Notified Party Street Address is a required field.")]
        public string sTrnsprtrDocNotFdPartyStreetAddress { get; set; }
        [Display(Name = "Notified Party City")]
        [MaxLength(70, ErrorMessage = "Notified Party City cannot exceed 70 character.")]
        [Required(ErrorMessage = "Notified Party City is a required field.")]
        public string sTrnsprtrDocNotFdPartyCity { get; set; }
        [Display(Name = "Notified Party Country Sub Div Name")]
        [MaxLength(35, ErrorMessage = "Notified Party Country Sub Div Name cannot exceed 35 character.")]
        public string sTrnsprtrDocNotFdPartyCountrySubDivName { get; set; }
        [Display(Name = "Notified Party Country Sub Div")]
        [MaxLength(9, ErrorMessage = "Notified Party Country Sub Div cannot exceed 9 character.")]
        public string sTrnsprtrDocNotFdPartyCountrySubDiv { get; set; }
        [Display(Name = "Notified Party Country Code")]
        [MaxLength(3, ErrorMessage = "Notified Party Country Code cannot exceed 3 character.")]
        public string sTrnsprtrDocNotFdPartyCountryCd { get; set; }
        [Display(Name = "Notified Party Post Code")]
        [MaxLength(9, ErrorMessage = "Notified Party Post Code cannot exceed 9 character.")]
        public string sTrnsprtrDocNotFdPartyPostCd { get; set; }
        [Display(Name = "Goods Description As Per Bill")]
        [MaxLength(512, ErrorMessage = "Goods Description As Per Bill cannot exceed 512 character.")]
        [Required(ErrorMessage = "Goods Description As Per Bill is a required field.")]
        public string sTrnsprtrDocGoodsDescAsPerBill { get; set; }
        [Display(Name = "UCR Type")]
        [MaxLength(3, ErrorMessage = "UCR Type cannot exceed 3 character.")]
        public string sTrnsprtrDocUCRType { get; set; }
        [Display(Name = "UCR Code")]
        [MaxLength(35, ErrorMessage = "UCR Code cannot exceed 35 character.")]
        public string sTrnsprtrDocUCRCd { get; set; }
        [Display(Name = "No. of packages")]
        [Range(0, 99999999, ErrorMessage = "No. of packages should be in range between 0 to 99999999")]
        [Required(ErrorMessage ="No of packages is a required field.")]
        public decimal dTrnsprtrDocMsrNoOfPackages { get; set; }
        [Display(Name = "Types Of Packages")]
        [MaxLength(3, ErrorMessage = "Types Of Packages cannot exceed 3 character.")]
        public string sTrnsprtrDocMsrTypesOfPackages { get; set; }
        [Display(Name = "Marks No. On Packages")]
        [MaxLength(512, ErrorMessage = "Marks No. On Packages cannot exceed 512 character.")]
        [Required(ErrorMessage = "Marks No. On Packages is a required field.")]
        public string sTrnsprtrDocMsrMarksNoOnPackages { get; set; }
        [Display(Name = "Gross Weight")]
        [Range(0,999999999999.99,ErrorMessage = "Gross Weight should be in range between 0 to 999999999999.99")]
        public decimal? dTrnsprtrDocMsrGrossWeight { get; set; }
        [Display(Name = "Net Weight")]
        [Range(0, 999999999999.99, ErrorMessage = "Net Weight should be in range between 0 to 999999999999.99")]
        public decimal? dTrnsprtrDocMsrNetWeight { get; set; }
        [Display(Name = "Unit Of Weight")]
        [MaxLength(3, ErrorMessage = "Unit Of Weight cannot exceed 3 character.")]
        public string sTrnsprtrDocMsrUnitOfWeight { get; set; }
        [Display(Name = "Gross Volume")]
        public decimal? dTrnsprtrDocMsrGrossVolume { get; set; }
        [Display(Name = "Unit Of Volume")]
        [MaxLength(3, ErrorMessage = "Unit Of Volume cannot exceed 3 character.")]
        public string sTrnsprtrDocMsrUnitOfVolume { get; set; }
        [Display(Name = "Invoice Value Of Consigment")]
        [Range(0,9999999999999999.99,ErrorMessage = "Invoice value of consignment should be in range between 0 to 9999999999999999.99")]
        public decimal? dTrnsprtrDocMsrInvoiceValueOfConsigment { get; set; }
        [Display(Name = "Currency Code")]
        [MaxLength(3, ErrorMessage = "Currency Code cannot exceed 3 character.")]
        public string sTrnsprtrDocMsrCurrencyCd { get; set; }
        [Display(Name = "CIN Type")]
        [MaxLength(4, ErrorMessage = "CIN Type cannot exceed 4 character.")]
        [Required(ErrorMessage = "CIN Type is a required field.")]
        public string sSuplmntryDecCinType { get; set; }
        [Display(Name = "MCIN/PCIN")]
        [MaxLength(20, ErrorMessage = "MCIN/PCIN cannot exceed 20 character.")]
        public string sSuplmntryDecMCinPCin { get; set; }
        [Display(Name = "CSN Submited Type")]
        [MaxLength(4, ErrorMessage = "CSN Submited Type cannot exceed 4 character.")]
        public string sSuplmntryDecCSNSubmtdType { get; set; }
        [Display(Name = "CSN Submited By")]
        [MaxLength(20, ErrorMessage = "CSN Submited By cannot exceed 20 character.")]
        public string sSuplmntryDecCSNSubmtdBy { get; set; }
        [Display(Name = "CSN Reporting Type")]
        [MaxLength(4, ErrorMessage = "CSN Reporting Type cannot exceed 4 character.")]
        public string sSuplmntryDecCSNReportingType { get; set; }
        [Display(Name = "CSN Site ID")]
        [MaxLength(6, ErrorMessage = "CSN Site ID cannot exceed 6 character.")]
        public string sSuplmntryDecCSNSiteId { get; set; }
        [Display(Name = "CSN No.")]
        [Range(0,9999999,ErrorMessage ="CSN No should be in range between 0 to 9999999")]
        public decimal dSuplmntryDecCSNNo { get; set; }
        [Display(Name = "CSN Date")]
        public string sSuplmntryDecCSNDate { get; set; }
        [Display(Name = "Previous MCIN")]
        [MaxLength(20, ErrorMessage = "Previous MCIN cannot exceed 20 character.")]
        public string sSuplmntryDecPrevMCIN { get; set; }
        [Display(Name = "Split Indicator")]
        [MaxLength(2, ErrorMessage = "Split Indicator cannot exceed 2 character.")]
        public string sSuplmntryDecSplitIndicator { get; set; }
        [Display(Name = "No. Of Packages")]
        public decimal dSuplmntryDecNoOfPackages { get; set; }
        [Display(Name = "Types Of Packages")]
        [MaxLength(4, ErrorMessage = "Types Of Packages cannot exceed 4 character.")]
        public string sSuplmntryDecTypeOfPackages { get; set; }
    }
}
