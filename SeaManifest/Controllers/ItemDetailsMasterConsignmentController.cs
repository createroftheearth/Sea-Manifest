﻿using BAL.Models;
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
            MasterConsignmentService.Instance.Validate(iMasterConsignmentId);

            return View();
        }

        [HttpPost]
        public JsonResult GetItemDetailsMasterConsignment()
        {
            var iMasterConsignmentId = Convert.ToInt32(Session["iMasterConsignmentId"]);
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var search = Request.Form.GetValues("search[value]").FirstOrDefault();
            var start = Convert.ToInt32(Request.Form.GetValues("start").FirstOrDefault());
            var length = Convert.ToInt32(Request.Form.GetValues("length").FirstOrDefault());
            var data = ItemDetailsMasterConsignmentService.Instance.GetItemDetailsMasterConsignment(iMasterConsignmentId, search, start, length, out int recordsTotal);
            return Json(new { recordsTotal, recordsFiltered = recordsTotal, data });
        }

        public PartialViewResult AddUpdateItemDetailsMasterConsignment(int? iItemDetailsId)
        {
            if (iItemDetailsId == null)
            {
                int iMasterConsignmentId = Convert.ToInt32(Session["iMasterConsignmentId"]);
                return PartialView("pvAddUpdateItemDetailsMasterConsignment", new ItemDetailsMasterConsignmentModel
                {
                    iMasterConsignmentId = iMasterConsignmentId,
                    sReportingEvent = MasterConsignmentService.Instance.GetMessageTypeByMasterConsignmentId(iMasterConsignmentId)
                });
            }
            else
                return PartialView("pvAddUpdateItemDetailsMasterConsignment", ItemDetailsMasterConsignmentService.Instance.GetItemDetailsMasterConsignmentByItemDetailsId(iItemDetailsId));
        }

        [HttpPost]
        public JsonResult AddUpdateItemDetailsMasterConsignment(ItemDetailsMasterConsignmentModel model)
        {
            if (ModelState.IsValid)
            {
                return Json(ItemDetailsMasterConsignmentService.Instance.SaveItemDetailssMasterConsignment(model, 1));
            }
            else
            {
                return Json(new { Status = false, Message = string.Join(",", ModelState.Values.SelectMany(z => z.Errors).Select(z => z.ErrorMessage)) });
            }
        }
    }
}