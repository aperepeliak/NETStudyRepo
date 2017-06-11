namespace GS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPlatformTypeGamesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlatformTypeGames",
                c => new
                    {
                        GameId = c.String(nullable: false, maxLength: 128),
                        PlatformTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GameId, t.PlatformTypeId })
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.PlatformTypes", t => t.PlatformTypeId, cascadeDelete: true)
                .Index(t => t.GameId)
                .Index(t => t.PlatformTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlatformTypeGames", "PlatformTypeId", "dbo.PlatformTypes");
            DropForeignKey("dbo.PlatformTypeGames", "GameId", "dbo.Games");
            DropIndex("dbo.PlatformTypeGames", new[] { "PlatformTypeId" });
            DropIndex("dbo.PlatformTypeGames", new[] { "GameId" });
            DropTable("dbo.PlatformTypeGames");
        }
    }
}
