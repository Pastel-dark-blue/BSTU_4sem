------------------------------- 7 (Ku_MyBase)
-- 1.1
-- ���������� ��� �������, ������� ������� � �� Ku_MyBase
use Ku_MyBase;
exec sp_helpindex '��������';
exec sp_helpindex '�������� �� ����������';
exec sp_helpindex '��������';
exec sp_helpindex '���������';

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

-- ������
select * 
from #tempTable_task7
order by num;

-- ���������������� ������
create clustered index #tempTable_task7_num_ind on #tempTable_task7(num);
-- drop index #tempTable_task7.#tempTable_task7_num_ind;

-- 2
-- �������� ������� 10000 �����
declare @ind_2 int = 0;
while(@ind_2 < 10000)
begin
	insert #tempTable_task7 values(floor(rand()*6000), 'UH OH!');
	set @ind_2 += 1;
end;

-- ������������������ ������������ ��������� ������
create index #tempTable_task7_composite_ind on #tempTable_task7(id, num);
-- drop index #tempTable_task7.#tempTable_task7_composite_ind;

-- ������
select * 
from #tempTable_task7
where id = 50000 and num > 1000

-- 3
-- ����� ������������ ������� #tempTable_task7 
-- ������
select string 
from #tempTable_task7 
where id < 600;

-- ������������������ ������ ��������
create index #tempTable_task7_id_inc on #tempTable_task7(string) include (id);
-- drop index #tempTable_task7.#tempTable_task7_id_inc;

-- 4
select id from #tempTable_task7 where id > 399 and id < 600; -- ������ �� ����������
select id from #tempTable_task7 where id > 400 and id < 600; -- ������ ����������

-- ����������� ������
create index #tempTable_task7_where on #tempTable_task7(id) where (id > 400 and id < 700);
-- drop index #tempTable_task7.#tempTable_task7_where;

-- 5
-- ������������������ ������
create index #tempTable_task7_string on #tempTable_task7(string);
-- drop index #tempTable_task7.#tempTable_task7_string;

-- ���������� � % ������������
use tempdb;
select	indInfo.name as [������],
		fragInfo.avg_fragmentation_in_percent as [������������, %]
from sys.dm_db_index_physical_stats(db_id('tempdb'),
									object_id('#tempTable_task7'),
									null,
									null,
									null) as fragInfo
join sys.indexes as indInfo
	on fragInfo.object_id = indInfo.object_id
	and fragInfo.index_id = indInfo.index_id
	where indInfo.name is not null;

-- ����������� ������������
insert top(99999999999999999) #tempTable_task7(num, string)
select num, string from #tempTable_task7;

-- �������������
alter index #tempTable_task7_string on #tempTable_task7 reorganize;

-- �����������
alter index #tempTable_task7_string on #tempTable_task7 rebuild with (online = off)

-- 6
create index #tempTable_task7_id on #tempTable_task7(id)
										with (fillfactor = 20);