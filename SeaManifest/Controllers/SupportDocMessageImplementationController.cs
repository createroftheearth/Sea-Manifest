using BAL.Models;
using BAL.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeaManifest.Controllers
{
    public class SupportDocMessageImplementationController : BaseController
    {
        // GET: HouseCargo
        public ActionResult Index(int? iMessageImplementationId)
        {
            Session["iMessageImplementationId"] = iMessageImplementationId;
            MessageImplementationService.Instance.Validate(iMessageImplementationId);
            return View();
        }

        [HttpPost]
        public JsonResult GetSupportDocMessageImplementation()
        {
            var iMessageImplementationId = Convert.ToInt32(Session["iMessageImplementationId"]);
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var search = Request.Form.GetValues("search[value]").FirstOrDefault();
            var start = Convert.ToInt32(Request.Form.GetValues("start").FirstOrDefault());
            var length = Convert.ToInt32(Request.Form.GetValues("length").FirstOrDefault());
            var data = SupportDocMessageImplementationService.Instance.GetSupportDocMessageImplementation(iMessageImplementationId, search, start, length, out int recordsTotal);
            return Json(new { recordsTotal, recordsFiltered = recordsTotal, data });
        }

        public PartialViewResult AddUpdateSupportDocMessageImplementation(int? iSupportDocsId = null)
        {
            var iMessageImplementationId = Convert.ToInt32(Session["iMessageImplementationId"]);
            if ((iSupportDocsId ?? 0) == 0)
            {
                return PartialView("pvAddUpdateSupportDocMessageImplementation", new SupportDocMessageImplementationModel
                {
                    iMessageImplementationId = iMessageImplementationId,
                    sReportingEvent = MessageImplementationService.Instance.GetMessageTypeByImplementationId(iMessageImplementationId)
                });
            }
            else
                return PartialView("pvAddUpdateSupportDocMessageImplementation", SupportDocMessageImplementationService.Instance.GetSupportDocMessageImplementationBySupportDocsId(iSupportDocsId));
        }

        [HttpPost]
        public JsonResult AddUpdateSupportDocMessageImplementation(SupportDocMessageImplementationModel model)
        {
            if (ModelState.IsValid)
            {
                return Json(SupportDocMessageImplementationService.Instance.SaveSupportDocMessageImplementation(model, 1));
            }
            else
            {
                return Json(new { Status = false, Message = string.Join(",", ModelState.Values.SelectMany(z => z.Errors).Select(z => z.ErrorMessage)) });
            }
        }
    }
}