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
    public class MessageImplementationController : Controller
    {
        // GET: MessageImplementation
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetHeaders()
        {
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var search = Request.Form.GetValues("search[value]").FirstOrDefault();
            var start = Convert.ToInt32(Request.Form.GetValues("start").FirstOrDefault());
            var length = Convert.ToInt32(Request.Form.GetValues("length").FirstOrDefault());
            var data = MessageImplementationService.Instance.GetHeaders(search, start, length, out int recordsTotal);
            return Json(new { recordsTotal, recordsFiltered = recordsTotal, data });
        }



        public PartialViewResult AddUpdateHeader(int? iMessageImplementationId = null)
        {
            if (iMessageImplementationId == null)
            {
                return PartialView("pvAddUpdateHeader");
            }
            else
                return PartialView("pvAddUpdateHeader",MessageImplementationService.Instance.GetHeaderByMessageImpementationId(iMessageImplementationId));
        }

        [HttpPost]
        public JsonResult AddUpdateHeader(HeaderFieldModel model)
        {
            model.sIndicator = ConfigurationManager.AppSettings["HeaderIndicator"];
            model.sVersionNo = ConfigurationManager.AppSettings["HeaderVersion"];
            if (ModelState.IsValid)
            {
                return Json(MessageImplementationService.Instance.SaveHeader(model, 1));
            }
            else
            {
                return Json(new { Status = false, Message = string.Join(",", ModelState.Values.SelectMany(z => z.Errors).Select(z => z.ErrorMessage)) });
            }
        }


        [HttpPost]
        public JsonResult AddUpdateMaster(MessageImplementationModel model)
        {
            
            if (ModelState.IsValid)
            {
                return Json(MessageImplementationService.Instance.SaveMasters(model, 1));
            }
            else
            {
                return Json(new { Status = false, Message = string.Join(",", ModelState.Values.SelectMany(z => z.Errors).Select(z => z.ErrorMessage)) });
            }
        }
    }
}