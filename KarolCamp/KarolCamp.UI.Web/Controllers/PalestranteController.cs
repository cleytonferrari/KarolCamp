using System.Web.Mvc;
using KarolCamp.UI.Web.Aplicacao;
using KarolCamp.UI.Web.Models;

namespace KarolCamp.UI.Web.Controllers
{
    public class PalestranteController : Controller
    {
        //
        // GET: /Palestrante/

        public ActionResult Index()
        {
            var app = new PalestranteAplicacao();
            return View(app.ListarTodos());
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Palestrante palestrante)
        {
            if (ModelState.IsValid)
            {
                var app = new PalestranteAplicacao();
                app.Salvar(palestrante);
                return RedirectToAction("Index");
            }
            return View(palestrante);
        }

        public ActionResult Editar(string id)
        {
            var app = new PalestranteAplicacao();
            var palestrante = app.ListarPorId(id);
            if (palestrante == null)
                return HttpNotFound();

            return View(palestrante);
        }

        [HttpPost]
        public ActionResult Editar(Palestrante palestrante)
        {
            if (ModelState.IsValid)
            {
                var app = new PalestranteAplicacao();
                app.Salvar(palestrante);
                return RedirectToAction("Index");
            }
            return View(palestrante);

        }

        public ActionResult Deletar(string id)
        {
            var app = new PalestranteAplicacao();
            var palestrante = app.ListarPorId(id);
            if (palestrante == null)
                return HttpNotFound();

            return View(palestrante);
        }

        [HttpPost, ActionName("Deletar")]
        public ActionResult ConfirmaDeletar(string id)
        {
            //Todo: Não posso excluir palestrante se estiver utilizando na palestra
            var app = new PalestranteAplicacao();
            app.Excluir(id);
            return RedirectToAction("Index");
        }

        public ActionResult Detalhe(string id)
        {
            var app = new PalestranteAplicacao();
            var palestrante = app.ListarPorId(id);
            if (palestrante == null)
                return HttpNotFound();

            return View(palestrante);
        }

    }
}
