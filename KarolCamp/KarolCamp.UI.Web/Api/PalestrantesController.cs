using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using KarolCamp.Aplicacao;
using KarolCamp.Dominio;

namespace KarolCamp.UI.Web.Api
{
    public class PalestrantesController : ApiController
    {
        public IEnumerable<Palestrante> Get()
        {
            return Construtor.PalestranteAplicacaoMongo().ListarTodos().ToList();
        }

        public Palestrante Get(string id)
        {
            return Construtor.PalestranteAplicacaoMongo().ListarPorId(id);
        }

        public HttpResponseMessage Post(Palestrante palestrante, HttpPostedFileBase foto)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);

            var app = Construtor.PalestranteAplicacaoMongo();
            var arquivo = app.SalvarArquivo(foto.InputStream, foto.FileName, foto.ContentType);
            palestrante.FotoId = arquivo;
            app.Salvar(palestrante);

            return Request.CreateResponse(HttpStatusCode.Created, palestrante);
        }

        public HttpResponseMessage Put(string id, Palestrante palestrante, HttpPostedFileBase foto)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);

            if (id != palestrante.Id)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var app = Construtor.PalestranteAplicacaoMongo();
            var palestranteBanco = app.ListarPorId(id);
            if (palestranteBanco == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            if (foto != null)
            {
                app.ExcluirArquivo(palestrante.FotoId);
                var arquivo = app.SalvarArquivo(foto.InputStream, foto.FileName, foto.ContentType);
                palestrante.FotoId = arquivo;
            }
            app.Salvar(palestrante);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public HttpResponseMessage Delete(string id)
        {
            var app = Construtor.PalestranteAplicacaoMongo();
            var palestranteBanco = app.ListarPorId(id);
            if (palestranteBanco == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            app.Excluir(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
