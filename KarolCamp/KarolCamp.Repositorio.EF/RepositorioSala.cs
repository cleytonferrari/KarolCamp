using System.Collections.Generic;
using System.Linq;
using KarolCamp.Dominio;
using KarolCamp.Dominio.Interfaces;

namespace KarolCamp.Repositorio.EF
{
    public class RepositorioSala: IRepositorio<Sala>
    {
        private readonly Contexto contexto;

        public RepositorioSala()
        {
            contexto = new Contexto();
        }

        public void Salvar(Sala entidade)
        {
            var salaBanco = contexto.Salas.FirstOrDefault(x => x.Id == entidade.Id);

            if (salaBanco == null)
            {
                contexto.Salas.Add(entidade);
            }
            else
            {
                salaBanco = new Sala();
                salaBanco.Nome = entidade.Nome;
            }

            contexto.SaveChanges();
        }

        public void Excluir(string id)
        {
            var salaExcluir = contexto.Salas.First(x => x.Id == id);
            contexto.Set<Sala>().Remove(salaExcluir);
            contexto.SaveChanges();
        }

        public IEnumerable<Sala> ListarTodos()
        {
            return contexto.Salas;
        }

        public Sala ListarPorId(string id)
        {
            return contexto.Salas.FirstOrDefault(x => x.Id == id);
        }
    }
}
