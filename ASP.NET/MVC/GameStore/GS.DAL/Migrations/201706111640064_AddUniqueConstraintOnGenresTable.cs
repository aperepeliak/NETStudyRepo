namespace GS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUniqueConstraintOnGenresTable : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE Genres ADD CONSTRAINT GenresName_Unique Unique(Name);");
        }
        
        public override void Down()
        {
            Sql("ALTER TABLE Genres DROP CONSTRAINT GenresName_Unique;");
        }
    }
}
