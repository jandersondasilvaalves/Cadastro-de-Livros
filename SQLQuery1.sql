create database Livros

create table Livros(
	id int identity,
	titulo varchar(50),
	autor varchar(50)
)
select * from Livros

select * from Livros where id = 1
update Livros set titulo = 'livro editado', autor = 'livro editado' where id = 1
delete from Livros where id = 1