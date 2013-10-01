using System.Collections.Generic;
using System.Linq;
using KarolCamp.Dominio;
using KarolCamp.Dominio.Interfaces;

namespace KarolCamp.Repositorio.EF
{
    public class RepositorioPalestra : IRepositorio<Palestra>
    {
        private readonly Contexto contexto;

        public RepositorioPalestra()
        {
            contexto = new Contexto();
        }

        public void Salvar(Palestra entidade)
        {
            var palestraBanco = contexto.Palestras.FirstOrDefault(x => x.Id == entidade.Id);

            if (palestraBanco == null)
            {
                entidade.Palestrante = contexto.Palestrante.FirstOrDefault(x => x.Id == entidade.Palestrante.Id);
                entidade.Sala = contexto.Salas.FirstOrDefault(x => x.Id == entidade.Sala.Id);
                entidade.Trilha = contexto.Trilhas.FirstOrDefault(x => x.Id == entidade.Trilha.Id);
                contexto.Palestras.Add(entidade);
            }
            else
            {
                palestraBanco = new Palestra();
                palestraBanco.Codigo = entidade.Codigo;
                palestraBanco.Titulo = entidade.Titulo;
                palestraBanco.Descricao = entidade.Descricao;
                palestraBanco.Horario = entidade.Horario;
                palestraBanco.Nivel = entidade.Nivel;
                palestraBanco.Palestrante = contexto.Palestrante.FirstOrDefault(x => x.Id == entidade.Palestrante.Id);
                palestraBanco.Sala = contexto.Salas.FirstOrDefault(x => x.Id == entidade.Sala.Id);
                palestraBanco.Trilha = contexto.Trilhas.FirstOrDefault(x => x.Id == entidade.Trilha.Id);
            }

            contexto.SaveChanges();
        }

        public void Excluir(string id)
        {
            var palestranteExcluir = contexto.Palestras.First(x => x.Id == id);
            contexto.Set<Palestra>().Remove(palestranteExcluir);
            contexto.SaveChanges();
        }

        public IEnumerable<Palestra> ListarTodos()
        {
            return contexto.Palestras
                .Include("Trilha")
                .Include("Sala")
                .Include("Palestrante");
        }

        public Palestra ListarPorId(string id)
        {
            return contexto.Palestras
                .Include("Trilha")
                .Include("Sala")
                .Include("Palestrante")
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
