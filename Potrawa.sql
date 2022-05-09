USE [Restauracja]
GO

/****** Object:  Table [dbo].[Potrawa]    Script Date: 09.05.2022 22:52:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Potrawa](
	[Id_Potrawa] [int] NOT NULL,
	[Nazwa] [nchar](30) NOT NULL,
	[Id_Rodzaj] [int] NULL,
	[Id_Diety] [int] NULL,
	[Cena] [money] NOT NULL,
	[Alkohol] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Potrawa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Potrawa]  WITH CHECK ADD FOREIGN KEY([Id_Diety])
REFERENCES [dbo].[TABELA_DIETY] ([Id_Diety])
ON UPDATE CASCADE
GO

ALTER TABLE [dbo].[Potrawa]  WITH CHECK ADD FOREIGN KEY([Id_Rodzaj])
REFERENCES [dbo].[TABELA_RODZAJ] ([Id_Rodzaj])
ON UPDATE CASCADE
GO

