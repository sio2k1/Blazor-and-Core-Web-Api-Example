USE [master]
GO
/****** Object:  Database [SDV701A2]    Script Date: 19.06.2020 16:48:07 ******/
CREATE DATABASE [SDV701A2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SDV701A2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\SDV701A2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SDV701A2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\SDV701A2_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [SDV701A2] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SDV701A2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SDV701A2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SDV701A2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SDV701A2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SDV701A2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SDV701A2] SET ARITHABORT OFF 
GO
ALTER DATABASE [SDV701A2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SDV701A2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SDV701A2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SDV701A2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SDV701A2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SDV701A2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SDV701A2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SDV701A2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SDV701A2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SDV701A2] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SDV701A2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SDV701A2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SDV701A2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SDV701A2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SDV701A2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SDV701A2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SDV701A2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SDV701A2] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SDV701A2] SET  MULTI_USER 
GO
ALTER DATABASE [SDV701A2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SDV701A2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SDV701A2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SDV701A2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SDV701A2] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SDV701A2] SET QUERY_STORE = OFF
GO
USE [SDV701A2]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 19.06.2020 16:48:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](255) NOT NULL,
	[Description] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientOrder]    Script Date: 19.06.2020 16:48:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientOrder](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[PartsID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [float] NOT NULL,
	[OrderDateTime] [datetime] NOT NULL,
	[ClientName] [varchar](255) NOT NULL,
	[ClientEMail] [varchar](255) NOT NULL,
	[proceeded] [bit] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NPart]    Script Date: 19.06.2020 16:48:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NPart](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[Price] [float] NOT NULL,
	[Currency] [varchar](3) NOT NULL,
	[WiFiStandard] [varchar](255) NULL,
	[EthernetPortType] [varchar](255) NULL,
	[NumberOfPorts] [int] NULL,
	[ClassName] [varchar](255) NOT NULL,
	[QtyInStock] [int] NOT NULL,
	[LastModified] [datetime] NOT NULL,
 CONSTRAINT [PK_parts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubTypes]    Script Date: 19.06.2020 16:48:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubTypes](
	[SubTypeID] [int] IDENTITY(1,1) NOT NULL,
	[SubTypeName] [varchar](255) NOT NULL,
	[SubTypeDescription] [varchar](255) NOT NULL,
 CONSTRAINT [PK_SubTypes] PRIMARY KEY CLUSTERED 
(
	[SubTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ClientOrder]  WITH CHECK ADD  CONSTRAINT [FK_Orders_parts] FOREIGN KEY([PartsID])
REFERENCES [dbo].[NPart] ([id])
GO
ALTER TABLE [dbo].[ClientOrder] CHECK CONSTRAINT [FK_Orders_parts]
GO
ALTER TABLE [dbo].[NPart]  WITH CHECK ADD  CONSTRAINT [FK_NPart_Category] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([id])
GO
ALTER TABLE [dbo].[NPart] CHECK CONSTRAINT [FK_NPart_Category]
GO
/****** Object:  StoredProcedure [dbo].[sp_backup_db]    Script Date: 19.06.2020 16:48:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_backup_db]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	BACKUP DATABASE [WEB701A2] TO  DISK = N'E:\@SkyDrive\SkyDrive\@backup\@nmit\@DBBACKUP\WEB701A2.bak' WITH NOFORMAT, INIT,  NAME = N'WEB701A2-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10
	BACKUP DATABASE [SDV701A2] TO  DISK = N'E:\@SkyDrive\SkyDrive\@backup\@nmit\@DBBACKUP\SDV701A2.bak' WITH NOFORMAT, INIT,  NAME = N'SDV701A2-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10
	BACKUP DATABASE [UPD] TO  DISK = N'E:\@SkyDrive\SkyDrive\@backup\@nmit\@DBBACKUP\UPD.bak' WITH NOFORMAT, INIT,  NAME = N'UPD-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10




END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetCategories]    Script Date: 19.06.2020 16:48:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetCategories] 
AS
BEGIN
	SET NOCOUNT ON;

    select * from Category order by CategoryName
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetCategoriesHash]    Script Date: 19.06.2020 16:48:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetCategoriesHash] 
AS
BEGIN
	SET NOCOUNT ON;
	declare @cats varchar(max)
	SELECT @cats= STRING_AGG (CategoryName, '') WITHIN GROUP ( ORDER BY CategoryName ) FROM Category 
    select CONVERT(varchar(255),HASHBYTES('SHA1',@cats),2) as result
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetOrders]    Script Date: 19.06.2020 16:48:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetOrders]

AS
BEGIN
	SET NOCOUNT ON;
	select co.*, p.Name, p.Currency, co.price*co.quantity as Summ from ClientOrder co left join NPart p on co.PartsID=p.id
  
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetPartById]    Script Date: 19.06.2020 16:48:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetPartById] @id int
AS
BEGIN
	SET NOCOUNT ON;
	select * from NPart where id = @id  
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetPartsByCategoryId]    Script Date: 19.06.2020 16:48:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetPartsByCategoryId] @CategoryId int

AS
BEGIN
	SET NOCOUNT ON;
	if (@CategoryId=-1) begin
		select * from Npart
	end else
	begin
		select * from Npart where CategoryID=@CategoryId
	end
END
GO
/****** Object:  StoredProcedure [dbo].[sp_PlaceOrder]    Script Date: 19.06.2020 16:48:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_PlaceOrder]  @PartsId int, @PartsQty int, @ClientName varchar(255), @ClientEmail varchar(255)
AS
BEGIN
	SET NOCOUNT ON;
	
	

	declare @qtyLeft int
	declare @currentPrice int
	select @qtyleft=isnull(QtyInStock,0), @currentPrice=isnull(Price,0) from Npart where id=@PartsId
	if @PartsQty<=0 begin
		RAISERROR('Quantity must be more than 0.',16,1)
	end

	if @currentPrice=0 begin
		RAISERROR('Item price is not set correctly.',16,1)
	end

	if @qtyLeft>=@PartsQty 
	begin
		begin transaction
			update Npart set QtyInStock=QtyInStock-@PartsQty where id=@PartsId and QtyInStock>=@PartsQty
			if (@@ROWCOUNT=1) begin
				INSERT INTO [dbo].[ClientOrder]
				   ([PartsID]
				   ,[Quantity]
				   ,[Price]
				   ,[OrderDateTime]
				   ,[ClientName]
				   ,[ClientEMail]
				   ,[proceeded])
				VALUES
				   (@PartsId
				   ,@PartsQty
				   ,@currentPrice
				   ,GETDATE()
				   ,@ClientName
				   ,@ClientEmail
				   ,0)
				SELECT CAST(scope_identity() AS int)
			end else
			begin
				RAISERROR('Out of stock.',16,1)
			end
		commit transaction
	end	else
	begin
		RAISERROR('Out of stock.',16,1)
	end


	


END
GO
USE [master]
GO
ALTER DATABASE [SDV701A2] SET  READ_WRITE 
GO
