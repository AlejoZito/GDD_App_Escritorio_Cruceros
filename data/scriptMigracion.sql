USE [GD1C2019]
GO

--*************************************************************************************************************
-- CREATE SCHEMA
-- Creamos el nuevo schema donde se almacenaran las distintas tablas
--*************************************************************************************************************

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'NUEVO_SCHEMA')
BEGIN
	EXEC ('CREATE SCHEMA [NUEVO_SCHEMA] AUTHORIZATION gd')
END
GO

--*************************************************************************************************************
--*************************************************************************************************************
-- DROPEO DE OBJETOS
--*************************************************************************************************************
--*************************************************************************************************************

--*************************************************************************************************************
-- DROP TABLES
-- Realizo un DROP de las tablas previo a su creación en caso existan
--*************************************************************************************************************

IF OBJECT_ID('[NUEVO_SCHEMA].[Cliente]','U') IS NOT NULL DROP TABLE [NUEVO_SCHEMA].[Cliente];
IF OBJECT_ID('[NUEVO_SCHEMA].[Pasaje]','U') IS NOT NULL DROP TABLE [NUEVO_SCHEMA].[Pasaje];
IF OBJECT_ID('[NUEVO_SCHEMA].[Pago]','U') IS NOT NULL DROP TABLE [NUEVO_SCHEMA].[Pago];
IF OBJECT_ID('[NUEVO_SCHEMA].[Medio_Pago]','U') IS NOT NULL DROP TABLE [NUEVO_SCHEMA].[Medio_Pago];
IF OBJECT_ID('[NUEVO_SCHEMA].[Estado_Pasaje]','U') IS NOT NULL DROP TABLE [NUEVO_SCHEMA].[Estado_Pasaje];
IF OBJECT_ID('[NUEVO_SCHEMA].[Ruta_Viaje]','U') IS NOT NULL DROP TABLE [NUEVO_SCHEMA].[Ruta_Viaje];
IF OBJECT_ID('[NUEVO_SCHEMA].[Recorrido]','U') IS NOT NULL DROP TABLE [NUEVO_SCHEMA].[Recorrido];
IF OBJECT_ID('[NUEVO_SCHEMA].[Tramo]','U') IS NOT NULL DROP TABLE [NUEVO_SCHEMA].[Tramo];
IF OBJECT_ID('[NUEVO_SCHEMA].[Puerto]','U') IS NOT NULL DROP TABLE [NUEVO_SCHEMA].[Puerto];
IF OBJECT_ID('[NUEVO_SCHEMA].[Crucero]','U') IS NOT NULL DROP TABLE [NUEVO_SCHEMA].[Crucero];
IF OBJECT_ID('[NUEVO_SCHEMA].[Modelo_Crucero]','U') IS NOT NULL DROP TABLE [NUEVO_SCHEMA].[Modelo_Crucero];
IF OBJECT_ID('[NUEVO_SCHEMA].[Mantenimiento]','U') IS NOT NULL DROP TABLE [NUEVO_SCHEMA].[Mantenimiento];
IF OBJECT_ID('[NUEVO_SCHEMA].[Fabricante]','U') IS NOT NULL DROP TABLE [NUEVO_SCHEMA].[Fabricante];
IF OBJECT_ID('[NUEVO_SCHEMA].[Cabina]','U') IS NOT NULL DROP TABLE [NUEVO_SCHEMA].[Cabina];
IF OBJECT_ID('[NUEVO_SCHEMA].[Tipo_Cabina]','U') IS NOT NULL DROP TABLE [NUEVO_SCHEMA].[Tipo_Cabina];
IF OBJECT_ID('[NUEVO_SCHEMA].[Reserva]','U') IS NOT NULL DROP TABLE [NUEVO_SCHEMA].[Reserva];
IF OBJECT_ID('[NUEVO_SCHEMA].[Estado_Reserva]','U') IS NOT NULL DROP TABLE [NUEVO_SCHEMA].[Estado_Reserva];
IF OBJECT_ID('[NUEVO_SCHEMA].[Usuario]','U') IS NOT NULL DROP TABLE [NUEVO_SCHEMA].[Usuario];
IF OBJECT_ID('[NUEVO_SCHEMA].[Rol_Usuario]','U') IS NOT NULL DROP TABLE [NUEVO_SCHEMA].[Rol_Usuario];
IF OBJECT_ID('[NUEVO_SCHEMA].[Rol]','U') IS NOT NULL DROP TABLE [NUEVO_SCHEMA].[Rol];
IF OBJECT_ID('[NUEVO_SCHEMA].[Permiso_Rol]','U') IS NOT NULL DROP TABLE [NUEVO_SCHEMA].[Permiso_Rol];
IF OBJECT_ID('[NUEVO_SCHEMA].[Permiso]','U') IS NOT NULL DROP TABLE [NUEVO_SCHEMA].[Permiso];

--*************************************************************************************************************
-- DROP STORED PROCEDURES
-- Realizo un DROP de los SP previo a su creación en caso existan
--*************************************************************************************************************

//TODO

--*************************************************************************************************************
-- DROP FUNCTIONS
-- Realizo un DROP de las funciones previo a su creación en caso existan
--*************************************************************************************************************

//TODO

--*************************************************************************************************************
-- DROP TRIGGERS
-- Realizo un DROP de los triggers previo a su creación en caso existan
--*************************************************************************************************************

//TODO
//Cuando inhabilitas un rol (baja lógica), se lo tenés que quitar al usuario que lo tenga (delete rol_permiso)



--*************************************************************************************************************
--*************************************************************************************************************
-- CREACION DE TABLAS
--*************************************************************************************************************
--*************************************************************************************************************


--*************************************************************************************************************
-- TABLE CLIENTE
--*************************************************************************************************************

CREATE TABLE [NUEVO_SCHEMA].[Cliente] (
	[clie_codigo] [NUMERIC] IDENTITY(1,1) PRIMARY KEY,
	[clie_nombre] [NVARCHAR](255) NOT NULL,
	[clie_apellido] [NVARCHAR](255) NOT NULL,
	[clie_dni] [DECIMAL](18,0) NOT NULL,
	[clie_telefono] [INT] NOT NULL,
	[clie_direccion] [NVARCHAR](255) NOT NULL,
	[clie_mail] [NVARCHAR](255) NOT NULL,
	[clie_fecha_nac] DATETIME2(3) NOT NULL
)

--*************************************************************************************************************
-- TABLE FABRICANTE
--*************************************************************************************************************

CREATE TABLE [NUEVO_SCHEMA].[Fabricante] (
	[fabr_codigo] [NUMERIC] IDENTITY(1,1) PRIMARY KEY,
	[fabr_detalle] [NVARCHAR](255) NOT NULL
)

--*************************************************************************************************************
-- TABLE MODELO_CRUCERO
--*************************************************************************************************************

CREATE TABLE [NUEVO_SCHEMA].[Modelo] (
	[mode_codigo] [NUMERIC] IDENTITY(1,1) PRIMARY KEY,
	[mode_nombre] [NVARCHAR](50) NOT NULL
)

--*************************************************************************************************************
-- TABLE CRUCERO
--*************************************************************************************************************

CREATE TABLE [NUEVO_SCHEMA].[Crucero] (
	[cruc_codigo] [NUMERIC] IDENTITY(1,1) IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[cruc_identificador] NOT NULL,
	[cruc_fabricante] [NUMERIC] NOT NULL,
	[cruc_modelo] [NUMERIC] NOT NULL,
	[cruc_activo] BIT,
	FOREIGN KEY (cruc_fabricante) REFERENCES Fabricante(fabr_codigo),
	FOREIGN KEY (cruc_modelo) REFERENCES Modelo(mode_codigo)
)

--*************************************************************************************************************
-- TABLE MANTENIMIENTO
--*************************************************************************************************************

CREATE TABLE [NUEVO_SCHEMA].[Mantenimiento] (
	[mant_codigo] [NUMERIC] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[mant_crucero] [NUMERIC] NOT NULL,
	[mant_fecha_desde] DATETIME2(3),
	[mant_fecha_hasta] DATETIME2(3),
	FOREIGN KEY (mant_crucero) REFERENCES Crucero(cruc_codigo)
)

--*************************************************************************************************************
-- TABLE TIPO_CABINA
--*************************************************************************************************************

CREATE TABLE [NUEVO_SCHEMA].[Tipo_Cabina] (
	[tc_codigo] [NUMERIC] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[tc_detalle] [NVARCHAR](255) NOT NULL,
	[tc_porc_recargo] [DECIMAL](18,2) NOT NULL
)

--*************************************************************************************************************
-- TABLE CABINA
--*************************************************************************************************************

CREATE TABLE [NUEVO_SCHEMA].[Cabina] (
	[cabi_codigo] [NUMERIC] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[cabi_numero] [DECIMAL](18,0) NOT NULL,
	[cabi_piso] [DECIMAL](18,0) NOT NULL,
	[cabi_crucero] [NUMERIC] NOT NULL,
	FOREIGN KEY (cabi_crucero) REFERENCES Crucero(cruc_codigo)
)

--*************************************************************************************************************
-- TABLE ESTADO_RESERVA
--*************************************************************************************************************

CREATE TABLE [NUEVO_SCHEMA].[Estado_Reserva] (
	[er_codigo] [NUMERIC] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[er_detalle] [NVARCHAR](255) NOT NULL
)

--*************************************************************************************************************
-- TABLE PUERTO
--*************************************************************************************************************

CREATE TABLE [NUEVO_SCHEMA].[Puerto] (
	[puer_codigo] [NUMERIC] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[puer_nombre] [NVARCHAR](255) NOT NULL,
	[puer_activo] BIT
)

--*************************************************************************************************************
-- TABLE RECORRIDO
--*************************************************************************************************************

CREATE TABLE [NUEVO_SCHEMA].[Recorrido] (
	[reco_codigo] [NUMERIC] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[reco_activo] BIT
)

--*************************************************************************************************************
-- TABLE TRAMO
--*************************************************************************************************************

CREATE TABLE [NUEVO_SCHEMA].[Tramo] (
	[tram_recorrido] [NUMERIC] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[tram_puerto_desde] [NUMERIC] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[tram_puerto_hasta] [NUMERIC] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[tram_precio] [NUMERIC] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[tram_codigo] [INT],
	FOREIGN KEY (tram_recorrido) REFERENCES Recorrido(reco_codigo),
	FOREIGN KEY (tram_puerto_desde) REFERENCES Puerto(puer_codigo),
	FOREIGN KEY (tram_puerto_hasta) REFERENCES Puerto(puer_codigo)
)

--*************************************************************************************************************
-- TABLE RUTA_VIAJE
--*************************************************************************************************************

CREATE TABLE [NUEVO_SCHEMA].[Ruta_Viaje] (
	[rv_codigo] [NUMERIC] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[rv_recorrido] [NUMERIC] NOT NULL,
	[rv_crucero] [NUMERIC] NOT NULL,
	[rv_fecha_inicio] DATETIME2(3),
	[rv_fecha_fin] DATETIME2(3),
	[rv_fecha_fin_estimada] DATETIME2(3),
	FOREIGN KEY (rv_recorrido) REFERENCES Recorrido(reco_codigo),
	FOREIGN KEY (rv_crucero) REFERENCES Crucero(cruc_codigo)
)

--*************************************************************************************************************
-- TABLE ESTADO_PASAJE
--*************************************************************************************************************

CREATE TABLE [NUEVO_SCHEMA].[Estado_Pasaje] (
	[ep_codigo] [NUMERIC] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[ep_detalle] [NVARCHAR](255) NOT NULL
)

--*************************************************************************************************************
-- TABLE MEDIO_PAGO
--*************************************************************************************************************

CREATE TABLE [NUEVO_SCHEMA].[Medio_Pago] (
	[mp_codigo] [NUMERIC] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[mp_detalle] [NVARCHAR](255) NOT NULL,
	[mp_cuotas_permitidas] [INT],
)

--*************************************************************************************************************
-- TABLE PAGO
--*************************************************************************************************************

CREATE TABLE [NUEVO_SCHEMA].[Pago] (
	[pago_codigo] [NUMERIC] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[pago_fecha_compra] DATETIME2(3),
	[pago_medio_pago] [NUMERIC] NOT NULL,
	[pago_cuotas] [INT],
	FOREIGN KEY (pago_medio_pago) REFERENCES Medio_Pago(mp_codigo),
)

--*************************************************************************************************************
-- TABLE PASAJE
--*************************************************************************************************************

CREATE TABLE [NUEVO_SCHEMA].[Pasaje] (
	[pasa_codigo] [NUMERIC] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[pasa_precio]  [DECIMAL](18,2) NOT NULL,
	[pasa_cabina] [NUMERIC] NOT NULL,
	[pasa_cliente] [NUMERIC] NOT NULL,
	[pasa_estado] [NUMERIC] NOT NULL,
	[pasa_pago] [NUMERIC] NOT NULL,
	[pasa_ruta] [NUMERIC] NOT NULL,
	FOREIGN KEY (pasa_cabina) REFERENCES Cabina(cabi_codigo),
	FOREIGN KEY (pasa_cliente) REFERENCES Cliente(clie_codigo),
	FOREIGN KEY (pasa_estado) REFERENCES Estado(ep_codigo),
	FOREIGN KEY (pasa_pago) REFERENCES Pago(pago_codigo),
	FOREIGN KEY (pasa_ruta) REFERENCES Ruta_Viaje(rv_codigo)
)

--*************************************************************************************************************
-- TABLE RESERVA
--*************************************************************************************************************

CREATE TABLE [NUEVO_SCHEMA].[Reserva] (
	[rese_codigo] [NUMERIC] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[rese_precio]  [DECIMAL](18,2) NOT NULL,
	[rese_fecha] DATETIME2(3),
	[rese_cabina] [NUMERIC] NOT NULL,
	[rese_cliente] [NUMERIC] NOT NULL,
	[rese_estado] [NUMERIC] NOT NULL,
	[rese_ruta] [NUMERIC] NOT NULL,
	FOREIGN KEY (rese_cabina) REFERENCES Cabina(cabi_codigo),
	FOREIGN KEY (rese_cliente) REFERENCES Cliente(clie_codigo),
	FOREIGN KEY (rese_estado) REFERENCES Estado(ep_codigo),
	FOREIGN KEY (rese_ruta) REFERENCES Ruta_Viaje(rv_codigo)
)

--*************************************************************************************************************
-- TABLE USUARIO
--*************************************************************************************************************

CREATE TABLE [NUEVO_SCHEMA].[Usuario] (
	[usua_codigo] [NUMERIC] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[usua_username] [NVARCHAR](255) NOT NULL,
	[usua_password] [NVARCHAR](255) NOT NULL,
	[usua_login_fallidos] INT NOT NULL,
	[usua_fecha_inhabilitaicon] DATETIME2(3)
)

--*************************************************************************************************************
-- TABLE ROL
--*************************************************************************************************************

CREATE TABLE [NUEVO_SCHEMA].[Rol] (
	[rol_codigo] [NUMERIC] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[rol_nombre] [NVARCHAR](255) NOT NULL UNIQUE,
	[rol_activo] [BIT] NOT NULL DEFAULT 1,
)

--*************************************************************************************************************
-- TABLE PERMISO
--*************************************************************************************************************

CREATE TABLE [NUEVO_SCHEMA].[Permiso] (
	[perm_codigo] [NUMERIC] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[perm_nombre] [NVARCHAR](255) NOT NULL,
)

--*************************************************************************************************************
-- TABLE ROL_USUARIO
--*************************************************************************************************************

CREATE TABLE [NUEVO_SCHEMA].[Rol_Usuario] (
	[ru_usua_codigo] [NUMERIC] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[ru_rol_codigo] [NUMERIC] IDENTITY(1,1) NOT NULL PRIMARY KEY,
)

--*************************************************************************************************************
-- TABLE PERMISO_ROL
--*************************************************************************************************************

CREATE TABLE [NUEVO_SCHEMA].[Permiso_Rol] (
	[pr_rol_codigo] [NUMERIC] NOT NULL PRIMARY KEY,
	[pr_perm_codigo] [NUMERIC] NOT NULL PRIMARY KEY,
)



--*************************************************************************************************************
--*************************************************************************************************************
-- MIGRACION DE DATOS
--*************************************************************************************************************
--*************************************************************************************************************

--*************************************************************************************************************
-- TABLE PERMISO
--*************************************************************************************************************

INSERT INTO [NUEVO_SCHEMA].Permiso(perm_nombre)
VALUES ('ABM_ROL'),('ABM_PUERTO'),('ABM_RECORRIDO'),('ABM_CRUCERO'),('GENERAR_VIAJE'),('COMPRAR_PASAJE'),('RESERVA_PASAJE'),('PAGO_RESERVA'),('LISTADO_ESTADISTICO')
GO

--*************************************************************************************************************
-- TABLE ROL + PERMISO_ROL
--*************************************************************************************************************

-- DEFINO EL ROL ADMINISTRATIVO

INSERT INTO [NUEVO_SCHEMA].Rol(rol_nombre)
VALUES ('Administrativo')
GO

-- El rol de administrador tiene todos los permisos asignados
INSERT INTO [NUEVO_SCHEMA].Permiso_Rol(pr_rol_codigo,pr_perm_codigo)
SELECT DISTINCT SCOPE_IDENTITY(), perm_codigo FROM [NUEVO_SCHEMA].Permiso
GO


-- DEFINO EL ROL CLIENTE

INSERT INTO [NUEVO_SCHEMA].Rol(rol_nombre)
VALUES ('Cliente')
GO

-- El rol de cliente tiene los siguientes permisos asignados: COMPRAR_PASAJE,RESERVA_PASAJE,PAGO_RESERVA,LISTADO_ESTADISTICO
INSERT INTO [NUEVO_SCHEMA].Permiso_Rol(pr_rol_codigo,pr_perm_codigo)
SELECT DISTINCT SCOPE_IDENTITY(), perm_codigo FROM [NUEVO_SCHEMA].Permiso
WHERE perm_nombre IN ('COMPRAR_PASAJE','RESERVA_PASAJE','PAGO_RESERVA','LISTADO_ESTADISTICO')
GO

--*************************************************************************************************************
-- TABLE USUARIO + ROL_USUARIO
-- Declaro un usuario y le asigno el rol correspondiente
--*************************************************************************************************************

DECLARE @password [nvarchar](255)
DECLARE @codigo_rol_administrativo [NUMERIC]
DECLARE @codigo_rol_cliente [NUMERIC]

SET @password = 'w23e'
SET @codigo_rol_administrativo = SELECT rol_codigo FROM [NUEVO_SCHEMA].Rol WHERE rol_nombre = 'Administrativo'
SET @codigo_rol_cliente = SELECT rol_codigo FROM [NUEVO_SCHEMA].Rol WHERE rol_nombre = 'Cliente'

-- Nuevo usuario administrativo

INSERT INTO [NUEVO_SCHEMA].Usuario(usua_username,usua_password)
VALUES ('admin', HASHBYTES('SHA2_256', @password))
GO

INSERT INTO [NUEVO_SCHEMA].Rol_Usuario(ru_codigo,ru_)
VALUES (SCOPE_IDENTITY(),@codigo_rol_administrativo)
GO

-- Nuevo usuario administrativo

INSERT INTO [NUEVO_SCHEMA].Usuario(usua_username,usua_password)
VALUES ('admin2', HASHBYTES('SHA2_256', @password))
GO

INSERT INTO [NUEVO_SCHEMA].Rol_Usuario(ru_codigo,ru_)
VALUES (SCOPE_IDENTITY(),@codigo_rol_administrativo)
GO

SET @password = 'clie'

-- Nuevo usuario cliente

INSERT INTO [NUEVO_SCHEMA].Usuario(usua_username,usua_password)
VALUES ('clie1', HASHBYTES('SHA2_256', @password))
GO

INSERT INTO [NUEVO_SCHEMA].Rol_Usuario(ru_codigo,ru_)
VALUES (SCOPE_IDENTITY(),@codigo_rol_cliente)
GO

-- Nuevo usuario cliente

INSERT INTO [NUEVO_SCHEMA].Usuario(usua_username,usua_password)
VALUES ('clie2', HASHBYTES('SHA2_256', @password))
GO

INSERT INTO [NUEVO_SCHEMA].Rol_Usuario(ru_codigo,ru_)
VALUES (SCOPE_IDENTITY(),@codigo_rol_cliente)
GO

--*************************************************************************************************************
-- TABLE CLIENTE
--*************************************************************************************************************























