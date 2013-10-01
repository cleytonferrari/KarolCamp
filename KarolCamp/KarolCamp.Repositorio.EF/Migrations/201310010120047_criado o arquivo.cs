namespace KarolCamp.Repositorio.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class criadooarquivo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Arquivo",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ContentType = c.String(),
                        Name = c.String(),
                        File = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Arquivo");
        }
    }
}
