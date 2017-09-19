USE [master]
GO
/****** Object:  Database [SampleShoppingCart]    Script Date: 9/13/2017 9:38:47 PM ******/
CREATE DATABASE [SampleShoppingCart]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SampleShoppingCart', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\SampleShoppingCart.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SampleShoppingCart_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\SampleShoppingCart_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SampleShoppingCart] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SampleShoppingCart].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SampleShoppingCart] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SampleShoppingCart] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SampleShoppingCart] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SampleShoppingCart] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SampleShoppingCart] SET ARITHABORT OFF 
GO
ALTER DATABASE [SampleShoppingCart] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SampleShoppingCart] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [SampleShoppingCart] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SampleShoppingCart] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SampleShoppingCart] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SampleShoppingCart] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SampleShoppingCart] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SampleShoppingCart] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SampleShoppingCart] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SampleShoppingCart] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SampleShoppingCart] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SampleShoppingCart] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SampleShoppingCart] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SampleShoppingCart] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SampleShoppingCart] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SampleShoppingCart] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SampleShoppingCart] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SampleShoppingCart] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SampleShoppingCart] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SampleShoppingCart] SET  MULTI_USER 
GO
ALTER DATABASE [SampleShoppingCart] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SampleShoppingCart] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SampleShoppingCart] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SampleShoppingCart] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [SampleShoppingCart]
GO
/****** Object:  UserDefinedFunction [dbo].[Total1lbok1s]    Script Date: 9/13/2017 9:38:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Function [dbo].[Total1lbok1s]()
returns int as
Begin
     declare @BookCount as int;
     Select @BookCount = Count(Pname)
     from Product;
     return @BookCount;

end;
GO
/****** Object:  UserDefinedFunction [dbo].[Totalbok1s]    Script Date: 9/13/2017 9:38:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Function [dbo].[Totalbok1s]()
returns int as
Begin
     declare @BookCount as int;
     Select @BookCount = Count(Pname)
     from Product;
     return @BookCount;

end;
GO
/****** Object:  UserDefinedFunction [dbo].[Totalboks]    Script Date: 9/13/2017 9:38:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Function [dbo].[Totalboks]()
returns int as
Begin
     declare @BookCount as int;
     Select @BookCount = Count(Pname)
     from Product;
     return @BookCount;

end;
GO
/****** Object:  UserDefinedFunction [dbo].[TotalBooks]    Script Date: 9/13/2017 9:38:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Function [dbo].[TotalBooks]()
returns int as
Begin
     declare @BookCount as int;
     Select @BookCount = Count(Pname)
     from Product;
     return @BookCount;

end;
GO
/****** Object:  UserDefinedFunction [dbo].[Totalbooks1]    Script Date: 9/13/2017 9:38:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Function [dbo].[Totalbooks1]()
returns int as
Begin
    return 1;
end
GO
/****** Object:  UserDefinedFunction [dbo].[Totlbok1s]    Script Date: 9/13/2017 9:38:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Function [dbo].[Totlbok1s]()
returns int as
Begin
     declare @BookCount as int;
     Select @BookCount = Count(Pname)
     from Product;
     return @BookCount;

end;
GO
/****** Object:  UserDefinedFunction [dbo].[udf_getRowCount]    Script Date: 9/13/2017 9:38:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[udf_getRowCount]()


RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE @ResultVar int

	Set @ResultVar=2

	-- Return the result of the function
	RETURN @ResultVar;

END

GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 9/13/2017 9:38:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[Pname] [varchar](50) NULL,
	[Oid] [varchar](50) NULL,
	[Quantity] [varchar](50) NULL,
	[Price] [decimal](18, 0) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 9/13/2017 9:38:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Orders](
	[Oid] [varchar](50) NULL,
	[Time] [datetime] NULL,
	[Amount] [decimal](18, 5) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Products]    Script Date: 9/13/2017 9:38:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Products](
	[Pname] [varchar](50) NOT NULL,
	[Pid] [varchar](50) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Pid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
USE [master]
GO
ALTER DATABASE [SampleShoppingCart] SET  READ_WRITE 
GO
