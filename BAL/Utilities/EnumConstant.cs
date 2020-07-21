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

        public enum MessageTypes
        {
            [Description("Fresh")]
            F,
            [Description("Ammendment")]
            A,
            [Description("Deletion")]
            D,
            [Description("Sub-manifest")]
            S
        }

        public enum VesselTypeMovement
        {
            [Description("Between India and Foreign Vice Versa")]
            FI,
            [Description("Between Indian Ports")]
            II,
            [Description("Between Indian Ports traversing SL & BL Territorial Waters")]
            RI,
        }

        public enum SubmitterType
        {
            [Description("ASA")]
            ASA,
            [Description("ATO")]
            ATO,
            [Description("ASC")]
            ASC,
            [Description("ANC")]
            ANC
        }

        public enum ModeOfTransport
        {
            Sea=1,
            Rail=2,
            Truck=3,
            Air=4
        }

        public enum TypeOfTransportMeans
        {
            [Description("IMO Vessel")]
            IMO=10,
            [Description("Non IMO Vessel")]
            NonIMO=11
        }
    }
}
