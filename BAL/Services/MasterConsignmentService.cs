using BAL.Models;
using BAL.Utilities;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BAL.Services
{
    public class MasterConsignmentService
    {
        private MasterConsignmentService()
        {
        }

        private static MasterConsignmentService _instance;

        public static MasterConsignmentService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MasterConsignmentService();
                return _instance;
            }
        }

        public List<SelectListItem> GetPorts()
        {
            using (var db = new SeaManifestEntities())
            {
                return db.tblPortMs.ToList().Select(z => new SelectListItem
                {
                    Value = z.sPortCode.ToString(),
                    Text = z.sPortDescription
                }).ToList();
            }
        }
        public void Validate(int? iMasterConsignmentId)
        {
            using (var db = new SeaManifestEntities())
            {
                if (!db.tblMasterConsignmentMessageImplementationMaps.Any(z => z.iMasterConsignmentId == iMasterConsignmentId))
                    throw new Exception("Invalid Master Consignment Id");
            }
        }

        public List<SelectListItem> GetCodesByType(string Type)
        {
            using (var db = new SeaManifestEntities())
            {
                return db.tblCodeMs.Where(z => z.tblCodeTypeM.sCodeType == Type).ToList().Select(z => new SelectListItem
                {
                    Value = z.sCode.ToString(),
                    Text = z.sCodeName
                }).ToList();
            }
        }

        //save master Consigment 
        public object SaveMasterConsigment(MasterConsignmentModel model, int iUserId)
        {
            try
            {
                using (var db = new SeaManifestEntities())
                {
                    var data = db.tblMasterConsignmentMessageImplementationMaps.Where(z => z.iMasterConsignmentId == model.iMasterConsignmentId).SingleOrDefault();
                    if (data != null)
                    {
                        data.iMessageImplementationId = model.iMessageImplementationId;
                        data.iMCRefLineNo = model.iMCRefLineNo;
                        data.sMCRefMasterBillNo = model.sMCRefMasterBillNo;
                        data.dtMCRefMasterBillDate = model.sMCRefMasterBillDate.ToDate();
                        data.sMCRefConsolidatedIndicator = model.sMCRefConsolidatedIndicator;
                        data.sMCRefPreviousDeclaration = model.sMCRefPreviousDeclaration;
                        data.sMCRefConsolidatorPan = model.sMCRefConsolidatorPan;
                        data.sPrevRefCinType = model.sPrevRefCinType;
                        data.sPrevRefMcinPcin = model.sPrevRefMcinPcin;
                        data.sPrevRefCSNSubmtdType = model.sPrevRefCSNSubmtdType;
                        data.sPrevRefCSNSubmtdBy = model.sPrevRefCSNSubmtdBy;
                        data.sPrevRefCSNReportingType = model.sPrevRefCSNReportingType;
                        data.sPrevRefCSNSiteId = model.sPrevRefCSNSiteId;
                        data.iPrevRefCSNNo = model.iPrevRefCSNNo;
                        data.dtPrevRefCSNDate = model.sPrevRefCSNDate.ToDate();
                        data.sPrevRefSplitIndicator = model.sPrevRefSplitIndicator;
                        data.dPrevRefNoOfPackages = model.dPrevRefNoOfPackages;
                        data.sPrevRefTypeOfPackage = model.sPrevRefTypeOfPackage;
                        data.sLocCustomFirstPortOfEntry = model.sLocCustomFirstPortOfEntry;
                        data.sLocCustomDestPort = model.sLocCustomDestPort;
                        data.sLocCustomNextPortOfUnlanding = model.sLocCustomNextPortOfUnlanding;
                        data.sLocCustomTypeOfCargo = model.sLocCustomTypeOfCargo;
                        data.sLocCustomItemType = model.sLocCustomItemType;
                        data.sLocCustomCargoMovement = model.sLocCustomCargoMovement;
                        data.sLocCustomNatureOfCargo = model.sLocCustomNatureOfCargo;
                        data.sLocCustomSplitIndicator = model.sLocCustomSplitIndicator;
                        data.dLocCustomNoOfPackages = model.dLocCustomNoOfPackages;
                        data.sLocCustomTypeOfPackage = model.sLocCustomTypeOfPackage;
                        data.sTrnshprCd = model.sTrnshprCd;
                        data.sTrnshprBond = model.sTrnshprBond;
                        data.sTrnsprtrDocPortOfAcceptedCCd = model.sTrnsprtrDocPortOfAcceptedCCd;
                        data.sTrnsprtrDocPortOfAcceptedName = model.sTrnsprtrDocPortOfAcceptedName;
                        data.sTrnsprtrDocPortOfReceiptCcd = model.sTrnsprtrDocPortOfReceiptCcd;
                        data.sTrnsprtrDocPortOfReceiptName = model.sTrnsprtrDocPortOfReceiptName;
                        data.sTrnsprtrDocConsignorName = model.sTrnsprtrDocConsignorName;
                        data.sTrnsprtrDocConsignorCd = model.sTrnsprtrDocConsignorCd;
                        data.sTrnsprtrDocConsignorCdType = model.sTrnsprtrDocConsignorCdType;
                        data.sTrnsprtrDocConsignorStreetAddress = model.sTrnsprtrDocConsignorStreetAddress;
                        data.sTrnsprtrDocConsignorCity = model.sTrnsprtrDocConsignorCity;
                        data.sTrnsprtrDocConsignorCountrySubDivName = model.sTrnsprtrDocConsignorCountrySubDivName;
                        data.sTrnsprtrDocConsignorCountrySubDivCd = model.sTrnsprtrDocConsignorCountrySubDivCd;
                        data.sTrnsprtrDocConsignorCountryCd = model.sTrnsprtrDocConsignorCountryCd;
                        data.sTrnsprtrDocConsignorPostCd = model.sTrnsprtrDocConsignorPostCd;
                        data.sTrnsprtrDocConsigneeName = model.sTrnsprtrDocConsigneeName;
                        data.sTrnsprtrDocConsigneeCd = model.sTrnsprtrDocConsigneeCd;
                        data.sTrnsprtrDocTypeOfCd = model.sTrnsprtrDocTypeOfCd;
                        data.sTrnsprtrDocConsigneeStreetAddress = model.sTrnsprtrDocConsigneeStreetAddress;
                        data.sTrnsprtrDocConsigneeCity = model.sTrnsprtrDocConsigneeCity;
                        data.sTrnsprtrDocConsigneeCountrySubDivName = model.sTrnsprtrDocConsigneeCountrySubDivName;
                        data.sTrnsprtrDocConsigneeCountrySubDiv = model.sTrnsprtrDocConsigneeCountrySubDiv;
                        data.sTrnsprtrDocConsigneeCountryCd = model.sTrnsprtrDocConsigneeCountryCd;
                        data.sTrnsprtrDocConsigneePostCd = model.sTrnsprtrDocConsigneePostCd;
                        data.sTrnsprtrDocNameOfAnyOtherNotFdParty = model.sTrnsprtrDocNameOfAnyOtherNotFdParty;
                        data.sTrnsprtrDocPANOfNotFdParty = model.sTrnsprtrDocPANOfNotFdParty;
                        data.sTrnsprtrDocTypeOfNotFdPartyCd = model.sTrnsprtrDocTypeOfNotFdPartyCd;
                        data.sTrnsprtrDocNotFdPartyStreetAddress = model.sTrnsprtrDocNotFdPartyStreetAddress;
                        data.sTrnsprtrDocNotFdPartyCity = model.sTrnsprtrDocNotFdPartyCity;
                        data.sTrnsprtrDocNotFdPartyCountrySubDivName = model.sTrnsprtrDocNotFdPartyCountrySubDivName;
                        data.sTrnsprtrDocNotFdPartyCountrySubDiv = model.sTrnsprtrDocNotFdPartyCountrySubDiv;
                        data.sTrnsprtrDocNotFdPartyCountryCd = model.sTrnsprtrDocNotFdPartyCountryCd;
                        data.sTrnsprtrDocNotFdPartyPostCd = model.sTrnsprtrDocNotFdPartyPostCd;
                        data.sTrnsprtrDocGoodsDescAsPerBill = model.sTrnsprtrDocGoodsDescAsPerBill;
                        data.sTrnsprtrDocUCRType = model.sTrnsprtrDocUCRType;
                        data.sTrnsprtrDocUCRCd = model.sTrnsprtrDocUCRCd;
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
                        data.sSuplmntryDecCinType = model.sSuplmntryDecCinType;
                        data.sSuplmntryDecMCinPCin = model.sSuplmntryDecMCinPCin;
                        data.sSuplmntryDecCSNSubmtdType = model.sSuplmntryDecCSNSubmtdType;
                        data.sSuplmntryDecCSNSubmtdBy = model.sSuplmntryDecCSNSubmtdBy;
                        data.sSuplmntryDecCSNReportingType = model.sSuplmntryDecCSNReportingType;
                        data.sSuplmntryDecCSNSiteId = model.sSuplmntryDecCSNSiteId;
                        data.dSuplmntryDecCSNNo = model.dSuplmntryDecCSNNo;
                        data.dtSuplmntryDecCSNDate = model.sSuplmntryDecCSNDate.ToDateTime();
                        data.sSuplmntryDecPrevMCIN = model.sSuplmntryDecPrevMCIN;
                        data.sSuplmntryDecSplitIndicator = model.sSuplmntryDecSplitIndicator;
                        data.dSuplmntryDecNoOfPackages = model.dSuplmntryDecNoOfPackages;
                        data.sSuplmntryDecTypeOfPackages = model.sSuplmntryDecTypeOfPackages;
                        data.iActionBy = iUserId;
                        data.dtActionDate = DateTime.Now;
                        db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        data = new tblMasterConsignmentMessageImplementationMap
                        {
                            iMessageImplementationId = model.iMessageImplementationId,
                            iMCRefLineNo = model.iMCRefLineNo,
                            sMCRefMasterBillNo = model.sMCRefMasterBillNo,
                            dtMCRefMasterBillDate = model.sMCRefMasterBillDate.ToDate(),
                            sMCRefConsolidatedIndicator = model.sMCRefConsolidatedIndicator,
                            sMCRefPreviousDeclaration = model.sMCRefPreviousDeclaration,
                            sMCRefConsolidatorPan = model.sMCRefConsolidatorPan,
                            sPrevRefCinType = model.sPrevRefCinType,
                            sPrevRefMcinPcin = model.sPrevRefMcinPcin,
                            sPrevRefCSNSubmtdType = model.sPrevRefCSNSubmtdType,
                            sPrevRefCSNSubmtdBy = model.sPrevRefCSNSubmtdBy,
                            sPrevRefCSNReportingType = model.sPrevRefCSNReportingType,
                            sPrevRefCSNSiteId = model.sPrevRefCSNSiteId,
                            iPrevRefCSNNo = model.iPrevRefCSNNo,
                            dtPrevRefCSNDate = model.sPrevRefCSNDate.ToDate(),
                            sPrevRefSplitIndicator = model.sPrevRefSplitIndicator,
                            dPrevRefNoOfPackages = model.dPrevRefNoOfPackages,
                            sPrevRefTypeOfPackage = model.sPrevRefTypeOfPackage,
                            sLocCustomFirstPortOfEntry = model.sLocCustomFirstPortOfEntry,
                            sLocCustomDestPort = model.sLocCustomDestPort,
                            sLocCustomNextPortOfUnlanding = model.sLocCustomNextPortOfUnlanding,
                            sLocCustomTypeOfCargo = model.sLocCustomTypeOfCargo,
                            sLocCustomItemType = model.sLocCustomItemType,
                            sLocCustomCargoMovement = model.sLocCustomCargoMovement,
                            sLocCustomNatureOfCargo = model.sLocCustomNatureOfCargo,
                            sLocCustomSplitIndicator = model.sLocCustomSplitIndicator,
                            dLocCustomNoOfPackages = model.dLocCustomNoOfPackages,
                            sLocCustomTypeOfPackage = model.sLocCustomTypeOfPackage,
                            sTrnshprCd = model.sTrnshprCd,
                            sTrnshprBond = model.sTrnshprBond,
                            sTrnsprtrDocPortOfAcceptedCCd = model.sTrnsprtrDocPortOfAcceptedCCd,
                            sTrnsprtrDocPortOfAcceptedName = model.sTrnsprtrDocPortOfAcceptedName,
                            sTrnsprtrDocPortOfReceiptCcd = model.sTrnsprtrDocPortOfReceiptCcd,
                            sTrnsprtrDocPortOfReceiptName = model.sTrnsprtrDocPortOfReceiptName,
                            sTrnsprtrDocConsignorName = model.sTrnsprtrDocConsignorName,
                            sTrnsprtrDocConsignorCd = model.sTrnsprtrDocConsignorCd,
                            sTrnsprtrDocConsignorCdType = model.sTrnsprtrDocConsignorCdType,
                            sTrnsprtrDocConsignorStreetAddress = model.sTrnsprtrDocConsignorStreetAddress,
                            sTrnsprtrDocConsignorCity = model.sTrnsprtrDocConsignorCity,
                            sTrnsprtrDocConsignorCountrySubDivName = model.sTrnsprtrDocConsignorCountrySubDivName,
                            sTrnsprtrDocConsignorCountrySubDivCd = model.sTrnsprtrDocConsignorCountrySubDivCd,
                            sTrnsprtrDocConsignorCountryCd = model.sTrnsprtrDocConsignorCountryCd,
                            sTrnsprtrDocConsignorPostCd = model.sTrnsprtrDocConsignorPostCd,
                            sTrnsprtrDocConsigneeName = model.sTrnsprtrDocConsigneeName,
                            sTrnsprtrDocConsigneeCd = model.sTrnsprtrDocConsigneeCd,
                            sTrnsprtrDocTypeOfCd = model.sTrnsprtrDocTypeOfCd,
                            sTrnsprtrDocConsigneeStreetAddress = model.sTrnsprtrDocConsigneeStreetAddress,
                            sTrnsprtrDocConsigneeCity = model.sTrnsprtrDocConsigneeCity,
                            sTrnsprtrDocConsigneeCountrySubDivName = model.sTrnsprtrDocConsigneeCountrySubDivName,
                            sTrnsprtrDocConsigneeCountrySubDiv = model.sTrnsprtrDocConsigneeCountrySubDiv,
                            sTrnsprtrDocConsigneeCountryCd = model.sTrnsprtrDocConsigneeCountryCd,
                            sTrnsprtrDocConsigneePostCd = model.sTrnsprtrDocConsigneePostCd,
                            sTrnsprtrDocNameOfAnyOtherNotFdParty = model.sTrnsprtrDocNameOfAnyOtherNotFdParty,
                            sTrnsprtrDocPANOfNotFdParty = model.sTrnsprtrDocPANOfNotFdParty,
                            sTrnsprtrDocTypeOfNotFdPartyCd = model.sTrnsprtrDocTypeOfNotFdPartyCd,
                            sTrnsprtrDocNotFdPartyStreetAddress = model.sTrnsprtrDocNotFdPartyStreetAddress,
                            sTrnsprtrDocNotFdPartyCity = model.sTrnsprtrDocNotFdPartyCity,
                            sTrnsprtrDocNotFdPartyCountrySubDivName = model.sTrnsprtrDocNotFdPartyCountrySubDivName,
                            sTrnsprtrDocNotFdPartyCountrySubDiv = model.sTrnsprtrDocNotFdPartyCountrySubDiv,
                            sTrnsprtrDocNotFdPartyCountryCd = model.sTrnsprtrDocNotFdPartyCountryCd,
                            sTrnsprtrDocNotFdPartyPostCd = model.sTrnsprtrDocNotFdPartyPostCd,
                            sTrnsprtrDocGoodsDescAsPerBill = model.sTrnsprtrDocGoodsDescAsPerBill,
                            sTrnsprtrDocUCRType = model.sTrnsprtrDocUCRType,
                            sTrnsprtrDocUCRCd = model.sTrnsprtrDocUCRCd,
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
                            sSuplmntryDecCinType = model.sSuplmntryDecCinType,
                            sSuplmntryDecMCinPCin = model.sSuplmntryDecMCinPCin,
                            sSuplmntryDecCSNSubmtdType = model.sSuplmntryDecCSNSubmtdType,
                            sSuplmntryDecCSNSubmtdBy = model.sSuplmntryDecCSNSubmtdBy,
                            sSuplmntryDecCSNReportingType = model.sSuplmntryDecCSNReportingType,
                            sSuplmntryDecCSNSiteId = model.sSuplmntryDecCSNSiteId,
                            dSuplmntryDecCSNNo = model.dSuplmntryDecCSNNo,
                            dtSuplmntryDecCSNDate = model.sSuplmntryDecCSNDate.ToDateTime(),
                            sSuplmntryDecPrevMCIN = model.sSuplmntryDecPrevMCIN,
                            sSuplmntryDecSplitIndicator = model.sSuplmntryDecSplitIndicator,
                            dSuplmntryDecNoOfPackages = model.dSuplmntryDecNoOfPackages,
                            sSuplmntryDecTypeOfPackages = model.sSuplmntryDecTypeOfPackages,
                            iActionBy = iUserId,
                            dtActionDate = DateTime.Now,
                        };
                        db.tblMasterConsignmentMessageImplementationMaps.Add(data);
                        db.SaveChanges();
                    }
                    return new { Status = true, Message = "Master Consigment saved successfully!" };
                }

            }
            catch (Exception)
            {
                return new { Status = false, Message = "Something went wrong" };
            }
        }

        public bool ValidateLineMasterConsignment(MasterConsignmentModel model, out string Messages)
        {
            Messages = string.Empty;
            bool valid = true;
            using (var db = new SeaManifestEntities())
            {
                var billDate = model.sMCRefMasterBillDate.ToDate();
                if (db.tblMasterConsignmentMessageImplementationMaps.Any(z => z.iMessageImplementationId == model.iMessageImplementationId && z.iMCRefLineNo == model.iMCRefLineNo && z.iMasterConsignmentId != model.iMasterConsignmentId))
                {
                    valid = false; Messages = "Line No already exists";
                }
                if (db.tblMasterConsignmentMessageImplementationMaps.Any(z => (model.sReportingEvent == "SAA" || model.sReportingEvent == "SDA") && z.iMessageImplementationId == model.iMessageImplementationId && z.sMCRefMasterBillNo == model.sMCRefMasterBillNo && z.iMasterConsignmentId != model.iMasterConsignmentId))
                {
                    valid = false; Messages+= ", Master Bill No already exists";
                }
                if (db.tblMasterConsignmentMessageImplementationMaps.Any(z => (model.sReportingEvent == "SAA" || model.sReportingEvent == "SDA") && z.iMessageImplementationId == model.iMessageImplementationId && z.dtMCRefMasterBillDate == billDate && z.iMasterConsignmentId != model.iMasterConsignmentId))
                {
                    valid = false; Messages += ",Master Bill Date already exists";
                }
            }
            return valid;
        }

        public object GetConsignments(int iMessageImplementationId, string search, int start, int length, out int recordsTotal)
        {
            using (var db = new SeaManifestEntities())
            {
                var query = from t in db.tblMasterConsignmentMessageImplementationMaps
                            where t.sMCRefMasterBillNo.Contains(search) && t.iMessageImplementationId == iMessageImplementationId
                            select t;
                recordsTotal = query.Count();
                return query.OrderBy(z => z.iMCRefLineNo).Skip(start).Take(length).ToList().Select(t => new
                {
                    t.iMessageImplementationId,
                    t.iMasterConsignmentId,
                    t.iMCRefLineNo,
                    t.sMCRefMasterBillNo,
                    sReportingEvent = t.tblMessageImplementation.sDecRefReportingEvent,
                    masterBillDate = t.dtMCRefMasterBillDate.ToDateString(),
                }).ToList();
            }
        }

        public MasterConsignmentModel GetMasterConsigmentByMasterConsignmentId(int? iMasterConsignmentId)
        {
            using (var db = new SeaManifestEntities())
            {
                return db.tblMasterConsignmentMessageImplementationMaps.Where(z => z.iMasterConsignmentId == iMasterConsignmentId).ToList().Select(model => new MasterConsignmentModel
                {
                    iMasterConsignmentId = model.iMasterConsignmentId,
                    iMessageImplementationId = model.iMessageImplementationId,
                    iMCRefLineNo = model.iMCRefLineNo,
                    sMCRefMasterBillNo = model.sMCRefMasterBillNo,
                    sMCRefMasterBillDate = model.dtMCRefMasterBillDate.ToDateString(),
                    sMCRefConsolidatedIndicator = model.sMCRefConsolidatedIndicator,
                    sMCRefPreviousDeclaration = model.sMCRefPreviousDeclaration,
                    sMCRefConsolidatorPan = model.sMCRefConsolidatorPan,
                    sPrevRefCinType = model.sPrevRefCinType,
                    sPrevRefMcinPcin = model.sPrevRefMcinPcin,
                    sPrevRefCSNSubmtdType = model.sPrevRefCSNSubmtdType,
                    sPrevRefCSNSubmtdBy = model.sPrevRefCSNSubmtdBy,
                    sPrevRefCSNReportingType = model.sPrevRefCSNReportingType,
                    sPrevRefCSNSiteId = model.sPrevRefCSNSiteId,
                    iPrevRefCSNNo = model.iPrevRefCSNNo,
                    sPrevRefCSNDate = model.dtPrevRefCSNDate.ToDateString(),
                    sPrevRefSplitIndicator = model.sPrevRefSplitIndicator,
                    dPrevRefNoOfPackages = model.dPrevRefNoOfPackages,
                    sPrevRefTypeOfPackage = model.sPrevRefTypeOfPackage,
                    sLocCustomFirstPortOfEntry = model.sLocCustomFirstPortOfEntry,
                    sLocCustomDestPort = model.sLocCustomDestPort,
                    sLocCustomNextPortOfUnlanding = model.sLocCustomNextPortOfUnlanding,
                    sLocCustomTypeOfCargo = model.sLocCustomTypeOfCargo,
                    sLocCustomItemType = model.sLocCustomItemType,
                    sLocCustomCargoMovement = model.sLocCustomCargoMovement,
                    sLocCustomNatureOfCargo = model.sLocCustomNatureOfCargo,
                    sLocCustomSplitIndicator = model.sLocCustomSplitIndicator,
                    dLocCustomNoOfPackages = model.dLocCustomNoOfPackages,
                    sLocCustomTypeOfPackage = model.sLocCustomTypeOfPackage,
                    sTrnshprCd = model.sTrnshprCd,
                    sTrnshprBond = model.sTrnshprBond,
                    sTrnsprtrDocPortOfAcceptedCCd = model.sTrnsprtrDocPortOfAcceptedCCd,
                    sTrnsprtrDocPortOfAcceptedName = model.sTrnsprtrDocPortOfAcceptedName,
                    sTrnsprtrDocPortOfReceiptCcd = model.sTrnsprtrDocPortOfReceiptCcd,
                    sTrnsprtrDocPortOfReceiptName = model.sTrnsprtrDocPortOfReceiptName,
                    sTrnsprtrDocConsignorName = model.sTrnsprtrDocConsignorName,
                    sTrnsprtrDocConsignorCd = model.sTrnsprtrDocConsignorCd,
                    sTrnsprtrDocConsignorCdType = model.sTrnsprtrDocConsignorCdType,
                    sTrnsprtrDocConsignorStreetAddress = model.sTrnsprtrDocConsignorStreetAddress,
                    sTrnsprtrDocConsignorCity = model.sTrnsprtrDocConsignorCity,
                    sTrnsprtrDocConsignorCountrySubDivName = model.sTrnsprtrDocConsignorCountrySubDivName,
                    sTrnsprtrDocConsignorCountrySubDivCd = model.sTrnsprtrDocConsignorCountrySubDivCd,
                    sTrnsprtrDocConsignorCountryCd = model.sTrnsprtrDocConsignorCountryCd,
                    sTrnsprtrDocConsignorPostCd = model.sTrnsprtrDocConsignorPostCd,
                    sTrnsprtrDocConsigneeName = model.sTrnsprtrDocConsigneeName,
                    sTrnsprtrDocConsigneeCd = model.sTrnsprtrDocConsigneeCd,
                    sTrnsprtrDocTypeOfCd = model.sTrnsprtrDocTypeOfCd,
                    sTrnsprtrDocConsigneeStreetAddress = model.sTrnsprtrDocConsigneeStreetAddress,
                    sTrnsprtrDocConsigneeCity = model.sTrnsprtrDocConsigneeCity,
                    sTrnsprtrDocConsigneeCountrySubDivName = model.sTrnsprtrDocConsigneeCountrySubDivName,
                    sTrnsprtrDocConsigneeCountrySubDiv = model.sTrnsprtrDocConsigneeCountrySubDiv,
                    sTrnsprtrDocConsigneeCountryCd = model.sTrnsprtrDocConsigneeCountryCd,
                    sTrnsprtrDocConsigneePostCd = model.sTrnsprtrDocConsigneePostCd,
                    sTrnsprtrDocNameOfAnyOtherNotFdParty = model.sTrnsprtrDocNameOfAnyOtherNotFdParty,
                    sTrnsprtrDocPANOfNotFdParty = model.sTrnsprtrDocPANOfNotFdParty,
                    sTrnsprtrDocTypeOfNotFdPartyCd = model.sTrnsprtrDocTypeOfNotFdPartyCd,
                    sTrnsprtrDocNotFdPartyStreetAddress = model.sTrnsprtrDocNotFdPartyStreetAddress,
                    sTrnsprtrDocNotFdPartyCity = model.sTrnsprtrDocNotFdPartyCity,
                    sTrnsprtrDocNotFdPartyCountrySubDivName = model.sTrnsprtrDocNotFdPartyCountrySubDivName,
                    sTrnsprtrDocNotFdPartyCountrySubDiv = model.sTrnsprtrDocNotFdPartyCountrySubDiv,
                    sTrnsprtrDocNotFdPartyCountryCd = model.sTrnsprtrDocNotFdPartyCountryCd,
                    sTrnsprtrDocNotFdPartyPostCd = model.sTrnsprtrDocNotFdPartyPostCd,
                    sTrnsprtrDocGoodsDescAsPerBill = model.sTrnsprtrDocGoodsDescAsPerBill,
                    sTrnsprtrDocUCRType = model.sTrnsprtrDocUCRType,
                    sTrnsprtrDocUCRCd = model.sTrnsprtrDocUCRCd,
                    dTrnsprtrDocMsrNoOfPackages = model.dTrnsprtrDocMsrNoOfPackages ?? 0,
                    sTrnsprtrDocMsrTypesOfPackages = model.sTrnsprtrDocMsrTypesOfPackages,
                    sTrnsprtrDocMsrMarksNoOnPackages = model.sTrnsprtrDocMsrMarksNoOnPackages,
                    dTrnsprtrDocMsrGrossWeight = model.dTrnsprtrDocMsrGrossWeight,
                    dTrnsprtrDocMsrNetWeight = model.dTrnsprtrDocMsrNetWeight,
                    sTrnsprtrDocMsrUnitOfWeight = model.sTrnsprtrDocMsrUnitOfWeight,
                    dTrnsprtrDocMsrGrossVolume = model.dTrnsprtrDocMsrGrossVolume,
                    sTrnsprtrDocMsrUnitOfVolume = model.sTrnsprtrDocMsrUnitOfVolume,
                    dTrnsprtrDocMsrInvoiceValueOfConsigment = model.dTrnsprtrDocMsrInvoiceValueOfConsigment ?? 0,
                    sTrnsprtrDocMsrCurrencyCd = model.sTrnsprtrDocMsrCurrencyCd,
                    sSuplmntryDecCinType = model.sSuplmntryDecCinType,
                    sSuplmntryDecMCinPCin = model.sSuplmntryDecMCinPCin,
                    sSuplmntryDecCSNSubmtdType = model.sSuplmntryDecCSNSubmtdType,
                    sSuplmntryDecCSNSubmtdBy = model.sSuplmntryDecCSNSubmtdBy,
                    sSuplmntryDecCSNReportingType = model.sSuplmntryDecCSNReportingType,
                    sSuplmntryDecCSNSiteId = model.sSuplmntryDecCSNSiteId,
                    dSuplmntryDecCSNNo = model.dSuplmntryDecCSNNo ?? 0,
                    sSuplmntryDecCSNDate = model.dtSuplmntryDecCSNDate.ToDateTimeString(),
                    sSuplmntryDecPrevMCIN = model.sSuplmntryDecPrevMCIN,
                    sSuplmntryDecSplitIndicator = model.sSuplmntryDecSplitIndicator,
                    dSuplmntryDecNoOfPackages = model.dSuplmntryDecNoOfPackages ?? 0,
                    sSuplmntryDecTypeOfPackages = model.sSuplmntryDecTypeOfPackages,
                    sReportingEvent = model.tblMessageImplementation.sDecRefReportingEvent
                }).SingleOrDefault();
            }
        }

        public List<SelectListItem> GetCountryCodes()
        {
            using (var db = new SeaManifestEntities())
            {
                return db.tblCountryMs.Select(z => new SelectListItem
                {
                    Text= z.sCountryName,
                    Value=z.sCountryCode
                }).ToList();
            }
        }

        public List<SelectListItem> GetCurrencyCodes()
        {
            using (var db = new SeaManifestEntities())
            {
                return db.tblCurrencyCodesMs.Select(z => new SelectListItem
                {
                    Text = z.sCurrencyName,
                    Value = z.sCurrencyCode
                }).ToList();
            }
        }

        public string GetMessageTypeByMasterConsignmentId(int iMasterConsignmentId, out int iMessageImplementationId)
        {
            using (var db = new SeaManifestEntities())
            {
                var query = db.tblMasterConsignmentMessageImplementationMaps.Where(z => z.iMasterConsignmentId == iMasterConsignmentId);
                iMessageImplementationId = query.Select(z => z.iMessageImplementationId??0).SingleOrDefault();
                return query.Select(z =>z.tblMessageImplementation.sDecRefReportingEvent).SingleOrDefault();
            }
        }
    }
}
