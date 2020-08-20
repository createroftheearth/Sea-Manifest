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
    public class SupportDocMasterConsignmentService
    {
        private SupportDocMasterConsignmentService()
        {
        }

        private static SupportDocMasterConsignmentService _instance;

        public static SupportDocMasterConsignmentService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SupportDocMasterConsignmentService();
                return _instance;
            }
        }

        //save SupportDocMasterConsignment 
        public object SaveSupportDocMasterConsignment(SupportDocMasterConsignmentModel model, int iUserId)
        {
            try
            {
                using (var db = new SeaManifestEntities())
                {
                    var data = db.tblSupportDocMasterConsignmentMaps.Where(z => z.iSupportDocsId == model.iSupportDocsId).SingleOrDefault();
                    if (data != null)
                    {
                        data.iMasterConsignmentId = model.iMasterConsignmentId ?? 0;
                        data.iMessageImplementationId = model.iMessageImplementationId;
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
                        data = new tblSupportDocMasterConsignmentMap
                        {
                            iMasterConsignmentId = model.iMasterConsignmentId ?? 0,
                            iMessageImplementationId = model.iMessageImplementationId,
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
                        db.tblSupportDocMasterConsignmentMaps.Add(data);
                        db.SaveChanges();
                    }
                    return new { Status = true, Message = "Support Doc saved successfully!" };
                }

            }
            catch (Exception)
            {
                return new { Status = false, Message = "Something went wrong" };
            }
        }

        public object GetSupportDocMasterConsignment(int iMasterConsignmentId, string search, int start, int length, out int recordsTotal)
        {
            using (var db = new SeaManifestEntities())
            {
                var query = from t in db.tblSupportDocMasterConsignmentMaps
                            where (t.sTagRef.Contains(search) || t.sRefSerialNo.Contains(search)
                            || t.sSubSerialNoRef.Contains(search)
                            || t.sIcegateUserId.Contains(search)
                            || t.sIRNNo.Contains(search)
                            || t.sDocRefNo.Contains(search)
                            || t.sDocTypeCd.Contains(search)
                            || t.sBeneficiaryCd.Contains(search)
                            )
                            && t.iMasterConsignmentId == iMasterConsignmentId
                            select t;
                recordsTotal = query.Count();
                return query.OrderBy(z => z.sIRNNo).Skip(start).Take(length).ToList().Select(t => new
                {
                    t.iMessageImplementationId,
                    t.iMasterConsignmentId,
                    t.sTagRef,
                    t.sRefSerialNo,
                    t.sSubSerialNoRef,
                    t.sIcegateUserId,
                    t.sIRNNo,
                    t.sDocRefNo,
                    t.sDocTypeCd,
                    t.sBeneficiaryCd,
                    t.iSupportDocsId
                }).ToList();
            }
        }

        public SupportDocMasterConsignmentModel GetSupportDocMasterConsignmentBySupportDocsId(int? iSupportDocsId)
        {
            using (var db = new SeaManifestEntities())
            {
                return db.tblSupportDocMasterConsignmentMaps.Where(z => z.iSupportDocsId == iSupportDocsId).ToList().Select(model => new SupportDocMasterConsignmentModel
                {
                    iMasterConsignmentId = model.iMasterConsignmentId ?? 0,
                    iMessageImplementationId = model.iMessageImplementationId,
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
