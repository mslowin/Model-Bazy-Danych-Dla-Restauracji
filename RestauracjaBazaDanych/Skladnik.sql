USE [Restauracja]
GO

/****** Object:  Table [dbo].[Skladnik]    Script Date: 09.05.2022 22:53:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Skladnik](
	[Id_Skladnik] [int] NOT NULL,
	[Nazwa] [nchar](20) NOT NULL,
	[Ilosc] [float] NOT NULL,
	[Id_Jednostka] [int] NOT NULL,
	[Cena_Za_Jednostke] [money] NOT NULL,
	[Czy_Widoczne_W_Menu] [binary](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Skladnik] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Skladnik]  WITH CHECK ADD FOREIGN KEY([Id_Jednostka])
REFERENCES [dbo].[TABELA_JEDNOSTKA] ([Id_Jednostka])
ON UPDATE CASCADE
GO

