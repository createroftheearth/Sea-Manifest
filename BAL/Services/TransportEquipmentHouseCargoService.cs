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

namespace BAL.Services
{
    public class TransportEquipmentHouseCargoService
    {
        private TransportEquipmentHouseCargoService()
        {
        }

        private static TransportEquipmentHouseCargoService _instance;

        public static TransportEquipmentHouseCargoService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TransportEquipmentHouseCargoService();
                return _instance;
            }
        }

        //save TransportEquipmentHouseCargo 
        public object SaveTransportEquipmentHouseCargo(TransportEquipmentHouseCargoModel model, int iUserId)
        {
            try
            {
                using (var db = new SeaManifestEntities())
                {
                    var data = db.tblTransportEquipmentHouseCargoMaps.Where(z => z.iTransporterEquipmentId == model.iTransporterEquipmentId).SingleOrDefault();
                    if (data != null)
                    {
                        data.iHouseCargoDescId = model.iHouseCargoDescId;
                        data.iEquipmentSequenceNo = model.iEquipmentSequenceNo;
                        data.sEquipmentId = model.sEquipmentId;
                        data.sEquipmentType = model.sEquipmentType;
                        data.sEquipmentSize = model.sEquipmentSize;
                        data.sEquipmentLoadStatus = model.sEquipmentLoadStatus;
                        data.sAdditionalEquipmentHold = model.sAdditionalEquipmentHold;
                        data.sEquipmentSealType = model.sEquipmentSealType;
                        data.sEquipmentSealNo = model.sEquipmentSealNo;
                        data.sOtherEquipmentId = model.sOtherEquipmentId;
                        data.sSOCFlag = model.sSOCFlag;
                        data.sContainerAgentCd = model.sContainerAgentCd;
                        data.iMasterConsignmentId = model.iMasterConsignmentId;
                        data.dContainerWeight = model.dContainerWeight;
                        data.dTotalNoOfPackages = model.dTotalNoOfPackages;
                        data.iActionBy = iUserId;
                        data.dtActionDate = DateTime.Now;
                        data.iActionBy = iUserId;
                        data.dtActionDate = DateTime.Now;
                        db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        data = new tblTransportEquipmentHouseCargoMap
                        {
                            iHouseCargoDescId = model.iHouseCargoDescId,
                            iEquipmentSequenceNo = model.iEquipmentSequenceNo,
                            sEquipmentId = model.sEquipmentId,
                            sEquipmentType = model.sEquipmentType,
                            sEquipmentSize = model.sEquipmentSize,
                            sEquipmentLoadStatus = model.sEquipmentLoadStatus,
                            sAdditionalEquipmentHold = model.sAdditionalEquipmentHold,
                            sEquipmentSealType = model.sEquipmentSealType,
                            sEquipmentSealNo = model.sEquipmentSealNo,
                            sOtherEquipmentId = model.sOtherEquipmentId,
                            sSOCFlag = model.sSOCFlag,
                            sContainerAgentCd = model.sContainerAgentCd,
                            iMasterConsignmentId = model.iMasterConsignmentId,
                            dContainerWeight = model.dContainerWeight,
                            dTotalNoOfPackages = model.dTotalNoOfPackages,
                            iActionBy = iUserId,
                            dtActionDate = DateTime.Now,
                        };
                        db.tblTransportEquipmentHouseCargoMaps.Add(data);
                        db.SaveChanges();
                    }
                    return new { Status = true, Message = "Transport Equipment House Cargo saved successfully!" };
                }

            }
            catch (Exception)
            {
                return new { Status = false, Message = "Something went wrong" };
            }
        }

        public object GetTransportEquipmentHouseCargo(int iHouseCargoDescId, string search, int start, int length, out int recordsTotal)
        {
            using (var db = new SeaManifestEntities())
            {
                var query = from t in db.tblTransportEquipmentHouseCargoMaps
                            where
                            (t.sEquipmentId.Contains(search)
                            || t.sEquipmentType.Contains(search)
                            || t.sEquipmentSize.Contains(search)
                            || t.sEquipmentLoadStatus.Contains(search)
                            || t.sAdditionalEquipmentHold.Contains(search)
                            || t.sEquipmentSealType.Contains(search)
                            || t.sEquipmentSealNo.Contains(search)
                            || t.sOtherEquipmentId.Contains(search)
                            || t.sSOCFlag.Contains(search)
                            || t.sContainerAgentCd.Contains(search)
                            || SqlFunctions.StringConvert(t.dContainerWeight).Contains(search)
                            || SqlFunctions.StringConvert(t.dTotalNoOfPackages).Contains(search)
                            )
                            && t.iHouseCargoDescId == iHouseCargoDescId
                            select t;
                recordsTotal = query.Count();
                return query.OrderBy(z => z.sEquipmentType).Skip(start).Take(length).ToList().Select(t => new
                {
                    t.iTransporterEquipmentId,
                    t.iHouseCargoDescId,
                    t.iEquipmentSequenceNo,
                    t.sEquipmentId,
                    t.sEquipmentType,
                    t.sEquipmentSize,
                    t.sEquipmentLoadStatus,
                    t.sAdditionalEquipmentHold,
                    t.sEquipmentSealType,
                    t.sEquipmentSealNo,
                    t.sOtherEquipmentId,
                    t.sSOCFlag,
                    t.sContainerAgentCd,
                    t.dContainerWeight,
                    t.dTotalNoOfPackages,
                }).ToList();
            }
        }

        public TransportEquipmentHouseCargoModel GetTransportEquipmentHouseCargoByTransporterEquipmentId(int? iTransporterEquipmentId)
        {
            using (var db = new SeaManifestEntities())
            {
                return db.tblTransportEquipmentHouseCargoMaps.Where(z => z.iTransporterEquipmentId == iTransporterEquipmentId).ToList().Select(model => new TransportEquipmentHouseCargoModel
                {
                    iMasterConsignmentId = model.iMasterConsignmentId,
                    iHouseCargoDescId = model.iHouseCargoDescId,
                    iEquipmentSequenceNo = model.iEquipmentSequenceNo ?? 0,
                    sEquipmentId = model.sEquipmentId,
                    sEquipmentType = model.sEquipmentType,
                    sEquipmentSize = model.sEquipmentSize,
                    sEquipmentLoadStatus = model.sEquipmentLoadStatus,
                    sAdditionalEquipmentHold = model.sAdditionalEquipmentHold,
                    sEquipmentSealType = model.sEquipmentSealType,
                    sEquipmentSealNo = model.sEquipmentSealNo,
                    sOtherEquipmentId = model.sOtherEquipmentId,
                    sSOCFlag = model.sSOCFlag,
                    sContainerAgentCd = model.sContainerAgentCd,
                    dContainerWeight = model.dContainerWeight ?? 0,
                    dTotalNoOfPackages = model.dTotalNoOfPackages ?? 0,
                    iTransporterEquipmentId = model.iTransporterEquipmentId,
                    sReportingEvent = model.tblMasterConsignmentMessageImplementationMap.tblMessageImplementation.sDecRefReportingEvent,
                }).SingleOrDefault();
            }
        }
    }
}
