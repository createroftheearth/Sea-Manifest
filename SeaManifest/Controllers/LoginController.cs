using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using BAL.Models;
using BAL.Services;

namespace SeaManifest.Controllers
{

    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(LoginModel model, string returnUrl)
        {
            try
            {
                if (LoginService.Instance.ValidateUsername(model.Username))
                {
                    var data = LoginService.Instance.ValidateUser(model);
                    if (data == null)
                    {
                        ModelState.AddModelError("Password", "Invalid Password");
                    }
                    else
                    {
                        var userRoles = await RoleService.Instance.GetAuthorizedRolePermissions(data.iRoleId);
                        Session["UserInfo"] = data;
                        Session["UserRights"] = userRoles;
                        if (string.IsNullOrEmpty(returnUrl))
                            return Redirect("/MessageImplementation/Index");
                        else
                            return Redirect(returnUrl);
                    }
                }
                else
                {
                    ModelState.AddModelError("Username", "Invalid Username");
                }
            }
            catch (Exception)
            {
                throw;
            }
            return View();
        }


        public ActionResult Logout()
        {
            HttpContext.Session.Remove("UserInfo");
            return RedirectToAction("index");
        }
    }
}
