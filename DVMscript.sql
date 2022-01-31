USE [master]
GO
/****** Object:  Database [DrinkVendingMachine]    Script Date: 31.01.2022 12:50:39 ******/
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
/****** Object:  Table [dbo].[coin]    Script Date: 31.01.2022 12:50:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[coin](
	[id] [int] NOT NULL,
	[denomination] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[drink]    Script Date: 31.01.2022 12:50:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[drink](
	[id] [int] NOT NULL,
	[code] [varchar](2) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[image] [varbinary](max) NOT NULL,
	[cost] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vendingmachine]    Script Date: 31.01.2022 12:50:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vendingmachine](
	[id] [int] NOT NULL,
	[secretcode] [varchar](10) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vmcoin]    Script Date: 31.01.2022 12:50:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vmcoin](
	[id] [int] NOT NULL,
	[vmid] [int] NOT NULL,
	[coinid] [int] NOT NULL,
	[count] [int] NOT NULL,
	[isactive] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vmdrink]    Script Date: 31.01.2022 12:50:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vmdrink](
	[id] [int] NOT NULL,
	[vmid] [int] NOT NULL,
	[drinkid] [int] NOT NULL,
	[count] [int] NOT NULL
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [DrinkVendingMachine] SET  READ_WRITE 
GO
