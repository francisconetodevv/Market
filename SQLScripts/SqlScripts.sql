CREATE DATABASE ListaComprasDB;

GO
USE ListaComprasDB;
GO

CREATE TABLE Produtos (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Nome NVARCHAR(100) NOT NULL,
	Categoria NVARCHAR(50) NOT NULL,
	Marca NVARCHAR(50) NOT NULL,
	Descricao NVARCHAR(500),
	PrecoUnitario DECIMAL(10, 2) NOT NULL
);

CREATE TABLE ItensCarrinho(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Quantidade INT NOT NULL,
	ProdutoId INT NOT NULL, 
	FOREIGN KEY (ProdutoId) REFERENCES Produtos(Id) 
);

INSERT INTO Produtos (Nome, Categoria, Marca, Descricao, PrecoUnitario)
VALUES ('Macarrão', 'Alimentos', 'Vitarela', 'Macarrão instantâneo do tipo de Carne', 1.89);
INSERT INTO Produtos (Nome, Categoria, Marca, Descricao, PrecoUnitario)
VALUES ('Arroz', 'Alimentos', 'Tio João', 'Arroz tipo parborizado Tio João', 2.59);
INSERT INTO Produtos (Nome, Categoria, Marca, Descricao, PrecoUnitario)
VALUES ('Tomate', 'Hortifruti', 'Pomodoro', 'Tomate orgânico do tipo Pomodoro', 5);
INSERT INTO Produtos (Nome, Categoria, Marca, Descricao, PrecoUnitario)
VALUES ('Pepino', 'Hortifruti', 'CIA e Grãos', 'Pepino orgânico', 3.14);
INSERT INTO Produtos (Nome, Categoria, Marca, Descricao, PrecoUnitario)
VALUES ('Biscoito', 'Mercearia', 'Vitarela', 'Biscoito treloso', 2);