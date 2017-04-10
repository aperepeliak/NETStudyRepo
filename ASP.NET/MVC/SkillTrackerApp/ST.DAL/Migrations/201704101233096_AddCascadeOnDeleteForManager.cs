namespace ST.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCascadeOnDeleteForManager : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Managers", "ManagerId", "dbo.AspNetUsers");
            AddForeignKey("dbo.Managers", "ManagerId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Managers", "ManagerId", "dbo.AspNetUsers");
            AddForeignKey("dbo.Managers", "ManagerId", "dbo.AspNetUsers", "Id");
        }
    }
}
