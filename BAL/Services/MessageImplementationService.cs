using BAL.Models;
using BAL.Utilities;
using DAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BAL.Services
{
    public class MessageImplementationService
    {
        private MessageImplementationService()
        {
        }

        private static MessageImplementationService _instance;

        public static MessageImplementationService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MessageImplementationService();
                return _instance;
            }
        }

        public void Validate(int? iMessageImplementationId)
        {
            using (var db = new SeaManifestEntities())
            {
                if (!db.tblMessageImplementations.Any(z => z.iMessageImplementationId == iMessageImplementationId))
                    throw new Exception("Invalid Message Implementation Id");
            }
        }

        public object GetMessages(string search, int start, int length, out int recordsTotal)
        {
            using (var db = new SeaManifestEntities())
            {
                var query = from t in db.tblMessageImplementations
                            where t.sHeaderFieldIndicator.Contains(search) || t.sHeaderFieldMessageId.Contains(search)
                            || t.sHeaderFieldSenderId.Contains(search) || t.sHeaderFieldReceiverId.Contains(search) || t.sHeaderFieldReportingEvent.Contains(search)
                            || t.sHeaderFieldVersionNo.Contains(search) || SqlFunctions.StringConvert(t.dHeaderFieldSequenceOrControlNumber).Contains(search)
                            select t;
                recordsTotal = query.Count();
                return query.OrderBy(z => z.dHeaderFieldSequenceOrControlNumber).Take(length).Skip(start).ToList().Select(t => new
                {
                    t.sHeaderFieldSenderId,
                    t.sHeaderFieldIndicator,
                    t.sHeaderFieldMessageId,
                    t.sHeaderFieldReceiverId,
                    t.sHeaderFieldReportingEvent,
                    t.sHeaderFieldVersionNo,
                    FieldSequenceOrControlNumber = t.dHeaderFieldSequenceOrControlNumber?.ToString("#"),
                    Date = t.dtHeaderFieldDateTime.ToDateString(),
                    Time = t.dtHeaderFieldDateTime?.ToString("hh:mm tt", CultureInfo.InvariantCulture),
                    t.iMessageImplementationId,
                    t.sDecRefReportingEvent
                }).ToList();
            }
        }
        //authprsn
        public object SaveMessage(MessageImplementationModel model, int iUserId)
        {
            try
            {
                using (var db = new SeaManifestEntities())
                {
                    var data = db.tblMessageImplementations.Where(z => z.iMessageImplementationId == model.iMessageImplementationId).SingleOrDefault();
                    if (data == null)
                    {
                        data = new tblMessageImplementation
                        {
                            dHeaderFieldSequenceOrControlNumber = model.dSequenceOrControlNumber,
                            dtHeaderFieldDateTime = model.sDateTime.ToDateTime(),
                            sHeaderFieldIndicator = model.sIndicator,
                            sHeaderFieldMessageId = model.sMessageID,
                            sHeaderFieldReceiverId = model.sReceiverID,
                            sHeaderFieldReportingEvent = model.sReportingEvent,
                            sHeaderFieldSenderId = model.sSenderID,
                            sHeaderFieldVersionNo = model.sVersionNo,
                            sDecRefMsgType = model.sDecRefMsgType,
                            sDecRefPortOfReporting = model.sDecRefPortOfReporting,
                            dDecRefjobNo = model.dDecRefjobNo,
                            dtDecRefJobDt = model.sDecRefJobDt.ToDate(),
                            sDecRefReportingEvent = model.sDecRefReportingEvent,
                            dDecRefManifestNoRotnNo = model.dDecRefManifestNoRotnNo,
                            dtDecRefManifestDateRotnDt = model.sDecRefManifestDateRotnDt.ToDate(),
                            sDecRefVesselTypeMovement = model.sDecRefVesselTypeMovement,
                            dDecRefDptrPreviousManifestNo = model.dDecRefDptrPreviousManifestNo,
                            dtDecRefPreviousManifestDptrDate = model.sDecRefPreviousManifestDptrDate.ToDate(),
                            sAuthPrsnSubmitType = model.sAuthPrsnSubmitType,
                            sAuthPrsnSubmitCode = model.sAuthPrsnSubmitCode,
                            sAuthPrsnAuthRepresentativePAN = model.sAuthPrsnAuthRepresentativePAN,
                            sAuthPrsnShipLineCode = model.sAuthPrsnShipLineCode,
                            sAuthPrsnAuthSeaCarrierCode = model.sAuthPrsnAuthSeaCarrierCode,
                            sAuthPrsnMasterName = model.sAuthPrsnMasterName,
                            sAuthPrsnShippingLineBondNo = model.sAuthPrsnShippingLineBondNo,
                            sAuthPrsnTerminalCustodianCode = model.sAuthPrsnTerminalCustodianCode,
                            sVesselDtlsModeOfTransport = model.sVesselDtlsModeOfTransport,
                            sVesselDtlsTypeOfTransportMeans = model.sVesselDtlsTypeOfTransportMeans,
                            sVesselDtlsTransportMeansId = model.sVesselDtlsTransportMeansId,
                            dVesselDtlsGrossTonnage = model.dVesselDtlsGrossTonnage,
                            dVesselDtlsNetTonnage = model.dVesselDtlsNetTonnage,
                            sVesselDtlsNationalityOfShip = model.sVesselDtlsNationalityOfShip,
                            sVesselDtlsPortOfRegistry = model.sVesselDtlsPortOfRegistry,
                            sVesselDtlsVesselCode = model.sVesselDtlsVesselCode,
                            sVesselDtlsRegistryNo = model.sVesselDtlsRegistryNo,
                            dtVesselDtlsRegistryDate = model.sVesselDtlsRegistryDate.ToDate(),
                            sVesselDtlsShipType = model.sVesselDtlsShipType,
                            sVesselDtlsPurposeOfCall = model.sVesselDtlsPurposeOfCall,
                            sVoyageDtlsVoyageNo = model.sVoyageDtlsVoyageNo,
                            sVoyageDtlsConveinceRefNo = model.sVoyageDtlsConveinceRefNo,
                            sVoyageDtlsTotalNumberofTrnsptEqtMnfstd = model.sVoyageDtlsTotalNumberofTrnsptEqtMnfstd,
                            sVoyageDtlsCargoDesCdd = model.sVoyageDtlsCargoDesCdd,
                            sVoyageDtlsBriefCargoDesc = model.sVoyageDtlsBriefCargoDesc,
                            dVoyageDtlsTotalNumberOfLines = model.dVoyageDtlsTotalNumberOfLines,
                            dtVoyageDtlsExpectedDtandTimeOfArrival = model.sVoyageDtlsExpectedDtandTimeOfArrival.ToDateTime(),
                            dtVoyageDtlsExpectedDtandTimeOfDeparture = model.sVoyageDtlsExpectedDtandTimeOfDeparture.ToDateTime(),
                            iVoyageDtlsNumberOfCrewManifested = model.iVoyageDtlsNumberOfCrewManifested,
                            iArvlDtlsNumberOfPassengers = model.iArvlDtlsNumberOfPassengers,
                            iArvlDtlsNumberOfCrew = model.iArvlDtlsNumberOfCrew,
                            iArvlDtlsTotalNoOfCntrsLanded = model.iArvlDtlsTotalNoOfCntrsLanded,
                            iArvlDtlsTotalOfCntrsLoaded = model.iArvlDtlsTotalOfCntrsLoaded,
                            iArvlDtlsTotalNoOfPersonOnBoard = model.iArvlDtlsTotalNoOfPersonOnBoard,
                            iArvlDtlsTotalNoOfTrnsprtEqReprtdOnArrDptr = model.iArvlDtlsTotalNoOfTrnsprtEqReprtdOnArrDptr,
                            iArvlDtlsTotalNoOfTrnsprtCntrctReprtdOnArrDptr1 = model.iArvlDtlsTotalNoOfTrnsprtCntrctReprtdOnArrDptr,
                            iArvlDtlsLightHouseDues = model.iArvlDtlsLightHouseDues,
                            sDigiSignSignerVersion = model.sDigiSignSignerVersion,
                            sDigiSignStartCertificate = model.sDigiSignStartCertificate,
                            sDigiSignStartSignature = model.sDigiSignStartSignature,
                            iActionBy = iUserId,
                            dtActionDate = DateTime.Now,
                        };
                        db.tblMessageImplementations.Add(data);
                        db.SaveChanges();
                    }
                    else
                    {
                        data.dHeaderFieldSequenceOrControlNumber = model.dSequenceOrControlNumber;
                        data.dtHeaderFieldDateTime = model.sDateTime.ToDateTime();
                        data.sHeaderFieldIndicator = model.sIndicator;
                        data.sHeaderFieldMessageId = model.sMessageID;
                        data.sHeaderFieldReceiverId = model.sReceiverID;
                        data.sHeaderFieldReportingEvent = model.sReportingEvent;
                        data.sHeaderFieldSenderId = model.sSenderID;
                        data.sHeaderFieldVersionNo = model.sVersionNo;
                        data.sDecRefMsgType = model.sDecRefMsgType;
                        data.sDecRefPortOfReporting = model.sDecRefPortOfReporting;
                        data.dDecRefjobNo = model.dDecRefjobNo;
                        data.dtDecRefJobDt = model.sDecRefJobDt.ToDate();
                        data.sDecRefReportingEvent = model.sDecRefReportingEvent;
                        data.dDecRefManifestNoRotnNo = model.dDecRefManifestNoRotnNo;
                        data.dtDecRefManifestDateRotnDt = model.sDecRefManifestDateRotnDt.ToDate();
                        data.sDecRefVesselTypeMovement = model.sDecRefVesselTypeMovement;
                        data.dDecRefDptrPreviousManifestNo = model.dDecRefDptrPreviousManifestNo;
                        data.dtDecRefPreviousManifestDptrDate = model.sDecRefPreviousManifestDptrDate.ToDate();
                        data.sAuthPrsnSubmitType = model.sAuthPrsnSubmitType;
                        data.sAuthPrsnSubmitCode = model.sAuthPrsnSubmitCode;
                        data.sAuthPrsnAuthRepresentativePAN = model.sAuthPrsnAuthRepresentativePAN;
                        data.sAuthPrsnShipLineCode = model.sAuthPrsnShipLineCode;
                        data.sAuthPrsnAuthSeaCarrierCode = model.sAuthPrsnAuthSeaCarrierCode;
                        data.sAuthPrsnMasterName = model.sAuthPrsnMasterName;
                        data.sAuthPrsnShippingLineBondNo = model.sAuthPrsnShippingLineBondNo;
                        data.sAuthPrsnTerminalCustodianCode = model.sAuthPrsnTerminalCustodianCode;
                        data.sVesselDtlsModeOfTransport = model.sVesselDtlsModeOfTransport;
                        data.sVesselDtlsTypeOfTransportMeans = model.sVesselDtlsTypeOfTransportMeans;
                        data.sVesselDtlsTransportMeansId = model.sVesselDtlsTransportMeansId;
                        data.dVesselDtlsGrossTonnage = model.dVesselDtlsGrossTonnage;
                        data.dVesselDtlsNetTonnage = model.dVesselDtlsNetTonnage;
                        data.sVesselDtlsNationalityOfShip = model.sVesselDtlsNationalityOfShip;
                        data.sVesselDtlsPortOfRegistry = model.sVesselDtlsPortOfRegistry;
                        data.sVesselDtlsVesselCode = model.sVesselDtlsVesselCode;
                        data.sVesselDtlsRegistryNo = model.sVesselDtlsRegistryNo;
                        data.dtVesselDtlsRegistryDate = model.sVesselDtlsRegistryDate.ToDate();
                        data.sVesselDtlsShipType = model.sVesselDtlsShipType;
                        data.sVesselDtlsPurposeOfCall = model.sVesselDtlsPurposeOfCall;
                        data.sVoyageDtlsVoyageNo = model.sVoyageDtlsVoyageNo;
                        data.sVoyageDtlsConveinceRefNo = model.sVoyageDtlsConveinceRefNo;
                        data.sVoyageDtlsTotalNumberofTrnsptEqtMnfstd = model.sVoyageDtlsTotalNumberofTrnsptEqtMnfstd;
                        data.sVoyageDtlsCargoDesCdd = model.sVoyageDtlsCargoDesCdd;
                        data.sVoyageDtlsBriefCargoDesc = model.sVoyageDtlsBriefCargoDesc;
                        data.dVoyageDtlsTotalNumberOfLines = model.dVoyageDtlsTotalNumberOfLines;
                        data.dtVoyageDtlsExpectedDtandTimeOfArrival = model.sVoyageDtlsExpectedDtandTimeOfArrival.ToDateTime();
                        data.dtVoyageDtlsExpectedDtandTimeOfDeparture = model.sVoyageDtlsExpectedDtandTimeOfDeparture.ToDateTime();
                        data.iVoyageDtlsNumberOfPsngrManifested = model.iVoyageDtlsNumberOfPsngrManifested;
                        data.iVoyageDtlsNumberOfCrewManifested = model.iVoyageDtlsNumberOfCrewManifested;
                        data.iArvlDtlsNumberOfPassengers = model.iArvlDtlsNumberOfPassengers;
                        data.iArvlDtlsNumberOfCrew = model.iArvlDtlsNumberOfCrew;
                        data.iArvlDtlsTotalNoOfCntrsLanded = model.iArvlDtlsTotalNoOfCntrsLanded;
                        data.iArvlDtlsTotalOfCntrsLoaded = model.iArvlDtlsTotalOfCntrsLoaded;
                        data.iArvlDtlsTotalNoOfPersonOnBoard = model.iArvlDtlsTotalNoOfPersonOnBoard;
                        data.iArvlDtlsTotalNoOfTrnsprtEqReprtdOnArrDptr = model.iArvlDtlsTotalNoOfTrnsprtEqReprtdOnArrDptr;
                        data.iArvlDtlsTotalNoOfTrnsprtCntrctReprtdOnArrDptr1 = model.iArvlDtlsTotalNoOfTrnsprtCntrctReprtdOnArrDptr;
                        data.iArvlDtlsLightHouseDues = model.iArvlDtlsLightHouseDues;
                        data.sDigiSignSignerVersion = model.sDigiSignSignerVersion;
                        data.sDigiSignStartCertificate = model.sDigiSignStartCertificate;
                        data.sDigiSignStartSignature = model.sDigiSignStartSignature;
                        data.iActionBy = iUserId;
                        data.dtActionDate = DateTime.Now;
                        db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return new { Status = true, Message = "Master saved successfully!" };
                }

            }
            catch (Exception)
            {
                return new { Status = false, Message = "Something went wrong" };
            }
        }

        public byte[] GetMessageJson(int iMessageImplementationId)
        {
            string Json = string.Empty;
            using (var db = new SeaManifestEntities())
            {
                var query = db.tblMessageImplementations.Where(z => z.iMessageImplementationId == iMessageImplementationId);
                if (query.Any(z => z.sHeaderFieldReportingEvent == "SAM"))
                {
                    Json = JsonConvert.SerializeObject(query.ToList().Select(z => new SAM_JsonModel
                    {
                        HeaderField = new Headerfield
                        {
                            date = z.dtHeaderFieldDateTime?.ToString("yyyyMMdd", CultureInfo.InvariantCulture),
                            time = "T" + z.dtHeaderFieldDateTime?.ToString("hh:mm", CultureInfo.InvariantCulture),
                            reportingEvent = z.sHeaderFieldReportingEvent,
                            indicator = z.sHeaderFieldIndicator,
                            messageID = z.sHeaderFieldMessageId,
                            receiverID = z.sHeaderFieldReceiverId,
                            senderID = z.sHeaderFieldSenderId,
                            sequenceOrControlNumber = Convert.ToInt32(z.dHeaderFieldSequenceOrControlNumber),
                            versionNo = z.sHeaderFieldVersionNo,
                        },
                        master = new Master
                        {
                            authPrsn = new Authprsn
                            {
                                authReprsntvCd = z.sAuthPrsnAuthRepresentativePAN,
                                authSeaCarrierCd = z.sAuthPrsnAuthSeaCarrierCode,
                                masterName = z.sAuthPrsnMasterName,
                                sbmtrCd = z.sAuthPrsnSubmitCode,
                                sbmtrTyp = z.sAuthPrsnSubmitType,
                                shpngLineBondNmbr = z.sAuthPrsnShippingLineBondNo,
                                shpngLineCd = z.sAuthPrsnShipLineCode,
                                trmnlOprtrCd = z.sAuthPrsnTerminalCustodianCode
                            },
                            decRef = new Decref
                            {
                                jobDt = z.dtDecRefJobDt?.ToString("yyyyMMdd", CultureInfo.InvariantCulture),
                                jobNo = Convert.ToInt32(z.dDecRefjobNo),
                                mnfstDtRotnDt = z.dtDecRefManifestDateRotnDt?.ToString("yyyyMMdd", CultureInfo.InvariantCulture),
                                mnfstNoRotnNo = Convert.ToInt32(z.dDecRefManifestNoRotnNo),
                                msgTyp = z.sDecRefMsgType,
                                prtofRptng = z.sDecRefPortOfReporting,
                                rptngEvent = z.sDecRefReportingEvent,
                                vesselTypMvmt = z.sDecRefVesselTypeMovement,
                            },
                            vesselDtls = new Vesseldtls
                            {
                                modeOfTrnsprt = z.sVesselDtlsModeOfTransport,
                                purposeOfCall = z.sVesselDtlsPurposeOfCall,
                                shipTyp = z.sVesselDtlsShipType,
                                trnsprtMeansId = z.sVesselDtlsTransportMeansId,
                                typOfTrnsprtMeans = z.sVesselDtlsTypeOfTransportMeans
                            },
                            voyageDtls = new Voyagedtls
                            {
                                briefCrgoDesc = z.sVoyageDtlsBriefCargoDesc,
                                cnvnceRefNmbr = z.sVoyageDtlsConveinceRefNo,
                                crgoDescCdd = z.sVoyageDtlsCargoDesCdd,
                                exptdDtAndTimeOfArvl = z.dtVoyageDtlsExpectedDtandTimeOfArrival?.ToString("yyyyMMddThh:mm", CultureInfo.InvariantCulture),
                                exptdDtAndTimeOfDptr = z.dtVoyageDtlsExpectedDtandTimeOfDeparture?.ToString("yyyyMMddThh:mm", CultureInfo.InvariantCulture),
                                nmbrOfCrewMnfsted = z.iVoyageDtlsNumberOfCrewManifested ?? 0,
                                nmbrOfPsngrsMnfsted = z.iVoyageDtlsNumberOfPsngrManifested ?? 0,
                                totalNmbrOfLines = Convert.ToInt32(z.dVoyageDtlsTotalNumberOfLines),
                                totalNoOfTrnsprtEqmtMnfsted = z.sVoyageDtlsTotalNumberofTrnsptEqtMnfstd,
                                voyageNo = z.sVoyageDtlsVoyageNo,
                                shipItnry = new List<Shipitnry>()
                            },
                            mastrCnsgmtDec = z.tblMasterConsignmentMessageImplementationMaps.Select(m => new Mastrcnsgmtdec
                            {
                                locCstm = new Loccstm
                                {
                                    crgoMvmt = m.sLocCustomCargoMovement,
                                    destPrt = m.sLocCustomDestPort,
                                    firstPrtOfEntry = m.sLocCustomFirstPortOfEntry,
                                    itemTyp = m.sLocCustomItemType,
                                    natrOfCrgo = m.sLocCustomNatureOfCargo,
                                    nmbrOfPkgs = Convert.ToInt32(m.dLocCustomNoOfPackages),
                                    nxtPrtOfUnlading = m.sLocCustomNextPortOfUnlanding,
                                    splitIndctr = m.sLocCustomSplitIndicator,
                                    typOfCrgo = m.sLocCustomTypeOfCargo,
                                    typOfPackage = m.sLocCustomTypeOfPackage
                                },
                                houseCargoDec = m.tblHouseCargoDescriptionMasterConsignmentMaps.Select(h => new Housecargodec
                                {
                                    HCRef = new Hcref
                                    {
                                        blDt = h.dtHCRefBillDate?.ToString("yyyyMMdd", CultureInfo.InvariantCulture),
                                        blNo = h.sHCRefBillNo,
                                        consolidatedIndctr = h.sHCRefConsolidatedIndicator,
                                        consolidatorPan = h.sHCRefConsolidatorPan,
                                        prevDec = h.sHCRefPreviousDescription,
                                        subLineNo = Convert.ToInt32(h.dHCRefSubLineNo)
                                    },
                                    locCstm = new Loccstm1
                                    {
                                        crgoMvmt = h.sLocCstmCargoMovement,
                                        destPrt = h.sLocCstmDestinationPort,
                                        firstPrtOfEntry = h.sLocCstmFirstPortOfEntry,
                                        itemTyp = h.sLocCstmItemType,
                                        natrOfCrgo = h.sLocCstmNatureOfCargo,
                                        nmbrOfPkgs = Convert.ToInt32(h.dLocCstmNoOfPackages),
                                        nxtPrtOfUnlading = h.sLocCstmNextPortOfUnlading,
                                        splitIndctr = h.sLocCstmSplitIndicator,
                                        typOfCrgo = h.sLocCstmTypeOfCargo,
                                        typOfPackage = h.sLocCstmTypeOfPakages,
                                    },
                                    itemDtls = h.tblItemDetailsHouseCargoMaps.Select(i => new Itemdtl1
                                    {
                                        crgoItemSeqNmbr = Convert.ToInt32(i.dCargoItemSequenceNo),
                                        hsCd = i.sHsCd,
                                        imdgCd = i.sIMDGCd,
                                        nmbrOfPkgs = Convert.ToInt32(i.dNoOfPakages),
                                        typOfPkgs = i.sTypesOfPackages,
                                        unoCd = i.sUnoCd,
                                        crgoItemDesc = i.sCargoItemDesc,
                                    }).ToList(),
                                    itnry = h.tblItineraryHouseCargoMaps.Select(ii => new Itnry1
                                    {
                                        modeOfTrnsprt = ii.sModeOfTransport,
                                        nxtPrtOfCallCdd = ii.sNextPortOfCallCdd,
                                        nxtPrtOfCallName = ii.sNextPortOfCallCdd,
                                        prtOfCallCdd = ii.sPortOfCallCd,
                                        prtOfCallName = ii.sPortOfCallName,
                                        prtOfCallSeqNmbr = Convert.ToInt32(ii.dPortOfCallSequenceNo)
                                    }).ToList(),
                                    trnsprtDoc = new Trnsprtdoc1
                                    {
                                        cnsgneCity = h.sTrnsprtrDocPartyConsigneeCity,
                                        cnsgneCntryCd = h.sTrnsprtrDocPartyConsigneeCountryCd,
                                        cnsgneCntrySubDiv = h.sTrnsprtrDocPartyConsigneeCountrySubDiv,
                                        cnsgneCntrySubDivName = h.sTrnsprtrDocPartyConsigneeCountrySubDivName,
                                        cnsgnePstcd = h.sTrnsprtrDocPartyConsigneePostCd,
                                        cnsgnesCd = h.sTrnsprtrDocPartyConsigneeCd,
                                        cnsgnesName = h.sTrnsprtrDocPartyConsigneeName,
                                        cnsgneStreetAddress = h.sTrnsprtrDocPartyConsigneeStreetAddress,
                                        cnsgnrCdTyp = h.sTrnsprtrDocPartyConsignorCdType,
                                        cnsgnrCity = h.sTrnsprtrDocPartyConsignorCity,
                                        cnsgnrCntryCd = h.sTrnsprtrDocPartyConsignorCountryCd,
                                        cnsgnrCntrySubDivCd = h.sTrnsprtrDocPartyConsignorCountrySubDivCd,
                                        cnsgnrCntrySubDivName = h.sTrnsprtrDocPartyConsignorCountrySubDivName,
                                        cnsgnrPstcd = h.sTrnsprtrDocPartyConsignorPostCd,
                                        cnsgnrsCd = h.sTrnsprtrDocPartyConsignorCd,
                                        cnsgnrsName = h.sTrnsprtrDocPartyConsignorName,
                                        cnsgnrStreetAddress = h.sTrnsprtrDocPartyConsignorStreetAddress,
                                        goodsDescAsPerBl = h.sTrnsprtrDocPartyGoodsDescAsPerBill,
                                        nameOfAnyOtherNotfdParty = h.sTrnsprtrDocPartyNameOfAnyOtherNotFdParty,
                                        notfdPartyCity = h.sTrnsprtrDocPartyNotFdPartyCity,
                                        notfdPartyCntryCd = h.sTrnsprtrDocPartyNotFdPartyCountryCd,
                                        notfdPartyCntrySubDiv = h.sTrnsprtrDocPartyNotFdPartyCountrySubDiv,
                                        notfdPartyCntrySubDivName = h.sTrnsprtrDocPartyNotFdPartyCountrySubDivName,
                                        notfdPartyPstcd = h.sTrnsprtrDocPartyNotFdPartyPostCd,
                                        notfdPartyStreetAddress = h.sTrnsprtrDocPartyNotFdPartyStreetAddress,
                                        panOfNotfdParty = h.sTrnsprtrDocPartyPANOfNotFdParty,
                                        prtOfAcptCdd = h.sTrnsprtrDocPartyPortOfAcceptedCCd,
                                        prtOfAcptName = h.sTrnsprtrDocPartyPortOfAcceptedName,
                                        prtOfReceiptCdd = h.sTrnsprtrDocPartyPortOfReceiptCcd,
                                        prtOfReceiptName = h.sTrnsprtrDocPartyPortOfReceiptName,
                                        typOfCd = h.sTrnsprtrDocPartyTypeOfCd,
                                        typOfNotfdPartyCd = h.sTrnsprtrDocPartyTypeOfNotFdPartyCd,
                                        ucrCd = h.sTrnsprtrDocPartyUCRCd,
                                        ucrTyp = h.sTrnsprtrDocPartyUCRType
                                    },
                                    trnsprtDocMsr = new Trnsprtdocmsr1
                                    {
                                        crncyCd = h.sTrnsprtrDocMsrCurrencyCd,
                                        grossWeight = Convert.ToInt32(h.dTrnsprtrDocMsrGrossWeight),
                                        invoiceValueOfCnsgmt = Convert.ToInt32(h.dTrnsprtrDocMsrInvoiceValueOfConsigment),
                                        marksNoOnPkgs = h.sTrnsprtrDocMsrMarksNoOnPackages,
                                        netWeight = Convert.ToInt32(h.dTrnsprtrDocMsrNetWeight),
                                        nmbrOfPkgs = Convert.ToInt32(h.dTrnsprtrDocMsrNoOfPackages),
                                        typsOfPkgs = h.sTrnsprtrDocMsrTypesOfPackages,
                                        unitOfWeight = h.sTrnsprtrDocMsrUnitOfWeight,
                                    },
                                    trnsprtEqmt = h.tblTransportEquipmentHouseCargoMaps.Select(e => new Trnsprteqmt1
                                    {
                                        adtnlEqmtHold = e.sAdditionalEquipmentHold,
                                        cntrAgntCd = e.sContainerAgentCd,
                                        cntrWeight = Convert.ToInt32(e.dContainerWeight),
                                        eqmtId = e.sEquipmentId,
                                        eqmtLoadStatus = e.sEquipmentLoadStatus,
                                        eqmtSealNmbr = e.sEquipmentSealNo,
                                        eqmtSealTyp = e.sEquipmentSealType,
                                        eqmtSeqNo = e.iEquipmentSequenceNo ?? 0,
                                        eqmtSize = e.sEquipmentSize,
                                        eqmtTyp = e.sEquipmentType,
                                        otherEqmtId = e.sOtherEquipmentId,
                                        socFlag = e.sSOCFlag,
                                        totalNmbrOfPkgs = Convert.ToInt32(e.dTotalNoOfPackages),
                                    }).ToList(),
                                }).ToList(),
                                itemDtls = m.tblItemDetailsMasterConsignmentMaps.Select(i => new Itemdtl
                                {
                                    crgoItemSeqNmbr = Convert.ToInt32(i.dCargoItemSequenceNo),
                                    hsCd = i.sHsCd,
                                    imdgCd = i.sIMDGCd,
                                    nmbrOfPkgs = Convert.ToInt32(i.dNoOfPakages),
                                    typOfPkgs = i.sTypesOfPackages,
                                    unoCd = i.sUnoCd,
                                    crgoItemDesc = i.sCargoItemDesc,
                                }).ToList(),
                                itnry = m.tblItineraryMasterConsignmentMaps.Select(ii => new Itnry
                                {
                                    modeOfTrnsprt = ii.sModeOfTransport,
                                    nxtPrtOfCallCdd = ii.sNextPortOfCallCdd,
                                    nxtPrtOfCallName = ii.sNextPortOfCallCdd,
                                    prtOfCallCdd = ii.sPortOfCallCd,
                                    prtOfCallName = ii.sPortOfCallName,
                                    prtOfCallSeqNmbr = Convert.ToInt32(ii.dPortOfCallSequenceNo)
                                }).ToList(),
                                MCRef = new Mcref
                                {
                                    consolidatedIndctr = m.sMCRefConsolidatedIndicator,
                                    consolidatorPan = m.sMCRefConsolidatorPan,
                                    lineNo = m.iMCRefLineNo ?? 0,
                                    mstrBlDt = m.dtMCRefMasterBillDate?.ToString("yyyyMMdd", CultureInfo.InvariantCulture),
                                    mstrBlNo = m.sMCRefMasterBillNo,
                                    prevDec = m.sMCRefPreviousDeclaration
                                },
                                trnsprtDoc = new Trnsprtdoc
                                {
                                    cnsgneCity = m.sTrnsprtrDocConsigneeCity,
                                    cnsgneCntryCd = m.sTrnsprtrDocConsigneeCountryCd,
                                    cnsgneCntrySubDiv = m.sTrnsprtrDocConsigneeCountrySubDiv,
                                    cnsgneCntrySubDivName = m.sTrnsprtrDocConsigneeCountrySubDivName,
                                    cnsgnePstcd = m.sTrnsprtrDocConsigneePostCd,
                                    cnsgnesName = m.sTrnsprtrDocConsigneeName,
                                    cnsgneStreetAddress = m.sTrnsprtrDocConsigneeStreetAddress,
                                    cnsgnrCntryCd = m.sTrnsprtrDocConsignorCountryCd,
                                    cnsgnrCity = m.sTrnsprtrDocConsignorCity,
                                    cnsgnrsName = m.sTrnsprtrDocConsignorName,
                                    cnsgnrStreetAddress = m.sTrnsprtrDocConsignorStreetAddress,
                                    goodsDescAsPerBl = m.sTrnsprtrDocGoodsDescAsPerBill,
                                    prtOfAcptCdd = m.sTrnsprtrDocPortOfAcceptedCCd,
                                    prtOfAcptName = m.sTrnsprtrDocPortOfAcceptedName,
                                    prtOfReceiptCdd = m.sTrnsprtrDocPortOfReceiptCcd,
                                    prtOfReceiptName = m.sTrnsprtrDocPortOfReceiptName,
                                    ucrCd = m.sTrnsprtrDocUCRCd,
                                    ucrTyp = m.sTrnsprtrDocUCRType,
                                    typOfNotfdPartyCd = m.sTrnsprtrDocTypeOfNotFdPartyCd,
                                    nameOfAnyOtherNotfdParty = m.sTrnsprtrDocNameOfAnyOtherNotFdParty,
                                    notfdPartyCity = m.sTrnsprtrDocNotFdPartyCity,
                                    notfdPartyCntryCd = m.sTrnsprtrDocNotFdPartyCountryCd,
                                    notfdPartyCntrySubDiv = m.sTrnsprtrDocNotFdPartyCountrySubDiv,
                                    notfdPartyCntrySubDivName = m.sTrnsprtrDocNotFdPartyCountrySubDivName,
                                    notfdPartyPstcd = m.sTrnsprtrDocNotFdPartyPostCd,
                                    notfdPartyStreetAddress = m.sTrnsprtrDocNotFdPartyStreetAddress,
                                    panOfNotfdParty = m.sTrnsprtrDocPANOfNotFdParty,
                                },
                                trnsprtDocMsr = new Trnsprtdocmsr
                                {
                                    crncyCd = m.sTrnsprtrDocMsrCurrencyCd,
                                    grossWeight = Convert.ToInt32(m.dTrnsprtrDocMsrGrossWeight),
                                    invoiceValueOfCnsgmt = Convert.ToInt32(m.dTrnsprtrDocMsrInvoiceValueOfConsigment),
                                    marksNoOnPkgs = m.sTrnsprtrDocMsrMarksNoOnPackages,
                                    netWeight = Convert.ToInt32(m.dTrnsprtrDocMsrNetWeight),
                                    nmbrOfPkgs = Convert.ToInt32(m.dTrnsprtrDocMsrNoOfPackages),
                                    typsOfPkgs = m.sTrnsprtrDocMsrTypesOfPackages,
                                    unitOfWeight = m.sTrnsprtrDocMsrUnitOfWeight,
                                },
                                trnsprtEqmt = m.tblTransportEquipmentMasterConsignmentMaps.Select(t => new Trnsprteqmt
                                {
                                    adtnlEqmtHold = t.sAdditionalEquipmentHold,
                                    cntrAgntCd = t.sContainerAgentCd,
                                    cntrWeight = Convert.ToInt32(t.dContainerWeight),
                                    eqmtId = t.sEquipmentId,
                                    eqmtLoadStatus = t.sEquipmentLoadStatus,
                                    eqmtSealNmbr = t.sEquipmentSealNo,
                                    eqmtSealTyp = t.sEquipmentSealType,
                                    eqmtSeqNo = t.iEquipmentSequenceNo ?? 0,
                                    eqmtSize = t.sEquipmentSize,
                                    eqmtTyp = t.sEquipmentType,
                                    otherEqmtId = t.sOtherEquipmentId,
                                    socFlag = t.sSOCFlag,
                                    totalNmbrOfPkgs = Convert.ToInt32(t.dTotalNoOfPackages),
                                }).ToList(),
                            }).ToList(),
                            prsnOnBoard = z.tblPersonOnBoardMessageImplementationMaps.Select(p => new Prsnonboard
                            {
                                prsnDtls = new Prsndtls
                                {
                                    crewmemberRankOrRatingCdd = p.sPersonDetailsCrewMemberRankOrRatingCdd,
                                    prsnCntryOfBirthCdd = p.sPersonDetailsPersonCountryOfBirthCdd,
                                    prsnDtOfBirth = p.dtPersonDetailsPersonDateOfBirth?.ToString("yyyyMMdd", CultureInfo.InvariantCulture),
                                    prsnGenderCdd = p.sPersonDetailsPersonGenderCdd,
                                    prsnGivenName = p.sPersonDetailsPersonGivenName,
                                    prsnNatnltyCdd = p.sPersonDetailsPersonNationalityCdd,
                                    prsnPlaceOfBirthName = p.sPersonDetailsPersonPlaceOfBirthName,
                                    prsnTypCdd = p.sPersonDetailsPersonTypeCdd,
                                    psngrInTransitIndctr = Convert.ToInt32(p.dPersonDetailsPassengersInTransitIndicator),
                                    prsnFamilyName = p.sPersonDetailsPersonFamilyName,
                                    psngrPrtOfDsmbrktnCdd = p.sPersonDetailsPassangerPartOfDsmbarkTnCdd,
                                    psngrPrtOfEmbrktnCdd = p.sPersonDetailsPassangerPartOfEmbarkTnCdd,
                                },
                                prsnId = new Prsnid
                                {
                                    prsnIdDocExpiryDt = p.dtPersonIdDocExpiryDate?.ToString("yyyyMMdd", CultureInfo.InvariantCulture),
                                    prsnIdOrTravelDocIssuingNationCdd = p.sPersonDetailsPersonNationalityCdd,
                                    prsnIdOrTravelDocNmbr = p.sPersonIdOrTravelDocNo,
                                    prsnIdOrTravelDocTypCdd = p.sPersonIdOrTravelDocTypeCdd,
                                },
                                prsnOnBoardSeqNmbr = Convert.ToInt32(p.dPersonOnBaordSeqNo),
                            }).ToList(),
                            voyageTransportEquipment = z.tblVoyageTransporterEquipmentMessageImplementationMaps.Select(v => new Voyagetransportequipment
                            {
                                additionalEquipmentHold = v.sAdditionalEquipmentHold,
                                containerAgentCode = v.sContainerAgentCode,
                                containerWeight = Convert.ToInt32(v.dContainerWeight),
                                equipmentId = v.sEquipmentId,
                                equipmentLoadStatus = v.sEquipmentLoadStatus,
                                equipmentSealNumber = v.sEquipmentSealNo,
                                equipmentSealType = v.sEquipmentSealType,
                                equipmentSequenceNo = v.iEquipmentSequenceNo ?? 0,
                                equipmentSize = v.sEquipmentSize,
                                equipmentType = v.sEquipmentType,
                                otherEquipmentId = v.sOtherEquipmentId,
                                socFlag = v.sSOCFlag,
                                totalNumberOfPackages = Convert.ToInt32(v.dTotalNoOfPackages),
                            }).ToList(),
                        },
                        digSign = new Digsign
                        {
                            signerVersion = z.sDigiSignSignerVersion,
                            startCertificate = z.sDigiSignStartCertificate,
                            startSignature = z.sDigiSignStartSignature
                        },
                    }).SingleOrDefault());
                }
                return Encoding.ASCII.GetBytes(Json);
            }
        }

        public MessageImplementationModel GetMessageByMessageImpementationId(int? iMessageImplementationId)
        {
            using (var db = new SeaManifestEntities())
            {
                return db.tblMessageImplementations.Where(z => z.iMessageImplementationId == iMessageImplementationId).ToList().Select(model => new MessageImplementationModel
                {
                    iMessageImplementationId = model.iMessageImplementationId,
                    dSequenceOrControlNumber = model.dHeaderFieldSequenceOrControlNumber,
                    sDateTime = model.dtHeaderFieldDateTime.ToDateTimeString(),
                    sIndicator = model.sHeaderFieldIndicator,
                    sMessageID = model.sHeaderFieldMessageId,
                    sReceiverID = model.sHeaderFieldReceiverId,
                    sReportingEvent = model.sHeaderFieldReportingEvent,
                    sSenderID = model.sHeaderFieldSenderId,
                    sVersionNo = model.sHeaderFieldVersionNo,
                    sDecRefMsgType = model.sDecRefMsgType,
                    sDecRefPortOfReporting = model.sDecRefPortOfReporting,
                    dDecRefjobNo = model.dDecRefjobNo,
                    sDecRefJobDt = model.dtDecRefJobDt.ToDateString(),
                    sDecRefReportingEvent = model.sDecRefReportingEvent,
                    dDecRefManifestNoRotnNo = model.dDecRefManifestNoRotnNo,
                    sDecRefManifestDateRotnDt = model.dtDecRefManifestDateRotnDt.ToDateString(),
                    sDecRefVesselTypeMovement = model.sDecRefVesselTypeMovement,
                    dDecRefDptrPreviousManifestNo = model.dDecRefDptrPreviousManifestNo,
                    sDecRefPreviousManifestDptrDate = model.dtDecRefPreviousManifestDptrDate.ToDateString(),
                    sAuthPrsnSubmitType = model.sAuthPrsnSubmitType,
                    sAuthPrsnSubmitCode = model.sAuthPrsnSubmitCode,
                    sAuthPrsnAuthRepresentativePAN = model.sAuthPrsnAuthRepresentativePAN,
                    sAuthPrsnShipLineCode = model.sAuthPrsnShipLineCode,
                    sAuthPrsnAuthSeaCarrierCode = model.sAuthPrsnAuthSeaCarrierCode,
                    sAuthPrsnMasterName = model.sAuthPrsnMasterName,
                    sAuthPrsnShippingLineBondNo = model.sAuthPrsnShippingLineBondNo,
                    sAuthPrsnTerminalCustodianCode = model.sAuthPrsnTerminalCustodianCode,
                    sVesselDtlsModeOfTransport = model.sVesselDtlsModeOfTransport,
                    sVesselDtlsTypeOfTransportMeans = model.sVesselDtlsTypeOfTransportMeans,
                    sVesselDtlsTransportMeansId = model.sVesselDtlsTransportMeansId,
                    dVesselDtlsGrossTonnage = model.dVesselDtlsGrossTonnage,
                    dVesselDtlsNetTonnage = model.dVesselDtlsNetTonnage,
                    sVesselDtlsNationalityOfShip = model.sVesselDtlsNationalityOfShip,
                    sVesselDtlsPortOfRegistry = model.sVesselDtlsPortOfRegistry,
                    sVesselDtlsVesselCode = model.sVesselDtlsVesselCode,
                    sVesselDtlsRegistryNo = model.sVesselDtlsRegistryNo,
                    sVesselDtlsRegistryDate = model.dtVesselDtlsRegistryDate.ToDateString(),
                    sVesselDtlsShipType = model.sVesselDtlsShipType,
                    sVesselDtlsPurposeOfCall = model.sVesselDtlsPurposeOfCall,
                    sVoyageDtlsVoyageNo = model.sVoyageDtlsVoyageNo,
                    sVoyageDtlsConveinceRefNo = model.sVoyageDtlsConveinceRefNo,
                    sVoyageDtlsTotalNumberofTrnsptEqtMnfstd = model.sVoyageDtlsTotalNumberofTrnsptEqtMnfstd,
                    sVoyageDtlsCargoDesCdd = model.sVoyageDtlsCargoDesCdd,
                    sVoyageDtlsBriefCargoDesc = model.sVoyageDtlsBriefCargoDesc,
                    dVoyageDtlsTotalNumberOfLines = model.dVoyageDtlsTotalNumberOfLines,
                    sVoyageDtlsExpectedDtandTimeOfArrival = model.dtVoyageDtlsExpectedDtandTimeOfArrival.ToDateTimeString(),
                    sVoyageDtlsExpectedDtandTimeOfDeparture = model.dtVoyageDtlsExpectedDtandTimeOfDeparture.ToDateTimeString(),
                    iVoyageDtlsNumberOfCrewManifested = model.iVoyageDtlsNumberOfCrewManifested ?? 0,
                    iArvlDtlsNumberOfPassengers = model.iArvlDtlsNumberOfPassengers,
                    iArvlDtlsNumberOfCrew = model.iArvlDtlsNumberOfCrew,
                    iArvlDtlsTotalNoOfCntrsLanded = model.iArvlDtlsTotalNoOfCntrsLanded,
                    iArvlDtlsTotalOfCntrsLoaded = model.iArvlDtlsTotalOfCntrsLoaded,
                    iArvlDtlsTotalNoOfPersonOnBoard = model.iArvlDtlsTotalNoOfPersonOnBoard,
                    iArvlDtlsTotalNoOfTrnsprtEqReprtdOnArrDptr = model.iArvlDtlsTotalNoOfTrnsprtEqReprtdOnArrDptr,
                    iArvlDtlsTotalNoOfTrnsprtCntrctReprtdOnArrDptr = model.iArvlDtlsTotalNoOfTrnsprtCntrctReprtdOnArrDptr1,
                    iArvlDtlsLightHouseDues = model.iArvlDtlsLightHouseDues,
                    sDigiSignSignerVersion = model.sDigiSignSignerVersion,
                    sDigiSignStartCertificate = model.sDigiSignStartCertificate,
                    sDigiSignStartSignature = model.sDigiSignStartSignature,
                }).SingleOrDefault();
            }
        }

        public string GetMessageTypeByImplementationId(int? iMessageImplementaionId)
        {
            using (var db = new SeaManifestEntities())
            {
                return db.tblMessageImplementations.Where(z => z.iMessageImplementationId == iMessageImplementaionId).Select(z => z.sDecRefReportingEvent).SingleOrDefault();
            }
        }
    }
}

