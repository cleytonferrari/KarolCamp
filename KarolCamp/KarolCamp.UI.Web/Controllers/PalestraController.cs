using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KarolCamp.UI.Web.Aplicacao;
using KarolCamp.UI.Web.Models;

namespace KarolCamp.UI.Web.Controllers
{
    public class PalestraController : Controller
    {
        //
        // GET: /Palestra/


        public ActionResult Index()
        {
            var app = new PalestraAplicacao();
            return View(app.ListarTodos());
        }

        public ActionResult Cadastrar()
        {

            ViewBag.ListaDeTrilhas = new SelectList(new TrilhaAplicacao().ListarTodos(), "Id", "Nome");
            ViewBag.ListaDePalestrantes = new SelectList(new PalestranteAplicacao().ListarTodos(), "Id", "Nome");
            ViewBag.ListaDeSalas = new SelectList(new SalaAplicacao().ListarTodos(), "Id", "Nome");
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Palestra palestra)
        {
            if (ModelState.IsValid)
            {
                var app = new PalestraAplicacao();
                palestra.Trilha = new TrilhaAplicacao().ListarPorId(palestra.Trilha.Id);
                palestra.Palestrante = new PalestranteAplicacao().ListarPorId(palestra.Palestrante.Id);
                palestra.Sala = new SalaAplicacao().ListarPorId(palestra.Sala.Id);
                app.Salvar(palestra);
                return RedirectToAction("Index");
            }
            return View(palestra);
        }

        public ActionResult Editar(string id)
        {
            var app = new PalestraAplicacao();
            var palestra = app.ListarPorId(id);
            if (palestra == null)
                return HttpNotFound();

            ViewBag.ListaDeTrilhas = new SelectList(new TrilhaAplicacao().ListarTodos(), "Id", "Nome", palestra.Trilha.Id);
            ViewBag.ListaDePalestrantes = new SelectList(new PalestranteAplicacao().ListarTodos(), "Id", "Nome", palestra.Palestrante.Id);
            ViewBag.ListaDeSalas = new SelectList(new SalaAplicacao().ListarTodos(), "Id", "Nome", palestra.Sala.Id);

            return View(palestra);
        }

        [HttpPost]
        public ActionResult Editar(Palestra palestra)
        {
            if (ModelState.IsValid)
            {
                var app = new PalestraAplicacao();
                palestra.Trilha = new TrilhaAplicacao().ListarPorId(palestra.Trilha.Id);
                palestra.Palestrante = new PalestranteAplicacao().ListarPorId(palestra.Palestrante.Id);
                palestra.Sala = new SalaAplicacao().ListarPorId(palestra.Sala.Id);
                app.Salvar(palestra);
                return RedirectToAction("Index");
            }
            return View(palestra);

        }

        public ActionResult Deletar(string id)
        {
            var app = new PalestraAplicacao();
            var palestra = app.ListarPorId(id);
            if (palestra == null)
                return HttpNotFound();

            return View(palestra);
        }

        [HttpPost, ActionName("Deletar")]
        public ActionResult ConfirmaDeletar(string id)
        {
            //Todo: Não posso excluir palestra se estiver utilizando na palestra
            var app = new PalestraAplicacao();
            app.Excluir(id);
            return RedirectToAction("Index");
        }

        public ActionResult Detalhe(string id)
        {
            var app = new PalestraAplicacao();
            var palestra = app.ListarPorId(id);
            if (palestra == null)
                return HttpNotFound();

            return View(palestra);
        }

    }
}
