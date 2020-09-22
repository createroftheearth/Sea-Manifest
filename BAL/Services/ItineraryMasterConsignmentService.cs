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
    public class ItineraryMasterConsignmentService : CommonService
    {
        private ItineraryMasterConsignmentService()
        {
        }

        private static ItineraryMasterConsignmentService _instance;

        public static ItineraryMasterConsignmentService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ItineraryMasterConsignmentService();
                return _instance;
            }
        }

        //save ItemDeatilsMasterConsignment 
        public object SaveItineraryHouseMasterConsignment(ItineraryMasterConsignmentModel model, int iUserId)
        {
            try
            {
                using (var db = new SeaManifestEntities())
                {
                    var data = db.tblItineraryMasterConsignmentMaps.Where(z => z.iItineraryId == model.iItineraryId).SingleOrDefault();
                    if (data != null)
                    {

                        data.iMasterConsignmentId = model.iMasterConsignmentId ?? 0;
                        data.iMessageImplementationId = model.iMessageImplementationId;
                        data.dPortOfCallSequenceNo = model.dPortOfCallSequenceNo;
                        data.sPortOfCallCd = model.sPortOfCallCd;
                        data.sPortOfCallName = model.sPortOfCallName;
                        data.sNextPortOfCallCdd = model.sNextPortOfCallCdd;
                        data.sNextPortOfCallName = model.sNextPortOfCallName;
                        data.sModeOfTransport = model.sModeOfTransport;
                        data.iActionBy = iUserId;
                        data.dtActionDate = DateTime.Now;
                        db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        data = new tblItineraryMasterConsignmentMap
                        {
                            iMasterConsignmentId = model.iMasterConsignmentId ?? 0,
                            iMessageImplementationId = model.iMessageImplementationId,
                            dPortOfCallSequenceNo = model.dPortOfCallSequenceNo,
                            sPortOfCallCd = model.sPortOfCallCd,
                            sPortOfCallName = model.sPortOfCallName,
                            sNextPortOfCallCdd = model.sNextPortOfCallCdd,
                            sNextPortOfCallName = model.sNextPortOfCallName,
                            sModeOfTransport = model.sModeOfTransport,
                            iActionBy = iUserId,
                            dtActionDate = DateTime.Now,
                        };
                        db.tblItineraryMasterConsignmentMaps.Add(data);
                        db.SaveChanges();
                    }
                    return new { Status = true, Message = "Itinerary saved successfully!" };
                }

            }
            catch (Exception)
            {
                return new { Status = false, Message = "Something went wrong" };
            }
        }

        public object GetItineraryHouseMasterConsignments(int iMasterConsignmentId, string search, int start, int length, out int recordsTotal)
        {
            using (var db = new SeaManifestEntities())
            {
                var userId = GetUserInfo().iUserId;
                var query = from t in db.tblItineraryMasterConsignmentMaps
                            where t.sPortOfCallName.Contains(search) && t.iMasterConsignmentId == iMasterConsignmentId
                            && t.iActionBy == userId
                            select t;
                recordsTotal = query.Count();
                return query.OrderBy(z => z.sPortOfCallCd).Skip(start).Take(length).ToList().Select(t => new
                {
                    t.dPortOfCallSequenceNo,
                    t.iMessageImplementationId,
                    t.iItineraryId,
                    t.iMasterConsignmentId,
                    t.sModeOfTransport,
                    t.sNextPortOfCallCdd,
                    t.sNextPortOfCallName,
                    t.sPortOfCallCd,
                    t.sPortOfCallName,
                }).ToList();
            }
        }

        public bool ValidateItinerary(ItineraryMasterConsignmentModel model, out string Messages)
        {
            Messages = string.Empty;
            bool valid = true;
            using (var db = new SeaManifestEntities())
            {
                if (db.tblItineraryMasterConsignmentMaps.Any(z => z.iItineraryId != model.iItineraryId && z.dPortOfCallSequenceNo== model.dPortOfCallSequenceNo && z.iMasterConsignmentId == model.iMasterConsignmentId))
                {
                    valid = false; Messages = "Port of call seq no already exists";
                }
            }
            return valid;
        }

        public ItineraryMasterConsignmentModel GetItineraryHouseMasterConsignmentByItenaryId(int? iIternaryId)
        {
            using (var db = new SeaManifestEntities())
            {
                return db.tblItineraryMasterConsignmentMaps.Where(z => z.iItineraryId == iIternaryId).ToList().Select(model => new ItineraryMasterConsignmentModel
                {
                    iMasterConsignmentId = model.iMasterConsignmentId ?? 0,
                    iItineraryId = model.iItineraryId,
                    iMessageImplementationId = model.iMessageImplementationId,
                    dPortOfCallSequenceNo = model.dPortOfCallSequenceNo ?? 0,
                    sPortOfCallCd = model.sPortOfCallCd,
                    sPortOfCallName = model.sPortOfCallName,
                    sNextPortOfCallCdd = model.sNextPortOfCallCdd,
                    sNextPortOfCallName = model.sNextPortOfCallName,
                    sModeOfTransport = model.sModeOfTransport,
                    sReportingEvent = model.tblMasterConsignmentMessageImplementationMap.tblMessageImplementation.sDecRefReportingEvent
                }).SingleOrDefault();
            }
        }
    }
}
