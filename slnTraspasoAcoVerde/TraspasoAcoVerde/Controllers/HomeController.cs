using System.Configuration;
using System.Web;
using System.Web.Mvc;
using TraspasoAcoVerde.AuxClasses;

namespace TraspasoAcoVerde.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            #region Establecer la cookie

            string valor = "34337054-042D-4AAF-AE15-7BE7EC878C21";
            HttpCookie cookie1 = new HttpCookie("TRSis", valor);
            ControllerContext.HttpContext.Response.SetCookie(cookie1);

            #endregion

            Session["Controlador" + Session.SessionID] = "Home";

            var motivoRedireccion = "";

            var login = GeneralFunctions.ValidaPermisosUsuario(ref motivoRedireccion);

            string pruebaConn = GeneralFunctions.Prueba_ConexionACualquierBD_porDLL();

            if(!login) {
                return Redirect(GeneralFunctions.ObtenerRutaRedireccion());
            }

            ViewBag.NombreSistema = ConfigurationManager.AppSettings["NombreSistema"];
            
            return View();
        }
        
    }
}