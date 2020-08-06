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
    public class SupportDocHouseCargoService
    {
        private SupportDocHouseCargoService()
        {
        }

        private static SupportDocHouseCargoService _instance;

        public static SupportDocHouseCargoService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SupportDocHouseCargoService();
                return _instance;
            }
        }

        //save SupportDocHouseCargo 
        public object SaveSupportDocHouseCargo(SupportDocHouseCargoModel model, int iUserId)
        {
            try
            {
                using (var db = new SeaManifestEntities())
                {
                    var data = db.tblSupportDocHouseCargoMaps.Where(z => z.iSupportDocsId == model.iSupportDocsId).SingleOrDefault();
                    if (data != null)
                    {
                        data.iMasterConsignmentId = model.iMasterConsignmentId ?? 0;
                        data.iHouseCargoDescId = model.iHouseCargoDescId;
                        data.sTagRef = model.sTagRef;
                        data.sRefSerialNo = model.sRefSerialNo;
                        data.sSubSerialNoRef = model.sSubSerialNoRef;
                        data.sIcegateUserId = model.sIcegateUserId;
                        data.sIRNNo = model.sIRNNo;
                        data.sDocRefNo = model.sDocRefNo;
                        data.sDocTypeCd = model.sDocTypeCd;
                        data.sBeneficiaryCd = model.sBeneficiaryCd;
                        data.iActionBy = iUserId;
                        data.dtActionDate = DateTime.Now;
                        db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        data = new tblSupportDocHouseCargoMap
                        {
                            iMasterConsignmentId = model.iMasterConsignmentId ?? 0,
                            iHouseCargoDescId = model.iHouseCargoDescId,
                            sTagRef = model.sTagRef,
                            sRefSerialNo = model.sRefSerialNo,
                            sSubSerialNoRef = model.sSubSerialNoRef,
                            sIcegateUserId = model.sIcegateUserId,
                            sIRNNo = model.sIRNNo,
                            sDocRefNo = model.sDocRefNo,
                            sDocTypeCd = model.sDocTypeCd,
                            sBeneficiaryCd = model.sBeneficiaryCd,
                            iActionBy = iUserId,
                            dtActionDate = DateTime.Now,
                        };
                        db.tblSupportDocHouseCargoMaps.Add(data);
                        db.SaveChanges();
                    }
                    return new { Status = true, Message = "Support Doc House Cargo saved successfully!" };
                }

            }
            catch (Exception)
            {
                return new { Status = false, Message = "Something went wrong" };
            }
        }

        public object GetSupportDocHouseCargo(int iHouseCargoDescId, string search, int start, int length, out int recordsTotal)
        {
            using (var db = new SeaManifestEntities())
            {
                var query = from t in db.tblSupportDocHouseCargoMaps
                            where t.sTagRef.Contains(search) && t.iHouseCargoDescId == iHouseCargoDescId
                            select t;
                recordsTotal = query.Count();
                return query.OrderBy(z => z.sIRNNo).Take(length).Skip(start).ToList().Select(t => new
                {
                    t.iHouseCargoDescId,
                    t.iMasterConsignmentId,
                    t.sTagRef,
                    t.sIRNNo,
                    // t.iItemsDetailsId
                    //masterBillDate = t.dtHCRefBillDate?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                }).ToList();
            }
        }

        public SupportDocHouseCargoModel GetSupportDocHouseCargoBySupportDocsId(int? iSupportDocsId)
        {
            using (var db = new SeaManifestEntities())
            {
                return db.tblSupportDocHouseCargoMaps.Where(z => z.iSupportDocsId == iSupportDocsId).ToList().Select(model => new SupportDocHouseCargoModel
                {
                    iMasterConsignmentId = model.iMasterConsignmentId ?? 0,
                    iHouseCargoDescId = model.iHouseCargoDescId,
                    sTagRef = model.sTagRef,
                    sRefSerialNo = model.sRefSerialNo,
                    sSubSerialNoRef = model.sSubSerialNoRef,
                    sIcegateUserId = model.sIcegateUserId,
                    sIRNNo = model.sIRNNo,
                    sDocRefNo = model.sDocRefNo,
                    sDocTypeCd = model.sDocTypeCd,
                    sBeneficiaryCd = model.sBeneficiaryCd,
                }).SingleOrDefault();
            }
        }
    }
}
