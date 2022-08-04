use UNIVERSITY;

------------------------------- 1.1
exec sp_helpindex 'AUDITORIUM';
exec sp_helpindex 'AUDITORIUM_TYPE';
exec sp_helpindex 'FACULTY';
exec sp_helpindex 'GROUPS';
exec sp_helpindex 'PROFESSION';
exec sp_helpindex 'PROGRESS';
exec sp_helpindex 'PULPIT';
exec sp_helpindex 'STUDENT';
exec sp_helpindex 'SUBJECT';
exec sp_helpindex 'TEACHER';

------------------------------- 1.2
-- создание временной таблицы
create table #tempTable(
	num int,
	string char(2)
);

-- заполнение таблицы
set nocount on; -- не выводить сообщения о затронутых строках
declare @i int = 0;
while @i < 1000
	begin
		insert #tempTable
			values(floor(rand()*20000), 'po');
		set @i += 1;
	end;

----------------------------------------------------------------------------------
checkpoint; -- сохраняем на диск все данные предыдущих инструкций из буффера
DBCC dropcleanbuffers; -- очищаем буферный кэш
----------------------------------------------------------------------------------

-- select-запрос
select * from #tempTable
where num between 1500 and 2500
order by num;

-- создание кластеризованного индекса на первый столбец таблицы #tempTable
create clustered index #tempTable_num_ind on #tempTable(num);

-------------------------------	2
-- создание таблицы
create table #tempTable_2(
	id int identity(1,1),
	num int,
	string char(2),
);

-- заполнение таблицы, при floor(rand()*300) индекс не применялся, кстати
set nocount on; 
declare @i_2 int = 0;
while @i_2 < 10000
	begin
		insert #tempTable_2
			values(floor(rand()*3000), 'po');
		set @i_2 += 1;
	end;

-- запрос к временной таблице
select *
from #tempTable_2
where num = 268 and id > 100;

-- некластеризованный неуникальный составной индекс
create index #tempTable_2_id_num_ind on #tempTable_2(num, id);
-- drop index #tempTable_2.#tempTable_2_id_num_ind

-------------------------------	3
create index #tempTable_2_num_include on #tempTable_2(num) include (id);
-- drop index #tempTable_2.#tempTable_2_num_include

select id from #tempTable_2 where num < 200;

-------------------------------	4
-- запросы
select num from #tempTable_2 where num > 100
select num from #tempTable_2 where num > 100 and num < 150
select num from #tempTable_2 where num = 160

-- некластеризованный фильтруемый индекс
create index #tempTable_2_whereNum on #tempTable_2(num) where (num > 100 and num < 200);
-- drop index #tempTable_2.#tempTable_2_whereNum

------------------------------- 5
-- создание некластеризованого индекса
create index #tempTable_2_num on #tempTable_2(num);
-- drop index #tempTable_2.#tempTable_2_num;

-- переключение контекста на БД tempdb с таблицей #tempTable_2
use tempdb;
-- получение информации о индексах таблицы
select	indInfo.name as [Индекс], 
		fragInfo.avg_fragmentation_in_percent as [Фрагментация, %]
from sys.dm_db_index_physical_stats(db_id('tempdb'),
									object_id('#tempTable_2'),
									null,
									null,
									null) as fragInfo
join sys.indexes as indInfo
	on fragInfo.object_id = indInfo.object_id
	and fragInfo.index_id = indInfo.index_id
		where indInfo.name is not null;

-- увеличиваем фрагментацию индекса
insert top(10000000) #tempTable_2(num, string) 
select num, string from #tempTable_2

-- реорганизация
alter index #tempTable_2_num on #tempTable_2 reorganize

-- перестройка
alter index #tempTable_2_num on #tempTable_2 rebuild with (online = off)

------------------------------- 6
-- drop index #tempTable_2.#tempTable_2_num;
create index #tempTable_2_num on #tempTable_2(num)
									with(fillfactor = 65)


