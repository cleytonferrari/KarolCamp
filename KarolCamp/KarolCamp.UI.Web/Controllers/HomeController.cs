using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KarolCamp.UI.Web.Aplicacao;

namespace KarolCamp.UI.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Arquivo(string id)
        {
            var ms = new MemoryStream();

            var arquivo = new PalestranteAplicacao().RetornaArquivo(id, ref ms);

            var contentType = arquivo.FirstOrDefault().Key;
            return new FileContentResult(ms.ToArray(), contentType);
        }
    }
}
