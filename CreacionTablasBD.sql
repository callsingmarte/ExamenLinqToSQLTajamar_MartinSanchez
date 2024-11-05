--Author Martin Sanchez
-- 1. Base de datos
CREATE DATABASE GestionCursosDB;
GO
USE GestionCursosDB;
GO
CREATE TABLE Usuarios(
	UsuarioID INT IDENTITY(1,1) PRIMARY KEY,
	Nombre NVARCHAR(50) NOT NULL,
	Correo NVARCHAR(50) UNIQUE NOT NULL,
	Contrasena NVARCHAR(50) NOT NULL,
	Rol NVARCHAR(20)
);
GO
CREATE TABLE Cursos(
	CursoID INT IDENTITY(1,1) PRIMARY KEY,
	Titulo NVARCHAR(100) NOT NULL,
	Descripcion NVARCHAR(255),
	FechaInicio DATE,
	Duracion INT
);
GO
CREATE TABLE Inscripciones(
	InscripcionID INT IDENTITY(1,1) PRIMARY KEY,
	UsuarioID INT,
	CursoID INT,
	FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID),
	FOREIGN KEY (CursoID) REFERENCES Cursos(CursoID)
);
GO

INSERT INTO Usuarios (Nombre, Correo, Contrasena, Rol)
VALUES 
	('Martin Sanchez','martin@gmail.com','1234','Admin'),
	('Pablo Gonzalez', 'pablo.gonzalez@gmail.com', '123', 'Usuario'),
    ('Juan Perez', 'juan.perez@gmail.com', 'pass1234', 'Usuario'),
    ('Maria Gonzalez', 'maria.gonzalez@gmail.com', 'maria123', 'Usuario'),
    ('Carlos Lopez', 'carlos.lopez@gmail.com', 'carlos789', 'Usuario'),
    ('Ana Torres', 'ana.torres@gmail.com', 'ana456', 'Usuario'),
    ('Luis Sanchez', 'luis.sanchez@gmail.com', 'luis000', 'Usuario'),
    ('Elena Ramirez', 'elena.ramirez@gmail.com', 'elena111', 'Usuario');

GO

INSERT INTO Cursos (Titulo, Descripcion, FechaInicio, Duracion)
VALUES 
    ('Curso de SQL Básico', 'Introducción a las consultas SQL y bases de datos.', '2024-01-10', 30),
    ('Desarrollo Web con HTML y CSS', 'Curso sobre fundamentos de diseño web.', '2024-02-15', 45),
    ('Python para Principiantes', 'Aprende los conceptos básicos de programación con Python.', '2024-03-01', 60),
    ('JavaScript Intermedio', 'Desarrollo de habilidades avanzadas en JavaScript.', '2024-04-05', 40),
    ('Administración de Bases de Datos', 'Curso avanzado de administración y optimización de bases de datos.', '2024-05-20', 50),
    ('Ciberseguridad', 'Curso de ciberseguridad.', '2024-08-10', 250);
GO

INSERT INTO Inscripciones (UsuarioID, CursoID)
VALUES 
    (3, 1),  -- Juan Perez inscrito en Curso de SQL Básico
    (4, 1),  -- Maria Gonzalez inscrita en Curso de SQL Básico
    (6, 3),  -- Ana Torres inscrita en Python para Principiantes
    (7, 4),  -- Luis Sanchez inscrito en JavaScript Intermedio
    (5, 1),  -- Carlos Lopez inscrito en Curso de SQL Básico
    (8, 2);  -- Elena Ramirez inscrita en Desarrollo Web con HTML y CSS
