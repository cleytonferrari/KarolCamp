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
    public class PalestrasController : ApiController
    {
        public IEnumerable<Palestra> Get()
        {
            return Construtor.PalestraAplicacaoMongo().ListarTodos().ToList();
        }

        public string Get(int id)
        {
            return "value";
        }

        public void Post([FromBody]string value)
        {
        }

        public void Put(int id, [FromBody]string value)
        {
        }

        public void Delete(int id)
        {
        }
    }
}
