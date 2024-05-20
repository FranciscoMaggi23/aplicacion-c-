CREATE DATABASE NAILSDB;

GO

CREATE TABLE PRECIOFINALSERVICIO(
    Id int IDENTITY(1,1) NOT NULL,
    Servicio VARCHAR(150) NULL,
    Precio DECIMAL(10, 2) NULL,
	CONSTRAINT [PK_PRECIOFINALSERVICIO] PRIMARY KEY CLUSTERED 
(
	Id ASC
)
)

GO
ALTER TABLE PRECIOFINALSERVICIO
ADD PrecioFinal int Null;

ALTER TABLE PRECIOFINALSERVICIO ALTER COLUMN PrecioFinal decimal;



CREATE TABLE MOVILIARIO(
    Id INT IDENTITY(1,1) NOT NULL,
    Producto VARCHAR(150) NULL,
    Precio DECIMAL(10, 2) NULL,
    Rinde INT NULL,
    Total INT NULL,
	CONSTRAINT [PK_MOVILIARIO] PRIMARY KEY CLUSTERED 
(
	Id ASC
)
)

GO

CREATE TABLE MATERIALES(
    Id INT IDENTITY(1,1) NOT NULL,
    Producto VARCHAR(150) NULL,
    Precio DECIMAL(10, 2) NULL,
    Rinde INT NULL,
    Total INT NULL,
	CONSTRAINT [PK_MATERIALES] PRIMARY KEY CLUSTERED 
(
	Id ASC
)
)

GO

CREATE TABLE TIEMPOSERVICIO(
    Id INT IDENTITY(1,1) NOT NULL,
    Servicio VARCHAR(150) NULL,
    PrecioHora DECIMAL(10, 2) NULL,
    Hora INT NULL,
	CONSTRAINT [PK_TIEMPOSERVICIO] PRIMARY KEY CLUSTERED 
(
	Id ASC
)
)
ALTER TABLE TIEMPOSERVICIO
ADD Total AS ROUND((PrecioHora * Hora), 2);

GO

CREATE TABLE PERIODO(
    Id INT IDENTITY(1,1) NOT NULL,
    Mes VARCHAR(50) NULL,
    HorasDia INT NULL,
    HorasSemana INT NULL,
    TotalMes INT NULL,
	CONSTRAINT [PK_PERIODO] PRIMARY KEY CLUSTERED 
(
	Id ASC
)
)

GO

CREATE TABLE GASTOS(
    Id INT IDENTITY(1,1) NOT NULL,
    GastoFijoServicio INT NULL,
    HoraTrabajo INT NULL,
    TotalGastoVariable INT NULL,
	CONSTRAINT [PK_GASTOS] PRIMARY KEY CLUSTERED 
(
	Id ASC
)
)

GO

CREATE TABLE MATERIALESADICIONALES(
    Id INT IDENTITY(1,1) NOT NULL,
    Producto VARCHAR(150) NULL,
    Precio DECIMAL(10, 2) NULL,
    Cantidad INT NULL,
    PrecioUnidad INT  NULL,
	CONSTRAINT [PK_MATERIALESADICIONALES] PRIMARY KEY CLUSTERED 
(
	Id ASC
)
)
GO

CREATE TABLE CLIENTES(
	Id int IDENTITY(1,1) NOT NULL,
	Nombre varchar(150) NULL,
	Apellido varchar(150) NULL,
	Correo varchar(150) NULL,
	Edad int NULL,
	Telefono int NULL,
	IdServicio int NULL,
	Servicio varchar(150) NULL,
	Estado bit,
	CONSTRAINT [PK_CLIENTES] PRIMARY KEY CLUSTERED 
(
	Id ASC
)

)

go

create table CATEGORIA(
	Id int identity(1,1)NOT NULL,
	Descripcion varchar(150)NULL,
	Estado bit NULL,
	FechaRegistro datetime default getdate() NULL,
	CONSTRAINT [PK_CATEGORIA] PRIMARY KEY CLUSTERED 
(
	Id ASC
)
)

create table PRODUCTO(
	Id int identity(1,1) NOT NULL,
	Codigo varchar(50) NULL,
	Nombre varchar(150) NULL,
	Descripcion varchar(150) NULL,
	Stock int not null default 0,
	PrecioCompra decimal(10,2) default 0,
	Estado bit NULL,
	Fecha datetime default getdate()
	CONSTRAINT [PK_PRODUCTO] PRIMARY KEY CLUSTERED 
(
	Id ASC
)
)
ALTER TABLE PRODUCTO
ADD IdCategoria int null;

select Id, Nombre, Apellido, Correo,Edad,Telefono, Servicio from CLIENTES 


--insert into TIEMPOSERVICIO values ('kapping', 1000,5)

INSERT INTO PRODUCTO(Codigo,Nombre,Descripcion, Stock, PrecioCompra, Estado)
VALUES ('12', 'uñas', 'raras', 22, 123.21,1);

ALTER TABLE PRODUCTO
DROP COLUMN IdCategoria;
select Id, Codigo, Nombre, Descripcion, Stock, PrecioCompra ,Estado from PRODUCTO where Estado = 1
select Fecha from PRODUCTO

update PRODUCTO set Codigo=1, Nombre = 'valen', Descripcion ='pato', Stock = 1, PrecioCompra =1, Estado =0 where Id = 2

update PRODUCTO set Estado = 1 where Estado=0
--otras funciones
--ALTER TABLE PRECIOFINALSERVICIO DROP COLUMN IdPrecioServicio;










