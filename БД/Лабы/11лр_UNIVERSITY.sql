-- 1
set nocount on;

-- если таблица #tempTable сущетсвует - удаляем её
use tempdb;
if exists (select * from sys.objects
			where object_id=object_id('dbo.#tempTable'))
drop table #tempTable;

declare @amountOfRows int;

set implicit_transactions on;	-- вкл режим неявной транзакции
-- начало транзакции
create table #tempTable(number int);
insert #tempTable values (1),
						 (2),
						 (3);

set @amountOfRows = (select count(*) from #tempTable);

print 'Кол-во строк в таблице #tempTable : ' + cast(@amountOfRows as varchar(2));

commit; -- завершение транзакции: фиксация
-- rollback; -- завершение транзакции: откат

set implicit_transactions off;	-- выкл режим неявной транзакции

if exists(select * from sys.objects
		  where object_id=object_id('dbo.#tempTable'))
	print 'Таблица #tempTable существует';
else 
		print 'Таблица #tempTable НЕ существует';

-- 2
use UNIVERSITY;
begin try
	begin tran;
		insert AUDITORIUM values('000-1', 'ЛК', 89, '000-1');
		insert AUDITORIUM values(null, 'ЛК', 89, 'null');	-- ошибка, т.к. первый столбец - первичный ключ
	commit tran;
end try
begin catch
	print 'Ошибка : ' + cast(error_number() as varchar(5)) + char(10) + error_message();
	if @@trancount > 0 rollback tran; -- откат вложенной транзакции
end catch;

-- 3
use UNIVERSITY;
declare @point varchar(32);

begin try
	begin tran
		insert AUDITORIUM values('000-1', 'ЛК', 89, '000-1');
		set @point = 'p1';	-- промежуточная точка сохранения
		save tran @point; 
		insert AUDITORIUM values(null, 'ЛК', 89, 'null');	-- ошибка, т.к. первый столбец - первичный ключ
	commit tran
end try
begin catch
	print 'Ошибка : ' + cast(error_number() as varchar(5)) + char(10) + error_message();
	if @@trancount > 0 
		begin
			print 'Контрольная точка : ' + @point;
			rollback tran @point; -- откат к контрольной точке
			commit tran; -- фиксация изменений до контрольной точки
		end;
end catch

-- 4
use UNIVERSITY;
-- A --
set transaction isolation level READ UNCOMMITTED
begin tran
--------------------- t1 ---------------------
	select	@@spid as [id A (insert)], 
			'insert AUDITORIUM''результат', 
			*
		from AUDITORIUM 
		where AUDITORIUM='111-1';

	select	@@spid as [id A (update)], 
			'update AUDITORIUM''результат', 
			*
		from AUDITORIUM
		where AUDITORIUM_CAPACITY=100;
commit;
--------------------- t2 ---------------------
-- B --
begin tran
	select @@spid as [id B];
	insert AUDITORIUM values('111-1', 'ЛК', 89, '111-1');
	update AUDITORIUM set AUDITORIUM_CAPACITY=100
			where AUDITORIUM_CAPACITY=89;
--------------------- t1 ---------------------
--------------------- t2 ---------------------
rollback;

-- 5
-- A --
set transaction isolation level READ COMMITTED
begin transaction
	select count(*) as [кол-во строк, где AUDITORIUM_CAPACITY=100]
	from AUDITORIUM
	where AUDITORIUM_CAPACITY=100;
--------------------- t1 ---------------------
--------------------- t2 ---------------------
	select 'update AUDITORIUM''результат',  
		count(*) as [кол-во строк, где AUDITORIUM_CAPACITY=100]
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
		end) + ' результат',
		* 
	from AUDITORIUM 
	where AUDITORIUM='666-6';
commit;
-- B --
set transaction isolation level READ COMMITTED
begin tran
--------------------- t1 ---------------------
	insert AUDITORIUM values('666-6', 'ЛК', 66, '666-6');
commit;
--------------------- t2 ---------------------

-- 7
-- A --
set tran isolation level SERIALIZABLE
begin tran
	delete AUDITORIUM where AUDITORIUM='171-7';
	insert AUDITORIUM values('555-5', 'ЛК', 17, '555-5');
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
	insert AUDITORIUM values('555-5', 'ЛК', 17, '555-5');
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

begin tran -- внешняя транзакция
	insert AUDITORIUM values('!', 'ЛК',17, '!');

	begin tran -- внутрення транзакция
		update AUDITORIUM set AUDITORIUM_NAME='gtl-wereeeeeewqq'
		where AUDITORIUM_NAME='*';
	commit; -- внутрення транзакция
rollback; -- внешняя транзакция

select * from AUDITORIUM;

