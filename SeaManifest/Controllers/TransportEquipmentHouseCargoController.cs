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
    public class TransportEquipmentHouseCargoController : Controller
    {
        // GET: HouseCargo
        public ActionResult Index(int? iHouseCargoDescId)
        {
            Session["iHouseCargoDescId"] = iHouseCargoDescId;
            return View();
        }

        [HttpPost]
        public JsonResult GetTransportEquipmentHouseCargo()
        {
            var iHouseCargoDescId = Convert.ToInt32(Session["iHouseCargoDescId"]);
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var search = Request.Form.GetValues("search[value]").FirstOrDefault();
            var start = Convert.ToInt32(Request.Form.GetValues("start").FirstOrDefault());
            var length = Convert.ToInt32(Request.Form.GetValues("length").FirstOrDefault());
            var data = TransportEquipmentHouseCargoService.Instance.GetTransportEquipmentHouseCargo(iHouseCargoDescId, search, start, length, out int recordsTotal);
            return Json(new { recordsTotal, recordsFiltered = recordsTotal, data });
        }

        public PartialViewResult AddUpdateTransportEquipmentHouseCargo(int? iHouseCargoDescId = null,int? iTransporterEquipmentId = null )
        {
            if (iTransporterEquipmentId == null && iHouseCargoDescId == null)
            {
                return PartialView("pvAddUpdateTransportEquipmentHouseCargo");
            }
            else
                return PartialView("pvAddUpdateTransportEquipmentHouseCargo", TransportEquipmentHouseCargoService.Instance.GetTransportEquipmentHouseCargoByTransporterEquipmentId(iHouseCargoDescId, iTransporterEquipmentId));
        }

        [HttpPost]
        public JsonResult AddUpdateTransportEquipmentHouseCargo(TransportEquipmentHouseCargoModel model)
        {
            if (ModelState.IsValid)
            {
                return Json(TransportEquipmentHouseCargoService.Instance.SaveTransportEquipmentHouseCargo(model, 1));
            }
            else
            {
                return Json(new { Status = false, Message = string.Join(",", ModelState.Values.SelectMany(z => z.Errors).Select(z => z.ErrorMessage)) });
            }
        }
    }
}