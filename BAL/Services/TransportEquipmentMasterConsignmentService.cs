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
    public class TransportEquipmentMasterConsignmentService
    {
        private TransportEquipmentMasterConsignmentService()
        {
        }

        private static TransportEquipmentMasterConsignmentService _instance;

        public static TransportEquipmentMasterConsignmentService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TransportEquipmentMasterConsignmentService();
                return _instance;
            }
        }

        //save TransportEquipmentMasterConsignment 
        public object SaveTransportEquipmentMasterConsignment(TransportEquipmentMasterConsignmentModel model, int iUserId)
        {
            try
            {
                using (var db = new SeaManifestEntities())
                {
                    var data = db.tblTransportEquipmentMasterConsignmentMaps.Where(z => z.iTransporterEquipmentId == model.iTransporterEquipmentId).SingleOrDefault();
                    if (data != null)
                    {
                        data.iMasterConsignmentId = model.iMasterConsignmentId;
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
                            data.iMessageImplementationId = model.iMessageImplementationId;
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
                        data = new tblTransportEquipmentMasterConsignmentMap
                        {
                            iMasterConsignmentId = model.iMasterConsignmentId,
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
                            iMessageImplementationId = model.iMessageImplementationId,
                            dContainerWeight = model.dContainerWeight,
                            dTotalNoOfPackages = model.dTotalNoOfPackages,
                            iActionBy = iUserId,
                            dtActionDate = DateTime.Now,
                        };
                        db.tblTransportEquipmentMasterConsignmentMaps.Add(data);
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

        public bool Validate(TransportEquipmentMasterConsignmentModel model, out string Messages)
        {
            Messages = string.Empty;
            bool valid = true;
            using (var db = new SeaManifestEntities())
            {
                if (db.tblTransportEquipmentMasterConsignmentMaps.Any(z => (model.sReportingEvent != "SEI" && model.sReportingEvent != "SDN") && z.iTransporterEquipmentId != model.iTransporterEquipmentId && z.iEquipmentSequenceNo == model.iEquipmentSequenceNo && z.iMasterConsignmentId == model.iMasterConsignmentId))
                {
                    valid = false; Messages = "Sequence No already exists";
                }
            }
            return valid;
        }

        public object GetTransportEquipmentMasterConsignment(int iMasterConsignmentId, string search, int start, int length, out int recordsTotal)
        {
            using (var db = new SeaManifestEntities())
            {
                var query = from t in db.tblTransportEquipmentMasterConsignmentMaps
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
                            && t.iMasterConsignmentId == iMasterConsignmentId
                            select t;
                recordsTotal = query.Count();
                return query.OrderBy(z => z.sEquipmentType).Skip(start).Take(length).ToList().Select(t => new
                {
                    t.iTransporterEquipmentId,
                    t.iMasterConsignmentId,
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

        public TransportEquipmentMasterConsignmentModel GetTransportEquipmentMasterConsignmentByTransporterEquipmentId(int? iTransporterEquipmentId)
        {
            using (var db = new SeaManifestEntities())
            {
                return db.tblTransportEquipmentMasterConsignmentMaps.Where(z => z.iTransporterEquipmentId == iTransporterEquipmentId).ToList().Select(model => new TransportEquipmentMasterConsignmentModel
                {
                    iMessageImplementationId = model.iMessageImplementationId,
                    iMasterConsignmentId = model.iMasterConsignmentId,
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
                    sReportingEvent = model.tblMessageImplementation.sDecRefReportingEvent,
                }).SingleOrDefault();
            }
        }
    }
}
