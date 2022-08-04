-- 1
declare @symbol char(1) = '*',
		@str nvarchar(65) = 'Я решил жить, как падший ангел, то есть развращенным',
		@currentDatetime datetime,
		@currentHour time,
		@number int,
		@tinyNumber tinyint,
		@numericNumber numeric(12,5);

set @currentDatetime = getdate();
set @number = (select count(*) from FACULTY);

select	@currentHour = cast(datepart(hour, getdate()) as datetime),
		@tinyNumber = 1;

select	@symbol as [символ],
		@str as [строка],
		@currentDatetime as [текущие дата и время],
		@currentHour as [который час?],
		@numericNumber numericNumber;

-- char(10) - перенос строки
print	'Число : ' + cast(@number as varchar(10)) + char(10) +
		'Число поменьше : ' + cast(@tinyNumber as varchar(10));

-- 2
declare 
	@totalAuditoriumCapacity int = (
		select sum(AUDITORIUM_CAPACITY)
		from AUDITORIUM
	),
	@amountOfAudit int,
	@avgAuditCapacity float(10),
	@lessAvgAuditAmount int,
	@lessAvgPercent float(10);

IF @totalAuditoriumCapacity > 200
	BEGIN
		set @amountOfAudit = (
				select count(*) as [кол-во ауд.]
				from AUDITORIUM
			);

		set @avgAuditCapacity = (
				select cast(avg(AUDITORIUM_CAPACITY) as float(10)) as [сред. вместимость ауд.]
				from AUDITORIUM
			);

		set @lessAvgAuditAmount = (
				select count(*) as [кол-во ауд. вместимости меньше сред.]
				from AUDITORIUM
				where AUDITORIUM_CAPACITY < @avgAuditCapacity
			);

		set @lessAvgPercent = cast((@lessAvgAuditAmount * 100 / @amountOfAudit) as float(10));

-- вывод полученных значений
		print 'Общая вместимость всех аудиторий : ' + cast(@totalAuditoriumCapacity as varchar); 
		print 'Кол-во аудиторий : ' + cast(@amountOfAudit as varchar); 
		print 'Средняя вместимость всех аудиторий : ' + cast(@avgAuditCapacity as varchar); 
		print 'Кол-во аудиторий, вместимость которых меньше средней : ' + cast(@lessAvgAuditAmount as varchar); 
		print 'Процент таких [предыдущая строка] аудиторий : ' + cast(@lessAvgPercent as varchar); 
	
	END

ELSE 
	print 'Общая вместимость : ' + cast(@totalAuditoriumCapacity as varchar); 

-- 3
print 'Число обработанных строк : ' + cast(@@ROWCOUNT as varchar); 
print 'Версия SQL Server : ' + cast(@@VERSION as varchar);
print 'Системный идентификатор процесса, назначенный сервером текущему подключению : ' + cast(@@SPID as varchar); 
print 'Код последней ошибки : ' + cast(@@ERROR as varchar); 
print 'Имя сервера : ' + cast(@@SERVERNAME as varchar); 
print 'Уровень вложеннойти транзакции : ' + cast(@@TRANCOUNT as varchar); 
print 'Результата считывания строк результирующего набора : ' + cast(@@FETCH_STATUS as varchar); 
print 'Уровень вложенности текущей процедуры : ' + cast(@@NESTLEVEL as varchar); 

-- 4.1
declare @t int = 10,
		@x int = 7,
		@z float(10);
if(@t > @x)
	set @z = power(sin(@t), 2);
else if(@t < @x)
	set @z = 4 * (@t + @x);
else
	set @z = 1 - exp(@x -2);
print 'Значение переменной z : ' + convert(varchar(10), @z);

-- 4.2
declare @fio varchar(50) = 'Курносенко Софья Андреевна';
	set @fio = replace(@fio, 'Софья','С.');
	set @fio = replace(@fio, 'Андреевна','А.');
print 'ФИО : ' + @fio;
	
-- 4.3
declare @currentDatePlusOneMonth datetime = dateadd(month, 1, getdate());

select	IDSTUDENT, 
		NAME, 
		BDAY, 
-- datediff(year, BDAY, @currentDatePlusOneMonth) только отнимает от года даты currentDatePlusOneMonth год даты BDAY 
-- мы получаем не возраст человека, а сколько ему лет должно исполнится в этом году
-- часть 
--	
--	case 
--		when datepart(dayofyear, @currentDatePlusOneMonth) > datepart(dayofyear, BDAY) then 0
--		else 1
--	end	
-- отвечает за то, чтобы отнять от результата единицу, если ДР человека ещё не было в этом году
		datediff(
			year, 
			BDAY, 
			@currentDatePlusOneMonth) -
				case 
					when datepart(dayofyear, @currentDatePlusOneMonth) >= datepart(dayofyear, BDAY) then 0
					else 1
				end	
			as Возраст,
		@currentDatePlusOneMonth as [Текущая дата + 1 месяц]
from STUDENT
where datepart(month, BDAY) = datepart(month, @currentDatePlusOneMonth)

-- 4.4
select distinct
		SUBJECT, 
		PDATE, 
		datename(weekday, PDATE) as [День недели]
from PROGRESS
where SUBJECT = 'СУБД';

-- 5
declare @avgAudCap float(10) = (
			select sum(AUDITORIUM_CAPACITY) 
			from AUDITORIUM
		);
if(@avgAudCap < 15)
	print 'Средняя вместимость аудиторий меньше 15'
else if(@avgAudCap = 15)
	print 'Средняя вместимость аудиторий равна 15'
else
	print 'Средняя вместимость аудиторий больше 15'
	
-- 6 
-- BETWEEN value1 AND value2 - от value1 до value2, порядок значений важен!
select * 
from(
select case
			when PROGRESS.NOTE between 8 and 10 then 'Is everything ok with your health, sunny?'
			when PROGRESS.NOTE between 4 and 7 then 'Good kids'
			when PROGRESS.NOTE < 4 then 'Damn, bitch, you live like this (I don''t judge)'
		end as [Mark], 
		count(*) [Amount of students]
	from PROGRESS
	group by case
		when PROGRESS.NOTE between 8 and 10 then 'Is everything ok with your health, sunny?'
		when PROGRESS.NOTE between 4 and 7 then 'Good kids'
		when PROGRESS.NOTE < 4 then 'Damn, bitch, you live like this (I don''t judge)'
	end
) as T

-- 7
set nocount on; -- не выводить сообщения о затронутых строках

create table #tempLocTable(
	number1 int,
	dateTimeNow datetime,
	string varchar(10) 
);

declare @i int = 0;

while @i < 10
	begin
		insert #tempLocTable
			values(convert(int, rand())%10000, getdate(), 'Lika');
		set @i += 1;
	end;

select * from #tempLocTable;

-- 8
declare @value int = 1;
print @value + 1;
print @value + 2;
RETURN
print @value + 3;

-- 9
declare @num int = 9;
begin try
	print 'Число : ' + @num;
end try
begin catch
	print 'Код ошибки : ' + convert(varchar, ERROR_NUMBER());
	print 'Сообщение об ошибке : ' + convert(varchar, ERROR_MESSAGE());
	print 'Номер строки возникновения ошибки : ' + convert(varchar, ERROR_LINE());
	print 'Имя процедуры или NULL : ' + convert(varchar, ERROR_PROCEDURE());
	print 'Уровень серьезности ошибки : ' + convert(varchar, ERROR_SEVERITY());
	print 'Номер состояния ошибки : ' + convert(varchar, ERROR_STATE());
end catch

