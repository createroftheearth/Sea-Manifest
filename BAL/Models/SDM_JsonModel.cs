using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Models
{
   public class SDM_JsonModel
    {
        public HeaderField HeaderField { get; set; }
        public MasterM masterm { get; set; }
        public DigSignM digSign { get; set; }
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class HeaderField
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

    public class DecRefM
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

    public class AuthPrsnM
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

    public class VesselDtlsM
    {
        public string modeOfTrnsprt { get; set; }
        public string typOfTrnsprtMeans { get; set; }
        public string trnsprtMeansId { get; set; }
        public string purposeOfCall { get; set; }
        public string shipTyp { get; set; }
    }

    public class ShipItnry
    {
        public string shipItnrySeq { get; set; }
        public string prtOfCallCdd { get; set; }
        public string prtOfCallName { get; set; }
    }

    public class VoyageDtls
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
        public List<ShipItnry> shipItnry { get; set; }
    }

    public class MCRef
    {
        public int lineNo { get; set; }
        public string mstrBlNo { get; set; }
        public string mstrBlDt { get; set; }
        public string consolidatedIndctr { get; set; }
        public string prevDec { get; set; }
        public string consolidatorPan { get; set; }
    }

    public class PrevRef
    {
        public string cinTyp { get; set; }
        public string mcinPcin { get; set; }
        public string csnSbmtdTyp { get; set; }
        public string csnSbmtdBy { get; set; }
        public string csnRptngTyp { get; set; }
        public string csnSiteId { get; set; }
        public string csnNmbr { get; set; }
        public string csnDt { get; set; }
        public string prevMcin { get; set; }
        public string splitIndctr { get; set; }
        public string nmbrOfPkgs { get; set; }
        public string typOfPackage { get; set; }
    }

    public class LocCstm
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

    public class TrnsprtDoc
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

    public class TrnsprtDocMsr
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

    public class ItemDtl
    {
        public string hsCd { get; set; }
        public int crgoItemSeqNmbr { get; set; }
        public string crgoItemDesc { get; set; }
        public string unoCd { get; set; }
        public string imdgCd { get; set; }
        public string nmbrOfPkgs { get; set; }
        public string typOfPkgs { get; set; }
    }

    public class TrnsprtEqmt
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
        public double cntrWeight { get; set; }
        public int totalNmbrOfPkgs { get; set; }
    }

    public class ItnryD
    {
        public int prtOfCallSeqNmbr { get; set; }
        public string prtOfCallCdd { get; set; }
        public string prtOfCallName { get; set; }
        public string nxtPrtOfCallCdd { get; set; }
        public string nxtPrtOfCallName { get; set; }
        public string modeOfTrnsprt { get; set; }
    }

    public class HCRef
    {
        public int subLineNo { get; set; }
        public string blNo { get; set; }
        public string blDt { get; set; }
        public string consolidatedIndctr { get; set; }
        public string prevDec { get; set; }
        public string consolidatorPan { get; set; }
    }

    public class LocCstm2
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

    public class TrnsprtDoc2
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

    public class TrnsprtDocMsr2
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

    public class ItemDtl2
    {
        public string hsCd { get; set; }
        public int crgoItemSeqNmbr { get; set; }
        public string crgoItemDesc { get; set; }
        public string unoCd { get; set; }
        public string imdgCd { get; set; }
        public int nmbrOfPkgs { get; set; }
        public string typOfPkgs { get; set; }
    }

    public class TrnsprtEqmt2
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
        public double cntrWeight { get; set; }
        public int totalNmbrOfPkgs { get; set; }
    }

    public class Itnry2
    {
        public int prtOfCallSeqNmbr { get; set; }
        public string prtOfCallCdd { get; set; }
        public string prtOfCallName { get; set; }
        public string nxtPrtOfCallCdd { get; set; }
        public string nxtPrtOfCallName { get; set; }
        public string modeOfTrnsprt { get; set; }
    }

    public class HouseCargoDec
    {
        public HCRef HCRef { get; set; }
        public LocCstm2 locCstm { get; set; }
        public TrnsprtDoc2 trnsprtDoc { get; set; }
        public TrnsprtDocMsr2 trnsprtDocMsr { get; set; }
        public List<ItemDtl2> itemDtls { get; set; }
        public List<TrnsprtEqmt2> trnsprtEqmt { get; set; }
        public List<Itnry2> itnry { get; set; }
    }

    public class MastrCnsgmtDec
    {
        public MCRef MCRef { get; set; }
        public LocCstm locCstm { get; set; }
        public TrnsprtDoc trnsprtDoc { get; set; }
        public TrnsprtDocMsr trnsprtDocMsr { get; set; }
        public List<ItemDtl> itemDtls { get; set; }
        public List<TrnsprtEqmt> trnsprtEqmt { get; set; }
        public List<Itnry> itnry { get; set; }
        public List<HouseCargoDec> houseCargoDec { get; set; }
    }

    public class PrsnDtls
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

    public class PrsnId
    {
        public string prsnIdDocExpiryDt { get; set; }
        public string prsnIdOrTravelDocIssuingNationCdd { get; set; }
        public string prsnIdOrTravelDocNmbr { get; set; }
        public string prsnIdOrTravelDocTypCdd { get; set; }
    }

    public class CrewEfct
    {
        public int crewEfctsSeqNmbr { get; set; }
        public string crewEfctDescCdd { get; set; }
        public string crewEfctsDesc { get; set; }
        public int crewEfctQntyOnbrd { get; set; }
        public string crewEfctQntyCdOnbrd { get; set; }
    }

    public class PrsnOnBoard
    {
        public int prsnOnBoardSeqNmbr { get; set; }
        public PrsnDtls prsnDtls { get; set; }
        public PrsnId prsnId { get; set; }
        public List<CrewEfct> crewEfct { get; set; }
    }

    public class ShipStore
    {
        public int seqNmbr { get; set; }
        public string articleNameCdd { get; set; }
        public string articleNameText { get; set; }
        public string locOnbrdText { get; set; }
        public int qntyOnbrd { get; set; }
        public string qntyCdOnbrd { get; set; }
    }

    public class VoyageTransportEquipment
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

    public class MasterM
    {
        public DecRefM decRef { get; set; }
        public AuthPrsnM authPrsn { get; set; }
        public VesselDtlsM vesselDtls { get; set; }
        public VoyageDtls voyageDtls { get; set; }
        public List<MastrCnsgmtDec> mastrCnsgmtDec { get; set; }
        public List<PrsnOnBoard> prsnOnBoard { get; set; }
        public List<ShipStore> shipStores { get; set; }
        public List<VoyageTransportEquipment> voyageTransportEquipment { get; set; }
    }

    public class DigSignM
    {
        public string startSignature { get; set; }
        public string startCertificate { get; set; }
        public string signerVersion { get; set; }
    }


}
