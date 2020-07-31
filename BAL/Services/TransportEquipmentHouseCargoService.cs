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
                        data.iMasterConsignmentId = model.iMasterConsignmentId ?? 0;
                        data.iHouseCargoDescId = model.iHouseCargoDescId;
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
                        data.sContainerAgentCd = model.sContainerAgentCd;
                        data.dContainerWeight = model.dContainerWeight;
                        data.dTotalNoOfPackages = model.dTotalNoOfPackages;
                        data.iActionBy = iUserId;
                        data.dtActionDate = DateTime.Now;
                        db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        data = new tblTransportEquipmentHouseCargoMap
                        {
                            iMasterConsignmentId = model.iMasterConsignmentId ?? 0,
                            iHouseCargoDescId = model.iHouseCargoDescId,
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
                            sContainerAgentCd = model.sContainerAgentCd,
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
                            where t.sEquipmentId.Contains(search) && t.iHouseCargoDescId == iHouseCargoDescId
                            select t;
                recordsTotal = query.Count();
                return query.OrderBy(z => z.sEquipmentType).Take(length).Skip(start).ToList().Select(t => new
                {
                    t.iHouseCargoDescId,
                    t.iMasterConsignmentId,
                    t.sEquipmentId,
                    t.sEquipmentType,
                    // t.iItemsDetailsId
                    //masterBillDate = t.dtHCRefBillDate?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                }).ToList();
            }
        }

        public TransportEquipmentHouseCargoModel GetTransportEquipmentHouseCargoByTransporterEquipmentId(int? iHouseCargoDescId, int? iTransporterEquipmentId)
        {
            using (var db = new SeaManifestEntities())
            {
                return db.tblTransportEquipmentHouseCargoMaps.Where(z => z.iTransporterEquipmentId == iTransporterEquipmentId).ToList().Select(model => new TransportEquipmentHouseCargoModel
                {
                    iMasterConsignmentId = model.iMasterConsignmentId ?? 0,
                    iHouseCargoDescId = model.iHouseCargoDescId,
                    iEquipmentSequenceNo = model.iEquipmentSequenceNo??0,
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
                    sContainerAgentCd = model.sContainerAgentCd,
                    dContainerWeight = model.dContainerWeight??0,
                    dTotalNoOfPackages = model.dTotalNoOfPackages??0,

                }).SingleOrDefault();
            }
        }
    }
}
