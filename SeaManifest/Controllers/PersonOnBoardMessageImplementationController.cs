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
    public class PersonOnBoardMessageImplementationController : BaseController
    {
        // GET: PersonOnBoard
        public ActionResult Index(int? iMessageImplementationId)
        {
            Session["iMessageImplementationId"] = iMessageImplementationId;
            MessageImplementationService.Instance.Validate(iMessageImplementationId);
            return View();
        }

        [HttpPost]
        public JsonResult GetPersonOnBoardMessageImplementation()
        {
            var iMessageImplementationId = Convert.ToInt32(Session["iMessageImplementationId"]);
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var search = Request.Form.GetValues("search[value]").FirstOrDefault();
            var start = Convert.ToInt32(Request.Form.GetValues("start").FirstOrDefault());
            var length = Convert.ToInt32(Request.Form.GetValues("length").FirstOrDefault());
            var data = PersonOnBoardMessageImplementationService.Instance.GetPersonOnBoardMessageImplementation(iMessageImplementationId, search, start, length, out int recordsTotal);
            return Json(new { recordsTotal, recordsFiltered = recordsTotal, data });
        }

        public PartialViewResult AddUpdatePersonOnBoardMessageImplementation(int? iPersonOnBoardId = null)
        {
            var iMessageImplementationId = Convert.ToInt32(Session["iMessageImplementationId"]);
            if ((iPersonOnBoardId ?? 0) == 0)
            {
                return PartialView("pvAddUpdatePersonOnBoardMessageImplementation", new PersonOnBoardMessageImplementationModel
                {
                    iMessageImplementationId = iMessageImplementationId,
                    sReportingEvent = MessageImplementationService.Instance.GetMessageTypeByImplementationId(iMessageImplementationId)
                });
            }
            else
                return PartialView("pvAddUpdatePersonOnBoardMessageImplementation", PersonOnBoardMessageImplementationService.Instance.GetPersonOnBoardMessageImplementationByPersonOnBoardId(iPersonOnBoardId,iMessageImplementationId));
        }

        [HttpPost]
        public JsonResult AddUpdatePersonOnBoardMessageImplementation(PersonOnBoardMessageImplementationModel model)
        {
            if (ModelState.IsValid)
            {
                return Json(PersonOnBoardMessageImplementationService.Instance.SavePersonOnBoardMessageImplementation(model, GetUserInfo().iUserId));
            }
            else
            {
                return Json(new { Status = false, Message = string.Join(",", ModelState.Values.SelectMany(z => z.Errors).Select(z => z.ErrorMessage)) });
            }
        }
    }
}