USE [LaBaseTheBase]
GO

ALTER TABLE Personas 
	ADD Foto VARBINARY(MAX)

INSERT INTO Departamentos (nombreDepartamento)
	VALUES ('clase'),('informatica'),('jefatura')

SET dateformat DMY

INSERT INTO [dbo].[Personas]([nombrePersona],[apellidosPersona],[fechaNacimiento],[Telefono],[direccion],[IDDepartamento])
     VALUES
           ('Angelito','Lopezito','26/12/2001','mi casa','telefono?',3),
           ('Pedro','Pastor','16/7/2001','su casa','telefono?',3),
           ('Santi','Martinez','4/2/2001','tu casa','telefono?',3),
           ('Nadine','Rufo','19/4/2000','la casa','telefono?',3),
           ('Jesus','Santos','8/1/1987','el casa','telefono?',3),
           ('Antonio','Quevedo','14/3/2004','casa','telefono?',3)
GO

select * from departamentos
select * from PERSONAS