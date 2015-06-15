--delete from Carga;
--DBCC CHECKIDENT (Carga, reseed, 0)
select count(*) from Carga;
select nome, id from Carga order by 2 desc;