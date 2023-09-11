USE [proyectoTitulacion]
GO

/****** Object:  StoredProcedure [dbo].[spd_data]    Script Date: 11/9/2023 10:24:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spd_data]
AS
BEGIN
	DELETE FROM datos_prestamos
	DELETE FROM datos_cliente_values
	DELETE FROM datos_cliente_vars
	DELETE FROM datos_cliente
END
GO

USE [proyectoTitulacion]
GO

/****** Object:  StoredProcedure [dbo].[spd_data_train]    Script Date: 11/9/2023 10:24:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spd_data_train]
AS
BEGIN
	DELETE FROM datos_prestamos_train
	DELETE FROM datos_cliente_vars_train
	DELETE FROM datos_cliente_train
END
GO


USE [proyectoTitulacion]
GO

/****** Object:  StoredProcedure [dbo].[spd_model_knowledge]    Script Date: 11/9/2023 10:25:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spd_model_knowledge]
AS
BEGIN
	delete from modelo_entrenado where id <> 1
END
GO

USE [proyectoTitulacion]
GO

/****** Object:  StoredProcedure [dbo].[spd_vals]    Script Date: 11/9/2023 10:25:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spd_vals]
AS
BEGIN
	DELETE FROM [dbo].datos_cliente_values
END
GO

USE [proyectoTitulacion]
GO

/****** Object:  StoredProcedure [dbo].[spd_vars]    Script Date: 11/9/2023 10:25:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spd_vars]
AS
BEGIN
	DELETE FROM [dbo].datos_cliente_vars
END
GO

USE [proyectoTitulacion]
GO

/****** Object:  StoredProcedure [dbo].[spd_vars_train]    Script Date: 11/9/2023 10:25:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spd_vars_train]
AS
BEGIN
	DELETE FROM [dbo].datos_cliente_vars_train
END
GO

USE [proyectoTitulacion]
GO

/****** Object:  StoredProcedure [dbo].[spi_model_knowledge]    Script Date: 11/9/2023 10:25:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spi_model_knowledge]
	@umbral int = null,
	@tasamax float = null,
	@tasamin float = null,
	@raroc float = null,
    @data varbinary(max) = null
AS
BEGIN
	IF (@data is null)  BEGIN
		delete from modelo_parametros where id <> 1
		insert into modelo_parametros values (2,@umbral, @tasamax, @tasamin, @raroc)
	END
	ELSE BEGIN
		delete from modelo_entrenado where id <> 1
		insert into modelo_entrenado values (2, @data)
	END
END 
GO

USE [proyectoTitulacion]
GO

/****** Object:  StoredProcedure [dbo].[sps_datos_cliente_por_identificacion]    Script Date: 11/9/2023 10:25:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sps_datos_cliente_por_identificacion]
    @identificacion varchar(64) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @identificacion IS NULL OR @identificacion = '0'
    BEGIN
        -- Sin restricción de identificación
        SELECT * FROM [dbo].[datos_cliente]
    END
    ELSE
    BEGIN
        -- Restricción de identificación
        SELECT * FROM [dbo].[datos_cliente]
         WHERE [identificacion] = @identificacion
    END
END

GO

USE [proyectoTitulacion]
GO

/****** Object:  StoredProcedure [dbo].[sps_datos_clientes_and_vars]    Script Date: 11/9/2023 10:25:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sps_datos_clientes_and_vars]
AS
BEGIN
	select datos_cliente.identificacion, fecha_nacimiento, ingreso_mensual,
	patrimonio, estado_civil, sexo, nivel_academico, edad, origen_ingresos,
	situacion_laboral, numero_cargas, tiempo_ultimo_trabajo, saldo_por_vencer_media,
	saldo_por_vencer_std, saldo_por_vencer_var, saldo_por_vencer_area, saldo_vencido_media,
	saldo_vencido_std, saldo_vencido_var, saldo_vencido_area, saldo_no_devenga_media,
	saldo_no_devenga_std, saldo_no_devenga_var, saldo_no_devenga_area, cartera_total_media,
	cartera_total_std, cartera_total_var, cartera_total_area, cartera_en_riesgo_media,
	cartera_en_riesgo_std, cartera_en_riesgo_var, cartera_en_riesgo_area, saldo_mora_media,
	saldo_mora_std, saldo_mora_var, saldo_mora_area, dias_mora_media, dias_mora_std,
	dias_mora_var, dias_mora_area, vida_prestamo, monto_prestamo, plazo, acumulacion_mora, incumplimiento
	from proyectoTitulacion..datos_cliente inner join proyectoTitulacion..datos_cliente_vars
	on datos_cliente.identificacion = datos_cliente_vars.identificacion
END
GO

USE [proyectoTitulacion]
GO

/****** Object:  StoredProcedure [dbo].[sps_datos_clientes_and_vars_train]    Script Date: 11/9/2023 10:25:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sps_datos_clientes_and_vars_train]
AS
BEGIN
	select datos_cliente_train.identificacion, fecha_nacimiento, ingreso_mensual,
	patrimonio, estado_civil, sexo, nivel_academico, edad, origen_ingresos,
	situacion_laboral, numero_cargas, tiempo_ultimo_trabajo, saldo_por_vencer_media,
	saldo_por_vencer_std, saldo_por_vencer_var, saldo_por_vencer_area, saldo_vencido_media,
	saldo_vencido_std, saldo_vencido_var, saldo_vencido_area, saldo_no_devenga_media,
	saldo_no_devenga_std, saldo_no_devenga_var, saldo_no_devenga_area, cartera_total_media,
	cartera_total_std, cartera_total_var, cartera_total_area, cartera_en_riesgo_media,
	cartera_en_riesgo_std, cartera_en_riesgo_var, cartera_en_riesgo_area, saldo_mora_media,
	saldo_mora_std, saldo_mora_var, saldo_mora_area, dias_mora_media, dias_mora_std,
	dias_mora_var, dias_mora_area, vida_prestamo, monto_prestamo, plazo, acumulacion_mora, incumplimiento
	from proyectoTitulacion..datos_cliente_train inner join proyectoTitulacion..datos_cliente_vars_train
	on datos_cliente_train.identificacion = datos_cliente_vars_train.identificacion
END
GO

USE [proyectoTitulacion]
GO

/****** Object:  StoredProcedure [dbo].[sps_datos_prestamos_por_identificacion]    Script Date: 11/9/2023 10:25:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sps_datos_prestamos_por_identificacion]
    @identificacion varchar(64)= NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @identificacion IS NULL OR @identificacion = '0'
    BEGIN
        -- Sin restricción de identificación
        SELECT * FROM [dbo].[datos_prestamos]
	      ORDER BY [codigo_prestamo]
    END
    ELSE
    BEGIN
        -- Restricción de identificación
        SELECT * FROM [dbo].[datos_prestamos]
          WHERE [identificacion] = @identificacion
		  ORDER BY [codigo_prestamo]
    END
END

GO

USE [proyectoTitulacion]
GO

/****** Object:  StoredProcedure [dbo].[sps_model_knowledge]    Script Date: 11/9/2023 10:25:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sps_model_knowledge]
AS
BEGIN
	select top 1 
	[umbral_default],
	[tasa_normativa],
	[tasa_min],
	[raroc_index],
	model_data
	from modelo_entrenado, modelo_parametros order by modelo_entrenado.id, modelo_parametros.id desc

END
GO

USE [proyectoTitulacion]
GO

/****** Object:  StoredProcedure [dbo].[sps_results]    Script Date: 11/9/2023 10:26:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sps_results]
AS
BEGIN
	select 
	datos_cliente_values.[identificacion],
	[fecha_nacimiento],
	[ingreso_mensual],
	[patrimonio],
	[estado_civil],
	[sexo],
	[nivel_academico],
	[edad],
	[origen_ingresos],
	[situacion_laboral],
	[numero_cargas],
	[tiempo_ultimo_trabajo],
	[PD],
	[EAD],
	[LGD],
	[PE],
	[PI],
	[tasa_ajustada]
	FROM [dbo].datos_cliente inner join [dbo].datos_cliente_values
	on  [dbo].datos_cliente.identificacion =  [dbo].datos_cliente_values.identificacion
END
GO

USE [proyectoTitulacion]
GO

/****** Object:  StoredProcedure [dbo].[sps_vals]    Script Date: 11/9/2023 10:26:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sps_vals]
AS
BEGIN
	select * FROM [dbo].datos_cliente_values
END
GO

USE [proyectoTitulacion]
GO

/****** Object:  StoredProcedure [dbo].[spu_incumplimiento]    Script Date: 11/9/2023 10:26:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spu_incumplimiento]
    @umbral int = 60
AS
BEGIN
	UPDATE [dbo].datos_cliente_vars
	SET incumplimiento = CASE WHEN dias_mora_media > @umbral and cartera_en_riesgo_media > 100 THEN 1 ELSE 0 END
END
GO

