using System.Web.Mvc;
using KarolCamp.Aplicacao;
using KarolCamp.Dominio;


namespace KarolCamp.UI.Web.Controllers
{
    public class TrilhaController : Controller
    {
        //
        // GET: /Trilha/

        public ActionResult Index()
        {
            var app = Construtor.TrilhaAplicacaoMongo();
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
                var app = Construtor.TrilhaAplicacaoMongo();
                app.Salvar(trilha);
                return RedirectToAction("Index");
            }
            return View(trilha);
        }

        public ActionResult Editar(string id)
        {
            var app = Construtor.TrilhaAplicacaoMongo();
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
                var app = Construtor.TrilhaAplicacaoMongo();
                app.Salvar(trilha);
                return RedirectToAction("Index");
            }
            return View(trilha);

        }

        public ActionResult Deletar(string id)
        {
            var app = Construtor.TrilhaAplicacaoMongo();
            var trilha = app.ListarPorId(id);
            if (trilha == null)
                return HttpNotFound();

            return View(trilha);
        }

        [HttpPost, ActionName("Deletar")]
        public ActionResult ConfirmaDeletar(string id)
        {
            //Todo: Não posso excluir trilha se estiver utilizando na palestra
            var app = Construtor.TrilhaAplicacaoMongo();
            app.Excluir(id);
            return RedirectToAction("Index");
        }

        public ActionResult Detalhe(string id)
        {
            var app = Construtor.TrilhaAplicacaoMongo();
            var trilha = app.ListarPorId(id);
            if (trilha == null)
                return HttpNotFound();

            return View(trilha);
        }

    }
}
