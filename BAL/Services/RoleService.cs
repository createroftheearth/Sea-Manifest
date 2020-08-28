using BAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BAL.Services
{
    public class RoleService
    {
        private static RoleService instance = null;

        private RoleService()
        {

        }

        public static RoleService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RoleService();
                }
                return instance;
            }
        }

        public List<RoleModel> GetRoles(int draw, int displayStart, int displayLength, out int recordsTotal)
        {
            using (var db = new SeaManifestEntities())
            {
                var data = db.tblRoleMs.OrderBy(z => z.sRoleName).Skip(displayStart).Take(displayLength).Select(z => new RoleModel
                {
                    iRoleId = z.iRoleId,
                    sRolename = z.sRoleName,
                }).ToList();
                recordsTotal = db.tblRoleMs.Count();
                return data;
            }
        }

        public List<SelectListItem> GetRoles()
        {
            using (var db = new SeaManifestEntities())
            {
                return db.tblRoleMs.ToList().Select(z => new SelectListItem
                {
                    Text = z.sRoleName,
                    Value = z.iRoleId.ToString()
                }).ToList();
            }
        }

        public RoleModel GetRoleById(byte iRoleId)
        {
            using (var db = new SeaManifestEntities())
            {
                return db.tblRoleMs.Where(x => x.iRoleId == iRoleId).Select(z => new RoleModel
                {
                    iRoleId = z.iRoleId,
                    sRolename = z.sRoleName,
                }).SingleOrDefault();
            }
        }

        public async Task<object> AddUpdateRolePermissions(RolePermissionModel model)
        {
            try
            {
                using (var db = new SeaManifestEntities())
                {
                    var roles = model.lstPermissionModel.Where(z => z.isChecked).Select(z => z.iPermissionId).ToList();
                    roles.AddRange(model.lstPermissionModel.SelectMany(z => z.childs).Where(z => z.isChecked).Select(z => z.iPermissionId).ToList());
                    db.tblRolePermissionsMs.RemoveRange(
                              from t in db.tblRolePermissionsMs.Where(z => z.iRoleId == model.iRoleId).ToList()
                              join s in roles on t.iPermissionId equals s
                              into temp
                              from s in temp.DefaultIfEmpty()
                              where s == 0
                              select t
                              );
                    await db.SaveChangesAsync();
                    db.tblRolePermissionsMs.AddRange((from t in roles
                                                      join s in db.tblRolePermissionsMs.Where(z => z.iRoleId == model.iRoleId).ToList() on t equals s.iPermissionId
                                                      into temp
                                                      from s in temp.DefaultIfEmpty()
                                                      where s == null
                                                      select new tblRolePermissionsM
                                                      {
                                                          iRoleId = model.iRoleId,
                                                          iPermissionId = t
                                                      }).ToList());
                    await db.SaveChangesAsync();
                }
                return new { Status = true, Message = "Role permission saved successfully." };
            }
            catch (Exception)
            {
                return new { Status = false, Message = "Something went wrong" };
            }
        }

        public async Task<RolePermissionModel> GetRolePermissions(byte iRoleId)
        {
            using (var db = new SeaManifestEntities())
            {
                var rolePermissions = await db.tblRolePermissionsMs.Where(z => z.iRoleId == iRoleId).Select(z => z.iPermissionId).ToListAsync();
                return new RolePermissionModel
                {
                    lstPermissionModel = (await db.tblPermissionMs.Where(z => z.iParentId == 0).OrderBy(z => z.iOrder).ToListAsync()).Select(z => new PermissionModel
                    {
                        iPermissionId = z.iPermissionId,
                        sPermissionName = z.sPermissionName,
                        isChecked = rolePermissions.Contains(z.iPermissionId),
                        sPath = z.sPath,
                        childs = db.tblPermissionMs.Where(zx => zx.iParentId == z.iPermissionId).OrderBy(xz => xz.iOrder).ToList().Select(c => new PermissionModel
                        {
                            iPermissionId = c.iPermissionId,
                            sPath = c.sPath,
                            sPermissionName = c.sPermissionName,
                            isChecked = rolePermissions.Contains(c.iPermissionId),
                        }).ToList(),
                    }).ToList(),
                    iRoleId = iRoleId
                };
            }
        }

        public async Task<RolePermissionModel> GetAuthorizedRolePermissions(byte iRoleId)
        {
            using (var db = new SeaManifestEntities())
            {
                return new RolePermissionModel
                {
                    lstPermissionModel = (await db.tblRolePermissionsMs.Where(z => z.tblPermissionM.iParentId == 0 && z.iRoleId == iRoleId).OrderBy(z => z.tblPermissionM.iOrder).ToListAsync()).Select(z => new PermissionModel
                    {
                        iPermissionId = z.tblPermissionM.iPermissionId,
                        sPermissionName = z.tblPermissionM.sPermissionName,
                        sPath = z.tblPermissionM.sPath,
                        childs = db.tblRolePermissionsMs.Where(zx => zx.tblPermissionM.iParentId == z.iPermissionId && zx.iRoleId == iRoleId).OrderBy(xz => xz.tblPermissionM.iOrder).ToList().Select(c => new PermissionModel
                        {
                            iPermissionId = c.tblPermissionM.iPermissionId,
                            sPermissionName = c.tblPermissionM.sPermissionName,
                            sPath = c.tblPermissionM.sPath,
                        }).ToList(),
                    }).ToList(),
                    iRoleId = iRoleId
                };
            }
        }


        public object SaveRole(RoleModel model)
        {
            using (var db = new SeaManifestEntities())
            {
                var data = db.tblRoleMs.Where(z => z.iRoleId == model.iRoleId).SingleOrDefault();
                if (data == null)
                {
                    if (db.tblRoleMs.Any(z => z.sRoleName == model.sRolename))
                    {
                        return new { Status = false, Message = "Role already exists" };
                    }
                    else
                    {
                        data = new tblRoleM
                        {
                            iRoleId = model.iRoleId,
                            sRoleName = model.sRolename,
                        };
                        db.tblRoleMs.Add(data);
                        db.SaveChanges();
                        return new { Status = true, Message = "Role saved successfully!" };
                    }
                }
                else
                {
                    if (db.tblRoleMs.Any(z => z.sRoleName == model.sRolename && z.iRoleId != model.iRoleId))
                    {
                        return new { Status = false, Message = "Role already exists" };
                    }
                    else
                    {
                        data.iRoleId = model.iRoleId;
                        data.sRoleName = model.sRolename;
                        db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        return new { Status = true, Message = "Role saved successfully!" };
                    }
                }
            }
        }


    }

}
