USE UNIVERSITY;
--1
SELECT AUDITORIUM.AUDITORIUM, AUDITORIUM_TYPE.AUDITORIUM_TYPENAME
	FROM AUDITORIUM INNER JOIN AUDITORIUM_TYPE
	ON AUDITORIUM.AUDITORIUM_TYPE = AUDITORIUM_TYPE.AUDITORIUM_TYPE;

--2
SELECT AUDITORIUM.AUDITORIUM, AUDITORIUM_TYPE.AUDITORIUM_TYPENAME
	FROM AUDITORIUM INNER JOIN AUDITORIUM_TYPE
	ON AUDITORIUM.AUDITORIUM_TYPE = AUDITORIUM_TYPE.AUDITORIUM_TYPE AND
	AUDITORIUM_TYPE.AUDITORIUM_TYPENAME LIKE '%компьютер%';

--3
SELECT AUDITORIUM.AUDITORIUM, AUDITORIUM_TYPE.AUDITORIUM_TYPENAME
	FROM AUDITORIUM, AUDITORIUM_TYPE
	WHERE AUDITORIUM.AUDITORIUM_TYPE = AUDITORIUM_TYPE.AUDITORIUM_TYPE;

SELECT AUDITORIUM.AUDITORIUM, AUDITORIUM_TYPE.AUDITORIUM_TYPENAME
	FROM AUDITORIUM, AUDITORIUM_TYPE
	WHERE AUDITORIUM.AUDITORIUM_TYPE = AUDITORIUM_TYPE.AUDITORIUM_TYPE AND
	AUDITORIUM_TYPE.AUDITORIUM_TYPENAME LIKE '%компьютер%';

--4
SELECT  FACULTY.FACULTY_NAME  AS Факультет,
		PULPIT.PULPIT_NAME AS Кафедра,
		PROFESSION.PROFESSION_NAME AS Специальность,
		SUBJECT.SUBJECT_NAME AS Дисциплина,
		STUDENT.NAME AS [Имя студента],
		CASE PROGRESS.NOTE
			WHEN 6 THEN 'шесть'
			WHEN 7 THEN 'семь'
			WHEN 8 THEN 'восемь'
		END AS Оценка
	FROM PROGRESS 
		INNER JOIN STUDENT ON PROGRESS.IDSTUDENT = STUDENT.IDSTUDENT
		INNER JOIN GROUPS ON STUDENT.IDGROUP = GROUPS.IDGROUP
		INNER JOIN SUBJECT ON SUBJECT.SUBJECT = PROGRESS.SUBJECT
		INNER JOIN PULPIT ON SUBJECT.PULPIT = PULPIT.PULPIT
		INNER JOIN FACULTY ON PULPIT.FACULTY = FACULTY.FACULTY
		INNER JOIN PROFESSION ON FACULTY.FACULTY = PROFESSION.FACULTY
	WHERE PROGRESS.NOTE BETWEEN 6 AND 8
	ORDER BY FACULTY.FACULTY, 
		PULPIT.PULPIT, 
		PROFESSION.PROFESSION, 
		STUDENT.NAME,
		PROGRESS.NOTE DESC;

--5
SELECT  FACULTY.FACULTY_NAME  AS Факультет,
		PULPIT.PULPIT_NAME AS Кафедра,
		PROFESSION.PROFESSION_NAME AS Специальность,
		SUBJECT.SUBJECT_NAME AS Дисциплина,
		STUDENT.NAME AS [Имя студента],
		CASE PROGRESS.NOTE
			WHEN 6 THEN 'шесть'
			WHEN 7 THEN 'семь'
			WHEN 8 THEN 'восемь'
		END AS Оценка
	FROM PROGRESS 
		INNER JOIN STUDENT ON PROGRESS.IDSTUDENT = STUDENT.IDSTUDENT
		INNER JOIN GROUPS ON STUDENT.IDGROUP = GROUPS.IDGROUP
		INNER JOIN SUBJECT ON SUBJECT.SUBJECT = PROGRESS.SUBJECT
		INNER JOIN PULPIT ON SUBJECT.PULPIT = PULPIT.PULPIT
		INNER JOIN FACULTY ON PULPIT.FACULTY = FACULTY.FACULTY
		INNER JOIN PROFESSION ON FACULTY.FACULTY = PROFESSION.FACULTY
	WHERE PROGRESS.NOTE BETWEEN 6 AND 8
	ORDER BY 
		(CASE 
			WHEN PROGRESS.NOTE = 7 THEN 1
			WHEN PROGRESS.NOTE = 8 THEN 2
			WHEN PROGRESS.NOTE = 6 THEN 3
		END),
		FACULTY.FACULTY, 
		PULPIT.PULPIT, 
		PROFESSION.PROFESSION, 
		STUDENT.NAME,
		PROGRESS.NOTE DESC;
		
--6
SELECT PULPIT.PULPIT_NAME AS Кафедра,
	isnull(TEACHER.TEACHER_NAME, '***') AS Преподаватель
	FROM PULPIT LEFT JOIN TEACHER
	ON PULPIT.PULPIT = TEACHER.PULPIT;

--7.1 
SELECT PULPIT.PULPIT_NAME AS Кафедра,
	isnull(TEACHER.TEACHER_NAME, '***') AS Преподаватель
	FROM TEACHER LEFT JOIN PULPIT
	ON PULPIT.PULPIT = TEACHER.PULPIT;

--7.2 
SELECT PULPIT.PULPIT_NAME AS Кафедра,
	isnull(TEACHER.TEACHER_NAME, '***') AS Преподаватель
	FROM TEACHER RIGHT JOIN PULPIT
	ON PULPIT.PULPIT = TEACHER.PULPIT;

--8 
--создаем две таблицы для примеров
CREATE TABLE Товары(
	ИД int identity(1,1) PRIMARY KEY,
	Название nvarchar(50)
);

CREATE TABLE Заказы(
	ИД int identity(16,1) PRIMARY KEY,
	Товар int FOREIGN KEY
					references Товары (ИД),
	Дата_заказа datetime,
);

--заполняем таблицы
INSERT INTO Товары
	VALUES
		('Кимоно'),
		('Волшебный кинжал'),
		('Электрогитара'),
		('Деревянный меч'),
		('DVD "Гинтама"'),
		('Набор для убийства'),
		('Проклятие'),
		('Почка');

INSERT INTO Заказы
	VALUES
		(1, '20220308'),
		(7, '20220308'),
		(5, '20220308'),
		(3, '20220308'),
		(7, '20220428'),
		(7, '20220308'),
		(1, '20220308'),
		(7, '20220308'),
		(8, '20210408'),
		(3, '20220308'),
		(1, '20210304'),
		(3, '20220308'),
		(7, '20220308'),
		(5, '20220211'),
		(NULL, '20200308'),
		(NULL, '20220211');

--8.1 (коммутативность FULL JOIN)
SELECT Товары.Название, Заказы.Дата_заказа, Заказы.ИД
	FROM Товары FULL JOIN Заказы
	ON Товары.ИД = Заказы.Товар;

SELECT Товары.Название, Заказы.Дата_заказа, Заказы.ИД
	FROM Заказы FULL JOIN Товары
	ON Товары.ИД = Заказы.Товар;

--8.2 (соединение FULL OUTER JOIN двух таблиц является объединением LEFT OUTER JOIN и RIGHT OUTER JOIN соединений этих таблиц)
SELECT Товары.Название, Заказы.Дата_заказа, Заказы.ИД
	FROM Товары LEFT JOIN Заказы
	ON Товары.ИД = Заказы.Товар
UNION 
SELECT Товары.Название, Заказы.Дата_заказа, Заказы.ИД
	FROM Товары RIGHT JOIN Заказы
	ON Товары.ИД = Заказы.Товар;

--8.3 (соединение FULL OUTER JOIN включает соединение INNER JOIN этих таблиц)
SELECT Товары.Название, Заказы.Дата_заказа, Заказы.ИД
	FROM Товары INNER JOIN Заказы
	ON Товары.ИД = Заказы.Товар;

--8.4 (запрос, результат которого содержит данные левой (в операции FULL OUTER JOIN) таблицы и не содержит данные правой)
--содержит все значения таблицы слева (LEFT JOIN короче)
SELECT Товары.ИД as ИД_товара,
	Товары.Название as Название_товара,
	Заказы.ИД as ИД_заказа
	FROM Товары FULL JOIN Заказы
	ON Товары.ИД = Заказы.Товар
	WHERE Товары.ИД IS NOT NULL;

--содержит все значения таблицы слева, кроме тех, что соответствуют значениям из таблицы справа (LEFT JOIN с исключением INNER JOIN'а)
SELECT Товары.ИД as ИД_товара,
	Товары.Название as Название_товара,
	Заказы.ИД as ИД_заказа
	FROM Товары FULL JOIN Заказы
	ON Товары.ИД = Заказы.Товар
	WHERE Товары.ИД IS NOT NULL AND Заказы.Товар IS NULL;

--8.5 (запрос, результат которого содержит данные правой таблицы и не содержащие данные левой)
--содержит все значения таблицы справа (RIGHT JOIN короче)
SELECT Товары.ИД as ИД_товара,
	Товары.Название as Название_товара,
	Заказы.ИД as ИД_заказа
	FROM Товары FULL JOIN Заказы
	ON Товары.ИД = Заказы.Товар
	WHERE Заказы.ИД IS NOT NULL;

--содержит все значения таблицы справа, кроме тех, что соответствуют значениям из таблицы слева (RIGHT JOIN с исключением INNER JOIN'а)
SELECT Товары.ИД as ИД_товара,
	Товары.Название as Название_товара,
	Заказы.ИД as ИД_заказа
	FROM Товары FULL JOIN Заказы
	ON Товары.ИД = Заказы.Товар
	WHERE Заказы.ИД IS NOT NULL AND Товары.ИД IS NULL;

--8.6 (запрос, результат которого содержит данные правой таблицы и левой таблиц)
SELECT Заказы.ИД AS [ИД заказа],
	Заказы.Дата_заказа AS [Дата заказа],
	Заказы.Товар [ИД товара из заказа],
	Товары.ИД AS [ИД товара],
	Товары.Название AS [Название товара]
	FROM Заказы FULL JOIN Товары
	ON Товары.ИД = Заказы.Товар;

--9
SELECT AUDITORIUM.AUDITORIUM, AUDITORIUM_TYPE.AUDITORIUM_TYPENAME
	FROM AUDITORIUM CROSS JOIN AUDITORIUM_TYPE
	WHERE AUDITORIUM.AUDITORIUM_TYPE = AUDITORIUM_TYPE.AUDITORIUM_TYPE;

