using KarolCamp.Repositorio.Mongo;

namespace KarolCamp.Aplicacao
{
    public class Construtor
    {
        public static PalestraAplicacao PalestraAplicacaoMongo()
        {
            return new PalestraAplicacao(new RepositorioPalestra());
        }

        public static PalestranteAplicacao PalestranteAplicacaoMongo()
        {
            return new PalestranteAplicacao(new RepositorioPalestrante(), new RepositorioArquivo());
        }

        public static SalaAplicacao SalaAplicacaoMongo()
        {
            return new SalaAplicacao(new RepositorioSala());
        }

        public static TrilhaAplicacao TrilhaAplicacaoMongo()
        {
            return new TrilhaAplicacao(new RepositorioTrilha());
        }
    }
}
