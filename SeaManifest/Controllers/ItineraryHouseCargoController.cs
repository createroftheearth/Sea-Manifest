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
    public class ItineraryHouseCargoController : BaseController
    {
        // GET: HouseCargo
        public ActionResult Index(int? iHouseCargoDescId)
        {
            Session["iHouseCargoDescId"] = iHouseCargoDescId;
            HouseCargoService.Instance.Validate(iHouseCargoDescId);
            return View();
        }

        [HttpPost]
        public JsonResult GetItineraryHouseCargo()
        {
            var iHouseCargoDescId = Convert.ToInt32(Session["iHouseCargoDescId"]);
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var search = Request.Form.GetValues("search[value]").FirstOrDefault();
            var start = Convert.ToInt32(Request.Form.GetValues("start").FirstOrDefault());
            var length = Convert.ToInt32(Request.Form.GetValues("length").FirstOrDefault());
            var data = ItineraryHouseCargoService.Instance.GetItineraryHouseHouseCargos(iHouseCargoDescId, search, start, length, out int recordsTotal);
            return Json(new { recordsTotal, recordsFiltered = recordsTotal, data });
        }

        public PartialViewResult AddUpdateItineraryHouseCargo(int? iItenaryHouseCargoId = null )
        {
            var iHouseCargoDescId = Convert.ToInt32(Session["iHouseCargoDescId"]);
            var reportingEvent = HouseCargoService.Instance.GetMessageTypeByHouseCargoDescId(iHouseCargoDescId, out int iMasterConsignmentId);
            if ((iItenaryHouseCargoId ?? 0) == 0)
            {
                return PartialView("pvAddUpdateItineraryHouseCargo", new ItineraryHouseCargoModel
                {
                    iHouseCargoDescId = iHouseCargoDescId,
                    iMasterConsignmentId = iMasterConsignmentId,
                    sReportingEvent = reportingEvent
                });
            }
            else
                return PartialView("pvAddUpdateItineraryHouseCargo", ItineraryHouseCargoService.Instance.GetItineraryHouseHouseCargoByItenaryId(iItenaryHouseCargoId));
        }

        [HttpPost]
        public JsonResult AddUpdateItineraryHouseCargo(ItineraryHouseCargoModel model)
        {
            if (ModelState.IsValid)
            {
                return Json(ItineraryHouseCargoService.Instance.SaveItineraryHouseHouseCargo(model, 1));
            }
            else
            {
                return Json(new { Status = false, Message = string.Join(",", ModelState.Values.SelectMany(z => z.Errors).Select(z => z.ErrorMessage)) });
            }
        }
    }
}