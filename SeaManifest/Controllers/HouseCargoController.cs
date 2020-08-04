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
    public class HouseCargoController : BaseController
    {
        // GET: HouseCargo
        public ActionResult Index(int? iMasterConsignmentId)
        {
            Session["iMasterConsignmentId"] = iMasterConsignmentId;
            MasterConsignmentService.Instance.Validate(iMasterConsignmentId);
            return View();
        }

        [HttpPost]
        public JsonResult GetHouseCargos()
        {
            var iMasterConsignmentId = Convert.ToInt32(Session["iMasterConsignmentId"]);
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var search = Request.Form.GetValues("search[value]").FirstOrDefault();
            var start = Convert.ToInt32(Request.Form.GetValues("start").FirstOrDefault());
            var length = Convert.ToInt32(Request.Form.GetValues("length").FirstOrDefault());
            var data = HouseCargoService.Instance.GetHouseCargos(iMasterConsignmentId, search, start, length, out int recordsTotal);
            return Json(new { recordsTotal, recordsFiltered = recordsTotal, data });
        }

        public PartialViewResult AddUpdateHouseCargo(int? iHouseCargoDescId = null)
        {
            if (iHouseCargoDescId == null)
            {
                int iMasterConsignmentId = Convert.ToInt32(Session["MasterConsignmentId"]);
                return PartialView("pvAddUpdateHouseCargo", new HouseCargoModel
                {
                    iMasterConsignmentId = iMasterConsignmentId,
                    sReportingEvent = MasterConsignmentService.Instance.GetMessageTypeByMasterConsignmentId(iMasterConsignmentId)
                });
            }
            else
                return PartialView("pvAddUpdateHouseCargo", HouseCargoService.Instance.GetHouseCargoHouseCargoDescId(iHouseCargoDescId));
        }

        [HttpPost]
        public JsonResult AddUpdateHouseCargo(HouseCargoModel model)
        {
            string Messages = string.Empty;
            if (ModelState.IsValid && HouseCargoService.Instance.ValidateHouseCargo(model, out Messages))
            {
                return Json(HouseCargoService.Instance.SaveHouseCargo(model, 1));
            }
            else
            {
                return Json(new { Status = false, Message = string.Join(",", ModelState.Values.SelectMany(z => z.Errors).Select(z => z.ErrorMessage)) + ", " + Messages });
            }
        }
    }
}