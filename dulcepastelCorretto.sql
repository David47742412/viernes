CREATE TABLE [cliente] (
  [cliente_id] varchar(10)  NOT NULL,
  [cliente_nombre] varchar(100)  NULL,
  [cliente_apellido] varchar(100)  NULL,
  [tipo_documento_id] varchar(3)  NULL,
  [cliente_nroDoc] varchar(20)  NULL,
  [cliente_direccion] varchar(150)  NULL,
  [cliente_celular] varchar(20)  NULL,
  [cliente_telefonoFijo] varchar(20)  NULL,
  [cliente_email] varchar(100)  NULL,
  [f_nacimiento] datetime  NULL,
  [usuario_id_create] varchar(10)  NULL,
  [cliente_create] datetime  NULL,
  [usuario_id_update] varchar(10)  NULL,
  [cliente_update] datetime  NULL,
  [cliente_flgElm] bit  NULL,
  CONSTRAINT [_copy_6] PRIMARY KEY CLUSTERED ([cliente_id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO

CREATE TABLE [comprobante] (
  [comprobante_id] varchar(12)  NOT NULL,
  [comprobante_descripcion] varchar(500)  NULL,
  [comprobante_PTotal] float  NULL,
  [usuario_id_create] varchar(10)  NULL,
  [comprobante_create] datetime  NULL,
  [usuario_id_update] varchar(10)  NULL,
  [comprobante_update] datetime  NULL,
  [comprobante_flgElm] bit  NULL,
  CONSTRAINT [_copy_15] PRIMARY KEY CLUSTERED ([comprobante_id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO

CREATE TABLE [comprobante_detalle] (
  [comprobante_id] varchar(12)  NULL,
  [producto_id] varchar(10)  NULL,
  [cliente_id] varchar(10)  NULL,
  [usuario_id] varchar(10)  NULL,
  [detalle_subtotal] float  NULL,
  [detalle_igv] float  NULL,
  [usuario_id_create] varchar(10)  NULL,
  [detalle_create] datetime  NULL,
  [usuario_id_update] varchar(10)  NULL,
  [detalle_update] datetime  NULL,
  [detalle_flgElm] bit  NULL
)
GO

CREATE TABLE [estado_usuario] (
  [estado_usuario_id] varchar(4)  NOT NULL,
  [usuario_id_create] varchar(10)  NULL,
  [estado_create] datetime  NULL,
  [usuario_id_update] varchar(10)  NULL,
  [estado_update] datetime  NULL,
  [estado_usuario_flgElm] bit  NULL,
  [estado_usuario_descripcion] varchar(200)  NULL,
  CONSTRAINT [_copy_11] PRIMARY KEY CLUSTERED ([estado_usuario_id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO

CREATE TABLE [familia] (
  [familia_id] varchar(10)  NOT NULL,
  [familia_descripcion] varchar(150)  NULL,
  [usuario_id_create] varchar(10)  NULL,
  [familia_create] datetime  NULL,
  [usuario_id_update] varchar(10)  NULL,
  [familia_update] datetime  NULL,
  [familia_flgElm] bit  NULL,
  CONSTRAINT [_copy_5] PRIMARY KEY CLUSTERED ([familia_id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO

CREATE TABLE [familia_detalle] (
  [familia_id] varchar(10)  NULL,
  [insumo_id] varchar(10)  NULL,
  [usuario_id_create] varchar(10)  NULL,
  [detalle_create] datetime  NULL,
  [usuario_id_update] varchar(10)  NULL,
  [detalle_update] datetime  NULL,
  [detalle_flgElm] bit  NULL
)
GO

CREATE TABLE [insumo] (
  [insumo_id] varchar(10)  NOT NULL,
  [insumo_nombre] varchar(150)  NULL,
  [usuario_id_create] varchar(10)  NULL,
  [insumo_create] datetime  NULL,
  [usuario_id_update] varchar(10)  NULL,
  [insumo_update] datetime  NULL,
  [insumo_flgElm] bit  NULL,
  [marca_id] varchar(6)  NULL,
  CONSTRAINT [_copy_3] PRIMARY KEY CLUSTERED ([insumo_id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO

CREATE TABLE [insumo_detalle] (
  [insumo_id] varchar(10)  NULL,
  [proveedor_id] varchar(10)  NULL,
  [presentacion_id] varchar(6)  NULL,
  [tipo_unidad_id] varchar(3)  NULL,
  [detalle_cantidad] int  NULL,
  [detalle_precioU] float  NULL,
  [detalle_precioT] float  NULL,
  [detalle_pesoT] float  NULL,
  [detalle_pesoU] float  NULL,
  [usuario_id_create] varchar(10)  NULL,
  [insumo_create] datetime  NULL,
  [usuario_id_update] varchar(10)  NULL,
  [insumo_update] datetime  NULL,
  [insumo_flgElm] bit  NULL
)
GO

CREATE TABLE [marca] (
  [marca_id] varchar(6)  NOT NULL,
  [marca_descripcion] varchar(150)  NULL,
  [usuario_id_create] varchar(10)  NULL,
  [marca_create] datetime  NULL,
  [usuario_id_update] varchar(10)  NULL,
  [marca_update] datetime  NULL,
  [marca_flgElm] bit  NULL,
  CONSTRAINT [_copy_7] PRIMARY KEY CLUSTERED ([marca_id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO

CREATE TABLE [ocupacion] (
  [ocupacion_id] varchar(6)  NOT NULL,
  [ocupacion_descripcion] varchar(150)  NULL,
  [usuario_id_create] varchar(10)  NULL,
  [ocupacion_create] datetime  NULL,
  [usuario_id_update] varchar(10)  NULL,
  [ocupacion_update] datetime  NULL,
  [ocupacion_flgElm] bit  NULL,
  PRIMARY KEY CLUSTERED ([ocupacion_id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO

CREATE TABLE [presentacion] (
  [presetancion_id] varchar(6)  NOT NULL,
  [presentacion_descripcion] varchar(150)  NULL,
  [usuario_id_create] varchar(10)  NULL,
  [presentacion_create] datetime  NULL,
  [usuario_id_update] varchar(10)  NULL,
  [presentacion_update] datetime  NULL,
  [presentacion_flgElm] bit  NULL,
  CONSTRAINT [_copy_4] PRIMARY KEY CLUSTERED ([presetancion_id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO

CREATE TABLE [producto] (
  [producto_id] varchar(10)  NOT NULL,
  [producto_nombre] varchar(100)  NULL,
  [producto_descripcion] varchar(300)  NULL,
  [producto_precio] float  NULL,
  [usuario_id_create] varchar(10)  NULL,
  [producto_create] datetime  NULL,
  [usuario_id_update] varchar(10)  NULL,
  [producto_update] datetime  NULL,
  [producto_flgElm] bit  NULL,
  CONSTRAINT [_copy_12_copy_1] PRIMARY KEY CLUSTERED ([producto_id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO

CREATE TABLE [proveedor] (
  [proveedor_id] varchar(10)  NOT NULL,
  [proveedor_ruc] varchar(11)  NULL,
  [proveedor_NComercial] varchar(200)  NULL,
  [proveedor_RazonSocial] varchar(300)  NULL,
  [proveedor_celular] varchar(20)  NULL,
  [proveedor_telefono] varchar(20)  NULL,
  [proveedor_pagina] varchar(150)  NULL,
  [proveedor_email] varchar(100)  NULL,
  [proveedor_direccion] varchar(150)  NULL,
  [proveedor_descripcion] varchar(300)  NULL,
  [proveedor_flgElm] bit  NULL,
  [usuario_id_create] varchar(10)  NULL,
  [proveedor_create] datetime  NULL,
  [usuario_id_update] varchar(10)  NULL,
  [proveedor_update] datetime  NULL,
  CONSTRAINT [_copy_8_copy_1] PRIMARY KEY CLUSTERED ([proveedor_id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO

CREATE TABLE [receta] (
  [receta_id] varchar(10)  NOT NULL,
  [producto_id] varchar(10)  NULL,
  [receta_descripcion] varchar(500)  NULL,
  [usuario_id_create] varchar(10)  NULL,
  [receta_create] datetime  NULL,
  [usuario_id_update] varchar(10)  NULL,
  [receta_update] datetime  NULL,
  [receta_flgElm] bit  NULL,
  CONSTRAINT [_copy_14] PRIMARY KEY CLUSTERED ([receta_id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO

CREATE TABLE [receta_detalle] (
  [receta_id] varchar(10)  NULL,
  [insumo_id] varchar(10)  NULL,
  [detalle_cantidad] float  NULL,
  [ususario_id_create] varchar(10)  NULL,
  [detalle_create] datetime  NULL,
  [usuario_id_update] varchar(10)  NULL,
  [detalle_update] datetime  NULL,
  [detalle_flgElm] bit  NULL
)
GO

CREATE TABLE [tipo_documento] (
  [tipo_documento_id] varchar(3)  NOT NULL,
  [tipo_documento_descripcion] varchar(100)  NULL,
  [usuario_id_create] varchar(10)  NULL,
  [tipo_documento_create] datetime  NULL,
  [usuario_id_update] varchar(10)  NULL,
  [tipo_documento_update] datetime  NULL,
  [tipo_documento_flgElm] bit  NULL,
  CONSTRAINT [_copy_10] PRIMARY KEY CLUSTERED ([tipo_documento_id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO

CREATE TABLE [tipo_unidad] (
  [tipo_unidad_id] varchar(3)  NOT NULL,
  [tipo_unidad_descripcion] varchar(50)  NULL,
  [usuario_id_create] varchar(10)  NULL,
  [tipo_unidad_create] datetime  NULL,
  [usuario_id_update] varchar(10)  NULL,
  [tipo_unidad_update] datetime  NULL,
  [tipo_unidad_flgElm] bit  NULL,
  CONSTRAINT [_copy_12] PRIMARY KEY CLUSTERED ([tipo_unidad_id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO

CREATE TABLE [usuario] (
  [usuario_id] varchar(10)  NOT NULL,
  [usuario_nombre] varchar(100)  NULL,
  [usuario_apellido] varchar(100)  NULL,
  [usuario_celular] varchar(20)  NULL,
  [usuario_direccion] varchar(100)  NULL,
  [usuario_nroDoc] varchar(20)  NULL,
  [usuario_email] varchar(100) NULL,
  [usuario_password] varchar(150) NULL,
  [tipo_documento_id] varchar(3)  NULL,
  [estado_usuario_id] varchar(4)  NULL,
  [usuario_foto] varchar(250)  NULL,
  [ocupacion_id] varchar(6)  NULL,
  [f_nacimiento] datetime  NULL,
  [usuario_id_create] varchar(10)  NULL,
  [usuario_create] datetime  NULL,
  [usuario_id_update] varchar(10)  NULL,
  [usuario_update] datetime  NULL,
  [usuario_flgElm] bit  NULL,
  CONSTRAINT [_copy_9] PRIMARY KEY CLUSTERED ([usuario_id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO

ALTER TABLE [cliente] ADD CONSTRAINT [fk_cliente_tipo_documento_id] FOREIGN KEY ([tipo_documento_id]) REFERENCES [tipo_documento] ([tipo_documento_id])
GO
ALTER TABLE [cliente] NOCHECK CONSTRAINT [fk_cliente_tipo_documento_id]
GO
ALTER TABLE [comprobante_detalle] ADD CONSTRAINT [fk_comprobante_detalle_cliente_id] FOREIGN KEY ([cliente_id]) REFERENCES [cliente] ([cliente_id])
GO
ALTER TABLE [comprobante_detalle] ADD CONSTRAINT [fk_comprobante_detalle_producto_id] FOREIGN KEY ([producto_id]) REFERENCES [producto] ([producto_id])
GO
ALTER TABLE [comprobante_detalle] ADD CONSTRAINT [fk_comprobante_detalle_usuario_id] FOREIGN KEY ([usuario_id]) REFERENCES [usuario] ([usuario_id])
GO
ALTER TABLE [comprobante_detalle] ADD CONSTRAINT [fk_comprobante_detalle_comprobante_id] FOREIGN KEY ([comprobante_id]) REFERENCES [comprobante] ([comprobante_id])
GO
ALTER TABLE [comprobante_detalle] NOCHECK CONSTRAINT [fk_comprobante_detalle_cliente_id]
GO
ALTER TABLE [comprobante_detalle] NOCHECK CONSTRAINT [fk_comprobante_detalle_producto_id]
GO
ALTER TABLE [comprobante_detalle] NOCHECK CONSTRAINT [fk_comprobante_detalle_usuario_id]
GO
ALTER TABLE [comprobante_detalle] NOCHECK CONSTRAINT [fk_comprobante_detalle_comprobante_id]
GO
ALTER TABLE [familia_detalle] ADD CONSTRAINT [fk_detalle_familia_id] FOREIGN KEY ([familia_id]) REFERENCES [familia] ([familia_id])
GO
ALTER TABLE [familia_detalle] ADD CONSTRAINT [fk_detalle_insumo_id] FOREIGN KEY ([insumo_id]) REFERENCES [insumo] ([insumo_id])
GO
ALTER TABLE [familia_detalle] NOCHECK CONSTRAINT [fk_detalle_familia_id]
GO
ALTER TABLE [familia_detalle] NOCHECK CONSTRAINT [fk_detalle_insumo_id]
GO
ALTER TABLE [insumo] ADD CONSTRAINT [fk_insumo_marca_id] FOREIGN KEY ([marca_id]) REFERENCES [marca] ([marca_id])
GO
ALTER TABLE [insumo] NOCHECK CONSTRAINT [fk_insumo_marca_id]
GO
ALTER TABLE [insumo_detalle] ADD CONSTRAINT [fk_insumo_detalle_insumo_id_copy_1] FOREIGN KEY ([insumo_id]) REFERENCES [insumo] ([insumo_id])
GO
ALTER TABLE [insumo_detalle] ADD CONSTRAINT [fk_insumo_detalle_proveedor_id] FOREIGN KEY ([proveedor_id]) REFERENCES [proveedor] ([proveedor_id])
GO
ALTER TABLE [insumo_detalle] ADD CONSTRAINT [fk_insumo_detalle_presentacion_id] FOREIGN KEY ([presentacion_id]) REFERENCES [presentacion] ([presetancion_id])
GO
ALTER TABLE [insumo_detalle] ADD CONSTRAINT [fk_insumo_detalle_tipo_unidad_id] FOREIGN KEY ([tipo_unidad_id]) REFERENCES [tipo_unidad] ([tipo_unidad_id])
GO
ALTER TABLE [insumo_detalle] NOCHECK CONSTRAINT [fk_insumo_detalle_insumo_id_copy_1]
GO
ALTER TABLE [insumo_detalle] NOCHECK CONSTRAINT [fk_insumo_detalle_proveedor_id]
GO
ALTER TABLE [insumo_detalle] NOCHECK CONSTRAINT [fk_insumo_detalle_presentacion_id]
GO
ALTER TABLE [insumo_detalle] NOCHECK CONSTRAINT [fk_insumo_detalle_tipo_unidad_id]
GO
ALTER TABLE [receta] ADD CONSTRAINT [fk_receta_producto_id] FOREIGN KEY ([producto_id]) REFERENCES [producto] ([producto_id])
GO
ALTER TABLE [receta] NOCHECK CONSTRAINT [fk_receta_producto_id]
GO
ALTER TABLE [receta_detalle] ADD CONSTRAINT [fk_receta_detalle_receta_id] FOREIGN KEY ([receta_id]) REFERENCES [receta] ([receta_id])
GO
ALTER TABLE [receta_detalle] ADD CONSTRAINT [fk_receta_detalle_insumo_id] FOREIGN KEY ([insumo_id]) REFERENCES [insumo] ([insumo_id])
GO
ALTER TABLE [receta_detalle] NOCHECK CONSTRAINT [fk_receta_detalle_receta_id]
GO
ALTER TABLE [receta_detalle] NOCHECK CONSTRAINT [fk_receta_detalle_insumo_id]
GO
ALTER TABLE [usuario] ADD CONSTRAINT [fk_usuario_tipo_documento_id] FOREIGN KEY ([tipo_documento_id]) REFERENCES [tipo_documento] ([tipo_documento_id])
GO
ALTER TABLE [usuario] ADD CONSTRAINT [fk_usuario_ocupacion_id] FOREIGN KEY ([ocupacion_id]) REFERENCES [ocupacion] ([ocupacion_id])
GO
ALTER TABLE [usuario] ADD CONSTRAINT [fk_usuario_estado_usuario_id] FOREIGN KEY ([estado_usuario_id]) REFERENCES [estado_usuario] ([estado_usuario_id])
GO
ALTER TABLE [usuario] NOCHECK CONSTRAINT [fk_usuario_tipo_documento_id]
GO
ALTER TABLE [usuario] NOCHECK CONSTRAINT [fk_usuario_ocupacion_id]
GO
ALTER TABLE [usuario] NOCHECK CONSTRAINT [fk_usuario_estado_usuario_id]
GO

CREATE   PROC [dbo].[SP_CLIENTE](
    @Opc CHAR,
	@Cliente_id VARCHAR(10),
    @Cliente_nombre VARCHAR(100),
    @Cliente_apellido VARCHAR(100),
    @TipoDocId VARCHAR(3),
    @NroDoc VARCHAR(20),
    @Direccion VARCHAR(150),
    @Celular VARCHAR(20),
    @TelfFijo VARCHAR(20),
    @email VARCHAR(100),
    @f_nacimiento DATETIME,
    @Usuario_id_create VARCHAR(10),
    @Usuario_id_update VARCHAR(10),
    @Msj VARCHAR(200) OUTPUT
)
AS
	BEGIN TRAN X
        SET @Cliente_nombre = TRIM(@Cliente_nombre)
        SET @Cliente_apellido = TRIM(@Cliente_apellido)
        SET @Direccion = TRIM(@Direccion)
        SET @NroDoc = TRIM(@NroDoc)
        SET @Celular = TRIM(@Celular)
        SET @TelfFijo = TRIM(@TelfFijo)
        SET @email = TRIM(LOWER(@email))

        IF @Opc = 'N'
            BEGIN
                SET @Cliente_id = (Select Right('00' + LTRIM(RTRIM(Convert(Varchar,Convert(Int,Isnull(Max(cliente_id),0))+1))),2) FROM cliente)
                INSERT INTO cliente VALUES(
                    @Cliente_id, @Cliente_nombre,
                    @Cliente_apellido, @TipoDocId,
                    @NroDoc, @Direccion, @Celular,
                    @TelfFijo, @email, @f_nacimiento,
                    @Usuario_id_create, GETDATE(),
                    @Usuario_id_update, GETDATE(),
                    0
                )
                IF @@ERROR <> 0
                    BEGIN
                        SET @Msj = 'No se pudo insertar en la tabla Clientes'
                        GOTO Error
                    end
            end

        IF @Opc = 'M'
            BEGIN
                UPDATE cliente SET
                    cliente_nombre = @Cliente_nombre,
                    cliente_apellido = @Cliente_apellido,
                    tipo_documento_id = @TipoDocId,
                    cliente_nroDoc = @NroDoc,
                    cliente_direccion = @Direccion,
                    cliente_celular = @Celular,
                    cliente_telefonoFijo = @TelfFijo,
                    cliente_email = @email,
                    f_nacimiento = @f_nacimiento,
                    usuario_id_update = @Usuario_id_update,
                    cliente_update = GETDATE()
                WHERE cliente_id = @Cliente_id AND cliente_flgElm <> 1
            end

        IF @Opc = 'E'
            BEGIN
                UPDATE cliente SET
                    usuario_id_update = @Usuario_id_update,
                    cliente_flgElm = 1,
                    cliente_update = GETDATE()
                WHERE cliente_id = @Cliente_id
            end
    GOTO OK

OK:
    COMMIT TRAN X
    GOTO Fin

Error:
    ROLLBACK TRAN X
    goto Fin

Fin:
go


CREATE OR ALTER PROCEDURE [dbo].[SP_ESTADO_USUARIO](
	@Opc CHAR,
	@Id VARCHAR(4),
	@descripcion VARCHAR(150),
	@userIdCre VARCHAR(10),
	@userIdMod VARCHAR(10),
	@Msj VARCHAR(200) OUTPUT
)
AS
	BEGIN TRAN X
	SET @descripcion = TRIM(@descripcion)

	IF @Opc = 'N'
		BEGIN
			SET @Id = (Select Right('00' + LTRIM(RTRIM(Convert(Varchar,Convert(Int,Isnull(Max(estado_usuario_id),0))+1))),2) FROM estado_usuario)
			INSERT INTO estado_usuario VALUES (@Id, @userIdCre, GETDATE(), @userIdMod, GETDATE(), 0, @descripcion)
			IF @@ERROR <> 0
				BEGIN
					SET @Msj = 'No se pudo insertar en estado_usuario'
					GOTO Error
				END
		END
	IF @Opc = 'M'
		BEGIN
			UPDATE estado_usuario SET
				usuario_id_update = @userIdMod,
				estado_usuario_descripcion = @descripcion,
				estado_update = GETDATE()
			WHERE estado_usuario_id = @Id AND estado_usuario_flgElm <> 1
			IF @@ERROR <> 0
				BEGIN
					SET @Msj = 'No se pudo insertar en estado_usuario'
					GOTO Error
				END
		END

	IF @Opc = 'E'
		BEGIN
			UPDATE estado_usuario SET
				estado_update = GETDATE(),
				usuario_id_update = @userIdMod,
				estado_usuario_flgElm = 1
			WHERE estado_usuario_id = @Id
			IF @@ERROR <> 0
				BEGIN
					SET @Msj = 'no se pudo eliminar en estado_usuario'
					GOTO Error
				END
		END
	GOTO OK
OK:
	COMMIT TRAN X
	GOTO Fin

Error:
	ROLLBACK TRAN X
	GOTO Fin

Fin:
go

CREATE   PROCEDURE [dbo].[SP_LOGIN](
	@Email NVARCHAR(100)
)
AS
DECLARE @Sql NVARCHAR(MAX), @params NVARCHAR(MAX)
	BEGIN
		SET @params = '@Email NVARCHAR(MAX)'
		SET @Sql = 'select usuario_id, usuario_nombre, usuario_apellido, usuario_celular, usuario_foto, f_nacimiento, usuario_password ' +
			'from usuario WHERE usuario_email = @Email AND usuario_flgElm <> 1'
		EXEC sp_executesql @Sql, @params, @Email = @Email
	END
go

CREATE   PROCEDURE [dbo].[SP_OCUPACION](
	@Opc CHAR,
	@id VARCHAR(6),
	@descripcion VARCHAR(150),
	@UseridCreate VARCHAR(10),
	@UseridUpdate VARCHAR(10),
	@Msj VARCHAR(200) OUTPUT
)
AS
	BEGIN TRAN X
	SET @descripcion = TRIM(@descripcion)

	IF @Opc = 'N'
		BEGIN
			SET @id = (Select Right('00' + LTRIM(RTRIM(Convert(Varchar,Convert(Int,Isnull(Max(ocupacion_id),0))+1))),2) FROM ocupacion)
			INSERT INTO ocupacion VALUES(@id, @descripcion, @UseridCreate, GETDATE(), @UseridUpdate, GETDATE(), 0)
			IF @@ERROR <> 0
				BEGIN
					SET @Msj = 'No se pudo insertar en ocupacion'
					GOTO Error
				END
		END
	IF @Opc = 'M'
		BEGIN
			UPDATE ocupacion SET
				ocupacion_descripcion = @descripcion,
				usuario_id_update = @UseridUpdate,
				ocupacion_update = GETDATE()
			WHERE ocupacion_id = @id AND ocupacion_flgElm <> 1
			IF @@ERROR <> 0
				BEGIN
					SET @Msj = 'No se pudo actualizar en ocupacion'
					GOTO Error
				END
		END
	IF @Opc = 'E'
		BEGIN
			UPDATE ocupacion SET
				ocupacion_flgElm = 1,
				usuario_id_update = @UseridUpdate,
				ocupacion_update = GETDATE()
			WHERE ocupacion_id = @id
			IF @@ERROR <> 0
				BEGIN
					SET @Msj = 'No se pudo eliminar en ocupacion'
					GOTO Error
				END
		END
	GOTO OK

OK:
	COMMIT TRAN X
	GOTO Fin

Error:
	ROLLBACK TRAN X
	GOTO Fin

Fin:
go

CREATE   PROCEDURE [dbo].[SP_TIPO_DOCUMENTO] (
	@Opc CHAR,
	@id VARCHAR(3),
	@descripcion VARCHAR(100),
	@UseridCre VARCHAR(10),
	@UseridUpd VARCHAR(10),
	@Msj VARCHAR(200) OUTPUT
)
AS
	BEGIN TRAN X
		SET @descripcion = TRIM(@descripcion)
		IF @Opc = 'N'
			BEGIN
				set @id = (Select Right('00' + LTRIM(RTRIM(Convert(Varchar,Convert(Int,Isnull(Max(tipo_documento_id),0))+1))),2) FROM tipo_documento)
				INSERT INTO tipo_documento VALUES(@id, @descripcion, @UseridCre, GETDATE(), @UseridUpd, GETDATE(), 0)
				IF @@ERROR <> 0
					BEGIN
						SET @Msj = 'No se pudo insertar en la tabla tipo_documento'
						GOTO Error
					END
			END
		IF @Opc = 'M'
			BEGIN
				UPDATE tipo_documento SET
					tipo_documento_descripcion = @descripcion,
					usuario_id_update = @UseridUpd,
					tipo_documento_update = GETDATE()
				WHERE tipo_documento_id = @id AND tipo_documento_flgElm <> 1
				IF @@ERROR <> 0
					BEGIN
						SET @Msj = 'No se pudo actualizar en la tabla tipo_documento'
						GOTO Error
					END
			END
		IF @Opc = 'E'
			BEGIN
				UPDATE tipo_documento SET
					tipo_documento_flgElm = 1,
					tipo_documento_update = GETDATE(),
					usuario_id_update = @UseridUpd
				WHERE tipo_documento_id = @id
				IF @@ERROR <> 0
					BEGIN
						SET @Msj = 'No se pudo eliminar en la tabla tipo_documento'
						GOTO Error
					END
			END
	GOTO OK

OK:
	COMMIT TRAN X
	GOTO Fin

Error:
	ROLLBACK TRAN X
	GOTO Fin

Fin:
go

CREATE   PROCEDURE [dbo].[SP_VIEW_CLIENTE](
	@Id VARCHAR(10) = '',
	@Nombre VARCHAR(100) = '',
	@Apellido VARCHAR(100) = '',
	@DesDocument VARCHAR(200) = '',
	@NroDoc VARCHAR(20) = '',
	@Direccion VARCHAR(150) = '',
	@Celular VARCHAR(20) = '',
	@TelfFijo VARCHAR(20) = '',
	@Email VARCHAR(100) = '',
	@F_NACIMIENTO DATETIME = 'Jan  1 1900 12:00AM'
)
AS
    BEGIN
        SELECT C.cliente_id, IIF(LEN(C.cliente_nombre) = 0, 'no asignado', C.cliente_nombre) AS cliente_nombre, IIF(LEN(C.cliente_apellido) = 0, 'no asignado', C.cliente_apellido) AS cliente_apellido,
               IIF(LEN(TD.tipo_documento_descripcion) = 0, 'no asignado', TD.tipo_documento_descripcion) AS tipo_documento_descripcion, IIF(LEN(C.cliente_nroDoc) = 0, 'no asignado', C.cliente_nroDoc) AS cliente_nroDoc,
			   IIF(LEN(C.cliente_direccion) = 0, 'no asignado', C.cliente_direccion) AS cliente_direccion,IIF(LEN(C.cliente_celular) = 0, 'no asignado', C.cliente_celular) AS cliente_celular,
               IIF(LEN(C.cliente_telefonoFijo) = 0, 'no asignado', C.cliente_telefonoFijo) AS cliente_telefonoFijo, IIF(LEN(C.cliente_email) = 0, 'no asignado', C.cliente_email) AS cliente_email,
			   C.f_nacimiento
               FROM cliente C
                   JOIN tipo_documento td on C.tipo_documento_id = td.tipo_documento_id
        WHERE cliente_flgElm <> 1
          AND (LEN(@Id) = 0 OR C.cliente_id LIKE '%' + @Id + '%')
          AND (LEN(@Nombre) = 0 OR C.cliente_nombre LIKE '%' + @Nombre + '%')
          AND (LEN(@Apellido) = 0 OR C.cliente_apellido LIKE '%' + @Apellido + '%')
          AND (LEN(@DesDocument) = 0 OR TD.tipo_documento_descripcion LIKE '%' + @DesDocument + '%')
          AND (LEN(@NroDoc) = 0 OR C.cliente_nroDoc LIKE '%' + @NroDoc + '%')
          AND (LEN(@Direccion) = 0 OR C.cliente_direccion LIKE '%' + @Direccion + '%')
          AND (LEN(@Celular) = 0 OR C.cliente_celular LIKE '%' + @Celular + '%')
          AND (LEN(@TelfFijo) = 0 OR C.cliente_telefonoFijo LIKE '%' + @TelfFijo + '%')
          AND (LEN(@Email) = 0 OR C.cliente_email LIKE '%' + @Email + '%')
          AND (LEN(@F_NACIMIENTO) = 19 AND @F_NACIMIENTO = 'Jan  1 1900 12:00AM' OR CONVERT(VARCHAR, C.f_nacimiento) LIKE '%' + CONVERT(VARCHAR, @F_NACIMIENTO) + '%')
    end
go

CREATE   PROCEDURE [dbo].[SP_VIEW_ESTADO_USUARIO](
	@id VARCHAR(4),
	@descripcion VARCHAR(150)
)
AS
	BEGIN
		SELECT estado_usuario_id, estado_usuario_descripcion
			FROM estado_usuario
			WHERE (LEN(@id) = 0 OR estado_usuario_id LIKE '%' + @id +'%')
				  AND (LEN(@descripcion) = 0 OR estado_usuario_descripcion LIKE '%' + @descripcion + '%')
				  AND estado_usuario_flgElm <> 1
			ORDER BY CONVERT(INT, estado_usuario_id)
	END
go

CREATE   PROCEDURE [dbo].[SP_VIEW_OCUPACION](
	@Id VARCHAR(6),
	@descripcion VARCHAR(150)
)
AS
	BEGIN
		SELECT ocupacion_id, ocupacion_descripcion FROM ocupacion
		WHERE (LEN(@Id) = 0 OR ocupacion_id LIKE '%' + @Id + '%')
			AND (LEN(@descripcion) = 0 OR ocupacion_descripcion LIKE '%' + @descripcion + '%')
			AND ocupacion_flgElm <> 1
		ORDER BY CONVERT(INT, ocupacion_id)
	END
go

CREATE       PROCEDURE [dbo].[SP_VIEW_TIPO_DOCUMENTO](
	@id VARCHAR(3),
	@descripcion VARCHAR(100)
)
AS
	BEGIN
		SELECT tipo_documento_id, tipo_documento_descripcion
			FROM tipo_documento
		WHERE (LEN(@id) = 0 OR tipo_documento_id LIKE '%' + @id + '%')
			  AND (LEN(@descripcion) = 0 OR tipo_documento_descripcion LIKE '%' + @descripcion + '%')
			  AND tipo_documento_flgElm <> 1
		ORDER BY CONVERT(INT, tipo_documento_id)
	END
go


EXEC SP_TIPO_DOCUMENTO @Opc = 'N', @id = _, @descripcion = 'DNI', @UseridCre = '01', @UseridUpd = '01', @Msj = _
EXEC SP_ESTADO_USUARIO @Opc = 'N', @Id = _, @descripcion = 'TRABAJANDO', @userIdCre = '01', @userIdMod = '01', @Msj = _
EXEC SP_OCUPACION @Opc = 'N', @id = _, @descripcion = 'Administrador', @UseridCreate = '01', @UseridUpdate = '01', @Msj = _

INSERT usuario VALUES ('01', 'Darwin David',
                       'Castro Astudillo', '934254896', 'Piura', '74465072','david@gmail.com', '$2a$12$sh9XvQd73TrEC4WSHvvV.etH7s5CHBtMTczxoqzw9HXPIYME5rBzO',
                       '01', '01', 'https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_640.png',
                       '01', '2004-12-26', '01', GETDATE(), '01', GETDATE(), 0)
