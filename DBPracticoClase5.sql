USE [DBPracticoClase5]
GO
/****** Object:  Table [dbo].[Cuentas]    Script Date: 03/10/2023 21:34:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cuentas](
	[idCuenta] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Cuentas] PRIMARY KEY CLUSTERED 
(
	[idCuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RegistrosContables]    Script Date: 03/10/2023 21:34:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegistrosContables](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idCuenta] [int] NOT NULL,
	[monto] [float] NOT NULL,
	[tipo] [bit] NOT NULL,
 CONSTRAINT [PK_RegistrosContables] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[RegistrosContables]  WITH CHECK ADD  CONSTRAINT [FK_RegistrosContables_Cuentas] FOREIGN KEY([idCuenta])
REFERENCES [dbo].[Cuentas] ([idCuenta])
GO
ALTER TABLE [dbo].[RegistrosContables] CHECK CONSTRAINT [FK_RegistrosContables_Cuentas]
GO
