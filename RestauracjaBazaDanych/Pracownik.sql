USE [Restauracja]
GO

/****** Object:  Table [dbo].[Pracownik]    Script Date: 09.05.2022 22:49:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Pracownik](
	[Id_Pracownika] [int] NOT NULL,
	[Imie] [nchar](20) NOT NULL,
	[Nazwisko] [nchar](30) NOT NULL,
	[Pesel] [int] NOT NULL,
	[RokUrodzenia] [int] NOT NULL,
	[Id_Posada] [int] NULL,
	[Zmiana] [int] NULL,
	[Wynagrodzenie] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Pracownika] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Pracownik]  WITH CHECK ADD FOREIGN KEY([Id_Posada])
REFERENCES [dbo].[TABELA_POSAD] ([Id_Posada])
ON UPDATE CASCADE
GO

