using BAL.Models;
using BAL.Utilities;
using DAL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services
{
    public class HouseCargoService
    {
        private HouseCargoService()
        {
        }

        private static HouseCargoService _instance;

        public static HouseCargoService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new HouseCargoService();
                return _instance;
            }
        }
        public void Validate(int? iHouseCargoDescId)
        {
            using (var db = new SeaManifestEntities())
            {
                if (!db.tblHouseCargoDescriptionMasterConsignmentMaps.Any(z => z.iHouseCargoDescId == iHouseCargoDescId))
                    throw new Exception("Invalid House Cargo Desc Id");
            }
        }
        //save HouseCargo 
        public object SaveHouseCargo(HouseCargoModel model, int iUserId)
        {
            try
            {
                using (var db = new SeaManifestEntities())
                {
                    var data = db.tblHouseCargoDescriptionMasterConsignmentMaps.Where(z => z.iHouseCargoDescId == model.iHouseCargoDescId).SingleOrDefault();
                    if (data != null)
                    {
                        data.iMessageImplementationId = model.iMessageImplementationId;
                        data.iMasterConsignmentId = model.iMasterConsignmentId ?? 0;
                        data.dHCRefSubLineNo = model.dHCRefSubLineNo;
                        data.sHCRefBillNo = model.sHCRefBillNo;
                        data.dtHCRefBillDate = model.sHCRefBillDate.ToDate();
                        data.sHCRefConsolidatedIndicator = model.sHCRefConsolidatedIndicator;
                        data.sHCRefConsolidatorPan = model.sHCRefConsolidatorPan;
                        data.sHCRefPreviousDescription = model.sHCRefPreviousDescription;
                        data.sLocCstmFirstPortOfEntry = model.sLocCstmFirstPortOfEntry;
                        data.sLocCstmDestinationPort = model.sLocCstmDestinationPort;
                        data.sLocCstmNextPortOfUnlading = model.sLocCstmNextPortOfUnlading;
                        data.sLocCstmTypeOfCargo = model.sLocCstmTypeOfCargo;
                        data.sLocCstmItemType = model.sLocCstmItemType;
                        data.sLocCstmCargoMovement = model.sLocCstmCargoMovement;
                        data.sLocCstmNatureOfCargo = model.sLocCstmNatureOfCargo;
                        data.sLocCstmSplitIndicator = model.sLocCstmSplitIndicator;
                        data.dLocCstmNoOfPackages = model.dLocCstmNoOfPackages;
                        data.sLocCstmTypeOfPakages = model.sLocCstmTypeOfPakages;
                        data.sTrnshprTranshipperCd = model.sTrnshprTranshipperCd;
                        data.sTrnshprTranshipperBond = model.sTrnshprTranshipperBond;
                        data.sTrnsprtrDocPartyPortOfAcceptedCCd = model.sTrnsprtrDocPartyPortOfAcceptedCCd;
                        data.sTrnsprtrDocPartyPortOfAcceptedName = model.sTrnsprtrDocPartyPortOfAcceptedName;
                        data.sTrnsprtrDocPartyPortOfReceiptCcd = model.sTrnsprtrDocPartyPortOfReceiptCcd;
                        data.sTrnsprtrDocPartyPortOfReceiptName = model.sTrnsprtrDocPartyPortOfReceiptName;
                        data.sTrnsprtrDocPartyConsignorName = model.sTrnsprtrDocPartyConsignorName;
                        data.sTrnsprtrDocPartyConsignorCd = model.sTrnsprtrDocPartyConsignorCd;
                        data.sTrnsprtrDocPartyConsignorCdType = model.sTrnsprtrDocPartyConsignorCdType;
                        data.sTrnsprtrDocPartyConsignorStreetAddress = model.sTrnsprtrDocPartyConsignorStreetAddress;
                        data.sTrnsprtrDocPartyConsignorCity = model.sTrnsprtrDocPartyConsignorCity;
                        data.sTrnsprtrDocPartyConsignorCountrySubDivName = model.sTrnsprtrDocPartyConsignorCountrySubDivName;
                        data.sTrnsprtrDocPartyConsignorCountrySubDivCd = model.sTrnsprtrDocPartyConsignorCountrySubDivCd;
                        data.sTrnsprtrDocPartyConsignorCountryCd = model.sTrnsprtrDocPartyConsignorCountryCd;
                        data.sTrnsprtrDocPartyConsignorPostCd = model.sTrnsprtrDocPartyConsignorPostCd;
                        data.sTrnsprtrDocPartyConsigneeName = model.sTrnsprtrDocPartyConsigneeName;
                        data.sTrnsprtrDocPartyConsigneeCd = model.sTrnsprtrDocPartyConsigneeCd;
                        data.sTrnsprtrDocPartyTypeOfCd = model.sTrnsprtrDocPartyTypeOfCd;
                        data.sTrnsprtrDocPartyConsigneeStreetAddress = model.sTrnsprtrDocPartyConsigneeStreetAddress;
                        data.sTrnsprtrDocPartyConsigneeCity = model.sTrnsprtrDocPartyConsigneeCity;
                        data.sTrnsprtrDocPartyConsigneeCountrySubDivName = model.sTrnsprtrDocPartyConsigneeCountrySubDivName;
                        data.sTrnsprtrDocPartyConsigneeCountrySubDiv = model.sTrnsprtrDocPartyConsigneeCountrySubDiv;
                        data.sTrnsprtrDocPartyConsigneeCountryCd = model.sTrnsprtrDocPartyConsigneeCountryCd;
                        data.sTrnsprtrDocPartyConsigneePostCd = model.sTrnsprtrDocPartyConsigneePostCd;
                        data.sTrnsprtrDocPartyNameOfAnyOtherNotFdParty = model.sTrnsprtrDocPartyNameOfAnyOtherNotFdParty;
                        data.sTrnsprtrDocPartyPANOfNotFdParty = model.sTrnsprtrDocPartyPANOfNotFdParty;
                        data.sTrnsprtrDocPartyTypeOfNotFdPartyCd = model.sTrnsprtrDocPartyTypeOfNotFdPartyCd;
                        data.sTrnsprtrDocPartyNotFdPartyStreetAddress = model.sTrnsprtrDocPartyNotFdPartyStreetAddress;
                        data.sTrnsprtrDocPartyNotFdPartyCity = model.sTrnsprtrDocPartyNotFdPartyCity;
                        data.sTrnsprtrDocPartyNotFdPartyCountrySubDivName = model.sTrnsprtrDocPartyNotFdPartyCountrySubDivName;
                        data.sTrnsprtrDocPartyNotFdPartyCountrySubDiv = model.sTrnsprtrDocPartyNotFdPartyCountrySubDiv;
                        data.sTrnsprtrDocPartyNotFdPartyCountryCd = model.sTrnsprtrDocPartyNotFdPartyCountryCd;
                        data.sTrnsprtrDocPartyNotFdPartyPostCd = model.sTrnsprtrDocPartyNotFdPartyPostCd;
                        data.sTrnsprtrDocPartyGoodsDescAsPerBill = model.sTrnsprtrDocPartyGoodsDescAsPerBill;
                        data.sTrnsprtrDocPartyUCRType = model.sTrnsprtrDocPartyUCRType;
                        data.sTrnsprtrDocPartyUCRCd = model.sTrnsprtrDocPartyUCRCd;
                        data.dTrnsprtrDocMsrNoOfPackages = model.dTrnsprtrDocMsrNoOfPackages;
                        data.sTrnsprtrDocMsrTypesOfPackages = model.sTrnsprtrDocMsrTypesOfPackages;
                        data.sTrnsprtrDocMsrMarksNoOnPackages = model.sTrnsprtrDocMsrMarksNoOnPackages;
                        data.dTrnsprtrDocMsrGrossWeight = model.dTrnsprtrDocMsrGrossWeight;
                        data.dTrnsprtrDocMsrNetWeight = model.dTrnsprtrDocMsrNetWeight;
                        data.sTrnsprtrDocMsrUnitOfWeight = model.sTrnsprtrDocMsrUnitOfWeight;
                        data.dTrnsprtrDocMsrGrossVolume = model.dTrnsprtrDocMsrGrossVolume;
                        data.sTrnsprtrDocMsrUnitOfVolume = model.sTrnsprtrDocMsrUnitOfVolume;
                        data.dTrnsprtrDocMsrInvoiceValueOfConsigment = model.dTrnsprtrDocMsrInvoiceValueOfConsigment;
                        data.sTrnsprtrDocMsrCurrencyCd = model.sTrnsprtrDocMsrCurrencyCd;
                        data.iActionBy = iUserId;
                        data.dtActionDate = DateTime.Now;
                        db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        data = new tblHouseCargoDescriptionMasterConsignmentMap
                        {
                            iMessageImplementationId = model.iMessageImplementationId,
                            iMasterConsignmentId = model.iMasterConsignmentId ?? 0,
                            dHCRefSubLineNo = model.dHCRefSubLineNo,
                            sHCRefBillNo = model.sHCRefBillNo,
                            dtHCRefBillDate = model.sHCRefBillDate.ToDate(),
                            sHCRefConsolidatedIndicator = model.sHCRefConsolidatedIndicator,
                            sHCRefConsolidatorPan = model.sHCRefConsolidatorPan,
                            sHCRefPreviousDescription = model.sHCRefPreviousDescription,
                            sLocCstmFirstPortOfEntry = model.sLocCstmFirstPortOfEntry,
                            sLocCstmDestinationPort = model.sLocCstmDestinationPort,
                            sLocCstmNextPortOfUnlading = model.sLocCstmNextPortOfUnlading,
                            sLocCstmTypeOfCargo = model.sLocCstmTypeOfCargo,
                            sLocCstmItemType = model.sLocCstmItemType,
                            sLocCstmCargoMovement = model.sLocCstmCargoMovement,
                            sLocCstmNatureOfCargo = model.sLocCstmNatureOfCargo,
                            sLocCstmSplitIndicator = model.sLocCstmSplitIndicator,
                            dLocCstmNoOfPackages = model.dLocCstmNoOfPackages,
                            sLocCstmTypeOfPakages = model.sLocCstmTypeOfPakages,
                            sTrnshprTranshipperCd = model.sTrnshprTranshipperCd,
                            sTrnshprTranshipperBond = model.sTrnshprTranshipperBond,
                            sTrnsprtrDocPartyPortOfAcceptedCCd = model.sTrnsprtrDocPartyPortOfAcceptedCCd,
                            sTrnsprtrDocPartyPortOfAcceptedName = model.sTrnsprtrDocPartyPortOfAcceptedName,
                            sTrnsprtrDocPartyPortOfReceiptCcd = model.sTrnsprtrDocPartyPortOfReceiptCcd,
                            sTrnsprtrDocPartyPortOfReceiptName = model.sTrnsprtrDocPartyPortOfReceiptName,
                            sTrnsprtrDocPartyConsignorName = model.sTrnsprtrDocPartyConsignorName,
                            sTrnsprtrDocPartyConsignorCd = model.sTrnsprtrDocPartyConsignorCd,
                            sTrnsprtrDocPartyConsignorCdType = model.sTrnsprtrDocPartyConsignorCdType,
                            sTrnsprtrDocPartyConsignorStreetAddress = model.sTrnsprtrDocPartyConsignorStreetAddress,
                            sTrnsprtrDocPartyConsignorCity = model.sTrnsprtrDocPartyConsignorCity,
                            sTrnsprtrDocPartyConsignorCountrySubDivName = model.sTrnsprtrDocPartyConsignorCountrySubDivName,
                            sTrnsprtrDocPartyConsignorCountrySubDivCd = model.sTrnsprtrDocPartyConsignorCountrySubDivCd,
                            sTrnsprtrDocPartyConsignorCountryCd = model.sTrnsprtrDocPartyConsignorCountryCd,
                            sTrnsprtrDocPartyConsignorPostCd = model.sTrnsprtrDocPartyConsignorPostCd,
                            sTrnsprtrDocPartyConsigneeName = model.sTrnsprtrDocPartyConsigneeName,
                            sTrnsprtrDocPartyConsigneeCd = model.sTrnsprtrDocPartyConsigneeCd,
                            sTrnsprtrDocPartyTypeOfCd = model.sTrnsprtrDocPartyTypeOfCd,
                            sTrnsprtrDocPartyConsigneeStreetAddress = model.sTrnsprtrDocPartyConsigneeStreetAddress,
                            sTrnsprtrDocPartyConsigneeCity = model.sTrnsprtrDocPartyConsigneeCity,
                            sTrnsprtrDocPartyConsigneeCountrySubDivName = model.sTrnsprtrDocPartyConsigneeCountrySubDivName,
                            sTrnsprtrDocPartyConsigneeCountrySubDiv = model.sTrnsprtrDocPartyConsigneeCountrySubDiv,
                            sTrnsprtrDocPartyConsigneeCountryCd = model.sTrnsprtrDocPartyConsigneeCountryCd,
                            sTrnsprtrDocPartyConsigneePostCd = model.sTrnsprtrDocPartyConsigneePostCd,
                            sTrnsprtrDocPartyNameOfAnyOtherNotFdParty = model.sTrnsprtrDocPartyNameOfAnyOtherNotFdParty,
                            sTrnsprtrDocPartyPANOfNotFdParty = model.sTrnsprtrDocPartyPANOfNotFdParty,
                            sTrnsprtrDocPartyTypeOfNotFdPartyCd = model.sTrnsprtrDocPartyTypeOfNotFdPartyCd,
                            sTrnsprtrDocPartyNotFdPartyStreetAddress = model.sTrnsprtrDocPartyNotFdPartyStreetAddress,
                            sTrnsprtrDocPartyNotFdPartyCity = model.sTrnsprtrDocPartyNotFdPartyCity,
                            sTrnsprtrDocPartyNotFdPartyCountrySubDivName = model.sTrnsprtrDocPartyNotFdPartyCountrySubDivName,
                            sTrnsprtrDocPartyNotFdPartyCountrySubDiv = model.sTrnsprtrDocPartyNotFdPartyCountrySubDiv,
                            sTrnsprtrDocPartyNotFdPartyCountryCd = model.sTrnsprtrDocPartyNotFdPartyCountryCd,
                            sTrnsprtrDocPartyNotFdPartyPostCd = model.sTrnsprtrDocPartyNotFdPartyPostCd,
                            sTrnsprtrDocPartyGoodsDescAsPerBill = model.sTrnsprtrDocPartyGoodsDescAsPerBill,
                            sTrnsprtrDocPartyUCRType = model.sTrnsprtrDocPartyUCRType,
                            sTrnsprtrDocPartyUCRCd = model.sTrnsprtrDocPartyUCRCd,
                            dTrnsprtrDocMsrNoOfPackages = model.dTrnsprtrDocMsrNoOfPackages,
                            sTrnsprtrDocMsrTypesOfPackages = model.sTrnsprtrDocMsrTypesOfPackages,
                            sTrnsprtrDocMsrMarksNoOnPackages = model.sTrnsprtrDocMsrMarksNoOnPackages,
                            dTrnsprtrDocMsrGrossWeight = model.dTrnsprtrDocMsrGrossWeight,
                            dTrnsprtrDocMsrNetWeight = model.dTrnsprtrDocMsrNetWeight,
                            sTrnsprtrDocMsrUnitOfWeight = model.sTrnsprtrDocMsrUnitOfWeight,
                            dTrnsprtrDocMsrGrossVolume = model.dTrnsprtrDocMsrGrossVolume,
                            sTrnsprtrDocMsrUnitOfVolume = model.sTrnsprtrDocMsrUnitOfVolume,
                            dTrnsprtrDocMsrInvoiceValueOfConsigment = model.dTrnsprtrDocMsrInvoiceValueOfConsigment,
                            sTrnsprtrDocMsrCurrencyCd = model.sTrnsprtrDocMsrCurrencyCd,
                            iActionBy = iUserId,
                            dtActionDate = DateTime.Now,
                        };
                        db.tblHouseCargoDescriptionMasterConsignmentMaps.Add(data);
                        db.SaveChanges();
                    }
                    return new { Status = true, Message = "House Cargo saved successfully!" };
                }

            }
            catch (Exception)
            {
                return new { Status = false, Message = "Something went wrong" };
            }
        }

        public object GetHouseCargos(int iMasterConsignmentId, string search, int start, int length, out int recordsTotal)
        {
            using (var db = new SeaManifestEntities())
            {
                var query = from t in db.tblHouseCargoDescriptionMasterConsignmentMaps
                            where t.sHCRefBillNo.Contains(search) && t.iMasterConsignmentId == iMasterConsignmentId
                            select t;
                recordsTotal = query.Count();
                return query.OrderBy(z => z.dHCRefSubLineNo).Take(length).Skip(start).ToList().Select(t => new
                {
                    t.iHouseCargoDescId,
                    t.iMessageImplementationId,
                    t.iMasterConsignmentId,
                    t.dHCRefSubLineNo,
                    t.sHCRefBillNo,
                    sReportingEvent = t.tblMessageImplementation.sDecRefReportingEvent,
                    sHCRefBillDate = t.dtHCRefBillDate.ToDateString(),
                }).ToList();
            }
        }

        public HouseCargoModel GetHouseCargoHouseCargoDescId(int? iHouseCargoDescId)
        {
            using (var db = new SeaManifestEntities())
            {
                return db.tblHouseCargoDescriptionMasterConsignmentMaps.Where(z => z.iHouseCargoDescId == iHouseCargoDescId).ToList().Select(model => new HouseCargoModel
                {
                    iHouseCargoDescId = model.iHouseCargoDescId,
                    iMessageImplementationId = model.iMessageImplementationId,
                    iMasterConsignmentId = model.iMasterConsignmentId,
                    sReportingEvent = model.tblMessageImplementation.sDecRefReportingEvent,
                    dHCRefSubLineNo = model.dHCRefSubLineNo,
                    sHCRefBillNo = model.sHCRefBillNo,
                    sHCRefBillDate = model.dtHCRefBillDate?.ToString("dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture),
                    sHCRefConsolidatedIndicator = model.sHCRefConsolidatedIndicator,
                    sHCRefConsolidatorPan = model.sHCRefConsolidatorPan,
                    sHCRefPreviousDescription = model.sHCRefPreviousDescription,
                    sLocCstmFirstPortOfEntry = model.sLocCstmFirstPortOfEntry,
                    sLocCstmDestinationPort = model.sLocCstmDestinationPort,
                    sLocCstmNextPortOfUnlading = model.sLocCstmNextPortOfUnlading,
                    sLocCstmTypeOfCargo = model.sLocCstmTypeOfCargo,
                    sLocCstmItemType = model.sLocCstmItemType,
                    sLocCstmCargoMovement = model.sLocCstmCargoMovement,
                    sLocCstmNatureOfCargo = model.sLocCstmNatureOfCargo,
                    sLocCstmSplitIndicator = model.sLocCstmSplitIndicator,
                    dLocCstmNoOfPackages = model.dLocCstmNoOfPackages,
                    sLocCstmTypeOfPakages = model.sLocCstmTypeOfPakages,
                    sTrnshprTranshipperCd = model.sTrnshprTranshipperCd,
                    sTrnshprTranshipperBond = model.sTrnshprTranshipperBond,
                    sTrnsprtrDocPartyPortOfAcceptedCCd = model.sTrnsprtrDocPartyPortOfAcceptedCCd,
                    sTrnsprtrDocPartyPortOfAcceptedName = model.sTrnsprtrDocPartyPortOfAcceptedName,
                    sTrnsprtrDocPartyPortOfReceiptCcd = model.sTrnsprtrDocPartyPortOfReceiptCcd,
                    sTrnsprtrDocPartyPortOfReceiptName = model.sTrnsprtrDocPartyPortOfReceiptName,
                    sTrnsprtrDocPartyConsignorName = model.sTrnsprtrDocPartyConsignorName,
                    sTrnsprtrDocPartyConsignorCd = model.sTrnsprtrDocPartyConsignorCd,
                    sTrnsprtrDocPartyConsignorCdType = model.sTrnsprtrDocPartyConsignorCdType,
                    sTrnsprtrDocPartyConsignorStreetAddress = model.sTrnsprtrDocPartyConsignorStreetAddress,
                    sTrnsprtrDocPartyConsignorCity = model.sTrnsprtrDocPartyConsignorCity,
                    sTrnsprtrDocPartyConsignorCountrySubDivName = model.sTrnsprtrDocPartyConsignorCountrySubDivName,
                    sTrnsprtrDocPartyConsignorCountrySubDivCd = model.sTrnsprtrDocPartyConsignorCountrySubDivCd,
                    sTrnsprtrDocPartyConsignorCountryCd = model.sTrnsprtrDocPartyConsignorCountryCd,
                    sTrnsprtrDocPartyConsignorPostCd = model.sTrnsprtrDocPartyConsignorPostCd,
                    sTrnsprtrDocPartyConsigneeName = model.sTrnsprtrDocPartyConsigneeName,
                    sTrnsprtrDocPartyConsigneeCd = model.sTrnsprtrDocPartyConsigneeCd,
                    sTrnsprtrDocPartyTypeOfCd = model.sTrnsprtrDocPartyTypeOfCd,
                    sTrnsprtrDocPartyConsigneeStreetAddress = model.sTrnsprtrDocPartyConsigneeStreetAddress,
                    sTrnsprtrDocPartyConsigneeCity = model.sTrnsprtrDocPartyConsigneeCity,
                    sTrnsprtrDocPartyConsigneeCountrySubDivName = model.sTrnsprtrDocPartyConsigneeCountrySubDivName,
                    sTrnsprtrDocPartyConsigneeCountrySubDiv = model.sTrnsprtrDocPartyConsigneeCountrySubDiv,
                    sTrnsprtrDocPartyConsigneeCountryCd = model.sTrnsprtrDocPartyConsigneeCountryCd,
                    sTrnsprtrDocPartyConsigneePostCd = model.sTrnsprtrDocPartyConsigneePostCd,
                    sTrnsprtrDocPartyNameOfAnyOtherNotFdParty = model.sTrnsprtrDocPartyNameOfAnyOtherNotFdParty,
                    sTrnsprtrDocPartyPANOfNotFdParty = model.sTrnsprtrDocPartyPANOfNotFdParty,
                    sTrnsprtrDocPartyTypeOfNotFdPartyCd = model.sTrnsprtrDocPartyTypeOfNotFdPartyCd,
                    sTrnsprtrDocPartyNotFdPartyStreetAddress = model.sTrnsprtrDocPartyNotFdPartyStreetAddress,
                    sTrnsprtrDocPartyNotFdPartyCity = model.sTrnsprtrDocPartyNotFdPartyCity,
                    sTrnsprtrDocPartyNotFdPartyCountrySubDivName = model.sTrnsprtrDocPartyNotFdPartyCountrySubDivName,
                    sTrnsprtrDocPartyNotFdPartyCountrySubDiv = model.sTrnsprtrDocPartyNotFdPartyCountrySubDiv,
                    sTrnsprtrDocPartyNotFdPartyCountryCd = model.sTrnsprtrDocPartyNotFdPartyCountryCd,
                    sTrnsprtrDocPartyNotFdPartyPostCd = model.sTrnsprtrDocPartyNotFdPartyPostCd,
                    sTrnsprtrDocPartyGoodsDescAsPerBill = model.sTrnsprtrDocPartyGoodsDescAsPerBill,
                    sTrnsprtrDocPartyUCRType = model.sTrnsprtrDocPartyUCRType,
                    sTrnsprtrDocPartyUCRCd = model.sTrnsprtrDocPartyUCRCd,
                    dTrnsprtrDocMsrNoOfPackages = model.dTrnsprtrDocMsrNoOfPackages,
                    sTrnsprtrDocMsrTypesOfPackages = model.sTrnsprtrDocMsrTypesOfPackages,
                    sTrnsprtrDocMsrMarksNoOnPackages = model.sTrnsprtrDocMsrMarksNoOnPackages,
                    dTrnsprtrDocMsrGrossWeight = model.dTrnsprtrDocMsrGrossWeight,
                    dTrnsprtrDocMsrNetWeight = model.dTrnsprtrDocMsrNetWeight,
                    sTrnsprtrDocMsrUnitOfWeight = model.sTrnsprtrDocMsrUnitOfWeight,
                    dTrnsprtrDocMsrGrossVolume = model.dTrnsprtrDocMsrGrossVolume,
                    sTrnsprtrDocMsrUnitOfVolume = model.sTrnsprtrDocMsrUnitOfVolume,
                    dTrnsprtrDocMsrInvoiceValueOfConsigment = model.dTrnsprtrDocMsrInvoiceValueOfConsigment,
                    sTrnsprtrDocMsrCurrencyCd = model.sTrnsprtrDocMsrCurrencyCd
                }).SingleOrDefault();
            }
        }
        public string GetMessageTypeByHouseCargoDescId(int? HouseCargoDescId,out int iMasterConsignmentId)
        {
            using (var db = new SeaManifestEntities())
            {
                var query = db.tblHouseCargoDescriptionMasterConsignmentMaps.Where(z => z.iHouseCargoDescId == HouseCargoDescId);
                iMasterConsignmentId = query.Select(z => z.iMasterConsignmentId).SingleOrDefault();
                return query.Select(z => z.tblMessageImplementation.sDecRefReportingEvent).SingleOrDefault();
            }
        }

        public bool ValidateHouseCargo(HouseCargoModel model, out string Messages)
        {
            Messages = string.Empty;
            bool valid = true;
            using (var db = new SeaManifestEntities())
            {
                if (db.tblHouseCargoDescriptionMasterConsignmentMaps.Any(z => (model.sReportingEvent != "SEI" && model.sReportingEvent != "SDN") && z.iMessageImplementationId == model.iMessageImplementationId && z.dHCRefSubLineNo == model.dHCRefSubLineNo && z.iMasterConsignmentId == model.iMasterConsignmentId))
                {
                    valid = false; Messages = "Sub Line No already exists";
                }
            }
            return valid;
        }

    }
}
