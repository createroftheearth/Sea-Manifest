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
    public class AmendmentDetailsMessageImlementationService : CommonService
    {
        private AmendmentDetailsMessageImlementationService()
        {
        }

        private static AmendmentDetailsMessageImlementationService _instance;

        public static AmendmentDetailsMessageImlementationService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AmendmentDetailsMessageImlementationService();
                return _instance;
            }
        }

        //save AmendmentDetailsMessageImlementation 
        public object SaveAmendmentDetailsMessageImlementation(AmendmentDetailsMessageImlementationModel model, int iUserId)
        {
            try
            {
                using (var db = new SeaManifestEntities())
                {
                    var data = db.tblAmendmentDetailsMessageImlementationMaps.Where(z => z.iAmendmentId == model.iAmendmentId).SingleOrDefault();
                    if (data != null)
                    {
                        data.iMessageImplementationId = model.iMessageImplementationId;
                        data.sAmendRefNo = model.sAmendRefNo;
                        data.sAmendFlag = model.sAmendFlag;
                        data.sAmendType = model.sAmendType;
                        data.iActionBy = iUserId;
                        data.dtActionDate = DateTime.Now;
                        db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        data = new tblAmendmentDetailsMessageImlementationMap
                        {
                            iMessageImplementationId = model.iMessageImplementationId,
                            sAmendRefNo = model.sAmendRefNo,
                            sAmendFlag = model.sAmendFlag,
                            sAmendType = model.sAmendType,
                            iActionBy = iUserId,
                            dtActionDate = DateTime.Now,
                        };
                        db.tblAmendmentDetailsMessageImlementationMaps.Add(data);
                        db.SaveChanges();
                    }
                    return new { Status = true, Message = "Amendment Details saved successfully!" };
                }

            }
            catch (Exception)
            {
                return new { Status = false, Message = "Something went wrong" };
            }
        }

        public object GetAmendmentDetailsMessageImlementation(int iMessageImplementationId, string search, int start, int length, out int recordsTotal)
        {
            using (var db = new SeaManifestEntities())
            {
                var userId = GetUserInfo().iUserId;
                var query = from t in db.tblAmendmentDetailsMessageImlementationMaps
                            where (
                            t.sAmendRefNo.Contains(search)
                            || t.sAmendFlag.Contains(search)
                            || t.sAmendType.Contains(search)
                            )
                            && t.iMessageImplementationId == iMessageImplementationId
                                                        && t.iActionBy == userId
                            select t;
                recordsTotal = query.Count();
                return query.OrderBy(z => z.sAmendRefNo).Skip(start).Take(length).ToList().Select(t => new
                {
                    t.iMessageImplementationId,
                    t.sAmendRefNo,
                    t.sAmendFlag,
                    t.sAmendType,
                    t.iAmendmentId
                }).ToList();
            }
        }

        public AmendmentDetailsMessageImlementationModel GetAmendmentDetailsMessageImlementationByAmendmentId(int? iAmendmentId)
        {
            using (var db = new SeaManifestEntities())
            {
                return db.tblAmendmentDetailsMessageImlementationMaps.Where(z => z.iAmendmentId == iAmendmentId).ToList().Select(model => new AmendmentDetailsMessageImlementationModel
                {

                    iMessageImplementationId = model.iMessageImplementationId,
                    iAmendmentId = model.iAmendmentId,
                    sAmendRefNo = model.sAmendRefNo,
                    sAmendFlag = model.sAmendFlag,
                    sAmendType = model.sAmendType,
                }).SingleOrDefault();
            }
        }
    }
}
