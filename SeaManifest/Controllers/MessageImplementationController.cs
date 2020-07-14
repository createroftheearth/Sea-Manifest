using BAL.Models;
using BAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeaManifest.Controllers
{
    public class MessageImplementationController : Controller
    {
        // GET: MessageImplementation
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetHeaders()
        {
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var search = Request.Form.GetValues("search[value]").FirstOrDefault();
            var start = Convert.ToInt32(Request.Form.GetValues("start").FirstOrDefault());
            var length = Convert.ToInt32(Request.Form.GetValues("length").FirstOrDefault());
            var data = MessageImplementationService.Instance.GetHeaders(search, start, length, out int recordsTotal);
            return Json(new { recordsTotal, recordsFiltered = recordsTotal, data });
        }



        public PartialViewResult AddUpdateHeader(int? iHeaderId = null)
        {
            return PartialView("pvAddUpdateHeader");
        }

        [HttpPost]
        public JsonResult AddUpdateHeader(HeaderFieldModel model)
        {
            return Json(new { Status = true, Message = "Saved Successfully" });
        }

    }
}