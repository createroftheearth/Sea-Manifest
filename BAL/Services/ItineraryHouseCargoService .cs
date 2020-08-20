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
    public class ItineraryHouseCargoService
    {
        private ItineraryHouseCargoService()
        {
        }

        private static ItineraryHouseCargoService _instance;

        public static ItineraryHouseCargoService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ItineraryHouseCargoService();
                return _instance;
            }
        }

        //save ItemDeatilsHouseCargo 
        public object SaveItineraryHouseHouseCargo(ItineraryHouseCargoModel model, int iUserId)
        {
            try
            {
                using (var db = new SeaManifestEntities())
                {
                    var data = db.tblItineraryHouseCargoMaps.Where(z => z.iItineraryId == model.iItineraryId).SingleOrDefault();
                    if (data != null)
                    {

                        data.iMasterConsignmentId = model.iMasterConsignmentId ?? 0;
                        data.iHouseCargoDescId = model.iHouseCargoDescId;
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
                        data = new tblItineraryHouseCargoMap
                        {
                            iMasterConsignmentId = model.iMasterConsignmentId ?? 0,
                            iHouseCargoDescId = model.iHouseCargoDescId,
                            dPortOfCallSequenceNo = model.dPortOfCallSequenceNo,
                            sPortOfCallCd = model.sPortOfCallCd,
                            sPortOfCallName = model.sPortOfCallName,
                            sNextPortOfCallCdd = model.sNextPortOfCallCdd,
                            sNextPortOfCallName = model.sNextPortOfCallName,
                            sModeOfTransport = model.sModeOfTransport,
                            iActionBy = iUserId,
                            dtActionDate = DateTime.Now,
                        };
                        db.tblItineraryHouseCargoMaps.Add(data);
                        db.SaveChanges();
                    }
                    return new { Status = true, Message = "Itinerary House Cargo saved successfully!" };
                }

            }
            catch (Exception)
            {
                return new { Status = false, Message = "Something went wrong" };
            }
        }

        public object GetItineraryHouseHouseCargos(int iHouseCargoDescId, string search, int start, int length, out int recordsTotal)
        {
            using (var db = new SeaManifestEntities())
            {
                var query = from t in db.tblItineraryHouseCargoMaps
                            where t.sPortOfCallName.Contains(search) && t.iHouseCargoDescId == iHouseCargoDescId
                            select t;
                recordsTotal = query.Count();
                return query.OrderBy(z => z.sPortOfCallCd).Skip(start).Take(length).ToList().Select(t => new
                {
                    t.dPortOfCallSequenceNo,
                    t.iHouseCargoDescId,
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

        public ItineraryHouseCargoModel GetItineraryHouseHouseCargoByItenaryId(int? iIternaryId)
        {
            using (var db = new SeaManifestEntities())
            {
                return db.tblItineraryHouseCargoMaps.Where(z => z.iItineraryId == iIternaryId).ToList().Select(model => new ItineraryHouseCargoModel
                {
                    iMasterConsignmentId = model.iMasterConsignmentId ?? 0,
                    iHouseCargoDescId = model.iHouseCargoDescId,
                    dPortOfCallSequenceNo = model.dPortOfCallSequenceNo??0,
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
