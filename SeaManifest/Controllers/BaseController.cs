using BAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SeaManifest.Controllers
{
    public class BaseController : Controller
    {

        // GET: Base
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Shared/Error.cshtml",
                ViewBag = { ExceptionMessage = filterContext.Exception.Message }
            };
        }

        protected override void OnActionExecuting(ActionExecutingContext context)
        {
            var data = context.HttpContext.Session["UserInfo"] as UserModel;
            if (data == null)
            {
                context.Result = new RedirectToRouteResult(
                  new RouteValueDictionary
                  {
                    { "controller", "Login" },
                    { "action", "Index" }
                  });
                return;
            }
            var userRights = context.HttpContext.Session["UserRights"] as RolePermissionModel;
            var url = context.HttpContext.Request.Path.Split('/')[1].ToLower();
            var paths = userRights.lstPermissionModel.Where(z => z.sPath != "#").Select(z => z.sPath).ToList();
            paths.AddRange(userRights.lstPermissionModel.SelectMany(z => z.childs).Where(z => z.sPath != "#").Select(z => z.sPath).ToList());
            paths = paths.Select(z => z.Split('/')[1].ToLower()).ToList();
            if (!paths.Any(z => z == url))
            {
                context.Result = new RedirectToRouteResult(
                new RouteValueDictionary
                {
                    { "controller", "Login" },
                    { "action", "Index" }
                });
            }
            base.OnActionExecuting(context);
        }

        public UserModel GetUserInfo()
        {
            if (Session["UserInfo"] == null)
                return null;
            else
                return Session["UserInfo"] as UserModel;
        }
    }
}