USE master;

GO
IF DB_ID('StoreDb') IS NOT NULL
   DROP DATABASE StoreDb;

CREATE DATABASE StoreDb;

GO
USE StoreDb;
IF OBJECT_ID('Manufacturer', 'U') IS NOT NULL
	DROP TABLE Manufacturer;

CREATE TABLE dbo.Manufacturer 
	(
		ManufacturerId		INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
		ManufacturerName	NVARCHAR(20) NOT NULL
	);

GO
SET IDENTITY_INSERT dbo.Manufacturer ON;
INSERT INTO dbo.Manufacturer (ManufacturerId, ManufacturerName) 
VALUES 
     (1, 'Samsung'),
	 (2, 'Lenovo'),
	 (3, 'Nokia'),
	 (4, 'Huawei'),
	 (5, 'Sony'),
	 (6, 'LG'),
	 (7, 'Acer'),
	 (8, 'HP'),
	 (9, 'Canon'),
	 (10, 'Asus');
SET IDENTITY_INSERT dbo.Manufacturer OFF;

GO
IF OBJECT_ID('Category', 'U') IS NOT NULL
	DROP TABLE Category;

CREATE TABLE dbo.Category 
	(
		CategoryId		INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
		CategoryName	NVARCHAR(20) NOT NULL
	);

GO 
SET IDENTITY_INSERT dbo.Category ON;
INSERT INTO dbo.Category (CategoryId, CategoryName) 
VALUES 
     (1, 'Smartphone'),
	 (2, 'Laptop'),
	 (3, 'Printer'),
	 (4, 'Telephone');
SET IDENTITY_INSERT dbo.Category OFF;

IF OBJECT_ID('Good', 'U') IS NOT NULL
	DROP TABLE Good;

CREATE TABLE dbo.Good
	(
		GoodId			INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
		GoodName		VARCHAR(100) NOT NULL,
		ManufacturerId	INT FOREIGN KEY REFERENCES dbo.Manufacturer(ManufacturerId), 
		CategoryId		INT FOREIGN KEY REFERENCES dbo.Category(CategoryId), 
		Price			MONEY NOT NULL DEFAULT 0,
		Stock			NUMERIC(18,3) NOT NULL DEFAULT 0
	);

GO
SET IDENTITY_INSERT dbo.Good ON;
INSERT INTO dbo.Good (GoodId, GoodName, ManufacturerId, CategoryId, Price, Stock) 
VALUES 
		(1, 'LaserJet P2035 (CE461A)', 8,3, 5445, 12),
		(2, 'i-SENSYS MF212W with Wi-Fi' ,9,3,3999, 7),
		(3, 'SCX-4650N', 1,3,3999, 15),
		(4, 'DJ1510 (B2L56C)', 8,3,1199, 2),
		(5, 'Transformer Book T100TAF 32GB',10,2, 4999, 11),
		(6, 'Flex 10 (59427902)', 2, 2, 5555, 11),
		(7, 'Aspire ES1-411-C1XZ', 7,2,6399, 7),
		(8, '255 G4 (N0Y69ES)', null, 2, 6199, 5),
		(9, 'ProBook 430 (N0Y70ES)', 8,2,12400, 3),
		(10, 'Ultrabook 535U3', 1, null, 8000,10),
		(11, 'Galaxy S3 Neo Duos I9300i Black', 1,1,3999, 7),
		(12, 'A5000 Black', 2,1,3299, 5),
		(13, 'Lumia 640 XL (Nokia)', 3,1, 4888, 5),
		(14, 'G3s Dual D724 Titan', 6, 1,3999, 0);
SET IDENTITY_INSERT dbo.Good OFF;

GO
IF OBJECT_ID('Role', 'U') IS NOT NULL
	DROP TABLE Role;

CREATE TABLE dbo.Role
	(
		RoleId		INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
		RoleName	NVARCHAR(20) NOT NULL
	);


GO
SET IDENTITY_INSERT dbo.Role ON;
INSERT INTO dbo.Role (RoleId, RoleName) 
VALUES 
     (1, 'SuperAdmin'),
	 (2, 'Admin'),
	 (3, 'Cashier');
SET IDENTITY_INSERT dbo.Role OFF;

GO
IF OBJECT_ID('User', 'U') IS NOT NULL
	DROP TABLE UserProfile;

CREATE TABLE dbo.UserProfile 
	(
		UserId			INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
		UserFirstName	NVARCHAR(50) NOT NULL,
		UserLastName	NVARCHAR(50) NOT NULL,
		UserLogin		NVARCHAR(50),
		UserPassword	NVARCHAR(50),
		RoleId			INT FOREIGN KEY REFERENCES dbo.Role(RoleId)
	);

GO
SET IDENTITY_INSERT dbo.UserProfile ON;
INSERT INTO dbo.UserProfile (UserId, UserFirstName, UserLastName, UserLogin, UserPassword, RoleId) 
VALUES 
     (1, 'Bob', 'Smith', 'SA', 'student', 1);
SET IDENTITY_INSERT dbo.Role OFF;

GO
IF OBJECT_ID('Sale', 'U') IS NOT NULL
	DROP TABLE Sale;

CREATE TABLE dbo.Sale 
	(
		SaleId			INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
		UserId			INT FOREIGN KEY REFERENCES dbo.UserProfile(UserId),
		SaleDate		DATETIME NOT NULL DEFAULT(GetDate()),
		SaleNumber		NVARCHAR(24)  NOT NULL,
		SaleAmount		MONEY NOT NULL DEFAULT(0)
	);

GO
IF OBJECT_ID('SalePos', 'U') IS NOT NULL
	DROP TABLE SalePos;

CREATE TABLE dbo.SalePos 
	(
		SalePosId		INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
		GoodId			INT FOREIGN KEY REFERENCES dbo.Good(GoodId),
		SaleId			INT FOREIGN KEY REFERENCES dbo.Sale(SaleId),
		Quantity		NUMERIC(18, 3) NOT NULL,
		SalePosSum		MONEY NOT NULL DEFAULT(0)
	);

IF OBJECT_ID('Photo', 'U') IS NOT NULL
	DROP TABLE Photo;

CREATE TABLE dbo.Photo 
	(
		PhotoId			INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
		GoodId			INT FOREIGN KEY REFERENCES dbo.Good(GoodId), 
		PhotoPath		NVARCHAR(200) NOT NULL
	);
