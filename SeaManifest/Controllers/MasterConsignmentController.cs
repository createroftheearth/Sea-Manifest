using BAL.Models;
using BAL.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace SeaManifest.Controllers
{
    public class MasterConsignmentController : Controller
    {
        // GET: MessageImplementation
        public ActionResult Index(int? iMessageImplementationId)
        {
            Session["MessageImplementationId"] = iMessageImplementationId;
            return View();
        }


        [HttpPost]
        public JsonResult GetMasterConsignments()
        {
            var iMessageImplementationId = Convert.ToInt32(Session["MessageImplementationId"]);
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var search = Request.Form.GetValues("search[value]").FirstOrDefault();
            var start = Convert.ToInt32(Request.Form.GetValues("start").FirstOrDefault());
            var length = Convert.ToInt32(Request.Form.GetValues("length").FirstOrDefault());
            var data = MasterConsignmentService.Instance.GetConsignments(iMessageImplementationId,search, start, length, out int recordsTotal);
            return Json(new { recordsTotal, recordsFiltered = recordsTotal, data });
        }


        public PartialViewResult AddUpdateMasterConsignment(int? iMessageImplementationId = null,int ? iMasterConsignmentId = null)
        {
            if (iMasterConsignmentId == null)
            {
            
                return PartialView("pvAddUpdateMasterConsignment",new MasterConsignmentModel
                {
                    iMessageImplementationId=iMessageImplementationId,
                    sReportingEvent= MessageImplementationService.Instance.GetMessageTypeByImplementationId(iMessageImplementationId)
                });
            }
            else
                return PartialView("pvAddUpdateMasterConsignment", MasterConsignmentService.Instance.GetMasterConsigmentMessageImpementationId(iMasterConsignmentId));
        }

        [HttpPost]
        public JsonResult AddUpdateMasterConsignment(MasterConsignmentModel model)
        {
            if (ModelState.IsValid)
            {
                return Json(MasterConsignmentService.Instance.SaveMasterConsigment(model, 1));
            }
            else
            {
                return Json(new { Status = false, Message = string.Join(",", ModelState.Values.SelectMany(z => z.Errors).Select(z => z.ErrorMessage)) });
            }
        }
    }
}