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
        public enum UnitOfWeight
        {
            KGS,
            MTS
        }

        public enum UnitOfVolume
        {
            LTR,
            USG
        }
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
            Sea = 1,
            Rail = 2,
            Truck = 3,
            Air = 4
        }

        public enum TypeOfTransportMeans
        {
            [Description("IMO Vessel")]
            IMO = 10,
            [Description("Non IMO Vessel")]
            NonIMO = 11
        }

        public enum ConsolidatedIndicator
        {
            [Description("Straight BL")]
            S,
            [Description("Consolidated BL")]
            C,
            [Description("House BL")]
            H
        }
        public enum PreviousDeclaration
        {
            N,
            C,
            Y
        }
        public enum EquipmentSealType
        {
            ESEAL, 
            BTSL

        }
        public enum EquipmentLoadStatus
        {
            FCL, 
            LCL,
            EMP
        }
        public enum EquipmentType
        {
            [Description("Break bulk")]
            BB,
            [Description("Blocks")]
            BL,
            [Description("Chassis")]
            CH,
            [Description("Container")]
            CN,
            [Description("Onboard Container")]
            OBE,
            [Description("Trailer")]
            TE
        }
        public enum PreviousMCRefCINType
        {
            MCIN,
            PCIN
        }

        public enum TypeOfCargo
        {
            IM,
            EX,
            CG,
            TR
        }

        public enum SplitIndicator
        {
            Y,
            N
        }

        public enum SOCFlag
        {
            Y,
            N
        }
        public enum CodeType
        {
            [Description("Importer exporter code")]
            IEC,
            [Description("PAN given by Income Tax Dept.")]
            PAN,
            [Description("GSTIN given for normal Taxpayers.")]
            GSN,
            [Description("GSTIN given for diplomats")]
            GSD,
            [Description("GSTIN given for Govt. Entities")]
            GSG,
        }
        public enum ItemType
        {
            [Description("Govt. Cargo")]
            GC,
            [Description("Unaccompanied Baggage")]
            UB,
            [Description("other Cargo")]
            OT
        }
        public enum CargoMovement
        {
            [Description("Local Clearance")]
            LC,
            [Description("Domestic Transshipment")]
            TI,
            [Description("Foreign Transshipment")]
            TC,
            [Description("Domestic Transit")]
            DT,
            [Description("Foreign Transit")]
            FT
        }

        public enum PersonType
        {
            [Description("Passenger")]
            FL,
            [Description("Crew")]
            FM,
            [Description("Stowaway")]
            DEE
        }

        public enum PersonGender
        {
            [Description("Not Known")]
            NK = 0,
            [Description("Male")]
            M = 1,
            [Description("Female")]
            F = 2,
            [Description("Not Applicable")]
            NA = 9,
        }

        public enum PersonInTransitIndicator
        {
            No = 0,
            Yes = 1
        }
    }
}
