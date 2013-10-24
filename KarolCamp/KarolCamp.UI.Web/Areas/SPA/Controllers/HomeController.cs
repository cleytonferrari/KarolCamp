using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KarolCamp.UI.Web.Areas.SPA.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /SPA/Home/

        public ActionResult Index()
        {
            return View();
        }
    }
}
