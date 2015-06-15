USE [master]
GO
--ALTER DATABASE Oficina SET  SINGLE_USER WITH ROLLBACK IMMEDIATE
--GO
--USE [master]
--GO

/* Termina sessões ativas */
declare @kill varchar(8000) = '';
select @kill=@kill+'kill ' + convert(varchar(5),spid) + ';'
from master..sysprocesses 
where dbid=db_id('LAB_BD');
print @kill;
exec (@kill);

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
USE [master]
GO
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- (RE)CRIA BD LAB_BD
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'LAB_BD')
DROP DATABASE [LAB_BD]
GO

USE [master]
GO
CREATE DATABASE [LAB_BD]
GO

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- (RE)CRIA OBJETOS
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
USE [LAB_BD]
GO

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- EXCLUE CONSTRAINTS
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
IF  EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_CONTAS_TIPOS]') AND parent_object_id = OBJECT_ID(N'[dbo].[CONTAS]'))
BEGIN
	IF  EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_CONTAS_TIPOS]') AND parent_object_id = OBJECT_ID(N'[dbo].[CONTAS]'))
	ALTER TABLE [dbo].[CONTAS] DROP CONSTRAINT [CK_CONTAS_TIPOS]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CLIENTES]') AND type in (N'U'))
	DROP TABLE [dbo].[CLIENTES]
GO
IF  EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_CONTAS_TIPOS]') AND parent_object_id = OBJECT_ID(N'[dbo].[CONTAS]'))
	ALTER TABLE [dbo].[CONTAS] DROP CONSTRAINT [CK_CONTAS_TIPOS]
GO

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- (RE)CRIA TABELA CONTAS
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CONTAS]') AND type in (N'U'))
	DROP TABLE [dbo].[CONTAS]
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CONTAS]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[CONTAS](
		[NUMERO] [char](10) NOT NULL,
		[TIPO] [char](2) NOT NULL,
		[SALDO] [decimal](18, 2) NOT NULL,
	CONSTRAINT [PK_Contas] PRIMARY KEY CLUSTERED 
	(
		[NUMERO] ASC
	))
END
GO

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- INSERE REGISTROS EM CONTAS
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
INSERT [dbo].[CONTAS] ([NUMERO], [TIPO], [SALDO]) VALUES (N'01-0001001', N'CC', CAST(1000 AS Decimal(18, 2)))
INSERT [dbo].[CONTAS] ([NUMERO], [TIPO], [SALDO]) VALUES (N'01-0001002', N'CC', CAST(500 AS Decimal(18, 2)))
INSERT [dbo].[CONTAS] ([NUMERO], [TIPO], [SALDO]) VALUES (N'01-0001003', N'CC', CAST(800 AS Decimal(18, 2)))
INSERT [dbo].[CONTAS] ([NUMERO], [TIPO], [SALDO]) VALUES (N'01-0001004', N'CC', CAST(2000 AS Decimal(18, 2)))
INSERT [dbo].[CONTAS] ([NUMERO], [TIPO], [SALDO]) VALUES (N'01-0001005', N'CC', CAST(700 AS Decimal(18, 2)))
INSERT [dbo].[CONTAS] ([NUMERO], [TIPO], [SALDO]) VALUES (N'02-0002001', N'CP', CAST(0 AS Decimal(18, 2)))
INSERT [dbo].[CONTAS] ([NUMERO], [TIPO], [SALDO]) VALUES (N'02-0002002', N'CP', CAST(1000 AS Decimal(18, 2)))
INSERT [dbo].[CONTAS] ([NUMERO], [TIPO], [SALDO]) VALUES (N'02-0002003', N'CP', CAST(1000 AS Decimal(18, 2)))
INSERT [dbo].[CONTAS] ([NUMERO], [TIPO], [SALDO]) VALUES (N'02-0002004', N'CP', CAST(100 AS Decimal(18, 2)))
INSERT [dbo].[CONTAS] ([NUMERO], [TIPO], [SALDO]) VALUES (N'02-0002005', N'CP', CAST(600 AS Decimal(18, 2)))
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
SELECT * FROM CONTAS ORDER BY NUMERO
GO
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- RE(CRIA) TABELA CLIENTES (PARA CARGA DE DADOS)
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CLIENTES]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CLIENTES](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOME] [varchar](50) NOT NULL,
	[TELEFONE] [varchar](20) NOT NULL,
 CONSTRAINT [PK_CLIENTES] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
))
END
GO

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- (RE)CRIA CONSTRAINTS
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
ALTER TABLE [dbo].[CONTAS]  WITH CHECK ADD  CONSTRAINT [CK_CONTAS_APENAS_SALDO_POSITIVO] CHECK  (([SALDO]>=(0)))
GO
ALTER TABLE [dbo].[CONTAS] CHECK CONSTRAINT [CK_CONTAS_APENAS_SALDO_POSITIVO]
GO

IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_CONTAS_TIPOS]') AND parent_object_id = OBJECT_ID(N'[dbo].[CONTAS]'))
ALTER TABLE [dbo].[CONTAS]  WITH CHECK ADD  CONSTRAINT [CK_CONTAS_TIPOS] CHECK  (([TIPO]='CC' OR [TIPO]='CP'))
GO
IF  EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_CONTAS_TIPOS]') AND parent_object_id = OBJECT_ID(N'[dbo].[CONTAS]'))
ALTER TABLE [dbo].[CONTAS] CHECK CONSTRAINT [CK_CONTAS_TIPOS]
GO
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
USE [master]
GO
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
