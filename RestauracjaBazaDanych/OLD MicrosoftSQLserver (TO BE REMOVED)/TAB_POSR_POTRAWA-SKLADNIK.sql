USE [Restauracja]
GO

/****** Object:  Table [dbo].[TAB_POSR_POTRAWA-SKLADNIK]    Script Date: 09.05.2022 22:54:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TAB_POSR_POTRAWA-SKLADNIK](
	[Id_Potrawa_Skladnik] [int] NOT NULL,
	[Id_Potrawa] [int] NOT NULL,
	[Id_Skladnik] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Potrawa_Skladnik] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TAB_POSR_POTRAWA-SKLADNIK]  WITH CHECK ADD FOREIGN KEY([Id_Potrawa])
REFERENCES [dbo].[Potrawa] ([Id_Potrawa])
ON UPDATE CASCADE
GO

ALTER TABLE [dbo].[TAB_POSR_POTRAWA-SKLADNIK]  WITH CHECK ADD FOREIGN KEY([Id_Skladnik])
REFERENCES [dbo].[Skladnik] ([Id_Skladnik])
ON UPDATE CASCADE
GO
