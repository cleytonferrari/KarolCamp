using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KarolCamp.Aplicacao;
using KarolCamp.Dominio;

namespace KarolCamp.UI.Web.Api
{
    public class PalestrantesController : ApiController
    {
        // GET api/palestrantes
        public IEnumerable<Palestrante> Get()
        {
            return Construtor.PalestranteAplicacaoMongo().ListarTodos().ToList();
        }

        // GET api/palestrantes/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/palestrantes
        public void Post([FromBody]string value)
        {
        }

        // PUT api/palestrantes/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/palestrantes/5
        public void Delete(int id)
        {
        }
    }
}
