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
    public class ItemDetailsHouseCargoController : BaseController
    {
        // GET: HouseCargo
        public ActionResult Index(int? iHouseCargoDescId)
        {
            Session["iHouseCargoDescId"] = iHouseCargoDescId;
            HouseCargoService.Instance.Validate(iHouseCargoDescId);

            return View();
        }

        [HttpPost]
        public JsonResult GetItemDetailsHouseCargo()
        {
            var iMasterConsignmentId = Convert.ToInt32(Session["iMasterConsignmentId"]);
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var search = Request.Form.GetValues("search[value]").FirstOrDefault();
            var start = Convert.ToInt32(Request.Form.GetValues("start").FirstOrDefault());
            var length = Convert.ToInt32(Request.Form.GetValues("length").FirstOrDefault());
            var data = ItemDetailsHouseCargoService.Instance.GetItemDetailsHouseCargos(iMasterConsignmentId, search, start, length, out int recordsTotal);
            return Json(new { recordsTotal, recordsFiltered = recordsTotal, data });
        }

        public PartialViewResult AddUpdateItemDetailsHouseCargo(int? iItemDetailsId)
        {
            if (iItemDetailsId == null)
            {
                int iHouseCargoDescId = Convert.ToInt32(Session["iHouseCargoDescId"]);
                return PartialView("pvAddUpdateItemDetailsHouseCargo", new ItemDetailsHouseCargoModel
                {
                    iHouseCargoDescId = iHouseCargoDescId,
                    sReportingEvent = HouseCargoService.Instance.GetMessageTypeByHouseCargoDescId(iHouseCargoDescId)
                });
            }
            else
                return PartialView("pvAddUpdateItemDetailsHouseCargo", ItemDetailsHouseCargoService.Instance.GetItemDetailsHouseCargoByItemDetailsId(iItemDetailsId));
        }

        [HttpPost]
        public JsonResult AddUpdateItemDetailsHouseCargo(ItemDetailsHouseCargoModel model)
        {
            if (ModelState.IsValid)
            {
                return Json(ItemDetailsHouseCargoService.Instance.SaveItemDetailsHouseCargo(model, 1));
            }
            else
            {
                return Json(new { Status = false, Message = string.Join(",", ModelState.Values.SelectMany(z => z.Errors).Select(z => z.ErrorMessage)) });
            }
        }
    }
}