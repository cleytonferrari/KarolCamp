using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using KarolCamp.UI.Web.Models;
using KarolCamp.UI.Web.Repositorio;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;

namespace KarolCamp.UI.Web.Aplicacao
{
    public class PalestraAplicacao
    {
        private readonly Contexto<Palestra> contexto;

        public PalestraAplicacao()
        {
            contexto = new Contexto<Palestra>();
        }

        public void Salvar(Palestra palestra)
        {
            contexto.Collection.Save(palestra);
        }

        public void Excluir(string id)
        {

            contexto.Collection.Remove(Query.EQ("_id", id));
        }

        public IEnumerable<Palestra> ListarTodos()
        {
            return contexto.Collection.AsQueryable();
        }

        public Palestra ListarPorId(string id)
        {
            return contexto.Collection.AsQueryable().FirstOrDefault(x => x.Id == id);
        }
    }
}