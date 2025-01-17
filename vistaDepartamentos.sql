USE [master]
GO
CREATE DATABASE [vistaDepartamentosDB]

USE [vistaDepartamentosDB]

/* //////////////////////////////CREATE TABLES////////////////////////////// */

CREATE TABLE [dbo].[DEPARTAMENTO](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Descripcion] [nvarchar](500) NOT NULL,
	[IdUbicacion] [int] NOT NULL,
	[Tarifa] [numeric](18, 0) NOT NULL,
	[Estado] [bit] NOT NULL,
	[Imagen] [nvarchar](2000) NOT NULL,
 CONSTRAINT [PK_DEPARTAMENTO] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[DEPARTAMENTODETALLE](
	[IdDepartamento] [int] NOT NULL,
	[IdExtra] [int] NOT NULL,
 CONSTRAINT [PK_DEPARTAMENTODETALLE] PRIMARY KEY CLUSTERED 
(
	[IdDepartamento] ASC,
	[IdExtra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[EXTRA](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_EXTRA] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[RESERVA](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[IdDepartamento] [int] NOT NULL,
	[FechaReserva] [datetime] NOT NULL,
	[FechaFinReserva] [datetime] NOT NULL,
	[IdTipoPago] [int] NOT NULL,
	[NumeroTarjeta] [nvarchar](20) NOT NULL,
	[CantPersonas] [int] NOT NULL,
	[SubTotal] [numeric](18, 0) NOT NULL,
	[Impuesto] [numeric](18, 0) NOT NULL,
	[Total] [numeric](18, 0) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_RESERVA] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[ROL](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ROL] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[SERVICIODETALLE](
	[IdServicio] [int] NOT NULL,
	[IdReserva] [int] NOT NULL,
 CONSTRAINT [PK_SERVICIODETALLE_1] PRIMARY KEY CLUSTERED 
(
	[IdServicio] ASC,
	[IdReserva] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[SERVICIOS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
	[Precio] [numeric](18, 0) NOT NULL,
	[Estado] [bit] NULL,
 CONSTRAINT [PK_SERVICIOS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[TIPOPAGO](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_TIPOPAGO] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[UBICACION](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_UBICACION] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[USUARIO](
	[Id] [int]  IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido1] [nvarchar](50) NOT NULL,
	[Apellido2] [nvarchar](50) NOT NULL,
	[Correo] [nvarchar](50) NOT NULL,
	[Telefono] [nvarchar](20) NOT NULL,
	[Sexo] [char](1) NOT NULL,
	[FechaNacimiento] [datetime] NOT NULL,
	[Clave] [char](50) NOT NULL,
	[IdRol] [int] NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_USUARIO] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/* //////////////////////////////FK TABLES////////////////////////////// */
ALTER TABLE [dbo].[DEPARTAMENTO]  WITH CHECK ADD  CONSTRAINT [FK_DEPARTAMENTO_UBICACION] FOREIGN KEY([IdUbicacion])
REFERENCES [dbo].[UBICACION] ([Id])
GO
ALTER TABLE [dbo].[DEPARTAMENTO] CHECK CONSTRAINT [FK_DEPARTAMENTO_UBICACION]
GO
ALTER TABLE [dbo].[DEPARTAMENTODETALLE]  WITH CHECK ADD  CONSTRAINT [FK_DEPARTAMENTODETALLE_DEPARTAMENTO] FOREIGN KEY([IdDepartamento])
REFERENCES [dbo].[DEPARTAMENTO] ([Id])
GO
ALTER TABLE [dbo].[DEPARTAMENTODETALLE] CHECK CONSTRAINT [FK_DEPARTAMENTODETALLE_DEPARTAMENTO]
GO
ALTER TABLE [dbo].[DEPARTAMENTODETALLE]  WITH CHECK ADD  CONSTRAINT [FK_DEPARTAMENTODETALLE_EXTRA] FOREIGN KEY([IdExtra])
REFERENCES [dbo].[EXTRA] ([Id])
GO
ALTER TABLE [dbo].[DEPARTAMENTODETALLE] CHECK CONSTRAINT [FK_DEPARTAMENTODETALLE_EXTRA]
GO
ALTER TABLE [dbo].[RESERVA]  WITH CHECK ADD  CONSTRAINT [FK_RESERVA_DEPARTAMENTO] FOREIGN KEY([IdDepartamento])
REFERENCES [dbo].[DEPARTAMENTO] ([Id])
GO
ALTER TABLE [dbo].[RESERVA] CHECK CONSTRAINT [FK_RESERVA_DEPARTAMENTO]
GO
ALTER TABLE [dbo].[RESERVA]  WITH CHECK ADD  CONSTRAINT [FK_RESERVA_TIPOPAGO] FOREIGN KEY([IdTipoPago])
REFERENCES [dbo].[TIPOPAGO] ([Id])
GO
ALTER TABLE [dbo].[RESERVA] CHECK CONSTRAINT [FK_RESERVA_TIPOPAGO]
GO
ALTER TABLE [dbo].[RESERVA]  WITH CHECK ADD  CONSTRAINT [FK_RESERVA_USUARIO] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[USUARIO] ([Id])
GO
ALTER TABLE [dbo].[RESERVA] CHECK CONSTRAINT [FK_RESERVA_USUARIO]
GO
ALTER TABLE [dbo].[SERVICIODETALLE]  WITH CHECK ADD  CONSTRAINT [FK_SERVICIODETALLE_RESERVA] FOREIGN KEY([IdReserva])
REFERENCES [dbo].[RESERVA] ([Id])
GO
ALTER TABLE [dbo].[SERVICIODETALLE] CHECK CONSTRAINT [FK_SERVICIODETALLE_RESERVA]
GO
ALTER TABLE [dbo].[SERVICIODETALLE]  WITH CHECK ADD  CONSTRAINT [FK_SERVICIODETALLE_SERVICIOS] FOREIGN KEY([IdServicio])
REFERENCES [dbo].[SERVICIOS] ([Id])
GO
ALTER TABLE [dbo].[SERVICIODETALLE] CHECK CONSTRAINT [FK_SERVICIODETALLE_SERVICIOS]
GO
ALTER TABLE [dbo].[USUARIO]  WITH CHECK ADD  CONSTRAINT [FK_USUARIO_ROL] FOREIGN KEY([IdRol])
REFERENCES [dbo].[ROL] ([Id])
GO
ALTER TABLE [dbo].[USUARIO] CHECK CONSTRAINT [FK_USUARIO_ROL]


/* //////////////////////////////INSERT TABLES////////////////////////////// */
USE [vistaDepartamentosDB]
--Ubicacion
INSERT INTO UBICACION VALUES('Desamparados, San Jose', 1);
INSERT INTO UBICACION VALUES('Naranjo, Alajuela', 1);
INSERT INTO UBICACION VALUES('Alajuela centro, Alajuela', 1);
INSERT INTO UBICACION VALUES('San Jose centro, San Jose', 1);
INSERT INTO UBICACION VALUES('San Ramon, Alajuela', 1);
INSERT INTO UBICACION VALUES('Grecia, Alajuela', 1);

--Extras
INSERT INTO EXTRA VALUES('Estacionamiento', 1);
INSERT INTO EXTRA VALUES('Garage', 1);
INSERT INTO EXTRA VALUES('Piscina', 1);
INSERT INTO EXTRA VALUES('Internet', 1);
INSERT INTO EXTRA VALUES('Cable', 1);
INSERT INTO EXTRA VALUES('Luz', 1);

--Departamento
INSERT INTO DEPARTAMENTO VALUES('Departamento estilo Urbano','Cuenta con 2 dormitorio con baño, cocina moderna equipada, un baño principal y sala de estar',4,459,1,'https://images.unsplash.com/photo-1554995207-c18c203602cb?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=750&q=80')
INSERT INTO DEPARTAMENTO VALUES('Departamento Elegante Desamparados', 'Cuenta con 3 dormitorios con baño, cocina moderna equipada, comedor, 2 baños principales, sala de estar, terraza y comedor externo',1,699,1,'https://images.unsplash.com/photo-1503174971373-b1f69850bded?ixlib=rb-1.2.1&ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&auto=format&fit=crop&w=787&q=80')
INSERT INTO DEPARTAMENTO VALUES('Departamento estilo Cabaña', 'Cuenta con 2 dormitorios con baño, cocina equipada, chimenea, un baño principal y sala de estar',2,329,1,'https://images.unsplash.com/photo-1501183638710-841dd1904471?ixlib=rb-1.2.1&ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&auto=format&fit=crop&w=750&q=80')
INSERT INTO DEPARTAMENTO VALUES('Departamento Familiar San Jose Centro', 'Cuenta con 2 dormitorios con baño, cocina equipada, comedor, un baño principal y sala de estar',4,559,1,'https://images.unsplash.com/photo-1505873242700-f289a29e1e0f?ixlib=rb-1.2.1&ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&auto=format&fit=crop&w=755&q=80')
INSERT INTO DEPARTAMENTO VALUES('Departamento Delux', 'Cuenta con 3 dormitorios con baño, cocina moderna equipada, 2 baños principales, MiniBar, mesa de pool, sala de estar y terraza con comedor',3,799,1,'https://images.unsplash.com/photo-1432303492674-642e9d0944b2?ixlib=rb-1.2.1&ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&auto=format&fit=crop&w=753&q=80')
INSERT INTO DEPARTAMENTO VALUES('Departamento Centro de San Ramon', 'Cuenta con 2 dormitorios con baño, cocina equipada, un baño principal y sala de estar',5,439,1,'https://images.unsplash.com/photo-1538569167668-086851742d17?ixlib=rb-1.2.1&ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&auto=format&fit=crop&w=889&q=80')
INSERT INTO DEPARTAMENTO VALUES('Departamento para Estudiante', 'Cuenta con un dormitorio con baño, cocina equipada, comedor, un baño principal y sala de estar',3,329,1,'https://images.unsplash.com/photo-1522708323590-d24dbb6b0267?ixlib=rb-1.2.1&ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&auto=format&fit=crop&w=750&q=80')
INSERT INTO DEPARTAMENTO VALUES('Departamento amueblado Naranjo', 'Cuenta con 2 dormitorios con baño, cocina moderna equipada, un baño principal, gran sala de estar y jardín',2,659,1,'https://images.unsplash.com/photo-1560185007-c5ca9d2c014d?ixlib=rb-1.2.1&ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&auto=format&fit=crop&w=750&q=80')
INSERT INTO DEPARTAMENTO VALUES('Departamento nuevo Desamparados','Cuenta con 2 dormitorios con baño, cocina moderna equipada, comedor, chimenea, un baño principal, sala de estar y jardín',1,699,1,'https://images.unsplash.com/photo-1560185009-5bf9f2849488?ixlib=rb-1.2.1&ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&auto=format&fit=crop&w=750&q=80')
INSERT INTO DEPARTAMENTO VALUES('Departamento afueras de San Ramon','Cuenta con 2 dormitorios con baño, cocina con isla equipada, un baño principal y sala de estar',5,469,1,'https://images.unsplash.com/photo-1560185127-2d06c6d08d3d?ixlib=rb-1.2.1&ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&auto=format&fit=crop&w=750&q=80')
INSERT INTO DEPARTAMENTO VALUES('Departamento cerca del aeropuerto - San Jose','Cuenta con 3 dormitorios con baño, gran cocina moderna equipada, comedor, un baño principal y sala de estar',4,499,1,'https://images.unsplash.com/photo-1495433324511-bf8e92934d90?ixlib=rb-1.2.1&ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&auto=format&fit=crop&w=750&q=80')
INSERT INTO DEPARTAMENTO VALUES('Departamento Dulce nombre, Naranjo','Cuenta con 3 dormitorios con baño, gran cocina moderna equipada, comedor, chimenea, 2 baños principales, sala de estar y jardín',2,699,1,'https://images.unsplash.com/photo-1560185008-b033106af5c3?ixlib=rb-1.2.1&ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&auto=format&fit=crop&w=750&q=80')
INSERT INTO DEPARTAMENTO VALUES('Prueba 1','Departamento prueba',1,400,1,'https://images.unsplash.com/photo-1600121848594-d8644e57abab?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=750&q=80')
INSERT INTO DEPARTAMENTO VALUES('Prueba 2','Departamento prueba',5,500,1,'https://images.unsplash.com/photo-1600121848594-d8644e57abab?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=750&q=80')
INSERT INTO DEPARTAMENTO VALUES('Prueba 3','Departamento prueba',2,400,1,'https://images.unsplash.com/photo-1600121848594-d8644e57abab?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=750&q=80')

--Departamento Detalle
INSERT INTO DEPARTAMENTODETALLE VALUES(16, 1)
INSERT INTO DEPARTAMENTODETALLE VALUES(16, 2)
INSERT INTO DEPARTAMENTODETALLE VALUES(17, 1)
INSERT INTO DEPARTAMENTODETALLE VALUES(17, 3)
INSERT INTO DEPARTAMENTODETALLE VALUES(18, 1)
INSERT INTO DEPARTAMENTODETALLE VALUES(19, 2)
INSERT INTO DEPARTAMENTODETALLE VALUES(20, 2)
INSERT INTO DEPARTAMENTODETALLE VALUES(20, 3)
INSERT INTO DEPARTAMENTODETALLE VALUES(21, 1)
INSERT INTO DEPARTAMENTODETALLE VALUES(22, 1)
INSERT INTO DEPARTAMENTODETALLE VALUES(23, 2)
INSERT INTO DEPARTAMENTODETALLE VALUES(9, 1)
INSERT INTO DEPARTAMENTODETALLE VALUES(24, 2)
INSERT INTO DEPARTAMENTODETALLE VALUES(25, 2)
INSERT INTO DEPARTAMENTODETALLE VALUES(26, 2)
INSERT INTO DEPARTAMENTODETALLE VALUES(26, 3)
INSERT INTO DEPARTAMENTODETALLE VALUES(27, 2)
INSERT INTO DEPARTAMENTODETALLE VALUES(28, 2)
INSERT INTO DEPARTAMENTODETALLE VALUES(29, 2)
INSERT INTO DEPARTAMENTODETALLE VALUES(29, 3)

--Rol
INSERT INTO ROL VALUES('Administrador')
INSERT INTO ROL VALUES('Procesos')
INSERT INTO ROL VALUES('Reportes')

--Usuario
INSERT INTO USUARIO VALUES('Bryan', 'Elizondo', 'Mora','bryanelizondo02@gmail.com', '84217621', 'M', '1998-11-01 00:00:00.000', '2PR07NWG3wVJMcqgry+0m1+QVrZtJlWI5gOqgn2LES8=', 1, 1)
INSERT INTO USUARIO VALUES('Rodrigo', 'Cespedes', 'Perez','rperez@gmail.com', '68473314', 'M', '1996-07-04 00:00:00.000', '2PR07NWG3wVJMcqgry+0m1+QVrZtJlWI5gOqgn2LES8=', 2, 1)
INSERT INTO USUARIO VALUES('Andrea', 'Solis', 'Bolaños','aBolannos@gmail.com', '76014451', 'F', '1997-08-04 00:00:00.000', '2PR07NWG3wVJMcqgry+0m1+QVrZtJlWI5gOqgn2LES8=', 3, 1)
INSERT INTO USUARIO VALUES('Carolina', 'Gimenez', 'Salas','cgsalas@gmail.com', '65023378', 'F', '1995-07-04 00:00:00.000', '2PR07NWG3wVJMcqgry+0m1+QVrZtJlWI5gOqgn2LES8=', 2, 1)

--Servicios
INSERT INTO SERVICIOS VALUES('Seguridad', 'Operaciones de vigilancia y resguardo de entradas', 35, 1)
INSERT INTO SERVICIOS VALUES('Limpieza', 'Limpieza de habitaciones, baños y cocina', 10, 1)
INSERT INTO SERVICIOS VALUES('Mantenimiento', 'Mantenimiento preventivo', 15, 1)
INSERT INTO SERVICIOS VALUES('Recolección de basura', 'Recolección de basura 2 días a la semana', 3, 1)

--Tipo Pago
INSERT INTO TIPOPAGO VALUES('Efectivo', 1)
INSERT INTO TIPOPAGO VALUES('Tarjeta de crédito', 1)

--Reserva
insert into RESERVA values(1, 16, '2021-03-04 00:00:00.000', '2021-03-28 00:00:00.000', 2, '5587235514', 3, 469, 0.13, 505,1)
insert into RESERVA values(2, 17, '2021-03-02 00:00:00.000', '2021-03-28 00:00:00.000', 2, '7815420678', 2, 699, 90.87, 789.87,1)



--Servicio Detalle
INSERT INTO SERVICIODETALLE VALUES(1,4)
INSERT INTO SERVICIODETALLE VALUES(1,3)
INSERT INTO SERVICIODETALLE VALUES(2,4)
INSERT INTO SERVICIODETALLE VALUES(3,4)
INSERT INTO SERVICIODETALLE VALUES(2,3)


