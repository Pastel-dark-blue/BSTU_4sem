use UNIVERSITY;
--	1
-- �� ������ ������ PULPIT � PROFESSION
select PULPIT_NAME
	from PULPIT
	where PULPIT.FACULTY in (select FACULTY from PROFESSION
							where (PROFESSION_NAME like '%����������%' 
							or 
							PROFESSION_NAME like'%����������%'));

-- �� ������ ������ PULPIT, FACULTY � PROFESSION
select PULPIT_NAME
	from PULPIT, FACULTY
	where FACULTY.FACULTY = PULPIT.FACULTY
	and
	PULPIT.FACULTY in (select FACULTY from PROFESSION
							where (PROFESSION_NAME like '%����������%' 
							or 
							PROFESSION_NAME like'%����������%'));

--	2
select PULPIT_NAME
	from PULPIT join FACULTY 
	on FACULTY.FACULTY = PULPIT.FACULTY
	and
	PULPIT.FACULTY in (select FACULTY from PROFESSION
							where (PROFESSION_NAME like '%����������%' 
							or 
							PROFESSION_NAME like'%����������%'));

--	3
select PULPIT_NAME, FACULTY_NAME, PROFESSION_NAME
	from PULPIT join FACULTY 
	on FACULTY.FACULTY = PULPIT.FACULTY
	join PROFESSION
	on PROFESSION.FACULTY = PULPIT.FACULTY
	and (PROFESSION_NAME like '%����������%' 
							or 
							PROFESSION_NAME like'%����������%');

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
		where SUBJECT like '����'), '0') as [������� ���� �� ����],
	isnull((select avg(NOTE) from PROGRESS
		where SUBJECT like '��'), '0') as [������� ���� �� ��],
	isnull((select avg(NOTE) from PROGRESS
		where SUBJECT like '����'), '0') as [������� ���� �� ����] 
from PROGRESS;

--	7 ������ ��������� �� ������� ������ ���� �������� �� ���� ���������
select STUDENT.NAME, 
	STUDENT.IDSTUDENT, 
	avg(PROGRESS.NOTE) AS [������� ���� �� ���� ���������]
	from STUDENT inner join PROGRESS
	on STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
	where PROGRESS.NOTE >=ALL (
		select avg(PROGRESS.NOTE)
		from PROGRESS
	)
group by STUDENT.NAME, STUDENT.IDSTUDENT;

--	8 ������� ��������������, ������� ��������� ��������, ��� ������� �������� �� ������ "����������������" � ��������
select * 
	from TEACHER
	where TEACHER.PULPIT =any (
		select SUBJECT.PULPIT
		from SUBJECT
		where SUBJECT_NAME like '%����������������%');

