using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Models
{
    public class MessageImplementationModel
    {
        //DecRef
        public int iMessageImplementationId { get; set; }
        public string sDecRefMsgType { get; set; }
        public string sDecRefPortOfReporting { get; set; }
        public decimal? dDecRefjobNo { get; set; }
        public string dtDecRefJobDt { get; set; }
        public string sDecRefReportingEvent { get; set; }
        public decimal? dDecRefManifestNoRotnNo { get; set; }
        public string dtDecRefManifestDateRotnDt { get; set; }
        public string sDecRefVesselTypeMovement { get; set; }
        public decimal? dDecRefDptrPreviousManifestNo { get; set; }
        public string dtDecRefPreviousManifestDptrDate { get; set; }

        //AuthPrsn
        public string sAuthPrsnSubmitType { get; set; }
        public string sAuthPrsnSubmitCode { get; set; }
        public string sAuthPrsnAuthRepresentativePAN { get; set; }
        public string sAuthPrsnShipLineCode { get; set; }
        public string sAuthPrsnAuthSeaCarrierCode { get; set; }
        public string sAuthPrsnMasterName { get; set; }
        public string sAuthPrsnShippingLineBondNo { get; set; }
        public string sAuthPrsnTerminalCustodianCode { get; set; }

        //VesselDtls
        public string sVesselDtlsModeOfTransport { get; set; }
        public string sVesselDtlsTypeOfTransportMeans { get; set; }
        public string sVesselDtlsTransportMeansId { get; set; }
        public string sVesselDtlsShipType { get; set; }
        public string sVesselDtlsPurposeOfCall { get; set; }

        //VoyageDtls
        public string sVoyageDtlsVoyageNo { get; set; }
        public string sVoyageDtlsConveinceRefNo { get; set; }
        public string sVoyageDtlsTotalNumberofTrnsptEqtMnfstd { get; set; }
        public string sVoyageDtlsCargoDesCdd { get; set; }
        public string sVoyageDtlsBriefCargoDesc { get; set; }
        public string dVoyageDtlsTotalNumberOfLines { get; set; }
        public string sVoyageDtlsExpectedDtandTimeOfArrival { get; set; }
        public string sVoyageDtlsExpectedDtandTimeOfDeparture { get; set; }
        public int iVoyageDtlsNumberOfPsngrManifested { get; set; }
        public int iVoyageDtlsNumberOfCrewManifested { get; set; } 
    }
}
