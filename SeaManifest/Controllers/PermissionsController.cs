using System;
using System.Linq;
using System.Web.Mvc;
using BAL.Models;
using BAL.Services;

namespace SeaManifest.Controllers
{
    public class PermissionsController : BaseController
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetPermissions()
        {
            int draw = Convert.ToInt32(Request.Form["draw"]);
            int DisplayStart = Convert.ToInt32(Request.Form["start"]);
            int DisplayLength = Convert.ToInt32(Request.Form["length"]);
            var data = PermissionsService.Instance.GetPermissions(draw, DisplayStart, DisplayLength, out int recordsTotal);
            return Json(new { draw, recordsFiltered = recordsTotal, recordsTotal, data }); ;
        }

        public PartialViewResult AddUpdatePermission(byte iPermissionId = 0)
        {
            if (iPermissionId != 0)
            {
                var model = PermissionsService.Instance.GetPermissionById(iPermissionId);
                return PartialView("pvAddUpdatePermission", model);
            }
            return PartialView("pvAddUpdatePermission");
        }

        [HttpPost]
        public JsonResult AddUpdatePermission(PermissionInputModel model)
        {
            if (ModelState.IsValid)
            {
                return Json(PermissionsService.Instance.SavePermission(model));
            }
            else
                return Json(new { Status = false, Message = string.Join(",", ModelState.Values.SelectMany(z => z.Errors).Select(z => z.ErrorMessage)) });
        }

    }
}
