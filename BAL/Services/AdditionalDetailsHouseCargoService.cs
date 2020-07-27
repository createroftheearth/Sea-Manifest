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
    public class AdditionalDetailsHouseCargoService
    {
        private AdditionalDetailsHouseCargoService()
        {
        }

        private static AdditionalDetailsHouseCargoService _instance;

        public static AdditionalDetailsHouseCargoService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AdditionalDetailsHouseCargoService();
                return _instance;
            }
        }

        //save AdditionalDetailsHouseCargo 
        public object SaveAdditionalDetailsHouseCargo(AdditionalDetailsHouseCargoModel model, int iUserId)
        {
            try
            {
                using (var db = new SeaManifestEntities())
                {
                    var data = db.tblAdditionalDetailsHouseCargoMaps.Where(z => z.iAdditionalDetailsId == model.iAdditionalDetailsId).SingleOrDefault();
                    if (data != null)
                    {
                        data.iMasterConsignmentId = model.iMasterConsignmentId ?? 0;
                        data.iHouseCargoDescId = model.iHouseCargoDescId;
                        data.sTagRef = model.sTagRef;
                        data.sRefSerialNo = model.sRefSerialNo;
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
                        data = new tblAdditionalDetailsHouseCargoMap
                        {
                            iMasterConsignmentId = model.iMasterConsignmentId ?? 0,
                            iHouseCargoDescId = model.iHouseCargoDescId,
                            sTagRef = model.sTagRef,
                            sRefSerialNo = model.sRefSerialNo,
                            sInfoType = model.sInfoType,
                            sInfoQualifier = model.sInfoQualifier,
                            sInfoCd = model.sInfoCd,
                            sInfoText = model.sInfoText,
                            sInfoMsr = model.sInfoMsr,
                            dtInfoDate = model.sInfoDate.ToDate(),
                            iActionBy = iUserId,
                            dtActionDate = DateTime.Now,
                        };
                        db.tblAdditionalDetailsHouseCargoMaps.Add(data);
                        db.SaveChanges();
                    }
                    return new { Status = true, Message = "AdditionalDetailsHouseCargo saved successfully!" };
                }

            }
            catch (Exception)
            {
                return new { Status = false, Message = "Something went wrong" };
            }
        }

        public object GetAdditionalDetailsHouseCargo(int iHouseCargoDescId, string search, int start, int length, out int recordsTotal)
        {
            using (var db = new SeaManifestEntities())
            {
                var query = from t in db.tblAdditionalDetailsHouseCargoMaps
                            where t.sInfoMsr.Contains(search) && t.iHouseCargoDescId == iHouseCargoDescId
                            select t;
                recordsTotal = query.Count();
                return query.OrderBy(z => z.sInfoCd).Take(length).Skip(start).ToList().Select(t => new
                {
                    t.iHouseCargoDescId,
                    t.iMasterConsignmentId,
                    t.sInfoQualifier,
                    t.sInfoMsr,
                   // t.iItemsDetailsId
                    //masterBillDate = t.dtHCRefBillDate?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                }).ToList();
            }
        }

        public AdditionalDetailsHouseCargoModel GetAdditionalDetailsHouseCargoByAddDetailsId(int? iAdditionalDetailsId)
        {
            using (var db = new SeaManifestEntities())
            {
                return db.tblAdditionalDetailsHouseCargoMaps.Where(z => z.iAdditionalDetailsId == iAdditionalDetailsId).ToList().Select(model => new AdditionalDetailsHouseCargoModel
                {
                    iMasterConsignmentId = model.iMasterConsignmentId ?? 0,
                    iHouseCargoDescId = model.iHouseCargoDescId,
                    sTagRef = model.sTagRef,
                    sRefSerialNo = model.sRefSerialNo,
                    sInfoType = model.sInfoType,
                    sInfoQualifier = model.sInfoQualifier,
                    sInfoCd = model.sInfoCd,
                    sInfoText = model.sInfoText,
                    sInfoMsr = model.sInfoMsr,
                    sInfoDate = model.dtInfoDate.ToDateString(),
                }).SingleOrDefault();
            }
        }
    }
}
