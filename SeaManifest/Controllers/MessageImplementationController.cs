using System;
using System.Collections.Generic;
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

        public PartialViewResult AddHeader()
        {
            return PartialView("pvAddHeader");
        }


    }
}