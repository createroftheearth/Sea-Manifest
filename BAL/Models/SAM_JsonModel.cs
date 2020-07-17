using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Models
{

    public class SAM_JsonModel
    {
        public Headerfield HeaderField { get; set; }
        public Master master { get; set; }
        public Digsign digSign { get; set; }
    }

    public class Headerfield
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

    public class Master
    {
        public Decref decRef { get; set; }
        public Authprsn authPrsn { get; set; }
        public Vesseldtls vesselDtls { get; set; }
        public Voyagedtls voyageDtls { get; set; }
        public List<Mastrcnsgmtdec> mastrCnsgmtDec { get; set; }
        public List<Prsnonboard> prsnOnBoard { get; set; }
        public List<Voyagetransportequipment> voyageTransportEquipment { get; set; }
    }

    public class Decref
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

    public class Authprsn
    {
        public string sbmtrTyp { get; set; }
        public string sbmtrCd { get; set; }
        public string authReprsntvCd { get; set; }
        public string shpngLineCd { get; set; }
        public string authSeaCarrierCd { get; set; }
        public string masterName { get; set; }
        public string shpngLineBondNmbr { get; set; }
        public string trmnlOprtrCd { get; set; }
    }

    public class Vesseldtls
    {
        public string modeOfTrnsprt { get; set; }
        public string typOfTrnsprtMeans { get; set; }
        public string trnsprtMeansId { get; set; }
        public string purposeOfCall { get; set; }
        public string shipTyp { get; set; }
    }

    public class Voyagedtls
    {
        public string voyageNo { get; set; }
        public string cnvnceRefNmbr { get; set; }
        public string totalNoOfTrnsprtEqmtMnfsted { get; set; }
        public string crgoDescCdd { get; set; }
        public string briefCrgoDesc { get; set; }
        public int totalNmbrOfLines { get; set; }
        public string exptdDtAndTimeOfArvl { get; set; }
        public string exptdDtAndTimeOfDptr { get; set; }
        public int nmbrOfPsngrsMnfsted { get; set; }
        public int nmbrOfCrewMnfsted { get; set; }
        public List<Shipitnry> shipItnry { get; set; }
    }

    public class Shipitnry
    {
        public string shipItnrySeq { get; set; }
        public string prtOfCallCdd { get; set; }
        public string prtOfCallName { get; set; }
    }

    public class Mastrcnsgmtdec
    {
        public Mcref MCRef { get; set; }
        public Loccstm locCstm { get; set; }
        public Trnsprtdoc trnsprtDoc { get; set; }
        public Trnsprtdocmsr trnsprtDocMsr { get; set; }
        public List<Itemdtl> itemDtls { get; set; }
        public List<Trnsprteqmt> trnsprtEqmt { get; set; }
        public List<Itnry> itnry { get; set; }
        public List<Housecargodec> houseCargoDec { get; set; }
    }

    public class Mcref
    {
        public int lineNo { get; set; }
        public string mstrBlNo { get; set; }
        public string mstrBlDt { get; set; }
        public string consolidatedIndctr { get; set; }
        public string prevDec { get; set; }
        public string consolidatorPan { get; set; }
    }

    public class Loccstm
    {
        public string firstPrtOfEntry { get; set; }
        public string destPrt { get; set; }
        public string nxtPrtOfUnlading { get; set; }
        public string typOfCrgo { get; set; }
        public string itemTyp { get; set; }
        public string crgoMvmt { get; set; }
        public string natrOfCrgo { get; set; }
        public string splitIndctr { get; set; }
        public int nmbrOfPkgs { get; set; }
        public string typOfPackage { get; set; }
    }

    public class Trnsprtdoc
    {
        public string prtOfAcptCdd { get; set; }
        public string prtOfAcptName { get; set; }
        public string prtOfReceiptCdd { get; set; }
        public string prtOfReceiptName { get; set; }
        public string cnsgnrsName { get; set; }
        public string cnsgnrStreetAddress { get; set; }
        public string cnsgnrCity { get; set; }
        public string cnsgnrCntryCd { get; set; }
        public string cnsgnesName { get; set; }
        public string cnsgneStreetAddress { get; set; }
        public string cnsgneCity { get; set; }
        public string cnsgneCntrySubDivName { get; set; }
        public string cnsgneCntrySubDiv { get; set; }
        public string cnsgneCntryCd { get; set; }
        public string cnsgnePstcd { get; set; }
        public string nameOfAnyOtherNotfdParty { get; set; }
        public string panOfNotfdParty { get; set; }
        public string typOfNotfdPartyCd { get; set; }
        public string notfdPartyStreetAddress { get; set; }
        public string notfdPartyCity { get; set; }
        public string notfdPartyCntrySubDivName { get; set; }
        public string notfdPartyCntrySubDiv { get; set; }
        public string notfdPartyCntryCd { get; set; }
        public string notfdPartyPstcd { get; set; }
        public string goodsDescAsPerBl { get; set; }
        public string ucrTyp { get; set; }
        public string ucrCd { get; set; }
    }

    public class Trnsprtdocmsr
    {
        public int nmbrOfPkgs { get; set; }
        public string typsOfPkgs { get; set; }
        public string marksNoOnPkgs { get; set; }
        public int grossWeight { get; set; }
        public int netWeight { get; set; }
        public string unitOfWeight { get; set; }
        public int invoiceValueOfCnsgmt { get; set; }
        public string crncyCd { get; set; }
    }

    public class Itemdtl
    {
        public string hsCd { get; set; }
        public int crgoItemSeqNmbr { get; set; }
        public string crgoItemDesc { get; set; }
        public string unoCd { get; set; }
        public string imdgCd { get; set; }
        public int nmbrOfPkgs { get; set; }
        public string typOfPkgs { get; set; }
    }

    public class Trnsprteqmt
    {
        public int eqmtSeqNo { get; set; }
        public string eqmtId { get; set; }
        public string eqmtTyp { get; set; }
        public string eqmtSize { get; set; }
        public string eqmtLoadStatus { get; set; }
        public string adtnlEqmtHold { get; set; }
        public string eqmtSealTyp { get; set; }
        public string eqmtSealNmbr { get; set; }
        public string otherEqmtId { get; set; }
        public string socFlag { get; set; }
        public string cntrAgntCd { get; set; }
        public float cntrWeight { get; set; }
        public int totalNmbrOfPkgs { get; set; }
    }

    public class Itnry
    {
        public int prtOfCallSeqNmbr { get; set; }
        public string prtOfCallCdd { get; set; }
        public string prtOfCallName { get; set; }
        public string nxtPrtOfCallCdd { get; set; }
        public string nxtPrtOfCallName { get; set; }
        public string modeOfTrnsprt { get; set; }
    }

    public class Housecargodec
    {
        public Hcref HCRef { get; set; }
        public Loccstm1 locCstm { get; set; }
        public Trnsprtdoc1 trnsprtDoc { get; set; }
        public Trnsprtdocmsr1 trnsprtDocMsr { get; set; }
        public List<Itemdtl1> itemDtls { get; set; }
        public List<Trnsprteqmt1> trnsprtEqmt { get; set; }
        public List<Itnry1> itnry { get; set; }
    }

    public class Hcref
    {
        public int subLineNo { get; set; }
        public string blNo { get; set; }
        public string blDt { get; set; }
        public string consolidatedIndctr { get; set; }
        public string prevDec { get; set; }
        public string consolidatorPan { get; set; }
    }

    public class Loccstm1
    {
        public string firstPrtOfEntry { get; set; }
        public string destPrt { get; set; }
        public string nxtPrtOfUnlading { get; set; }
        public string typOfCrgo { get; set; }
        public string itemTyp { get; set; }
        public string crgoMvmt { get; set; }
        public string natrOfCrgo { get; set; }
        public string splitIndctr { get; set; }
        public int nmbrOfPkgs { get; set; }
        public string typOfPackage { get; set; }
    }

    public class Trnsprtdoc1
    {
        public string prtOfAcptCdd { get; set; }
        public string prtOfAcptName { get; set; }
        public string prtOfReceiptCdd { get; set; }
        public string prtOfReceiptName { get; set; }
        public string cnsgnrsName { get; set; }
        public string cnsgnrsCd { get; set; }
        public string cnsgnrCdTyp { get; set; }
        public string cnsgnrStreetAddress { get; set; }
        public string cnsgnrCity { get; set; }
        public string cnsgnrCntrySubDivName { get; set; }
        public string cnsgnrCntrySubDivCd { get; set; }
        public string cnsgnrCntryCd { get; set; }
        public string cnsgnrPstcd { get; set; }
        public string cnsgnesName { get; set; }
        public string cnsgnesCd { get; set; }
        public string typOfCd { get; set; }
        public string cnsgneStreetAddress { get; set; }
        public string cnsgneCity { get; set; }
        public string cnsgneCntrySubDivName { get; set; }
        public string cnsgneCntrySubDiv { get; set; }
        public string cnsgneCntryCd { get; set; }
        public string cnsgnePstcd { get; set; }
        public string nameOfAnyOtherNotfdParty { get; set; }
        public string panOfNotfdParty { get; set; }
        public string typOfNotfdPartyCd { get; set; }
        public string notfdPartyStreetAddress { get; set; }
        public string notfdPartyCity { get; set; }
        public string notfdPartyCntrySubDivName { get; set; }
        public string notfdPartyCntrySubDiv { get; set; }
        public string notfdPartyCntryCd { get; set; }
        public string notfdPartyPstcd { get; set; }
        public string goodsDescAsPerBl { get; set; }
        public string ucrTyp { get; set; }
        public string ucrCd { get; set; }
    }

    public class Trnsprtdocmsr1
    {
        public int nmbrOfPkgs { get; set; }
        public string typsOfPkgs { get; set; }
        public string marksNoOnPkgs { get; set; }
        public int grossWeight { get; set; }
        public int netWeight { get; set; }
        public string unitOfWeight { get; set; }
        public int invoiceValueOfCnsgmt { get; set; }
        public string crncyCd { get; set; }
    }

    public class Itemdtl1
    {
        public string hsCd { get; set; }
        public int crgoItemSeqNmbr { get; set; }
        public string crgoItemDesc { get; set; }
        public string unoCd { get; set; }
        public string imdgCd { get; set; }
        public int nmbrOfPkgs { get; set; }
        public string typOfPkgs { get; set; }
    }

    public class Trnsprteqmt1
    {
        public int eqmtSeqNo { get; set; }
        public string eqmtId { get; set; }
        public string eqmtTyp { get; set; }
        public string eqmtSize { get; set; }
        public string eqmtLoadStatus { get; set; }
        public string adtnlEqmtHold { get; set; }
        public string eqmtSealTyp { get; set; }
        public string eqmtSealNmbr { get; set; }
        public string otherEqmtId { get; set; }
        public string socFlag { get; set; }
        public string cntrAgntCd { get; set; }
        public float cntrWeight { get; set; }
        public int totalNmbrOfPkgs { get; set; }
    }

    public class Itnry1
    {
        public int prtOfCallSeqNmbr { get; set; }
        public string prtOfCallCdd { get; set; }
        public string prtOfCallName { get; set; }
        public string nxtPrtOfCallCdd { get; set; }
        public string nxtPrtOfCallName { get; set; }
        public string modeOfTrnsprt { get; set; }
    }

    public class Prsnonboard
    {
        public int prsnOnBoardSeqNmbr { get; set; }
        public Prsndtls prsnDtls { get; set; }
        public Prsnid prsnId { get; set; }
    }

    public class Prsndtls
    {
        public string prsnTypCdd { get; set; }
        public string prsnFamilyName { get; set; }
        public string prsnGivenName { get; set; }
        public string prsnNatnltyCdd { get; set; }
        public int psngrInTransitIndctr { get; set; }
        public string crewmemberRankOrRatingCdd { get; set; }
        public string psngrPrtOfEmbrktnCdd { get; set; }
        public string psngrPrtOfDsmbrktnCdd { get; set; }
        public string prsnGenderCdd { get; set; }
        public string prsnDtOfBirth { get; set; }
        public string prsnPlaceOfBirthName { get; set; }
        public string prsnCntryOfBirthCdd { get; set; }
    }

    public class Prsnid
    {
        public string prsnIdDocExpiryDt { get; set; }
        public string prsnIdOrTravelDocIssuingNationCdd { get; set; }
        public string prsnIdOrTravelDocNmbr { get; set; }
        public string prsnIdOrTravelDocTypCdd { get; set; }
    }

    public class Voyagetransportequipment
    {
        public int equipmentSequenceNo { get; set; }
        public string equipmentId { get; set; }
        public string equipmentType { get; set; }
        public string equipmentSize { get; set; }
        public string equipmentLoadStatus { get; set; }
        public string additionalEquipmentHold { get; set; }
        public string equipmentSealType { get; set; }
        public string equipmentSealNumber { get; set; }
        public string otherEquipmentId { get; set; }
        public string socFlag { get; set; }
        public string containerAgentCode { get; set; }
        public int containerWeight { get; set; }
        public int totalNumberOfPackages { get; set; }
    }

    public class Digsign
    {
        public string startSignature { get; set; }
        public string startCertificate { get; set; }
        public string signerVersion { get; set; }
    }

}
