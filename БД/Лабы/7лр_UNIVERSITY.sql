use UNIVERSITY;

-- 1
go
create view [�������������] as
select * from TEACHER;

-- 2
go
create view [���������� ������] as
select	FACULTY.FACULTY_NAME as [���������],
		count(PULPIT.PULPIT) as [���������� ������]
		from FACULTY inner join PULPIT
		on FACULTY.FACULTY = PULPIT.FACULTY
		group by FACULTY.FACULTY_NAME;

-- 3
go
create view [���������]([���], [������������ ���������]) as
select	AUDITORIUM,
		AUDITORIUM_NAME
	from AUDITORIUM
	where AUDITORIUM_TYPE like '��%';

-- 4
go
create view ����������_��������� as
	select	AUDITORIUM,
		AUDITORIUM_NAME
	from AUDITORIUM
	where AUDITORIUM_TYPE like '��%'
	with check option;

-- 5
go
create view ����������(���, [������������ ����������], [��� �������]) as
	select	top 20 
			SUBJECT, SUBJECT_NAME, PULPIT
	from SUBJECT
	order by SUBJECT_NAME;

-- 6
go
alter view dbo.[���������� ������] with schemabinding
as
select	FACULTY.FACULTY_NAME as [���������],
		count(PULPIT.PULPIT) as [���������� ������]
		from dbo.FACULTY inner join dbo.PULPIT
		on FACULTY.FACULTY = PULPIT.FACULTY
		group by FACULTY.FACULTY_NAME;

-- ��������� ������� ������� �� ������� FACULTY, �� ��� ��� �� ������� ��-�� ����� "with schemabinding"
go
alter table FACULTY
drop column FACULTY_NAME;
