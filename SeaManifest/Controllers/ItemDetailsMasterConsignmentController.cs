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
    public class ItemDetailsMasterConsignmentController : BaseController
    {
        // GET: MasterConsignment
        public ActionResult Index(int? iMasterConsignmentId)
        {
            Session["iMasterConsignmentId"] = iMasterConsignmentId;
            ItemDetailsMasterConsignmentService.Instance.Validate(iMasterConsignmentId);
            return View();
        }

        [HttpPost]
        public JsonResult GetItemDetailsMasterConsignment()
        {
            var iMasterConsignmentId = Convert.ToInt32(Session["iMasterConsignmentId"]);
            var search = Request.Form.GetValues("search[value]").FirstOrDefault();
            var start = Convert.ToInt32(Request.Form.GetValues("start").FirstOrDefault());
            var length = Convert.ToInt32(Request.Form.GetValues("length").FirstOrDefault());
            var data = ItemDetailsMasterConsignmentService.Instance.GetItemDetailsMasterConsignment(iMasterConsignmentId, search, start, length, out int recordsTotal);
            return Json(new { recordsTotal, recordsFiltered = recordsTotal, data });
        }

        public PartialViewResult AddUpdateItemDetailsMasterConsignment(int? iItemDetailsId)
        {
            if ((iItemDetailsId??0) == 0)
            {
                int iMasterConsignmentId = Convert.ToInt32(Session["iMasterConsignmentId"]);
                return PartialView("pvAddUpdateItemDetailsMasterConsignment", new ItemDetailsMasterConsignmentModel
                {
                    iMasterConsignmentId = iMasterConsignmentId,
                    sReportingEvent = MasterConsignmentService.Instance.GetMessageTypeByMasterConsignmentId(iMasterConsignmentId,out int iMessageImplementationId),
                    iMessageImplementationId = iMessageImplementationId 
                });
            }
            else
                return PartialView("pvAddUpdateItemDetailsMasterConsignment", ItemDetailsMasterConsignmentService.Instance.GetItemDetailsMasterConsignmentByItemDetailsId(iItemDetailsId));
        }

        [HttpPost]
        public JsonResult AddUpdateItemDetailsMasterConsignment(ItemDetailsMasterConsignmentModel model)
        {
            string Messages = string.Empty;
            if (ModelState.IsValid && ItemDetailsMasterConsignmentService.Instance.Validate(model, out Messages))
            {
                return Json(ItemDetailsMasterConsignmentService.Instance.SaveItemDetailssMasterConsignment(model, GetUserInfo().iUserId));
            }
            else
            {
                return Json(new { Status = false, Message = string.Join(",", ModelState.Values.SelectMany(z => z.Errors).Select(z => z.ErrorMessage)) + ", " + Messages });
            }
        }
    }
}