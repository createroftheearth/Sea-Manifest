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
    public class SupportDocMesageImplementationController : BaseController
    {
        // GET: HouseCargo
        public ActionResult Index(int? iMessageImplementationId)
        {
            Session["iMessageImplementationId"] = iMessageImplementationId;
            HouseCargoService.Instance.Validate(iMessageImplementationId);
            return View();
        }

        [HttpPost]
        public JsonResult GetSupportDocMesageImplementation()
        {
            var iMessageImplementationId = Convert.ToInt32(Session["iMessageImplementationId"]);
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var search = Request.Form.GetValues("search[value]").FirstOrDefault();
            var start = Convert.ToInt32(Request.Form.GetValues("start").FirstOrDefault());
            var length = Convert.ToInt32(Request.Form.GetValues("length").FirstOrDefault());
            var data = SupportDocMesageImplementationService.Instance.GetSupportDocMesageImplementation(iMessageImplementationId, search, start, length, out int recordsTotal);
            return Json(new { recordsTotal, recordsFiltered = recordsTotal, data });
        }

        public PartialViewResult AddUpdateSupportDocMesageImplementation(int? iSupportDocsId = null)
        {
            var iMessageImplementationId = Convert.ToInt32(Session["iMessageImplementationId"]);
            var reportingEvent = HouseCargoService.Instance.GetMessageTypeByHouseCargoDescId(iMessageImplementationId, out int iMasterConsignmentId);
            if ((iSupportDocsId ?? 0) == 0)
            {
                return PartialView("pvAddUpdateSupportDocMesageImplementation", new SupportDocMesageImplementationModel
                {
                    iMessageImplementationId = iMessageImplementationId,
                    sReportingEvent = reportingEvent
                });
            }
            else
                return PartialView("pvAddUpdateSupportDocMesageImplementation", SupportDocMesageImplementationService.Instance.GetSupportDocMesageImplementationBySupportDocsId(iSupportDocsId));
        }

        [HttpPost]
        public JsonResult AddUpdateSupportDocMesageImplementation(SupportDocMesageImplementationModel model)
        {
            if (ModelState.IsValid)
            {
                return Json(SupportDocMesageImplementationService.Instance.SaveSupportDocMesageImplementation(model, 1));
            }
            else
            {
                return Json(new { Status = false, Message = string.Join(",", ModelState.Values.SelectMany(z => z.Errors).Select(z => z.ErrorMessage)) });
            }
        }
    }
}