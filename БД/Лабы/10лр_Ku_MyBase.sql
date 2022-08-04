-- 1 (вывести в строку через запятую список фамилий водителей со стажем более 5 лет)
declare curTask_1 cursor local
	for select Фамилия
		from Водители
		where Стаж > 5;

declare @surname nvarchar(50), @allSurnames nvarchar(200) = ''; 

open curTask_1;
	print 'Водители со стажем более 5 лет: ';
	fetch curTask_1 into @surname; 
	while @@fetch_status = 0
		begin
			set @allSurnames = @surname + ',' + @allSurnames;
			fetch curTask_1 into @surname; 
		end;
close curTask_1;

-- убираем последнюю запятую в строке, затем добавляем точку
set @allSurnames = substring(@allSurnames, 1, len(@allSurnames)-1) + '.';
print @allSurnames;

-- 2.1
-- локальный курсор
declare LocCurTask_2 cursor local
	for select Название
		from Маршруты;

declare @name nvarchar(50);

open LocCurTask_2;
	fetch LocCurTask_2 into @name;
	print '1. ' + @name;
go
------------------------ конец 1 пакета
declare @name nvarchar(50);

	fetch LocCurTask_2 into @name;
	print '2. ' + @name;
close LocCurTask_2;

-- 2.2
-- глобальный курсор
declare GlobCurTask_2 cursor global
	for select Название
		from Маршруты;

declare @nameG nvarchar(50);

open GlobCurTask_2;
	fetch GlobCurTask_2 into @nameG;
	print '1. ' + @nameG;
go
------------------------ конец 1 пакета
declare @nameG nvarchar(50);

	fetch GlobCurTask_2 into @nameG;
	print '2. ' + @nameG;
close GlobCurTask_2;
deallocate GlobCurTask_2;

-- 3
-- статический курсор
declare statCur cursor static local scroll
	for select Название
		from Маршруты;

declare @nameForStat nvarchar(50);

open statCur;
	insert	into Маршруты(Название)
			values('Заславль - Коссово');
	print 'В таблицу добавлена строка ''Заславль - Коссово''!';

	print 'Последняя строка таблицы ''Маршруты'' по версии статического курсора:';
	fetch last from statCur into @nameForStat;

	print @nameForStat;
close statCur;

-- динамический курсор
declare dynamicCur cursor dynamic local scroll
	for select Название
		from Маршруты;

declare @nameForDyn nvarchar(50);

open dynamicCur;
	insert	into Маршруты(Название)
			values('Миоры - Туров');
	print 'В таблицу добавлена строка ''Миоры - Туров''!';

	print 'Последняя строка таблицы ''Маршруты'' по версии динамического курсора:';
	fetch last from dynamicCur into @nameForDyn;

	print @nameForDyn;
close dynamicCur;

-- 4
-- scroll
declare curTask_4 cursor scroll
	for select	row_number() over (order by Название),
				Название
		from Маршруты;

declare @name_4 nvarchar(50), 
		@allNames nvarchar(250) = '', 
		@num int;

-- Выведем все записи курсора через запятую
open curTask_4;
	print 'Все записи курсора:';
	fetch curTask_4 into @num, @name_4;
	while @@fetch_status = 0
		begin
			set @allNames = @allNames + @name_4 + ', ';
			if (@num % 3 = 0) 
				set @allNames = @allNames + char(10);

			fetch curTask_4 into @num, @name_4;
		end;
close curTask_4;

-- убираем последнюю запятую в строке, затем добавляем точку
set @allNames = substring(@allNames, 1, len(@allNames)-1) + '.';
print @allNames;

-- применение scroll
open curTask_4;
	fetch first from curTask_4 into @num, @name_4;
	print char(10) + 'Первая запись : ' +
		cast(@num as varchar(5)) + ' -> ' + @name_4;

	fetch next from curTask_4 into @num, @name_4;
	print 'Следующая строка от текущей : ' +
		cast(@num as varchar(5)) + ' -> ' + @name_4;

	fetch last from curTask_4 into @num, @name_4;
	print 'Последняя запись : ' +
		cast(@num as varchar(5)) + ' -> ' + @name_4;

	fetch prior from curTask_4 into @num, @name_4;
	print 'Предыдущая строка от текущей : ' +
		cast(@num as varchar(5)) + ' -> ' + @name_4;

	fetch absolute 3 from curTask_4 into @num, @name_4;
	print 'Третья запись с начала : ' +
		cast(@num as varchar(5)) + ' -> ' + @name_4;

	fetch absolute -3 from curTask_4 into @num, @name_4;
	print 'Третья запись с конца : ' +
		cast(@num as varchar(5)) + ' -> ' + @name_4;

	fetch relative 2 from curTask_4 into @num, @name_4;
	print 'Вторая запись вперед от текущей : ' +
		cast(@num as varchar(5)) + ' -> ' + @name_4;

	fetch relative -2 from curTask_4 into @num, @name_4;
	print 'Вторая запись назад от текущей : ' +
		cast(@num as varchar(5)) + ' -> ' + @name_4;

close curTask_4;
deallocate curTask_4;

-- 5
declare @name_5 nvarchar(50);

declare curTask_5 cursor dynamic
	for select Название
		from Маршруты
		for update;

open curTask_5;

	fetch last from curTask_5 into @name_5;
	delete Маршруты where current of curTask_5;

	fetch last from curTask_5 into @name_5;
	update Маршруты 
		set [Дальность, км] = 228.2
		where current of curTask_5;

close curTask_5;
deallocate curTask_5;

-- 6.1 
-- удалим из таблицы "Водители" водителей со стажем меньше года
select * into cop
from Водители;

declare curTask_6_1 cursor local dynamic
	for select Код_водителя
		from Водители
		where Стаж < 1
		for update;

open curTask_6_1;
	fetch curTask_6_1;
	while @@fetch_status = 0
		begin
			delete Водители where current of curTask_6_1;
			fetch curTask_6_1;
		end;
close curTask_6_1;

-- 6.1 
declare curTask_6_2 cursor local dynamic
	for select Код_водителя
		from Водители
		where Код_водителя = 7
		for update;

open curTask_6_2;
	fetch curTask_6_2;
	update Водители set Стаж += 1
		where current of curTask_6_2
close curTask_6_2;
