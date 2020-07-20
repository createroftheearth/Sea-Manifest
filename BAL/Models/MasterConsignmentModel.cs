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
        public int iMasterConsignmentId { get; set; }
        public int? iMessageImplementationId { get; set; }
        [Display(Name = "Line no.")]
        [MaxLength(4, ErrorMessage = "Line no. cannot exceed 4 character.")]
        [Required(ErrorMessage = "Line no. is a required field.")]
        public int? iMCRefLineNo { get; set; }
        [Display(Name = "Master Bill no.")]
        [MaxLength(20, ErrorMessage = "Master Bill no. cannot exceed 20 character.")]
        [Required(ErrorMessage = "Master Bill no. is a required field.")]
        public string sMCRefMasterBillNo { get; set; }
        [Display(Name = "Master Bill Date")]
        [Required(ErrorMessage = "Master Bill Date is a required field.")]
        public string dtMCRefMasterBillDate { get; set; }
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
        [Display(Name = "CIN Type")]
        [MaxLength(4, ErrorMessage = "CIN Type cannot exceed 4 character.")]
        [Required(ErrorMessage = "CIN Type is a required field.")]
        public string sPrevRefCinType { get; set; }
        [Display(Name = "MCIN PCIN")]
        [MaxLength(20, ErrorMessage = "MCIN PCIN cannot exceed 20 character.")]
        [Required(ErrorMessage = "MCIN PCIN is a required field.")]
        public string sPrevRefMcinPcin { get; set; }
        [Display(Name = "CSN Submited Type")]
        [MaxLength(4, ErrorMessage = "CSN Submited Type cannot exceed 4 character.")]
        [Required(ErrorMessage = "CSN Submited Type is a required field.")]
        public string sPrevRefCSNSubmtdType { get; set; }
        [Display(Name = "CSN Submited By")]
        [MaxLength(20, ErrorMessage = "CSN Submited By cannot exceed 20 character.")]
        [Required(ErrorMessage = "CSN Submited By is a required field.")]
        public string sPrevRefCSNSubmtdBy { get; set; }
        [Display(Name = "CSN Reporting Type")]
        [MaxLength(4, ErrorMessage = "CSN Reporting Type cannot exceed 4 character.")]
        [Required(ErrorMessage = "CSN Reporting Type is a required field.")]
        public string sPrevRefCSNReportingType { get; set; }
        [Display(Name = "CSN Site Id")]
        [MaxLength(6, ErrorMessage = "CSN Site Id cannot exceed 6 character.")]
        [Required(ErrorMessage = "CSN Site Id is a required field.")]
        public string sPrevRefCSNSiteId { get; set; }
        [Display(Name = "CSN No.")]
        [MaxLength(4, ErrorMessage = "CSN No. cannot exceed 4 character.")]
        [Required(ErrorMessage = "CSN No. is a required field.")]
        public int? iPrevRefCSNNo { get; set; }
        [Display(Name = "Previous Ref CSN Date")]
        [Required(ErrorMessage = "Previous Ref CSN Date is a required field.")]
        public string dtPrevRefCSNDate { get; set; }
        [Display(Name = "Previous Ref Split Indicator")]
        [MaxLength(2, ErrorMessage = "Previous Ref Split Indicator cannot exceed 2 character.")]
        [Required(ErrorMessage = "Previous Ref Split Indicator is a required field.")]
        public string sPrevRefSplitIndicator { get; set; }
        [Display(Name = "No. Of Packages")]
        [Required(ErrorMessage = "No. Of Packages is a required field.")]
        public decimal? dPrevRefNoOfPackages { get; set; }
        [Display(Name = "Type Of Packages")]
        [MaxLength(4, ErrorMessage = "Type Of Packages cannot exceed 4 character.")]
        [Required(ErrorMessage = "Type Of Packages is a required field.")]
        public string sPrevRefTypeOfPackage { get; set; }
        [Display(Name = "First Port Of Entry")]
        [MaxLength(6, ErrorMessage = "First Port Of Entry cannot exceed 6 character.")]
        [Required(ErrorMessage = "First Port Of Entry is a required field.")]
        public string sLocCustomFirstPortOfEntry { get; set; }
        [Display(Name = "Destination Port")]
        [MaxLength(10, ErrorMessage = "Destination Port cannot exceed 10 character.")]
        [Required(ErrorMessage = "Destination Port is a required field.")]
        public string sLocCustomDestPort { get; set; }
        [Display(Name = "Next Port Of  Unlanding")]
        [MaxLength(6, ErrorMessage = "Next Port Of  Unlanding cannot exceed 6 character.")]
        [Required(ErrorMessage = "Next Port Of  Unlanding is a required field.")]
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
        [Required(ErrorMessage = "Split Indicator is a required field.")]
        public string sLocCustomSplitIndicator { get; set; }
        [Display(Name = "No. Of Packages")]
        [Required(ErrorMessage = "No. Of Packages is a required field.")]
        public decimal? dLocCustomNoOfPackages { get; set; }
        [Display(Name = "Types Of Packages")]
        [MaxLength(4, ErrorMessage = "Types Of Packages cannot exceed 4 character.")]
        [Required(ErrorMessage = "Types Of Packages is a required field.")]
        public string sLocCustomTypeOfPackage { get; set; }
        [Display(Name = "Transhipper CD")]
        [MaxLength(10, ErrorMessage = "Transhipper CD cannot exceed 10 character.")]
        [Required(ErrorMessage = "Transhipper CD is a required field.")]
        public string sTrnshprCd { get; set; }
        [Display(Name = "Transhipper Bond")]
        [MaxLength(10, ErrorMessage = "Transhipper Bond cannot exceed 10 character.")]
        [Required(ErrorMessage = "Transhipper Bond is a required field.")]
        public string sTrnshprBond { get; set; }
        [Display(Name = "Port Of Accepted CCD")]
        [MaxLength(6, ErrorMessage = "Port Of Accepted CCD cannot exceed 6 character.")]
        [Required(ErrorMessage = "Port Of Accepted CCD is a required field.")]
        public string sTrnsprtrDocPortOfAcceptedCCd { get; set; }
        [Display(Name = "Port Of Accepted Name")]
        [MaxLength(256, ErrorMessage = "Port Of Accepted Name cannot exceed 256 character.")]
        [Required(ErrorMessage = "Port Of Accepted Name is a required field.")]
        public string sTrnsprtrDocPortOfAcceptedName { get; set; }
        [Display(Name = "Port Of Receipt CCD")]
        [MaxLength(10, ErrorMessage = "Port Of Receipt CCD cannot exceed 10 character.")]
        [Required(ErrorMessage = "Port Of Receipt CCD is a required field.")]
        public string sTrnsprtrDocPortOfReceiptCcd { get; set; }
        [Display(Name = "Port Of Receipt Name")]
        [MaxLength(256, ErrorMessage = "Port Of Receipt Name cannot exceed 256 character.")]
        [Required(ErrorMessage = "Port Of Receipt Name is a required field.")]
        public string sTrnsprtrDocPortOfReceiptName { get; set; }
        [Display(Name = "Consignor Name")]
        [MaxLength(70, ErrorMessage = "Consignor Name cannot exceed 70 character.")]
        [Required(ErrorMessage = "Consignor Name is a required field.")]
        public string sTrnsprtrDocConsignorName { get; set; }
        [Display(Name = "Consignor CD")]
        [MaxLength(17, ErrorMessage = "Consignor CD cannot exceed 17 character.")]
        [Required(ErrorMessage = "Consignor CD is a required field.")]
        public string sTrnsprtrDocConsignorCd { get; set; }
        [Display(Name = "Consignor CD Type")]
        [MaxLength(3, ErrorMessage = "Consignor CD Type cannot exceed 3 character.")]
        [Required(ErrorMessage = "Consignor CD Type is a required field.")]
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
        [Required(ErrorMessage = "Consignor Country Sub Div Name is a required field.")]
        public string sTrnsprtrDocConsignorCountrySubDivName { get; set; }
        [Display(Name = "Consignor Country Sub Div CD")]
        [MaxLength(9, ErrorMessage = "Consignor Country Sub Div CD cannot exceed 9 character.")]
        [Required(ErrorMessage = "Consignor Country Sub Div CD is a required field.")]
        public string sTrnsprtrDocConsignorCountrySubDivCd { get; set; }
        [Display(Name = "Consignor Country CD")]
        [MaxLength(2, ErrorMessage = "Consignor Country CD cannot exceed 2 character.")]
        [Required(ErrorMessage = "Consignor Country CD is a required field.")]
        public string sTrnsprtrDocConsignorCountryCd { get; set; }
        [Display(Name = "Consignor Post CD")]
        [MaxLength(9, ErrorMessage = "Consignor Post CD cannot exceed 9 character.")]
        [Required(ErrorMessage = "Consignor Post CD is a required field.")]
        public string sTrnsprtrDocConsignorPostCd { get; set; }
        [Display(Name = "Consignee Name")]
        [MaxLength(70, ErrorMessage = "Consignee Name cannot exceed 70 character.")]
        [Required(ErrorMessage = "Consignee Name is a required field.")]
        public string sTrnsprtrDocConsigneeName { get; set; }
        [Display(Name = "Consignee CD")]
        [MaxLength(17, ErrorMessage = "Consignee CD cannot exceed 17 character.")]
        [Required(ErrorMessage = "Consignee CD is a required field.")]
        public string sTrnsprtrDocConsigneeCd { get; set; }
        [Display(Name = "Type Of CD")]
        [MaxLength(3, ErrorMessage = "Type Of CD cannot exceed 3 character.")]
        [Required(ErrorMessage = "Type Of CD is a required field.")]
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
        [Required(ErrorMessage = "Consignee Country Sub Div Name is a required field.")]
        public string sTrnsprtrDocConsigneeCountrySubDivName { get; set; }
        [Display(Name = "Consignee Country Sub Div")]
        [MaxLength(9, ErrorMessage = "Consignee Country Sub Div cannot exceed 9 character.")]
        [Required(ErrorMessage = "Consignee Country Sub Div is a required field.")]
        public string sTrnsprtrDocConsigneeCountrySubDiv { get; set; }
        [Display(Name = "Consignee Country CD")]
        [MaxLength(2, ErrorMessage = "Consignee Country CD cannot exceed 2 character.")]
        [Required(ErrorMessage = "Consignee Country CD is a required field.")]
        public string sTrnsprtrDocConsigneeCountryCd { get; set; }
        [Display(Name = "Consignee Post CD")]
        [MaxLength(9, ErrorMessage = "Consignee Post CD cannot exceed 9 character.")]
        [Required(ErrorMessage = "Consignee Post CD is a required field.")]
        public string sTrnsprtrDocConsigneePostCd { get; set; }
        [Display(Name = "Name Of Any Other Not Fd Party")]
        [MaxLength(70, ErrorMessage = "Name Of Any Other Not Fd Party cannot exceed 70 character.")]
        [Required(ErrorMessage = "Name Of Any Other Not Fd Party is a required field.")]
        public string sTrnsprtrDocNameOfAnyOtherNotFdParty { get; set; }
        [Display(Name = "PAN Of Not Fd Party")]
        [MaxLength(17, ErrorMessage = "PAN Of Not Fd Party cannot exceed 17 character.")]
        [Required(ErrorMessage = "PAN Of Not Fd Party is a required field.")]
        public string sTrnsprtrDocPANOfNotFdParty { get; set; }
        [Display(Name = "Type Of Not Fd Party CD")]
        [MaxLength(3, ErrorMessage = "Type Of Not Fd Party CD cannot exceed 3 character.")]
        [Required(ErrorMessage = "Type Of Not Fd Party CD is a required field.")]
        public string sTrnsprtrDocTypeOfNotFdPartyCd { get; set; }
        [Display(Name = "Not Fd Party Street Address")]
        [MaxLength(70, ErrorMessage = "Not Fd Party Street Address cannot exceed 70 character.")]
        [Required(ErrorMessage = "Not Fd Party Street Address is a required field.")]
        public string sTrnsprtrDocNotFdPartyStreetAddress { get; set; }
        [Display(Name = "Not Fd Party City")]
        [MaxLength(70, ErrorMessage = "Not Fd Party City cannot exceed 70 character.")]
        [Required(ErrorMessage = "Not Fd Party City is a required field.")]
        public string sTrnsprtrDocNotFdPartyCity { get; set; }
        [Display(Name = "Not Fd Party Country Sub Div Name")]
        [MaxLength(35, ErrorMessage = "Not Fd Party Country Sub Div Name cannot exceed 35 character.")]
        [Required(ErrorMessage = "Not Fd Party Country Sub Div Name is a required field.")]
        public string sTrnsprtrDocNotFdPartyCountrySubDivName { get; set; }
        [Display(Name = "Not Fd Party Country Sub Div")]
        [MaxLength(9, ErrorMessage = "Not Fd Party Country Sub Div cannot exceed 9 character.")]
        [Required(ErrorMessage = "Not Fd Party Country Sub Div is a required field.")]
        public string sTrnsprtrDocNotFdPartyCountrySubDiv { get; set; }
        [Display(Name = "Not Fd Party Country CD")]
        [MaxLength(3, ErrorMessage = "Not Fd Party Country CD cannot exceed 3 character.")]
        [Required(ErrorMessage = "Not Fd Party Country CD is a required field.")]
        public string sTrnsprtrDocNotFdPartyCountryCd { get; set; }
        [Display(Name = "Not Fd Party Post CD")]
        [MaxLength(9, ErrorMessage = "Not Fd Party Post CD cannot exceed 9 character.")]
        [Required(ErrorMessage = "Not Fd Party Post CD is a required field.")]
        public string sTrnsprtrDocNotFdPartyPostCd { get; set; }
        [Display(Name = "Goods Description As Per Bill")]
        [MaxLength(512, ErrorMessage = "Goods Description As Per Bill cannot exceed 512 character.")]
        [Required(ErrorMessage = "Goods Description As Per Bill is a required field.")]
        public string sTrnsprtrDocGoodsDescAsPerBill { get; set; }
        [Display(Name = "UCR Type")]
        [MaxLength(3, ErrorMessage = "UCR Type cannot exceed 3 character.")]
        [Required(ErrorMessage = "UCR Type is a required field.")]
        public string sTrnsprtrDocUCRType { get; set; }
        [Display(Name = "UCR CD")]
        [MaxLength(35, ErrorMessage = "UCR CD cannot exceed 35 character.")]
        [Required(ErrorMessage = "UCR CD is a required field.")]
        public string sTrnsprtrDocUCRCd { get; set; }
        [Display(Name = "No. Of Packages")]
        [Required(ErrorMessage = "No. Of Packages is a required field.")]
        public decimal dTrnsprtrDocMsrNoOfPackages { get; set; }
        [Display(Name = "Types Of Packages")]
        [MaxLength(3, ErrorMessage = "Types Of Packages cannot exceed 3 character.")]
        [Required(ErrorMessage = "Types Of Packages is a required field.")]
        public string sTrnsprtrDocMsrTypesOfPackages { get; set; }
        [Display(Name = "Marks No. On Packages")]
        [MaxLength(512, ErrorMessage = "Marks No. On Packages cannot exceed 512 character.")]
        [Required(ErrorMessage = "Marks No. On Packages is a required field.")]
        public string sTrnsprtrDocMsrMarksNoOnPackages { get; set; }
        [Display(Name = "Gross Weight")]
        [Required(ErrorMessage = "Gross Weight is a required field.")]
        public decimal? dTrnsprtrDocMsrGrossWeight { get; set; }
        [Display(Name = "Gross Net Weight")]
        [Required(ErrorMessage = "Gross Net Weight is a required field.")]
        public decimal? dTrnsprtrDocMsrNetWeight { get; set; }
        [Display(Name = "Unit Of Weight")]
        [MaxLength(3, ErrorMessage = "Unit Of Weight cannot exceed 3 character.")]
        [Required(ErrorMessage = "Unit Of Weight is a required field.")]
        public string sTrnsprtrDocMsrUnitOfWeight { get; set; }
        [Display(Name = "Gross Volume")]
        [Required(ErrorMessage = "Gross Volume is a required field.")]
        public decimal? dTrnsprtrDocMsrGrossVolume { get; set; }
        [Display(Name = "Unit Of Volume")]
        [MaxLength(3, ErrorMessage = "Unit Of Volume cannot exceed 3 character.")]
        [Required(ErrorMessage = "Unit Of Volume is a required field.")]
        public string sTrnsprtrDocMsrUnitOfVolume { get; set; }
        [Display(Name = "Invoice Value Of Consigment")]
        [Required(ErrorMessage = "Invoice Value Of Consigment is a required field.")]
        public decimal? dTrnsprtrDocMsrInvoiceValueOfConsigment { get; set; }
        [Display(Name = "Currency CD")]
        [MaxLength(3, ErrorMessage = "Currency CD cannot exceed 3 character.")]
        [Required(ErrorMessage = "Currency CD is a required field.")]
        public string sTrnsprtrDocMsrCurrencyCd { get; set; }
        [Display(Name = "CIN Type")]
        [MaxLength(4, ErrorMessage = "CIN Type cannot exceed 4 character.")]
        [Required(ErrorMessage = "CIN Type is a required field.")]
        public string sSuplmntryDecCinType { get; set; }
        [Display(Name = "MCIN PCIN")]
        [MaxLength(20, ErrorMessage = "MCIN PCIN cannot exceed 20 character.")]
        [Required(ErrorMessage = "MCIN PCIN is a required field.")]
        public string sSuplmntryDecMCinPCin { get; set; }
        [Display(Name = "CSN Submited Type")]
        [MaxLength(4, ErrorMessage = "CSN Submited Type cannot exceed 4 character.")]
        [Required(ErrorMessage = "CSN Submited Type is a required field.")]
        public string sSuplmntryDecCSNSubmtdType { get; set; }
        [Display(Name = "CSN Submited By")]
        [MaxLength(20, ErrorMessage = "CSN Submited By cannot exceed 20 character.")]
        [Required(ErrorMessage = "CSN Submited By is a required field.")]
        public string sSuplmntryDecCSNSubmtdBy { get; set; }
        [Display(Name = "CSN Reporting Type")]
        [MaxLength(4, ErrorMessage = "CSN Reporting Type cannot exceed 4 character.")]
        [Required(ErrorMessage = "CSN Reporting Type is a required field.")]
        public string sSuplmntryDecCSNReportingType { get; set; }
        [Display(Name = "CSN Site ID")]
        [MaxLength(6, ErrorMessage = "CSN Site ID cannot exceed 6 character.")]
        [Required(ErrorMessage = "CSN Site ID is a required field.")]
        public string sSuplmntryDecCSNSiteId { get; set; }
        [Display(Name = "CSN No.")]
        [Required(ErrorMessage = "CSN No. is a required field.")]
        public decimal dSuplmntryDecCSNNo { get; set; }
        [Display(Name = "CSN Date")]
        [Required(ErrorMessage = "CSN Date is a required field.")]
        public string dtSuplmntryDecCSNDate { get; set; }
        [Display(Name = "Previous MCIN")]
        [MaxLength(20, ErrorMessage = "Previous MCIN cannot exceed 20 character.")]
        [Required(ErrorMessage = "Previous MCIN is a required field.")]
        public string sSuplmntryDecPrevMCIN { get; set; }
        [Display(Name = "Split Indicator")]
        [MaxLength(2, ErrorMessage = "Split Indicator cannot exceed 2 character.")]
        [Required(ErrorMessage = "Split Indicator is a required field.")]
        public string sSuplmntryDecSplitIndicator { get; set; }
        [Display(Name = "No. Of Packages")]
        [Required(ErrorMessage = "No. Of Packages is a required field.")]
        public decimal dSuplmntryDecNoOfPackages { get; set; }
        [Display(Name = "Types Of Packages")]
        [MaxLength(4, ErrorMessage = "Types Of Packages cannot exceed 4 character.")]
        [Required(ErrorMessage = "Types Of Packages is a required field.")]
        public string sSuplmntryDecTypeOfPackages { get; set; }
    }
}
