-- 1
declare @symbol char(1) = '*',
		@str nvarchar(65) = '� ����� ����, ��� ������ �����, �� ���� ������������',
		@currentDatetime datetime,
		@currentHour time,
		@number int,
		@tinyNumber tinyint,
		@numericNumber numeric(12,5);

set @currentDatetime = getdate();
set @number = (select count(*) from FACULTY);

select	@currentHour = cast(datepart(hour, getdate()) as datetime),
		@tinyNumber = 1;

select	@symbol as [������],
		@str as [������],
		@currentDatetime as [������� ���� � �����],
		@currentHour as [������� ���?],
		@numericNumber numericNumber;

-- char(10) - ������� ������
print	'����� : ' + cast(@number as varchar(10)) + char(10) +
		'����� �������� : ' + cast(@tinyNumber as varchar(10));

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
				select count(*) as [���-�� ���.]
				from AUDITORIUM
			);

		set @avgAuditCapacity = (
				select cast(avg(AUDITORIUM_CAPACITY) as float(10)) as [����. ����������� ���.]
				from AUDITORIUM
			);

		set @lessAvgAuditAmount = (
				select count(*) as [���-�� ���. ����������� ������ ����.]
				from AUDITORIUM
				where AUDITORIUM_CAPACITY < @avgAuditCapacity
			);

		set @lessAvgPercent = cast((@lessAvgAuditAmount * 100 / @amountOfAudit) as float(10));

-- ����� ���������� ��������
		print '����� ����������� ���� ��������� : ' + cast(@totalAuditoriumCapacity as varchar); 
		print '���-�� ��������� : ' + cast(@amountOfAudit as varchar); 
		print '������� ����������� ���� ��������� : ' + cast(@avgAuditCapacity as varchar); 
		print '���-�� ���������, ����������� ������� ������ ������� : ' + cast(@lessAvgAuditAmount as varchar); 
		print '������� ����� [���������� ������] ��������� : ' + cast(@lessAvgPercent as varchar); 
	
	END

ELSE 
	print '����� ����������� : ' + cast(@totalAuditoriumCapacity as varchar); 

-- 3
print '����� ������������ ����� : ' + cast(@@ROWCOUNT as varchar); 
print '������ SQL Server : ' + cast(@@VERSION as varchar);
print '��������� ������������� ��������, ����������� �������� �������� ����������� : ' + cast(@@SPID as varchar); 
print '��� ��������� ������ : ' + cast(@@ERROR as varchar); 
print '��� ������� : ' + cast(@@SERVERNAME as varchar); 
print '������� ����������� ���������� : ' + cast(@@TRANCOUNT as varchar); 
print '���������� ���������� ����� ��������������� ������ : ' + cast(@@FETCH_STATUS as varchar); 
print '������� ����������� ������� ��������� : ' + cast(@@NESTLEVEL as varchar); 

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
print '�������� ���������� z : ' + convert(varchar(10), @z);

-- 4.2
declare @fio varchar(50) = '���������� ����� ���������';
	set @fio = replace(@fio, '�����','�.');
	set @fio = replace(@fio, '���������','�.');
print '��� : ' + @fio;
	
-- 4.3
declare @currentDatePlusOneMonth datetime = dateadd(month, 1, getdate());

select	IDSTUDENT, 
		NAME, 
		BDAY, 
-- datediff(year, BDAY, @currentDatePlusOneMonth) ������ �������� �� ���� ���� currentDatePlusOneMonth ��� ���� BDAY 
-- �� �������� �� ������� ��������, � ������� ��� ��� ������ ���������� � ���� ����
-- ����� 
--	
--	case 
--		when datepart(dayofyear, @currentDatePlusOneMonth) > datepart(dayofyear, BDAY) then 0
--		else 1
--	end	
-- �������� �� ��, ����� ������ �� ���������� �������, ���� �� �������� ��� �� ���� � ���� ����
		datediff(
			year, 
			BDAY, 
			@currentDatePlusOneMonth) -
				case 
					when datepart(dayofyear, @currentDatePlusOneMonth) >= datepart(dayofyear, BDAY) then 0
					else 1
				end	
			as �������,
		@currentDatePlusOneMonth as [������� ���� + 1 �����]
from STUDENT
where datepart(month, BDAY) = datepart(month, @currentDatePlusOneMonth)

-- 4.4
select distinct
		SUBJECT, 
		PDATE, 
		datename(weekday, PDATE) as [���� ������]
from PROGRESS
where SUBJECT = '����';

-- 5
declare @avgAudCap float(10) = (
			select sum(AUDITORIUM_CAPACITY) 
			from AUDITORIUM
		);
if(@avgAudCap < 15)
	print '������� ����������� ��������� ������ 15'
else if(@avgAudCap = 15)
	print '������� ����������� ��������� ����� 15'
else
	print '������� ����������� ��������� ������ 15'
	
-- 6 
-- BETWEEN value1 AND value2 - �� value1 �� value2, ������� �������� �����!
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
set nocount on; -- �� �������� ��������� � ���������� �������

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
	print '����� : ' + @num;
end try
begin catch
	print '��� ������ : ' + convert(varchar, ERROR_NUMBER());
	print '��������� �� ������ : ' + convert(varchar, ERROR_MESSAGE());
	print '����� ������ ������������� ������ : ' + convert(varchar, ERROR_LINE());
	print '��� ��������� ��� NULL : ' + convert(varchar, ERROR_PROCEDURE());
	print '������� ����������� ������ : ' + convert(varchar, ERROR_SEVERITY());
	print '����� ��������� ������ : ' + convert(varchar, ERROR_STATE());
end catch

