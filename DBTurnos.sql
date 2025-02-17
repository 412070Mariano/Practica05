﻿USE [turnos_db﻿_2]
GO
/****** Object:  Table [dbo].[T_DETALLES_TURNO]    Script Date: 04/10/2024 08:52:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_DETALLES_TURNO](
	[id_turno] [int] NOT NULL,
	[id_servicio] [int] NOT NULL,
	[observaciones] [varchar](200) NULL,
 CONSTRAINT [PK_T_DETALLES_TURNO] PRIMARY KEY CLUSTERED 
(
	[id_turno] ASC,
	[id_servicio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_SERVICIOS]    Script Date: 04/10/2024 08:52:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_SERVICIOS](
	[id_servicio] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[costo] [int] NOT NULL,
	[enPromocion] [varchar](1) NOT NULL,
 CONSTRAINT [PK_T_SERVICIOS] PRIMARY KEY CLUSTERED 
(
	[id_servicio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_TURNOS]    Script Date: 04/10/2024 08:52:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_TURNOS](
	[id_turno] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [varchar](10) NULL,
	[hora] [varchar](5) NULL,
	[cliente] [varchar](100) NULL,
 CONSTRAINT [PK_T_TURNOS] PRIMARY KEY CLUSTERED 
(
	[id_turno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[T_DETALLES_TURNO]  WITH CHECK ADD  CONSTRAINT [FK_T_DETALLES_TURNO_T_SERVICIOS] FOREIGN KEY([id_servicio])
REFERENCES [dbo].[T_SERVICIOS] ([id_servicio])
GO
ALTER TABLE [dbo].[T_DETALLES_TURNO] CHECK CONSTRAINT [FK_T_DETALLES_TURNO_T_SERVICIOS]
GO
ALTER TABLE [dbo].[T_DETALLES_TURNO]  WITH CHECK ADD  CONSTRAINT [FK_T_DETALLES_TURNO_T_TURNOS] FOREIGN KEY([id_turno])
REFERENCES [dbo].[T_TURNOS] ([id_turno])
GO
ALTER TABLE [dbo].[T_DETALLES_TURNO] CHECK CONSTRAINT [FK_T_DETALLES_TURNO_T_TURNOS]
GO

Alter table [dbo].[T_TURNOS]
ADD [fecha_cancelacion] [DateTime] NULL

Alter table [dbo].[T_TURNOS]
ADD [motivo_cancelacion] [varchar](50) NULL