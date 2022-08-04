-- 1
select	max(AUDITORIUM_CAPACITY) as [Максимальная вместимость ауд.], 
		min(AUDITORIUM_CAPACITY) as [Минимальная вместимость ауд.], 
		avg(AUDITORIUM_CAPACITY) as [Средняя вместимость ауд.], 
		sum(AUDITORIUM_CAPACITY) as [Суммарная вместимость всех ауд.],
		count(*) as [Общее кол-во ауд.]
	from AUDITORIUM;

-- 2
select	AUDITORIUM_TYPE.AUDITORIUM_TYPENAME as [Тип ауд.],
		max(AUDITORIUM.AUDITORIUM_CAPACITY) as [Максимальная вместимость],
		min(AUDITORIUM.AUDITORIUM_CAPACITY) as [Минимальная вместимость],
		avg(AUDITORIUM.AUDITORIUM_CAPACITY) as [Средняя вместимость],
		sum(AUDITORIUM.AUDITORIUM_CAPACITY) as [Суммарная вместимость всех ауд.],
		count(*) as [Общее кол-во ауд. данного типа]
	from AUDITORIUM_TYPE inner join AUDITORIUM
	on AUDITORIUM_TYPE.AUDITORIUM_TYPE = AUDITORIUM.AUDITORIUM_TYPE
	group by AUDITORIUM_TYPE.AUDITORIUM_TYPENAME;

-- 3
select *
from (select
			case 
				when PROGRESS.NOTE = 10 then '10'
				when PROGRESS.NOTE between 8 and 9 then '8-9'
				when PROGRESS.NOTE between 6 and 7 then '6-7'
				when PROGRESS.NOTE between 4 and 5 then '4-5'
				else 'не сдано'
-- обязательно даем столбцу название в следующей строке
			end [Оценки], 
			count(*) as [Количество]
			from PROGRESS
			group by case 
				when PROGRESS.NOTE = 10 then '10'
				when PROGRESS.NOTE between 8 and 9 then '8-9'
				when PROGRESS.NOTE between 6 and 7 then '6-7'
				when PROGRESS.NOTE between 4 and 5 then '4-5'
				else 'не сдано'
			end
		) as T
-- сортировка по значению строки в столбце [Оценки]
		order by case [Оценки]
					when '10' then 1
					when '8-9' then 2
					when '6-7' then 3
					when '4-5' then 4
					else 5
				end;

-- 4
select	FACULTY.FACULTY_NAME,
		GROUPS.PROFESSION,
		CASE
			WHEN GROUPS.YEAR_FIRST = 2013 then 1
			WHEN GROUPS.YEAR_FIRST = 2012 then 2
			WHEN GROUPS.YEAR_FIRST = 2011 then 3
			WHEN GROUPS.YEAR_FIRST = 2010 then 4
		END [Курс],
	round(avg (cast(PROGRESS.NOTE as float(4))), 2) as [Средняя оценка]
	from FACULTY inner join GROUPS
	on FACULTY.FACULTY = GROUPS.FACULTY
	inner join STUDENT
	on GROUPS.IDGROUP = STUDENT.IDGROUP
	inner join PROGRESS
	on STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
group by FACULTY.FACULTY_NAME,
	GROUPS.PROFESSION,
	GROUPS.YEAR_FIRST
order by [Средняя оценка] desc

-- 4 в расчете среднего значения оценок используются оценки только по дисциплинам с кодами БД и ОАиП				
select	FACULTY.FACULTY_NAME,
		GROUPS.PROFESSION,
-- год поступления ↓
		CASE
			WHEN GROUPS.YEAR_FIRST = 2013 then 1
			WHEN GROUPS.YEAR_FIRST = 2012 then 2
			WHEN GROUPS.YEAR_FIRST = 2011 then 3
			WHEN GROUPS.YEAR_FIRST = 2010 then 4
		END [Курс],
		round(avg (cast(PROGRESS.NOTE as float(4))), 2) as [Средняя оценка]
	from FACULTY inner join GROUPS
	on FACULTY.FACULTY = GROUPS.FACULTY
	inner join STUDENT
	on GROUPS.IDGROUP = STUDENT.IDGROUP
	inner join PROGRESS
	on STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
	where PROGRESS.SUBJECT in ('БД', 'ОАиП')
group by FACULTY.FACULTY_NAME,
	GROUPS.PROFESSION,
	GROUPS.YEAR_FIRST
order by [Средняя оценка] desc

-- 5 (без ROLLUP)
select	FACULTY.FACULTY,
		GROUPS.PROFESSION,
		PROGRESS.SUBJECT,
		round(avg (cast(PROGRESS.NOTE as float(4))), 2) as [Средняя оценка]
	from FACULTY inner join GROUPS
	on FACULTY.FACULTY = GROUPS.FACULTY
	inner join STUDENT
	on GROUPS.IDGROUP = STUDENT.IDGROUP
	inner join PROGRESS
	on STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
	where FACULTY.FACULTY = 'ТОВ'
group by FACULTY.FACULTY,
		GROUPS.PROFESSION,
		PROGRESS.SUBJECT

-- 5 (с ROLLUP)
select	FACULTY.FACULTY,
		GROUPS.PROFESSION,
		PROGRESS.SUBJECT,
		round(avg (cast(PROGRESS.NOTE as float(4))), 2) as [Средняя оценка]
	from FACULTY inner join GROUPS
	on FACULTY.FACULTY = GROUPS.FACULTY
	inner join STUDENT
	on GROUPS.IDGROUP = STUDENT.IDGROUP
	inner join PROGRESS
	on STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
	where FACULTY.FACULTY = 'ТОВ'
group by ROLLUP(FACULTY.FACULTY,
		GROUPS.PROFESSION,
		PROGRESS.SUBJECT)

-- 6
select	FACULTY.FACULTY,
		GROUPS.PROFESSION,
		PROGRESS.SUBJECT,
		round(avg (cast(PROGRESS.NOTE as float(4))), 2) as [Средняя оценка]
	from FACULTY inner join GROUPS
	on FACULTY.FACULTY = GROUPS.FACULTY
	inner join STUDENT
	on GROUPS.IDGROUP = STUDENT.IDGROUP
	inner join PROGRESS
	on STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
	where FACULTY.FACULTY = 'ТОВ'
group by CUBE(FACULTY.FACULTY,
		GROUPS.PROFESSION,
		PROGRESS.SUBJECT)

-- 7 (union)
select	GROUPS.FACULTY,
		GROUPS.PROFESSION,
		PROGRESS.SUBJECT,
		round(avg (cast(PROGRESS.NOTE as float(4))), 2) as [Средняя оценка]
		from GROUPS inner join STUDENT
			on GROUPS.IDGROUP = STUDENT.IDGROUP
			inner join PROGRESS
			on STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
			where GROUPS.FACULTY = 'ТОВ'
	group by GROUPS.FACULTY, GROUPS.PROFESSION, PROGRESS.SUBJECT
union
select	GROUPS.FACULTY,
		GROUPS.PROFESSION,
		PROGRESS.SUBJECT,
		round(avg (cast(PROGRESS.NOTE as float(4))), 2) as [Средняя оценка]
		from GROUPS inner join STUDENT
			on GROUPS.IDGROUP = STUDENT.IDGROUP
			inner join PROGRESS
			on STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
			where GROUPS.FACULTY = 'ХТиТ'
	group by GROUPS.FACULTY, GROUPS.PROFESSION, PROGRESS.SUBJECT

-- 7 (union all)
select	GROUPS.FACULTY,
		GROUPS.PROFESSION,
		PROGRESS.SUBJECT,
		round(avg (cast(PROGRESS.NOTE as float(4))), 2) as [Средняя оценка]
		from GROUPS inner join STUDENT
			on GROUPS.IDGROUP = STUDENT.IDGROUP
			inner join PROGRESS
			on STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
			where GROUPS.FACULTY = 'ТОВ'
	group by GROUPS.FACULTY, GROUPS.PROFESSION, PROGRESS.SUBJECT
union all
select	GROUPS.FACULTY,
		GROUPS.PROFESSION,
		PROGRESS.SUBJECT,
		round(avg (cast(PROGRESS.NOTE as float(4))), 2) as [Средняя оценка]
		from GROUPS inner join STUDENT
			on GROUPS.IDGROUP = STUDENT.IDGROUP
			inner join PROGRESS
			on STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
			where GROUPS.FACULTY = 'ХТиТ'
	group by GROUPS.FACULTY, GROUPS.PROFESSION, PROGRESS.SUBJECT

-- 8
select	GROUPS.FACULTY,
		GROUPS.PROFESSION,
		PROGRESS.SUBJECT,
		round(avg (cast(PROGRESS.NOTE as float(4))), 2) as [Средняя оценка]
		from GROUPS inner join STUDENT
			on GROUPS.IDGROUP = STUDENT.IDGROUP
			inner join PROGRESS
			on STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
			where GROUPS.FACULTY = 'ТОВ'
	group by GROUPS.FACULTY, GROUPS.PROFESSION, PROGRESS.SUBJECT
intersect
select	GROUPS.FACULTY,
		GROUPS.PROFESSION,
		PROGRESS.SUBJECT,
		round(avg (cast(PROGRESS.NOTE as float(4))), 2) as [Средняя оценка]
		from GROUPS inner join STUDENT
			on GROUPS.IDGROUP = STUDENT.IDGROUP
			inner join PROGRESS
			on STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
			where GROUPS.FACULTY = 'ХТиТ'
	group by GROUPS.FACULTY, GROUPS.PROFESSION, PROGRESS.SUBJECT

-- 9
select	GROUPS.FACULTY,
		GROUPS.PROFESSION,
		PROGRESS.SUBJECT,
		round(avg (cast(PROGRESS.NOTE as float(4))), 2) as [Средняя оценка]
		from GROUPS inner join STUDENT
			on GROUPS.IDGROUP = STUDENT.IDGROUP
			inner join PROGRESS
			on STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
			where GROUPS.FACULTY = 'ТОВ'
	group by GROUPS.FACULTY, GROUPS.PROFESSION, PROGRESS.SUBJECT
except
select	GROUPS.FACULTY,
		GROUPS.PROFESSION,
		PROGRESS.SUBJECT,
		round(avg (cast(PROGRESS.NOTE as float(4))), 2) as [Средняя оценка]
		from GROUPS inner join STUDENT
			on GROUPS.IDGROUP = STUDENT.IDGROUP
			inner join PROGRESS
			on STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
			where GROUPS.FACULTY = 'ХТиТ'
	group by GROUPS.FACULTY, GROUPS.PROFESSION, PROGRESS.SUBJECT

-- 10
select	p1.IDSTUDENT as [ИД студента], 
		p1.NOTE as [Оценка],
		(select count(*) from PROGRESS as p2
			where p1.IDSTUDENT = p2.IDSTUDENT
			and p1.NOTE = p2.NOTE
		) as [Количество студентов, получивших оценки 8 и 9]
	from PROGRESS as p1
	group by p1.IDSTUDENT, p1.NOTE
	having p1.NOTE in (8, 9)

-- 12.1
select	FACULTY.FACULTY,
		GROUPS.IDGROUP,
		count (*) as [Кол-во студентов]
		from FACULTY inner join GROUPS
		on FACULTY.FACULTY = GROUPS.FACULTY
		inner join STUDENT
		on GROUPS.IDGROUP = STUDENT.IDGROUP
		group by rollup(FACULTY.FACULTY, GROUPS.IDGROUP)

