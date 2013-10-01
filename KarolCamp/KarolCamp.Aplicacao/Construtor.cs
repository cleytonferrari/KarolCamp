

using KarolCamp.Repositorio.Mongo;

namespace KarolCamp.Aplicacao
{
    public class Construtor
    {
        public static PalestraAplicacao PalestraAplicacaoMongo()
        {
            //return new PalestraAplicacao(new RepositorioPalestra());
            return new PalestraAplicacao(new Repositorio.EF.RepositorioPalestra());
        }

        public static PalestranteAplicacao PalestranteAplicacaoMongo()
        {
            //return new PalestranteAplicacao(new RepositorioPalestrante(), new RepositorioArquivo());
            return new PalestranteAplicacao(new Repositorio.EF.RepositorioPalestrante(), new Repositorio.EF.RepositorioArquivo());
        }

        public static SalaAplicacao SalaAplicacaoMongo()
        {
            //return new SalaAplicacao(new RepositorioSala());
            return new SalaAplicacao(new Repositorio.EF.RepositorioSala());
        }

        public static TrilhaAplicacao TrilhaAplicacaoMongo()
        {
            //return new TrilhaAplicacao(new RepositorioTrilha());
            return new TrilhaAplicacao(new Repositorio.EF.RepositorioTrilha());
        }
    }
}
