use UNIVERSITY;

-- 1
go
-- создание функции
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

-- выполнение
declare @fac varchar(20) = 'ХТиТ';
declare @amountOfFacStud int = dbo.COUNT_STUDENTS(@fac);
print 'Кол-во студентов на кафедре ' + @fac + ': ' + cast(@amountOfFacStud as varchar);

-- изменяем функцию
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

-- вызов функции при помощи select
select distinct f.FACULTY as [факультет],
				p.PROFESSION as [специальности],
				dbo.COUNT_STUDENTS(f.FACULTY, p.PROFESSION) as [кол-во студентов на факультете]
	from FACULTY f inner join PROFESSION p on f.FACULTY=p.FACULTY
	group by f.FACULTY, p.PROFESSION

-- вызов функции с использование значения по умолчанию для сторого парметра
select distinct FACULTY as [факультет],
				dbo.COUNT_STUDENTS(FACULTY, default) as [кол-во студентов на факультете]
	from FACULTY 


-- 2
go
create function FSUBJECTS (@p varchar(20)) returns varchar(300)
as
begin
	declare @subject varchar(10),
			@allSubjects varchar(300) = 'Дисциплины: ';

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

select	PULPIT as [Код кафедры],
		dbo.FSUBJECTS(PULPIT) as [Дисциплины]
from PULPIT

-- 3
go
create function FFACPUL (@fac varchar(20), @pul varchar(20)) returns table
as return
	select	PULPIT as [Кафедра],
			FACULTY as [Факультет]
	from PULPIT 
	where PULPIT = isnull(@pul, PULPIT)
	and 
	FACULTY = isnull(@fac, FACULTY);

select * from dbo.FFACPUL('ТОВ', 'ОХ')
select * from dbo.FFACPUL('ТОВ', null)
select * from dbo.FFACPUL(null, 'ОХ')
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

select	dbo.FCTEACHER(null) as [Кол-во преподавателей];

select	PULPIT as [Код кафедры],
		dbo.FCTEACHER(PULPIT) as [Кол-во преподавателей]
		from PULPIT;

-- 6
-- скалярная функция для подсчета кол-ва кафедр на факультете @fac
go
create function countPulpits(@fac varchar(20)) returns int
as 
begin
	return (select count(PULPIT) from PULPIT where FACULTY = @fac)
end;

-- скалярная функция для подсчета кол-ва групп на факультете @fac
go
create function countGroups(@fac varchar(20)) returns int
as 
begin
	return (select count(IDGROUP) from GROUPS where FACULTY = @fac)
end;

-- скалярная функция для подсчета кол-ва студентов на факультете @fac
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

-- скалярная функция для подсчета кол-ва специальностей на факультете @fac
go
create function countProf(@fac varchar(20)) returns int
as 
begin
	return (select count(PROFESSION) from PROFESSION where FACULTY = @fac)
end;

-- вызываем вышесозданные функции в данной
go
create function FACULTY_REPORT(@c int) returns @fr table
	        ( [Факультет] varchar(50), [Количество кафедр] int, [Количество групп]  int, 
	        [Количество студентов] int, [Количество специальностей] int )
	as begin 
        declare cc CURSOR static for 
		-- выбираем из таблицы FACULTY все факультеты, на к-рых кол-во студентов больше параметра @c данной функции
	    select FACULTY from FACULTY 
			where dbo.countStudents(FACULTY) > @c; 

	    declare @f varchar(30);

		open cc;  
			fetch cc into @f;
			while @@fetch_status = 0
			begin
				-- вставляем записи в таблицу, к-рую будем возвращать
				insert @fr values(
					@f,		-- факультет, где студентов больше @c
					dbo.countPulpits(@f),		-- кол-во кафедр на факультете @f
					dbo.countGroups(@f),		-- кол-во групп на факультете @f
					dbo.countStudents(@f),	-- кол-во студентов на факультете @f
					dbo.countProf(@f)   -- кол-во специальностей на факультете @f
				); 
				fetch cc into @f;  
			end;  
		
        return; 
	end;

select * from dbo.FACULTY_REPORT(0);