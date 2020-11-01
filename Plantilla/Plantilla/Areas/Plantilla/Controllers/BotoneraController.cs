using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plantilla.Areas.Plantilla.Controllers
{
    public class BotoneraController : Areas.Login.Controllers.AppController
    {
        // GET: Plantilla/Botonera
        public ActionResult Botonera()
        {

            if (Session["usuario"] != null)
            {
                string usuario = Session["usuario"].ToString();
                return View();
            }
            else
            {
                return Redirect("/");
            }
        }
    }
}