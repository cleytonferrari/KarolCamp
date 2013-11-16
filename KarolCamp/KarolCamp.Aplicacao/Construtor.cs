using KarolCamp.Dominio;
using KarolCamp.Dominio.Interfaces;
using KarolCamp.Security;

namespace KarolCamp.Aplicacao
{
    public class Construtor
    {
        public static PalestraAplicacao PalestraAplicacaoMongo()
        {
            return new PalestraAplicacao(new Repositorio.Mongo.RepositorioPalestra());
        }

        public static PalestraAplicacao PalestraAplicacaoEF()
        {
            return new PalestraAplicacao(new Repositorio.EF.RepositorioPalestra());
        }

        public static PalestranteAplicacao PalestranteAplicacaoMongo()
        {
            return new PalestranteAplicacao(new Repositorio.Mongo.RepositorioPalestrante(), new Repositorio.Mongo.RepositorioArquivo());
        }

        public static PalestranteAplicacao PalestranteAplicacaoEF()
        {
            return new PalestranteAplicacao(new Repositorio.EF.RepositorioPalestrante(), new Repositorio.EF.RepositorioArquivo());
        }

        public static SalaAplicacao SalaAplicacaoMongo()
        {
            return new SalaAplicacao(new Repositorio.Mongo.RepositorioSala());
        }

        public static SalaAplicacao SalaAplicacaoEF()
        {
            return new SalaAplicacao(new Repositorio.EF.RepositorioSala());
        }

        public static TrilhaAplicacao TrilhaAplicacaoMongo()
        {
            return new TrilhaAplicacao(new Repositorio.Mongo.RepositorioTrilha());
        }

        public static TrilhaAplicacao TrilhaAplicacaoEF()
        {
            return new TrilhaAplicacao(new Repositorio.EF.RepositorioTrilha());
        }

        public static IRepositorio<Usuario> UsuarioAplicacaoMongo()
        {
            return new Repositorio.Mongo.RepositorioUsuario();
        }
    }
}
