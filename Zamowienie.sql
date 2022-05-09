USE [Restauracja]
GO

/****** Object:  Table [dbo].[Zamowienie]    Script Date: 09.05.2022 22:55:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Zamowienie](
	[Id_Zamowienia] [int] NOT NULL,
	[Numer_Stolu] [int] NULL,
	[Data_Zamowienia] [date] NOT NULL,
	[Ulica] [nchar](30) NULL,
	[Budynek] [int] NULL,
	[Lokal] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Zamowienia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

