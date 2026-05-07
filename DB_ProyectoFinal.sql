CREATE DATABASE db_reservas;
GO
USE db_reservas;
GO


CREATE TABLE [Usuarios] (
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [Nombre] NVARCHAR(100) NOT NULL,
    [Apellido] NVARCHAR(100) NOT NULL,
    [Email] NVARCHAR(150) NOT NULL UNIQUE,
    [Telefono] NVARCHAR(20) NULL,
    [Contrasena]  NVARCHAR(255) NOT NULL,
);



CREATE TABLE [Administradores] (
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [Usuario] INT NOT NULL REFERENCES [Usuarios]([Id]),
    [Cargo] NVARCHAR(100) NOT NULL,
);



CREATE TABLE [Apartamentos] (
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [NumeroApartamento] NVARCHAR(20) NOT NULL,
    [Piso] INT NOT NULL,
    [Torre] NVARCHAR(50) NOT NULL,
    [TieneParqueadero] BIT NOT NULL DEFAULT 0,
);



CREATE TABLE [Residentes] (
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [Cedula] NVARCHAR(20) NOT NULL UNIQUE,
    [Usuario] INT NOT NULL REFERENCES [Usuarios]([Id]),
    [TipoResidente]   NVARCHAR(50)    NOT NULL,
    [Activo] BIT NOT NULL DEFAULT 1,

);



CREATE TABLE [ResidenteApartamentos] (
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [ResidenteId] INT NOT NULL REFERENCES [Residentes]([Id]),
    [ApartamentoId] INT NOT NULL REFERENCES [Apartamentos]([Id]),
    [EsPropietario] BIT NOT NULL DEFAULT 0,

);



CREATE TABLE [ZonasComunes] (
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [Nombre] NVARCHAR(100) NOT NULL,
    [Descripcion] NVARCHAR(500) NULL,
    [CapacidadMaxima] INT NOT NULL,
    [Disponible] BIT NOT NULL DEFAULT 1,
);



CREATE TABLE [Tarifas] (
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [ZonaComun] INT NOT NULL REFERENCES [ZonasComunes]([Id]),
    [PrecioPorHora] DECIMAL(18,2)   NOT NULL,
    [Activa] BIT NOT NULL DEFAULT 1,
);



CREATE TABLE [EstadosReserva] (
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [Nombre] NVARCHAR(100) NOT NULL,
    [Descripcion] NVARCHAR(500) NULL,
);



CREATE TABLE [Reservas] (
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [Residente] INT NOT NULL REFERENCES [Residentes]([Id]),
    [ZonaComun] INT NOT NULL REFERENCES [ZonasComunes]([Id]),
    [FechaInicio] DATETIME NOT NULL,
    [FechaFin] DATETIME NOT NULL,
    [TieneCosto] BIT NOT NULL DEFAULT 0,
    [EstadoReserva] INT NOT NULL REFERENCES [EstadosReserva]([Id]),
);



CREATE TABLE [Sanciones] (
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [ResidenteId] INT NOT NULL REFERENCES [Residentes]([Id]),
    [ReservaId] INT NULL REFERENCES [Reservas]([Id]),
    [Motivo] NVARCHAR(500) NOT NULL,
    [Valor] DECIMAL(18,2) NOT NULL,
    [Pagada] BIT NOT NULL DEFAULT 0,
    [FechaSancion] DATETIME NOT NULL DEFAULT GETDATE(),
	);


CREATE TABLE [Pagos] (
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [IdReserva] INT NOT NULL REFERENCES [Reservas]([Id]),
    [MetodoPago] NVARCHAR(50) NOT NULL,
    [Monto] DECIMAL(18,2)   NOT NULL,
    [EstadoPago] NVARCHAR(50) NOT NULL,
	[FechaPago] DATETIME NOT NULL DEFAULT GETDATE(),
);



CREATE TABLE [Facturas] (
    [Id]             INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [NumeroFactura]  NVARCHAR(50) NOT NULL UNIQUE,
    [PagoId]         INT NOT NULL REFERENCES [Pagos]([Id]),  
    [ResidenteId]    INT NOT NULL REFERENCES [Residentes]([Id]),
    [Total]          DECIMAL(18,2) NOT NULL,
    [Descripcion]    NVARCHAR(500) NULL,
    [FechaEmision]   DATETIME NOT NULL DEFAULT GETDATE()
);



CREATE TABLE [MesaPingPong] (
	[IdMesaPingPong] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [IdZonaComun]  INT NOT NULL REFERENCES [ZonasComunes]([Id]),
    [NumeroDeMesa] NVARCHAR(20) NOT NULL,
    [EstadoMesa] NVARCHAR(50) NOT NULL,
    [PaletasIncluidas] BIT NOT NULL DEFAULT 0,
    [RedesIncluidas] BIT NOT NULL DEFAULT 0,
    [Ubicacion] NVARCHAR(200) NULL,
);


CREATE TABLE [SalonesComunales] (
	[IdSalonesComunales] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [IdZonaComun] INT NOT NULL REFERENCES [ZonasComunes]([Id]),
    [CapacidadPersonas] NVARCHAR(20) NOT NULL,
    [NumeroDeSalon] NVARCHAR(20) NOT NULL,
    [TieneCocina]  BIT NOT NULL DEFAULT 0,
    [TieneVideoBeam] BIT NOT NULL DEFAULT 0,
    [TieneSonido] BIT NOT NULL DEFAULT 0,
);



CREATE TABLE [ZonaBBQ] (
	[IdZonaBBQ] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [IdZonaComun]  INT NOT NULL REFERENCES [ZonasComunes]([Id]),
    [NumeroParrillas] NVARCHAR(20) NOT NULL,
    [CapacidadSillas] NVARCHAR(20) NOT NULL,
    [CantidadDeUtensilios] INT NOT NULL DEFAULT 0,
    [CarbonIncluido] BIT NOT NULL DEFAULT 0,
);



CREATE TABLE [MesaDeBillar](
	[IdMesaDeBillar] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [IdZonaComun]  INT NOT NULL REFERENCES [ZonasComunes]([Id]),
    [EstadoMesa] NVARCHAR(50) NOT NULL,
    [NumeroDeMesa] NVARCHAR(20) NOT NULL,
    [TipoMesa] NVARCHAR(50) NOT NULL,
    [CantidadDeBolas] INT NOT NULL DEFAULT 0,
    [TacosIncluidos] BIT NOT NULL DEFAULT 0,
);



CREATE TABLE [Cooworking](
	[IdCooworking] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [IdZonaComun]  INT NOT NULL REFERENCES [ZonasComunes]([Id]),
    [CantPuestosDeTrabajo] INT NOT NULL DEFAULT 0,
    [TieneInternet]  BIT NOT NULL DEFAULT 0,
    [TieneAireAcondicionado]  BIT NOT NULL DEFAULT 0,
    [TieneImpresora] BIT NOT NULL DEFAULT 0,
    [TieneLockers] BIT NOT NULL DEFAULT 0,
);



CREATE TABLE [CanchaSintetica](
	[IdCanchaSintetica] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [IdZonaComun]  INT NOT NULL REFERENCES [ZonasComunes]([Id]),
    [TiempoMaximoUso] INT NOT NULL,
    [CapacidadJugadores] INT NOT NULL,
    [EstadoCancha] NVARCHAR(50) NOT NULL,
    [RequiereFirma] BIT NOT NULL DEFAULT 0,
    [TieneIluminacion] BIT NOT NULL DEFAULT 0,
    [TieneGradas] BIT NOT NULL DEFAULT 0,

);



CREATE TABLE [CanchaBaloncesto] (
	[IdCanchaBaloncesto] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [IdZonaComun]  INT NOT NULL REFERENCES [ZonasComunes]([Id]),
    [TiempoMaximoUso] INT NOT NULL,
    [EstadoTablero] NVARCHAR(50) NOT NULL,
    [RequiereFirma] BIT NOT NULL DEFAULT 0,
    [EsTechada] BIT NOT NULL DEFAULT 0,
    [NumeroAros] INT NOT NULL DEFAULT 2,

);



CREATE TABLE [CanchaMicro](
	[IdCanchaMicro] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [IdZonaComun]  INT NOT NULL REFERENCES [ZonasComunes]([Id]),
    [TiempoMaximoUso] INT NOT NULL,
    [CapacidadJugadores] INT NOT NULL,
    [EstadoCancha] NVARCHAR(50) NOT NULL,
    [RequiereFirma] BIT NOT NULL DEFAULT 0,
    [TieneIluminacion] BIT NOT NULL DEFAULT 0,
    [TieneVestuario] BIT NOT NULL DEFAULT 0,

);