using System.Web.Mvc;
using KarolCamp.Aplicacao;
using KarolCamp.Dominio;


namespace KarolCamp.UI.Web.Controllers
{
    public class PalestraController : Controller
    {
        //
        // GET: /Palestra/


        public ActionResult Index()
        {
            var app = Construtor.PalestraAplicacaoMongo();
            return View(app.ListarTodos());
        }

        public ActionResult Cadastrar()
        {

            ViewBag.ListaDeTrilhas = new SelectList(Construtor.TrilhaAplicacaoMongo().ListarTodos(), "Id", "Nome");
            ViewBag.ListaDePalestrantes = new SelectList(Construtor.PalestranteAplicacaoMongo().ListarTodos(), "Id", "Nome");
            ViewBag.ListaDeSalas = new SelectList(Construtor.SalaAplicacaoMongo().ListarTodos(), "Id", "Nome");
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Palestra palestra)
        {
            if (ModelState.IsValid)
            {
                var app = Construtor.PalestraAplicacaoMongo();
                palestra.Trilha = Construtor.TrilhaAplicacaoMongo().ListarPorId(palestra.Trilha.Id);
                palestra.Palestrante = Construtor.PalestranteAplicacaoMongo().ListarPorId(palestra.Palestrante.Id);
                palestra.Sala = Construtor.SalaAplicacaoMongo().ListarPorId(palestra.Sala.Id);
                app.Salvar(palestra);
                return RedirectToAction("Index");
            }
            return View(palestra);
        }

        public ActionResult Editar(string id)
        {
            var app = Construtor.PalestraAplicacaoMongo();
            var palestra = app.ListarPorId(id);
            if (palestra == null)
                return HttpNotFound();

            ViewBag.ListaDeTrilhas = new SelectList(Construtor.TrilhaAplicacaoMongo().ListarTodos(), "Id", "Nome", palestra.Trilha.Id);
            ViewBag.ListaDePalestrantes = new SelectList(Construtor.PalestranteAplicacaoMongo().ListarTodos(), "Id", "Nome", palestra.Palestrante.Id);
            ViewBag.ListaDeSalas = new SelectList(Construtor.SalaAplicacaoMongo().ListarTodos(), "Id", "Nome", palestra.Sala.Id);

            return View(palestra);
        }

        [HttpPost]
        public ActionResult Editar(Palestra palestra)
        {
            if (ModelState.IsValid)
            {
                var app = Construtor.PalestraAplicacaoMongo();
                palestra.Trilha = Construtor.TrilhaAplicacaoMongo().ListarPorId(palestra.Trilha.Id);
                palestra.Palestrante = Construtor.PalestranteAplicacaoMongo().ListarPorId(palestra.Palestrante.Id);
                palestra.Sala = Construtor.SalaAplicacaoMongo().ListarPorId(palestra.Sala.Id);
                app.Salvar(palestra);
                return RedirectToAction("Index");
            }
            return View(palestra);

        }

        public ActionResult Deletar(string id)
        {
            var app = Construtor.PalestraAplicacaoMongo();
            var palestra = app.ListarPorId(id);
            if (palestra == null)
                return HttpNotFound();

            return View(palestra);
        }

        [HttpPost, ActionName("Deletar")]
        public ActionResult ConfirmaDeletar(string id)
        {
            //Todo: Não posso excluir palestra se estiver utilizando na palestra
            var app = Construtor.PalestraAplicacaoMongo();
            app.Excluir(id);
            return RedirectToAction("Index");
        }

        public ActionResult Detalhe(string id)
        {
            var app = Construtor.PalestraAplicacaoMongo();
            var palestra = app.ListarPorId(id);
            if (palestra == null)
                return HttpNotFound();

            return View(palestra);
        }

    }
}
