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
    public class MessageImplementationController : Controller
    {
        // GET: MessageImplementation
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetMessages()
        {
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var search = Request.Form.GetValues("search[value]").FirstOrDefault();
            var start = Convert.ToInt32(Request.Form.GetValues("start").FirstOrDefault());
            var length = Convert.ToInt32(Request.Form.GetValues("length").FirstOrDefault());
            var data = MessageImplementationService.Instance.GetMessages(search, start, length, out int recordsTotal);
            return Json(new { recordsTotal, recordsFiltered = recordsTotal, data });
        }

        public PartialViewResult AddUpdateMessage(int? iMessageImplementationId = null)
        {
            if (iMessageImplementationId == null)
            {
                return PartialView("pvAddUpdateMessages");
            }
            else
                return PartialView("pvAddUpdateMessages", MessageImplementationService.Instance.GetMessageByMessageImpementationId(iMessageImplementationId));
        }

        [HttpPost]
        public JsonResult AddUpdateMessage(MessageImplementationModel model)
        {
            model.sIndicator = ConfigurationManager.AppSettings["HeaderIndicator"];
            model.sVersionNo = ConfigurationManager.AppSettings["HeaderVersion"];
            if (model.sReportingEvent == "SDN")
            {
                ModelState.Remove("sDate");
                ModelState.Remove("sTime");
                ModelState.Remove("sSequenceOrControlNumber");
            }
            if (ModelState.IsValid)
            {
                return Json(MessageImplementationService.Instance.SaveMessage(model, 1));
            }
            else
            {
                return Json(new { Status = false, Message = string.Join(",", ModelState.Values.SelectMany(z => z.Errors).Select(z => z.ErrorMessage)) });
            }
        }

        public FileResult GetMessageJson(int iMessageImplementationId)
        {
            byte[] getJsonBytes = MessageImplementationService.Instance.GetMessageJson(iMessageImplementationId);
            return File(getJsonBytes,"application/json");
        }
    }
}