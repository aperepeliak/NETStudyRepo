namespace GS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(maxLength: 50),
                        Description = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);

            Sql("ALTER TABLE Games ADD CONSTRAINT GamesId_Default DEFAULT NEWID() FOR Id;");
        }
        
        public override void Down()
        {
            DropTable("dbo.Games");
        }
    }
}
