USE [master]
GO
/****** Object:  Database [db_App_Poli]    Script Date: 11/05/2023 23:26:09 ******/
CREATE DATABASE [db_App_Poli]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'db_App_Poli', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\db_App_Poli.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'db_App_Poli_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\db_App_Poli_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [db_App_Poli] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [db_App_Poli].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [db_App_Poli] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [db_App_Poli] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [db_App_Poli] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [db_App_Poli] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [db_App_Poli] SET ARITHABORT OFF 
GO
ALTER DATABASE [db_App_Poli] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [db_App_Poli] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [db_App_Poli] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [db_App_Poli] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [db_App_Poli] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [db_App_Poli] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [db_App_Poli] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [db_App_Poli] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [db_App_Poli] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [db_App_Poli] SET  DISABLE_BROKER 
GO
ALTER DATABASE [db_App_Poli] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [db_App_Poli] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [db_App_Poli] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [db_App_Poli] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [db_App_Poli] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [db_App_Poli] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [db_App_Poli] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [db_App_Poli] SET RECOVERY FULL 
GO
ALTER DATABASE [db_App_Poli] SET  MULTI_USER 
GO
ALTER DATABASE [db_App_Poli] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [db_App_Poli] SET DB_CHAINING OFF 
GO
ALTER DATABASE [db_App_Poli] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [db_App_Poli] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [db_App_Poli] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [db_App_Poli] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'db_App_Poli', N'ON'
GO
ALTER DATABASE [db_App_Poli] SET QUERY_STORE = OFF
GO
USE [db_App_Poli]
GO
/****** Object:  Table [dbo].[Autor]    Script Date: 11/05/2023 23:26:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Autor](
	[id_autor] [int] IDENTITY(10001,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[apellido] [varchar](100) NOT NULL,
	[id_tipo_docto] [int] NOT NULL,
	[num_docto] [int] NOT NULL,
	[fec_nacimiento] [date] NOT NULL,
 CONSTRAINT [PK_Autor] PRIMARY KEY CLUSTERED 
(
	[id_autor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Editorial]    Script Date: 11/05/2023 23:26:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Editorial](
	[id_editorial] [int] IDENTITY(30001,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Editorial] PRIMARY KEY CLUSTERED 
(
	[id_editorial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Libro]    Script Date: 11/05/2023 23:26:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Libro](
	[id_libro] [int] IDENTITY(20001,1) NOT NULL,
	[titulo] [varchar](100) NOT NULL,
	[id_editorial] [int] NOT NULL,
	[num_paginas] [int] NOT NULL,
	[fec_publicacion] [datetime] NOT NULL,
	[id_autor] [int] NOT NULL,
 CONSTRAINT [PK_Libro] PRIMARY KEY CLUSTERED 
(
	[id_libro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo_docto]    Script Date: 11/05/2023 23:26:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_docto](
	[id_tipo_docto] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Tipo_docto] PRIMARY KEY CLUSTERED 
(
	[id_tipo_docto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Autor]  WITH CHECK ADD  CONSTRAINT [FK_Autor_Tipo_docto] FOREIGN KEY([id_tipo_docto])
REFERENCES [dbo].[Tipo_docto] ([id_tipo_docto])
GO
ALTER TABLE [dbo].[Autor] CHECK CONSTRAINT [FK_Autor_Tipo_docto]
GO
ALTER TABLE [dbo].[Libro]  WITH CHECK ADD  CONSTRAINT [FK_Libro_Autor] FOREIGN KEY([id_autor])
REFERENCES [dbo].[Autor] ([id_autor])
GO
ALTER TABLE [dbo].[Libro] CHECK CONSTRAINT [FK_Libro_Autor]
GO
ALTER TABLE [dbo].[Libro]  WITH CHECK ADD  CONSTRAINT [FK_Libro_Editorial] FOREIGN KEY([id_editorial])
REFERENCES [dbo].[Editorial] ([id_editorial])
GO
ALTER TABLE [dbo].[Libro] CHECK CONSTRAINT [FK_Libro_Editorial]
GO
USE [master]
GO
ALTER DATABASE [db_App_Poli] SET  READ_WRITE 
GO

-- Inserciones necesarias para las tablas base:
-- Tipo_docto
-- Editorial
INSERT INTO Tipo_docto (nombre) VALUES ('Cédula de ciudadanía')
INSERT INTO Tipo_docto (nombre) VALUES ('NIT')
INSERT INTO Tipo_docto (nombre) VALUES ('Cédula de extranjería')
GO
INSERT INTO Editorial (nombre) VALUES ('Babel Libros')
INSERT INTO Editorial (nombre) VALUES ('Carvajal Ediciones')
INSERT INTO Editorial (nombre) VALUES ('Cooperativa Editorial Magisterio')
INSERT INTO Editorial (nombre) VALUES ('Ediciones SM')
INSERT INTO Editorial (nombre) VALUES ('Editorial Gato Malo')