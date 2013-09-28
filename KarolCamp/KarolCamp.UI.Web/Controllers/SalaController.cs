using System.Web.Mvc;
using KarolCamp.Aplicacao;
using KarolCamp.Dominio;


namespace KarolCamp.UI.Web.Controllers
{
    public class SalaController : Controller
    {
        //
        // GET: /Sala/

        public ActionResult Index()
        {
            var app = Construtor.SalaAplicacaoMongo();
            return View(app.ListarTodos());
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Sala sala)
        {
            if (ModelState.IsValid)
            {
                var app = Construtor.SalaAplicacaoMongo();
                app.Salvar(sala);
                return RedirectToAction("Index");
            }
            return View(sala);
        }

        public ActionResult Editar(string id)
        {
            var app = Construtor.SalaAplicacaoMongo();
            var sala = app.ListarPorId(id);
            if (sala == null)
                return HttpNotFound();

            return View(sala);
        }

        [HttpPost]
        public ActionResult Editar(Sala sala)
        {
            if (ModelState.IsValid)
            {
                var app = Construtor.SalaAplicacaoMongo();
                app.Salvar(sala);
                return RedirectToAction("Index");
            }
            return View(sala);

        }

        public ActionResult Deletar(string id)
        {
            var app = Construtor.SalaAplicacaoMongo();
            var sala = app.ListarPorId(id);
            if (sala == null)
                return HttpNotFound();

            return View(sala);
        }

        [HttpPost, ActionName("Deletar")]
        public ActionResult ConfirmaDeletar(string id)
        {
            //Todo: Não posso excluir sala se estiver utilizando na palestra
            var app = Construtor.SalaAplicacaoMongo();
            app.Excluir(id);
            return RedirectToAction("Index");
        }

        public ActionResult Detalhe(string id)
        {
            var app = Construtor.SalaAplicacaoMongo();
            var sala = app.ListarPorId(id);
            if (sala == null)
                return HttpNotFound();

            return View(sala);
        }

    }
}
