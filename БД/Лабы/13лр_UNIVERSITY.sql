use UNIVERSITY;

-- 1
go
-- �������� �������
create function COUNT_STUDENTS 
						(@faculty varchar(20))
						returns int
as
begin
	declare @amountOfStudents int = 
		(select count(*)
			from FACULTY inner join GROUPS
			on FACULTY.FACULTY = GROUPS.FACULTY
			inner join STUDENT
			on GROUPS.IDGROUP = STUDENT.IDGROUP
			where FACULTY.FACULTY = @faculty);

	return @amountOfStudents;
end;

-- ����������
declare @fac varchar(20) = '����';
declare @amountOfFacStud int = dbo.COUNT_STUDENTS(@fac);
print '���-�� ��������� �� ������� ' + @fac + ': ' + cast(@amountOfFacStud as varchar);

-- �������� �������
go
alter function dbo.COUNT_STUDENTS 
						(@faculty varchar(20) = null, 
						@prof varchar(20) = null)
						returns int
as
begin
	declare @amountOfStudents int = 
		(select count(*)
			from FACULTY f	inner join PROFESSION p on f.FACULTY=p.FACULTY
							inner join GROUPS g on p.PROFESSION=g.PROFESSION
							inner join STUDENT s on g.IDGROUP=s.IDGROUP
			where	f.FACULTY=isnull(@faculty, f.FACULTY)
					and
					p.PROFESSION=isnull(@prof, p.PROFESSION));

	return @amountOfStudents;
end;

-- ����� ������� ��� ������ select
select distinct f.FACULTY as [���������],
				p.PROFESSION as [�������������],
				dbo.COUNT_STUDENTS(f.FACULTY, p.PROFESSION) as [���-�� ��������� �� ����������]
	from FACULTY f inner join PROFESSION p on f.FACULTY=p.FACULTY
	group by f.FACULTY, p.PROFESSION

-- ����� ������� � ������������� �������� �� ��������� ��� ������� ��������
select distinct FACULTY as [���������],
				dbo.COUNT_STUDENTS(FACULTY, default) as [���-�� ��������� �� ����������]
	from FACULTY 


-- 2
go
create function FSUBJECTS (@p varchar(20)) returns varchar(300)
as
begin
	declare @subject varchar(10),
			@allSubjects varchar(300) = '����������: ';

	declare subjectsOnPulpitCur cursor local static
	for 
		select SUBJECT 
		from SUBJECT 
		where PULPIT=@p;

	open subjectsOnPulpitCur;
		fetch subjectsOnPulpitCur into @subject;

		while @@fetch_status = 0
			begin
				set @allSubjects=@allSubjects + ', ' + rtrim(@subject);
				fetch subjectsOnPulpitCur into @subject;
			end;
	close subjectsOnPulpitCur;

	return @allSubjects;
end;

select	PULPIT as [��� �������],
		dbo.FSUBJECTS(PULPIT) as [����������]
from PULPIT

-- 3
go
create function FFACPUL (@fac varchar(20), @pul varchar(20)) returns table
as return
	select	PULPIT as [�������],
			FACULTY as [���������]
	from PULPIT 
	where PULPIT = isnull(@pul, PULPIT)
	and 
	FACULTY = isnull(@fac, FACULTY);

select * from dbo.FFACPUL('���', '��')
select * from dbo.FFACPUL('���', null)
select * from dbo.FFACPUL(null, '��')
select * from dbo.FFACPUL(null, null)

-- 4
go
create function FCTEACHER (@pul varchar(20)) returns int
as 
begin
	return 
		(select count(*) 
		from TEACHER
		where PULPIT=isnull(@pul, PULPIT))
end;

select	dbo.FCTEACHER(null) as [���-�� ��������������];

select	PULPIT as [��� �������],
		dbo.FCTEACHER(PULPIT) as [���-�� ��������������]
		from PULPIT;

-- 6
-- ��������� ������� ��� �������� ���-�� ������ �� ���������� @fac
go
create function countPulpits(@fac varchar(20)) returns int
as 
begin
	return (select count(PULPIT) from PULPIT where FACULTY = @fac)
end;

-- ��������� ������� ��� �������� ���-�� ����� �� ���������� @fac
go
create function countGroups(@fac varchar(20)) returns int
as 
begin
	return (select count(IDGROUP) from GROUPS where FACULTY = @fac)
end;

-- ��������� ������� ��� �������� ���-�� ��������� �� ���������� @fac
go
create function countStudents(@fac varchar(20)) returns int
as 
begin
	return (
		select count(IDSTUDENT) 
		from STUDENT inner join GROUPS
		on STUDENT.IDGROUP=GROUPS.IDGROUP
		where FACULTY = @fac
	)
end;

-- ��������� ������� ��� �������� ���-�� �������������� �� ���������� @fac
go
create function countProf(@fac varchar(20)) returns int
as 
begin
	return (select count(PROFESSION) from PROFESSION where FACULTY = @fac)
end;

-- �������� ������������� ������� � ������
go
create function FACULTY_REPORT(@c int) returns @fr table
	        ( [���������] varchar(50), [���������� ������] int, [���������� �����]  int, 
	        [���������� ���������] int, [���������� ��������������] int )
	as begin 
        declare cc CURSOR static for 
		-- �������� �� ������� FACULTY ��� ����������, �� �-��� ���-�� ��������� ������ ��������� @c ������ �������
	    select FACULTY from FACULTY 
			where dbo.countStudents(FACULTY) > @c; 

	    declare @f varchar(30);

		open cc;  
			fetch cc into @f;
			while @@fetch_status = 0
			begin
				-- ��������� ������ � �������, �-��� ����� ����������
				insert @fr values(
					@f,		-- ���������, ��� ��������� ������ @c
					dbo.countPulpits(@f),		-- ���-�� ������ �� ���������� @f
					dbo.countGroups(@f),		-- ���-�� ����� �� ���������� @f
					dbo.countStudents(@f),	-- ���-�� ��������� �� ���������� @f
					dbo.countProf(@f)   -- ���-�� �������������� �� ���������� @f
				); 
				fetch cc into @f;  
			end;  
		
        return; 
	end;

select * from dbo.FACULTY_REPORT(0);