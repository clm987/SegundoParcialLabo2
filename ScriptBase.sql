USE [master]
GO
/****** Object:  Database [Restaurant]    Script Date: 24/11/2020 18:41:27 ******/
CREATE DATABASE [Restaurant]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Restaurant', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Restaurant.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Restaurant_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Restaurant_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Restaurant] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Restaurant].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Restaurant] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Restaurant] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Restaurant] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Restaurant] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Restaurant] SET ARITHABORT OFF 
GO
ALTER DATABASE [Restaurant] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Restaurant] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Restaurant] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Restaurant] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Restaurant] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Restaurant] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Restaurant] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Restaurant] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Restaurant] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Restaurant] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Restaurant] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Restaurant] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Restaurant] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Restaurant] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Restaurant] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Restaurant] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Restaurant] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Restaurant] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Restaurant] SET  MULTI_USER 
GO
ALTER DATABASE [Restaurant] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Restaurant] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Restaurant] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Restaurant] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Restaurant] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Restaurant] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Restaurant] SET QUERY_STORE = OFF
GO
USE [Restaurant]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 24/11/2020 18:41:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[Dni] [numeric](18, 0) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 24/11/2020 18:41:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[Dni] [numeric](18, 0) NOT NULL,
	[Usuario] [nvarchar](50) NOT NULL,
	[ClaveAcceso] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedido]    Script Date: 24/11/2020 18:41:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[IdEmpleado] [numeric](18, 0) NOT NULL,
	[DniCliente] [numeric](18, 0) NOT NULL,
	[TipoConsumo] [nvarchar](50) NOT NULL,
	[EstadoPedido] [nvarchar](50) NOT NULL,
	[Monto] [numeric](18, 2) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 24/11/2020 18:41:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Marca] [nvarchar](50) NOT NULL,
	[Tipo] [nvarchar](50) NOT NULL,
	[Stock] [numeric](18, 0) NOT NULL,
	[Precio] [decimal](19, 2) NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

INSERT [dbo].[Cliente] ([Id], [Nombre], [Apellido], [Dni]) VALUES (CAST(1 AS Numeric(18, 0)), N'Carlos', N'Lopez', CAST(123456 AS Numeric(18, 0)))
INSERT [dbo].[Cliente] ([Id], [Nombre], [Apellido], [Dni]) VALUES (CAST(2 AS Numeric(18, 0)), N'Juan', N'Perez', CAST(289456 AS Numeric(18, 0)))
INSERT [dbo].[Cliente] ([Id], [Nombre], [Apellido], [Dni]) VALUES (CAST(3 AS Numeric(18, 0)), N'Maria', N'Rodriguez', CAST(12345456 AS Numeric(18, 0)))
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[Empleado] ON 

INSERT [dbo].[Empleado] ([Id], [Nombre], [Apellido], [Dni], [Usuario], [ClaveAcceso]) VALUES (CAST(1 AS Numeric(18, 0)), N'Juana', N'Ramirez', CAST(12345678 AS Numeric(18, 0)), N'Jramirez', N'jramirez')
INSERT [dbo].[Empleado] ([Id], [Nombre], [Apellido], [Dni], [Usuario], [ClaveAcceso]) VALUES (CAST(2 AS Numeric(18, 0)), N'Miguel', N'Mejia', CAST(12345556 AS Numeric(18, 0)), N'Mmejia', N'Mmejia')
SET IDENTITY_INSERT [dbo].[Empleado] OFF
GO
SET IDENTITY_INSERT [dbo].[Pedido] ON 

INSERT [dbo].[Pedido] ([Id], [IdEmpleado], [DniCliente], [TipoConsumo], [EstadoPedido], [Monto]) VALUES (CAST(49 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(123456 AS Numeric(18, 0)), N'Insitu', N'Listo', CAST(400.00 AS Numeric(18, 2)))
INSERT [dbo].[Pedido] ([Id], [IdEmpleado], [DniCliente], [TipoConsumo], [EstadoPedido], [Monto]) VALUES (CAST(56 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(123456 AS Numeric(18, 0)), N'Insitu', N'Listo', CAST(50.00 AS Numeric(18, 2)))
INSERT [dbo].[Pedido] ([Id], [IdEmpleado], [DniCliente], [TipoConsumo], [EstadoPedido], [Monto]) VALUES (CAST(57 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(123456 AS Numeric(18, 0)), N'Insitu', N'Listo', CAST(100.00 AS Numeric(18, 2)))
INSERT [dbo].[Pedido] ([Id], [IdEmpleado], [DniCliente], [TipoConsumo], [EstadoPedido], [Monto]) VALUES (CAST(58 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(123456 AS Numeric(18, 0)), N'Insitu', N'Listo', CAST(50.00 AS Numeric(18, 2)))
INSERT [dbo].[Pedido] ([Id], [IdEmpleado], [DniCliente], [TipoConsumo], [EstadoPedido], [Monto]) VALUES (CAST(68 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(123456 AS Numeric(18, 0)), N'Delivery', N'Preparando', CAST(150.00 AS Numeric(18, 2)))
INSERT [dbo].[Pedido] ([Id], [IdEmpleado], [DniCliente], [TipoConsumo], [EstadoPedido], [Monto]) VALUES (CAST(69 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(123456 AS Numeric(18, 0)), N'Delivery', N'Preparando', CAST(50.00 AS Numeric(18, 2)))
INSERT [dbo].[Pedido] ([Id], [IdEmpleado], [DniCliente], [TipoConsumo], [EstadoPedido], [Monto]) VALUES (CAST(50 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(123456 AS Numeric(18, 0)), N'Insitu', N'Listo', CAST(50.00 AS Numeric(18, 2)))
INSERT [dbo].[Pedido] ([Id], [IdEmpleado], [DniCliente], [TipoConsumo], [EstadoPedido], [Monto]) VALUES (CAST(53 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(123456 AS Numeric(18, 0)), N'Insitu', N'Listo', CAST(500.50 AS Numeric(18, 2)))
INSERT [dbo].[Pedido] ([Id], [IdEmpleado], [DniCliente], [TipoConsumo], [EstadoPedido], [Monto]) VALUES (CAST(54 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(123456 AS Numeric(18, 0)), N'Insitu', N'Listo', CAST(100.00 AS Numeric(18, 2)))
INSERT [dbo].[Pedido] ([Id], [IdEmpleado], [DniCliente], [TipoConsumo], [EstadoPedido], [Monto]) VALUES (CAST(55 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(123456 AS Numeric(18, 0)), N'Insitu', N'Listo', CAST(100.00 AS Numeric(18, 2)))
INSERT [dbo].[Pedido] ([Id], [IdEmpleado], [DniCliente], [TipoConsumo], [EstadoPedido], [Monto]) VALUES (CAST(59 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(123456 AS Numeric(18, 0)), N'Insitu', N'Listo', CAST(100.00 AS Numeric(18, 2)))
INSERT [dbo].[Pedido] ([Id], [IdEmpleado], [DniCliente], [TipoConsumo], [EstadoPedido], [Monto]) VALUES (CAST(60 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(123456 AS Numeric(18, 0)), N'Insitu', N'Listo', CAST(50.00 AS Numeric(18, 2)))
INSERT [dbo].[Pedido] ([Id], [IdEmpleado], [DniCliente], [TipoConsumo], [EstadoPedido], [Monto]) VALUES (CAST(61 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(123456 AS Numeric(18, 0)), N'Insitu', N'Listo', CAST(150.00 AS Numeric(18, 2)))
INSERT [dbo].[Pedido] ([Id], [IdEmpleado], [DniCliente], [TipoConsumo], [EstadoPedido], [Monto]) VALUES (CAST(62 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(123456 AS Numeric(18, 0)), N'Insitu', N'Listo', CAST(100.00 AS Numeric(18, 2)))
INSERT [dbo].[Pedido] ([Id], [IdEmpleado], [DniCliente], [TipoConsumo], [EstadoPedido], [Monto]) VALUES (CAST(63 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(123456 AS Numeric(18, 0)), N'Insitu', N'Listo', CAST(150.00 AS Numeric(18, 2)))
INSERT [dbo].[Pedido] ([Id], [IdEmpleado], [DniCliente], [TipoConsumo], [EstadoPedido], [Monto]) VALUES (CAST(64 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(123456 AS Numeric(18, 0)), N'Insitu', N'Listo', CAST(50.00 AS Numeric(18, 2)))
INSERT [dbo].[Pedido] ([Id], [IdEmpleado], [DniCliente], [TipoConsumo], [EstadoPedido], [Monto]) VALUES (CAST(67 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(123456 AS Numeric(18, 0)), N'Delivery', N'Preparando', CAST(100.00 AS Numeric(18, 2)))
INSERT [dbo].[Pedido] ([Id], [IdEmpleado], [DniCliente], [TipoConsumo], [EstadoPedido], [Monto]) VALUES (CAST(51 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(123456 AS Numeric(18, 0)), N'Insitu', N'Listo', CAST(100.00 AS Numeric(18, 2)))
INSERT [dbo].[Pedido] ([Id], [IdEmpleado], [DniCliente], [TipoConsumo], [EstadoPedido], [Monto]) VALUES (CAST(52 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(123456 AS Numeric(18, 0)), N'Insitu', N'Listo', CAST(200.50 AS Numeric(18, 2)))
INSERT [dbo].[Pedido] ([Id], [IdEmpleado], [DniCliente], [TipoConsumo], [EstadoPedido], [Monto]) VALUES (CAST(65 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(123456 AS Numeric(18, 0)), N'Insitu', N'Preparando', CAST(150.50 AS Numeric(18, 2)))
INSERT [dbo].[Pedido] ([Id], [IdEmpleado], [DniCliente], [TipoConsumo], [EstadoPedido], [Monto]) VALUES (CAST(66 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(123456 AS Numeric(18, 0)), N'Insitu', N'Preparando', CAST(0.00 AS Numeric(18, 2)))
SET IDENTITY_INSERT [dbo].[Pedido] OFF
GO
SET IDENTITY_INSERT [dbo].[Producto] ON 

INSERT [dbo].[Producto] ([Id], [Nombre], [Marca], [Tipo], [Stock], [Precio]) VALUES (CAST(1 AS Numeric(18, 0)), N'Hamburguesa doble', N'Propia', N'Cocina', CAST(97 AS Numeric(18, 0)), CAST(250.00 AS Decimal(19, 2)))
INSERT [dbo].[Producto] ([Id], [Nombre], [Marca], [Tipo], [Stock], [Precio]) VALUES (CAST(2 AS Numeric(18, 0)), N'Hamburguesa simple', N'Propia', N'Cocina', CAST(83 AS Numeric(18, 0)), CAST(150.50 AS Decimal(19, 2)))
INSERT [dbo].[Producto] ([Id], [Nombre], [Marca], [Tipo], [Stock], [Precio]) VALUES (CAST(3 AS Numeric(18, 0)), N'Hamburguesa con queso', N'Propia', N'Cocina', CAST(88 AS Numeric(18, 0)), CAST(200.50 AS Decimal(19, 2)))
INSERT [dbo].[Producto] ([Id], [Nombre], [Marca], [Tipo], [Stock], [Precio]) VALUES (CAST(4 AS Numeric(18, 0)), N'Papas fritas', N'Propia', N'Cocina', CAST(79 AS Numeric(18, 0)), CAST(50.00 AS Decimal(19, 2)))
INSERT [dbo].[Producto] ([Id], [Nombre], [Marca], [Tipo], [Stock], [Precio]) VALUES (CAST(5 AS Numeric(18, 0)), N'Ensalada Cesar', N'Propia', N'Cocina', CAST(84 AS Numeric(18, 0)), CAST(100.00 AS Decimal(19, 2)))
SET IDENTITY_INSERT [dbo].[Producto] OFF
GO
USE [master]
GO
ALTER DATABASE [Restaurant] SET  READ_WRITE 
GO
