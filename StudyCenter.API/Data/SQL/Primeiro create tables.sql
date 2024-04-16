create table MATERIA (
	id_materia int primary key not null,
	nome_materia nvarchar(100) not null,
)

create table TOPICOS (
		id_topico int primary key not null,
		topico nvarchar(100) not null,
		id_materia int,
		FOREIGN KEY (id_materia) REFERENCES MATERIA (id_materia)
		)
create table SESSOES(
	id_sessao int primary key not null,
	nome_sessao nvarchar(200),
	anotacao_sessao nvarchar(max),
	dthr_inicio_sessao datetime not null,
	dthr_fim_sessao datetime not null
)

create table SESSAO_TOPICOS(
	id_sessao_topico int primary key not null,
	id_sessao int not null,
	id_topico int not null,
	duracao_estudo decimal,
	FOREIGN KEY (id_sessao) REFERENCES SESSOES(id_sessao),
    FOREIGN KEY (id_topico) REFERENCES TOPICOS(id_topico)
)

create table ANOTACOES_TOPICO (
    id_anotacao int primary key not null,
    id_sessao_topico int not null,
    anotacao nvarchar(max)
	FOREIGN KEY (id_sessao_topico) REFERENCES SESSAO_TOPICOS(id_sessao_topico)
)
