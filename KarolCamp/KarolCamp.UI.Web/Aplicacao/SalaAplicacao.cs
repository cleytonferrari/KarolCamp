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
    public class SalaAplicacao
    {
        private readonly Contexto<Sala> contexto;

        public SalaAplicacao()
        {
            contexto = new Contexto<Sala>();
        }

        public void Salvar(Sala sala)
        {
            contexto.Collection.Save(sala);
        }

        public void Excluir(string id)
        {
            contexto.Collection.Remove(Query.EQ("_id", id));
        }

        public IEnumerable<Sala> ListarTodos()
        {
            return contexto.Collection.AsQueryable();
        }

        public Sala ListarPorId(string id)
        {
            return contexto.Collection.AsQueryable().FirstOrDefault(x => x.Id == id);
        }

    }
}