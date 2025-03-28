CREATE DATABASE PharmaDB;
GO

USE PharmaDB;
GO

/*
-- Dropar as tabelas na ordem certa
DROP TABLE IF EXISTS ItensPedido;
DROP TABLE IF EXISTS Pedidos;
DROP TABLE IF EXISTS Clientes;
DROP TABLE IF EXISTS ComposicaoMedicamentos;
DROP TABLE IF EXISTS Fornecedores;
DROP TABLE IF EXISTS MateriasPrimas;
DROP TABLE IF EXISTS Medicamentos;
*/


CREATE TABLE MateriasPrimas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome NVARCHAR(255) NOT NULL,
    Descricao NVARCHAR(500),    
    QuantidadeEmEstoque INT NOT NULL,
    DataValidade DATE NOT NULL,
);

-- Criação da tabela de Medicamentos
CREATE TABLE Medicamentos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome NVARCHAR(255) NOT NULL,
    Descricao NVARCHAR(500),
    Preco DECIMAL(18,2) NOT NULL,
    QuantidadeEmEstoque INT NOT NULL
);

-- Tabela de relacionamento entre Medicamentos e Matérias-Primas
CREATE TABLE ComposicaoMedicamentos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    MedicamentoId INT NOT NULL,
    MateriaPrimaId INT NOT NULL,
    QuantidadeUtilizada INT NOT NULL,
    FOREIGN KEY (MedicamentoId) REFERENCES Medicamentos(Id) ON DELETE CASCADE,
    FOREIGN KEY (MateriaPrimaId) REFERENCES MateriasPrimas(Id) ON DELETE CASCADE
);

-- Criação da tabela de Clientes
CREATE TABLE Clientes (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome NVARCHAR(255) NOT NULL,
    CPF CHAR(11) UNIQUE NOT NULL,
    Endereco NVARCHAR(500) NOT NULL,
    Telefone NVARCHAR(20) NOT NULL,
    Email NVARCHAR(255) UNIQUE NOT NULL
);

-- Criação da tabela de Pedidos
CREATE TABLE Pedidos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ClienteId INT NOT NULL,
    DataPedido DATETIME DEFAULT GETDATE(),
    ValorTotal DECIMAL(18,2) NOT NULL,
    FOREIGN KEY (ClienteId) REFERENCES Clientes(Id) ON DELETE CASCADE
);

-- Tabela de relacionamento entre Pedidos e Medicamentos
CREATE TABLE ItensPedido (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    PedidoId INT NOT NULL,
    MedicamentoId INT NOT NULL,
    Quantidade INT NOT NULL,
    PrecoUnitario DECIMAL(18,2) NOT NULL,
    FOREIGN KEY (PedidoId) REFERENCES Pedidos(Id) ON DELETE CASCADE,
    FOREIGN KEY (MedicamentoId) REFERENCES Medicamentos(Id) ON DELETE CASCADE
);