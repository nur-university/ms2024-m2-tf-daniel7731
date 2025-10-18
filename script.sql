use appservice;
go
CREATE TABLE TipoAlimento (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(50) NOT NULL
);
CREATE TABLE Unidad (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(50) NOT NULL,
    Simbolo NVARCHAR(10) NOT NULL
);
-- Insert basic units
INSERT INTO Unidad (Nombre, Simbolo)
VALUES
('Gramos', 'g'),
('Kilogramos', 'kg');

INSERT INTO TipoAlimento (Nombre)
VALUES
('Verdura'),
('Fruta'),
('FrutoSeco'),
('CarneRoja'),
('CarneBlanca'),
('Grano'),
('Carbohidrato');
CREATE TABLE Tiempo (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(50) NOT NULL
);

INSERT INTO Tiempo (Nombre)
VALUES
('Breaskfast'),
('HalfMorning'),
('Lunch'),
('HalfAfternoon'),
('Dinner');
CREATE TABLE Paciente (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Apellido NVARCHAR(100) NOT NULL,
    FechaNacimiento DATETIME NOT NULL,
    Email NVARCHAR(150) NULL,
    Telefono NVARCHAR(50) NULL,
    Peso DECIMAL(10,2) NULL,
    Altura DECIMAL(10,2) NULL
);
CREATE TABLE Nutricionista (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    FechaCreacion DATETIME NOT NULL DEFAULT GETDATE(),
    Activo BIT NOT NULL DEFAULT 1
);
CREATE TABLE Categoria (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    TipoAlimentoId INT NOT NULL,
    FOREIGN KEY (TipoAlimentoId) REFERENCES TipoAlimento(Id)
);
CREATE TABLE Ingrediente (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Calorias DECIMAL(10,2) NOT NULL,
    CategoriaId UNIQUEIDENTIFIER NOT NULL,
    UnidadId INT NOT NULL,
    FOREIGN KEY (CategoriaId) REFERENCES Categoria(Id),
    FOREIGN KEY (UnidadId) REFERENCES Unidad(Id)
);

CREATE TABLE Receta (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    Nombre NVARCHAR(150) NOT NULL,
    TiempoId INT NOT NULL,
    CONSTRAINT FK_Receta_Tiempo
        FOREIGN KEY (TiempoId) REFERENCES Tiempo(Id)
);

CREATE TABLE RecetaIngrediente (
    RecetaId UNIQUEIDENTIFIER NOT NULL,
    IngredienteId UNIQUEIDENTIFIER NOT NULL,
    CantidadValor DECIMAL(10,2) NULL,

    CONSTRAINT PK_RecetaIngrediente PRIMARY KEY (RecetaId, IngredienteId),
    CONSTRAINT FK_RecetaIngrediente_Receta
        FOREIGN KEY (RecetaId) REFERENCES Receta(Id) ON DELETE CASCADE,
    CONSTRAINT FK_RecetaIngrediente_Ingrediente
        FOREIGN KEY (IngredienteId) REFERENCES Ingrediente(Id)
);
CREATE TABLE Dieta (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    Nombre NVARCHAR(150) NOT NULL,
    FechaConsumo DATETIME NOT NULL
);

CREATE TABLE DietaReceta (
    DietaId   UNIQUEIDENTIFIER NOT NULL,
    RecetaId  UNIQUEIDENTIFIER NOT NULL,

    -- (Opcional) Orden o secuencia dentro de la dieta
    Orden INT NULL,

    CONSTRAINT PK_DietaReceta PRIMARY KEY (DietaId, RecetaId),
    CONSTRAINT FK_DietaReceta_Dieta
        FOREIGN KEY (DietaId) REFERENCES Dieta(Id) ON DELETE CASCADE,
    CONSTRAINT FK_DietaReceta_Receta
        FOREIGN KEY (RecetaId) REFERENCES Receta(Id)
);
CREATE TABLE PlanAlimentacion (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,

    PacienteId      UNIQUEIDENTIFIER NOT NULL,
    NutricionistaId UNIQUEIDENTIFIER NOT NULL,

    FechaInicio DATETIME NOT NULL,
    FechaFin    DATETIME NOT NULL,

  
    DuracionDias AS DATEDIFF(DAY, FechaInicio, FechaFin) PERSISTED,

    CONSTRAINT FK_PlanAlimentacion_Paciente
        FOREIGN KEY (PacienteId) REFERENCES Paciente(Id),

    CONSTRAINT FK_PlanAlimentacion_Nutricionista
        FOREIGN KEY (NutricionistaId) REFERENCES Nutricionista(Id),

    CONSTRAINT CK_PlanAlimentacion_Duracion
        CHECK (FechaFin > FechaInicio AND DATEDIFF(DAY, FechaInicio, FechaFin) IN (15, 30))
);

CREATE TABLE PlanAlimentacionDieta (
    PlanAlimentacionId UNIQUEIDENTIFIER NOT NULL,
    DietaId            UNIQUEIDENTIFIER NOT NULL, 
    Orden INT NULL,
    FechaProgramada DATE NULL,
    CONSTRAINT PK_PlanAlimentacionDieta PRIMARY KEY (PlanAlimentacionId, DietaId),

    CONSTRAINT FK_PlanAlimentacionDieta_Plan
        FOREIGN KEY (PlanAlimentacionId) REFERENCES PlanAlimentacion(Id) ON DELETE CASCADE,

    CONSTRAINT FK_PlanAlimentacionDieta_Dieta
        FOREIGN KEY (DietaId) REFERENCES Dieta(Id)
);
INSERT INTO Categoria (Id, Nombre, TipoAlimentoId)
VALUES
-- 1. Verdura
(NEWID(), 'Verdura fresca', 1),
(NEWID(), 'Verdura congelada', 1),
(NEWID(), 'Verdura orgánica', 1),
(NEWID(), 'Verdura de hoja verde', 1),
(NEWID(), 'Verdura de raíz', 1),

-- 2. Fruta
(NEWID(), 'Fruta tropical', 2),
(NEWID(), 'Fruta cítrica', 2),
(NEWID(), 'Fruta de estación', 2),
(NEWID(), 'Fruta seca', 2),
(NEWID(), 'Fruta congelada', 2),

-- 3. FrutoSeco
(NEWID(), 'Nueces', 3),
(NEWID(), 'Almendras', 3),
(NEWID(), 'Castañas', 3),
(NEWID(), 'Pistachos', 3),
(NEWID(), 'Maní', 3),

-- 4. CarneRoja
(NEWID(), 'Res', 4),
(NEWID(), 'Cordero', 4),
(NEWID(), 'Cerdo', 4),
(NEWID(), 'Carne molida', 4),
(NEWID(), 'Carne curada', 4),

-- 5. CarneBlanca
(NEWID(), 'Pollo', 5),
(NEWID(), 'Pavo', 5),
(NEWID(), 'Conejo', 5),
(NEWID(), 'Pescado blanco', 5),
(NEWID(), 'Carne de ave', 5),

-- 6. Grano
(NEWID(), 'Arroz', 6),
(NEWID(), 'Trigo', 6),
(NEWID(), 'Avena', 6),
(NEWID(), 'Cebada', 6),
(NEWID(), 'Maíz', 6),

-- 7. Carbohidrato
(NEWID(), 'Pan', 7),
(NEWID(), 'Pasta', 7),
(NEWID(), 'Cereal', 7),
(NEWID(), 'Papa', 7),
(NEWID(), 'Yuca', 7);

ALTER TABLE Ingrediente
ADD CantidadValor decimal not null default 1;