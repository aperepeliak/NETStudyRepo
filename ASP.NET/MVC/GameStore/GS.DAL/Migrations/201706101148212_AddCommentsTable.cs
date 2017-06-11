namespace GS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCommentsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Body = c.String(maxLength: 500),
                        GameId = c.String(nullable: false, maxLength: 128),
                        ParentCommentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.Comments", t => t.ParentCommentId)
                .Index(t => t.GameId)
                .Index(t => t.ParentCommentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "ParentCommentId", "dbo.Comments");
            DropForeignKey("dbo.Comments", "GameId", "dbo.Games");
            DropIndex("dbo.Comments", new[] { "ParentCommentId" });
            DropIndex("dbo.Comments", new[] { "GameId" });
            DropTable("dbo.Comments");
        }
    }
}
