using BAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        //save master Consigment 
        public object SaveMasterConsigment(MasterConsignmentModel model, int iUserId)
        {
            try
            {
                using (var db = new SeaManifestEntities())
                {
                    var data = db.tblMasterConsignmentMessageImplementationMaps.Where(z => z.iMessageImplementationId == model.iMessageImplementationId).SingleOrDefault();
                    if (data != null)
                    {
                        data.iMessageImplementationId = model.iMessageImplementationId;
                        data.iMCRefLineNo = model.iMCRefLineNo;
                        data.sMCRefMasterBillNo = model.sMCRefMasterBillNo;
                        data.dtMCRefMasterBillDate = DateTime.ParseExact(model.dtMCRefMasterBillDate, "dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture);
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
                        data.dtPrevRefCSNDate = DateTime.ParseExact(model.dtPrevRefCSNDate, "dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture);
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
                        data.dtSuplmntryDecCSNDate = DateTime.ParseExact(model.dtSuplmntryDecCSNDate, "dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture);
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
                            dtMCRefMasterBillDate = DateTime.ParseExact(model.dtMCRefMasterBillDate, "dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture),
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
                            dtPrevRefCSNDate = DateTime.ParseExact(model.dtPrevRefCSNDate, "dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture),
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
                            dtSuplmntryDecCSNDate = DateTime.ParseExact(model.dtSuplmntryDecCSNDate, "dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture),
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

        public object GetConsignments(int iMessageImplementationId, string search, int start, int length, out int recordsTotal)
        {
            using (var db = new SeaManifestEntities())
            {
                var query = from t in db.tblMasterConsignmentMessageImplementationMaps
                            where t.sMCRefMasterBillNo.Contains(search) 
                            select t;
                recordsTotal = query.Count();
                return query.OrderBy(z => z.iMCRefLineNo).Take(length).Skip(start).ToList().Select(t => new
                {
                    t.iMessageImplementationId,
                    t.iMasterConsignmentId,
                    t.iMCRefLineNo,
                    t.sMCRefMasterBillNo,
                    masterBillDate = t.dtMCRefMasterBillDate?.ToString("dd/MM/yyyy",CultureInfo.InvariantCulture),
                }).ToList();
            }
        }

        public MasterConsignmentModel GetMasterConsigmentMessageImpementationId(int? iMessageImplementationId)
        {
            using (var db = new SeaManifestEntities())
            {
                return db.tblMasterConsignmentMessageImplementationMaps.Where(z => z.iMessageImplementationId == iMessageImplementationId).ToList().Select(model => new MasterConsignmentModel
                {
                    iMasterConsignmentId = model.iMasterConsignmentId,
                    iMessageImplementationId = model.iMessageImplementationId,
                    iMCRefLineNo = model.iMCRefLineNo,
                    sMCRefMasterBillNo = model.sMCRefMasterBillNo,
                    dtMCRefMasterBillDate = model.dtMCRefMasterBillDate?.ToString("dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture),
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
                    dtPrevRefCSNDate = model.dtPrevRefCSNDate?.ToString("dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture),
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
                    dtSuplmntryDecCSNDate = model.dtSuplmntryDecCSNDate?.ToString("dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture),
                    sSuplmntryDecPrevMCIN = model.sSuplmntryDecPrevMCIN,
                    sSuplmntryDecSplitIndicator = model.sSuplmntryDecSplitIndicator,
                    dSuplmntryDecNoOfPackages = model.dSuplmntryDecNoOfPackages ?? 0,
                    sSuplmntryDecTypeOfPackages = model.sSuplmntryDecTypeOfPackages,
                }).SingleOrDefault();
            }
        }
    }
}
