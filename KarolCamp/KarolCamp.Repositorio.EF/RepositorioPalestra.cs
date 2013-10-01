using System.Collections.Generic;
using System.Linq;
using KarolCamp.Dominio;
using KarolCamp.Dominio.Interfaces;

namespace KarolCamp.Repositorio.EF
{
    public class RepositorioPalestra: IRepositorio<Palestra>
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
                contexto.Palestras.Add(entidade);
            }
            else
            {
                palestraBanco.Codigo = entidade.Codigo;
                palestraBanco.Titulo = entidade.Titulo;
                palestraBanco.Descricao = entidade.Descricao;
                palestraBanco.Horario = entidade.Horario;
                palestraBanco.Nivel = entidade.Nivel;
                //tem que configurar os relacionamentos do entity
                /*palestraBanco.Palestrante = entidade.Palestrante;
                palestraBanco.Sala = entidade.Sala;
                palestraBanco.Trilha = entidade.Trilha;*/

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
            return contexto.Palestras;
        }

        public Palestra ListarPorId(string id)
        {
            return contexto.Palestras.FirstOrDefault(x => x.Id == id);
        }
    }
}
