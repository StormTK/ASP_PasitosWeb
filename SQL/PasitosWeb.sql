CREATE DATABASE PASITOSWEB

CREATE TABLE CURSO(
	Codigo		int	primary key identity,
	Nombre		Varchar(60) NOT NULL,
	NoCredito		int NOT NULL
);

CREATE TABLE PRERREQUISITO(
	Curso		int NOT NULL,
	PreCurso	int NOT NULL,
	CONSTRAINT pk_prerequisito PRIMARY KEY(Curso, PreCurso),
	CONSTRAINT fk_curso FOREIGN KEY(curso) REFERENCES CURSO(Codigo),
	CONSTRAINT fk_Precurso FOREIGN KEY(Precurso) REFERENCES CURSO(Codigo)
);

select * from CURSO;
select * from PRERREQUISITO;

drop Table PRERREQUISITO, CURSO;

delete from CURSO

DROP DATABASE PASITOSWEB