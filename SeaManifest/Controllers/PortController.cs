using BAL.Models;
using BAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeaManifest.Controllers
{
    public class PortController : Controller
    {
        // GET: Port
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetPort()
        {
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var search = Request.Form.GetValues("search[value]").FirstOrDefault();
            var start = Convert.ToInt32(Request.Form.GetValues("start").FirstOrDefault());
            var length = Convert.ToInt32(Request.Form.GetValues("length").FirstOrDefault());
            var data = PortService.Instance.GetPort(search, start, length, out int recordsTotal);
            return Json(new { recordsTotal, recordsFiltered = recordsTotal, data });
        }

        public PartialViewResult AddUpdatePort(int? iPortId = null)
        {
            if ((iPortId ?? 0) == 0)
            {
                return PartialView("pvAddUpdatePort", new PortModel
                {

                });
            }
            else
                return PartialView("pvAddUpdatePort", PortService.Instance.GetPortByPortId(iPortId));
        }

        [HttpPost]
        public JsonResult AddUpdatePort(PortModel model)
        {
            if(model.sCountryCode!="IN")
            {
                ModelState.Remove("SstateCode");
            }
            if (ModelState.IsValid)
            {
                return Json(PortService.Instance.SavePort(model, 1));
            }
            else
            {
                return Json(new { Status = false, Message = string.Join(",", ModelState.Values.SelectMany(z => z.Errors).Select(z => z.ErrorMessage)) });
            }
        }

    }
}