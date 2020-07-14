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
                            || t.sHeaderFieldSenderId.Contains(search) ||t.sHeaderFieldReceiverId.Contains(search) || t.sHeaderFieldReportingEvent.Contains(search)
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
                return db.tblMessageImplementations.Where(z => z.iMessageImplementationId == iMessageImplementationId).ToList().Select(z=>new HeaderFieldModel
                {
                    iMessageImplementationId = z.iMessageImplementationId,
                    sDate= z.dtHeaderFieldDateTime?.ToString("dd/MM/yyyy",CultureInfo.InvariantCulture),
                    sTime = z.dtHeaderFieldDateTime?.ToString("hh:mm tt", CultureInfo.InvariantCulture),
                    sIndicator = z.sHeaderFieldIndicator,
                    sMessageID = z.sHeaderFieldMessageId,
                    sReceiverID = z.sHeaderFieldReceiverId,
                    sReportingEvent=z.sHeaderFieldReportingEvent,
                    sSenderID = z.sHeaderFieldSenderId,
                    sSequenceOrControlNumber = z.dHeaderFieldSequenceOrControlNumber?.ToString("#"),
                    sVersionNo= z.sHeaderFieldVersionNo,
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

    }
}

