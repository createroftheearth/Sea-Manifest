using BAL.Models;
using DAL;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services
{
    public class ItemDetailsMasterConsignmentService : CommonService
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

        public void Validate(int? iMasterConsignmentId)
        {
            using (var db = new SeaManifestEntities())
            {
                if (!db.tblMasterConsignmentMessageImplementationMaps.Any(z => z.iMasterConsignmentId == iMasterConsignmentId))
                    throw new Exception("Invalid Master Consignment Id");
                if (db.tblMasterConsignmentMessageImplementationMaps.Any(z => z.iMasterConsignmentId == iMasterConsignmentId && (z.tblMessageImplementation.sDecRefReportingEvent == "SEI" || z.tblMessageImplementation.sDecRefReportingEvent == "SDN")))
                    throw new Exception("Item Details cannot be filled with SEI or SDN reporting type");
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
                    return new { Status = true, Message = "Item Details saved successfully!" };
                }

            }
            catch (Exception)
            {
                return new { Status = false, Message = "Something went wrong" };
            }
        }

        public bool Validate(ItemDetailsMasterConsignmentModel model, out string Messages)
        {
            Messages = string.Empty;
            bool valid = true;
            using (var db = new SeaManifestEntities())
            {
                if (db.tblItemDetailsMasterConsignmentMaps.Any(z => z.iMasterConsignmentId == model.iMasterConsignmentId && z.dCargoItemSequenceNo == model.dCargoItemSequenceNo && z.iItemsDetailsId != model.iItemsDetailsId))
                {
                    valid = false; Messages = "Cargo Item Sequence no already exists.";
                }
            }
            return valid;
        }

        public object GetItemDetailsMasterConsignment(int iMasterConsignmentId, string search, int start, int length, out int recordsTotal)
        {
            using (var db = new SeaManifestEntities())
            {
                var userId = GetUserInfo().iUserId;
                var query = from t in db.tblItemDetailsMasterConsignmentMaps
                            where (SqlFunctions.StringConvert(t.dCargoItemSequenceNo).Contains(search) || SqlFunctions.StringConvert(t.dNoOfPakages).Contains(search) || t.sCargoItemDesc.Contains(search) || t.sTypesOfPackages.Contains(search)) && t.iMasterConsignmentId == iMasterConsignmentId
                            && t.iActionBy == userId
                            select t;
                recordsTotal = query.Count();
                return query.OrderBy(z => z.sHsCd).Skip(start).Take(length).ToList().Select(t => new
                {
                    t.iMessageImplementationId,
                    t.iMasterConsignmentId,
                    t.sCargoItemDesc,
                    t.sHsCd,
                    t.iItemsDetailsId,
                    t.dCargoItemSequenceNo,
                    t.dNoOfPakages,
                    t.sTypesOfPackages
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
                    dCargoItemSequenceNo = model.dCargoItemSequenceNo ?? 0,
                    sHsCd = model.sHsCd,
                    sCargoItemDesc = model.sCargoItemDesc,
                    sUnoCd = model.sUnoCd,
                    sIMDGCd = model.sIMDGCd,
                    dNoOfPakages = model.dNoOfPakages ?? 0,
                    sTypesOfPackages = model.sTypesOfPackages,
                    iItemsDetailsId = model.iItemsDetailsId
                }).SingleOrDefault();
            }
        }
    }
}
