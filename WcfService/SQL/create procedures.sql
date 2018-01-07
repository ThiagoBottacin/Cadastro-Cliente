CREATE PROCEDURE sp_TipoCliente @command NVARCHAR(6)
AS

	SET NOCOUNT ON;
	IF(@command = 'SELECT')
	 BEGIN
		SELECT Tipo_ClienteId, Nome FROM Tipo_Cliente
	 END

GO

CREATE PROCEDURE sp_SituacaoCliente @command NVARCHAR(6)
AS

	SET NOCOUNT ON;
	IF(@command = 'SELECT')
	 BEGIN
		SELECT Situacao_ClienteId, Nome FROM Situacao_Cliente
	 END
	
GO

CREATE PROCEDURE sp_Cliente 

	@command NVARCHAR(6), 
	@clienteId INT NULL,
	@nome NVARCHAR(100) NULL,
	@cpf NVARCHAR(14) NULL,
	@tipoClienteId INT NULL,
	@sexo CHAR NULL,
	@situacaoClienteId INT NULL

AS

	SET NOCOUNT ON;

	IF(@command = 'INSERT')
	BEGIN
		
		INSERT INTO Cliente VALUES(@nome, @cpf, @tipoClienteId, @sexo, @situacaoClienteId);

	END
	ELSE IF(@command = 'SELECT')
	BEGIN
		
		SELECT 
			C.ClienteId, 
			C.Nome, 
			C.CPF, 
			TC.Tipo_ClienteId, 
			TC.Nome, 
			C.Sexo, 
			SC.Situacao_ClienteId, 
			SC.Nome 
		FROM Cliente C
		INNER JOIN Tipo_Cliente TC ON C.Tipo_ClienteId = TC.Tipo_ClienteId
		INNER JOIN Situacao_Cliente SC ON C.Situacao_ClienteId = SC.Situacao_ClienteId

	END
	ELSE IF(@command = 'UPDATE')
	BEGIN

		UPDATE Cliente SET
			Nome = @nome, 
			CPF = @cpf, 
			Tipo_ClienteId = @tipoClienteId, 
			Sexo = @sexo, 
			Situacao_ClienteId = @situacaoClienteId

		WHERE ClienteId = @clienteId;

	END
	ELSE IF(@command = 'DELETE')
	BEGIN
		
		DELETE Cliente WHERE ClienteId = @clienteId;

	END

GO
