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
            //Exclui a foto do palestrante
            var palestrante = ListarPorId(id);
            ExcluirArquivo(palestrante.FotoId);

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

        public string SalvarArquivo(Stream arquivo, string nome, string contentType)
        {
            return contexto.InserirArquivo(arquivo, nome, contentType);
        }
        public void ExcluirArquivo(string idArquivo)
        {
            contexto.ExcluirArquivo(idArquivo);
        }

        public Dictionary<string, string> RetornaArquivo(string id, ref MemoryStream retorno)
        {
            return contexto.BuscarArquivo(id, ref retorno);
        }
    }
}