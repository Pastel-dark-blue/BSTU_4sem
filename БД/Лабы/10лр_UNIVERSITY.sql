-- 1
declare subjectCur cursor
	for select SUBJECT from SUBJECT
	where PULPIT = '����';

declare @subject char(10), @allSubjects char(300) = '';

open subjectCur; -- ��������� ������
fetch subjectCur into @subject; -- ��������� ������ ������
	print '���������� �� ������� ����:' + char(10);
while @@fetch_status = 0 -- ���� ����� ��������, ���� ������ ������� ������������ �� �������
	begin
		set @allSubjects = rtrim(@subject) + ','+ @allSubjects;
		fetch subjectCur into @subject; -- ��������� ��������� ������, �� ���, ������� ��� ������� � ������� ���
	end;
print @allSubjects;
close subjectCur; -- �������� �������

-- 2
-- ��������� ������
declare locCur cursor local
	for
		select PULPIT, PULPIT_NAME
		from PULPIT;

declare @pul char(20), @pulName varchar(100);

open locCur;
fetch locCur into @pul, @pulName;
print '1. ' + @pul + ' ' + @pulName;

go
------------------------------------------
declare @pul char(20), @pulName varchar(100);

fetch locCur into @pul, @pulName;
print '2. ' + @pul + ' ' + @pulName;

go

-- ����������
declare globCur cursor global
	for select PULPIT, PULPIT_NAME
		from PULPIT;

declare @pul char(20), @pulName varchar(100);

open globCur;
fetch globCur into @pul, @pulName;
print '1. ' + @pul + ' ' + @pulName;
go
------------------------------------------
declare @pul char(20), @pulName varchar(100);

fetch globCur into @pul, @pulName;
print '2. ' + @pul + ' ' + @pulName;
close globCur;
deallocate globCur; -- �������� ������� � ������������ ������, ���������� � ������ ��������� ��������, ���������� ��� �������
go

-- 3
-- ����������� ������
declare studentStaticCur cursor static scroll
	for select IDSTUDENT, NAME
		from STUDENT;

-- ���������� ��� ������������ �������
declare @idForStatic int, @nameForStatic nvarchar(100); -- ����������, ���� ����� ����������� �������� �������

open studentStaticCur; -- ��������� ����������� ������

	-- ������������ �������  (����� ������ ������� � ����� �������)
	insert into STUDENT(NAME)
			values('���������� ����� ���������');
	print '� ������� ��������� ������ ''���������� ����� ���������''!';

	print '��������� ������ ������� STUDENT �� ������ ������������ �������:';
	-- ��������� ��������� ������ � ����������� �������
	fetch last from studentStaticCur into @idForStatic, @nameForStatic;
	print cast(@idForStatic as varchar(7)) + '	' + @nameForStatic;

close studentStaticCur;
----------------------------------------------------
-- ������������ ������
declare studentDynamicCur cursor dynamic scroll
	for select IDSTUDENT, NAME
		from STUDENT;

declare @idForDynamic int, @nameForDynamic nvarchar(100); -- ����������, ���� ����� ����������� �������� �������

open studentDynamicCur; -- ��������� ������������ ������

	-- ������������ �������  (����� ������ ������� � ����� �������)
	insert into STUDENT(NAME)
			values('��������� ����� ���������');
	print '� ������� ��������� ������ ''��������� ����� ���������''!';

	print '��������� ������ ������� STUDENT �� ������ ������������� �������:';
	-- ��������� ��������� ������ � ������������ �������
	fetch last from studentDynamicCur into @idForDynamic, @nameForDynamic;
	print cast(@idForDynamic as varchar(7)) + '	' + @nameForDynamic;

close studentDynamicCur;
deallocate studentDynamicCur;

-- 4
-- ������� ���������� ��� �������� ����� �������
declare @pul varchar(20), 
		@allPulpits varchar(100) = '', 
		@rowNum int;

-- ������� ������
declare curTask_4 cursor scroll
	for select	row_number() over (order by PULPIT) as [����� ������],
				PULPIT as [�������]
		from PULPIT;

-- ������� ��� ������� �� ������� PULPIT
open curTask_4;
	print '��� ������� �� ������� PULPIT :';
	fetch curTask_4 into @rowNum, @pul;
	while @@fetch_status = 0 
		begin
			set @allPulpits = @allPulpits + rtrim(@pul) + ',';
			fetch curTask_4 into @rowNum, @pul;
		end;
	print @allPulpits;
close curTask_4;

-- ���������� �������� scroll
open curTask_4;
	fetch first from curTask_4 into @rowNum, @pul;
	print char(10) + '������ ������ : ' + 
		cast(@rowNum as varchar(10)) + ' -> ' + @pul;

	fetch next from curTask_4 into @rowNum, @pul;
	print '��������� ������ �� ������� : ' + 
		cast(@rowNum as varchar(10)) + ' -> ' + @pul;

	fetch last from curTask_4 into @rowNum, @pul;
	print '��������� ������ : ' + 
		cast(@rowNum as varchar(10)) + ' -> ' + @pul;

	fetch prior from curTask_4 into @rowNum, @pul;
	print '���������� ������ �� ������� : ' + 
		cast(@rowNum as varchar(10)) + ' -> ' + @pul;

	fetch absolute 5 from curTask_4 into @rowNum, @pul;
	print '����� ������ � ������ : ' + 
		cast(@rowNum as varchar(10)) + ' -> ' + @pul;

	fetch absolute -5 from curTask_4 into @rowNum, @pul;
	print '����� ������ � ����� : ' + 
		cast(@rowNum as varchar(10)) + ' -> ' + @pul;

	fetch relative 3 from curTask_4 into @rowNum, @pul;
	print '������ ������ ������ �� ������� : ' + 
		cast(@rowNum as varchar(10)) + ' -> ' + @pul;

	fetch relative -3 from curTask_4 into @rowNum, @pul;
	print '������ ������ ����� �� ������� : ' + 
		cast(@rowNum as varchar(10)) + ' -> ' + @pul;

close curTask_4;
deallocate 	curTask_4;

-- 5
declare @bday date;

declare curTask_5 cursor local dynamic
	for select BDAY 
		from STUDENT for update;

open curTask_5;
	fetch curTask_5 into @bday;
	delete STUDENT where current of curTask_5; -- ������� �� ������� STUDENT ������, ��������� ��������

	fetch curTask_5 into @bday;
	update STUDENT 
		set BDAY = getdate()
		where current of curTask_5; -- �������� � ������� STUDENT ������, ��������� ��������
close curTask_5;

-- 6.1
-- � ������� PROGRESS ��� ��������� � ������� ���� 4
-- ��� ��� ���� ������� ��������� � ������� ������ 4
-- ����� ���� ������ �����  ������� PROGRESS, ����� ����� ������������ ��� ��� ����
select * into PROGRESS_copy
from PROGRESS;

-- ������ 
declare curTask_6_1 cursor local dynamic
for select	STUDENT.NAME as [���],
			PROGRESS.NOTE as [������]
	from STUDENT inner join PROGRESS
	on STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
	inner join GROUPS
	on STUDENT.IDGROUP = GROUPS.IDGROUP
	where PROGRESS.NOTE = 4
	for update;

-- �������� �� ������� PROGRESS ���������� � ��������� � ������ = 4
open curTask_6_1;
	fetch curTask_6_1;

	while @@fetch_status = 0
		begin
			delete PROGRESS where current of curTask_6_1;
			fetch curTask_6_1;
		end;

close curTask_6_1;

-- �������� ������������ ������� � �������������� ��������� �������� �� �����
drop table PROGRESS; 
exec sp_rename 'PROGRESS_copy', 'PROGRESS'; 

-- 6.2
declare curTask_6_2 cursor local dynamic 
	for select IDSTUDENT 
		from PROGRESS
		where IDSTUDENT = 1003
	for update;

open curTask_6_2;
	fetch curTask_6_2;
	update PROGRESS set NOTE += 1
		where current of curTask_6_2;
close curTask_6_2;


