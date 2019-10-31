IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = 'db_promos') /*N’SQLServerPlanet’*/
	CREATE DATABASE db_promos;
USE db_promos;

/*prestar atenção que toda tabela tem ID como PK AI, mas quando é FK ela fica como "ID + qual tabela" que é
prestar atenção nisso na hora de programar o sistema
PK - Primary KEY
AI = auto increment
FK foreing key

criação das tabelas*/

IF NOT EXISTS(SELECT * FROM sysobjects WHERE name='tb_master' and xtype='U')
	CREATE TABLE tb_master (
		id int IDENTITY(1,1) primary key,
		empresa varchar(30),		
		nome varchar(20),
		senha varchar(20)
	);
go
IF NOT EXISTS(SELECT * FROM sysobjects WHERE name='tb_loja' and xtype='U')
	CREATE TABLE tb_loja (
		id int IDENTITY(1,1) primary key,
		cnpj varchar(17) UNIQUE,
		nome varchar(35),
		funciona char(1) DEFAULT 1 /*FUNCIONA é 1 e NÃO FUNCIONA mais (loja fechada) é 0 (true/false*/
	)
go

IF NOT EXISTS(SELECT * FROM sysobjects WHERE name='tb_lojista' and xtype='U')
	CREATE TABLE tb_lojista (
		id int IDENTITY(1,1) primary key,
		idloja int,
		nome varchar(35),
		senha varchar(20)
		
	);
go

IF NOT EXISTS(SELECT * FROM sysobjects WHERE name='tb_cliente' and xtype='U')
	CREATE TABLE tb_cliente (
		id int IDENTITY(1,1) primary key,
		cpf varchar(14) UNIQUE,
		nome varchar(35),
		email varchar(30),
		tel varchar(14)
	);
go

IF NOT EXISTS(SELECT * FROM sysobjects WHERE name='tb_promo' and xtype='U')
	CREATE TABLE tb_promo (
		id int IDENTITY(1,1) primary key,
		idlojista int,
		criado date,
		validade date,
		carimbos int,
		FOREIGN KEY(idlojista) REFERENCES tb_lojista(id)
	);
go

IF NOT EXISTS(SELECT * FROM sysobjects WHERE name='tb_cartela' and xtype='U')
	CREATE TABLE tb_cartela (
		id int IDENTITY(1,1) primary key,
		idpromo int,
		idlojista int,
		idcliente int,
		--  qtdadiq int DEFAULT 0, /*quantidade adquirida de carimbos nessa cartela*/
		--  trocado char(1) DEFAULT 0, /*NÃO TROCADO é 0 e TROCADO é 1 (true e false)*/
		datatroca date,
		FOREIGN KEY(idpromo) REFERENCES tb_promo(id),
		FOREIGN KEY(idlojista) REFERENCES tb_lojista(id),
		FOREIGN KEY(idcliente) REFERENCES tb_cliente(id)
	);
go

IF NOT EXISTS(SELECT * FROM sysobjects WHERE name='tb_carimbo' and xtype='U')
	CREATE TABLE tb_carimbo (
		id int IDENTITY(1,1) primary key,
		idcartela int,
		idloja int,
		idcliente int,
		datacarimbo date,
		resgatado char(1) DEFAULT 0, /*NÃO TROCADO é 0 e TROCADO é 1 (true e false)*/
		FOREIGN KEY(idcartela) REFERENCES tb_cartela(id),
		FOREIGN KEY(idloja) REFERENCES tb_loja(id),
		FOREIGN KEY(idcliente) REFERENCES tb_cliente(id)
	);
go