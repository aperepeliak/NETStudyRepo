// <auto-generated />
namespace GS.DAL.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.1.3-40302")]
    public sealed partial class AddNotNullConstraintsToNameAndBodyInCommentsTable : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(AddNotNullConstraintsToNameAndBodyInCommentsTable));
        
        string IMigrationMetadata.Id
        {
            get { return "201706101151474_AddNotNullConstraintsToNameAndBodyInCommentsTable"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}