USE [QuanLyKhoNhapMon]
GO
/****** Object:  Table [dbo].[employee]    Script Date: 4/4/2021 7:45:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employee](
	[username] [nvarchar](1) NOT NULL,
	[password] [varchar](1) NOT NULL,
	[confirmPassword] [varchar](1) NULL,
	[code] [varchar](1) NOT NULL,
	[name] [varchar](1) NOT NULL,
	[dob] [datetime] NULL,
	[gender] [bit] NULL,
	[phoneNumber] [varchar](1) NULL,
	[dayOne] [datetime] NULL,
	[identify] [varchar](1) NOT NULL,
	[flag] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
