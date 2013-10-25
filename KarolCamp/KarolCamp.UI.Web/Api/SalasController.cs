﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KarolCamp.Aplicacao;
using KarolCamp.Dominio;
using Newtonsoft.Json.Linq;

namespace KarolCamp.UI.Web.Api
{
    public class SalasController : ApiController
    {
        // GET api/palestra
        public IEnumerable<Sala> Get()
        {
            return Construtor.SalaAplicacaoMongo().ListarTodos().ToList();
        }

        // GET api/palestra/5
        public Sala Get(string id)
        {
            return Construtor.SalaAplicacaoMongo().ListarPorId(id);
        }

        // POST api/palestra
        public HttpResponseMessage Post(Sala sala)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);

            var app = Construtor.SalaAplicacaoMongo();
            app.Salvar(sala);

            return Request.CreateResponse(HttpStatusCode.Created, sala);
        }

        // PUT api/palestra/5
        public HttpResponseMessage Put(string id, Sala sala)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);

            if (id != sala.Id)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var app = Construtor.SalaAplicacaoMongo();
            var salaBanco = app.ListarPorId(id);
            if (salaBanco == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            app.Salvar(sala);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // DELETE api/palestra/5
        public HttpResponseMessage Delete(string id)
        {
            var app = Construtor.SalaAplicacaoMongo();
            var salaBanco = app.ListarPorId(id);
            if (salaBanco == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            app.Excluir(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
