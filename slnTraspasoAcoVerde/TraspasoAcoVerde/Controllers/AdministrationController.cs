using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Acosta.Domain;

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

        [HttpPost]
        public ActionResult LoadUsers()
        {
            List<UserModel> LstUsers = new List<UserModel>();
            UserModel user = new UserModel();
            user.IdUsuario = 1;
            user.NombreCompleto = "Ricardo Herrera";
            user.Correo = "rherrera@grupoav.com";
            user.TipoUsuario = "corporativo administrador";
            user.Activo = true;
            LstUsers.Add(user);

            return Json(new { data = LstUsers }, JsonRequestBehavior.AllowGet);
        }
    }
}