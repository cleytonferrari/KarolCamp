using System.Collections.Generic;
using System.Linq;
using KarolCamp.Dominio;
using KarolCamp.Dominio.Interfaces;

namespace KarolCamp.Repositorio.EF
{
    public class RepositorioTrilha: IRepositorio<Trilha>
    {
        private readonly Contexto contexto;

        public RepositorioTrilha()
        {
            contexto = new Contexto();
        }

        public void Salvar(Trilha entidade)
        {
            var trilhaBanco = contexto.Trilhas.FirstOrDefault(x => x.Id == entidade.Id);

            if (trilhaBanco == null)
            {
                contexto.Trilhas.Add(entidade);
            }
            else
            {
                trilhaBanco.Nome = entidade.Nome;
            }

            contexto.SaveChanges();
        }

        public void Excluir(string id)
        {
            var trilhaExcluir = contexto.Trilhas.First(x => x.Id == id);
            contexto.Set<Trilha>().Remove(trilhaExcluir);
            contexto.SaveChanges();
        }

        public IEnumerable<Trilha> ListarTodos()
        {
            return contexto.Trilhas;
        }

        public Trilha ListarPorId(string id)
        {
            return contexto.Trilhas.FirstOrDefault(x => x.Id == id);
        }
    }
}
