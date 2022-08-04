-- 1
declare subjectCur cursor
	for select SUBJECT from SUBJECT
	where PULPIT = 'ИСиТ';

declare @subject char(10), @allSubjects char(300) = '';

open subjectCur; -- открываем курсор
fetch subjectCur into @subject; -- считываем первую запись
	print 'Дисциплины на кафедре ИСиТ:' + char(10);
while @@fetch_status = 0 -- цикл будет работать, пока записи успешно считываеются из курсора
	begin
		set @allSubjects = rtrim(@subject) + ','+ @allSubjects;
		fetch subjectCur into @subject; -- считываем следующую запись, за той, которую уже считали в прошлый раз
	end;
print @allSubjects;
close subjectCur; -- закрытие курсора

-- 2
-- локальный курсор
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

-- глобальный
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
deallocate globCur; -- удаления курсора и освобождения памяти, процессора и других системных ресурсов, выделенных для курсора
go

-- 3
-- статический курсор
declare studentStaticCur cursor static scroll
	for select IDSTUDENT, NAME
		from STUDENT;

-- переменные для статического курсора
declare @idForStatic int, @nameForStatic nvarchar(100); -- переменные, куда будут считываться значения курсора

open studentStaticCur; -- открываем статический курсор

	-- модифицируем таблицу  (новая строка попадет в конец таблицы)
	insert into STUDENT(NAME)
			values('Курносенко Софья Андреевна');
	print 'В таблицу добавлена строка ''Курносенко Софья Андреевна''!';

	print 'Последняя строка таблицы STUDENT по версии статического курсора:';
	-- считываем последнюю запись в статическом курсоре
	fetch last from studentStaticCur into @idForStatic, @nameForStatic;
	print cast(@idForStatic as varchar(7)) + '	' + @nameForStatic;

close studentStaticCur;
----------------------------------------------------
-- динамический курсор
declare studentDynamicCur cursor dynamic scroll
	for select IDSTUDENT, NAME
		from STUDENT;

declare @idForDynamic int, @nameForDynamic nvarchar(100); -- переменные, куда будут считываться значения курсора

open studentDynamicCur; -- открываем динамический курсор

	-- модифицируем таблицу  (новая строка попадет в конец таблицы)
	insert into STUDENT(NAME)
			values('Олимпиева Ольга Денисовна');
	print 'В таблицу добавлена строка ''Олимпиева Ольга Денисовна''!';

	print 'Последняя строка таблицы STUDENT по версии динамического курсора:';
	-- считываем последнюю запись в динамическом курсоре
	fetch last from studentDynamicCur into @idForDynamic, @nameForDynamic;
	print cast(@idForDynamic as varchar(7)) + '	' + @nameForDynamic;

close studentDynamicCur;
deallocate studentDynamicCur;

-- 4
-- создаем переменные для хранения строк курсора
declare @pul varchar(20), 
		@allPulpits varchar(100) = '', 
		@rowNum int;

-- создаем курсор
declare curTask_4 cursor scroll
	for select	row_number() over (order by PULPIT) as [Номер строки],
				PULPIT as [Кафедра]
		from PULPIT;

-- выведем все кафедры из таблицы PULPIT
open curTask_4;
	print 'Все кафедры из таблицы PULPIT :';
	fetch curTask_4 into @rowNum, @pul;
	while @@fetch_status = 0 
		begin
			set @allPulpits = @allPulpits + rtrim(@pul) + ',';
			fetch curTask_4 into @rowNum, @pul;
		end;
	print @allPulpits;
close curTask_4;

-- применение атрибута scroll
open curTask_4;
	fetch first from curTask_4 into @rowNum, @pul;
	print char(10) + 'Первая запись : ' + 
		cast(@rowNum as varchar(10)) + ' -> ' + @pul;

	fetch next from curTask_4 into @rowNum, @pul;
	print 'Следующая строка от текущей : ' + 
		cast(@rowNum as varchar(10)) + ' -> ' + @pul;

	fetch last from curTask_4 into @rowNum, @pul;
	print 'Последняя запись : ' + 
		cast(@rowNum as varchar(10)) + ' -> ' + @pul;

	fetch prior from curTask_4 into @rowNum, @pul;
	print 'Предыдущая строка от текущей : ' + 
		cast(@rowNum as varchar(10)) + ' -> ' + @pul;

	fetch absolute 5 from curTask_4 into @rowNum, @pul;
	print 'Пятая запись с начала : ' + 
		cast(@rowNum as varchar(10)) + ' -> ' + @pul;

	fetch absolute -5 from curTask_4 into @rowNum, @pul;
	print 'Пятая запись с конца : ' + 
		cast(@rowNum as varchar(10)) + ' -> ' + @pul;

	fetch relative 3 from curTask_4 into @rowNum, @pul;
	print 'Третья строка вперед от текущей : ' + 
		cast(@rowNum as varchar(10)) + ' -> ' + @pul;

	fetch relative -3 from curTask_4 into @rowNum, @pul;
	print 'Третья строка назад от текущей : ' + 
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
	delete STUDENT where current of curTask_5; -- удаляем из таблицы STUDENT запись, считанную курсором

	fetch curTask_5 into @bday;
	update STUDENT 
		set BDAY = getdate()
		where current of curTask_5; -- изменяем в таблице STUDENT запись, считанную курсором
close curTask_5;

-- 6.1
-- в таблице PROGRESS нет студентов с оценкой ниже 4
-- так что буду удалять студентов с оценкой равной 4
-- перед этим сделаю копию  таблицы PROGRESS, чтобы потом восстановить все как было
select * into PROGRESS_copy
from PROGRESS;

-- курсор 
declare curTask_6_1 cursor local dynamic
for select	STUDENT.NAME as [ФИО],
			PROGRESS.NOTE as [Оценка]
	from STUDENT inner join PROGRESS
	on STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
	inner join GROUPS
	on STUDENT.IDGROUP = GROUPS.IDGROUP
	where PROGRESS.NOTE = 4
	for update;

-- удаление из таблицы PROGRESS информации о студентах с баллом = 4
open curTask_6_1;
	fetch curTask_6_1;

	while @@fetch_status = 0
		begin
			delete PROGRESS where current of curTask_6_1;
			fetch curTask_6_1;
		end;

close curTask_6_1;

-- удаление покалеченной таблицы и восстановление исходного варианта из копии
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


