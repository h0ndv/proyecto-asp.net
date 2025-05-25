-- Crear base de datos
CREATE DATABASE bdSqlServer;
GO

USE bdSqlServer;
GO

-- Tabla de cargos
CREATE TABLE Cargos (
  IdCargo INT IDENTITY(1,1) PRIMARY KEY,
  Cargo VARCHAR(50) NOT NULL,
  Descripcion VARCHAR(50) NOT NULL
);

-- Tabla de usuarios
CREATE TABLE Usuarios (
  IdUsuario INT IDENTITY(1,1) PRIMARY KEY,
  IdCargo INT NOT NULL,
  Usuario VARCHAR(50) NOT NULL,
  Contrasena VARCHAR(50) NOT NULL
);

-- Tabla de clientes
CREATE TABLE Cliente (
  IdCliente INT IDENTITY(1,1) PRIMARY KEY,
  Nombre VARCHAR(50) NOT NULL,
  Apellido VARCHAR(50) NOT NULL,
  Telefono VARCHAR(50) NOT NULL
);

-- Tabla de categorias de productos
CREATE TABLE CategoriaProductos (
  IdCategoria INT IDENTITY(1,1) PRIMARY KEY,
  Nombre VARCHAR(50) NOT NULL
);

-- Tabla de productos
CREATE TABLE Productos (
  IdProducto INT IDENTITY(1,1) PRIMARY KEY,
  IdCategoria INT NOT NULL,
  Nombre VARCHAR(50) NOT NULL,
  Cantidad INT NOT NULL,
  Precio INT NOT NULL
);

-- Tabla de ventas
CREATE TABLE Ventas (
  IdVenta INT IDENTITY(1,1) PRIMARY KEY,
  IdUsuario INT NOT NULL,
  Fecha DATE NOT NULL,
  Total INT NOT NULL,
  TipoCompra VARCHAR(50) NOT NULL
);

-- Tabla de detalle de ventas
CREATE TABLE DetalleVentas (
  IdDetVenta INT IDENTITY(1,1) PRIMARY KEY,
  IdVenta INT NOT NULL,
  IdProductos INT NOT NULL,
  Cantidad INT NOT NULL,
  Precio INT NOT NULL,
  Total INT NOT NULL
);

-- CLAVES FORANEAS

ALTER TABLE Productos
ADD CONSTRAINT FK_Producto_Categoria 
FOREIGN KEY (IdCategoria) REFERENCES CategoriaProductos(IdCategoria);

ALTER TABLE Usuarios
ADD CONSTRAINT FK_Usuario_Cargo 
FOREIGN KEY (IdCargo) REFERENCES Cargos(IdCargo);

ALTER TABLE DetalleVentas
ADD CONSTRAINT FK_DetalleVenta_Venta 
FOREIGN KEY (IdVenta) REFERENCES Ventas(IdVenta);

ALTER TABLE DetalleVentas
ADD CONSTRAINT FK_DetalleVenta_Producto 
FOREIGN KEY (IdProductos) REFERENCES Productos(IdProducto);

ALTER TABLE Ventas
ADD CONSTRAINT FK_Venta_Usuario 
FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario);

-- Insertar datos de ejemplo

INSERT INTO Cargos (Cargo, Descripcion) VALUES
('Administrador', 'Administrador del sistema'),
('Vendedor', 'Vendedor de productos'),
('Bodega', 'Encargado de bodega');

INSERT INTO Usuarios (IdCargo, Usuario, Contrasena) VALUES
(1, 'Administrador', '1234'),
(2, 'Vendedor', '1234'),
(3, 'Bodeguero', '1234');

INSERT INTO Cliente (Nombre, Apellido, Telefono) VALUES
('Cliente', 'Cliente', '123456789');

INSERT INTO CategoriaProductos (Nombre) VALUES
('Procesador'),
('Placa Madre'),
('Memoria RAM'),
('Fuente de Poder'),
('Gabinete');

INSERT INTO Productos (IdCategoria, Nombre, Cantidad, Precio) VALUES
(1, 'Intel Core i7-12700K', 10, 3500000),
(2, 'ASUS ROG STRIX B550-F', 5, 180000),
(3, 'Corsair Vengeance 16GB DDR4', 20, 7550),
(4, 'EVGA 750W 80 Plus Gold', 0, 12000),
(5, 'NZXT H510', 15, 9999);
