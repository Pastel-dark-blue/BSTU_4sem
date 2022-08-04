use UNIVERSITY;

-- 1
-- �������� ���������
go -- ������� CREATE PROCEDURE ������ ���������� � ��������� ������
create procedure PSUBJECT
as 
begin
select	SUBJECT as [���],
			SUBJECT_NAME as [����������],
			PULPIT as [�������]
	from SUBJECT

	return @@rowcount; -- ����� ������������ �����
end;

-- ����������
go
declare @result_1 int;
exec @result_1 = PSUBJECT;
print '���������� �����: ' + convert(varchar(20), (@result_1));

-- 2
-- ������ ��������� � ������ ���������
go
alter procedure [dbo].[PSUBJECT] 
		@p varchar(20) = null, -- ������� ��������, �� ��������� ����� null
		@c int output -- �������� ��������
as
begin
	select	SUBJECT as [���],
			SUBJECT_NAME as [����������],
			PULPIT as [�������]
	from SUBJECT
	where SUBJECT = @p;

	set @c = @@rowcount; -- ���-�� ������������ ����� (����� � �������������� ������)

	return (select count(*) from SUBJECT); -- ���-�� ����� � ������� SUBJECT
end;

-- ������������� ���������
go
set nocount on;
declare @result_2 int,
		@p varchar(20),
		@outputParam int;

exec @result_2 = PSUBJECT 
						@p = '��', 
						@c = @outputParam output;

print '���������� �����: ' + cast(@result_2 as varchar);
print '���������� ���������: ' + cast(@outputParam as varchar);

-- 3
-- ������ ��������� � ������ ���������
go
alter procedure [dbo].[PSUBJECT] 
		@p varchar(20) = null
as
begin
	select	SUBJECT as [���],
			SUBJECT_NAME as [����������],
			PULPIT as [�������]
	from SUBJECT
	where SUBJECT = @p;
end;

-- ������� ��������� �������
create table #SUBJECT (
	��� char(10),
	���������� varchar(100),
	������� char(20),
);

-- ������������� ��������� ��� ���������� �����
insert #SUBJECT exec PSUBJECT '��';

select * from #SUBJECT;

-- 4
-- ���������
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
	print '��� ���������� ��������� ��������� ������.';
	print '��� ������: ' + cast(error_number() as varchar);
	print '������� �����������: ' + cast(error_severity() as varchar);
	print '����� ������: ' + error_message();
	return -1;
end catch;	

-- ����������
declare @result_4 int;
exec @result_4 = PAUDITORIUM_INSERT '222-1',
									'222-1',
									36,
									'��';
print '��������� �������: ' + cast(@result_4 as varchar)

-- 5
go
-- ������� ���������
create procedure SUBJECT_REPORT @p char(10)
as
begin try
	declare @sub varchar(10), 
			@allSubjects varchar(200) = '',
			@amountOfSubjects int = 0;

	-- ������� ������
		declare subjectsCur cursor local 
		for
			select SUBJECT from SUBJECT
				where PULPIT = @p;

	-- ���� ��� ��������� �� ������� @p, ������ ������
	if not exists (select SUBJECT from SUBJECT
				where PULPIT = @p)
			raiserror('������ � ����������', 11, 1);

	-- ��������� ����������
	print '���������� �� ������� ' + ltrim(rtrim(@p)) + ': ';
	open subjectsCur
		fetch subjectsCur into @sub
		while @@fetch_status = 0
			begin
				set @allSubjects = rtrim(@sub) + ', ' + @allSubjects;
				set @amountOfSubjects += 1;

				fetch subjectsCur into @sub; 
			end;
	close subjectsCur;

	-- ��������� �������� ����� ������� - ������� �
	print substring(@allSubjects, 1, len(@allSubjects) - 1);

	return @amountOfSubjects;
end try
begin catch
	print '��������� ������.';
	print '����� ������: ' + error_message();
	if error_procedure() is not null
		print '��� ���������: ' + error_procedure();

	return -1;
end catch;

-- �������������
declare @result_5 int, @pulpit varchar(20) = 'Gtl';
exec @result_5 = SUBJECT_REPORT @pulpit;
print '���-�� ���������� �� ������� ' + @pulpit + ': ' + cast(@result_5 as varchar(15));

-- 6
-- �������� ���������
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
	print '��������� ������.';
	print '����� ������: ' + error_message();
	if error_procedure() is not null
			print '��� ���������: ' + error_procedure();

	if @@trancount > 0
			rollback;

	return -1;
end catch;

-- �������������
set nocount on
go
declare @result_6 int;

declare @aud char(20) = '000-0',
		@aud_name varchar(50) = '000-0',
		@aud_cap int = 100,
		@aud_type char(10) = '��',
		@aud_type_name varchar(30) = '������� ������';

exec @result_6 = PAUDITORIUM_INSERTX @aud, @aud_name, @aud_cap, @aud_type, @aud_type_name;

print '��������� �������: ' + cast(@result_6 as varchar);