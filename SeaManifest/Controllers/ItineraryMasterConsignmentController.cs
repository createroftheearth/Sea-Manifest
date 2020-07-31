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
    public class ItineraryMasterConsignmentController : Controller
    {
        // GET: HouseCargo
        public ActionResult Index(int? iMasterConsignmentId)
        {
            Session["iMasterConsignmentId"] = iMasterConsignmentId;
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
            var data = ItineraryMasterConsignmentService.Instance.GetItineraryMasterConsignment(iMasterConsignmentId, search, start, length, out int recordsTotal);
            return Json(new { recordsTotal, recordsFiltered = recordsTotal, data });
        }

        public PartialViewResult AddUpdateItineraryMasterConsignment(int? iMasterConsignmentId = null,int? iIternaryMasterConsignmentId = null )
        {
            if (iIternaryMasterConsignmentId == null && iMasterConsignmentId == null)
            {
                return PartialView("pvAddUpdateItineraryMasterConsignment");
            }
            else
                return PartialView("pvAddUpdateItineraryMasterConsignment", ItineraryMasterConsignmentService.Instance.GetItineraryMasterConsignmentByItenaryId(iMasterConsignmentId, iIternaryMasterConsignmentId));
        }

        [HttpPost]
        public JsonResult AddUpdateItineraryMasterConsignment(ItineraryMasterConsignmentModel model)
        {
            if (ModelState.IsValid)
            {
                return Json(ItineraryMasterConsignmentService.Instance.SaveItineraryMasterConsignment(model, 1));
            }
            else
            {
                return Json(new { Status = false, Message = string.Join(",", ModelState.Values.SelectMany(z => z.Errors).Select(z => z.ErrorMessage)) });
            }
        }
    }
}