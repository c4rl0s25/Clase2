
create table Usuario
(
Id int identity(1,1) primary key,
name varchar(max) not null,
clave varchar(max) not null,
habilitar bit not null
)

create procedure CreaUsuario

@name varchar(max),
@clave varchar(max) ,
@habilitar bit 
as
	begin
	INSERT INTO Usuario (name,clave,habilitar) values (@name,@clave,@habilitar) 
end

create procedure ListarUsuarios
as
	begin
	select Id,name,clave,habilitar from Usuario
	end

		create procedure BorrarUsuario
	@Id int
	as
	begin 
	delete from Usuario where Id =@Id
	end