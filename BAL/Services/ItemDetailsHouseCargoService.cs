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
    public class ItemDetailsHouseCargoService
    {
        private ItemDetailsHouseCargoService()
        {
        }

        private static ItemDetailsHouseCargoService _instance;

        public static ItemDetailsHouseCargoService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ItemDetailsHouseCargoService();
                return _instance;
            }
        }

        public void Validate(int? iHouseCargoDescId)
        {
            using (var db = new SeaManifestEntities())
            {
                if (!db.tblItemDetailsHouseCargoMaps.Any(z => z.iHouseCargoDescId == iHouseCargoDescId))
                    throw new Exception("Invalid Master Consignment Id");
                if (db.tblItemDetailsHouseCargoMaps.Any(z => z.iHouseCargoDescId == iHouseCargoDescId && (z.tblMasterConsignmentMessageImplementationMap.tblMessageImplementation.sDecRefReportingEvent == "SEI" || z.tblMasterConsignmentMessageImplementationMap.tblMessageImplementation.sDecRefReportingEvent == "SDN")))
                    throw new Exception("Item Details cannot be filled with SEI or SDN reporting type");
            }
        }
        //save ItemDeatilsHouseCargo
        public object SaveItemDetailssHouseCargo(ItemDetailsHouseCargoModel model, int iUserId)
        {
            try
            {
                using (var db = new SeaManifestEntities())
                {
                    var data = db.tblItemDetailsHouseCargoMaps.Where(z => z.iItemsDetailsId == model.iItemsDetailsId).SingleOrDefault();
                    if (data != null)
                    {
                        data.iHouseCargoDescId = model.iHouseCargoDescId ?? 0;
                        data.iMasterConsignmentId = model.iMasterConsignmentId;
                        data.dCargoItemSequenceNo = model.dCargoItemSequenceNo;
                        data.sHsCd = model.sHsCd;
                        data.sCargoItemDesc = model.sCargoItemDesc;
                        data.sUnoCd = model.sUnoCd;
                        data.sIMDGCd = model.sIMDGCd;
                        data.dNoOfPakages = model.dNoOfPakages;
                        data.sTypesOfPackages = model.sTypesOfPackages;
                        data.iActionBy = iUserId;
                        data.dtActionDate = DateTime.Now;
                        db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        data = new tblItemDetailsHouseCargoMap
                        {
                            iHouseCargoDescId = model.iHouseCargoDescId ?? 0,
                            iMasterConsignmentId = model.iMasterConsignmentId,
                            dCargoItemSequenceNo = model.dCargoItemSequenceNo,
                            sHsCd = model.sHsCd,
                            sCargoItemDesc = model.sCargoItemDesc,
                            sUnoCd = model.sUnoCd,
                            sIMDGCd = model.sIMDGCd,
                            dNoOfPakages = model.dNoOfPakages,
                            sTypesOfPackages = model.sTypesOfPackages,
                            iActionBy = iUserId,
                            dtActionDate = DateTime.Now,
                        };
                        db.tblItemDetailsHouseCargoMaps.Add(data);
                        db.SaveChanges();
                    }
                    return new { Status = true, Message = "Item Details saved successfully!" };
                }

            }
            catch (Exception)
            {
                return new { Status = false, Message = "Something went wrong" };
            }
        }

        public bool Validate(ItemDetailsHouseCargoModel model, out string Messages)
        {
            Messages = string.Empty;
            bool valid = true;
            using (var db = new SeaManifestEntities())
            {
                if (db.tblItemDetailsHouseCargoMaps.Any(z => z.iHouseCargoDescId == model.iHouseCargoDescId && z.dCargoItemSequenceNo == model.dCargoItemSequenceNo && z.iItemsDetailsId != model.iItemsDetailsId))
                {
                    valid = false; Messages = "Cargo Item Sequence no already exists.";
                }
            }
            return valid;
        }

        public object GetItemDetailsHouseCargo(int iMasterConsignmentId, string search, int start, int length, out int recordsTotal)
        {
            using (var db = new SeaManifestEntities())
            {
                var query = from t in db.tblItemDetailsHouseCargoMaps
                            where t.sCargoItemDesc.Contains(search) && t.iMasterConsignmentId == iMasterConsignmentId
                            select t;
                recordsTotal = query.Count();
                return query.OrderBy(z => z.sHsCd).Take(length).Skip(start).ToList().Select(t => new
                {
                    t.iMasterConsignmentId,
                    t.iHouseCargoDescId,
                    t.sCargoItemDesc,
                    t.sHsCd,
                    t.iItemsDetailsId,
                    t.dCargoItemSequenceNo,
                    t.dNoOfPakages,
                    t.sTypesOfPackages
                }).ToList();
            }
        }

        public ItemDetailsHouseCargoModel GetItemDetailsHouseCargoByItemDetailsId(int? iItemDetailsId)
        {
            using (var db = new SeaManifestEntities())
            {
                return db.tblItemDetailsHouseCargoMaps.Where(z => z.iItemsDetailsId == iItemDetailsId).ToList().Select(model => new ItemDetailsHouseCargoModel
                {
                    iMasterConsignmentId = model.iMasterConsignmentId,
                    iHouseCargoDescId = model.iHouseCargoDescId,
                    dCargoItemSequenceNo = model.dCargoItemSequenceNo ?? 0,
                    sHsCd = model.sHsCd,
                    sCargoItemDesc = model.sCargoItemDesc,
                    sUnoCd = model.sUnoCd,
                    sIMDGCd = model.sIMDGCd,
                    dNoOfPakages = model.dNoOfPakages ?? 0,
                    sTypesOfPackages = model.sTypesOfPackages,

                }).SingleOrDefault();
            }
        }
    }
}
