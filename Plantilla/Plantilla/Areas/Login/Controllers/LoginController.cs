using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Plantilla.Areas.Login.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login/Login
        public ActionResult Index()
        {
            ViewBag.FocoUser = "autofocus";
            return View();
        }

        [HttpPost]
        public ActionResult Index(string usuario, string pass)
        {
            var bd = (new Class.ConnectionBuilder(usuario, pass, "(localdb)\\Servidor")).GetBD_REVISTAS();
            if (bd.Database.Exists())
            {
                Session["usuario"] = usuario;
                Session["pass"] = pass;
                Session["servidor"] = "(localdb)\\Servidor";

                //Direct link
                if (HttpContext.Request.Cookies["linkRedirect"] != null)
                {
                    //Pagina guardada
                    var strAux = "/" + (HttpContext.Request.Cookies["linkRedirect"].Value).Split(new[] { '/' }, 4)[3];
                    HttpContext.Response.Cookies["linkRedirect"].Expires = DateTime.Now.AddDays(-1);
                    return RedirectToAction("Plantilla", "Plantilla", new { area = "Plantilla" });
                    //return Redirect(strAux);
                }
                else
                {
                    //Pagina de inicio despues del Login
                    return RedirectToAction("Home", "Home", new { area = "" });
                }
            }
            else
            {
                ViewBag.Error = "Usuario y/o contraseña incorrecta";
            }
            ViewBag.Usuario = usuario;
            ViewBag.FocoPass = "autofocus";

            return View();
        }

        public ActionResult CerrarSesion()
        {
            Session.Clear();
            return Redirect("/");
        }
    }
}