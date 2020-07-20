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
    public class MasterConsigmentController : Controller
    {
        // GET: MessageImplementation
        public ActionResult Index()
        {
            return View();
        }


        public PartialViewResult AddUpdateMessage(int? iMessageImplementationId = null)
        {
            if (iMessageImplementationId == null)
            {
                return PartialView("pvAddUpdateMessages");
            }
            else
                return PartialView("pvAddUpdateMessages", MasterConsigmentModel.Instance.GetMessageByMessageImpementationId(iMessageImplementationId));
        }

        [HttpPost]
        public JsonResult AddUpdateMasterConsignment(MasterConsigmentModel model)
        {
           
            if (ModelState.IsValid)
            {
                return Json(MasterConsigmentService.Instance.SaveMasterConsigment(model, 1));
            }
            else
            {
                return Json(new { Status = false, Message = string.Join(",", ModelState.Values.SelectMany(z => z.Errors).Select(z => z.ErrorMessage)) });
            }
        }
    }
}