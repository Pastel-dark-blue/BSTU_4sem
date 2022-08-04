-- 1
set nocount on;

-- ���� ������� #tempTable ���������� - ������� �
use tempdb;
if exists (select * from sys.objects
			where object_id=object_id('dbo.#tempTable'))
drop table #tempTable;

declare @amountOfRows int;

set implicit_transactions on;	-- ��� ����� ������� ����������
-- ������ ����������
create table #tempTable(number int);
insert #tempTable values (1),
						 (2),
						 (3);

set @amountOfRows = (select count(*) from #tempTable);

print '���-�� ����� � ������� #tempTable : ' + cast(@amountOfRows as varchar(2));

commit; -- ���������� ����������: ��������
-- rollback; -- ���������� ����������: �����

set implicit_transactions off;	-- ���� ����� ������� ����������

if exists(select * from sys.objects
		  where object_id=object_id('dbo.#tempTable'))
	print '������� #tempTable ����������';
else 
		print '������� #tempTable �� ����������';

-- 2
use UNIVERSITY;
begin try
	begin tran;
		insert AUDITORIUM values('000-1', '��', 89, '000-1');
		insert AUDITORIUM values(null, '��', 89, 'null');	-- ������, �.�. ������ ������� - ��������� ����
	commit tran;
end try
begin catch
	print '������ : ' + cast(error_number() as varchar(5)) + char(10) + error_message();
	if @@trancount > 0 rollback tran; -- ����� ��������� ����������
end catch;

-- 3
use UNIVERSITY;
declare @point varchar(32);

begin try
	begin tran
		insert AUDITORIUM values('000-1', '��', 89, '000-1');
		set @point = 'p1';	-- ������������� ����� ����������
		save tran @point; 
		insert AUDITORIUM values(null, '��', 89, 'null');	-- ������, �.�. ������ ������� - ��������� ����
	commit tran
end try
begin catch
	print '������ : ' + cast(error_number() as varchar(5)) + char(10) + error_message();
	if @@trancount > 0 
		begin
			print '����������� ����� : ' + @point;
			rollback tran @point; -- ����� � ����������� �����
			commit tran; -- �������� ��������� �� ����������� �����
		end;
end catch

-- 4
use UNIVERSITY;
-- A --
set transaction isolation level READ UNCOMMITTED
begin tran
--------------------- t1 ---------------------
	select	@@spid as [id A (insert)], 
			'insert AUDITORIUM''���������', 
			*
		from AUDITORIUM 
		where AUDITORIUM='111-1';

	select	@@spid as [id A (update)], 
			'update AUDITORIUM''���������', 
			*
		from AUDITORIUM
		where AUDITORIUM_CAPACITY=100;
commit;
--------------------- t2 ---------------------
-- B --
begin tran
	select @@spid as [id B];
	insert AUDITORIUM values('111-1', '��', 89, '111-1');
	update AUDITORIUM set AUDITORIUM_CAPACITY=100
			where AUDITORIUM_CAPACITY=89;
--------------------- t1 ---------------------
--------------------- t2 ---------------------
rollback;

-- 5
-- A --
set transaction isolation level READ COMMITTED
begin transaction
	select count(*) as [���-�� �����, ��� AUDITORIUM_CAPACITY=100]
	from AUDITORIUM
	where AUDITORIUM_CAPACITY=100;
--------------------- t1 ---------------------
--------------------- t2 ---------------------
	select 'update AUDITORIUM''���������',  
		count(*) as [���-�� �����, ��� AUDITORIUM_CAPACITY=100]
	from AUDITORIUM
	where AUDITORIUM_CAPACITY=100;
commit;
-- B --
begin transaction
--------------------- t1 ---------------------
		update AUDITORIUM set AUDITORIUM_CAPACITY=100
			where AUDITORIUM_CAPACITY=89;
commit;
--------------------- t2 ---------------------

-- 6
-- A --
set transaction isolation level REPEATABLE READ
begin tran
select AUDITORIUM from AUDITORIUM 
where AUDITORIUM='666-6';
--------------------- t1 ---------------------
--------------------- t2 ---------------------
	select 
		(case 
			when AUDITORIUM='666-6'
				then 'inser AUDITORIUM'
			else ''
		end) + ' ���������',
		* 
	from AUDITORIUM 
	where AUDITORIUM='666-6';
commit;
-- B --
set transaction isolation level READ COMMITTED
begin tran
--------------------- t1 ---------------------
	insert AUDITORIUM values('666-6', '��', 66, '666-6');
commit;
--------------------- t2 ---------------------

-- 7
-- A --
set tran isolation level SERIALIZABLE
begin tran
	delete AUDITORIUM where AUDITORIUM='171-7';
	insert AUDITORIUM values('555-5', '��', 17, '555-5');
	update AUDITORIUM set AUDITORIUM_NAME='*' 
		where AUDITORIUM='555-5';

	select * 
	from AUDITORIUM 
	where AUDITORIUM='555-5';
--------------------- t1 ---------------------
	select * 
	from AUDITORIUM 
	where AUDITORIUM='555-5';
--------------------- t2 ---------------------
commit;

-- B --
set tran isolation level READ COMMITTED
begin tran
	delete AUDITORIUM where AUDITORIUM='555-5';
	insert AUDITORIUM values('555-5', '��', 17, '555-5');
	update AUDITORIUM set AUDITORIUM_NAME='*' 
		where AUDITORIUM='555-5';

	select * 
	from AUDITORIUM 
	where AUDITORIUM='555-5';
--------------------- t1 ---------------------
commit;

select * 
from AUDITORIUM 
where AUDITORIUM='555-5';
--------------------- t2 ---------------------

-- 8
set nocount on;

begin tran -- ������� ����������
	insert AUDITORIUM values('!', '��',17, '!');

	begin tran -- ��������� ����������
		update AUDITORIUM set AUDITORIUM_NAME='gtl-wereeeeeewqq'
		where AUDITORIUM_NAME='*';
	commit; -- ��������� ����������
rollback; -- ������� ����������

select * from AUDITORIUM;

