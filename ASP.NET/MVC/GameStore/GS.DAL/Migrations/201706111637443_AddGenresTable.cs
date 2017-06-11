namespace GS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenresTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        ParentGenreId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.ParentGenreId)
                .Index(t => t.ParentGenreId);            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Genres", "ParentGenreId", "dbo.Genres");
            DropIndex("dbo.Genres", new[] { "ParentGenreId" });
            DropTable("dbo.Genres");
        }
    }
}
