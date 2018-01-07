
CREATE TABLE Tipo_Cliente (
	
	Tipo_ClienteId INT NOT NULL IDENTITY(1,1) CONSTRAINT PK_Tipo_Cliente_Tipo_ClienteId PRIMARY KEY,
	Nome NVARCHAR(50) NOT NULL,
);

CREATE TABLE Situacao_Cliente (
	Situacao_ClienteId INT NOT NULL IDENTITY(1,1) CONSTRAINT PK_Situacao_Cliente_Situacao_ClienteId PRIMARY KEY,
	Nome NVARCHAR(50) NOT NULL
);

CREATE TABLE Cliente (
	
	ClienteId INT NOT NULL IDENTITY(1,1) CONSTRAINT PK_Cliente_ClienteId PRIMARY KEY,
	Nome NVARCHAR(100) NOT NULL,
	CPF NVARCHAR(14) NOT NULL CONSTRAINT UQ_Cliente_CPF UNIQUE,
	Tipo_ClienteId INT NOT NULL,
	Sexo char(1) NOT NULL CONSTRAINT CK_Cliente_Sexo CHECK(Sexo = 'M' or Sexo = 'F'),
	Situacao_ClienteId INT NOT NULL,

	CONSTRAINT FK_Cliente_Tipo_ClienteId FOREIGN KEY(Tipo_ClienteId) REFERENCES Tipo_Cliente(Tipo_ClienteId),
	CONSTRAINT FK_Cliente_Situacao_ClienteId FOREIGN KEY(Situacao_ClienteId) REFERENCES Situacao_Cliente(Situacao_ClienteId)
);


-- Carga de Teste
INSERT INTO Tipo_Cliente VALUES('Eventual');
INSERT INTO Tipo_Cliente VALUES('Regular');

INSERT INTO Situacao_Cliente VALUES('Livre');
INSERT INTO Situacao_Cliente VALUES('Potencial');
INSERT INTO Situacao_Cliente VALUES('Ativo');
INSERT INTO Situacao_Cliente VALUES('Inativo');

INSERT INTO Cliente Values ('Thiago Bottacin', '226.310.588-36', 1, 'M', 3);