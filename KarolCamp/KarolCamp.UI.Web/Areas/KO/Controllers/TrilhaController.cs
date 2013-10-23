using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KarolCamp.UI.Web.Areas.KO.Controllers
{
    public class TrilhaController : Controller
    {
        //
        // GET: /KO/Trilha/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        public ActionResult Editar(string id)
        {
            return View();
        }

        
        public ActionResult Deletar(string id)
        {
            return View();
        }

        
        public ActionResult Detalhe(string id)
        {
            return View();
        }

    }
}
