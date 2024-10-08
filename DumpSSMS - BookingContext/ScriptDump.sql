USE [BookingContext]
GO
/****** Object:  Table [dbo].[Prenotazioni]    Script Date: 06/09/2024 02:23:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prenotazioni](
	[PrenotazioneId] [int] IDENTITY(1,1) NOT NULL,
	[DataInizio] [date] NOT NULL,
	[DataFine] [date] NOT NULL,
	[UtenteId] [int] NOT NULL,
	[RisorsaId] [int] NOT NULL,
 CONSTRAINT [PK_Prenotazioni] PRIMARY KEY CLUSTERED 
(
	[PrenotazioneId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Risorse]    Script Date: 06/09/2024 02:23:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Risorse](
	[RisorsaId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](max) NOT NULL,
	[TipologiaRisorsaId] [int] NOT NULL,
 CONSTRAINT [PK_Risorse] PRIMARY KEY CLUSTERED 
(
	[RisorsaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipologieRisorse]    Script Date: 06/09/2024 02:23:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipologieRisorse](
	[TipologiaRisorsaId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_TipologieRisorse] PRIMARY KEY CLUSTERED 
(
	[TipologiaRisorsaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utente]    Script Date: 06/09/2024 02:23:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utente](
	[UtenteId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](max) NOT NULL,
	[Cognome] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Utente] PRIMARY KEY CLUSTERED 
(
	[UtenteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Prenotazioni]  WITH CHECK ADD  CONSTRAINT [FK_Prenotazioni_Risorse_RisorsaId] FOREIGN KEY([RisorsaId])
REFERENCES [dbo].[Risorse] ([RisorsaId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Prenotazioni] CHECK CONSTRAINT [FK_Prenotazioni_Risorse_RisorsaId]
GO
ALTER TABLE [dbo].[Prenotazioni]  WITH CHECK ADD  CONSTRAINT [FK_Prenotazioni_Utente_UtenteId] FOREIGN KEY([UtenteId])
REFERENCES [dbo].[Utente] ([UtenteId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Prenotazioni] CHECK CONSTRAINT [FK_Prenotazioni_Utente_UtenteId]
GO
ALTER TABLE [dbo].[Risorse]  WITH CHECK ADD  CONSTRAINT [FK_Risorse_TipologieRisorse_TipologiaRisorsaId] FOREIGN KEY([TipologiaRisorsaId])
REFERENCES [dbo].[TipologieRisorse] ([TipologiaRisorsaId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Risorse] CHECK CONSTRAINT [FK_Risorse_TipologieRisorse_TipologiaRisorsaId]
GO
