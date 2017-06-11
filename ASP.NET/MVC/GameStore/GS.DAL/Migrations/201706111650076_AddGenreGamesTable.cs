namespace GS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreGamesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GenreGames",
                c => new
                    {
                        GameId = c.String(nullable: false, maxLength: 128),
                        GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GameId, t.GenreId })
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.GameId)
                .Index(t => t.GenreId);          
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GenreGames", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.GenreGames", "GameId", "dbo.Games");
            DropIndex("dbo.GenreGames", new[] { "GenreId" });
            DropIndex("dbo.GenreGames", new[] { "GameId" });
            DropTable("dbo.GenreGames");
        }
    }
}
