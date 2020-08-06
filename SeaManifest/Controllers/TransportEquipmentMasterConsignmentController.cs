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
    public class TransportEquipmentMasterConsignmentController : BaseController
    {
        // GET: MasterConsignment
        public ActionResult Index(int? iMasterConsignmentId)
        {
            Session["iMasterConsignmentId"] = iMasterConsignmentId;
            MasterConsignmentService.Instance.Validate(iMasterConsignmentId);
            return View();
        }

        [HttpPost]
        public JsonResult GetTransportEquipmentMasterConsignment()
        {
            var iMasterConsignmentId = Convert.ToInt32(Session["iMasterConsignmentId"]);
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var search = Request.Form.GetValues("search[value]").FirstOrDefault();
            var start = Convert.ToInt32(Request.Form.GetValues("start").FirstOrDefault());
            var length = Convert.ToInt32(Request.Form.GetValues("length").FirstOrDefault());
            var data = TransportEquipmentMasterConsignmentService.Instance.GetTransportEquipmentMasterConsignment(iMasterConsignmentId, search, start, length, out int recordsTotal);
            return Json(new { recordsTotal, recordsFiltered = recordsTotal, data });
        }

        public PartialViewResult AddUpdateTransportEquipmentMasterConsignment(int? iTransporterEquipmentId = null)
        {
            if ((iTransporterEquipmentId ?? 0) == 0)
            {
                var iMasterConsignmentId = Convert.ToInt32(Session["iMasterConsignmentId"]);
                return PartialView("pvAddUpdateTransportEquipmentMasterConsignment", new TransportEquipmentMasterConsignmentModel
                {
                    iMasterConsignmentId = iMasterConsignmentId,
                    sReportingEvent = MasterConsignmentService.Instance.GetMessageTypeByMasterConsignmentId(iMasterConsignmentId,out int iMessageImplementationId),
                    iMessageImplementationId = iMessageImplementationId
                });
            }
            else
                return PartialView("pvAddUpdateTransportEquipmentMasterConsignment", TransportEquipmentMasterConsignmentService.Instance.GetTransportEquipmentMasterConsignmentByTransporterEquipmentId(iTransporterEquipmentId));
        }

        [HttpPost]
        public JsonResult AddUpdateTransportEquipmentMasterConsignment(TransportEquipmentMasterConsignmentModel model)
        {
            if (ModelState.IsValid)
            {
                return Json(TransportEquipmentMasterConsignmentService.Instance.SaveTransportEquipmentMasterConsignment(model, 1));
            }
            else
            {
                return Json(new { Status = false, Message = string.Join(",", ModelState.Values.SelectMany(z => z.Errors).Select(z => z.ErrorMessage)) });
            }
        }
    }
}