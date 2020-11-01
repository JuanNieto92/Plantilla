using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Authentication;
using System.Web;
using System.Web.Mvc;


namespace Plantilla.Areas.Login.Controllers
{

    public class AppController : Controller
    {
        protected Models.BD_REVISTAS.BD_REVISTASEntities bd_revistas;

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (Session["usuario"] != null)
            {
                string usuario = Session["usuario"].ToString();
                bd_revistas = (new Class.ConnectionBuilder(Session["usuario"].ToString(), Session["pass"].ToString(), Session["servidor"].ToString())).GetBD_REVISTAS();

                string funcion = filterContext.RouteData.Values["action"].ToString().ToUpper();
                string controlador = filterContext.RouteData.Values["controller"].ToString().ToUpper();

                //if (!bd.USR_PermisoSitioWeb.Any(x => x.Usuario == usuario && x.IdPaginaSitioWeb == 1))
                //{
                //    throw new AuthenticationException("SinPermiso");
                //}
            }
            else
            {
                throw new AuthenticationException("SinLogin");
            }
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                if (filterContext.Exception.Message.Equals("SinLogin"))
                {
                    HttpCookie cookieURL = new HttpCookie((Assembly.GetCallingAssembly().GetName().Name).ToString() + "linkRedirect");
                    cookieURL.Value = filterContext.HttpContext.Request.Url.ToString();
                    HttpContext.Response.Cookies.Add(cookieURL);
                    filterContext.Result = new JsonResult
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = new { error = "No se ha registrado, ha perdido su sesión." }
                    };
                    filterContext.ExceptionHandled = true;
                }
                if (filterContext.Exception.Message.Equals("SinPermiso"))
                {
                    filterContext.Result = new JsonResult
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = new { error = "No cuenta con los privilegios para esta acción." }
                    };
                    filterContext.ExceptionHandled = true;
                }
            }
            else
            {
                if (filterContext.Exception.GetType() == typeof(AuthenticationException))
                {
                    if (filterContext.Exception.Message.Equals("SinLogin"))
                    {
                        HttpCookie cookieURL = new HttpCookie("linkRedirect");
                        cookieURL.Value = filterContext.HttpContext.Request.Url.ToString();
                        HttpContext.Response.Cookies.Add(cookieURL);
                        filterContext.ExceptionHandled = true;
                        filterContext.Result = this.Redirect("/Login/Login/");
                    }
                    if (filterContext.Exception.Message.Equals("SinPermiso"))
                    {
                        filterContext.ExceptionHandled = true;
                        // No se que pagina
                        filterContext.Result = this.Redirect("/Home/Home/");
                    }
                }
            }
            //base.OnException(filterContext);
        }
    }
}