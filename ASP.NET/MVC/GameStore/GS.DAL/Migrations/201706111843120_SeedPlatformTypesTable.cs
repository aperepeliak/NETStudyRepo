namespace GS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedPlatformTypesTable : DbMigration
    {
        public override void Up()
        {
            Sql(
                @"SET IDENTITY_INSERT [dbo].[PlatformTypes] ON  
                GO
                INSERT [dbo].[PlatformTypes] ([Id], [Type]) VALUES (2, N'Browser')
                GO
                INSERT [dbo].[PlatformTypes] ([Id], [Type]) VALUES (4, N'Console')
                GO
                INSERT [dbo].[PlatformTypes] ([Id], [Type]) VALUES (3, N'Desktop')
                GO
                INSERT [dbo].[PlatformTypes] ([Id], [Type]) VALUES (1, N'Mobile')
                GO
                SET IDENTITY_INSERT [dbo].[PlatformTypes] OFF"
                );
        }

        public override void Down()
        {
            Sql("DELETE FROM PlatformTypes");
        }
    }
}
