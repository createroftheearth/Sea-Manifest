using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Utilities
{
    public class EnumConstant
    {
        public enum ReportingEvent
        {
            [Description("Sea Arrival Manifest Filing")]
            SAM,
            [Description("Sea Arrival Manifest Filing - Amendment")]
            SAA,
            [Description("Sea Departure Manifest")]
            SDM,
            [Description("Sea Entry Inward")]
            SEI,
            [Description("Sea Departure Manifest Amendment Filing")]
            SDA,
            [Description("Sea Departure Notification")]
            SDN
        }

    }
}
