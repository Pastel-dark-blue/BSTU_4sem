use UNIVERSITY;
--	1
-- на основе таблиц PULPIT и PROFESSION
select PULPIT_NAME
	from PULPIT
	where PULPIT.FACULTY in (select FACULTY from PROFESSION
							where (PROFESSION_NAME like '%технология%' 
							or 
							PROFESSION_NAME like'%технологии%'));

-- на основе таблиц PULPIT, FACULTY и PROFESSION
select PULPIT_NAME
	from PULPIT, FACULTY
	where FACULTY.FACULTY = PULPIT.FACULTY
	and
	PULPIT.FACULTY in (select FACULTY from PROFESSION
							where (PROFESSION_NAME like '%технология%' 
							or 
							PROFESSION_NAME like'%технологии%'));

--	2
select PULPIT_NAME
	from PULPIT join FACULTY 
	on FACULTY.FACULTY = PULPIT.FACULTY
	and
	PULPIT.FACULTY in (select FACULTY from PROFESSION
							where (PROFESSION_NAME like '%технология%' 
							or 
							PROFESSION_NAME like'%технологии%'));

--	3
select PULPIT_NAME, FACULTY_NAME, PROFESSION_NAME
	from PULPIT join FACULTY 
	on FACULTY.FACULTY = PULPIT.FACULTY
	join PROFESSION
	on PROFESSION.FACULTY = PULPIT.FACULTY
	and (PROFESSION_NAME like '%технология%' 
							or 
							PROFESSION_NAME like'%технологии%');

--	4
select *
	from AUDITORIUM as a
		where a.AUDITORIUM = (
			select top(1) b.AUDITORIUM
			from AUDITORIUM as b
			where b.AUDITORIUM_TYPE = a.AUDITORIUM_TYPE
			order by b.AUDITORIUM_CAPACITY desc
		)
	order by a.AUDITORIUM_CAPACITY desc;

--	5
select FACULTY_NAME
	from FACULTY
	where exists (select FACULTY from PULPIT 
		where FACULTY.FACULTY = PULPIT.FACULTY);

--	6
select top(1)
	isnull((select avg(NOTE) from PROGRESS
		where SUBJECT like 'ОАиП'), '0') as [Средний балл по ОАиП],
	isnull((select avg(NOTE) from PROGRESS
		where SUBJECT like 'БД'), '0') as [Средний балл по БД],
	isnull((select avg(NOTE) from PROGRESS
		where SUBJECT like 'СУБД'), '0') as [Средний балл по СУБД] 
from PROGRESS;

--	7 найдем студентов со средним баллом выше среднего по всем предметам
select STUDENT.NAME, 
	STUDENT.IDSTUDENT, 
	avg(PROGRESS.NOTE) AS [Средний балл по всем предметам]
	from STUDENT inner join PROGRESS
	on STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
	where PROGRESS.NOTE >=ALL (
		select avg(PROGRESS.NOTE)
		from PROGRESS
	)
group by STUDENT.NAME, STUDENT.IDSTUDENT;

--	8 выбрать преподавателей, которые преподают кафедрах, где ведутся предметы со словом "программирование" в названии
select * 
	from TEACHER
	where TEACHER.PULPIT =any (
		select SUBJECT.PULPIT
		from SUBJECT
		where SUBJECT_NAME like '%программирование%');

