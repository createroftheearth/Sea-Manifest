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
    public class SupportDocHouseCargoController : Controller
    {
        // GET: HouseCargo
        public ActionResult Index(int? iHouseCargoDescId)
        {
            Session["iHouseCargoDescId"] = iHouseCargoDescId;
            return View();
        }

        [HttpPost]
        public JsonResult GetSupportDocHouseCargo()
        {
            var iHouseCargoDescId = Convert.ToInt32(Session["iHouseCargoDescId"]);
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var search = Request.Form.GetValues("search[value]").FirstOrDefault();
            var start = Convert.ToInt32(Request.Form.GetValues("start").FirstOrDefault());
            var length = Convert.ToInt32(Request.Form.GetValues("length").FirstOrDefault());
            var data = SupportDocHouseCargoService.Instance.GetSupportDocHouseCargo(iHouseCargoDescId, search, start, length, out int recordsTotal);
            return Json(new { recordsTotal, recordsFiltered = recordsTotal, data });
        }

        public PartialViewResult AddUpdateSupportDocHouseCargo(int? iHouseCargoDescId = null,int? iSupportDocsId = null )
        {
            if (iSupportDocsId == null && iHouseCargoDescId == null)
            {
                return PartialView("pvAddUpdateSupportDocHouseCargo");
            }
            else
                return PartialView("pvAddUpdateSupportDocHouseCargo", SupportDocHouseCargoService.Instance.GetSupportDocHouseCargoBySupportDocsId(iHouseCargoDescId, iSupportDocsId));
        }

        [HttpPost]
        public JsonResult AddUpdateSupportDocHouseCargo(SupportDocHouseCargoModel model)
        {
            if (ModelState.IsValid)
            {
                return Json(SupportDocHouseCargoService.Instance.SaveSupportDocHouseCargo(model, 1));
            }
            else
            {
                return Json(new { Status = false, Message = string.Join(",", ModelState.Values.SelectMany(z => z.Errors).Select(z => z.ErrorMessage)) });
            }
        }
    }
}