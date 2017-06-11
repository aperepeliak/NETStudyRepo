namespace GS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBasicGenres : DbMigration
    {
        public override void Up()
        {
            Sql(
        @"SET IDENTITY_INSERT [dbo].[Genres] ON 
            GO
            INSERT [dbo].[Genres] ([Id], [Name], [ParentGenreId]) VALUES (1, N'Strategy', NULL)
            GO
            INSERT [dbo].[Genres] ([Id], [Name], [ParentGenreId]) VALUES (2, N'RPG', NULL)
            GO
            INSERT [dbo].[Genres] ([Id], [Name], [ParentGenreId]) VALUES (3, N'Sports', NULL)
            GO
            INSERT [dbo].[Genres] ([Id], [Name], [ParentGenreId]) VALUES (4, N'Races', NULL)
            GO
            INSERT [dbo].[Genres] ([Id], [Name], [ParentGenreId]) VALUES (5, N'Action', NULL)
            GO
            INSERT [dbo].[Genres] ([Id], [Name], [ParentGenreId]) VALUES (6, N'Adventure', NULL)
            GO
            INSERT [dbo].[Genres] ([Id], [Name], [ParentGenreId]) VALUES (7, N'Puzzle&Skill', NULL)
            GO
            INSERT [dbo].[Genres] ([Id], [Name], [ParentGenreId]) VALUES (8, N'Misc', NULL)
            GO
            INSERT [dbo].[Genres] ([Id], [Name], [ParentGenreId]) VALUES (9, N'RTS', 1)
            GO
            INSERT [dbo].[Genres] ([Id], [Name], [ParentGenreId]) VALUES (10, N'TBS', 1)
            GO
            INSERT [dbo].[Genres] ([Id], [Name], [ParentGenreId]) VALUES (11, N'Rally', 4)
            GO
            INSERT [dbo].[Genres] ([Id], [Name], [ParentGenreId]) VALUES (12, N'Arcade', 4)
            GO
            INSERT [dbo].[Genres] ([Id], [Name], [ParentGenreId]) VALUES (13, N'Formula', 4)
            GO
            INSERT [dbo].[Genres] ([Id], [Name], [ParentGenreId]) VALUES (14, N'Offroad', 4)
            GO
            INSERT [dbo].[Genres] ([Id], [Name], [ParentGenreId]) VALUES (15, N'FPS', 5)
            GO
            INSERT [dbo].[Genres] ([Id], [Name], [ParentGenreId]) VALUES (16, N'TPS', 5)
            GO
            SET IDENTITY_INSERT [dbo].[Genres] OFF"
        );
        }

        public override void Down()
        {
            Sql("DELETE FROM Genres");
        }
    }
}
