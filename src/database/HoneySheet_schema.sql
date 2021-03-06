USE [master]
GO
/****** Object:  Database [HoneySheet]    Script Date: 2019/2/22 22:14:38 ******/
CREATE DATABASE [HoneySheet]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HoneySheet', FILENAME = N'D:\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\HoneySheet.mdf' , SIZE = 7168KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'HoneySheet_log', FILENAME = N'D:\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\HoneySheet_log.ldf' , SIZE = 3136KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [HoneySheet] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HoneySheet].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HoneySheet] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HoneySheet] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HoneySheet] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HoneySheet] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HoneySheet] SET ARITHABORT OFF 
GO
ALTER DATABASE [HoneySheet] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HoneySheet] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HoneySheet] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HoneySheet] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HoneySheet] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HoneySheet] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HoneySheet] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HoneySheet] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HoneySheet] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HoneySheet] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HoneySheet] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HoneySheet] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HoneySheet] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HoneySheet] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HoneySheet] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HoneySheet] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HoneySheet] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HoneySheet] SET RECOVERY FULL 
GO
ALTER DATABASE [HoneySheet] SET  MULTI_USER 
GO
ALTER DATABASE [HoneySheet] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HoneySheet] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HoneySheet] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HoneySheet] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [HoneySheet] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'HoneySheet', N'ON'
GO
USE [HoneySheet]
GO
/****** Object:  Table [dbo].[Contract]    Script Date: 2019/2/22 22:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Contract](
	[ContractId] [int] IDENTITY(1,1) NOT NULL,
	[ContractCode] [varchar](20) NOT NULL,
	[ContractName] [nvarchar](50) NOT NULL,
	[ContractAmount] [decimal](18, 2) NOT NULL,
	[DateOfSign] [date] NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[Salesman] [nvarchar](20) NOT NULL,
	[Custom] [nvarchar](50) NOT NULL,
	[State] [int] NOT NULL,
	[UpdateTime] [datetime] NULL,
	[UpdateUser] [varchar](20) NULL,
 CONSTRAINT [PK_Contract] PRIMARY KEY CLUSTERED 
(
	[ContractId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Department]    Script Date: 2019/2/22 22:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[DepartmentId] [int] NOT NULL,
	[DepartmentName] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 2019/2/22 22:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Invoice](
	[InvoiceId] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [int] NOT NULL,
	[DrawDate] [date] NOT NULL,
	[InvoiceType] [int] NOT NULL,
	[InvoiceContent] [nvarchar](100) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreateUser] [varchar](20) NOT NULL,
 CONSTRAINT [Invoice_pk] PRIMARY KEY NONCLUSTERED 
(
	[InvoiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Project]    Script Date: 2019/2/22 22:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Project](
	[ProjectId] [int] IDENTITY(1,1) NOT NULL,
	[ContractId] [int] NOT NULL,
	[ProjectName] [nvarchar](50) NOT NULL,
	[ProjectAmount] [decimal](18, 2) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreateUser] [varchar](20) NOT NULL,
 CONSTRAINT [Project_pk] PRIMARY KEY NONCLUSTERED 
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Receipt]    Script Date: 2019/2/22 22:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Receipt](
	[ReceiptId] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceId] [int] NOT NULL,
	[PayDate] [date] NULL,
	[PayAmount] [decimal](18, 2) NULL,
	[ReceiptDate] [date] NOT NULL,
	[ReceiptAmount] [decimal](18, 2) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreateUser] [varchar](20) NOT NULL,
 CONSTRAINT [Receipt_pk] PRIMARY KEY NONCLUSTERED 
(
	[ReceiptId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 2019/2/22 22:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Account] [varchar](20) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [Invoice_ProjectId_fk] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([ProjectId])
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [Invoice_ProjectId_fk]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [Project_ContractId_fk] FOREIGN KEY([ContractId])
REFERENCES [dbo].[Contract] ([ContractId])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [Project_ContractId_fk]
GO
ALTER TABLE [dbo].[Receipt]  WITH CHECK ADD  CONSTRAINT [Receipt_InvoiceId_fk] FOREIGN KEY([InvoiceId])
REFERENCES [dbo].[Invoice] ([InvoiceId])
GO
ALTER TABLE [dbo].[Receipt] CHECK CONSTRAINT [Receipt_InvoiceId_fk]
GO
USE [master]
GO
ALTER DATABASE [HoneySheet] SET  READ_WRITE 
GO
