namespace ST.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCascadeOnDeleteForDeveloper : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Developers", "DeveloperId", "dbo.AspNetUsers");
            AddForeignKey("dbo.Developers", "DeveloperId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Developers", "DeveloperId", "dbo.AspNetUsers");
            AddForeignKey("dbo.Developers", "DeveloperId", "dbo.AspNetUsers", "Id");
        }
    }
}
