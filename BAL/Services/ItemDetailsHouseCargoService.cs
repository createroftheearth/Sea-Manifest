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

        //save ItemDeatilsHouseCargo 
        public object SaveItemDetailsHouseCargo(ItemDetailsHouseCargoModel model, int iUserId)
        {
            try
            {
                using (var db = new SeaManifestEntities())
                {
                    var data = db.tblItemDetailsHouseCargoMaps.Where(z => z.iItemsDetailsId == model.iItemsDetailsId).SingleOrDefault();
                    if (data != null)
                    {
                        data.iMasterConsignmentId = model.iMasterConsignmentId ?? 0;
                        data.iHouseCargoDescId = model.iHouseCargoDescId;
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
                            iMasterConsignmentId = model.iMasterConsignmentId ?? 0,
                            iHouseCargoDescId = model.iHouseCargoDescId,
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
                    return new { Status = true, Message = "Item Details House Cargo saved successfully!" };
                }

            }
            catch (Exception)
            {
                return new { Status = false, Message = "Something went wrong" };
            }
        }

        public object GetItemDetailsHouseCargos(int iHouseCargoDescId, string search, int start, int length, out int recordsTotal)
        {
            using (var db = new SeaManifestEntities())
            {
                var query = from t in db.tblItemDetailsHouseCargoMaps
                            where t.sCargoItemDesc.Contains(search) && t.iHouseCargoDescId == iHouseCargoDescId
                            select t;
                recordsTotal = query.Count();
                return query.OrderBy(z => z.sHsCd).Take(length).Skip(start).ToList().Select(t => new
                {
                    t.iHouseCargoDescId,
                    t.iMasterConsignmentId,
                    t.sCargoItemDesc,
                    t.sHsCd,
                    t.iItemsDetailsId
                    //masterBillDate = t.dtHCRefBillDate?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                }).ToList();
            }
        }

        public ItemDetailsHouseCargoModel GetItemDetailsHouseCargoByItemDetailsId(int? iItemDetailsId)
        {
            using (var db = new SeaManifestEntities())
            {
                return db.tblItemDetailsHouseCargoMaps.Where(z => z.iItemsDetailsId == iItemDetailsId).ToList().Select(model => new ItemDetailsHouseCargoModel
                {
                    iHouseCargoDescId = model.iHouseCargoDescId,
                    iMasterConsignmentId = model.iMasterConsignmentId,
                    dCargoItemSequenceNo = model.dCargoItemSequenceNo??0,
                    sHsCd = model.sHsCd,
                    sCargoItemDesc = model.sCargoItemDesc,
                    sUnoCd = model.sUnoCd,
                    sIMDGCd = model.sIMDGCd,
                    dNoOfPakages = model.dNoOfPakages??0,
                    sTypesOfPackages = model.sTypesOfPackages,

                }).SingleOrDefault();
            }
        }
    }
}
