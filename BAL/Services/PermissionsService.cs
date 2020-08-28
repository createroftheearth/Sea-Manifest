using BAL.Models;
using DAL;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BAL.Services
{
    public class PermissionsService
    {
        private static PermissionsService instance = null;

        private PermissionsService()
        {

        }

        public static PermissionsService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PermissionsService();
                }
                return instance;
            }
        }

        public object GetPermissions(int draw, int displayStart, int displayLength, out int recordsTotal)
        {
            using (var db= new SeaManifestEntities())
            {
                var query = from permission in db.tblPermissionMs
                            join parent in db.tblPermissionMs on permission.iParentId equals parent.iPermissionId
                            into temp
                            from parent in temp.DefaultIfEmpty()
                            select new
                            {
                                permission.iPermissionId,
                                permission.sPermissionName,
                                permission.sPath,
                                parent = parent.sPermissionName,
                                permission.iOrder
                            };
                recordsTotal = query.Count();
                var data = query.OrderBy(z=>z.sPermissionName).Skip(displayStart).Take(displayLength).ToList();
                return data;
            }
        }

        public List<SelectListItem> GetPermissions()
        {
            using (var db= new SeaManifestEntities())
            {
                return db.tblPermissionMs.ToList().Select(z => new SelectListItem
                {
                    Text = z.sPermissionName,
                    Value = z.iPermissionId.ToString()
                }).ToList();
            }
        }

        public PermissionInputModel GetPermissionById(byte iPermissionId)
        {
            using (var db= new SeaManifestEntities())
            {
                return db.tblPermissionMs.Where(x => x.iPermissionId == iPermissionId).Select(z => new PermissionInputModel
                {
                    iPermissionId = z.iPermissionId,
                    sPermissionName = z.sPermissionName,
                    iOrder = z.iOrder??0,
                    iParentId = z.iParentId,
                    sPath = z.sPath
                }).SingleOrDefault();
            }
        }


        public object SavePermission(PermissionInputModel model)
        {
            using (var db= new SeaManifestEntities())
            {
                var data = db.tblPermissionMs.Where(z => z.iPermissionId == model.iPermissionId).SingleOrDefault();
                if (data == null)
                {
                    if (db.tblPermissionMs.Any(z => z.sPermissionName == model.sPermissionName))
                    {
                        return new { Status = false, Message = "Permission already exists" };
                    }
                    else
                    {
                        data = new tblPermissionM
                        {
                            sPermissionName = model.sPermissionName,
                            iParentId = model.iParentId ?? 0,
                            iOrder = model.iOrder,
                            sPath = model.sPath
                        };
                        db.tblPermissionMs.Add(data);
                        db.SaveChanges();
                        return new { Status = true, Message = "Permission saved successfully!" };
                    }
                }
                else
                {
                    if (db.tblPermissionMs.Any(z => z.sPermissionName == model.sPermissionName && z.iPermissionId != model.iPermissionId))
                    {
                        return new { Status = false, Message = "Permission already exists" };
                    }
                    else
                    {
                        data.sPermissionName = model.sPermissionName;
                        data.iParentId = model.iParentId ?? 0;
                        data.iOrder = model.iOrder;
                        data.sPath = model.sPath;
                        db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        return new { Status = true, Message = "Permission saved successfully!" };
                    }
                }
            }
        }

        public List<SelectListItem> GetParents()
        {
            using (var db= new SeaManifestEntities())
            {
                return db.tblPermissionMs.Where(z => z.iParentId == 0).ToList().Select(z => new SelectListItem
                {
                    Text = z.sPermissionName,
                    Value = z.iPermissionId.ToString()
                }).ToList();
            }
        }
    }

}
