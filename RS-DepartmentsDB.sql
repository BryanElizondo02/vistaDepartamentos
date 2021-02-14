USE [master]
GO
/****** Object:  Database [vistaDepartamentosDB]    Script Date: 10/2/2021 9:09:42 p. m. ******/
CREATE DATABASE [vistaDepartamentosDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'vistaDepartamentosDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\vistaDepartamentosDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'vistaDepartamentosDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\vistaDepartamentosDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [vistaDepartamentosDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [vistaDepartamentosDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [vistaDepartamentosDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [vistaDepartamentosDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [vistaDepartamentosDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [vistaDepartamentosDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [vistaDepartamentosDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [vistaDepartamentosDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [vistaDepartamentosDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [vistaDepartamentosDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [vistaDepartamentosDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [vistaDepartamentosDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [vistaDepartamentosDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [vistaDepartamentosDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [vistaDepartamentosDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [vistaDepartamentosDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [vistaDepartamentosDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [vistaDepartamentosDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [vistaDepartamentosDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [vistaDepartamentosDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [vistaDepartamentosDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [vistaDepartamentosDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [vistaDepartamentosDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [vistaDepartamentosDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [vistaDepartamentosDB] SET RECOVERY FULL 
GO
ALTER DATABASE [vistaDepartamentosDB] SET  MULTI_USER 
GO
ALTER DATABASE [vistaDepartamentosDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [vistaDepartamentosDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [vistaDepartamentosDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [vistaDepartamentosDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [vistaDepartamentosDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'vistaDepartamentosDB', N'ON'
GO
ALTER DATABASE [vistaDepartamentosDB] SET QUERY_STORE = OFF
GO
USE [vistaDepartamentosDB]
GO
/****** Object:  Table [dbo].[DEPARTAMENTO]    Script Date: 10/2/2021 9:09:43 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
/****** Object:  Table [dbo].[DEPARTAMENTODETALLE]    Script Date: 10/2/2021 9:09:43 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DEPARTAMENTODETALLE](
	[IdDepartamento] [int] NOT NULL,
	[IdExtra] [int] NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_DEPARTAMENTODETALLE] PRIMARY KEY CLUSTERED 
(
	[IdDepartamento] ASC,
	[IdExtra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EXTRA]    Script Date: 10/2/2021 9:09:43 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EXTRA](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_EXTRA] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RESERVA]    Script Date: 10/2/2021 9:09:43 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  Table [dbo].[ROL]    Script Date: 10/2/2021 9:09:43 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ROL](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ROL] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SERVICIODETALLE]    Script Date: 10/2/2021 9:09:43 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SERVICIODETALLE](
	[IdServicio] [int] IDENTITY(1,1) NOT NULL,
	[Secuencia] [int] NOT NULL,
	[IdReserva] [int] NOT NULL,
 CONSTRAINT [PK_SERVICIODETALLE_1] PRIMARY KEY CLUSTERED 
(
	[IdServicio] ASC,
	[Secuencia] ASC,
	[IdReserva] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SERVICIOS]    Script Date: 10/2/2021 9:09:43 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  Table [dbo].[TIPOPAGO]    Script Date: 10/2/2021 9:09:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIPOPAGO](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_TIPOPAGO] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UBICACION]    Script Date: 10/2/2021 9:09:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UBICACION](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_UBICACION] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USUARIO]    Script Date: 10/2/2021 9:09:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USUARIO](
	[Id] [int] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido1] [nvarchar](50) NOT NULL,
	[Apellido2] [nvarchar](50) NOT NULL,
	[Correo] [nvarchar](50) NOT NULL,
	[Telefono] [nvarchar](20) NOT NULL,
	[Sexo] [char](1) NOT NULL,
	[FechaNacimiento] [datetime] NOT NULL,
	[Clave] [nvarchar](20) NOT NULL,
	[IdRol] [int] NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_USUARIO] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
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
GO
USE [master]
GO
ALTER DATABASE [vistaDepartamentosDB] SET  READ_WRITE 
GO


INSERT INTO UBICACION VALUES('Desamparados, San Jose', 1);
INSERT INTO UBICACION VALUES('Naranjo, Alajuela', 1);
INSERT INTO UBICACION VALUES('Alajuela centro, Alajuela', 1);
INSERT INTO UBICACION VALUES('San Jose centro, San Jose', 1);
INSERT INTO UBICACION VALUES('San Ramon, Alajuela', 1);


INSERT INTO DEPARTAMENTO VALUES('Departamento estilo Urbano','Cuenta con 2 dormitorio con baño, cocina moderna equipada, un baño principal y sala de estar',4,459,1,'https://images.unsplash.com/photo-1554995207-c18c203602cb?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=750&q=80')
INSERT INTO DEPARTAMENTO VALUES('Departamento estilo Urbano','Cuenta con 2 dormitorio con baño, cocina moderna equipada, un baño principal y sala de estar',4,459,1,'https://images.unsplash.com/photo-1503174971373-b1f69850bded?ixlib=rb-1.2.1&ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&auto=format&fit=crop&w=787&q=80')
INSERT INTO DEPARTAMENTO VALUES('Departamento estilo Urbano','Cuenta con 2 dormitorio con baño, cocina moderna equipada, un baño principal y sala de estar',4,459,1,'https://images.unsplash.com/photo-1501183638710-841dd1904471?ixlib=rb-1.2.1&ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&auto=format&fit=crop&w=750&q=80')
INSERT INTO DEPARTAMENTO VALUES('Departamento estilo Urbano','Cuenta con 2 dormitorio con baño, cocina moderna equipada, un baño principal y sala de estar',4,459,1,'https://images.unsplash.com/photo-1505873242700-f289a29e1e0f?ixlib=rb-1.2.1&ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&auto=format&fit=crop&w=755&q=80')
INSERT INTO DEPARTAMENTO VALUES('Departamento estilo Urbano','Cuenta con 2 dormitorio con baño, cocina moderna equipada, un baño principal y sala de estar',4,459,1,'https://images.unsplash.com/photo-1432303492674-642e9d0944b2?ixlib=rb-1.2.1&ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&auto=format&fit=crop&w=753&q=80')
INSERT INTO DEPARTAMENTO VALUES('Departamento estilo Urbano','Cuenta con 2 dormitorio con baño, cocina moderna equipada, un baño principal y sala de estar',4,459,1,'https://images.unsplash.com/photo-1538569167668-086851742d17?ixlib=rb-1.2.1&ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&auto=format&fit=crop&w=889&q=80')
INSERT INTO DEPARTAMENTO VALUES('Departamento estilo Urbano','Cuenta con 2 dormitorio con baño, cocina moderna equipada, un baño principal y sala de estar',4,459,1,'https://images.unsplash.com/photo-1522708323590-d24dbb6b0267?ixlib=rb-1.2.1&ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&auto=format&fit=crop&w=750&q=80')
INSERT INTO DEPARTAMENTO VALUES('Departamento estilo Urbano','Cuenta con 2 dormitorio con baño, cocina moderna equipada, un baño principal y sala de estar',4,459,1,'https://images.unsplash.com/photo-1560185007-c5ca9d2c014d?ixlib=rb-1.2.1&ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&auto=format&fit=crop&w=750&q=80')
INSERT INTO DEPARTAMENTO VALUES('Departamento estilo Urbano','Cuenta con 2 dormitorio con baño, cocina moderna equipada, un baño principal y sala de estar',4,459,1,'https://images.unsplash.com/photo-1560185009-5bf9f2849488?ixlib=rb-1.2.1&ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&auto=format&fit=crop&w=750&q=80')
INSERT INTO DEPARTAMENTO VALUES('Departamento estilo Urbano','Cuenta con 2 dormitorio con baño, cocina moderna equipada, un baño principal y sala de estar',4,459,1,'https://images.unsplash.com/photo-1560185127-2d06c6d08d3d?ixlib=rb-1.2.1&ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&auto=format&fit=crop&w=750&q=80')
INSERT INTO DEPARTAMENTO VALUES('Departamento estilo Urbano','Cuenta con 2 dormitorio con baño, cocina moderna equipada, un baño principal y sala de estar',4,459,1,'https://images.unsplash.com/photo-1495433324511-bf8e92934d90?ixlib=rb-1.2.1&ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&auto=format&fit=crop&w=750&q=80')
INSERT INTO DEPARTAMENTO VALUES('Departamento estilo Urbano','Cuenta con 2 dormitorio con baño, cocina moderna equipada, un baño principal y sala de estar',4,459,1,'https://images.unsplash.com/photo-1560185008-b033106af5c3?ixlib=rb-1.2.1&ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&auto=format&fit=crop&w=750&q=80')
















