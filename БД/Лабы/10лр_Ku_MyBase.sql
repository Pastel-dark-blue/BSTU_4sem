-- 1 (������� � ������ ����� ������� ������ ������� ��������� �� ������ ����� 5 ���)
declare curTask_1 cursor local
	for select �������
		from ��������
		where ���� > 5;

declare @surname nvarchar(50), @allSurnames nvarchar(200) = ''; 

open curTask_1;
	print '�������� �� ������ ����� 5 ���: ';
	fetch curTask_1 into @surname; 
	while @@fetch_status = 0
		begin
			set @allSurnames = @surname + ',' + @allSurnames;
			fetch curTask_1 into @surname; 
		end;
close curTask_1;

-- ������� ��������� ������� � ������, ����� ��������� �����
set @allSurnames = substring(@allSurnames, 1, len(@allSurnames)-1) + '.';
print @allSurnames;

-- 2.1
-- ��������� ������
declare LocCurTask_2 cursor local
	for select ��������
		from ��������;

declare @name nvarchar(50);

open LocCurTask_2;
	fetch LocCurTask_2 into @name;
	print '1. ' + @name;
go
------------------------ ����� 1 ������
declare @name nvarchar(50);

	fetch LocCurTask_2 into @name;
	print '2. ' + @name;
close LocCurTask_2;

-- 2.2
-- ���������� ������
declare GlobCurTask_2 cursor global
	for select ��������
		from ��������;

declare @nameG nvarchar(50);

open GlobCurTask_2;
	fetch GlobCurTask_2 into @nameG;
	print '1. ' + @nameG;
go
------------------------ ����� 1 ������
declare @nameG nvarchar(50);

	fetch GlobCurTask_2 into @nameG;
	print '2. ' + @nameG;
close GlobCurTask_2;
deallocate GlobCurTask_2;

-- 3
-- ����������� ������
declare statCur cursor static local scroll
	for select ��������
		from ��������;

declare @nameForStat nvarchar(50);

open statCur;
	insert	into ��������(��������)
			values('�������� - �������');
	print '� ������� ��������� ������ ''�������� - �������''!';

	print '��������� ������ ������� ''��������'' �� ������ ������������ �������:';
	fetch last from statCur into @nameForStat;

	print @nameForStat;
close statCur;

-- ������������ ������
declare dynamicCur cursor dynamic local scroll
	for select ��������
		from ��������;

declare @nameForDyn nvarchar(50);

open dynamicCur;
	insert	into ��������(��������)
			values('����� - �����');
	print '� ������� ��������� ������ ''����� - �����''!';

	print '��������� ������ ������� ''��������'' �� ������ ������������� �������:';
	fetch last from dynamicCur into @nameForDyn;

	print @nameForDyn;
close dynamicCur;

-- 4
-- scroll
declare curTask_4 cursor scroll
	for select	row_number() over (order by ��������),
				��������
		from ��������;

declare @name_4 nvarchar(50), 
		@allNames nvarchar(250) = '', 
		@num int;

-- ������� ��� ������ ������� ����� �������
open curTask_4;
	print '��� ������ �������:';
	fetch curTask_4 into @num, @name_4;
	while @@fetch_status = 0
		begin
			set @allNames = @allNames + @name_4 + ', ';
			if (@num % 3 = 0) 
				set @allNames = @allNames + char(10);

			fetch curTask_4 into @num, @name_4;
		end;
close curTask_4;

-- ������� ��������� ������� � ������, ����� ��������� �����
set @allNames = substring(@allNames, 1, len(@allNames)-1) + '.';
print @allNames;

-- ���������� scroll
open curTask_4;
	fetch first from curTask_4 into @num, @name_4;
	print char(10) + '������ ������ : ' +
		cast(@num as varchar(5)) + ' -> ' + @name_4;

	fetch next from curTask_4 into @num, @name_4;
	print '��������� ������ �� ������� : ' +
		cast(@num as varchar(5)) + ' -> ' + @name_4;

	fetch last from curTask_4 into @num, @name_4;
	print '��������� ������ : ' +
		cast(@num as varchar(5)) + ' -> ' + @name_4;

	fetch prior from curTask_4 into @num, @name_4;
	print '���������� ������ �� ������� : ' +
		cast(@num as varchar(5)) + ' -> ' + @name_4;

	fetch absolute 3 from curTask_4 into @num, @name_4;
	print '������ ������ � ������ : ' +
		cast(@num as varchar(5)) + ' -> ' + @name_4;

	fetch absolute -3 from curTask_4 into @num, @name_4;
	print '������ ������ � ����� : ' +
		cast(@num as varchar(5)) + ' -> ' + @name_4;

	fetch relative 2 from curTask_4 into @num, @name_4;
	print '������ ������ ������ �� ������� : ' +
		cast(@num as varchar(5)) + ' -> ' + @name_4;

	fetch relative -2 from curTask_4 into @num, @name_4;
	print '������ ������ ����� �� ������� : ' +
		cast(@num as varchar(5)) + ' -> ' + @name_4;

close curTask_4;
deallocate curTask_4;

-- 5
declare @name_5 nvarchar(50);

declare curTask_5 cursor dynamic
	for select ��������
		from ��������
		for update;

open curTask_5;

	fetch last from curTask_5 into @name_5;
	delete �������� where current of curTask_5;

	fetch last from curTask_5 into @name_5;
	update �������� 
		set [���������, ��] = 228.2
		where current of curTask_5;

close curTask_5;
deallocate curTask_5;

-- 6.1 
-- ������ �� ������� "��������" ��������� �� ������ ������ ����
select * into cop
from ��������;

declare curTask_6_1 cursor local dynamic
	for select ���_��������
		from ��������
		where ���� < 1
		for update;

open curTask_6_1;
	fetch curTask_6_1;
	while @@fetch_status = 0
		begin
			delete �������� where current of curTask_6_1;
			fetch curTask_6_1;
		end;
close curTask_6_1;

-- 6.1 
declare curTask_6_2 cursor local dynamic
	for select ���_��������
		from ��������
		where ���_�������� = 7
		for update;

open curTask_6_2;
	fetch curTask_6_2;
	update �������� set ���� += 1
		where current of curTask_6_2
close curTask_6_2;
