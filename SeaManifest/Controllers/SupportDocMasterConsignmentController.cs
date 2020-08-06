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
    public class SupportDocMasterConsignmentController : BaseController
    {
        // GET: MasterConsignment
        public ActionResult Index(int? iMasterConsignmentId)
        {
            Session["iMasterConsignmentId"] = iMasterConsignmentId;
            MasterConsignmentService.Instance.Validate(iMasterConsignmentId);
            return View();
        }

        [HttpPost]
        public JsonResult GetSupportDocMasterConsignment()
        {
            var iMasterConsignmentId = Convert.ToInt32(Session["iMasterConsignmentId"]);
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var search = Request.Form.GetValues("search[value]").FirstOrDefault();
            var start = Convert.ToInt32(Request.Form.GetValues("start").FirstOrDefault());
            var length = Convert.ToInt32(Request.Form.GetValues("length").FirstOrDefault());
            var data = SupportDocMasterConsignmentService.Instance.GetSupportDocMasterConsignment(iMasterConsignmentId, search, start, length, out int recordsTotal);
            return Json(new { recordsTotal, recordsFiltered = recordsTotal, data });
        }

        public PartialViewResult AddUpdateSupportDocMasterConsignment(int? iSupportDocsId = null)
        {
            var iMasterConsignmentId = Convert.ToInt32(Session["iMasterConsignmentId"]);
            var reportingEvent = MasterConsignmentService.Instance.GetMessageTypeByMasterConsignmentId(iMasterConsignmentId, out int iMessageImplementationId);
            if ((iSupportDocsId ?? 0) == 0)
            {
                return PartialView("pvAddUpdateSupportDocMasterConsignment", new SupportDocMasterConsignmentModel
                {
                    iMasterConsignmentId = iMasterConsignmentId,
                    iMessageImplementationId=iMessageImplementationId,
                    sReportingEvent = reportingEvent
                });
            }
            else
                return PartialView("pvAddUpdateSupportDocMasterConsignment", SupportDocMasterConsignmentService.Instance.GetSupportDocMasterConsignmentBySupportDocsId(iSupportDocsId));
        }

        [HttpPost]
        public JsonResult AddUpdateSupportDocMasterConsignment(SupportDocMasterConsignmentModel model)
        {
            if (ModelState.IsValid)
            {
                return Json(SupportDocMasterConsignmentService.Instance.SaveSupportDocMasterConsignment(model, 1));
            }
            else
            {
                return Json(new { Status = false, Message = string.Join(",", ModelState.Values.SelectMany(z => z.Errors).Select(z => z.ErrorMessage)) });
            }
        }
    }
}