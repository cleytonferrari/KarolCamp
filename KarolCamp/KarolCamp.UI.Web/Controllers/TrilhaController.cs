using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KarolCamp.UI.Web.Aplicacao;
using KarolCamp.UI.Web.Models;

namespace KarolCamp.UI.Web.Controllers
{
    public class TrilhaController : Controller
    {
        //
        // GET: /Trilha/

        public ActionResult Index()
        {
            var app = new TrilhaAplicacao();
            return View(app.ListarTodos());
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Trilha trilha)
        {
            if (ModelState.IsValid)
            {
                var app = new TrilhaAplicacao();
                app.Salvar(trilha);
                return RedirectToAction("Index");
            }

            return View(trilha);
        }


    }
}
