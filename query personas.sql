

create table Personas(
id int primary key identity(1,1),
nombre varchar(50) not null,
apellidoPat varchar(50) null,
apellidoMat varchar(50) null,
);
insert into Personas(nombre, apellidoPat, apellidoMat)
values('Marcelo', 'Hernandez')