using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KarolCamp.UI.Web.Models;
using KarolCamp.UI.Web.Repositorio;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;

namespace KarolCamp.UI.Web.Aplicacao
{
    public class TrilhaAplicacao
    {
        private readonly Contexto<Trilha> contexto;

        public TrilhaAplicacao()
        {
            contexto = new Contexto<Trilha>();
        }

        public void Salvar(Trilha trilha)
        {
            contexto.Collection.Save(trilha);
        }

        public void Excluir(string id)
        {
            contexto.Collection.Remove(Query.EQ("_id", new ObjectId(id)));
        }

        public IEnumerable<Trilha> ListarTodos()
        {
            return contexto.Collection.AsQueryable();
        }

        public Trilha ListarPorId(string id)
        {
            return contexto.Collection.AsQueryable().FirstOrDefault(x => x.Id == id);
        }

    }
}