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
    public class ItemDetailsMasterConsignmentService
    {
        private ItemDetailsMasterConsignmentService()
        {
        }

        private static ItemDetailsMasterConsignmentService _instance;

        public static ItemDetailsMasterConsignmentService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ItemDetailsMasterConsignmentService();
                return _instance;
            }
        }

        //save ItemDeatilsMasterConsignment
        public object SaveItemDetailssMasterConsignment(ItemDetailsMasterConsignmentModel model, int iUserId)
        {
            try
            {
                using (var db = new SeaManifestEntities())
                {
                    var data = db.tblItemDetailsMasterConsignmentMaps.Where(z => z.iItemsDetailsId == model.iItemsDetailsId).SingleOrDefault();
                    if (data != null)
                    {
                        data.iMasterConsignmentId = model.iMasterConsignmentId ?? 0;
                        data.iMessageImplementationId = model.iMessageImplementationId;
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
                        data = new tblItemDetailsMasterConsignmentMap
                        {
                            iMasterConsignmentId = model.iMasterConsignmentId ?? 0,
                            iMessageImplementationId = model.iMessageImplementationId,
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
                        db.tblItemDetailsMasterConsignmentMaps.Add(data);
                        db.SaveChanges();
                    }
                    return new { Status = true, Message = "Item Details Master Consignment saved successfully!" };
                }

            }
            catch (Exception)
            {
                return new { Status = false, Message = "Something went wrong" };
            }
        }

        public object GetItemDetailsMasterConsignment(int iMessageImplementationId, string search, int start, int length, out int recordsTotal)
        {
            using (var db = new SeaManifestEntities())
            {
                var query = from t in db.tblItemDetailsMasterConsignmentMaps
                            where t.sCargoItemDesc.Contains(search) && t.iMessageImplementationId == iMessageImplementationId
                            select t;
                recordsTotal = query.Count();
                return query.OrderBy(z => z.sHsCd).Take(length).Skip(start).ToList().Select(t => new
                {
                    t.iMessageImplementationId,
                    t.iMasterConsignmentId,
                    t.sCargoItemDesc,
                    t.sHsCd,
                    t.iItemsDetailsId
                    //masterBillDate = t.dtHCRefBillDate?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                }).ToList();
            }
        }

        public ItemDetailsMasterConsignmentModel GetItemDetailsMasterConsignmentByItemDetailsId(int? iItemDetailsId)
        {
            using (var db = new SeaManifestEntities())
            {
                return db.tblItemDetailsMasterConsignmentMaps.Where(z => z.iItemsDetailsId == iItemDetailsId).ToList().Select(model => new ItemDetailsMasterConsignmentModel
                {
                    iMessageImplementationId = model.iMessageImplementationId,
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
