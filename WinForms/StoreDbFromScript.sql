USE [master]
GO
/****** Object:  Database [StoreDb]    Script Date: 21.10.2016 23:23:25 ******/
CREATE DATABASE [StoreDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StoreDb', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\StoreDb.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'StoreDb_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\StoreDb_log.ldf' , SIZE = 1040KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [StoreDb] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StoreDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StoreDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StoreDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StoreDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StoreDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StoreDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [StoreDb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [StoreDb] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [StoreDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StoreDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StoreDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StoreDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StoreDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StoreDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StoreDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StoreDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StoreDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [StoreDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StoreDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StoreDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StoreDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StoreDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StoreDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StoreDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StoreDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [StoreDb] SET  MULTI_USER 
GO
ALTER DATABASE [StoreDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StoreDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StoreDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StoreDb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [StoreDb]
GO
/****** Object:  StoredProcedure [dbo].[InsertSalePos]    Script Date: 21.10.2016 23:23:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertSalePos]
   @SaleId INT, 
   @GoodId INT, 
   @Quantity NUMERIC(18,3)
AS
BEGIN
   DECLARE @Price money = (SELECT Price
                           FROM dbo.Good
                           WHERE GoodId = @GoodId);
   BEGIN TRAN
     BEGIN TRY
   
	   UPDATE dbo.Good
	   SET
	   Stock = Stock - @Quantity
	   WHERE GoodId = @GoodId;
	   
	   INSERT INTO dbo.SalePos(SaleId, GoodId, Quantity, SalePosSum)
	   VALUES (@SaleId, @GoodId, @Quantity, @Quantity * @Price);
	   
	   UPDATE dbo.Sale
	   SET SaleAmount = SaleAmount + @Quantity * @Price
	   WHERE SaleId = @SaleId;
	   COMMIT;
     END TRY
     BEGIN CATCH
       ROLLBACK;
     END CATCH
   
END

GO
/****** Object:  Table [dbo].[Category]    Script Date: 21.10.2016 23:23:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Good]    Script Date: 21.10.2016 23:23:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Good](
	[GoodId] [int] IDENTITY(1,1) NOT NULL,
	[GoodName] [varchar](100) NOT NULL,
	[ManufacturerId] [int] NULL,
	[CategoryId] [int] NULL,
	[Price] [money] NOT NULL,
	[Stock] [numeric](18, 3) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[GoodId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Manufacturer]    Script Date: 21.10.2016 23:23:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manufacturer](
	[ManufacturerId] [int] IDENTITY(1,1) NOT NULL,
	[ManufacturerName] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ManufacturerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Photo]    Script Date: 21.10.2016 23:23:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Photo](
	[PhotoId] [int] IDENTITY(1,1) NOT NULL,
	[GoodId] [int] NULL,
	[PhotoPath] [nvarchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PhotoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Role]    Script Date: 21.10.2016 23:23:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sale]    Script Date: 21.10.2016 23:23:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sale](
	[SaleId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[SaleDate] [datetime] NOT NULL,
	[SaleNumber] [nvarchar](24) NOT NULL,
	[SaleAmount] [money] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SaleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SalePos]    Script Date: 21.10.2016 23:23:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalePos](
	[SalePosId] [int] IDENTITY(1,1) NOT NULL,
	[GoodId] [int] NULL,
	[SaleId] [int] NULL,
	[Quantity] [numeric](18, 3) NOT NULL,
	[SalePosSum] [money] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SalePosId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserProfile]    Script Date: 21.10.2016 23:23:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserProfile](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserFirstName] [nvarchar](50) NOT NULL,
	[UserLastName] [nvarchar](50) NOT NULL,
	[UserLogin] [nvarchar](50) NULL,
	[UserPassword] [nvarchar](50) NULL,
	[RoleId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Good] ADD  DEFAULT ((0)) FOR [Price]
GO
ALTER TABLE [dbo].[Good] ADD  DEFAULT ((0)) FOR [Stock]
GO
ALTER TABLE [dbo].[Sale] ADD  DEFAULT (getdate()) FOR [SaleDate]
GO
ALTER TABLE [dbo].[Sale] ADD  DEFAULT ((0)) FOR [SaleAmount]
GO
ALTER TABLE [dbo].[SalePos] ADD  DEFAULT ((0)) FOR [SalePosSum]
GO
ALTER TABLE [dbo].[Good]  WITH CHECK ADD FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[Good]  WITH CHECK ADD FOREIGN KEY([ManufacturerId])
REFERENCES [dbo].[Manufacturer] ([ManufacturerId])
GO
ALTER TABLE [dbo].[Photo]  WITH CHECK ADD FOREIGN KEY([GoodId])
REFERENCES [dbo].[Good] ([GoodId])
GO
ALTER TABLE [dbo].[Sale]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[UserProfile] ([UserId])
GO
ALTER TABLE [dbo].[SalePos]  WITH CHECK ADD FOREIGN KEY([GoodId])
REFERENCES [dbo].[Good] ([GoodId])
GO
ALTER TABLE [dbo].[SalePos]  WITH CHECK ADD FOREIGN KEY([SaleId])
REFERENCES [dbo].[Sale] ([SaleId])
GO
ALTER TABLE [dbo].[UserProfile]  WITH CHECK ADD FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
GO
ALTER TABLE [dbo].[Good]  WITH CHECK ADD  CONSTRAINT [GoodStock_Check] CHECK  (([Stock]>=(0)))
GO
ALTER TABLE [dbo].[Good] CHECK CONSTRAINT [GoodStock_Check]
GO
USE [master]
GO
ALTER DATABASE [StoreDb] SET  READ_WRITE 
GO
