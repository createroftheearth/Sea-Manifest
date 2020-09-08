using BAL.Models;
using BAL.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace SeaManifest.Controllers
{
    public class MasterConsignmentController : BaseController
    {
        // GET: MessageImplementation
        public ActionResult Index(int? iMessageImplementationId)
        {
            Session["MessageImplementationId"] = iMessageImplementationId;
            MessageImplementationService.Instance.Validate(iMessageImplementationId);
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
            var data = MasterConsignmentService.Instance.GetConsignments(iMessageImplementationId, search, start, length, out int recordsTotal);
            return Json(new { recordsTotal, recordsFiltered = recordsTotal, data });
        }


        public PartialViewResult AddUpdateMasterConsignment(int? iMasterConsignmentId = null)
        {
            if ((iMasterConsignmentId ?? 0) == 0)
            {
                int iMessageImplementationId = Convert.ToInt32(Session["MessageImplementationId"]);
                return PartialView("pvAddUpdateMasterConsignment", new MasterConsignmentModel
                {
                    iMessageImplementationId = iMessageImplementationId,
                    sTrnsprtrDocTypeOfNotFdPartyCd = "PAN",
                    sReportingEvent = MessageImplementationService.Instance.GetMessageTypeByImplementationId(iMessageImplementationId)
                });
            }
            else
                return PartialView("pvAddUpdateMasterConsignment", MasterConsignmentService.Instance.GetMasterConsigmentByMasterConsignmentId(iMasterConsignmentId));
        }

        [HttpPost]
        public JsonResult AddUpdateMasterConsignment(MasterConsignmentModel model)
        {
            string Messages = string.Empty;
            if(model.sReportingEvent=="SEI" || model.sReportingEvent=="SDN")
            {
                ModelState.Remove("sTrnsprtrDocMsrMarksNoOnPackages");
                ModelState.Remove("sTrnsprtrDocGoodsDescAsPerBill");
                ModelState.Remove("sTrnsprtrDocNotFdPartyCity");
                ModelState.Remove("sTrnsprtrDocNotFdPartyStreetAddress");
                ModelState.Remove("sTrnsprtrDocNameOfAnyOtherNotFdParty");
                ModelState.Remove("sTrnsprtrDocConsigneeCountryCd");
                ModelState.Remove("sTrnsprtrDocConsigneeCity");
                ModelState.Remove("sTrnsprtrDocConsigneeStreetAddress");
                ModelState.Remove("sTrnsprtrDocConsigneeName");
                ModelState.Remove("sTrnsprtrDocConsignorCountryCd");
                ModelState.Remove("sTrnsprtrDocConsignorCity");
                ModelState.Remove("sTrnsprtrDocConsignorStreetAddress");
                ModelState.Remove("sTrnshprBond");
                ModelState.Remove("sTrnshprCd");
                ModelState.Remove("sLocCustomNatureOfCargo");
                ModelState.Remove("sLocCustomCargoMovement");
                ModelState.Remove("sLocCustomItemType");
                ModelState.Remove("sLocCustomTypeOfCargo");
                ModelState.Remove("sLocCustomTypeOfCargo");
                ModelState.Remove("dTrnsprtrDocMsrNoOfPackages");
                ModelState.Remove("dSuplmntryDecNoOfPackages");
                ModelState.Remove("sSuplmntryDecCinType");
                ModelState.Remove("dSuplmntryDecCSNNo");
            }
            if (ModelState.IsValid && MasterConsignmentService.Instance.ValidateLineMasterConsignment(model, out Messages))
            {
                return Json(MasterConsignmentService.Instance.SaveMasterConsigment(model, 1));
            }
            else
            {
                return Json(new { Status = false, Message = string.Join(",", ModelState.Values.SelectMany(z => z.Errors).Select(z => z.ErrorMessage)) + Messages });
            }
        }


    }
}