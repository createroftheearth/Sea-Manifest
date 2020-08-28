using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using BAL.Models;
using BAL.Services;
namespace SeaManifest.Controllers
{
    public class RoleController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetRoles()
        {
            int draw = Convert.ToInt32(Request.Form["draw"]);
            int DisplayStart = Convert.ToInt32(Request.Form["start"]);
            int DisplayLength = Convert.ToInt32(Request.Form["length"]);
            var data = RoleService.Instance.GetRoles(draw, DisplayStart, DisplayLength, out int recordsTotal);
            return Json(new { draw, recordsFiltered = recordsTotal, recordsTotal, data }); ;
        }

        public PartialViewResult AddUpdateRole(byte iRoleId = 0)
        {
            if (iRoleId != 0)
            {
                var model = RoleService.Instance.GetRoleById(iRoleId);
                return PartialView("pvAddUpdateRole", model);
            }
            return PartialView("pvAddUpdateRole");
        }

        [HttpPost]
        public JsonResult AddUpdateRole(RoleModel model)
        {
            if (ModelState.IsValid)
            {
                return Json(RoleService.Instance.SaveRole(model));
            }
            else
                return Json(new { Status = false, Message = string.Join(",", ModelState.Values.SelectMany(z => z.Errors).Select(z => z.ErrorMessage)) });
        }

        public async Task<PartialViewResult> AddUpdateRolePermissions(byte iRoleId)
        {
            return PartialView("pvAddUpdateRolePermissions", await RoleService.Instance.GetRolePermissions(iRoleId));
        }
        [HttpPost]
        public async Task<JsonResult> AddUpdateRolePermissions(RolePermissionModel model)
        {
            return Json(await RoleService.Instance.AddUpdateRolePermissions(model));
        }
    }

}
