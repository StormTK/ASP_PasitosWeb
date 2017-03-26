CREATE DATABASE PASITOSWEB

CREATE TABLE CURSO(
	Codigo		int	primary key,
	Nombre		Varchar(60) NOT NULL
);

CREATE TABLE PRERREQUISITO(
	Curso		int NOT NULL,
	PreCurso	int NOT NULL,
	CONSTRAINT pk_prerequisito PRIMARY KEY(Curso, PreCurso),
	CONSTRAINT fk_curso FOREIGN KEY(curso) REFERENCES CURSO(Codigo),
	CONSTRAINT fk_Precurso FOREIGN KEY(Precurso) REFERENCES CURSO(Codigo)
);

select * from CURSO;