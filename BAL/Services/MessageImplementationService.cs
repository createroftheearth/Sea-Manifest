using BAL.Models;
using BAL.Utilities;
using DAL;
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

        public object GetHeaders(string search, int start, int length, out int recordsTotal)
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
                    Date = t.dtHeaderFieldDateTime?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Time = t.dtHeaderFieldDateTime?.ToString("hh:mm tt", CultureInfo.InvariantCulture),
                    t.iMessageImplementationId
                }).ToList();
            }
        }

        public HeaderFieldModel GetHeaderByMessageImpementationId(int? iMessageImplementationId)
        {
            using (var db = new SeaManifestEntities())
            {
                return db.tblMessageImplementations.Where(z => z.iMessageImplementationId == iMessageImplementationId).ToList().Select(z => new HeaderFieldModel
                {
                    iMessageImplementationId = z.iMessageImplementationId,
                    sDate = z.dtHeaderFieldDateTime?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    sTime = z.dtHeaderFieldDateTime?.ToString("hh:mm tt", CultureInfo.InvariantCulture),
                    sIndicator = z.sHeaderFieldIndicator,
                    sMessageID = z.sHeaderFieldMessageId,
                    sReceiverID = z.sHeaderFieldReceiverId,
                    sReportingEvent = z.sHeaderFieldReportingEvent,
                    sSenderID = z.sHeaderFieldSenderId,
                    sSequenceOrControlNumber = z.dHeaderFieldSequenceOrControlNumber?.ToString("#"),
                    sVersionNo = z.sHeaderFieldVersionNo,
                }).SingleOrDefault();
            }
        }

        public object SaveHeader(HeaderFieldModel model, int iUserId)
        {
            try
            {
                using (var db = new SeaManifestEntities())
                {
                    var data = db.tblMessageImplementations.Where(z => z.iMessageImplementationId == model.iMessageImplementationId).SingleOrDefault();
                    decimal.TryParse(model.sSequenceOrControlNumber, out decimal SqOrCtrlNo);
                    DateTime dateTime = DateTime.ParseExact(model.sDate + " " + model.sTime, "dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture);
                    if (data == null)
                    {
                        data = new tblMessageImplementation
                        {
                            dHeaderFieldSequenceOrControlNumber = SqOrCtrlNo,
                            dtHeaderFieldDateTime = dateTime,
                            sHeaderFieldIndicator = model.sIndicator,
                            sHeaderFieldMessageId = model.sMessageID,
                            sHeaderFieldReceiverId = model.sReceiverID,
                            sHeaderFieldReportingEvent = model.sReportingEvent,
                            sHeaderFieldSenderId = model.sSenderID,
                            sHeaderFieldVersionNo = model.sVersionNo,
                            iActionBy = iUserId,
                            dtActionDate = DateTime.Now,
                        };
                        db.tblMessageImplementations.Add(data);
                        db.SaveChanges();
                    }
                    else
                    {
                        data.dHeaderFieldSequenceOrControlNumber = SqOrCtrlNo;
                        data.dtHeaderFieldDateTime = dateTime;
                        data.sHeaderFieldIndicator = model.sIndicator;
                        data.sHeaderFieldMessageId = model.sMessageID;
                        data.sHeaderFieldReceiverId = model.sReceiverID;
                        data.sHeaderFieldReportingEvent = model.sReportingEvent;
                        data.sHeaderFieldSenderId = model.sSenderID;
                        data.sHeaderFieldVersionNo = model.sVersionNo;
                        data.iActionBy = iUserId;
                        data.dtActionDate = DateTime.Now;
                        db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return new { Status = true, Message = "Header saved successfully!" };
                }

            }
            catch (Exception)
            {
                return new { Status = false, Message = "Something went wrong" };
            }
        }

        //authprsn
        public object SaveMasters(MessageImplementationModel model, int iUserId)
        {
            try
            {
                using (var db = new SeaManifestEntities())
                {
                    var data = db.tblMessageImplementations.Where(z => z.iMessageImplementationId == model.iMessageImplementationId).SingleOrDefault();
                    if (data == null)
                    {
                        return new { Status = false, Message = "Invalid Master" };
                    }
                    else
                    {
                        data.iMessageImplementationId = model.iMessageImplementationId;
                        data.sDecRefMsgType = model.sDecRefMsgType;
                        data.sDecRefPortOfReporting = model.sDecRefPortOfReporting;
                        data.dDecRefjobNo = model.dDecRefjobNo;
                        data.dtDecRefJobDt = DateTime.ParseExact(model.sDecRefJobDt, "dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture);
                        data.sDecRefReportingEvent = model.sDecRefReportingEvent;
                        data.dDecRefManifestNoRotnNo = model.dDecRefManifestNoRotnNo;
                        data.dtDecRefManifestDateRotnDt = DateTime.ParseExact(model.sDecRefManifestDateRotnDt, "dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture);
                        data.sDecRefVesselTypeMovement = model.sDecRefVesselTypeMovement;
                        data.dDecRefDptrPreviousManifestNo = model.dDecRefDptrPreviousManifestNo;
                        data.dtDecRefPreviousManifestDptrDate = DateTime.ParseExact(model.sDecRefPreviousManifestDptrDate, "dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture);
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
                        data.sVesselDtlsShipType = model.sVesselDtlsShipType;
                        data.sVesselDtlsPurposeOfCall = model.sVesselDtlsPurposeOfCall;
                        data.sVoyageDtlsVoyageNo = model.sVoyageDtlsVoyageNo;
                        data.sVoyageDtlsConveinceRefNo = model.sVoyageDtlsConveinceRefNo;
                        data.sVoyageDtlsTotalNumberofTrnsptEqtMnfstd = model.sVoyageDtlsTotalNumberofTrnsptEqtMnfstd;
                        data.sVoyageDtlsCargoDesCdd = model.sVoyageDtlsCargoDesCdd;
                        data.sVoyageDtlsBriefCargoDesc = model.sVoyageDtlsBriefCargoDesc;
                        data.dVoyageDtlsTotalNumberOfLines = Convert.ToDecimal(model.sVoyageDtlsTotalNumberOfLines);
                        data.dtVoyageDtlsExpectedDtandTimeOfArrival = DateTime.ParseExact(model.sVoyageDtlsExpectedDtandTimeOfArrival, "dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture);
                        data.dtVoyageDtlsExpectedDtandTimeOfDeparture = DateTime.ParseExact(model.sVoyageDtlsExpectedDtandTimeOfDeparture, "dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture);
                        data.iVoyageDtlsNumberOfPsngrManifested = model.iVoyageDtlsNumberOfPsngrManifested;
                        data.iVoyageDtlsNumberOfCrewManifested = model.iVoyageDtlsNumberOfCrewManifested;
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

        public MessageImplementationModel GetMasterByMessageImpementationId(int? iMessageImplementationId)
        {
            using (var db = new SeaManifestEntities())
            {
                return db.tblMessageImplementations.Where(z => z.iMessageImplementationId == iMessageImplementationId).ToList().Select(model => new MessageImplementationModel
                {
                    iMessageImplementationId = model.iMessageImplementationId,
                    sDecRefMsgType = model.sDecRefMsgType,
                    sDecRefPortOfReporting = model.sDecRefPortOfReporting,
                    dDecRefjobNo = model.dDecRefjobNo,
                    sDecRefJobDt = model.dtDecRefJobDt?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    sDecRefReportingEvent = model.sDecRefReportingEvent,
                    dDecRefManifestNoRotnNo = model.dDecRefManifestNoRotnNo,
                    sDecRefManifestDateRotnDt = model.dtDecRefManifestDateRotnDt?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    sDecRefVesselTypeMovement = model.sDecRefVesselTypeMovement,
                    dDecRefDptrPreviousManifestNo = model.dDecRefDptrPreviousManifestNo,
                    sDecRefPreviousManifestDptrDate = model.dtDecRefPreviousManifestDptrDate?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
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
                    sVesselDtlsShipType = model.sVesselDtlsShipType,
                    sVesselDtlsPurposeOfCall = model.sVesselDtlsPurposeOfCall,
                    sVoyageDtlsVoyageNo = model.sVoyageDtlsVoyageNo,
                    sVoyageDtlsConveinceRefNo = model.sVoyageDtlsConveinceRefNo,
                    sVoyageDtlsTotalNumberofTrnsptEqtMnfstd = model.sVoyageDtlsTotalNumberofTrnsptEqtMnfstd,
                    sVoyageDtlsCargoDesCdd = model.sVoyageDtlsCargoDesCdd,
                    sVoyageDtlsBriefCargoDesc = model.sVoyageDtlsBriefCargoDesc,
                    sVoyageDtlsTotalNumberOfLines = model.dVoyageDtlsTotalNumberOfLines?.ToString("#"),
                    sVoyageDtlsExpectedDtandTimeOfArrival = model.dtVoyageDtlsExpectedDtandTimeOfArrival?.ToString("dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture),
                    sVoyageDtlsExpectedDtandTimeOfDeparture = model.dtVoyageDtlsExpectedDtandTimeOfDeparture?.ToString("dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture),
                    iVoyageDtlsNumberOfPsngrManifested = model.iVoyageDtlsNumberOfPsngrManifested ?? 0,
                    iVoyageDtlsNumberOfCrewManifested = model.iVoyageDtlsNumberOfCrewManifested ?? 0,

                }).SingleOrDefault();
            }
        }
    }
}

