using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using KarolCamp.Dominio;

namespace KarolCamp.Repositorio.EF
{
    public class Contexto:DbContext
    {
        public Contexto()
            : base("KarolCampEF")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Contexto>());
        }

        public DbSet<Trilha> Trilhas { get; set; }

        public DbSet<Sala> Salas { get; set; }

        public DbSet<Palestrante> Palestrante { get; set; }

        public DbSet<Palestra> Palestras { get; set; }

        public DbSet<Arquivo> Arquivos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
