﻿using System;
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

        public ActionResult Editar(string id)
        {
            var app = new TrilhaAplicacao();
            var trilha = app.ListarPorId(id);
            if (trilha == null)
                return HttpNotFound();

            return View(trilha);
        }

        [HttpPost]
        public ActionResult Editar(Trilha trilha)
        {
            if (ModelState.IsValid)
            {
                var app = new TrilhaAplicacao();
                app.Salvar(trilha);
                return RedirectToAction("Index");
            }
            return View(trilha);

        }

        public ActionResult Deletar(string id)
        {
            var app = new TrilhaAplicacao();
            var trilha = app.ListarPorId(id);
            if (trilha == null)
                return HttpNotFound();

            return View(trilha);
        }

        [HttpPost, ActionName("Deletar")]
        public ActionResult ConfirmaDeletar(string id)
        {
            //Todo: Não posso excluir trilha se estiver utilizando na palestra
            var app = new TrilhaAplicacao();
            app.Excluir(id);
            return RedirectToAction("Index");
        }

        public ActionResult Detalhe(string id)
        {
            var app = new TrilhaAplicacao();
            var trilha = app.ListarPorId(id);
            if (trilha == null)
                return HttpNotFound();

            return View(trilha);
        }

    }
}
