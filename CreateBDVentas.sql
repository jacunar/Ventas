Use master;
go

--CREAR BASE DE DATOS
IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'Ventas')
	CREATE DATABASE Ventas;

USE Ventas;
GO

--Tabla categorías
create table Categorias (
       IdCategoria integer primary key identity,
       Nombre varchar(50) not null unique,
       Descripcion varchar(256) null,
       Activo bit default(1)
);
insert into Categorias (Nombre, Descripcion) values ('Cereales','Trigo, arroz, avena, cebada, etc.');


--Tabla artículos
create table Articulos (
       IdArticulo integer primary key identity,
       IdCategoria integer not null,
       Codigo varchar(50) null,
       Nombre varchar(100) not null unique,
	   Costo decimal(11,2) not null,
       PrecioVenta decimal(11,2) not null,
       Stock integer not null,
       Descripcion varchar(256) null,
       Activo bit default(1),
       FOREIGN KEY (IdCategoria) REFERENCES Categorias (IdCategoria)
);

--Tabla personas
create table Personas (
       IdPersona integer primary key identity,
       TipoPersona varchar(20) not null,
       Nombre varchar(100) not null,
       TipoDocumento varchar(20) null,
       NumDocumento varchar(20) null,
       Direccion varchar(200) null,
       Telefono varchar(20) null,
       Email varchar(50) null
);

INSERT INTO Personas(TipoPersona, Nombre) values('Natural', 'Juan Perez');

--Tabla roles
create table Roles (
       IdRol integer primary key identity,
       Nombre varchar(30) not null,
       Descripcion varchar(100) null,
       Activo bit default(1)
);

INSERT INTO Roles(Nombre, Descripcion, Activo) values('Administrador','Rol de Administrador',1);

--Tabla usuarios
create table Usuarios (
       IdUsuario integer primary key identity,
       IdRol integer not null,
       IdPersona integer not null,
	   usuario varchar(50) not null,
       Clave binary(128) not null,
       Activo bit default(1),
       FOREIGN KEY (IdRol) REFERENCES Roles (IdRol),
	   FOREIGN KEY (IdPersona) REFERENCES Personas (IdPersona)
);

INSERT INTO Usuarios(IdRol, IdPersona, usuario, Clave, Activo) values(1, 1, 'admin', HASHBYTES('SHA2_512','admin'), 1);

create table Proveedores (
	IdProveedor integer primary key identity,
	Nombre varchar(50) not null,
	Contacto varchar(200) not null,
	Direccion varchar(200) not null,
	Telefono varchar(20) null,
    Email varchar(50) null,
	Activo bit default(1)
)

--Tabla ingreso
create table Ingresos (
       IdIngreso integer primary key identity,
       IdProveedor integer not null,
       IdUsuario integer not null,
       TipoComprobante varchar(20) not null,
       SerieComprobante varchar(7) null,
       NumComprobante varchar (10) not null,
       Fecha datetime not null,
       Impuesto decimal (4,2) not null,
       Total decimal (11,2) not null,
       Estado varchar(20) not null,
       FOREIGN KEY (IdProveedor) REFERENCES Proveedores (IdProveedor),
       FOREIGN KEY (IdUsuario) REFERENCES Usuarios (IdUsuario)
);

--Tabla detalle_ingreso
create table DetalleIngreso (
       IdDetalleIngreso integer primary key identity,
       IdIngreso integer not null,
       IdArticulo integer not null,
       Cantidad integer not null,
       Precio decimal(11,2) not null,
       FOREIGN KEY (IdIngreso) REFERENCES Ingresos (IdIngreso) ON DELETE CASCADE,
       FOREIGN KEY (IdArticulo) REFERENCES Articulos (IdArticulo)
);


--Tabla venta
create table Ventas (
       IdVenta integer primary key identity,
       IdCliente integer not null,
       IdUsuario integer not null,
       TipoComprobante varchar(20) not null,
       SerieComprobante varchar(7) null,
       NumComprobante varchar (10) not null,
       FechaHora datetime not null,
       Impuesto decimal (4,2) not null,
       Total decimal (11,2) not null,
       Estado varchar(20) not null,
       FOREIGN KEY (IdCliente) REFERENCES Personas (IdPersona),
       FOREIGN KEY (IdUsuario) REFERENCES Usuarios (IdUsuario)
);

--Tabla detalle_venta
create table DetalleVentas (
       IdDetalleVenta integer primary key identity,
       IdVenta integer not null,
       IdArticulo integer not null,
       Cantidad integer not null,
       Precio decimal(11,2) not null,
       Descuento decimal(11,2) not null,
       FOREIGN KEY (IdVenta) REFERENCES Ventas (IdVenta) ON DELETE CASCADE,
       FOREIGN KEY (IdArticulo) REFERENCES Articulos (IdArticulo)
);