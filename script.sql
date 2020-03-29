USE [master]
GO
/****** Object:  Database [Assignment4]    Script Date: 3/29/2020 8:44:08 PM ******/
CREATE DATABASE [Assignment4]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Assignment4', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS2012\MSSQL\DATA\Assignment4.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Assignment4_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS2012\MSSQL\DATA\Assignment4_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Assignment4] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Assignment4].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Assignment4] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Assignment4] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Assignment4] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Assignment4] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Assignment4] SET ARITHABORT OFF 
GO
ALTER DATABASE [Assignment4] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Assignment4] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Assignment4] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Assignment4] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Assignment4] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Assignment4] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Assignment4] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Assignment4] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Assignment4] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Assignment4] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Assignment4] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Assignment4] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Assignment4] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Assignment4] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Assignment4] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Assignment4] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Assignment4] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Assignment4] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Assignment4] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Assignment4] SET  MULTI_USER 
GO
ALTER DATABASE [Assignment4] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Assignment4] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Assignment4] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Assignment4] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Assignment4]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 3/29/2020 8:44:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Admin](
	[AdminID] [int] IDENTITY(1,1) NOT NULL,
	[AdminName] [varchar](50) NOT NULL,
	[AdminPassword] [varchar](50) NOT NULL,
	[AdminLogin] [varchar](50) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 3/29/2020 8:44:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Login] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Gender] [char](1) NOT NULL,
	[Address] [varchar](50) NOT NULL,
	[Age] [int] NOT NULL,
	[NIC] [varchar](50) NOT NULL,
	[DOB] [date] NOT NULL,
	[IsCricket] [bit] NOT NULL,
	[Hockey] [bit] NOT NULL,
	[Chess] [bit] NOT NULL,
	[ImageName] [varchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[Email] [varchar](70) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
USE [master]
GO
ALTER DATABASE [Assignment4] SET  READ_WRITE 
GO
