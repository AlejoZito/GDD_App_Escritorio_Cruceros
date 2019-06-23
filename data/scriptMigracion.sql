USE [GD1C2019]
GO

--*************************************************************************************************************
-- DROP CONTRAINTS
-- Realizo un DROP de las FK para permitirme luego hacer un DROP de la tablas
--*************************************************************************************************************

DECLARE cursor_tablas CURSOR FOR
SELECT 
    'ALTER TABLE [' +  OBJECT_SCHEMA_NAME(parent_object_id) +
    '].[' + OBJECT_NAME(parent_object_id) + 
    '] DROP CONSTRAINT [' + name + ']'
FROM sys.foreign_keys

DECLARE @sql nvarchar(255)
OPEN cursor_tablas
FETCH NEXT FROM cursor_tablas INTO @sql

WHILE @@FETCH_STATUS = 0
	BEGIN
	exec    sp_executesql @sql
	FETCH NEXT FROM cursor_tablas INTO @sql
	END
CLOSE cursor_tablas
DEALLOCATE cursor_tablas
GO


--*************************************************************************************************************
-- DROP TABLES
-- Realizo un DROP de las tablas previo a su creación en caso existan
--*************************************************************************************************************

IF OBJECT_ID('[TIRANDO_QUERIES].[Cliente]','U') IS NOT NULL DROP TABLE [TIRANDO_QUERIES].[Cliente];
IF OBJECT_ID('[TIRANDO_QUERIES].[Pasaje]','U') IS NOT NULL DROP TABLE [TIRANDO_QUERIES].[Pasaje];
IF OBJECT_ID('[TIRANDO_QUERIES].[Pago]','U') IS NOT NULL DROP TABLE [TIRANDO_QUERIES].[Pago];
IF OBJECT_ID('[TIRANDO_QUERIES].[Estado_Pasaje]','U') IS NOT NULL DROP TABLE [TIRANDO_QUERIES].[Estado_Pasaje];
IF OBJECT_ID('[TIRANDO_QUERIES].[Ruta_Viaje]','U') IS NOT NULL DROP TABLE [TIRANDO_QUERIES].[Ruta_Viaje];
IF OBJECT_ID('[TIRANDO_QUERIES].[Recorrido]','U') IS NOT NULL DROP TABLE [TIRANDO_QUERIES].[Recorrido];
IF OBJECT_ID('[TIRANDO_QUERIES].[Tramo]','U') IS NOT NULL DROP TABLE [TIRANDO_QUERIES].[Tramo];
IF OBJECT_ID('[TIRANDO_QUERIES].[Puerto]','U') IS NOT NULL DROP TABLE [TIRANDO_QUERIES].[Puerto];
IF OBJECT_ID('[TIRANDO_QUERIES].[Crucero]','U') IS NOT NULL DROP TABLE [TIRANDO_QUERIES].[Crucero];
IF OBJECT_ID('[TIRANDO_QUERIES].[Modelo_Crucero]','U') IS NOT NULL DROP TABLE [TIRANDO_QUERIES].[Modelo_Crucero];
IF OBJECT_ID('[TIRANDO_QUERIES].[Mantenimiento]','U') IS NOT NULL DROP TABLE [TIRANDO_QUERIES].[Mantenimiento];
IF OBJECT_ID('[TIRANDO_QUERIES].[Fabricante]','U') IS NOT NULL DROP TABLE [TIRANDO_QUERIES].[Fabricante];
IF OBJECT_ID('[TIRANDO_QUERIES].[Cabina]','U') IS NOT NULL DROP TABLE [TIRANDO_QUERIES].[Cabina];
IF OBJECT_ID('[TIRANDO_QUERIES].[Tipo_Cabina]','U') IS NOT NULL DROP TABLE [TIRANDO_QUERIES].[Tipo_Cabina];
IF OBJECT_ID('[TIRANDO_QUERIES].[Reserva]','U') IS NOT NULL DROP TABLE [TIRANDO_QUERIES].[Reserva];
IF OBJECT_ID('[TIRANDO_QUERIES].[Estado_Reserva]','U') IS NOT NULL DROP TABLE [TIRANDO_QUERIES].[Estado_Reserva];
IF OBJECT_ID('[TIRANDO_QUERIES].[Usuario]','U') IS NOT NULL DROP TABLE [TIRANDO_QUERIES].[Usuario];
IF OBJECT_ID('[TIRANDO_QUERIES].[Rol_Usuario]','U') IS NOT NULL DROP TABLE [TIRANDO_QUERIES].[Rol_Usuario];
IF OBJECT_ID('[TIRANDO_QUERIES].[Rol]','U') IS NOT NULL DROP TABLE [TIRANDO_QUERIES].[Rol];
IF OBJECT_ID('[TIRANDO_QUERIES].[Permiso_Rol]','U') IS NOT NULL DROP TABLE [TIRANDO_QUERIES].[Permiso_Rol];
IF OBJECT_ID('[TIRANDO_QUERIES].[Permiso]','U') IS NOT NULL DROP TABLE [TIRANDO_QUERIES].[Permiso];
GO

--*************************************************************************************************************
-- DROP STORED PROCEDURES
-- Realizo un DROP de los SP previo a su creación en caso existan
--*************************************************************************************************************

-- sp_postergar_viajes
IF OBJECT_ID('[TIRANDO_QUERIES].sp_postergar_viajes') IS NOT NULL DROP PROCEDURE [TIRANDO_QUERIES].sp_postergar_viajes;
IF OBJECT_ID('[TIRANDO_QUERIES].sp_vencer_reservas') IS NOT NULL DROP PROCEDURE [TIRANDO_QUERIES].sp_vencer_reservas;
IF OBJECT_ID('[TIRANDO_QUERIES].sp_esta_bloqueado_usuario') IS NOT NULL DROP PROCEDURE [TIRANDO_QUERIES].sp_esta_bloqueado_usuario;
IF OBJECT_ID('[TIRANDO_QUERIES].sp_actualizar_cliente') IS NOT NULL DROP PROCEDURE [TIRANDO_QUERIES].sp_actualizar_cliente;
IF OBJECT_ID('[TIRANDO_QUERIES].sp_autenticar_usuario') IS NOT NULL DROP PROCEDURE [TIRANDO_QUERIES].sp_autenticar_usuario;
IF OBJECT_ID('[TIRANDO_QUERIES].sp_pago_reserva') IS NOT NULL DROP PROCEDURE [TIRANDO_QUERIES].sp_pago_reserva;
IF OBJECT_ID('[TIRANDO_QUERIES].sp_encontrar_cruceros_reemplazo') IS NOT NULL DROP PROCEDURE [TIRANDO_QUERIES].sp_encontrar_cruceros_reemplazo;
GO

--*************************************************************************************************************
-- DROP FUNCTIONS
-- Realizo un DROP de las funciones previo a su creación en caso existan
--*************************************************************************************************************

IF OBJECT_ID('[TIRANDO_QUERIES].fn_existe_usuario') IS NOT NULL DROP FUNCTION [TIRANDO_QUERIES].[fn_existe_usuario];
GO

--*************************************************************************************************************
-- DROP TRIGGERS
-- Realizo un DROP de los triggers previo a su creación en caso existan
--*************************************************************************************************************

IF OBJECT_ID('[TIRANDO_QUERIES].[trg_baja_recorrido_por_baja_puerto]') IS NOT NULL DROP TRIGGER [TIRANDO_QUERIES].[trg_bajaRecorridoPorBajaPuerto];
IF OBJECT_ID('[TIRANDO_QUERIES].[trg_cancelar_pasajes_vigentes_por_baja_recorrido]') IS NOT NULL DROP TRIGGER [TIRANDO_QUERIES].[trg_cancelarPasajesVigentesPorBajaRecorrido];
IF OBJECT_ID('[TIRANDO_QUERIES].[trg_quitar_rol_de_usuario_por_baja_logica]') IS NOT NULL DROP TRIGGER [TIRANDO_QUERIES].[trg_quitar_rol_de_usuario_por_baja_logica];
GO


--*************************************************************************************************************
--*************************************************************************************************************
-- CREACION DE SCHEMA
--*************************************************************************************************************
--*************************************************************************************************************

IF NOT EXISTS (SELECT 1 FROM sys.schemas WHERE name = 'TIRANDO_QUERIES')
BEGIN
	EXEC ('CREATE SCHEMA [TIRANDO_QUERIES] AUTHORIZATION gdCruceros2019')
END
GO


--*************************************************************************************************************
--*************************************************************************************************************
-- CREACION DE TABLAS
--*************************************************************************************************************
--*************************************************************************************************************


--*************************************************************************************************************
-- TABLE CLIENTE
--*************************************************************************************************************

CREATE TABLE [TIRANDO_QUERIES].[Cliente] (
	[clie_codigo] [NUMERIC] IDENTITY(1,1) PRIMARY KEY,
	[clie_nombre] [NVARCHAR](255) NOT NULL,
	[clie_apellido] [NVARCHAR](255) NOT NULL,
	[clie_dni] [NUMERIC] NOT NULL,
	[clie_telefono] [INT] NOT NULL,
	[clie_direccion] [NVARCHAR](255) NOT NULL,
	[clie_mail] [NVARCHAR](255) NOT NULL,
	[clie_fecha_nac] DATETIME2(3) NOT NULL,
	[clie_duplicado] BIT DEFAULT 0
)
GO

--*************************************************************************************************************
-- TABLE FABRICANTE
--*************************************************************************************************************

CREATE TABLE [TIRANDO_QUERIES].[Fabricante] (
	[fabr_codigo] [NUMERIC] IDENTITY(1,1) PRIMARY KEY,
	[fabr_detalle] [NVARCHAR](255) NOT NULL UNIQUE
)
GO

--*************************************************************************************************************
-- TABLE MODELO_CRUCERO
--*************************************************************************************************************

CREATE TABLE [TIRANDO_QUERIES].[Modelo_Crucero] (
	[mc_codigo] [NUMERIC] IDENTITY(1,1) PRIMARY KEY,
	[mc_detalle] [NVARCHAR](50) NOT NULL UNIQUE
)
GO

--*************************************************************************************************************
-- TABLE CRUCERO
--*************************************************************************************************************

CREATE TABLE [TIRANDO_QUERIES].[Crucero] (
	[cruc_codigo] [NUMERIC] IDENTITY(1,1) PRIMARY KEY,
	[cruc_identificador] [NVARCHAR](50) NULL,
	[cruc_fabricante] [NUMERIC] NOT NULL,
	[cruc_modelo] [NUMERIC] NOT NULL,
	[cruc_activo] BIT DEFAULT 1,
	FOREIGN KEY (cruc_fabricante) REFERENCES [TIRANDO_QUERIES].Fabricante(fabr_codigo) ON DELETE CASCADE,
	FOREIGN KEY (cruc_modelo) REFERENCES [TIRANDO_QUERIES].Modelo_Crucero(mc_codigo) ON DELETE CASCADE
)
GO

--*************************************************************************************************************
-- TABLE MANTENIMIENTO
--*************************************************************************************************************

CREATE TABLE [TIRANDO_QUERIES].[Mantenimiento] (
	[mant_codigo] [NUMERIC] IDENTITY(1,1) PRIMARY KEY,
	[mant_crucero] [NUMERIC] NOT NULL,
	[mant_fecha_desde] DATETIME2(3),
	[mant_fecha_hasta] DATETIME2(3),
	FOREIGN KEY (mant_crucero) REFERENCES [TIRANDO_QUERIES].Crucero(cruc_codigo)
)
GO

--*************************************************************************************************************
-- TABLE TIPO_CABINA
--*************************************************************************************************************

CREATE TABLE [TIRANDO_QUERIES].[Tipo_Cabina] (
	[tc_codigo] [NUMERIC] IDENTITY(1,1) PRIMARY KEY,
	[tc_detalle] [NVARCHAR](255) NOT NULL,
	[tc_porc_recargo] [DECIMAL](18,2) NOT NULL
)
GO

--*************************************************************************************************************
-- TABLE CABINA
--*************************************************************************************************************

CREATE TABLE [TIRANDO_QUERIES].[Cabina] (
	[cabi_codigo] [NUMERIC] IDENTITY(1,1) PRIMARY KEY,
	[cabi_numero] [DECIMAL](18,0) NOT NULL,
	[cabi_piso] [DECIMAL](18,0) NOT NULL,
	[cabi_cod_tipo] [NUMERIC] NOT NULL,
	[cabi_crucero] [NUMERIC] NOT NULL,
	FOREIGN KEY (cabi_crucero) REFERENCES [TIRANDO_QUERIES].Crucero(cruc_codigo)
)
GO

--*************************************************************************************************************
-- TABLE ESTADO_RESERVA
--*************************************************************************************************************

CREATE TABLE [TIRANDO_QUERIES].[Estado_Reserva] (
	[er_codigo] [NUMERIC] IDENTITY(1,1) PRIMARY KEY,
	[er_estado] [NVARCHAR](255) NOT NULL,
	[er_motivo] [NVARCHAR](255) NOT NULL
)
GO

--*************************************************************************************************************
-- TABLE PUERTO
--*************************************************************************************************************

CREATE TABLE [TIRANDO_QUERIES].[Puerto] (
	[puer_codigo] [NUMERIC] IDENTITY(1,1) PRIMARY KEY,
	[puer_nombre] [NVARCHAR](255) NOT NULL UNIQUE,
	[puer_activo] BIT NOT NULL DEFAULT 1
)
GO

--*************************************************************************************************************
-- TABLE RECORRIDO
--*************************************************************************************************************

CREATE TABLE [TIRANDO_QUERIES].[Recorrido] (
	[reco_codigo] [NUMERIC] IDENTITY(1,1) PRIMARY KEY,
	[reco_activo] BIT NOT NULL DEFAULT 1,
	[reco_invalido] BIT NOT NULL DEFAULT 0
)
GO

--*************************************************************************************************************
-- TABLE TRAMO
--*************************************************************************************************************

CREATE TABLE [TIRANDO_QUERIES].[Tramo] (
	[tram_recorrido] [NUMERIC],
	[tram_puerto_desde] [NUMERIC],
	[tram_puerto_hasta] [NUMERIC],
	[tram_precio] [NUMERIC],
	[tram_orden] [INT],
	PRIMARY KEY (tram_recorrido,tram_puerto_desde,tram_puerto_hasta),
	FOREIGN KEY (tram_recorrido) REFERENCES [TIRANDO_QUERIES].Recorrido(reco_codigo),
	FOREIGN KEY (tram_puerto_desde) REFERENCES [TIRANDO_QUERIES].Puerto(puer_codigo),
	FOREIGN KEY (tram_puerto_hasta) REFERENCES [TIRANDO_QUERIES].Puerto(puer_codigo)
)
GO

--*************************************************************************************************************
-- TABLE RUTA_VIAJE
--*************************************************************************************************************

CREATE TABLE [TIRANDO_QUERIES].[Ruta_Viaje] (
	[rv_codigo] [NUMERIC] IDENTITY(1,1) PRIMARY KEY,
	[rv_recorrido] [NUMERIC] NOT NULL,
	[rv_crucero] [NUMERIC] NOT NULL,
	[rv_fecha_salida] DATETIME2(3) NOT NULL,
	[rv_fecha_llegada] DATETIME2(3) DEFAULT NULL,
	[rv_fecha_llegada_estimada] DATETIME2(3) NOT NULL,
	FOREIGN KEY (rv_recorrido) REFERENCES [TIRANDO_QUERIES].Recorrido(reco_codigo),
	FOREIGN KEY (rv_crucero) REFERENCES [TIRANDO_QUERIES].Crucero(cruc_codigo)
)
GO

--*************************************************************************************************************
-- TABLE ESTADO_PASAJE
--*************************************************************************************************************

CREATE TABLE [TIRANDO_QUERIES].[Estado_Pasaje] (
	[ep_codigo] [NUMERIC] IDENTITY(1,1) PRIMARY KEY,
	[ep_estado] [NVARCHAR](255) NOT NULL,
	[ep_motivo] [NVARCHAR](255) NOT NULL
)
GO

--*************************************************************************************************************
-- TABLE PAGO
--*************************************************************************************************************

CREATE TABLE [TIRANDO_QUERIES].[Pago] (
	[pago_codigo] [NUMERIC] IDENTITY(1,1) PRIMARY KEY,
	[pago_medio_pago] [VARCHAR](255) NOT NULL,
	[pago_cuotas] [INT]
)
GO

--*************************************************************************************************************
-- TABLE PASAJE
--*************************************************************************************************************

CREATE TABLE [TIRANDO_QUERIES].[Pasaje] (
	[pasa_codigo] [NUMERIC] IDENTITY(1,1) PRIMARY KEY,
	[pasa_precio] [DECIMAL](18,2) NOT NULL,
	[pasa_cabina] [NUMERIC] NOT NULL,
	[pasa_cliente] [NUMERIC] NOT NULL,
	[pasa_estado] [NUMERIC] NOT NULL,
	[pasa_pago] [NUMERIC] NOT NULL,
	[pasa_ruta] [NUMERIC] NOT NULL,
	[pasa_fecha_pago] DATETIME2(3),
	FOREIGN KEY (pasa_cabina) REFERENCES [TIRANDO_QUERIES].Cabina(cabi_codigo),
	FOREIGN KEY (pasa_cliente) REFERENCES [TIRANDO_QUERIES].Cliente(clie_codigo),
	FOREIGN KEY (pasa_estado) REFERENCES [TIRANDO_QUERIES].Estado_Pasaje(ep_codigo),
	FOREIGN KEY (pasa_pago) REFERENCES [TIRANDO_QUERIES].Pago(pago_codigo),
	FOREIGN KEY (pasa_ruta) REFERENCES [TIRANDO_QUERIES].Ruta_Viaje(rv_codigo)
)
GO

--*************************************************************************************************************
-- TABLE RESERVA
--*************************************************************************************************************

CREATE TABLE [TIRANDO_QUERIES].[Reserva] (
	[rese_codigo] [NUMERIC] IDENTITY(1,1) PRIMARY KEY,
	[rese_precio]  [DECIMAL](18,2) NOT NULL,
	[rese_fecha] DATETIME2(3),
	[rese_cabina] [NUMERIC] NOT NULL,
	[rese_cliente] [NUMERIC] NOT NULL,
	[rese_estado] [NUMERIC] NOT NULL,
	[rese_ruta] [NUMERIC] NOT NULL,
	FOREIGN KEY (rese_cabina) REFERENCES [TIRANDO_QUERIES].Cabina(cabi_codigo),
	FOREIGN KEY (rese_cliente) REFERENCES [TIRANDO_QUERIES].Cliente(clie_codigo),
	FOREIGN KEY (rese_estado) REFERENCES [TIRANDO_QUERIES].Estado_Reserva(er_codigo),
	FOREIGN KEY (rese_ruta) REFERENCES [TIRANDO_QUERIES].Ruta_Viaje(rv_codigo)
)
GO

--*************************************************************************************************************
-- TABLE USUARIO
--*************************************************************************************************************

CREATE TABLE [TIRANDO_QUERIES].[Usuario] (
	[usua_codigo] [NUMERIC] IDENTITY(1,1) PRIMARY KEY,
	[usua_username] [NVARCHAR](255) NOT NULL UNIQUE,
	[usua_password] [NVARCHAR](255) NOT NULL,
	[usua_login_fallidos] INT NOT NULL DEFAULT 0,
	[usua_fecha_inhabilitacion] DATETIME2(3)
)
GO

--*************************************************************************************************************
-- TABLE ROL
--*************************************************************************************************************

CREATE TABLE [TIRANDO_QUERIES].[Rol] (
	[rol_codigo] [NUMERIC] IDENTITY(1,1) PRIMARY KEY,
	[rol_nombre] [NVARCHAR](255) NOT NULL UNIQUE,
	[rol_activo] [BIT] NOT NULL DEFAULT 1,
)
GO

--*************************************************************************************************************
-- TABLE PERMISO
--*************************************************************************************************************

CREATE TABLE [TIRANDO_QUERIES].[Permiso] (
	[perm_codigo] [NUMERIC] IDENTITY(1,1) PRIMARY KEY,
	[perm_nombre] [NVARCHAR](255) NOT NULL UNIQUE
)
GO

--*************************************************************************************************************
-- TABLE ROL_USUARIO
--*************************************************************************************************************

CREATE TABLE [TIRANDO_QUERIES].[Rol_Usuario] (
	[ru_usua_codigo] [NUMERIC],
	[ru_rol_codigo] [NUMERIC],
	PRIMARY KEY (ru_usua_codigo,ru_rol_codigo),
	FOREIGN KEY (ru_usua_codigo) REFERENCES [TIRANDO_QUERIES].Usuario(usua_codigo),
	FOREIGN KEY (ru_rol_codigo) REFERENCES [TIRANDO_QUERIES].Rol(rol_codigo)
)
GO

--*************************************************************************************************************
-- TABLE PERMISO_ROL
--*************************************************************************************************************

CREATE TABLE [TIRANDO_QUERIES].[Permiso_Rol] (
	[pr_rol_codigo] [NUMERIC],
	[pr_perm_codigo] [NUMERIC],
	PRIMARY KEY (pr_rol_codigo,pr_perm_codigo),
	FOREIGN KEY (pr_rol_codigo) REFERENCES [TIRANDO_QUERIES].Rol(rol_codigo),
	FOREIGN KEY (pr_perm_codigo) REFERENCES [TIRANDO_QUERIES].Permiso(perm_codigo)
)
GO


--*************************************************************************************************************
--*************************************************************************************************************
-- MIGRACION DE DATOS
--*************************************************************************************************************
--*************************************************************************************************************

--*************************************************************************************************************
-- TABLE PERMISO
--*************************************************************************************************************

INSERT INTO [TIRANDO_QUERIES].Permiso(perm_nombre)
VALUES ('ABM_ROL'),('ABM_PUERTO'),('ABM_RECORRIDO'),('ABM_CRUCERO'),('GENERAR_VIAJE'),('COMPRAR_PASAJE'),('RESERVA_PASAJE'),('PAGO_RESERVA'),('LISTADO_ESTADISTICO')
GO

--*************************************************************************************************************
-- TABLE ROL + PERMISO_ROL
--*************************************************************************************************************

-- DEFINO EL ROL ADMINISTRATIVO

INSERT INTO [TIRANDO_QUERIES].Rol(rol_nombre)
VALUES ('ADMINISTRATIVO')
GO

-- El rol de administrador tiene todos los permisos asignados
INSERT INTO [TIRANDO_QUERIES].Permiso_Rol(pr_rol_codigo,pr_perm_codigo)
SELECT DISTINCT SCOPE_IDENTITY(), perm_codigo FROM [TIRANDO_QUERIES].Permiso
GO


-- DEFINO EL ROL CLIENTE

INSERT INTO [TIRANDO_QUERIES].Rol(rol_nombre)
VALUES ('CLIENTE')
GO

-- El rol de cliente tiene los siguientes permisos asignados: COMPRAR_PASAJE,RESERVA_PASAJE,PAGO_RESERVA,LISTADO_ESTADISTICO
INSERT INTO [TIRANDO_QUERIES].Permiso_Rol(pr_rol_codigo,pr_perm_codigo)
SELECT DISTINCT SCOPE_IDENTITY(), perm_codigo FROM [TIRANDO_QUERIES].Permiso
WHERE perm_nombre IN ('GESTIONAR_PASAJE','PAGO_RESERVA')
GO

--*************************************************************************************************************
-- TABLE USUARIO + ROL_USUARIO
-- Declaro un usuario y le asigno el rol correspondiente
--*************************************************************************************************************

-- Nuevo usuario administrativo

DECLARE @password [nvarchar](255)
SET @password = 'w23e'

INSERT INTO [TIRANDO_QUERIES].Usuario(usua_username,usua_password)
VALUES ('admin', HASHBYTES('SHA2_256', @password))
GO

DECLARE @codigo_rol_administrativo [NUMERIC]
SET @codigo_rol_administrativo = (SELECT rol_codigo FROM [TIRANDO_QUERIES].Rol WHERE rol_nombre = 'Administrativo')

INSERT INTO [TIRANDO_QUERIES].Rol_Usuario(ru_usua_codigo,ru_rol_codigo)
VALUES (SCOPE_IDENTITY(),@codigo_rol_administrativo)
GO

-- Nuevo usuario administrativo

DECLARE @password [nvarchar](255)
SET @password = 'w23e'

INSERT INTO [TIRANDO_QUERIES].Usuario(usua_username,usua_password)
VALUES ('admin2', HASHBYTES('SHA2_256', @password))
GO

DECLARE @codigo_rol_administrativo [NUMERIC]
SET @codigo_rol_administrativo = (SELECT rol_codigo FROM [TIRANDO_QUERIES].Rol WHERE rol_nombre = 'Administrativo')

INSERT INTO [TIRANDO_QUERIES].Rol_Usuario(ru_usua_codigo,ru_rol_codigo)
VALUES (SCOPE_IDENTITY(),@codigo_rol_administrativo)
GO


--*************************************************************************************************************
-- TABLE CLIENTE
--*************************************************************************************************************

/*
SELECT cli_dni FROM gd_esquema.Maestra m1
GROUP BY cli_dni
HAVING COUNT(DISTINCT cli_nombre) > 1

La consulta devuelve 311 resultados, lo que nos permite afirmar que DNI no identifica a un cliente

SELECT DISTINCT m.cli_nombre,m.cli_apellido,m.cli_dni,m.cli_telefono,m.cli_direccion,m.cli_mail,m.cli_fecha_nac FROM gd_esquema.Maestra m
SELECT DISTINCT m.cli_nombre,m.cli_apellido,m.cli_dni FROM gd_esquema.Maestra m

Devuelven la misma cantidad de resultados, lo que nos permite afirmar que dni + nombre + apellido son clave única

*/

INSERT INTO [TIRANDO_QUERIES].Cliente(clie_nombre,clie_apellido,clie_dni,clie_telefono,clie_direccion,clie_mail,clie_fecha_nac)
SELECT DISTINCT m.cli_nombre,m.cli_apellido,m.cli_dni,m.cli_telefono,m.cli_direccion,m.cli_mail,m.cli_fecha_nac FROM gd_esquema.Maestra m
GO

UPDATE [TIRANDO_QUERIES].Cliente
SET clie_duplicado = 1
WHERE clie_dni IN (SELECT DISTINCT clie_dni FROM [TIRANDO_QUERIES].Cliente GROUP BY clie_dni HAVING COUNT(clie_dni) > 1)
GO

--*************************************************************************************************************
-- TABLE PUERTOS
--*************************************************************************************************************

INSERT INTO [TIRANDO_QUERIES].Puerto(puer_nombre)
SELECT DISTINCT * FROM 
(SELECT DISTINCT puerto_desde FROM gd_esquema.Maestra
WHERE puerto_desde IS NOT NULL
UNION ALL 
SELECT DISTINCT puerto_hasta FROM gd_esquema.Maestra
WHERE puerto_hasta IS NOT NULL) AS Puertos
GO

--*************************************************************************************************************
-- TABLE FABRICANTE
--*************************************************************************************************************

INSERT INTO [TIRANDO_QUERIES].Fabricante(fabr_detalle)
SELECT DISTINCT cru_fabricante FROM gd_esquema.Maestra
WHERE cru_fabricante IS NOT NULL
GO

--*************************************************************************************************************
-- TABLE MODELO_CRUCERO
--*************************************************************************************************************

INSERT INTO [TIRANDO_QUERIES].Modelo_Crucero(mc_detalle)
SELECT DISTINCT crucero_modelo FROM gd_esquema.Maestra
WHERE crucero_modelo IS NOT NULL
GO

--*************************************************************************************************************
-- TABLE CRUCERO
--*************************************************************************************************************

INSERT INTO [TIRANDO_QUERIES].Crucero(cruc_identificador,cruc_fabricante,cruc_modelo)
SELECT DISTINCT m.crucero_identificador,mc.mc_codigo,fb.fabr_codigo FROM gd_esquema.Maestra m
JOIN TIRANDO_QUERIES.Modelo_Crucero mc ON m.crucero_modelo = mc.mc_detalle
JOIN TIRANDO_QUERIES.Fabricante fb ON m.cru_fabricante = fb.fabr_detalle
GO


--*************************************************************************************************************
-- TABLE TIPO_CABINA
--*************************************************************************************************************

INSERT INTO [TIRANDO_QUERIES].Tipo_Cabina(tc_detalle,tc_porc_recargo)
SELECT DISTINCT cabina_tipo,cabina_tipo_porc_recargo FROM gd_esquema.Maestra
WHERE cabina_tipo IS NOT NULL AND cabina_tipo_porc_recargo IS NOT NULL
GO

--*************************************************************************************************************
-- TABLE CABINA
--*************************************************************************************************************

INSERT INTO [TIRANDO_QUERIES].Cabina(cabi_numero,cabi_piso,cabi_cod_tipo,cabi_crucero)
SELECT DISTINCT m.cabina_nro,m.cabina_piso,tc.tc_codigo,cr.cruc_codigo FROM gd_esquema.Maestra m
JOIN TIRANDO_QUERIES.Tipo_Cabina tc ON m.cabina_tipo = tc.tc_detalle
JOIN TIRANDO_QUERIES.Crucero cr ON m.crucero_identificador = cr.cruc_identificador
GO


--*************************************************************************************************************
-- TABLE RECORRIDO
--*************************************************************************************************************
SET IDENTITY_INSERT [TIRANDO_QUERIES].[Recorrido] ON

INSERT INTO [TIRANDO_QUERIES].Recorrido(reco_codigo)
SELECT DISTINCT m.recorrido_codigo FROM gd_esquema.Maestra m
WHERE m.recorrido_codigo IS NOT NULL

SET IDENTITY_INSERT [TIRANDO_QUERIES].[Recorrido] OFF
GO

--*************************************************************************************************************
-- TABLE RECORRIDO - DATOS INCOHERENTES MARCADOS CON EL FLAG
--*************************************************************************************************************

UPDATE [TIRANDO_QUERIES].[Recorrido]
SET reco_invalido = 1
WHERE reco_codigo IN 
(SELECT recorrido_codigo FROM gd_esquema.Maestra m
GROUP BY recorrido_codigo
HAVING COUNT(DISTINCT puerto_desde) > 1)
GO

--*************************************************************************************************************
-- TABLE TRAMO
--*************************************************************************************************************

INSERT INTO [TIRANDO_QUERIES].Tramo(tram_recorrido,tram_puerto_desde,tram_puerto_hasta,tram_precio,tram_orden)
SELECT DISTINCT m.recorrido_codigo,p.puer_codigo,p2.puer_codigo,recorrido_precio_base,
(CASE WHEN (SELECT COUNT(*) FROM gd_esquema.Maestra m2 WHERE m.recorrido_codigo=m2.recorrido_codigo) > 1 THEN 1 ELSE 0 END)
FROM gd_esquema.Maestra m
JOIN [TIRANDO_QUERIES].Puerto p ON m.puerto_desde = p.puer_nombre
JOIN [TIRANDO_QUERIES].Puerto p2 ON m.puerto_hasta = p2.puer_nombre;
GO

--*************************************************************************************************************
-- TABLE RUTA_VIAJE
--*************************************************************************************************************

INSERT INTO [TIRANDO_QUERIES].Ruta_Viaje(rv_recorrido,rv_crucero,rv_fecha_salida,rv_fecha_llegada,rv_fecha_llegada_estimada)
SELECT DISTINCT m.recorrido_codigo,
(SELECT cr.cruc_codigo FROM [TIRANDO_QUERIES].Crucero cr WHERE cr.cruc_identificador = m.crucero_identificador),
m.fecha_salida,m.fecha_llegada,m.fecha_llegada_estimada
FROM gd_esquema.Maestra m
GO

--*************************************************************************************************************
-- TABLE ESTADO_PASAJE
--*************************************************************************************************************

INSERT INTO [TIRANDO_QUERIES].[Estado_Pasaje](ep_estado,ep_motivo)
VALUES ('Vigente','Pasaje vigente'),('Desconocido','Sin informacion'),('Cancelado','Desperfecto tecnico en crucero'),('Cancelado','Crucero completo VU'),('Cancelado','Baja de recorrido')
GO

-- Para los datos migrados tomamos Desconocido como DEFAULT

--*************************************************************************************************************
-- TABLE PAGO
--*************************************************************************************************************

INSERT INTO [TIRANDO_QUERIES].[Pago](pago_medio_pago,pago_cuotas)
VALUES ('Efectivo',0),('TD Santander',0),('TC Santander',3),('TC Ciudad',6),('Desconocido',NULL)
GO

--*************************************************************************************************************
-- TABLE PASAJE
--*************************************************************************************************************

SET IDENTITY_INSERT [TIRANDO_QUERIES].[Pasaje] ON

--Creo un índice para performar la migraicón de la tabla pasaje
CREATE INDEX index_clientes ON TIRANDO_QUERIES.Cliente(clie_dni,clie_nombre,clie_apellido)

DECLARE @cod_estado_desconocido NUMERIC
DECLARE @cod_pago_desconocido NUMERIC
SET @cod_estado_desconocido = (SELECT  ep.ep_codigo FROM [TIRANDO_QUERIES].Estado_Pasaje ep WHERE ep.ep_estado = 'Desconocido')
SET @cod_pago_desconocido = (SELECT  p.pago_codigo FROM [TIRANDO_QUERIES].Pago p WHERE p.pago_medio_pago = 'Desconocido')

INSERT INTO [TIRANDO_QUERIES].[Pasaje](pasa_codigo,pasa_precio,pasa_cabina,pasa_cliente,pasa_estado,pasa_pago,pasa_ruta,pasa_fecha_pago)
SELECT DISTINCT m.pasaje_codigo,m.recorrido_precio_base,

(SELECT c.cabi_codigo FROM [TIRANDO_QUERIES].Cabina c
 JOIN [TIRANDO_QUERIES].Tipo_Cabina tc ON c.cabi_cod_tipo = tc.tc_codigo
 JOIN [TIRANDO_QUERIES].Crucero cr ON cr.cruc_codigo = c.cabi_crucero
 WHERE c.cabi_piso = m.cabina_piso AND c.cabi_numero = m.cabina_nro AND m.cabina_tipo = tc.tc_detalle AND cr.cruc_identificador = m.crucero_identificador),
 
(SELECT c.clie_codigo FROM [TIRANDO_QUERIES].Cliente c
 WHERE c.clie_dni = m.cli_dni AND c.clie_nombre = m.cli_nombre AND c.clie_apellido = m.cli_apellido),
 
@cod_estado_desconocido,
@cod_pago_desconocido,

--Aca hacemos un TOP 1 dado que la información en tramos puede devolver mas de un registro con el mismo cod_recorrido

(SELECT TOP 1 rv.rv_codigo FROM [TIRANDO_QUERIES].Ruta_Viaje rv
 JOIN [TIRANDO_QUERIES].Recorrido r ON rv.rv_recorrido = r.reco_codigo
 JOIN [TIRANDO_QUERIES].Tramo t ON r.reco_codigo = t.tram_recorrido
 JOIN [TIRANDO_QUERIES].Puerto p ON t.tram_puerto_desde = p.puer_codigo
 JOIN [TIRANDO_QUERIES].Puerto p2 ON t.tram_puerto_hasta = p2.puer_codigo
 WHERE p.puer_nombre = m.puerto_desde AND p2.puer_nombre = m.puerto_hasta AND m.recorrido_codigo = r.reco_codigo),

m.pasaje_fecha_compra 
 
FROM gd_esquema.Maestra m
WHERE m.reserva_codigo IS NULL AND m.reserva_fecha IS NULL

SET IDENTITY_INSERT [TIRANDO_QUERIES].[Pasaje] OFF

GO


--*************************************************************************************************************
-- TABLE ESTADO_RESERVA
--*************************************************************************************************************

INSERT INTO [TIRANDO_QUERIES].[Estado_Reserva](er_estado,er_motivo)
VALUES ('Vigente','Reserva vigente'),('Vencida','Supero la cantidad de dias'),('Pagado','Se realizo el pago'),('Cancelado','Cliente desiste'),('Desconocido','Sin informacion')
GO

-- Para los datos migrados tomamos Desconocido como DEFAULT

--*************************************************************************************************************
-- TABLE RESERVA
--*************************************************************************************************************

SET IDENTITY_INSERT [TIRANDO_QUERIES].[Reserva] ON

DECLARE @cod_estado_desconocido NUMERIC
SET @cod_estado_desconocido = (SELECT  er.er_codigo FROM [TIRANDO_QUERIES].Estado_Reserva er WHERE er.er_estado = 'Desconocido')

INSERT INTO [TIRANDO_QUERIES].[Reserva](rese_codigo,rese_precio,rese_cabina,rese_cliente,rese_estado,rese_ruta,rese_fecha)
SELECT DISTINCT m.reserva_codigo,m.recorrido_precio_base,

(SELECT c.cabi_codigo FROM [TIRANDO_QUERIES].Cabina c
 JOIN [TIRANDO_QUERIES].Tipo_Cabina tc ON c.cabi_cod_tipo = tc.tc_codigo
 JOIN [TIRANDO_QUERIES].Crucero cr ON cr.cruc_codigo = c.cabi_crucero
 WHERE c.cabi_piso = m.cabina_piso AND c.cabi_numero = m.cabina_nro AND m.cabina_tipo = tc.tc_detalle AND cr.cruc_identificador = m.crucero_identificador),
 
(SELECT c.clie_codigo FROM [TIRANDO_QUERIES].Cliente c
 WHERE c.clie_dni = m.cli_dni AND c.clie_nombre = m.cli_nombre AND c.clie_apellido = m.cli_apellido),
 
@cod_estado_desconocido,

--Aca hacemos un TOP 1 dado que la información en tramos puede devolver mas de un registro con el mismo cod_recorrido

(SELECT TOP 1 rv.rv_codigo FROM [TIRANDO_QUERIES].Ruta_Viaje rv
 JOIN [TIRANDO_QUERIES].Recorrido r ON rv.rv_recorrido = r.reco_codigo
 JOIN [TIRANDO_QUERIES].Tramo t ON r.reco_codigo = t.tram_recorrido
 JOIN [TIRANDO_QUERIES].Puerto p ON t.tram_puerto_desde = p.puer_codigo
 JOIN [TIRANDO_QUERIES].Puerto p2 ON t.tram_puerto_hasta = p2.puer_codigo
 WHERE p.puer_nombre = m.puerto_desde AND p2.puer_nombre = m.puerto_hasta AND m.recorrido_codigo = r.reco_codigo),

m.reserva_fecha
 
FROM gd_esquema.Maestra m
WHERE m.reserva_codigo IS NOT NULL AND m.reserva_fecha IS NOT NULL

SET IDENTITY_INSERT [TIRANDO_QUERIES].[Reserva] OFF

GO

--*************************************************************************************************************
--*************************************************************************************************************
-- FIN DE MIGRACION DE DATOS
--*************************************************************************************************************
--*************************************************************************************************************



--*************************************************************************************************************
--*************************************************************************************************************
--CREACIÓN DE FUNCTIONS
--*************************************************************************************************************
--*************************************************************************************************************

--Función que sirve para saber sí un usuario existe
CREATE FUNCTION [TIRANDO_QUERIES].fn_existe_usuario(@username nvarchar(255))
RETURNS bit
AS
 BEGIN
	IF ((SELECT COUNT(*) FROM TIRANDO_QUERIES.Usuario WHERE usua_username = @username) = 1)
		RETURN 1
	RETURN 0
 END	
GO

--*************************************************************************************************************
--*************************************************************************************************************
--CREACIÓN DE STORED PROCEDURES
--*************************************************************************************************************
--*************************************************************************************************************


--*************************************************************************************************************
-- CREACION DE SP_ESTA_BLOQUEADO_USUARIO
-- SP que devuelve 1 si esta bloqueado el usuario, 0 si no lo esta o sí pasaron 10 minutos luego de su último 
-- login fallido y actualiza su contador
--*************************************************************************************************************

CREATE PROCEDURE [TIRANDO_QUERIES].[sp_esta_bloqueado_usuario](@username nvarchar(255), @codigo INT OUTPUT)
AS
 BEGIN
	IF ((SELECT usua_login_fallidos FROM TIRANDO_QUERIES.Usuario WHERE usua_username = @username) >= 3)
		IF((SELECT usua_fecha_inhabilitacion FROM TIRANDO_QUERIES.Usuario WHERE usua_username = @username) < DATEADD(minute, -10, GETDATE()))
		BEGIN
			UPDATE TIRANDO_QUERIES.Usuario SET usua_login_fallidos = 0 WHERE usua_username = @username
			SET @codigo = 0
			RETURN @codigo
		END
		ELSE
		BEGIN
			SET @codigo = 1
			RETURN @codigo
		END
	SET @codigo = 0
	RETURN @codigo
 END	
GO

--*************************************************************************************************************
-- CREACION DE SP_AUTENTICAR_USUARIO
-- SP que autentica usuario y devuelve distintos códigos dependiendo de sí fue exitoso o en que fallo
--*************************************************************************************************************

CREATE PROCEDURE [TIRANDO_QUERIES].sp_autenticar_usuario(@username nvarchar(255) , @password nvarchar(255))
AS
 BEGIN
	
	--Valido sí el usuario existe y si no está bloqueado
	IF ((SELECT TIRANDO_QUERIES.fn_existe_usuario(@username)) = 0)
		RETURN -2 --Usuario inexistente

	DECLARE @codigo_de_bloqueo INT;
	EXEC TIRANDO_QUERIES.sp_esta_bloqueado_usuario @username, @codigo_de_bloqueo OUTPUT
	IF (@codigo_de_bloqueo = 1)
		RETURN -3 --Usuario bloqueado
 	
	--Convierto la pass en hashed para poder autenticar
	DECLARE @hashedPassword nvarchar(255)
	DECLARE @usua_codigo numeric(18,0)

	SET @hashedPassword = HASHBYTES('SHA2_256', @password)
	SET @usua_codigo = (SELECT usua_codigo FROM TIRANDO_QUERIES.Usuario WHERE usua_username = @username AND usua_password = @hashedPassword)

	IF (@usua_codigo IS NOT NULL)
		BEGIN 
			UPDATE TIRANDO_QUERIES.Usuario SET usua_login_fallidos = 0 WHERE usua_username = @username
			RETURN 1 --Usuario ok
		END
	ELSE 	
		BEGIN 
			UPDATE TIRANDO_QUERIES.Usuario SET usua_login_fallidos = usua_login_fallidos + 1 WHERE usua_username = @username
			IF ((SELECT usua_login_fallidos FROM TIRANDO_QUERIES.Usuario WHERE usua_username = @username) >= 3)
			BEGIN
				UPDATE TIRANDO_QUERIES.Usuario SET usua_fecha_inhabilitacion = GETDATE() WHERE usua_username = @username
			END
			RETURN -1 --Usuario o contraseña incorrectos
		END
END
GO

--*************************************************************************************************************
-- CREACIÓN DE SP_POSTERGAR_VIAJES
-- Desplazo una cantidad N de dias los pasajes
-- Uso: reprogramacion cuando un crucero en mantenimiento
--*************************************************************************************************************

CREATE PROCEDURE [TIRANDO_QUERIES].sp_postergar_viajes(@crucero NUMERIC, @dias NUMERIC)
AS
BEGIN
	UPDATE [TIRANDO_QUERIES].[Ruta_Viaje]
	SET [rv_fecha_salida] = DATEADD(dd,@dias,[rv_fecha_salida]), [rv_fecha_llegada_estimada] = DATEADD(dd,@dias,[rv_fecha_llegada_estimada])
	WHERE rv_crucero=@crucero
	AND rv_fecha_llegada IS NULL;
END
GO

--*************************************************************************************************************
-- CREACIÓN DE SP_PAGO_RESERVA
-- Pago de una reserva
--*************************************************************************************************************

CREATE PROCEDURE [TIRANDO_QUERIES].sp_pago_reserva(@reserva_id NUMERIC, @metodo_pago NUMERIC)
AS
BEGIN
	
	INSERT INTO [TIRANDO_QUERIES].Pasaje (pasa_precio,pasa_cabina,pasa_cliente,pasa_estado,pasa_pago,pasa_ruta,pasa_fecha_pago)
	SELECT rese_precio,rese_cabina,rese_cliente,1,@metodo_pago,rese_ruta,GETDATE()
	FROM [TIRANDO_QUERIES].Reserva WHERE rese_codigo = @reserva_id
	
	DECLARE @pasaje_id NUMERIC;
	SET @pasaje_id = SCOPE_IDENTITY()

	UPDATE [TIRANDO_QUERIES].Reserva
	SET rese_estado = (SELECT er_codigo FROM [TIRANDO_QUERIES].Estado_Reserva WHERE er_estado = 'Pagado')
	WHERE rese_codigo = @reserva_id

	RETURN @pasaje_id

END
GO

--*************************************************************************************************************
-- CREACIÓN DE SP_VENCER_RESERVAS
-- Cuando una reserva se vence
--*************************************************************************************************************

CREATE PROCEDURE [TIRANDO_QUERIES].sp_vencer_reservas
AS
BEGIN
	UPDATE [TIRANDO_QUERIES].Reserva
	SET rese_estado = (SELECT er_codigo FROM Estado_Reserva WHERE er_estado = 'Vencida')
	WHERE rese_estado <> (SELECT er_codigo FROM Estado_Reserva WHERE er_estado = 'Vencida') AND rese_estado <> (SELECT er_codigo FROM Estado_Reserva WHERE er_estado = 'Desconocido')
	AND rese_fecha <= GETDATE() - 4
END
GO

--*************************************************************************************************************
-- CREACIÓN DE SP_ACTUALIZAR_CLIENTE
-- Actualizamos un cliente cuando se compra un pasaje
--*************************************************************************************************************

CREATE PROCEDURE [TIRANDO_QUERIES].sp_actualizar_cliente(@cli_nombre nvarchar(255), @cli_apellido nvarchar(255), @cli_dni numeric(18,0), @cli_telefono int, @cli_direccion nvarchar(255), @cli_mail nvarchar(255), @cli_fecha_nac datetime2(3))
AS
    if exists(Select TOP 1 [clie_dni] From [TIRANDO_QUERIES].[Cliente] WHERE clie_dni = @cli_dni AND clie_duplicado=0)
		BEGIN
			UPDATE [TIRANDO_QUERIES].[Cliente] 
			SET
				[clie_nombre] = @cli_nombre,
				[clie_apellido] = @cli_apellido, 
				[clie_dni] = @cli_dni, 
				[clie_telefono] = @cli_telefono, 
				[clie_direccion] = @cli_direccion, 
				[clie_mail] = @cli_mail, 
				[clie_fecha_nac] = @cli_fecha_nac
			WHERE clie_dni = @cli_dni AND clie_duplicado=0
		END
	ELSE
		BEGIN
			INSERT INTO [TIRANDO_QUERIES].[Cliente] ([clie_nombre], [clie_apellido], [clie_dni], [clie_telefono], [clie_direccion], [clie_mail], [clie_fecha_nac])
			VALUES (@cli_nombre, @cli_apellido, @cli_dni, @cli_telefono, @cli_direccion, @cli_mail, @cli_fecha_nac);
		END
GO

--*************************************************************************************************************
-- CREACIÓN DE SP_ENCONTRAR_CRUCEROS_REEMPLAZO
-- Devuelve todos los cruceros que son válidos para reemplazar a otro.
--*************************************************************************************************************
CREATE PROCEDURE [TIRANDO_QUERIES].sp_encontrar_cruceros_reemplazo(@crucero_a_reemplazar int)
AS
BEGIN
	SELECT * FROM [TIRANDO_QUERIES].[Crucero] C
	WHERE 
		C.cruc_codigo NOT IN (
			SELECT V2.rv_crucero
			FROM [TIRANDO_QUERIES].[Ruta_Viaje] V1, [TIRANDO_QUERIES].[Ruta_Viaje] V2
			WHERE
				V1.rv_crucero = 1 AND
				V1.rv_fecha_llegada IS NULL AND
				V2.rv_fecha_llegada IS NULL AND
				(V1.[rv_fecha_salida] BETWEEN V2.[rv_fecha_salida] AND V2.[rv_fecha_llegada_estimada] OR
				V1.[rv_fecha_llegada_estimada] BETWEEN V2.[rv_fecha_salida] AND V2.[rv_fecha_llegada_estimada])
		) AND
		C.cruc_activo = 1 AND
		(SELECT Count(*) Total FROM [TIRANDO_QUERIES].[Cabina] WHERE [cabi_crucero]=C.cruc_codigo) 
			>= (SELECT TOP 1 COUNT([pasa_ruta]) AS max_pasajes
			FROM [TIRANDO_QUERIES].[Pasaje] 
			WHERE [pasa_ruta] IN (SELECT rv_codigo FROM [TIRANDO_QUERIES].[Ruta_Viaje] WHERE [rv_crucero] = 1 AND rv_fecha_llegada IS NULL)
			GROUP BY [pasa_ruta]
			ORDER BY max_pasajes DESC)
	ORDER BY C.cruc_codigo;
END
GO

--*************************************************************************************************************
--*************************************************************************************************************
-- CREACION TRIGGERS
--*************************************************************************************************************
--*************************************************************************************************************


--*************************************************************************************************************
-- CREACION TRG_BAJA_RECORRIDO_POR_BAJA_PUERTO
-- Cuando ponemos un puerto como inactivo, se deben poner los recorridos que tienen tramos con dichos puertos
-- también como inactivos
--*************************************************************************************************************

CREATE TRIGGER [TIRANDO_QUERIES].[trg_baja_recorrido_por_baja_puerto] ON [TIRANDO_QUERIES].[Puerto] AFTER UPDATE
AS
BEGIN

	DECLARE cursor_puerto CURSOR FOR
	SELECT i.puer_codigo FROM inserted i
	JOIN deleted d ON i.puer_codigo = d.puer_codigo
	WHERE i.puer_activo = 0 AND d.puer_activo = 1
	--Hago el JOIN para ver que cambio el estado y solo asi pegarle a la base solo cuando es necesario
	
	OPEN cursor_puerto
	DECLARE @puerto_id NUMERIC
	
	FETCH cursor_puerto INTO @puerto_id

	WHILE @@FETCH_STATUS = 0
	BEGIN
		UPDATE [TIRANDO_QUERIES].Recorrido SET reco_activo = 0 WHERE reco_codigo IN 
		(SELECT DISTINCT tram_recorrido FROM [TIRANDO_QUERIES].Tramo WHERE @puerto_id = tram_puerto_desde OR @puerto_id = tram_puerto_hasta)
		FETCH cursor_puerto INTO @puerto_id
	END

CLOSE cursor_puerto
DEALLOCATE cursor_puerto
END
GO


--*************************************************************************************************************
-- CREACION TRG_CANCELAR_PASAJES_VIGENTES_POR_BAJA_RECORRIDO
-- Cuando ponemos un recorrido como inactivo, cancelar pasajes que no hayan iniciado
--*************************************************************************************************************


CREATE TRIGGER [TIRANDO_QUERIES].[trg_cancelar_pasajes_vigentes_por_baja_recorrido] ON [TIRANDO_QUERIES].[Recorrido] AFTER UPDATE
AS
BEGIN
	DECLARE cursor_recorrido CURSOR FOR
	SELECT i.reco_codigo FROM inserted i
	JOIN deleted d ON i.reco_codigo = d.reco_codigo
	WHERE i.reco_activo = 0 AND d.reco_activo = 1
	--Hago el JOIN para ver que cambio el estado y solo asi pegarle a la base solo cuando es necesario
	
	OPEN cursor_recorrido
	DECLARE @recorrido_id NUMERIC
	
	FETCH cursor_recorrido INTO @recorrido_id

	WHILE @@FETCH_STATUS = 0
	BEGIN
		UPDATE [TIRANDO_QUERIES].Pasaje SET pasa_estado = (SELECT ep_codigo FROM [TIRANDO_QUERIES].Estado_Pasaje WHERE ep_motivo = 'Baja de recorrido')
		WHERE pasa_ruta IN 
		(SELECT rv_codigo FROM [TIRANDO_QUERIES].Ruta_Viaje 
		WHERE rv_recorrido = @recorrido_id AND rv_fecha_llegada IS NULL AND rv_fecha_salida > GETDATE())
		
		FETCH cursor_recorrido INTO @recorrido_id
	END

CLOSE cursor_recorrido
DEALLOCATE cursor_recorrido
END
GO


--*************************************************************************************************************
-- CREACION TRG_QUITAR_ROL_DE_USUARIO_POR_BAJA_LOGICA
-- Cuando hacemos una baja lógica de un rol, elimino de la tabla Rol_Usuario todas las asignaciones existentes
--*************************************************************************************************************

CREATE TRIGGER [TIRANDO_QUERIES].[trg_quitar_rol_de_usuario_por_baja_logica] ON [TIRANDO_QUERIES].[Rol] AFTER UPDATE
AS
BEGIN
	DECLARE cursor_rol CURSOR FOR
	SELECT i.rol_codigo FROM inserted i
	JOIN deleted d ON i.rol_codigo = d.rol_codigo
	WHERE i.rol_activo = 0 AND d.rol_activo = 1
	--Hago el JOIN para ver que cambio el estado y solo asi pegarle a la base solo cuando es necesario
	
	OPEN cursor_rol
	DECLARE @rol_id NUMERIC
	
	FETCH cursor_rol INTO @rol_id

	WHILE @@FETCH_STATUS = 0
	BEGIN
		DELETE FROM [TIRANDO_QUERIES].Rol_Usuario
		WHERE ru_rol_codigo = @rol_id
		
		FETCH cursor_rol INTO @rol_id
	END

CLOSE cursor_rol
DEALLOCATE cursor_rol
END
GO


--*************************************************************************************************************
--*************************************************************************************************************
-- DATOS DUMMY PARA TEST
--*************************************************************************************************************
--*************************************************************************************************************

INSERT INTO [TIRANDO_QUERIES].[Ruta_Viaje](rv_recorrido, rv_crucero, [rv_fecha_salida], [rv_fecha_llegada_estimada])
VALUES(43820882, 23, '2019-07-25 09:00:00.000', '2019-08-25 09:00:00.000');
GO
INSERT INTO [TIRANDO_QUERIES].[Pasaje]([pasa_precio], [pasa_cabina], [pasa_cliente], [pasa_estado], [pasa_pago], [pasa_ruta])
VALUES(400, 4, 155985, 4, 5, 4957);
GO
INSERT [TIRANDO_QUERIES].[Ruta_Viaje]
([rv_recorrido], [rv_crucero], [rv_fecha_salida], [rv_fecha_llegada_estimada])
VALUES (43820882, 23, '2019-04-25 03:00:00.000', '2019-04-25 10:00:00.000')
GO
INSERT [TIRANDO_QUERIES].[Ruta_Viaje]
([rv_recorrido], [rv_crucero], [rv_fecha_salida], [rv_fecha_llegada_estimada])
VALUES (43820882, 1, '2019-02-25 03:00:00.000', '2019-02-25 10:00:00.000')
GO
INSERT [TIRANDO_QUERIES].[Ruta_Viaje]
([rv_recorrido], [rv_crucero], [rv_fecha_salida], [rv_fecha_llegada_estimada])
VALUES (43820882, 1, '2019-07-25 03:00:00.000', '2019-07-25 10:00:00.000')
GO
INSERT [TIRANDO_QUERIES].[Ruta_Viaje]
([rv_recorrido], [rv_crucero], [rv_fecha_salida], [rv_fecha_llegada_estimada])
VALUES (43820882, 2, '2019-08-25 8:00:00.000', '2019-09-26 10:00:00.000')
GO
INSERT [TIRANDO_QUERIES].[Ruta_Viaje]
([rv_recorrido], [rv_crucero], [rv_fecha_salida], [rv_fecha_llegada_estimada])
VALUES (43820882, 3, '2019-07-24 03:00:00.000', '2019-07-24 10:00:00.000')
GO
