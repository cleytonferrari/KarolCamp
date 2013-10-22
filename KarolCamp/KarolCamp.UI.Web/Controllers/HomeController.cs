using System.IO;
using System.Linq;
using System.Web.Mvc;
using KarolCamp.Aplicacao;

namespace KarolCamp.UI.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewBag.Palestrantes = Construtor.PalestranteAplicacaoMongo().ListarTodos().ToList();
            ViewBag.Palestras = Construtor.PalestraAplicacaoMongo().ListarTodos().ToList();
            return View();
        }

        public ActionResult Arquivo(string id)
        {
            var ms = new MemoryStream();

            var arquivo = Construtor.PalestranteAplicacaoMongo().RetornaArquivo(id, ref ms);

            var contentType = arquivo.FirstOrDefault().Key;
            return new FileContentResult(ms.ToArray(), contentType);
        }
    }
}
