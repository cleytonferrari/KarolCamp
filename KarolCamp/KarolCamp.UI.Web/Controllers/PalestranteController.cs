using System.Web;
using System.Web.Mvc;
using KarolCamp.Aplicacao;
using KarolCamp.Dominio;

namespace KarolCamp.UI.Web.Controllers
{
    public class PalestranteController : Controller
    {
        //
        // GET: /Palestrante/

        public ActionResult Index()
        {
            var app = Construtor.PalestranteAplicacaoMongo();
            return View(app.ListarTodos());
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Palestrante palestrante, HttpPostedFileBase foto)
        {
            if (ModelState.IsValid)
            {
                var app = Construtor.PalestranteAplicacaoMongo();
                var arquivo = app.SalvarArquivo(foto.InputStream, foto.FileName, foto.ContentType);
                palestrante.FotoId = arquivo;
                app.Salvar(palestrante);
                return RedirectToAction("Index");
            }
            return View(palestrante);
        }

        public ActionResult Editar(string id)
        {
            var app = Construtor.PalestranteAplicacaoMongo();
            var palestrante = app.ListarPorId(id);
            if (palestrante == null)
                return HttpNotFound();

            return View(palestrante);
        }

        [HttpPost]
        public ActionResult Editar(Palestrante palestrante, HttpPostedFileBase foto)
        {
            if (ModelState.IsValid)
            {
                var app = Construtor.PalestranteAplicacaoMongo();
                if (foto != null)
                {
                    app.ExcluirArquivo(palestrante.FotoId);
                    var arquivo = app.SalvarArquivo(foto.InputStream, foto.FileName, foto.ContentType);
                    palestrante.FotoId = arquivo;
                }

                app.Salvar(palestrante);
                return RedirectToAction("Index");
            }
            return View(palestrante);

        }

        public ActionResult Deletar(string id)
        {
            var app = Construtor.PalestranteAplicacaoMongo();
            var palestrante = app.ListarPorId(id);
            if (palestrante == null)
                return HttpNotFound();

            return View(palestrante);
        }

        [HttpPost, ActionName("Deletar")]
        public ActionResult ConfirmaDeletar(string id)
        {
            //Todo: Não posso excluir palestrante se estiver utilizando na palestra
            var app = Construtor.PalestranteAplicacaoMongo();
            app.Excluir(id);
            return RedirectToAction("Index");
        }

        public ActionResult Detalhe(string id)
        {
            var app = Construtor.PalestranteAplicacaoMongo();
            var palestrante = app.ListarPorId(id);
            if (palestrante == null)
                return HttpNotFound();

            return View(palestrante);
        }

    }
}
