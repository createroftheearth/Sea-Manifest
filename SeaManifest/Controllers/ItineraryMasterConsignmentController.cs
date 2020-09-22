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
    public class ItineraryMasterConsignmentController : BaseController
    {
        // GET: MasterConsignment
        public ActionResult Index(int? iMasterConsignmentId)
        {
            Session["iMasterConsignmentId"] = iMasterConsignmentId;
            MasterConsignmentService.Instance.Validate(iMasterConsignmentId);
            return View();
        }

        [HttpPost]
        public JsonResult GetItineraryMasterConsignment()
        {
            var iMasterConsignmentId = Convert.ToInt32(Session["iMasterConsignmentId"]);
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var search = Request.Form.GetValues("search[value]").FirstOrDefault();
            var start = Convert.ToInt32(Request.Form.GetValues("start").FirstOrDefault());
            var length = Convert.ToInt32(Request.Form.GetValues("length").FirstOrDefault());
            var data = ItineraryMasterConsignmentService.Instance.GetItineraryHouseMasterConsignments(iMasterConsignmentId, search, start, length, out int recordsTotal);
            return Json(new { recordsTotal, recordsFiltered = recordsTotal, data });
        }

        public PartialViewResult AddUpdateItineraryMasterConsignment(int? iItenaryMasterConsignmentId = null)
        {
            var iMasterConsignmentId = Convert.ToInt32(Session["iMasterConsignmentId"]);
            var reportingEvent = MasterConsignmentService.Instance.GetMessageTypeByMasterConsignmentId(iMasterConsignmentId, out int iMessageImplementationId);
            if ((iItenaryMasterConsignmentId ?? 0) == 0)
            {
                return PartialView("pvAddUpdateItineraryMasterConsignment", new ItineraryMasterConsignmentModel
                {
                    iMasterConsignmentId = iMasterConsignmentId,
                    iMessageImplementationId = iMessageImplementationId,
                    sReportingEvent = reportingEvent
                });
            }
            else
                return PartialView("pvAddUpdateItineraryMasterConsignment", ItineraryMasterConsignmentService.Instance.GetItineraryHouseMasterConsignmentByItenaryId(iItenaryMasterConsignmentId));
        }

        [HttpPost]
        public JsonResult AddUpdateItineraryMasterConsignment(ItineraryMasterConsignmentModel model)
        {
            string Messages = string.Empty;

            if (ModelState.IsValid && ItineraryMasterConsignmentService.Instance.ValidateItinerary(model, out Messages))
            {
                return Json(ItineraryMasterConsignmentService.Instance.SaveItineraryHouseMasterConsignment(model, GetUserInfo().iUserId));
            }
            else
            {
                return Json(new { Status = false, Message = string.Join(",", ModelState.Values.SelectMany(z => z.Errors).Select(z => z.ErrorMessage)) + Messages });
            }
        }
    }
}