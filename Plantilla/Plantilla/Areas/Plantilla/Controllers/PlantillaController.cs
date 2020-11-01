using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plantilla.Areas.Plantilla.Controllers
{
    public class PlantillaController : Areas.Login.Controllers.AppController
    {
        // GET: Plantilla/Plantilla
        public ActionResult Plantilla()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}