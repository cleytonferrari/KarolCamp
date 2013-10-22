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
        // GET api/palestra
        public IEnumerable<Palestra> Get()
        {
            return Construtor.PalestraAplicacaoMongo().ListarTodos().ToList();
        }

        // GET api/palestra/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/palestra
        public void Post([FromBody]string value)
        {
        }

        // PUT api/palestra/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/palestra/5
        public void Delete(int id)
        {
        }
    }
}
