using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Models
{
    public class MessageImplementationModel
    {
        //DecRef
        public int iMessageImplementationId { get; set; }

        [Display(Name = "Sender ID")]
        [MaxLength(30, ErrorMessage = "Sender ID cannot exceed 30 character.")]
        [Required(ErrorMessage = "Sender ID is a required field.")]
        public string sSenderID { get; set; }
        [Display(Name = "Receiver ID")]
        [MaxLength(30, ErrorMessage = "Receiver ID cannot exceed 30 character.")]
        [Required(ErrorMessage = "Receiver ID is a required field.")]
        public string sReceiverID { get; set; }
        [Display(Name = "Version No")]
        [MaxLength(7, ErrorMessage = "Version No cannot exceed 1 character.")]
        public string sVersionNo { get; set; }
        [Display(Name = "Indicator")]
        [MaxLength(1, ErrorMessage = "Indicator cannot exceed 1 character.")]
        public string sIndicator { get; set; }
        [Display(Name = "Message ID")]
        [MaxLength(7, ErrorMessage = "Message ID cannot exceed 7 character.")]
        [Required(ErrorMessage = "Message ID is a required field.")]
        public string sMessageID { get; set; }
        [Display(Name = "Sequence Or Control Number ")]
        [Required(ErrorMessage = "Sequence Or Control Number  is a required field.")]
        [Range(1, 9999999,ErrorMessage = "Sequence Or Control Number should be in 1 to 9999999")]
        public decimal? dSequenceOrControlNumber { get; set; }
        [Display(Name = "Date Time")]
        [Required(ErrorMessage = "Date Time is a required field.")]
        public string sDateTime { get; set; }
        [Display(Name = "Message Type")]
        [MaxLength(1, ErrorMessage = "Message Type cannot exceed 1 character.")]
        [Required(ErrorMessage = "Message Type is a required field.")]
        public string sDecRefMsgType { get; set; }
        [Display(Name = "Port Of Reporting")]
        [MaxLength(6, ErrorMessage = "Port Of Reporting cannot exceed 6 character.")]
        [Required(ErrorMessage = "Port Of Reporting is a required field.")]
        public string sDecRefPortOfReporting { get; set; }
        [Display(Name = "Job No")]
        [Required(ErrorMessage ="Job No is a required field.")]
        public decimal? dDecRefjobNo { get; set; }
        [Display(Name = "Job Date")]
        [Required(ErrorMessage ="Job Date is a required field.")]
        public string sDecRefJobDt { get; set; }
        [Display(Name = "Reporting Event")]
        [MaxLength(4, ErrorMessage = "Reporting Event cannot exceed 4 character.")]
        [Required(ErrorMessage = "Reporting Event is a required field.")]
        public string sDecRefReportingEvent { get; set; }
        [Display(Name = "Manifest No Rotation No")]
        [Required(ErrorMessage = "Manifest No Rotation No is a required field.")]
        public decimal? dDecRefManifestNoRotnNo { get; set; }
        [Display(Name = "Manifest Date Rotation Date")]
        [Required(ErrorMessage = "Manifest Date Rotation Date is a required field.")]
        public string sDecRefManifestDateRotnDt { get; set; }
        [Display(Name = "Vessel Type Movement")]
        [MaxLength(2, ErrorMessage = "Vessel Type Movement cannot exceed 2 character.")]
        public string sDecRefVesselTypeMovement { get; set; }
        [Display(Name = "Departure Previous Manifest No")]
        public decimal? dDecRefDptrPreviousManifestNo { get; set; }
        [Display(Name = "Previous Manifest Departure Date")]
        public string sDecRefPreviousManifestDptrDate { get; set; }

        //AuthPrsn
        [Display(Name = "Submit Type")]
        [MaxLength(4, ErrorMessage = "Submit Type cannot exceed 4 character.")]
        [Required(ErrorMessage = "Submit Type is a required field.")]
        public string sAuthPrsnSubmitType { get; set; }
        [Display(Name = "Submit Code")]
        [MaxLength(15, ErrorMessage = "Submit Code cannot exceed 15 character.")]
        [Required(ErrorMessage = "Submit Code is a required field.")]
        public string sAuthPrsnSubmitCode { get; set; }
        [Display(Name = "Auth Representative PAN")]
        [MaxLength(10, ErrorMessage = "Auth Representative PAN cannot exceed 10 character.")]
        [Required(ErrorMessage = "Auth Representative PAN is a required field.")]
        [RegularExpression(@"[A-Z]{5}\d{4}[A-Z]{1}", ErrorMessage = "Please Enter valid PAN Card")]
        public string sAuthPrsnAuthRepresentativePAN { get; set; }
        [Display(Name = "Shipping Line Code")]
        [MaxLength(10, ErrorMessage = "Shipping Line Code cannot exceed 10 character.")]
        public string sAuthPrsnShipLineCode { get; set; }
        [Display(Name = "Auth Sea Carrier Code")]
        [MaxLength(10, ErrorMessage = "Auth Sea Carrier Code cannot exceed 10 character.")]
        public string sAuthPrsnAuthSeaCarrierCode { get; set; }
        [Display(Name = "Master Name")]
        [MaxLength(30, ErrorMessage = "Master Name cannot exceed 30 character.")]
        public string sAuthPrsnMasterName { get; set; }
        [Display(Name = "Shipping Line Bond No")]
        [MaxLength(10, ErrorMessage = "Shipping Line Bond No cannot exceed 10 character.")]
        public string sAuthPrsnShippingLineBondNo { get; set; }
        [Display(Name = "Terminal Custodian Code")]
        [MaxLength(10, ErrorMessage = "Terminal Custodian Code cannot exceed 10 character.")]
        public string sAuthPrsnTerminalCustodianCode { get; set; }

        //VesselDtls
        [Display(Name = "Mode Of Transport")]
        [MaxLength(4, ErrorMessage = "Mode Of Transport cannot exceed 4 character.")]
        public string sVesselDtlsModeOfTransport { get; set; }
        [Display(Name = "Type Of Transport Means")]
        [MaxLength(25, ErrorMessage = "Type Of Transport Means cannot exceed 25 character.")]
        public string sVesselDtlsTypeOfTransportMeans { get; set; }
        [Display(Name = "Transport Means Id")]
        [MaxLength(25, ErrorMessage = "Transport Means Id cannot exceed 25 character.")]
        public string sVesselDtlsTransportMeansId { get; set; }
        [Display(Name ="Vessel Code")]
        [MaxLength(10,ErrorMessage ="Vessel Code cannot exceed 10 characters.")]
        public string sVesselDtlsVesselCode { get; set; }
        [Display(Name ="Nationality of Ship")]
        [MaxLength(70,ErrorMessage ="Nationality of ship cannot exceed 70 characters.")]
        public string sVesselDtlsNationalityOfShip { get; set; }
        [Display(Name ="Port of Registry")]
        [MaxLength(6,ErrorMessage ="Port of Registry cannot exceed 6 characters.")]
        public string sVesselDtlsPortOfRegistry { get; set; }
        [Display(Name ="Registry Date")]
        public string sVesselDtlsRegistryDate { get; set; }
        [Display(Name ="Registry Number")]
        [MaxLength(35,ErrorMessage ="Registry Number cannot exceed 35 characters")]
        public string sVesselDtlsRegistryNo { get; set; }
        [Display(Name ="Gross Tonnage")]
        public decimal? dVesselDtlsGrossTonnage { get; set; }
        [Display(Name ="Net Tonnage")]
        public decimal? dVesselDtlsNetTonnage { get; set; }

        [Display(Name = "Ship Type")]
        [MaxLength(3, ErrorMessage = "Ship Type cannot exceed 3 character.")]
        public string sVesselDtlsShipType { get; set; }
        [Display(Name = "Purpose Of Call")]
        [MaxLength(3, ErrorMessage = "Purpose Of Call cannot exceed 3 character.")]
        public string sVesselDtlsPurposeOfCall { get; set; }

        //VoyageDtls
        [Display(Name = "Voyage No")]
        [MaxLength(10, ErrorMessage = "Voyage No cannot exceed 10 character.")]
        public string sVoyageDtlsVoyageNo { get; set; }
        [Display(Name = "Conveyance Ref No")]
        [MaxLength(35, ErrorMessage = "Conveyance Ref No cannot exceed 35 character.")]
        public string sVoyageDtlsConveinceRefNo { get; set; }
        [Display(Name = "Total No. of Transport Equipment Manifested")]
        [MaxLength(5, ErrorMessage = "Total No. of Transport Equipment Manifested cannot exceed 5 character.")]
        public string sVoyageDtlsTotalNumberofTrnsptEqtMnfstd { get; set; }
        [Display(Name = "Cargo Description,Coded")]
        [MaxLength(3, ErrorMessage = "Cargo Description,Coded cannot exceed 3 character.")]
        public string sVoyageDtlsCargoDesCdd { get; set; }
        [Display(Name = "Brief Cargo Description")]
        [MaxLength(30, ErrorMessage = "Brief Cargo Description cannot exceed 30 character.")]
        public string sVoyageDtlsBriefCargoDesc { get; set; }
        [Display(Name = "Total number of Transport Contracts Manifested")]
        [Range(0,99999,ErrorMessage ="Total number of Transport Contaracts Manifisted should be in between 0 to 99999")]
        public decimal? dVoyageDtlsTotalNumberOfLines { get; set; }
        [Display(Name = "Expected date and time of arrival")]
        public string sVoyageDtlsExpectedDtandTimeOfArrival { get; set; }
        [Display(Name = "Expected date and time of Departure")]
        public string sVoyageDtlsExpectedDtandTimeOfDeparture { get; set; }
        [Display(Name = "Number Of Passenger Manifested")]
        public int iVoyageDtlsNumberOfPsngrManifested { get; set; }
        [Display(Name = "Number Of Crew Manifested")]
        public int iVoyageDtlsNumberOfCrewManifested { get; set; }
        [Display(Name ="Number of Passengers")]
        public int? iArvlDtlsNumberOfPassengers { get; set; }
        [Display(Name ="No of Crew")]
        public int? iArvlDtlsNumberOfCrew { get; set; }
        [Display(Name ="Total No of containers landed")]
        public int? iArvlDtlsTotalNoOfCntrsLanded { get; set; }
        [Display(Name ="Total No of containers loaded")]
        public int? iArvlDtlsTotalOfCntrsLoaded { get; set; }
        [Display(Name ="Total No of person on board")]
        public int? iArvlDtlsTotalNoOfPersonOnBoard { get; set; }
        [Display(Name ="Total No of transport equipment reported on Arrival/Departure")]
        public int? iArvlDtlsTotalNoOfTrnsprtEqReprtdOnArrDptr { get; set; }
        [Display(Name ="Total No of transport equipment contracts on Arrival/Departure")]
        public int? iArvlDtlsTotalNoOfTrnsprtCntrctReprtdOnArrDptr { get; set; }
        [Display(Name ="Light House Dues")]
        [Range(0,999999999,ErrorMessage ="Light House Dues should be in between 0 to 999999999")]
        public decimal? iArvlDtlsLightHouseDues { get; set; }

        [Required(ErrorMessage ="Start Signature is a required field.")]
        [Display(Name ="Start Signature")]
        public string sDigiSignStartSignature { get; set; }
        [Required(ErrorMessage = "Start Certificate is a required field.")]
        [Display(Name ="Start Certificate")]
        public string sDigiSignStartCertificate { get; set; }
        [Required(ErrorMessage = "Signer Version is a required field.")]
        [Display(Name ="Start Version")]
        public string sDigiSignSignerVersion { get; set; }

    }
}
