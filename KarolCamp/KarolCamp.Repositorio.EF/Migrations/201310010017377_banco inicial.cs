namespace KarolCamp.Repositorio.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bancoinicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Trilha",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sala",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Palestrante",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Nome = c.String(),
                        Twitter = c.String(),
                        Bio = c.String(),
                        FotoId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Palestra",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Titulo = c.String(),
                        Codigo = c.String(),
                        Descricao = c.String(),
                        Nivel = c.String(),
                        Horario = c.DateTime(nullable: false),
                        Palestrante_Id = c.String(maxLength: 128),
                        Trilha_Id = c.String(maxLength: 128),
                        Sala_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Palestrante", t => t.Palestrante_Id)
                .ForeignKey("dbo.Trilha", t => t.Trilha_Id)
                .ForeignKey("dbo.Sala", t => t.Sala_Id)
                .Index(t => t.Palestrante_Id)
                .Index(t => t.Trilha_Id)
                .Index(t => t.Sala_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Palestra", new[] { "Sala_Id" });
            DropIndex("dbo.Palestra", new[] { "Trilha_Id" });
            DropIndex("dbo.Palestra", new[] { "Palestrante_Id" });
            DropForeignKey("dbo.Palestra", "Sala_Id", "dbo.Sala");
            DropForeignKey("dbo.Palestra", "Trilha_Id", "dbo.Trilha");
            DropForeignKey("dbo.Palestra", "Palestrante_Id", "dbo.Palestrante");
            DropTable("dbo.Palestra");
            DropTable("dbo.Palestrante");
            DropTable("dbo.Sala");
            DropTable("dbo.Trilha");
        }
    }
}
