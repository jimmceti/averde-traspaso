using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TraspasoAcoVerde.Controllers
{
    public class AdministrationController : Controller
    {
        // GET: Configuration
        public ActionResult Configuration()
        {
            return View();
        }

        public ActionResult Roles()
        {
            return View();
        }

        public ActionResult Users()
        {
            return View();
        }
    }
}