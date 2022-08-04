------------------------------- 7 (Ku_MyBase)
-- 1.1
-- определить все индексы, которые имеются в БД Ku_MyBase
use Ku_MyBase;
exec sp_helpindex 'Водители';
exec sp_helpindex 'Водители на перевозках';
exec sp_helpindex 'Маршруты';
exec sp_helpindex 'Перевозки';

-- 1.2
create table #tempTable_task7(
	id int identity(1,1),
	num int,
	string char(6)
);

declare @ind int = 0;
set nocount on;
while(@ind < 1000)
begin
	insert #tempTable_task7 values(floor(rand()*6000), 'UH OH!');
	set @ind += 1;
end;

-- запрос
select * 
from #tempTable_task7
order by num;

-- кластеризованный индекс
create clustered index #tempTable_task7_num_ind on #tempTable_task7(num);
-- drop index #tempTable_task7.#tempTable_task7_num_ind;

-- 2
-- заполняю таблицу 10000 строк
declare @ind_2 int = 0;
while(@ind_2 < 10000)
begin
	insert #tempTable_task7 values(floor(rand()*6000), 'UH OH!');
	set @ind_2 += 1;
end;

-- некластеризованный неуникальный составной индекс
create index #tempTable_task7_composite_ind on #tempTable_task7(id, num);
-- drop index #tempTable_task7.#tempTable_task7_composite_ind;

-- запрос
select * 
from #tempTable_task7
where id = 50000 and num > 1000

-- 3
-- будем использовать таблицу #tempTable_task7 
-- запрос
select string 
from #tempTable_task7 
where id < 600;

-- некластеризованный индекс покрытия
create index #tempTable_task7_id_inc on #tempTable_task7(string) include (id);
-- drop index #tempTable_task7.#tempTable_task7_id_inc;

-- 4
select id from #tempTable_task7 where id > 399 and id < 600; -- индекс НЕ применится
select id from #tempTable_task7 where id > 400 and id < 600; -- индекс применится

-- фильтруемый индекс
create index #tempTable_task7_where on #tempTable_task7(id) where (id > 400 and id < 700);
-- drop index #tempTable_task7.#tempTable_task7_where;

-- 5
-- некластеризованный индекс
create index #tempTable_task7_string on #tempTable_task7(string);
-- drop index #tempTable_task7.#tempTable_task7_string;

-- информация о % фрагментации
use tempdb;
select	indInfo.name as [Индекс],
		fragInfo.avg_fragmentation_in_percent as [Фрагментация, %]
from sys.dm_db_index_physical_stats(db_id('tempdb'),
									object_id('#tempTable_task7'),
									null,
									null,
									null) as fragInfo
join sys.indexes as indInfo
	on fragInfo.object_id = indInfo.object_id
	and fragInfo.index_id = indInfo.index_id
	where indInfo.name is not null;

-- увеличиваем фрагментацию
insert top(99999999999999999) #tempTable_task7(num, string)
select num, string from #tempTable_task7;

-- реогранизация
alter index #tempTable_task7_string on #tempTable_task7 reorganize;

-- перестройка
alter index #tempTable_task7_string on #tempTable_task7 rebuild with (online = off)

-- 6
create index #tempTable_task7_id on #tempTable_task7(id)
										with (fillfactor = 20);