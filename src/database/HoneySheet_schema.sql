USE [HoneySheet]
GO
/****** Object:  Table [dbo].[Contract]    Script Date: 2019/2/18 21:23:19 ******/
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
	[Department] [nvarchar](20) NOT NULL,
	[Salesman] [nvarchar](20) NOT NULL,
	[Province] [varchar](20) NULL,
	[Details] [nvarchar](max) NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreateUser] [varchar](20) NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
	[UpdateUser] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Contract] PRIMARY KEY CLUSTERED 
(
	[ContractId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
