using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using BAL.Models;
using DAL;

namespace BAL.Services
{
    public class PortService
    {
        private PortService()
        {
        }

        private static PortService _instance;

        public static PortService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new PortService();
                return _instance;
            }
        }

        //save Port 
        public object SavePort(PortModel model, int iUserId)
        {
            try
            {
                using (var db = new SeaManifestEntities())
                {
                    if(db.tblPortMs.Any(z=>z.iPortId!=model.iPortId && z.sPortCode == model.sPortCode))
                    {
                        return new { Status = false, Message = "Port Code already exists." };
                    }
                    var data = db.tblPortMs.Where(z => z.iPortId == model.iPortId).SingleOrDefault();
                    if (data != null)
                    {

                        data.sPortCode = model.sPortCode;
                        data.sPortDescription = model.sPortDescription;
                        data.sCountryCode = model.sCountryCode;
                        data.SstateCode = model.SstateCode;
                        db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        data = new tblPortM
                        {

                            sPortCode = model.sPortCode,
                            sPortDescription = model.sPortDescription,
                            sCountryCode = model.sCountryCode,
                            SstateCode = model.SstateCode,
                        };
                        db.tblPortMs.Add(data);
                        db.SaveChanges();
                    }
                    return new { Status = true, Message = "Port saved successfully!" };
                }

            }
            catch (Exception)
            {
                return new { Status = false, Message = "Something went wrong" };
            }
        }

        public object GetPort(string search, int start, int length, out int recordsTotal)
        {
            using (var db = new SeaManifestEntities())
            {
                var query = from t in db.tblPortMs
                            join C in db.tblCountryMs on t.sCountryCode equals C.sCountryCode
                            join S in db.tblCodeMs.Where(Z=>Z.tblCodeTypeM.sCodeType == "State_Code") on t.SstateCode equals S.sCode into tp
                            from S in tp.DefaultIfEmpty()
                            where (t.sPortCode.Contains(search)
                            || t.sPortDescription.Contains(search)
                            || C.sCountryName.Contains(search)
                            || S.sCodeName.Contains(search)
                            )
                            select new { t,S.sCodeName,C.sCountryName};
                recordsTotal = query.Count();
                return query.OrderBy(z => z.t.sPortCode).Skip(start).Take(length).ToList().Select(z => new
                {
                    z.t.sPortCode,
                    z.t.sPortDescription,
                    z.sCountryName,
                    sStateName = z.sCodeName,
                    z.t.iPortId
                }).ToList();
            }
        }

        public PortModel GetPortByPortId(int? iPortId)
        {
            using (var db = new SeaManifestEntities())
            {
                return db.tblPortMs.Where(z => z.iPortId == iPortId).ToList().Select(model => new PortModel
                {
                    sPortCode = model.sPortCode,
                    sPortDescription = model.sPortDescription,
                    sCountryCode = model.sCountryCode,
                    SstateCode = model.SstateCode,
                }).SingleOrDefault();
            }
        }
    }
}
