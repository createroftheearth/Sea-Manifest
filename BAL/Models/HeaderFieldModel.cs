using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Models
{
    public class HeaderFieldModel
    {

        public int iMessageImplementationId { get; set; }
        public string sSenderID { get; set; }
        public string sReceiverID { get; set; }
        public string sVersionNo { get; set; }
        public string sIndicator { get; set; }
        public string sMessageID { get; set; }
        public int? iSequenceOrControlNumber { get; set; }
        public string sDate { get; set; }
        public string sTime { get; set; }
        public string sReportingEvent { get; set; }

    }
}
