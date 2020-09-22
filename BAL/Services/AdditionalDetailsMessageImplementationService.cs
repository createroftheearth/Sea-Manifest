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
    public class AdditionalDetailsMessageImplementationService : CommonService
    {
        private AdditionalDetailsMessageImplementationService()
        {
        }

        private static AdditionalDetailsMessageImplementationService _instance;

        public static AdditionalDetailsMessageImplementationService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AdditionalDetailsMessageImplementationService();
                return _instance;
            }
        }

        //save AdditionalDetailsMessageImplementation 
        public object SaveAdditionalDetailsMessageImplementation(AdditionalDetailsMessageImplementationModel model, int iUserId)
        {
            try
            {
                using (var db = new SeaManifestEntities())
                {
                    var data = db.tblAdditionalDetailsMessageImplementationMaps.Where(z => z.iAdditionalDetailsId == model.iAdditionalDetailsId).SingleOrDefault();
                    if (data != null)
                    {
                        data.iMessageImplementationId = model.iMessageImplementationId;
                        data.sTagRef = model.sTagRef;
                        data.dRefSerialNo = model.dRefSerialNo;
                        data.sInfoType = model.sInfoType;
                        data.sInfoQualifier = model.sInfoQualifier;
                        data.sInfoCd = model.sInfoCd;
                        data.sInfoText = model.sInfoText;
                        data.sInfoMsr = model.sInfoMsr;
                        data.dtInfoDate = model.sInfoDate.ToDate();
                        data.iActionBy = iUserId;
                        data.dtActionDate = DateTime.Now;
                        db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        data = new tblAdditionalDetailsMessageImplementationMap
                        {
                            iMessageImplementationId = model.iMessageImplementationId,
                            sTagRef = model.sTagRef,
                            dRefSerialNo = model.dRefSerialNo,
                            sInfoType = model.sInfoType,
                            sInfoQualifier = model.sInfoQualifier,
                            sInfoCd = model.sInfoCd,
                            sInfoText = model.sInfoText,
                            sInfoMsr = model.sInfoMsr,
                            dtInfoDate = model.sInfoDate.ToDate(),
                            iActionBy = iUserId,
                            dtActionDate = DateTime.Now,
                        };
                        db.tblAdditionalDetailsMessageImplementationMaps.Add(data);
                        db.SaveChanges();
                    }
                    return new { Status = true, Message = "Additional Details saved successfully!" };
                }

            }
            catch (Exception)
            {
                return new { Status = false, Message = "Something went wrong" };
            }
        }

        public object GetAdditionalDetailsMessageImplementation(int iMessageImplementationId, string search, int start, int length, out int recordsTotal)
        {
            using (var db = new SeaManifestEntities())
            {
                var userId = GetUserInfo().iUserId;
                var query = from t in db.tblAdditionalDetailsMessageImplementationMaps
                            where (
                                t.sInfoMsr.Contains(search) || SqlFunctions.StringConvert(t.dRefSerialNo).Contains(search)
                                || t.sTagRef.Contains(search) || t.sInfoType.Contains(search) || t.sInfoQualifier.Contains(search)
                                || t.sInfoCd.Contains(search) || t.sInfoText.Contains(search) || t.sInfoMsr.Contains(search)
                            )
                            && t.iActionBy == userId
                            && t.iMessageImplementationId == iMessageImplementationId
                            select t;
                recordsTotal = query.Count();
                return query.OrderBy(z => z.sInfoCd).Skip(start).Take(length).ToList().Select(z => new
                {
                    z.iAdditionalDetailsId,
                    z.iMessageImplementationId,
                    z.sInfoCd,
                    z.sInfoMsr,
                    z.sInfoQualifier,
                    z.sInfoText,
                    z.sInfoType,
                    z.sTagRef,
                    z.dRefSerialNo,
                    sInfoDate = z.dtInfoDate.ToDateString()
                }).ToList();
            }
        }

        public AdditionalDetailsMessageImplementationModel GetAdditionalDetailsMessageImplementationByAddDetailsId(int? iAdditionalDetailsId)
        {
            using (var db = new SeaManifestEntities())
            {
                return db.tblAdditionalDetailsMessageImplementationMaps.Where(z => z.iAdditionalDetailsId == iAdditionalDetailsId).ToList().Select(model => new AdditionalDetailsMessageImplementationModel
                {
                    iMessageImplementationId = model.iMessageImplementationId,
                    sTagRef = model.sTagRef,
                    dRefSerialNo = model.dRefSerialNo ?? 0,
                    sInfoType = model.sInfoType,
                    sInfoQualifier = model.sInfoQualifier,
                    sInfoCd = model.sInfoCd,
                    sInfoText = model.sInfoText,
                    sInfoMsr = model.sInfoMsr,
                    iAdditionalDetailsId = model.iAdditionalDetailsId,
                    sReportingEvent = model.tblMessageImplementation.sDecRefReportingEvent,
                    sInfoDate = model.dtInfoDate.ToDateString(),
                }).SingleOrDefault();
            }
        }
    }
}
