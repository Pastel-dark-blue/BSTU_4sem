use UNIVERSITY;

-- 1
go
create view [Преподаватель] as
select * from TEACHER;

-- 2
go
create view [Количество кафедр] as
select	FACULTY.FACULTY_NAME as [факультет],
		count(PULPIT.PULPIT) as [количество кафедр]
		from FACULTY inner join PULPIT
		on FACULTY.FACULTY = PULPIT.FACULTY
		group by FACULTY.FACULTY_NAME;

-- 3
go
create view [Аудитории]([код], [наименование аудитории]) as
select	AUDITORIUM,
		AUDITORIUM_NAME
	from AUDITORIUM
	where AUDITORIUM_TYPE like 'ЛК%';

-- 4
go
create view Лекционные_аудитории as
	select	AUDITORIUM,
		AUDITORIUM_NAME
	from AUDITORIUM
	where AUDITORIUM_TYPE like 'ЛК%'
	with check option;

-- 5
go
create view Дисциплины(код, [наименование дисциплины], [код кафедры]) as
	select	top 20 
			SUBJECT, SUBJECT_NAME, PULPIT
	from SUBJECT
	order by SUBJECT_NAME;

-- 6
go
alter view dbo.[Количество кафедр] with schemabinding
as
select	FACULTY.FACULTY_NAME as [факультет],
		count(PULPIT.PULPIT) as [количество кафедр]
		from dbo.FACULTY inner join dbo.PULPIT
		on FACULTY.FACULTY = PULPIT.FACULTY
		group by FACULTY.FACULTY_NAME;

-- попробуем удалить столбец из таблицы FACULTY, но нам это не удастся из-за опции "with schemabinding"
go
alter table FACULTY
drop column FACULTY_NAME;
