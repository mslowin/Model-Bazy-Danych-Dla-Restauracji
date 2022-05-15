USE [Restauracja]
GO

/****** Object:  Table [dbo].[TAB_POSR_ZAMOWIENIE-POTRAWA]    Script Date: 09.05.2022 22:54:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TAB_POSR_ZAMOWIENIE-POTRAWA](
	[Id_Zamowienie_Potrawa] [int] NOT NULL,
	[Id_Zamowienie] [int] NOT NULL,
	[Id_Potrawa] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Zamowienie_Potrawa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TAB_POSR_ZAMOWIENIE-POTRAWA]  WITH CHECK ADD FOREIGN KEY([Id_Potrawa])
REFERENCES [dbo].[Potrawa] ([Id_Potrawa])
ON UPDATE CASCADE
GO

ALTER TABLE [dbo].[TAB_POSR_ZAMOWIENIE-POTRAWA]  WITH CHECK ADD FOREIGN KEY([Id_Zamowienie])
REFERENCES [dbo].[Zamowienie] ([Id_Zamowienia])
ON UPDATE CASCADE
GO
