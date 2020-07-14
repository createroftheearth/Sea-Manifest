using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    Date = t.dtHeaderFieldDateTime?.ToString("dd/MM/yyyy",CultureInfo.InvariantCulture),
                    Time = t.dtHeaderFieldDateTime?.ToString("hh:mm tt",CultureInfo.InvariantCulture),
                }).ToList();
            }
        }


    }
}
