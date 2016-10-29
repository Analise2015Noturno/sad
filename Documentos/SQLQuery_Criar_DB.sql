create database t_pratico
go
use t_pratico
go
create table tbl_tipo_usuario
(
	id_tipo_usuario int not null primary key identity(1,1),
	nome_tipo_usuario varchar(80)
)

create table tbl_usuario
(
	id_usuario int not null primary key identity(1,1),
	nome_usuario varchar (255),
	cpf varchar(11),
	cep varchar(8),
	endereco varchar(80),
	n_endereco int,
	bairro varchar(80),
	cidade varchar(80),
	uf varchar(2),
	email varchar(80),
	senha varchar (80),
	id_tipo_usuario int not null references tbl_tipo_usuario (id_tipo_usuario)
)

create table tbl_problema
(
	id_problema int not null primary key identity(1,1),
	titulo_problema varchar (80),
	descricao_problema varchar (800),
	dt_criacao date,
	dt_hr_atualizacao datetime,
	usuario_solucao int not null references tbl_usuario (id_usuario),
)

create table tbl_solucao
(
	id_solucao int not null primary key identity(1,1),
	nome varchar (80),
	imagem image,
	link_acesso varchar(255),
	descricao_solucao varchar(255),
)

create table tbl_problema_solucao
(
	id_problema_solucao int not null primary key identity(1,1),
	id_problema int not null references tbl_problema (id_problema),
	id_solucao int not null references tbl_solucao (id_solucao)
)

create table tbl_feedback
(
	id_feedback int not null primary key identity(1,1),
	detalhe_feedback varchar(255),
	dt_feedback datetime,
	id_solucao int not null references tbl_solucao (id_solucao)
)

create table tbl_questao
(
	id_questao int not null primary key identity(1,1),
	questao varchar(255),
	resposta int not null
)
create table tbl_questionario
(
	id_problema int not null references tbl_problema (id_problema),
	id_questão int not null references tbl_questao (id_questao)
)



select * from tbl_tipo_usuario
select * from tbl_usuario
select * from tbl_problema
select * from tbl_solucao
select * from tbl_problema_solucao
select * from tbl_feedback
select * from tbl_questao
select * from tbl_questionario