----------------------------------------- 1
use UNIVERSITY;
-- ��������������� ������� ��� ����������� ���-��� �� ���������
create table TR_AUDIT
(
	ID int identity,	-- �����
	STMT varchar(20)	-- DML-��������
		check (STMT in ('INS', 'DEL', 'UPD')),
	TRNAME varchar(50),	-- ��� ��������
	CC varchar(300),	-- �����������
)

go
create trigger TR_TEACHER_INS -- create trigger ��������_��������
on TEACHER -- ������� ����� ���������� �� ������� � ������� TEACHER
after insert -- ������� ����������� ����� (after) ������� insert
as
begin
	declare @teacher char(10) = (select TEACHER from INSERTED),
			@teacher_name varchar(100) = (select TEACHER_NAME from INSERTED),
			@gender char(1) = (select GENDER from INSERTED),
			@pulpit char(20) = (select PULPIT from INSERTED);

	declare	@allInsertedInfo varchar(200) = @teacher + ' ' + 
						@teacher_name + ' ' + @gender + ' ' +
						@pulpit;

	insert into TR_AUDIT values('INS', 'TR_TEACHER_INS', @allInsertedInfo);
end;

-- ������� ������ � ������� TEACHER
go
insert into TEACHER values('������', '���������� ����� ���������', '�', '����');

-- ������� �������� �� ������� TR_AUDIT
select * from TR_AUDIT;

drop trigger TR_TEACHER_INS;



----------------------------------------- 2
go
create trigger TR_TEACHER_DEL 
on TEACHER 
after DELETE
as 
begin
	declare @teacher char(10) = (select TEACHER from DELETED),
			@teacher_name varchar(100) = (select TEACHER_NAME from DELETED),
			@gender char(1) = (select GENDER from DELETED),
			@pulpit char(20) = (select PULPIT from DELETED);

	declare	@allDeletedInfo varchar(200) = @teacher + ' ' + 
						@teacher_name + ' ' + @gender + ' ' +
						@pulpit;

	insert into TR_AUDIT values('DEL', 'TR_TEACHER_DEL', @allDeletedInfo);
end;

-- ������ ������ �� ������� TEACHER
go
delete from TEACHER 
where TEACHER = '������';

-- ������� �������� �� ������� TR_AUDIT
select * from TR_AUDIT;

drop trigger TR_TEACHER_DEL;



----------------------------------------- 3
go
create trigger TR_TEACHER_UPD 
on TEACHER 
after UPDATE
as 
begin
		declare 
			@oldTeacher char(10) = (select TEACHER from DELETED where TEACHER is not null),
			@oldTeacher_name varchar(100) = (select TEACHER_NAME from DELETED where TEACHER_NAME is not null),
			@oldGender char(1) = (select GENDER from DELETED where GENDER is not null),
			@oldPulpit char(20) = (select PULPIT from DELETED where PULPIT is not null),
			@newTeacher char(10) = (select TEACHER from INSERTED where TEACHER is not null),
			@newTeacher_name varchar(100) = (select TEACHER_NAME from INSERTED where TEACHER_NAME is not null),
			@newGender char(1) = (select GENDER from INSERTED where GENDER is not null),
			@newPulpit char(20) = (select PULPIT from INSERTED where PULPIT is not null);

	declare	@oldInfo varchar(200) = @oldTeacher + ' ' + 
						@oldTeacher_name + ' ' + @oldGender + ' ' +
						@oldPulpit;

	declare	@newInfo varchar(200) = @newTeacher + ' ' + 
						@newTeacher_name + ' ' + @newGender + ' ' +
						@newPulpit;

	declare @result varchar(400) =	'deleted:' + char(10) + @oldInfo +
									'inserted:' + char(10) + @newInfo;

	insert into TR_AUDIT values('UPD', 'TR_TEACHER_UPD', @result);
end;

insert into TEACHER values('������', '���������� ����� ���������', '�', '����');

update TEACHER set TEACHER_NAME = '���������� ������� ��������������'
where TEACHER_NAME = '���������� ����� ���������';

select * from TR_AUDIT;

drop trigger TR_TEACHER_UPD;



----------------------------------------- 4
go
create trigger TR_TEACHER 
on TEACHER
after insert, update, delete
as
begin
	declare @ins int = (select count(*) from inserted); 
	declare @del int = (select count(*) from deleted);
	
	-- �������
	if @ins>0 and @del=0
	begin
		declare @teacherI char(10) = (select TEACHER from INSERTED),
		@teacher_nameI varchar(100) = (select TEACHER_NAME from INSERTED),
		@genderI char(1) = (select GENDER from INSERTED),
		@pulpitI char(20) = (select PULPIT from INSERTED);

		declare	@allInsertedInfo varchar(200) = @teacherI + ' ' + 
					@teacher_nameI + ' ' + @genderI + ' ' +
					@pulpitI;

		insert into TR_AUDIT values('INS', 'TR_TEACHER_INS', @allInsertedInfo);
	end;

	-- ��������
	else if @del>0 and @ins=0
	begin
		declare @teacherD char(10) = (select TEACHER from DELETED),
			@teacher_nameD varchar(100) = (select TEACHER_NAME from DELETED),
			@genderD char(1) = (select GENDER from DELETED),
			@pulpitD char(20) = (select PULPIT from DELETED);

		declare	@allDeletedInfo varchar(200) = @teacherD + ' ' + 
							@teacher_nameD + ' ' + @genderD + ' ' +
							@pulpitD;

		insert into TR_AUDIT values('DEL', 'TR_TEACHER_DEL', @allDeletedInfo);
	end;

	-- ����������
	else if @del>0 and @ins>0
	begin
		declare 
				@oldTeacher char(10) = (select TEACHER from DELETED where TEACHER is not null),
				@oldTeacher_name varchar(100) = (select TEACHER_NAME from DELETED where TEACHER_NAME is not null),
				@oldGender char(1) = (select GENDER from DELETED where GENDER is not null),
				@oldPulpit char(20) = (select PULPIT from DELETED where PULPIT is not null),
				@newTeacher char(10) = (select TEACHER from INSERTED where TEACHER is not null),
				@newTeacher_name varchar(100) = (select TEACHER_NAME from INSERTED where TEACHER_NAME is not null),
				@newGender char(1) = (select GENDER from INSERTED where GENDER is not null),
				@newPulpit char(20) = (select PULPIT from INSERTED where PULPIT is not null);

		declare	@oldInfo varchar(200) = @oldTeacher + ' ' + 
							@oldTeacher_name + ' ' + @oldGender + ' ' +
							@oldPulpit;

		declare	@newInfo varchar(200) = @newTeacher + ' ' + 
							@newTeacher_name + ' ' + @newGender + ' ' +
							@newPulpit;

		declare @result varchar(400) =	'deleted:' + char(10) + @oldInfo +
										'inserted:' + char(10) + @newInfo;

		insert into TR_AUDIT values('UPD', 'TR_TEACHER_UPD', @result);
	end;
end;

-- �������� �������, ���������� � ��������
insert into TEACHER values('���', '������� ������', '�', '����');

update TEACHER set PULPIT = '��'
where TEACHER = '���';

delete from TEACHER 
where TEACHER = '���';

select * from TR_AUDIT;

-- ������� �������
drop trigger TR_TEACHER;



----------------------------------------- 5
-- ������� ������ � �������
insert into TEACHER values('����', '������ ������', '�', '��');
 
-- � ����� ��������� ������, ��� �������� � ������� TEACHER - ��������� �����, �.�. ������ ���� �����������
insert into TEACHER values('����', '������ ������', '�', '��');

select * from TR_AUDIT;



----------------------------------------- 6
-- ������ �������
go
create trigger TR_TEACHER_DEL1
on TEACHER
after DELETE
as
begin
		declare @teacher char(10) = (select TEACHER from DELETED),
			@teacher_name varchar(100) = (select TEACHER_NAME from DELETED),
			@gender char(1) = (select GENDER from DELETED),
			@pulpit char(20) = (select PULPIT from DELETED);

	declare	@allDeletedInfo varchar(200) = @teacher + ' ' + 
						@teacher_name + ' ' + @gender + ' ' +
						@pulpit;

	insert into TR_AUDIT values('DEL', 'TR_TEACHER_DEL1', @allDeletedInfo);
end;

-- ������ �������
go
create trigger TR_TEACHER_DEL2
on TEACHER
after DELETE
as
begin
		declare @teacher char(10) = (select TEACHER from DELETED),
			@teacher_name varchar(100) = (select TEACHER_NAME from DELETED),
			@gender char(1) = (select GENDER from DELETED),
			@pulpit char(20) = (select PULPIT from DELETED);

	declare	@allDeletedInfo varchar(200) = @teacher + ' ' + 
						@teacher_name + ' ' + @gender + ' ' +
						@pulpit;

	insert into TR_AUDIT values('DEL', 'TR_TEACHER_DEL2', @allDeletedInfo);
end;

-- ������ �������
go
create trigger TR_TEACHER_DEL3
on TEACHER
after DELETE
as
begin
		declare @teacher char(10) = (select TEACHER from DELETED),
			@teacher_name varchar(100) = (select TEACHER_NAME from DELETED),
			@gender char(1) = (select GENDER from DELETED),
			@pulpit char(20) = (select PULPIT from DELETED);

	declare	@allDeletedInfo varchar(200) = @teacher + ' ' + 
						@teacher_name + ' ' + @gender + ' ' +
						@pulpit;

	insert into TR_AUDIT values('DEL', 'TR_TEACHER_DEL3', @allDeletedInfo);
end;

-- ��������� ���� ��������� ������� TEACHER
select	t.name, 
		e.type_desc
from 
	sys.triggers as t 
	join 
	sys.trigger_events as e
	on t.object_id = e.object_id
where OBJECT_NAME(t.parent_id) = 'TEACHER'

-- ���������� ���������� ���������: ������ TR_TEACHER_DEL3, ��������� - TR_TEACHER_DEL2
exec sp_settriggerorder @triggername = 'TR_TEACHER_DEL3',
						@order = 'first',
						@stmttype = 'delete';
exec sp_settriggerorder @triggername = 'TR_TEACHER_DEL2',
						@order = 'last',
						@stmttype = 'delete';

-- ������ ������ �� ������� TEACHER � ���������, � ����� ������� ���=�������� ��������
delete from TEACHER
where TEACHER = '����';

select * from TR_AUDIT;

-- ������� ��������
drop trigger TR_TEACHER_DEL1;
drop trigger TR_TEACHER_DEL2;
drop trigger TR_TEACHER_DEL3;



----------------------------------------- 7
go
create trigger noDeletingInTeacherTableTrig
on TEACHER 
after delete
as 
begin
	raiserror('������� �� ��������� �������� ������� � ������� TEACHER.', 10, 1);
	rollback;
end;

delete from TEACHER
where TEACHER = '������';

drop trigger noDeletingInTeacherTableTrig;



----------------------------------------- 8
go
create trigger noDeletingInFacultyTableTrig
on FACULTY
instead of delete
as
raiserror('������� �� ��������� �������� ������� � ������� FACULTY.', 10, 1);

delete from FACULTY
where FACULTY = '���';

drop trigger noDeletingInFacultyTableTrig;



----------------------------------------- 8
go
create trigger ddlTrigger 
on database
for DDL_DATABASE_LEVEL_EVENTS 
as
begin 
	declare @eventType varchar(50) = EVENTDATA().value('(/EVENT_INSTANCE/
				EventType)[1]', 'varchar(50)');
	declare @objName varchar(50) = EVENTDATA().value('(/EVENT_INSTANCE/
				ObjectName)[1]', 'varchar(50)');
	declare @objType varchar(50) = EVENTDATA().value('(/EVENT_INSTANCE/
				ObjectType)[1]', 'varchar(50)');

	print '��� �������: ' + @eventType;
	print '��� �������: ' + @objName;
	print '��� �������: ' + @objType;

	-- ���� ������� �������� �������� �������� ��� �������� �������
	if(@eventType in ('CREATE_TABLE', 'DROP_TABLE'))
	begin
		raiserror('�������� �������� � �������� ������ � �� UNIVERSITY ���������', 16, 1);
		rollback;
	end;
end;

create table bitch(id int identity(1,1));
drop table TR_AUDIT;

drop trigger ddlTrigger on database

