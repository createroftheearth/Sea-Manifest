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
    public class TransportEquipmentMessageImplementationService
    {
        private TransportEquipmentMessageImplementationService()
        {
        }

        private static TransportEquipmentMessageImplementationService _instance;

        public static TransportEquipmentMessageImplementationService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TransportEquipmentMessageImplementationService();
                return _instance;
            }
        }

        //save TransportEquipmentMessageImplementation 
        public object SaveTransportEquipmentMessageImplementation(TransportEquipmentMessageImplementationModel model, int iUserId)
        {
            try
            {
                using (var db = new SeaManifestEntities())
                {
                    var data = db.tblVoyageTransporterEquipmentMessageImplementationMaps.Where(z => z.iVoyageTransportId == model.iTransporterEquipmentId).SingleOrDefault();
                    if (data != null)
                    {
                        data.iMessageImplementationId = model.iMessageImplementationId;
                        data.iEquipmentSequenceNo = model.iEquipmentSequenceNo;
                        data.sEquipmentId = model.sEquipmentId;
                        data.sEquipmentType = model.sEquipmentType;
                        data.sEquipmentSize = model.sEquipmentSize;
                        data.sEquipmentLoadStatus = model.sEquipmentLoadStatus;
                        data.sAdditionalEquipmentHold = model.sAdditionalEquipmentHold;
                        data.dtEventDate = model.sEventDate.ToDate();
                        data.sEquipmentSealType = model.sEquipmentSealType;
                        data.sEquipmentSealNo = model.sEquipmentSealNo;
                        data.sOtherEquipmentId = model.sOtherEquipmentId;
                        data.sSOCFlag = model.sSOCFlag;
                        data.sContainerAgentCode = model.sContainerAgentCd;
                        data.dContainerWeight = model.dContainerWeight;
                        data.dTotalNoOfPackages = model.dTotalNoOfPackages;
                        data.sEquipmentStatus = model.sEquipmentStatus;
                        data.sFinalLocation = model.sFinalLocation;
                        data.sStoragePositionCoded = model.sStoragePositionCoded;
                        data.iActionBy = iUserId;
                        data.dtActionDate = DateTime.Now;
                        db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        data = new tblVoyageTransporterEquipmentMessageImplementationMap
                        {
                            iMessageImplementationId = model.iMessageImplementationId,
                            iEquipmentSequenceNo = model.iEquipmentSequenceNo,
                            sEquipmentId = model.sEquipmentId,
                            sEquipmentType = model.sEquipmentType,
                            sEquipmentSize = model.sEquipmentSize,
                            sEquipmentLoadStatus = model.sEquipmentLoadStatus,
                            sAdditionalEquipmentHold = model.sAdditionalEquipmentHold,
                            dtEventDate = model.sEventDate.ToDate(),
                            sEquipmentSealType = model.sEquipmentSealType,
                            sEquipmentSealNo = model.sEquipmentSealNo,
                            sOtherEquipmentId = model.sOtherEquipmentId,
                            sSOCFlag = model.sSOCFlag,
                            sContainerAgentCode = model.sContainerAgentCd,
                            dContainerWeight = model.dContainerWeight,
                            dTotalNoOfPackages = model.dTotalNoOfPackages,
                            sEquipmentStatus = model.sEquipmentStatus,
                            sFinalLocation = model.sFinalLocation,
                            sStoragePositionCoded = model.sStoragePositionCoded,
                            iActionBy = iUserId,
                            dtActionDate = DateTime.Now,
                        };
                        db.tblVoyageTransporterEquipmentMessageImplementationMaps.Add(data);
                        db.SaveChanges();
                    }
                    return new { Status = true, Message = "Transport Equipment saved successfully!" };
                }

            }
            catch (Exception)
            {
                return new { Status = false, Message = "Something went wrong" };
            }
        }

        public object GetTransportEquipmentMessageImplementation(int iMessageImplementationId, string search, int start, int length, out int recordsTotal)
        {
            using (var db = new SeaManifestEntities())
            {
                var query = from t in db.tblVoyageTransporterEquipmentMessageImplementationMaps
                            where
                            ( t.sEquipmentId.Contains(search)
                            || t.sEquipmentType.Contains(search)
                            || t.sEquipmentSize.Contains(search)
                            || t.sEquipmentLoadStatus.Contains(search)
                            || t.sAdditionalEquipmentHold.Contains(search)
                            || t.sEquipmentSealType.Contains(search)
                            || t.sEquipmentSealNo.Contains(search)
                            || t.sOtherEquipmentId.Contains(search)
                            || t.sSOCFlag.Contains(search)
                            || t.sContainerAgentCode.Contains(search)
                            || SqlFunctions.StringConvert(t.dContainerWeight).Contains(search)
                            || SqlFunctions.StringConvert(t.dTotalNoOfPackages).Contains(search)
                            )
                            && t.iMessageImplementationId == iMessageImplementationId
                            select t;
                recordsTotal = query.Count();
                return query.OrderBy(z => z.sEquipmentType).Skip(start).Take(length).ToList().Select(t => new
                {
                    t.iVoyageTransportId,
                    t.iMessageImplementationId,
                    t.iEquipmentSequenceNo ,
                    t.sEquipmentId ,
                    t.sEquipmentType,
                    t.sEquipmentSize,
                    t.sEquipmentLoadStatus ,
                    t.sAdditionalEquipmentHold ,
                    sEventDate = t.dtEventDate.ToDateString(),
                    t.sEquipmentSealType,
                    t.sEquipmentSealNo ,
                    t.sOtherEquipmentId,
                    t.sSOCFlag ,
                    t.sContainerAgentCode,
                    t.dContainerWeight,
                    t.dTotalNoOfPackages,
                    t.sEquipmentStatus,
                    t.sFinalLocation,
                    t.sStoragePositionCoded,
                }).ToList();
            }
        }

        public TransportEquipmentMessageImplementationModel GetTransportEquipmentMessageImplementationByTransporterEquipmentId(int? iTransporterEquipmentId)
        {
            using (var db = new SeaManifestEntities())
            {
                return db.tblVoyageTransporterEquipmentMessageImplementationMaps.Where(z => z.iVoyageTransportId == iTransporterEquipmentId).ToList().Select(model => new TransportEquipmentMessageImplementationModel
                {
                    iMessageImplementationId = model.iMessageImplementationId,
                    iEquipmentSequenceNo = model.iEquipmentSequenceNo ?? 0,
                    sEquipmentId = model.sEquipmentId,
                    sEquipmentType = model.sEquipmentType,
                    sEquipmentSize = model.sEquipmentSize,
                    sEquipmentLoadStatus = model.sEquipmentLoadStatus,
                    sAdditionalEquipmentHold = model.sAdditionalEquipmentHold,
                    sEventDate = model.dtEventDate.ToDateString(),
                    sEquipmentSealType = model.sEquipmentSealType,
                    sEquipmentSealNo = model.sEquipmentSealNo,
                    sOtherEquipmentId = model.sOtherEquipmentId,
                    sSOCFlag = model.sSOCFlag,
                    sContainerAgentCd = model.sContainerAgentCode,
                    dContainerWeight = model.dContainerWeight ?? 0,
                    dTotalNoOfPackages = model.dTotalNoOfPackages ?? 0,
                    sEquipmentStatus = model.sEquipmentStatus,
                    sFinalLocation = model.sFinalLocation,
                    sStoragePositionCoded = model.sStoragePositionCoded,
                    iTransporterEquipmentId = model.iVoyageTransportId,
                    sReportingEvent = model.tblMessageImplementation.sDecRefReportingEvent,
                }).SingleOrDefault();
            }
        }
    }
}
