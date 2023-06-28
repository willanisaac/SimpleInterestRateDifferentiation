USE proyectoTitulacion
GO

/****** Object:  Table [dbo].[datos_cliente]    Script Date: 8/6/2023 9:15:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[datos_cliente](
	[identificacion] [varchar](64) NOT NULL,
	[fecha_nacimiento] [varchar](50) NULL,
	[ingreso_mensual] [float] NULL,
	[patrimonio] [float] NULL,
	[estado_civil] [varchar](50) NULL,
	[sexo] [varchar](50) NULL,
	[nivel_academico] [varchar](50) NULL,
	[edad] [int] NULL,
	[origen_ingresos] [varchar](50) NULL,
	[situacion_laboral] [varchar](50) NULL,
	[numero_cargas] [int] NULL,
	[tiempo_ultimo_trabajo] [int] NULL,
 CONSTRAINT [PK_datos_cliente] PRIMARY KEY CLUSTERED 
(
	[identificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[datos_cliente_vars](
	[identificacion] [varchar](64) NOT NULL,
	[saldo_por_vencer_media] [float] NULL,
	[saldo_por_vencer_std] [float] NULL,
	[saldo_por_vencer_var] [float] NULL,
	[saldo_por_vencer_area] [float] NULL,
	[saldo_vencido_media] [float] NULL,
	[saldo_vencido_std] [float] NULL,
	[saldo_vencido_var] [float] NULL,
	[saldo_vencido_area] [float] NULL,
	[saldo_no_devenga_media] [float] NULL,
	[saldo_no_devenga_std] [float] NULL,
	[saldo_no_devenga_var] [float] NULL,
	[saldo_no_devenga_area] [float] NULL,
	[cartera_total_media] [float] NULL,
	[cartera_total_std] [float] NULL,
	[cartera_total_var] [float] NULL,
	[cartera_total_area] [float] NULL,
	[cartera_en_riesgo_media] [float] NULL,
	[cartera_en_riesgo_std] [float] NULL,
	[cartera_en_riesgo_var] [float] NULL,
	[cartera_en_riesgo_area] [float] NULL,
	[saldo_mora_media] [float] NULL,
	[saldo_mora_std] [float] NULL,
	[saldo_mora_var] [float] NULL,
	[saldo_mora_area] [float] NULL,
	[dias_mora_media] [float] NULL,
	[dias_mora_std] [float] NULL,
	[dias_mora_var] [float] NULL,
	[dias_mora_area] [float] NULL,
	[vida_prestamo] [int] NULL,
	[monto_prestamo] [float] NULL,
	[plazo] [int] NULL,
	[incumplimiento] [int] NULL,
	[acumulacion_mora] [int] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[datos_cliente_vars]  WITH NOCHECK ADD  CONSTRAINT [FK_datos_cliente_vars_datos_cliente] FOREIGN KEY([identificacion])
REFERENCES [dbo].[datos_cliente] ([identificacion])
GO
ALTER TABLE [dbo].[datos_cliente_vars] CHECK CONSTRAINT [FK_datos_cliente_vars_datos_cliente]
GO

CREATE TABLE [dbo].[datos_cliente_values](
	[identificacion] [varchar](64) NOT NULL,

	[PD]	[float] NULL,
	[EAD]	[float] NULL,
	[LGD]	[float] NULL, 
	[PE]	[float] NULL,
	[PI]	[float] NULL,
	[tasa_ajustada]	[float] NULL
	) ON [PRIMARY]
GO
ALTER TABLE [dbo].[datos_cliente_values]  WITH NOCHECK ADD  CONSTRAINT [FK_datos_cliente_values_datos_cliente] FOREIGN KEY([identificacion])
REFERENCES [dbo].[datos_cliente] ([identificacion])
GO
ALTER TABLE [dbo].[datos_cliente_values] CHECK CONSTRAINT [FK_datos_cliente_values_datos_cliente]
GO

CREATE TABLE [dbo].[datos_prestamos](
	[fecha_corte] [varchar](10) NOT NULL,
	[identificacion] [varchar](64) NOT NULL,
	[codigo_prestamo] [varchar](64) NOT NULL,
	[plazo] [int] NULL,
	[saldo_por_vencer] [float] NULL,
	[saldo_vencido] [float] NULL,
	[saldo_no_devenga] [float] NULL,
	[cartera_total] [float] NULL,
	[cartera_en_riesgo] [float] NULL,
	[saldo_mora] [float] NULL,
	[fecha_consecion] [varchar](50) NULL,
	[fecha_vencimiento] [varchar](50) NULL,
	[dias_mora] [int] NULL,
	[monto_prestamo] [float] NULL,
	[vida_prestamo] [int] NULL,
	[tasa] [float] NULL,
	[acumulacion_mora] [int] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[datos_prestamos]  WITH NOCHECK ADD  CONSTRAINT [FK_datos_prestamos_datos_cliente] FOREIGN KEY([identificacion])
REFERENCES [dbo].[datos_cliente] ([identificacion])
GO
ALTER TABLE [dbo].[datos_prestamos] CHECK CONSTRAINT [FK_datos_prestamos_datos_cliente]
GO

CREATE TABLE [dbo].[modelo_entrenado](
	[Id] [int] NOT NULL,
	[ModelData] [varbinary](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


