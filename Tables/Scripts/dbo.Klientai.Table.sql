USE [KlientuDuomenys]
GO
/****** Object:  Table [dbo].[Klientai]******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Klientai](
	[Name] [nvarchar](450) NOT NULL,
	[Address] [nvarchar](450) NOT NULL,
	[PostCode] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Klientai] PRIMARY KEY CLUSTERED 
(
	[Name] ASC,
	[Address] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
