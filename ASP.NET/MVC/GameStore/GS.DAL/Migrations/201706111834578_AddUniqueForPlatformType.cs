namespace GS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUniqueForPlatformType : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE PlatformTypes ADD CONSTRAINT Type_Unique Unique(Type);");
        }
        
        public override void Down()
        {
            Sql("ALTER TABLE PlatformTypes DROP CONSTRAINT Type_Unique;");
        }
    }
}
