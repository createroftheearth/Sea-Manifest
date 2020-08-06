
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
    public class AdditionalDetailsMasterConsignmentController : BaseController
    {
        // GET: MasterConsignment
        public ActionResult Index(int? iMasterConsignmentId)
        {
            Session["iMasterConsignmentId"] = iMasterConsignmentId;
            MasterConsignmentService.Instance.Validate(iMasterConsignmentId);
            return View();
        }

        [HttpPost]
        public JsonResult GetAdditionalDetailsMasterConsignment()
        {
            var iMasterConsignmentId = Convert.ToInt32(Session["iMasterConsignmentId"]);
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var search = Request.Form.GetValues("search[value]").FirstOrDefault();
            var start = Convert.ToInt32(Request.Form.GetValues("start").FirstOrDefault());
            var length = Convert.ToInt32(Request.Form.GetValues("length").FirstOrDefault());
            var data = AdditionalDetailsMasterConsignmentService.Instance.GetAdditionalDetailsMasterConsignment(iMasterConsignmentId, search, start, length, out int recordsTotal);
            return Json(new { recordsTotal, recordsFiltered = recordsTotal, data });
        }

        public PartialViewResult AddUpdateAdditionalDetailsMasterConsignment(int? iAdditionalDetailsId = null)
        {
            if ((iAdditionalDetailsId ?? 0) == 0)
            {
                var iMasterConsignmentId = Convert.ToInt32(Session["iMasterConsignmentId"]);
                var reportingEvent = MasterConsignmentService.Instance.GetMessageTypeByMasterConsignmentId(iMasterConsignmentId, out int iMessageImplementationId);
                return PartialView("pvAddUpdateAdditionalDetailsMasterConsignment", new AdditionalDetailsMasterConsignmentModel
                {
                    iMasterConsignmentId = iMasterConsignmentId,
                    iMessageImplementationId = iMessageImplementationId
                });
            }
            else
                return PartialView("pvAddUpdateAdditionalDetailsMasterConsignment", AdditionalDetailsMasterConsignmentService.Instance.GetAdditionalDetailsMasterConsignmentByAddDetailsId(iAdditionalDetailsId));
        }

        [HttpPost]
        public JsonResult AddUpdateAdditionalDetailsMasterConsignment(AdditionalDetailsMasterConsignmentModel model)
        {
            if (ModelState.IsValid)
            {
                return Json(AdditionalDetailsMasterConsignmentService.Instance.SaveAdditionalDetailsMasterConsignment(model, 1));
            }
            else
            {
                return Json(new { Status = false, Message = string.Join(",", ModelState.Values.SelectMany(z => z.Errors).Select(z => z.ErrorMessage)) });
            }
        }
    }
}