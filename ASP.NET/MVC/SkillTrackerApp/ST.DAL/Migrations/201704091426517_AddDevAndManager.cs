namespace ST.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDevAndManager : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Developers",
                c => new
                    {
                        DeveloperId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.DeveloperId)
                .ForeignKey("dbo.AspNetUsers", t => t.DeveloperId)
                .Index(t => t.DeveloperId);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        ManagerId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ManagerId)
                .ForeignKey("dbo.AspNetUsers", t => t.ManagerId)
                .Index(t => t.ManagerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Managers", "ManagerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Developers", "DeveloperId", "dbo.AspNetUsers");
            DropIndex("dbo.Managers", new[] { "ManagerId" });
            DropIndex("dbo.Developers", new[] { "DeveloperId" });
            DropTable("dbo.Managers");
            DropTable("dbo.Developers");
        }
    }
}
