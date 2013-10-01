using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using KarolCamp.Dominio;
using KarolCamp.Dominio.Interfaces;
using System.Drawing;

namespace KarolCamp.Repositorio.EF
{
    public class RepositorioArquivo : IRepositorioArquivo
    {
        private readonly Contexto contexto;

        public RepositorioArquivo()
        {
            contexto = new Contexto();
        }

        public string SalvarArquivo(System.IO.Stream arquivo, string nome, string contentType)
        {
            var imagem = new Arquivo
                              {
                                  ContentType = contentType,
                                  Name = nome
                              };

            using (var ms = new MemoryStream())
            {
                arquivo.CopyTo(ms);
                imagem.File = ms.ToArray();
            }
            contexto.Arquivos.Add(imagem);

            contexto.SaveChanges();

            return imagem.Id;
        }

        public void ExcluirArquivo(string idArquivo)
        {
            var palestranteExcluir = contexto.Arquivos.First(x => x.Id == idArquivo);
            contexto.Set<Arquivo>().Remove(palestranteExcluir);
            contexto.SaveChanges();
        }

        public Dictionary<string, string> RetornaArquivo(string id, ref System.IO.MemoryStream retorno)
        {
            var image = contexto.Arquivos.Find(id);
            retorno = new MemoryStream(image.File);
            return new Dictionary<string, string> { { image.ContentType, image.Name } };
        }
    }

    public class Arquivo : Entidade
    {
        public string ContentType { get; set; }
        public string Name { get; set; }
        public byte[] File { get; set; }
    }
}
