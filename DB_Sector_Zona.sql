USE [DB_Sector_Zona]
GO
/****** Object:  Table [dbo].[tbl_persona]    Script Date: 18/11/2021 10:47:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_persona](
	[cod_persona] [int] NOT NULL,
	[nom_persona] [varchar](30) NOT NULL,
	[fec_nacimiento] [date] NOT NULL,
	[cod_sector] [int] NOT NULL,
	[cod_zona] [int] NOT NULL,
	[sueldo] [decimal](8, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[cod_persona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_sector]    Script Date: 18/11/2021 10:47:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_sector](
	[cod_sector] [int] IDENTITY(1,1) NOT NULL,
	[des_sector] [varchar](30) NOT NULL,
 CONSTRAINT [PK_tbl_sector] PRIMARY KEY CLUSTERED 
(
	[cod_sector] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_usuario]    Script Date: 18/11/2021 10:47:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_usuario](
	[cod_usuario] [int] IDENTITY(1,1) NOT NULL,
	[nom_usuario] [varchar](30) NOT NULL,
	[password] [varchar](20) NOT NULL,
	[tiempo] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_tbl_usuario] PRIMARY KEY CLUSTERED 
(
	[cod_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_zona]    Script Date: 18/11/2021 10:47:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_zona](
	[cod_zona] [int] IDENTITY(1,1) NOT NULL,
	[des_zona] [varchar](30) NOT NULL,
	[cod_sector] [int] NOT NULL,
 CONSTRAINT [PK_tbl_zona] PRIMARY KEY CLUSTERED 
(
	[cod_zona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tbl_persona] ([cod_persona], [nom_persona], [fec_nacimiento], [cod_sector], [cod_zona], [sueldo]) VALUES (1, N'Luis Vivas', CAST(N'1989-05-12' AS Date), 1, 1, CAST(500.00 AS Decimal(8, 2)))
GO
INSERT [dbo].[tbl_persona] ([cod_persona], [nom_persona], [fec_nacimiento], [cod_sector], [cod_zona], [sueldo]) VALUES (2, N'David Román', CAST(N'1990-10-02' AS Date), 1, 2, CAST(550.00 AS Decimal(8, 2)))
GO
INSERT [dbo].[tbl_persona] ([cod_persona], [nom_persona], [fec_nacimiento], [cod_sector], [cod_zona], [sueldo]) VALUES (3, N'Guillermo Rivera', CAST(N'1999-11-26' AS Date), 2, 3, CAST(500.00 AS Decimal(8, 2)))
GO
INSERT [dbo].[tbl_persona] ([cod_persona], [nom_persona], [fec_nacimiento], [cod_sector], [cod_zona], [sueldo]) VALUES (4, N'Carlos Alcívar', CAST(N'1991-05-22' AS Date), 2, 3, CAST(560.00 AS Decimal(8, 2)))
GO
INSERT [dbo].[tbl_persona] ([cod_persona], [nom_persona], [fec_nacimiento], [cod_sector], [cod_zona], [sueldo]) VALUES (5, N'Laura Gutierrez', CAST(N'1940-12-27' AS Date), 1, 1, CAST(750.00 AS Decimal(8, 2)))
GO
SET IDENTITY_INSERT [dbo].[tbl_sector] ON 
GO
INSERT [dbo].[tbl_sector] ([cod_sector], [des_sector]) VALUES (1, N'Norte')
GO
INSERT [dbo].[tbl_sector] ([cod_sector], [des_sector]) VALUES (2, N'Sur')
GO
SET IDENTITY_INSERT [dbo].[tbl_sector] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_usuario] ON 
GO
INSERT [dbo].[tbl_usuario] ([cod_usuario], [nom_usuario], [password], [tiempo]) VALUES (1, N'admin', N'123', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[tbl_usuario] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_zona] ON 
GO
INSERT [dbo].[tbl_zona] ([cod_zona], [des_zona], [cod_sector]) VALUES (1, N'Alborada', 1)
GO
INSERT [dbo].[tbl_zona] ([cod_zona], [des_zona], [cod_sector]) VALUES (2, N'Sauces', 1)
GO
INSERT [dbo].[tbl_zona] ([cod_zona], [des_zona], [cod_sector]) VALUES (3, N'Acacias', 2)
GO
SET IDENTITY_INSERT [dbo].[tbl_zona] OFF
GO
ALTER TABLE [dbo].[tbl_usuario] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [tiempo]
GO
ALTER TABLE [dbo].[tbl_persona]  WITH CHECK ADD  CONSTRAINT [fk_persona_sector] FOREIGN KEY([cod_sector])
REFERENCES [dbo].[tbl_sector] ([cod_sector])
GO
ALTER TABLE [dbo].[tbl_persona] CHECK CONSTRAINT [fk_persona_sector]
GO
ALTER TABLE [dbo].[tbl_persona]  WITH CHECK ADD  CONSTRAINT [fk_persona_zona] FOREIGN KEY([cod_zona])
REFERENCES [dbo].[tbl_zona] ([cod_zona])
GO
ALTER TABLE [dbo].[tbl_persona] CHECK CONSTRAINT [fk_persona_zona]
GO
ALTER TABLE [dbo].[tbl_zona]  WITH CHECK ADD  CONSTRAINT [FK_tbl_sector] FOREIGN KEY([cod_sector])
REFERENCES [dbo].[tbl_sector] ([cod_sector])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_zona] CHECK CONSTRAINT [FK_tbl_sector]
GO
