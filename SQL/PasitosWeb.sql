CREATE DATABASE PASITOSWEB

CREATE TABLE CURSO(
	Nombre		Varchar(60) Primary Key,
	NoCredito		int NOT NULL
);

CREATE TABLE PRERREQUISITO(
	Curso		Varchar(60) NOT NULL,
	PreCurso	Varchar(60) NOT NULL,
	CONSTRAINT pk_prerequisito PRIMARY KEY(Curso, PreCurso),
	CONSTRAINT fk_curso FOREIGN KEY(curso) REFERENCES CURSO(Nombre),
	CONSTRAINT fk_Precurso FOREIGN KEY(Precurso) REFERENCES CURSO(Nombre)
);



select * from CURSO;
select * from PRERREQUISITO;

drop Table PRERREQUISITO, CURSO;

delete from CURSO

DROP DATABASE PASITOSWEB