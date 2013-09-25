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
    public class PalestranteAplicacao
    {
        private readonly Contexto<Palestrante> contexto;

        public PalestranteAplicacao()
        {
            contexto = new Contexto<Palestrante>();
        }

        public void Salvar(Palestrante palestrante)
        {
            contexto.Collection.Save(palestrante);
        }

        public void Excluir(string id)
        {
            contexto.Collection.Remove(Query.EQ("_id", id));
        }

        public IEnumerable<Palestrante> ListarTodos()
        {
            return contexto.Collection.AsQueryable();
        }

        public Palestrante ListarPorId(string id)
        {
            return contexto.Collection.AsQueryable().FirstOrDefault(x => x.Id == id);
        }

    }
}