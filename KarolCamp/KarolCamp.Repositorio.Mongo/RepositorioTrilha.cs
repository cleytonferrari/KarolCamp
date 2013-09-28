using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarolCamp.Dominio;
using KarolCamp.Dominio.Interfaces;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;

namespace KarolCamp.Repositorio.Mongo
{
    public class RepositorioTrilha:IRepositorio<Trilha>
    {
        private readonly Contexto<Trilha> contexto;

        public RepositorioTrilha()
        {
            contexto = new Contexto<Trilha>();
        }

        public void Salvar(Trilha entidade)
        {
            contexto.Collection.Save(entidade);
        }

        public void Excluir(string id)
        {
            contexto.Collection.Remove(Query.EQ("_id", id));
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
