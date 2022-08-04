use UNIVERSITY;

-- 1
-- создание процедуры
go -- команда CREATE PROCEDURE должна вызываться в отдельном пакете
create procedure PSUBJECT
as 
begin
select	SUBJECT as [код],
			SUBJECT_NAME as [дисциплина],
			PULPIT as [кафедра]
	from SUBJECT

	return @@rowcount; -- число обработанных строк
end;

-- выполнение
go
declare @result_1 int;
exec @result_1 = PSUBJECT;
print 'Количество строк: ' + convert(varchar(20), (@result_1));

-- 2
-- вносим изменения в скрипт процедуры
go
alter procedure [dbo].[PSUBJECT] 
		@p varchar(20) = null, -- входной параметр, по умолчанию равен null
		@c int output -- выходной параметр
as
begin
	select	SUBJECT as [код],
			SUBJECT_NAME as [дисциплина],
			PULPIT as [кафедра]
	from SUBJECT
	where SUBJECT = @p;

	set @c = @@rowcount; -- кол-во обработанных строк (строк в результирующем наборе)

	return (select count(*) from SUBJECT); -- кол-во строк в таблице SUBJECT
end;

-- использование процедуры
go
set nocount on;
declare @result_2 int,
		@p varchar(20),
		@outputParam int;

exec @result_2 = PSUBJECT 
						@p = 'БД', 
						@c = @outputParam output;

print 'Количество строк: ' + cast(@result_2 as varchar);
print 'Количество предметов: ' + cast(@outputParam as varchar);

-- 3
-- вносим изменения в скрипт процедуры
go
alter procedure [dbo].[PSUBJECT] 
		@p varchar(20) = null
as
begin
	select	SUBJECT as [код],
			SUBJECT_NAME as [дисциплина],
			PULPIT as [кафедра]
	from SUBJECT
	where SUBJECT = @p;
end;

-- создаем временную таблицу
create table #SUBJECT (
	код char(10),
	дисциплина varchar(100),
	кафедра char(20),
);

-- использование процедуры для добавления строк
insert #SUBJECT exec PSUBJECT 'ох';

select * from #SUBJECT;

-- 4
-- процедура
go
create procedure PAUDITORIUM_INSERT
						@a char(20),
						@n varchar(50),
						@c int = 0,
						@t char(10)
as
begin try
	insert into AUDITORIUM (AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_CAPACITY, AUDITORIUM_TYPE)
					values(@a, @n, @c, @t);
	return 1;
end try
begin catch
	print 'При выполнении процедуры произошла ошибка.';
	print 'Код ошибки: ' + cast(error_number() as varchar);
	print 'Уровень серьезности: ' + cast(error_severity() as varchar);
	print 'Текст ошибки: ' + error_message();
	return -1;
end catch;	

-- выполнение
declare @result_4 int;
exec @result_4 = PAUDITORIUM_INSERT '222-1',
									'222-1',
									36,
									'ЛК';
print 'Процедура вернула: ' + cast(@result_4 as varchar)

-- 5
go
-- создаем процедуру
create procedure SUBJECT_REPORT @p char(10)
as
begin try
	declare @sub varchar(10), 
			@allSubjects varchar(200) = '',
			@amountOfSubjects int = 0;

	-- создаем курсор
		declare subjectsCur cursor local 
		for
			select SUBJECT from SUBJECT
				where PULPIT = @p;

	-- если нет дисциплин на кафедре @p, кидаем ошибку
	if not exists (select SUBJECT from SUBJECT
				where PULPIT = @p)
			raiserror('ошибка в параметрах', 11, 1);

	-- считываем дисциплины
	print 'Дисциплины на кафедре ' + ltrim(rtrim(@p)) + ': ';
	open subjectsCur
		fetch subjectsCur into @sub
		while @@fetch_status = 0
			begin
				set @allSubjects = rtrim(@sub) + ', ' + @allSubjects;
				set @amountOfSubjects += 1;

				fetch subjectsCur into @sub; 
			end;
	close subjectsCur;

	-- последним символом будет запятая - удаляем её
	print substring(@allSubjects, 1, len(@allSubjects) - 1);

	return @amountOfSubjects;
end try
begin catch
	print 'Произошла ошибка.';
	print 'Текст ошибки: ' + error_message();
	if error_procedure() is not null
		print 'Имя процедуры: ' + error_procedure();

	return -1;
end catch;

-- использование
declare @result_5 int, @pulpit varchar(20) = 'Gtl';
exec @result_5 = SUBJECT_REPORT @pulpit;
print 'Кол-во дисциплина на кафедре ' + @pulpit + ': ' + cast(@result_5 as varchar(15));

-- 6
-- создание процедуры
go
create procedure PAUDITORIUM_INSERTX
						@a char(20),
						@n varchar(50),
						@c int = 0,
						@t char(10),
						@tn varchar(50)
as

begin try
	set tran isolation level SERIALIZABLE
	begin tran
		declare @res int = 1;
		insert into AUDITORIUM_TYPE (AUDITORIUM_TYPE, AUDITORIUM_TYPENAME)
					values(@t, @tn);
		exec @res = PAUDITORIUM_INSERT @a, @n, @c, @t;

	commit tran
	return @res;
end try
begin catch
	print 'Произошла ошибка.';
	print 'Текст ошибки: ' + error_message();
	if error_procedure() is not null
			print 'Имя процедуры: ' + error_procedure();

	if @@trancount > 0
			rollback;

	return -1;
end catch;

-- использование
set nocount on
go
declare @result_6 int;

declare @aud char(20) = '000-0',
		@aud_name varchar(50) = '000-0',
		@aud_cap int = 100,
		@aud_type char(10) = 'КО',
		@aud_type_name varchar(30) = 'Комната отдыха';

exec @result_6 = PAUDITORIUM_INSERTX @aud, @aud_name, @aud_cap, @aud_type, @aud_type_name;

print 'Процедура вернула: ' + cast(@result_6 as varchar);