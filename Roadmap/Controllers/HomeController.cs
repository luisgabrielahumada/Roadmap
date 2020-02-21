using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Roadmap.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string cultura = "es-MX";
            var hasCultura = this.HttpContext.Request.Cookies.AllKeys.Contains("LanguageCookieName");
            if (!hasCultura)
            {
                this.HttpContext.Request.Cookies.Add(new HttpCookie("LanguageCookieName", cultura));
            }
            else
            {
                cultura =  this.HttpContext.Request.Cookies.Get("LanguageCookieName").Value;
            }
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultura);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(cultura);
            return View();
        }

        [AllowAnonymous]
        public ActionResult ChangeLanguage(string language)
        {
            this.HttpContext.Response.Cookies.Remove("LanguageCookieName");
            this.HttpContext.Response.Cookies.Add(new HttpCookie("LanguageCookieName", language));

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}
