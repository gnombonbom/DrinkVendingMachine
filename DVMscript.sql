USE [master]
GO
/****** Object:  Database [DrinkVendingMachine]    Script Date: 09.02.2022 15:38:01 ******/
CREATE DATABASE [DrinkVendingMachine]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DrinkVendingMachine', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DrinkVendingMachine.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DrinkVendingMachine_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DrinkVendingMachine_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DrinkVendingMachine] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DrinkVendingMachine].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DrinkVendingMachine] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DrinkVendingMachine] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DrinkVendingMachine] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DrinkVendingMachine] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DrinkVendingMachine] SET ARITHABORT OFF 
GO
ALTER DATABASE [DrinkVendingMachine] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DrinkVendingMachine] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DrinkVendingMachine] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DrinkVendingMachine] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DrinkVendingMachine] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DrinkVendingMachine] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DrinkVendingMachine] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DrinkVendingMachine] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DrinkVendingMachine] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DrinkVendingMachine] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DrinkVendingMachine] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DrinkVendingMachine] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DrinkVendingMachine] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DrinkVendingMachine] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DrinkVendingMachine] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DrinkVendingMachine] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DrinkVendingMachine] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DrinkVendingMachine] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DrinkVendingMachine] SET  MULTI_USER 
GO
ALTER DATABASE [DrinkVendingMachine] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DrinkVendingMachine] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DrinkVendingMachine] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DrinkVendingMachine] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DrinkVendingMachine] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DrinkVendingMachine] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [DrinkVendingMachine] SET QUERY_STORE = OFF
GO
USE [DrinkVendingMachine]
GO
/****** Object:  Table [dbo].[coin]    Script Date: 09.02.2022 15:38:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[coin](
	[id] [uniqueidentifier] NOT NULL,
	[denomination] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[drink]    Script Date: 09.02.2022 15:38:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[drink](
	[id] [uniqueidentifier] NULL,
	[name] [varchar](50) NOT NULL,
	[image] [varbinary](max) NOT NULL,
	[cost] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vendingmachine]    Script Date: 09.02.2022 15:38:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vendingmachine](
	[id] [uniqueidentifier] NOT NULL,
	[secretcode] [varchar](10) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vmcoin]    Script Date: 09.02.2022 15:38:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vmcoin](
	[id] [uniqueidentifier] NOT NULL,
	[vmid] [uniqueidentifier] NOT NULL,
	[coinid] [uniqueidentifier] NOT NULL,
	[count] [int] NOT NULL,
	[isactive] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vmdrink]    Script Date: 09.02.2022 15:38:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vmdrink](
	[id] [uniqueidentifier] NOT NULL,
	[vmid] [uniqueidentifier] NOT NULL,
	[drinkid] [uniqueidentifier] NOT NULL,
	[count] [int] NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[coin] ([id], [denomination]) VALUES (N'08cdbf10-6c53-44a9-8ded-3f3c78f57171', 1)
INSERT [dbo].[coin] ([id], [denomination]) VALUES (N'b14aa2be-1821-484d-b16a-1b3555456a32', 2)
INSERT [dbo].[coin] ([id], [denomination]) VALUES (N'9096b2e6-6eae-494f-816f-a6d0e2cc36f8', 5)
INSERT [dbo].[coin] ([id], [denomination]) VALUES (N'74ddf375-ac83-4ebc-a2eb-a4be4851b3d4', 10)
GO
INSERT [dbo].[vendingmachine] ([id], [secretcode]) VALUES (N'50d5ed51-d49c-4bd6-b843-0a498b1dd003', N'12331213')
GO
INSERT [dbo].[vmcoin] ([id], [vmid], [coinid], [count], [isactive]) VALUES (N'ba5728c2-c274-4cbf-a615-8a09d4e2722e', N'50d5ed51-d49c-4bd6-b843-0a498b1dd003', N'08cdbf10-6c53-44a9-8ded-3f3c78f57171', 10, 1)
INSERT [dbo].[vmcoin] ([id], [vmid], [coinid], [count], [isactive]) VALUES (N'23105a06-c561-45a5-ad47-73b708dc0a41', N'50d5ed51-d49c-4bd6-b843-0a498b1dd003', N'b14aa2be-1821-484d-b16a-1b3555456a32', 15, 1)
INSERT [dbo].[vmcoin] ([id], [vmid], [coinid], [count], [isactive]) VALUES (N'fe1c0a59-27b7-4b1f-a746-25b69af0a8ca', N'50d5ed51-d49c-4bd6-b843-0a498b1dd003', N'9096b2e6-6eae-494f-816f-a6d0e2cc36f8', 25, 1)
INSERT [dbo].[vmcoin] ([id], [vmid], [coinid], [count], [isactive]) VALUES (N'8ed516e2-3038-484f-b102-fb091a325f98', N'50d5ed51-d49c-4bd6-b843-0a498b1dd003', N'74ddf375-ac83-4ebc-a2eb-a4be4851b3d4', 15, 1)
GO
USE [master]
GO
ALTER DATABASE [DrinkVendingMachine] SET  READ_WRITE 
GO
