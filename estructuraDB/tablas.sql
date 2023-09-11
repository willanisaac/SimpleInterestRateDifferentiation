CREATE DATABASE [proyectoTitulacion]

USE [proyectoTitulacion]
GO

/****** Object:  Table [dbo].[datos_cliente]    Script Date: 11/9/2023 10:14:29 ******/
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


/****** Object:  Table [dbo].[datos_cliente_train]    Script Date: 11/9/2023 10:15:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[datos_cliente_train](
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
 CONSTRAINT [PK_datos_cliente_train] PRIMARY KEY CLUSTERED 
(
	[identificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[datos_cliente_values]    Script Date: 11/9/2023 10:19:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[datos_cliente_values](
	[identificacion] [varchar](64) NOT NULL,
	[PD] [float] NULL,
	[EAD] [float] NULL,
	[LGD] [float] NULL,
	[PE] [float] NULL,
	[PI] [float] NULL,
	[tasa_ajustada] [float] NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[datos_cliente_values]  WITH NOCHECK ADD  CONSTRAINT [FK_datos_cliente_values_datos_cliente] FOREIGN KEY([identificacion])
REFERENCES [dbo].[datos_cliente] ([identificacion])
GO

ALTER TABLE [dbo].[datos_cliente_values] CHECK CONSTRAINT [FK_datos_cliente_values_datos_cliente]
GO


/****** Object:  Table [dbo].[datos_cliente_vars]    Script Date: 11/9/2023 10:23:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
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


/****** Object:  Table [dbo].[datos_cliente_vars_train]    Script Date: 11/9/2023 10:23:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[datos_cliente_vars_train](
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

ALTER TABLE [dbo].[datos_cliente_vars_train]  WITH NOCHECK ADD  CONSTRAINT [FK_datos_cliente_vars_train_datos_cliente_train] FOREIGN KEY([identificacion])
REFERENCES [dbo].[datos_cliente_train] ([identificacion])
GO

ALTER TABLE [dbo].[datos_cliente_vars_train] CHECK CONSTRAINT [FK_datos_cliente_vars_train_datos_cliente_train]
GO

/****** Object:  Table [dbo].[datos_prestamos]    Script Date: 11/9/2023 10:23:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
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


/****** Object:  Table [dbo].[datos_prestamos_train]    Script Date: 11/9/2023 10:24:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[datos_prestamos_train](
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

ALTER TABLE [dbo].[datos_prestamos_train]  WITH NOCHECK ADD  CONSTRAINT [FK_datos_prestamos_train_datos_cliente_train] FOREIGN KEY([identificacion])
REFERENCES [dbo].[datos_cliente_train] ([identificacion])
GO

ALTER TABLE [dbo].[datos_prestamos_train] CHECK CONSTRAINT [FK_datos_prestamos_train_datos_cliente_train]
GO

/****** Object:  Table [dbo].[modelo_entrenado]    Script Date: 11/9/2023 10:24:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[modelo_entrenado](
	[Id] [int] NOT NULL,
	[model_data] [varbinary](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


/****** Object:  Table [dbo].[modelo_parametros]    Script Date: 11/9/2023 10:24:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[modelo_parametros](
	[Id] [int] NOT NULL,
	[umbral_default] [int] NOT NULL,
	[tasa_normativa] [float] NOT NULL,
	[tasa_min] [float] NOT NULL,
	[raroc_index] [float] NOT NULL
) ON [PRIMARY]
GO

insert into modelo_entrenado values (1,	'0x785E7D566B6C145514DEDD76FB58DAD252CAA3945A68D196C2420B8596EE0649558C8B450A8689090E77676F770667E6EE9D996DA92214930A8D63883A15024A4144E22301FD63845D82219A128C2415491413E5A1FC000534CA2369F0CCDD6DBB7DE8FCD89939E7DCEF3BDFB9E79E9DCEF49EBB4E07BBCC52FD0519234DF5CA920A775E21212C7B79998425DD9004CB9CB42AF9D882C31AD67589A8D65B56D576EB65ABD2CC8C6015C9468765BAE45ACB4C0F45916C759B690691AD95CB8B975CBE5ED234DF7436C1CBAD24616EAB64F0926A604DC011C3DA69160CBDF0BA80208DB015709A39828C749D6FC7525834AC663347436A8828BC6E2003C37B864EE436AC59A65B0EB68675CBCC52D0665E02582B1032272851D99078860169A1A8412C3313E28344C756C0617ADA91C6C03403F2CD50F94D24A8036C965CC36BC890083C17B462644435CCAB48C13AE4CC5B6621C4C952D0AB469548071F9104A89E651634DBAF2B340D75ACD7502402490C95284B8F069379B8D92A48440D213B16824CB72EA208A454DD05CF440BC15231DB74878C0EB08AA56205C4B856D75BDD3B77582D566520CD746EB19A9B9B9F7A0017FB092C37ACA0E941B24CDA79454111103423911F63E1A1A66155C1AAC1073B0CAC5B81FC68B0D325B010AF4034EC65D562C11E5EC3025175438B0A86873A12519E64C21EEA0C38BAA84BE005681341F760D57EF0D034CEEEA7204DE732E02E4301D51AEA7E9566B4D0CC1D34AB856657069CA0917A92804C9F874EE05C10BFBA9EE6803E9ADB42F34021C3DA42278E5649F383DD1B684125970FFE562C88087646901409A4113A899B0866E81E6852C2835C1D7A9116721EB04690A1490A51254227733960C0B0F321C20B529B24D3222E1D4C3ADE4CE81406A24A6D58E691804258910442A7B2001C42213A8D05104D0A63153A8291E9743A576023484614F2212A2FA320D180BD98CBB5E1A20AD6800C6961A4D3195C11D80C092B11C2DB7557086F68288836115AC24DB171900CB94588C6B7417D319C491C92109DC94D1ECFA91B215A3ABEAB0D69F421463706126918D132AE70C8675349409BE09A9510C41219F4D844B3C7B1DB2CE5DCA431F18CA22245914AF81006B4304AB2CC49493BC569133D3CBECBE67A244551CA2A4657C91441A5610E20DE200692935C552CF3911E9B68EE38769BA59A291A19CF28E67153531CD0059A84F5F060E1E6B3E406970D7B6D2AEF7FF86CBA05AC4E63D731CA85ACE313BBA140632525D5707923CD3649ED68A38DBE88756D0A00835DCCACB0DD7A2A6A1DEBD961AB0DBA6494CDC65CCA8886E318643D0B6C9342888FC0D130904268030B84D36740530F1A97716EFB5CCAE845421B993C2444610C25CE8F2D92FAB041FD416F0F06A77D99792A9F9CC889611CA836B3D86485E16C89C589BF2471A65826CE0AB8BA2CB15CCC162BC439A64B1A313E7DA3C6A703C6A758BD539C67CFC5747BA226091DC9FF4847CFEAC11432E1D0436B8DA1738EA05B3C3CADC5BA91536C0459A64D06970FE08739DC02C1AD631902D5AFA6486A4D91F4BF1C69808F9BB614DD7D7243ECC602A1A9A1C51FE7E837BDD706707C79BED6D55F71AB91DFBE7EE2E95DE9BE657551D7BAFA99B11D7A851EEC7A22F6F6BD8DD32A5EF9E3442C7C71575F4E4E6CE5D6C24B19BEBF1AF75CE92F5DB3B921D677F5C219BC7769FC41E9E9E79CCF94FBF74E397EF1CBB5FBFD37076EB9661D381CBFFFD5E26F6FFE54EAFF91BFE2BE7DB6D87F6D59E7EEC7F6DFF3473D4D57ABB76D8CA77FE6F9E7876373FD471BBA73177D5EEEAFFF8DFEBEE2FB5FFDAE9FFBEA0ECD6B8F3BD61D3A153E3221DE7BF4CA02E9F264FF9CF91F3756BD7332BE5711EFF51DFE30DE7316A51D39B5C8EFBD5955F2C5C10AFFC18D2B4DF7C0A5B8824AAEF7DCDE1AEFEDFFE4D8F5674FC7CACF7F70FCC69E5F625D971CBB8DD7B34FDE59AFACFD6E60497C95E4FBF3E997F6F90EACDAD6DB757E8F6FEDD77FBBCFBC51E4DFA7CF7EBF6C4D7FAC7FE1FDFE473F6AF56DBAD079E3CDB319F1D79E77BDBBFDDC7BB1ABE794589C96F97A160EF68567F81B6674270EB7C6E3435D9697DCF8E4EDD3868CE97738EE444FE9205E3E9FFC2C83E9ABB14F2ED35DE3ADF5D65AD1A0F75F6B0DAFED')