using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Models
{
    public class SDN_JsonModel
    {
        public HeaderFieldN HeaderField { get; set; }
        public MasterN master { get; set; }
        public DigSignN digSign { get; set; }
    }
    public class HeaderFieldN
    {
        public string senderID { get; set; }
        public string receiverID { get; set; }
        public string versionNo { get; set; }
        public string indicator { get; set; }
        public string messageID { get; set; }
        public int sequenceOrControlNumber { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public string reportingEvent { get; set; }
    }

    public class DecRefN
    {
        public string msgTyp { get; set; }
        public string prtofRptng { get; set; }
        public int jobNo { get; set; }
        public string jobDt { get; set; }
        public string rptngEvent { get; set; }
        public int mnfstNoRotnNo { get; set; }
        public string mnfstDtRotnDt { get; set; }
        public string vesselTypMvmt { get; set; }
    }

    public class AuthPrsnN
    {
        public string sbmtrTyp { get; set; }
        public string sbmtrCd { get; set; }
        public string authReprsntvCd { get; set; }
        public string authSeaCarrierCd { get; set; }
        public string shpngLineBondNmbr { get; set; }
        public string trmnlOprtrCd { get; set; }
    }

    public class VesselDtlsN
    {
        public string modeOfTrnsprt { get; set; }
        public string typOfTrnsprtMeans { get; set; }
        public string trnsprtMeansId { get; set; }
    }

    public class ArvlDtlsN
    {
        public int nmbrOfPsngrs { get; set; }
        public int nmbrOfCrew { get; set; }
        public double lightHouseDues { get; set; }
        public int totalNoOfCntrsLanded { get; set; }
        public int totalNoOfCntrsLoaded { get; set; }
        public int totalNmbrOfPrsnsOnBoard { get; set; }
        public int totalNoOfTrnsprtEqmtRprtdOnArvlDptr { get; set; }
        public int totalNmbrOfTrnsprtContractsRprtdOnArvlDptr { get; set; }
    }

    public class MasterN
    {
        public DecRefN decRef { get; set; }
        public AuthPrsnN authPrsn { get; set; }
        public VesselDtlsN vesselDtls { get; set; }
        public ArvlDtlsN arvlDtls { get; set; }
    }

    public class DigSignN
    {
        public string startSignature { get; set; }
        public string startCertificate { get; set; }
        public string signerVersion { get; set; }
    }

}
