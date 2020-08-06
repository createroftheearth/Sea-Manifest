
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
    public class AdditionalDetailsMessageImplementationController : BaseController
    {
        // GET: MessageImplementation
        public ActionResult Index(int? iMessageImplementationId)
        {
            Session["iMessageImplementationId"] = iMessageImplementationId;
            MessageImplementationService.Instance.Validate(iMessageImplementationId);
            return View();
        }

        [HttpPost]
        public JsonResult GetAdditionalDetailsMessageImplementation()
        {
            var iMessageImplementationId = Convert.ToInt32(Session["iMessageImplementationId"]);
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var search = Request.Form.GetValues("search[value]").FirstOrDefault();
            var start = Convert.ToInt32(Request.Form.GetValues("start").FirstOrDefault());
            var length = Convert.ToInt32(Request.Form.GetValues("length").FirstOrDefault());
            var data = AdditionalDetailsMessageImplementationService.Instance.GetAdditionalDetailsMessageImplementation(iMessageImplementationId, search, start, length, out int recordsTotal);
            return Json(new { recordsTotal, recordsFiltered = recordsTotal, data });
        }

        public PartialViewResult AddUpdateAdditionalDetailsMessageImplementation(int? iAdditionalDetailsId = null )
        {
            if ((iAdditionalDetailsId ?? 0) == 0)
            {
                var iMessageImplementationId = Convert.ToInt32(Session["iMessageImplementationId"]);
                return PartialView("pvAddUpdateAdditionalDetailsMessageImplementation", new AdditionalDetailsMessageImplementationModel
                {
                    iMessageImplementationId = iMessageImplementationId
                });
            }
            else
                return PartialView("pvAddUpdateAdditionalDetailsMessageImplementation", AdditionalDetailsMessageImplementationService.Instance.GetAdditionalDetailsMessageImplementationByAddDetailsId(iAdditionalDetailsId));
        }

        [HttpPost]
        public JsonResult AddUpdateAdditionalDetailsMessageImplementation(AdditionalDetailsMessageImplementationModel model)
        {
            if (ModelState.IsValid)
            {
                return Json(AdditionalDetailsMessageImplementationService.Instance.SaveAdditionalDetailsMessageImplementation(model, 1));
            }
            else
            {
                return Json(new { Status = false, Message = string.Join(",", ModelState.Values.SelectMany(z => z.Errors).Select(z => z.ErrorMessage)) });
            }
        }
    }
}