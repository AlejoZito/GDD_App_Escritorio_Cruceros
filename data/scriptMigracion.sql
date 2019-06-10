USE [GD1C2019]
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

IF OBJECT_ID('[TIRANDO_QUERIES].[Cliente]','U') IS NOT NULL DROP TABLE [TIRANDO_QUERIES].[Cliente];
IF OBJECT_ID('[TIRANDO_QUERIES].[Pasaje]','U') IS NOT NULL DROP TABLE [TIRANDO_QUERIES].[Pasaje];
IF OBJECT_ID('[TIRANDO_QUERIES].[Pago]','U') IS NOT NULL DROP TABLE [TIRANDO_QUERIES].[Pago];
IF OBJECT_ID('[TIRANDO_QUERIES].[Medio_Pago]','U') IS NOT NULL DROP TABLE [TIRANDO_QUERIES].[Medio_Pago];
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

--TODO

--*************************************************************************************************************
-- DROP FUNCTIONS
-- Realizo un DROP de las funciones previo a su creación en caso existan
--*************************************************************************************************************

--TODO

--*************************************************************************************************************
-- DROP TRIGGERS
-- Realizo un DROP de los triggers previo a su creación en caso existan
--*************************************************************************************************************

--TODO
--Cuando inhabilitas un rol (baja lógica), se lo tenés que quitar al usuario que lo tenga (delete rol_permiso)




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
	[clie_dni] [DECIMAL](18,0) NOT NULL,
	[clie_telefono] [INT] NOT NULL,
	[clie_direccion] [NVARCHAR](255) NOT NULL,
	[clie_mail] [NVARCHAR](255) NOT NULL,
	[clie_fecha_nac] DATETIME2(3) NOT NULL
)

--*************************************************************************************************************
-- TABLE FABRICANTE
--*************************************************************************************************************

CREATE TABLE [TIRANDO_QUERIES].[Fabricante] (
	[fabr_codigo] [NUMERIC] IDENTITY(1,1) PRIMARY KEY,
	[fabr_detalle] [NVARCHAR](255) NOT NULL
)

--*************************************************************************************************************
-- TABLE MODELO_CRUCERO
--*************************************************************************************************************

CREATE TABLE [TIRANDO_QUERIES].[Modelo_Crucero] (
	[mc_codigo] [NUMERIC] IDENTITY(1,1) PRIMARY KEY,
	[mc_detalle] [NVARCHAR](50) NOT NULL
)

--*************************************************************************************************************
-- TABLE CRUCERO
--*************************************************************************************************************

CREATE TABLE [TIRANDO_QUERIES].[Crucero] (
	[cruc_codigo] [NUMERIC] IDENTITY(1,1) PRIMARY KEY,
	[cruc_identificador] [NVARCHAR](50) NULL,
	[cruc_fabricante] [NUMERIC] NOT NULL,
	[cruc_modelo] [NUMERIC] NOT NULL,
	[cruc_activo] BIT
	--FOREIGN KEY (cruc_fabricante) REFERENCES Fabricante(fabr_codigo),
	--FOREIGN KEY (cruc_modelo) REFERENCES Modelo_Crucero(mode_codigo)
)

--*************************************************************************************************************
-- TABLE MANTENIMIENTO
--*************************************************************************************************************

CREATE TABLE [TIRANDO_QUERIES].[Mantenimiento] (
	[mant_codigo] [NUMERIC] IDENTITY(1,1) PRIMARY KEY,
	[mant_crucero] [NUMERIC] NOT NULL,
	[mant_fecha_desde] DATETIME2(3),
	[mant_fecha_hasta] DATETIME2(3)
	--FOREIGN KEY (mant_crucero) REFERENCES Crucero(cruc_codigo)
)

--*************************************************************************************************************
-- TABLE TIPO_CABINA
--*************************************************************************************************************

CREATE TABLE [TIRANDO_QUERIES].[Tipo_Cabina] (
	[tc_codigo] [NUMERIC] IDENTITY(1,1) PRIMARY KEY,
	[tc_detalle] [NVARCHAR](255) NOT NULL,
	[tc_porc_recargo] [DECIMAL](18,2) NOT NULL
)

--*************************************************************************************************************
-- TABLE CABINA
--*************************************************************************************************************

CREATE TABLE [TIRANDO_QUERIES].[Cabina] (
	[cabi_codigo] [NUMERIC] IDENTITY(1,1) PRIMARY KEY,
	[cabi_numero] [DECIMAL](18,0) NOT NULL,
	[cabi_piso] [DECIMAL](18,0) NOT NULL,
	[cabi_crucero] [NUMERIC] NOT NULL
	--FOREIGN KEY (cabi_crucero) REFERENCES Crucero(cruc_codigo)
)

--*************************************************************************************************************
-- TABLE ESTADO_RESERVA
--*************************************************************************************************************

CREATE TABLE [TIRANDO_QUERIES].[Estado_Reserva] (
	[er_codigo] [NUMERIC] IDENTITY(1,1) PRIMARY KEY,
	[er_detalle] [NVARCHAR](255) NOT NULL
)

--*************************************************************************************************************
-- TABLE PUERTO
--*************************************************************************************************************

CREATE TABLE [TIRANDO_QUERIES].[Puerto] (
	[puer_codigo] [NUMERIC] IDENTITY(1,1) PRIMARY KEY,
	[puer_nombre] [NVARCHAR](255) NOT NULL,
	[puer_activo] BIT NOT NULL DEFAULT 1
)

--*************************************************************************************************************
-- TABLE RECORRIDO
--*************************************************************************************************************

CREATE TABLE [TIRANDO_QUERIES].[Recorrido] (
	[reco_codigo] [NUMERIC] IDENTITY(1,1) PRIMARY KEY,
	[reco_activo] BIT NOT NULL DEFAULT 1
)

--*************************************************************************************************************
-- TABLE TRAMO
--*************************************************************************************************************

CREATE TABLE [TIRANDO_QUERIES].[Tramo] (
	[tram_recorrido] [NUMERIC],
	[tram_puerto_desde] [NUMERIC],
	[tram_puerto_hasta] [NUMERIC],
	[tram_precio] [NUMERIC],
	[tram_codigo] [INT],
	PRIMARY KEY (tram_recorrido,tram_puerto_desde,tram_puerto_hasta)
	--FOREIGN KEY (tram_recorrido) REFERENCES Recorrido(reco_codigo),
	--FOREIGN KEY (tram_puerto_desde) REFERENCES Puerto(puer_codigo),
	--FOREIGN KEY (tram_puerto_hasta) REFERENCES Puerto(puer_codigo)
)

--*************************************************************************************************************
-- TABLE RUTA_VIAJE
--*************************************************************************************************************

CREATE TABLE [TIRANDO_QUERIES].[Ruta_Viaje] (
	[rv_codigo] [NUMERIC] IDENTITY(1,1) PRIMARY KEY,
	[rv_recorrido] [NUMERIC] NOT NULL,
	[rv_crucero] [NUMERIC] NOT NULL,
	[rv_fecha_inicio] DATETIME2(3),
	[rv_fecha_fin] DATETIME2(3),
	[rv_fecha_fin_estimada] DATETIME2(3)
	--FOREIGN KEY (rv_recorrido) REFERENCES Recorrido(reco_codigo),
	--FOREIGN KEY (rv_crucero) REFERENCES Crucero(cruc_codigo)
)

--*************************************************************************************************************
-- TABLE ESTADO_PASAJE
--*************************************************************************************************************

CREATE TABLE [TIRANDO_QUERIES].[Estado_Pasaje] (
	[ep_codigo] [NUMERIC] IDENTITY(1,1) PRIMARY KEY,
	[ep_detalle] [NVARCHAR](255) NOT NULL
)

--*************************************************************************************************************
-- TABLE MEDIO_PAGO
--*************************************************************************************************************

CREATE TABLE [TIRANDO_QUERIES].[Medio_Pago] (
	[mp_codigo] [NUMERIC] IDENTITY(1,1) PRIMARY KEY,
	[mp_detalle] [NVARCHAR](255) NOT NULL,
	[mp_cuotas_permitidas] [INT],
)

--*************************************************************************************************************
-- TABLE PAGO
--*************************************************************************************************************

CREATE TABLE [TIRANDO_QUERIES].[Pago] (
	[pago_codigo] [NUMERIC] IDENTITY(1,1) PRIMARY KEY,
	[pago_fecha_compra] DATETIME2(3),
	[pago_medio_pago] [NUMERIC] NOT NULL,
	[pago_cuotas] [INT]
	--FOREIGN KEY (pago_medio_pago) REFERENCES Medio_Pago(mp_codigo),
)

--*************************************************************************************************************
-- TABLE PASAJE
--*************************************************************************************************************

CREATE TABLE [TIRANDO_QUERIES].[Pasaje] (
	[pasa_codigo] [NUMERIC] IDENTITY(1,1) PRIMARY KEY,
	[pasa_precio]  [DECIMAL](18,2) NOT NULL,
	[pasa_cabina] [NUMERIC] NOT NULL,
	[pasa_cliente] [NUMERIC] NOT NULL,
	[pasa_estado] [NUMERIC] NOT NULL,
	[pasa_pago] [NUMERIC] NOT NULL,
	[pasa_ruta] [NUMERIC] NOT NULL
	--FOREIGN KEY (pasa_cabina) REFERENCES Cabina(cabi_codigo),
	--FOREIGN KEY (pasa_cliente) REFERENCES Cliente(clie_codigo),
	--FOREIGN KEY (pasa_estado) REFERENCES Estado(ep_codigo),
	--FOREIGN KEY (pasa_pago) REFERENCES Pago(pago_codigo),
	--FOREIGN KEY (pasa_ruta) REFERENCES Ruta_Viaje(rv_codigo)
)

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
	[rese_ruta] [NUMERIC] NOT NULL
	--FOREIGN KEY (rese_cabina) REFERENCES Cabina(cabi_codigo),
	--FOREIGN KEY (rese_cliente) REFERENCES Cliente(clie_codigo),
	--FOREIGN KEY (rese_estado) REFERENCES Estado(ep_codigo),
	--FOREIGN KEY (rese_ruta) REFERENCES Ruta_Viaje(rv_codigo)
)

--*************************************************************************************************************
-- TABLE USUARIO
--*************************************************************************************************************

CREATE TABLE [TIRANDO_QUERIES].[Usuario] (
	[usua_codigo] [NUMERIC] IDENTITY(1,1) PRIMARY KEY,
	[usua_username] [NVARCHAR](255) NOT NULL,
	[usua_password] [NVARCHAR](255) NOT NULL,
	[usua_login_fallidos] INT NOT NULL DEFAULT 0,
	[usua_fecha_inhabilitaicon] DATETIME2(3)
)

--*************************************************************************************************************
-- TABLE ROL
--*************************************************************************************************************

CREATE TABLE [TIRANDO_QUERIES].[Rol] (
	[rol_codigo] [NUMERIC] IDENTITY(1,1) PRIMARY KEY,
	[rol_nombre] [NVARCHAR](255) NOT NULL UNIQUE,
	[rol_activo] [BIT] NOT NULL DEFAULT 1,
)

--*************************************************************************************************************
-- TABLE PERMISO
--*************************************************************************************************************

CREATE TABLE [TIRANDO_QUERIES].[Permiso] (
	[perm_codigo] [NUMERIC] IDENTITY(1,1) PRIMARY KEY,
	[perm_nombre] [NVARCHAR](255) NOT NULL,
)

--*************************************************************************************************************
-- TABLE ROL_USUARIO
--*************************************************************************************************************

CREATE TABLE [TIRANDO_QUERIES].[Rol_Usuario] (
	[ru_usua_codigo] [NUMERIC],
	[ru_rol_codigo] [NUMERIC],
	PRIMARY KEY (ru_usua_codigo,ru_rol_codigo)
	--FOREIGN KEY (ru_usua_codigo) REFERENCES Usuario(usua_codigo),
	--FOREIGN KEY (ru_rol_codigo) REFERENCES Rol(rol_codigo)
)

--*************************************************************************************************************
-- TABLE PERMISO_ROL
--*************************************************************************************************************

CREATE TABLE [TIRANDO_QUERIES].[Permiso_Rol] (
	[pr_rol_codigo] [NUMERIC],
	[pr_perm_codigo] [NUMERIC],
	PRIMARY KEY (pr_rol_codigo,pr_perm_codigo)
	--FOREIGN KEY (pr_rol_codigo) REFERENCES Rol(rol_codigo),
	--FOREIGN KEY (pr_perm_codigo) REFERENCES Permiso(perm_codigo)
)



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
VALUES ('Administrativo')
GO

-- El rol de administrador tiene todos los permisos asignados
INSERT INTO [TIRANDO_QUERIES].Permiso_Rol(pr_rol_codigo,pr_perm_codigo)
SELECT DISTINCT SCOPE_IDENTITY(), perm_codigo FROM [TIRANDO_QUERIES].Permiso
GO


-- DEFINO EL ROL CLIENTE

INSERT INTO [TIRANDO_QUERIES].Rol(rol_nombre)
VALUES ('Cliente')
GO

-- El rol de cliente tiene los siguientes permisos asignados: COMPRAR_PASAJE,RESERVA_PASAJE,PAGO_RESERVA,LISTADO_ESTADISTICO
INSERT INTO [TIRANDO_QUERIES].Permiso_Rol(pr_rol_codigo,pr_perm_codigo)
SELECT DISTINCT SCOPE_IDENTITY(), perm_codigo FROM [TIRANDO_QUERIES].Permiso
WHERE perm_nombre IN ('COMPRAR_PASAJE','RESERVA_PASAJE','PAGO_RESERVA','LISTADO_ESTADISTICO')
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

-- Nuevo usuario cliente

DECLARE @password [nvarchar](255)
SET @password = 'clie'

INSERT INTO [TIRANDO_QUERIES].Usuario(usua_username,usua_password)
VALUES ('clie1', HASHBYTES('SHA2_256', @password))
GO

DECLARE @codigo_rol_cliente [NUMERIC]
SET @codigo_rol_cliente = (SELECT rol_codigo FROM [TIRANDO_QUERIES].Rol WHERE rol_nombre = 'Cliente')

INSERT INTO [TIRANDO_QUERIES].Rol_Usuario(ru_usua_codigo,ru_rol_codigo)
VALUES (SCOPE_IDENTITY(),@codigo_rol_cliente)
GO

-- Nuevo usuario cliente

DECLARE @password [nvarchar](255)
SET @password = 'clie'

INSERT INTO [TIRANDO_QUERIES].Usuario(usua_username,usua_password)
VALUES ('clie2', HASHBYTES('SHA2_256', @password))
GO

DECLARE @codigo_rol_cliente [NUMERIC]
SET @codigo_rol_cliente = (SELECT rol_codigo FROM [TIRANDO_QUERIES].Rol WHERE rol_nombre = 'Cliente')

INSERT INTO [TIRANDO_QUERIES].Rol_Usuario(ru_usua_codigo,ru_rol_codigo)
VALUES (SCOPE_IDENTITY(),@codigo_rol_cliente)
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
-- TABLE TIPO_CABINA
--*************************************************************************************************************

INSERT INTO [TIRANDO_QUERIES].Tipo_Cabina(tc_detalle,tc_porc_recargo)
SELECT DISTINCT cabina_tipo,cabina_tipo_porc_recargo FROM gd_esquema.Maestra
WHERE cabina_tipo IS NOT NULL AND cabina_tipo_porc_recargo IS NOT NULL
GO

