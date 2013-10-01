using System.Collections.Generic;
using System.Linq;
using KarolCamp.Dominio;
using KarolCamp.Dominio.Interfaces;

namespace KarolCamp.Repositorio.EF
{
    public class RepositorioPalestrante: IRepositorio<Palestrante>
    {
        private readonly Contexto contexto;

        public RepositorioPalestrante()
        {
            contexto = new Contexto();
        }

        public void Salvar(Palestrante entidade)
        {
            var palestranteBanco = contexto.Palestrante.FirstOrDefault(x => x.Id == entidade.Id);

            if (palestranteBanco == null)
            {
                contexto.Palestrante.Add(entidade);
            }
            else
            {
                palestranteBanco = new Palestrante();
                palestranteBanco.Nome = entidade.Nome;
                palestranteBanco.Bio = entidade.Bio;
                palestranteBanco.Twitter = entidade.Twitter;
                palestranteBanco.FotoId = entidade.FotoId;
            }

            contexto.SaveChanges();
        }

        public void Excluir(string id)
        {
            var palestranteExcluir = contexto.Palestrante.First(x => x.Id == id);
            contexto.Set<Palestrante>().Remove(palestranteExcluir);
            contexto.SaveChanges();
        }

        public IEnumerable<Palestrante> ListarTodos()
        {
            return contexto.Palestrante;
        }

        public Palestrante ListarPorId(string id)
        {
            return contexto.Palestrante.FirstOrDefault(x => x.Id == id);
        }
    }
}
