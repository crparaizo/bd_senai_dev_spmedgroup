USE SPMEDGROUP;

SELECT * FROM CLINICA
SELECT * FROM CONSULTA
SELECT * FROM ESPECIALIDADES
SELECT * FROM MEDICOS
SELECT * FROM PRONTUARIOS
SELECT * FROM SITUACOES
SELECT * FROM TIPOS_USUARIOS
SELECT * FROM USUARIOS

DELETE FROM CONSULTA
DBCC CHECKIDENT('CONSULTA', RESEED, 0)

GO

CREATE PROCEDURE INSERIR_CLINICA
AS
BEGIN
bulk insert CLINICA
from 'C:\db\spmedgroup_clinica.csv'
	with(
		format = 'csv',
		firstrow = 2, -- primeira linha de dados = 2 
		fieldterminator = ';', -- separador de campos = ';'
		rowterminator = '\n', -- separador de linhas = '\n'
		CODEPAGE = 'ACP', -- codificação dos dados = 'ACP'
		DATAFILETYPE = 'Char' -- tipo do arquivo = 'Char'
	);
END
GO

CREATE PROCEDURE INSERIR_SITUACAO
AS
BEGIN
bulk insert SITUACOES
from 'C:\db\spmedgroup_situacoes.csv'
	with(
		format = 'csv',
		firstrow = 2, -- primeira linha de dados = 2 
		fieldterminator = ';', -- separador de campos = ';'
		rowterminator = '\n', -- separador de linhas = '\n'
		CODEPAGE = 'ACP', -- codificação dos dados = 'ACP'
		DATAFILETYPE = 'Char' -- tipo do arquivo = 'Char'
	);
END
GO

CREATE PROCEDURE INSERIR_TIPO_USUARIO
AS
BEGIN
bulk insert TIPOS_USUARIOS
from 'C:\db\spmedgroup_tipos_usuarios.csv'
	with(
		format = 'csv',
		firstrow = 2, -- primeira linha de dados = 2 
		fieldterminator = ';', -- separador de campos = ';'
		rowterminator = '\n', -- separador de linhas = '\n'
		CODEPAGE = 'ACP', -- codificação dos dados = 'ACP'
		DATAFILETYPE = 'Char' -- tipo do arquivo = 'Char'
	);
END
GO

CREATE PROCEDURE INSERIR_ESPECIALIDADE
AS
BEGIN
bulk insert ESPECIALIDADES
from 'C:\db\spmedgroup_especialidades.csv'
	with(
		format = 'csv',
		firstrow = 2, -- primeira linha de dados = 2 
		fieldterminator = ';', -- separador de campos = ';'
		rowterminator = '\n', -- separador de linhas = '\n'
		CODEPAGE = 'ACP', -- codificação dos dados = 'ACP'
		DATAFILETYPE = 'Char' -- tipo do arquivo = 'Char'
	);
END
GO

CREATE PROCEDURE INSERIR_USUARIOS
AS
BEGIN
bulk insert USUARIOS
from 'C:\db\spmedgroup_usuarios.csv'
	with(
		format = 'csv',
		firstrow = 2, -- primeira linha de dados = 2 
		fieldterminator = ';', -- separador de campos = ';'
		rowterminator = '\n', -- separador de linhas = '\n'
		CODEPAGE = 'ACP', -- codificação dos dados = 'ACP'
		DATAFILETYPE = 'Char' -- tipo do arquivo = 'Char'
	);
END
GO


CREATE PROCEDURE INSERIR_MEDICO
AS
BEGIN
bulk insert MEDICOS
from 'C:\db\spmedgroup_medicos.csv'
	with(
		format = 'csv',
		firstrow = 2, -- primeira linha de dados = 2 
		fieldterminator = ';', -- separador de campos = ';'
		rowterminator = '\n', -- separador de linhas = '\n'
		CODEPAGE = 'ACP', -- codificação dos dados = 'ACP'
		DATAFILETYPE = 'Char' -- tipo do arquivo = 'Char'
	);
END
GO


CREATE PROCEDURE INSERIR_PRONTUARIO
AS
BEGIN
bulk insert PRONTUARIOS
from 'C:\db\spmedgroup_prontuarios.csv'
	with(
		format = 'csv',
		firstrow = 2, -- primeira linha de dados = 2 
		fieldterminator = ';', -- separador de campos = ';'
		rowterminator = '\n', -- separador de linhas = '\n'
		CODEPAGE = 'ACP', -- codificação dos dados = 'ACP'
		DATAFILETYPE = 'Char' -- tipo do arquivo = 'Char'
	);
END
GO


CREATE PROCEDURE INSERIR_CONSULTA
AS
BEGIN
bulk insert CONSULTA
from 'C:\db\spmedgroup_consultas.csv'
	with(
		format = 'csv',
		firstrow = 2, -- primeira linha de dados = 2 
		fieldterminator = ';', -- separador de campos = ';'
		rowterminator = '\n', -- separador de linhas = '\n'
		CODEPAGE = 'ACP', -- codificação dos dados = 'ACP'
		DATAFILETYPE = 'Char' -- tipo do arquivo = 'Char'
	);
END
GO

EXEC INSERIR_CLINICA
EXEC INSERIR_CONSULTA
EXEC INSERIR_ESPECIALIDADE
EXEC INSERIR_MEDICO
EXEC INSERIR_PRONTUARIO
EXEC INSERIR_SITUACAO
EXEC INSERIR_TIPO_USUARIO
EXEC INSERIR_USUARIOS
