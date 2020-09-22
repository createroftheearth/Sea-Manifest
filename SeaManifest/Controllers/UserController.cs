using System;
using System.Linq;
using System.Web.Mvc;
using BAL.Models;
using BAL.Services;
using BAL.Utilities;
namespace SeaManifest.Controllers
{
    public class UserController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetUsers()
        {
            int draw = Convert.ToInt32(Request.Form["draw"]);
            int DisplayStart = Convert.ToInt32(Request.Form["start"]);
            int DisplayLength = Convert.ToInt32(Request.Form["length"]);
            var data = UserService.Instance.GetUsers(draw, DisplayStart, DisplayLength, out int recordsTotal);
            return Json(new { draw, recordsFiltered = recordsTotal, recordsTotal, data }); ;
        }

        public PartialViewResult AddUpdateUser(int iUserId = 0)
        {
            ViewBag.Roles = UserService.Instance.GetRoles();
            if (iUserId != 0)
            {
                var model = UserService.Instance.GetUserById(iUserId);
                model.sPassword = Crypto.Decrypt(model.sPassword);
                return PartialView("pvAddUpdateUser", model);
            }
            return PartialView("pvAddUpdateUser");
        }

        [HttpPost]
        public JsonResult AddUpdateUser(UserModel model)
        {
            if (ModelState.IsValid)
            {
                return Json(UserService.Instance.SaveUser(model, GetUserInfo().iUserId));
            }
            else
                return Json(new { Status = false, Message = string.Join(",", ModelState.Values.SelectMany(z => z.Errors).Select(z => z.ErrorMessage)) });
        }
    }
}
