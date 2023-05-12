--								Script de creación de tablas
-- Creacicón de tabla Autor:
CREATE TABLE Autor (
    id_autor int IDENTITY(10001,1) NOT NULL,
	nombre varchar(100) NOT NULL,
	apellido varchar(100) NOT NULL,
	id_tipo_docto [int] NOT NULL,
	num_docto int NOT NULL,
	fec_nacimiento date NOT NULL
);

-- Creacicón de tabla Libro:
CREATE TABLE Libro (
    id_libro int IDENTITY(20001,1) NOT NULL,
	titulo varchar(100) NOT NULL,
	id_editorial int NOT NULL,
	num_paginas int NOT NULL,
	fec_publicacion datetime NOT NULL,
	id_autor int NOT NULL,   
);

-- Creacicón de tabla Tipo_Docto:
CREATE TABLE Tipo_Docto (
    id_tipo_docto int IDENTITY(1,1) NOT NULL,
	nombre varchar(50) NOT NULL, 
);

-- Creacicón de tabla Editorial:
CREATE TABLE Editorial (
    id_libro int IDENTITY(20001,1) NOT NULL,
	titulo varchar(100) NOT NULL,
	id_editorial int NOT NULL,
	num_paginas int NOT NULL,
	fec_publicacion date NOT NULL,
	id_autor int NOT NULL,  
);

-- Relaciones definidas:
-- Autor 1:N (1 a muchos) Libro
-- Tipo_Docto 1:N (1 a muchos) Autor
-- Editorial 1:N (1 a muchos) Libro
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



