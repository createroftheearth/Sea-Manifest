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
    public class TransportEquipmentMessageImplementationController : BaseController
    {
        // GET: MessageImplementation
        public ActionResult Index(int? iMessageImplementationId)
        {
            Session["iMessageImplementationId"] = iMessageImplementationId;
            MessageImplementationService.Instance.Validate(iMessageImplementationId);
            return View();
        }

        [HttpPost]
        public JsonResult GetTransportEquipmentMessageImplementation()
        {
            var iMessageImplementationId = Convert.ToInt32(Session["iMessageImplementationId"]);
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var search = Request.Form.GetValues("search[value]").FirstOrDefault();
            var start = Convert.ToInt32(Request.Form.GetValues("start").FirstOrDefault());
            var length = Convert.ToInt32(Request.Form.GetValues("length").FirstOrDefault());
            var data = TransportEquipmentMessageImplementationService.Instance.GetTransportEquipmentMessageImplementation(iMessageImplementationId, search, start, length, out int recordsTotal);
            return Json(new { recordsTotal, recordsFiltered = recordsTotal, data });
        }

        public PartialViewResult AddUpdateTransportEquipmentMessageImplementation(int? iTransporterEquipmentId = null )
        {
            if ((iTransporterEquipmentId ?? 0) == 0)
            {
                var iMessageImplementationId = Convert.ToInt32(Session["iMessageImplementationId"]);
                return PartialView("pvAddUpdateTransportEquipmentMessageImplementation", new TransportEquipmentMessageImplementationModel
                {
                    iMessageImplementationId = iMessageImplementationId,
                    sReportingEvent = MessageImplementationService.Instance.GetMessageTypeByImplementationId(iMessageImplementationId)
                });
            }
            else
                return PartialView("pvAddUpdateTransportEquipmentMessageImplementation", TransportEquipmentMessageImplementationService.Instance.GetTransportEquipmentMessageImplementationByTransporterEquipmentId(iTransporterEquipmentId));
        }

        [HttpPost]
        public JsonResult AddUpdateTransportEquipmentMessageImplementation(TransportEquipmentMessageImplementationModel model)
        {
            if (ModelState.IsValid)
            {
                return Json(TransportEquipmentMessageImplementationService.Instance.SaveTransportEquipmentMessageImplementation(model, 1));
            }
            else
            {
                return Json(new { Status = false, Message = string.Join(",", ModelState.Values.SelectMany(z => z.Errors).Select(z => z.ErrorMessage)) });
            }
        }
    }
}