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
            ItemDetailsHouseCargoService.Instance.Validate(iHouseCargoDescId);
            return View();
        }

        [HttpPost]
        public JsonResult GetItemDetailsHouseCargo()
        {
            var iHouseCargoDescId = Convert.ToInt32(Session["iHouseCargoDescId"]);
            var search = Request.Form.GetValues("search[value]").FirstOrDefault();
            var start = Convert.ToInt32(Request.Form.GetValues("start").FirstOrDefault());
            var length = Convert.ToInt32(Request.Form.GetValues("length").FirstOrDefault());
            var data = ItemDetailsHouseCargoService.Instance.GetItemDetailsHouseCargo(iHouseCargoDescId, search, start, length, out int recordsTotal);
            return Json(new { recordsTotal, recordsFiltered = recordsTotal, data });
        }

        public PartialViewResult AddUpdateItemDetailsHouseCargo(int? iItemDetailsId)
        {
            if ((iItemDetailsId??0) == 0)
            {
                int iHouseCargoDescId = Convert.ToInt32(Session["iHouseCargoDescId"]);
                return PartialView("pvAddUpdateItemDetailsHouseCargo", new ItemDetailsHouseCargoModel
                {
                    iHouseCargoDescId = iHouseCargoDescId,
                    sReportingEvent = HouseCargoService.Instance.GetMessageTypeByHouseCargoDescId(iHouseCargoDescId,out int iMasterConsignmentId),
                    iMasterConsignmentId = iMasterConsignmentId
                });
            }
            else
                return PartialView("pvAddUpdateItemDetailsHouseCargo", ItemDetailsHouseCargoService.Instance.GetItemDetailsHouseCargoByItemDetailsId(iItemDetailsId));
        }

        [HttpPost]
        public JsonResult AddUpdateItemDetailsHouseCargo(ItemDetailsHouseCargoModel model)
        {
            string Messages = string.Empty;
            if (ModelState.IsValid && ItemDetailsHouseCargoService.Instance.Validate(model, out Messages))
            {
                return Json(ItemDetailsHouseCargoService.Instance.SaveItemDetailssHouseCargo(model, 1));
            }
            else
            {
                return Json(new { Status = false, Message = string.Join(",", ModelState.Values.SelectMany(z => z.Errors).Select(z => z.ErrorMessage)) + ", " + Messages });
            }
        }
    }
}