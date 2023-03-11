USE dulcepastel

CREATE TABLE [clientes] (
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
  [cliente_flgElm] BIT  NULL,
  PRIMARY KEY CLUSTERED ([cliente_id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO

CREATE TABLE [estado_usuario] (
  [estado_usuario_id] varchar(4)  NOT NULL,
  [estado_descripcion] varchar(150)  NULL,
  [usuario_id_create] varchar(10)  NULL,
  [estado_create] datetime  NULL,
  [usuario_id_update] varchar(10)  NULL,
  [estado_update] datetime  NULL,
  [estado_usuario_flgElm] bit  NULL,
  PRIMARY KEY CLUSTERED ([estado_usuario_id])
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

CREATE TABLE [tipo_documento] (
  [tipo_documento_id] varchar(3) NOT NULL ,
  [tipo_documento_descripcion] varchar(100)  NULL,
  [usuario_id_create] varchar(10)  NULL,
  [tipo_documento_create] datetime  NULL,
  [usuario_id_update] varchar(10)  NULL,
  [tipo_documento_update] datetime  NULL,
  [tipo_documento_flgElm] bit  NULL,
  PRIMARY KEY CLUSTERED ([tipo_documento_id])
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
  [usuario_email] varchar(100)  NULL,
  [usuario_password] varchar(160)  NULL,
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
  PRIMARY KEY CLUSTERED ([usuario_id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO

ALTER TABLE [clientes] ADD CONSTRAINT [fk_tipo_cliente_documento_id] FOREIGN KEY ([tipo_documento_id]) REFERENCES [tipo_documento] ([tipo_documento_id])
GO
ALTER TABLE [clientes] NOCHECK CONSTRAINT [fk_tipo_cliente_documento_id]
GO
ALTER TABLE [usuario] ADD CONSTRAINT [fk_usuario_tipo_documento_id] FOREIGN KEY ([tipo_documento_id]) REFERENCES [tipo_documento] ([tipo_documento_id])
GO
ALTER TABLE [usuario] ADD CONSTRAINT [fk_usuario_estado_usuario_id] FOREIGN KEY ([estado_usuario_id]) REFERENCES [estado_usuario] ([estado_usuario_id])
GO
ALTER TABLE [usuario] ADD CONSTRAINT [fk_usuario_ocupacion_id] FOREIGN KEY ([ocupacion_id]) REFERENCES [ocupacion] ([ocupacion_id])
GO
ALTER TABLE [usuario] NOCHECK CONSTRAINT [fk_usuario_tipo_documento_id]
GO
ALTER TABLE [usuario] NOCHECK CONSTRAINT [fk_usuario_estado_usuario_id]
GO
ALTER TABLE [usuario] NOCHECK CONSTRAINT [fk_usuario_ocupacion_id]
GO


CREATE OR ALTER PROC SP_CLIENTES(
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
                SET @Cliente_id = (Select Right('00' + LTRIM(RTRIM(Convert(Varchar,Convert(Int,Isnull(Max(cliente_id),0))+1))),2) FROM clientes)
                INSERT INTO clientes VALUES(
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
                UPDATE clientes SET
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
                IF @@ERROR <> 0
                    BEGIN
                        SET @Msj = 'No se pudo actualizar en la tabla Clientes'
                        GOTO Error
                    end
            end

        IF @Opc = 'E'
            BEGIN
                UPDATE clientes SET
                    usuario_id_update = @Usuario_id_update,
                    cliente_flgElm = 1,
                    cliente_update = GETDATE()
                WHERE cliente_id = @Cliente_id
                IF @@ERROR <> 0
                    BEGIN
                        SET @Msj = 'No se pudo eliminar en la tabla Clientes'
                        GOTO Error
                    end
            end
    GOTO OK

OK:
    COMMIT TRAN X
    GOTO Fin

Error:
    ROLLBACK TRAN X
    goto Fin

Fin:
GO

CREATE OR ALTER PROC SP_TIPO_DOCUMENTO(
    @Opc CHAR,
	@IdTipoDoc VARCHAR(3),
    @Descripcion VARCHAR(100),
    @usrIdCre VARCHAR(10),
    @usrIdMod VARCHAR(10),
    @Msj VARCHAR(200) OUTPUT
)
AS
	BEGIN TRAN X
        SET @Descripcion = TRIM(@Descripcion)

        IF @Opc = 'N'
            BEGIN
                SET @IdTipoDoc = (Select Right('00' + LTRIM(RTRIM(Convert(Varchar,Convert(Int,Isnull(Max(tipo_documento_id),0))+1))),2) FROM tipo_documento)
                INSERT INTO tipo_documento VALUES(
                    @IdTipoDoc, @Descripcion,
                    @usrIdCre, GETDATE(),
                    @usrIdMod, GETDATE(), 0
                )
                IF @@ERROR <> 0
                    BEGIN
                        SET @Msj = 'No se pudo insertar en la tabla tipo_documento'
                        GOTO Error
                    end
            end

        IF @Opc = 'M'
            BEGIN
                UPDATE tipo_documento SET
                    tipo_documento_descripcion = @Descripcion,
                    usuario_id_update = @usrIdMod,
                    tipo_documento_update = GETDATE()
                WHERE tipo_documento_id = @IdTipoDoc AND tipo_documento.tipo_documento_flgElm <> 1
                IF @@ERROR <> 0
                    BEGIN
                        SET @Msj = 'No se pudo actualizar en la tabla tipo_documento'
                        GOTO Error
                    end
            end

        IF @Opc = 'E'
            BEGIN
                UPDATE tipo_documento SET
                    usuario_id_update = @usrIdMod,
                    tipo_documento_flgElm = 1,
                    tipo_documento_update = GETDATE()
                WHERE tipo_documento_id = @IdTipoDoc
                IF @@ERROR <> 0
                    BEGIN
                        SET @Msj = 'No se pudo eliminar en la tabla tipo_documento'
                        GOTO Error
                    end
            end
    GOTO OK

OK:
    COMMIT TRAN X
    GOTO Fin

Error:
    ROLLBACK TRAN X
    goto Fin

Fin:
GO

SELECT * FROM tipo_documento

EXEC SP_TIPO_DOCUMENTO @Opc = 'M', @IdTipoDoc = '01', @Descripcion = 'Dni', @usrIdCre = '01', @usrIdMod = '01', @Msj = _
