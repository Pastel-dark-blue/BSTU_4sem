--USE master
--CREATE database Ku_MyBase_3

USE Ku_MyBase_3

CREATE TABLE Водители (
	Код_водителя int PRIMARY KEY,
	Фамилия nvarchar(50),
	Имя nvarchar(50),
	Отчество nvarchar(50),
	Стаж smallint CONSTRAINT experience_positive CHECK(Стаж > 0),
);

CREATE TABLE Маршруты (
	Код_маршрута int PRIMARY KEY,
	Название nvarchar(50),
	[Дальность, км] float CONSTRAINT distance_positive CHECK([Дальность, км] > 0),
);

CREATE TABLE Перевозки(
	Код_перевозки int PRIMARY KEY,
	Код_маршрута int FOREIGN KEY REFERENCES Маршруты(Код_маршрута),
	Дата_отправки datetime,
	Дата_возвращения datetime,
);

CREATE TABLE [Водители на перевозках] (
	Код_перевозки int FOREIGN KEY REFERENCES Перевозки(Код_перевозки),
	Код_водителя int FOREIGN KEY REFERENCES Водители(Код_водителя),
	[Оплата, USD] smallmoney CONSTRAINT payment_positive CHECK([Оплата, USD] > 0),
	PRIMARY KEY (Код_перевозки, Код_водителя),
);

----создаем столбец "Пол" в таблице "Водители", задаем ему дефолтное значение и ограничение
--ALTER TABLE Водители
--	ADD Пол nchar(1)
--		DEFAULT 'ж'
--		CONSTRAINT gender_male_female CHECK(Пол IN ('м', 'ж'));

----удаляем ограничения
--ALTER TABLE Водители
--	DROP CONSTRAINT DF__Водители__Пол__4CA06362, gender_male_female;

----удаляем столбец
--ALTER TABLE Водители
--	DROP COLUMN Пол;

INSERT INTO Водители
	VALUES (1, 'Хмельная', 'Ольга', 'Викторовна', 5),
		   (2, 'Поляруш', 'Иван', 'Андреевич', 2);

INSERT INTO Маршруты
	VALUES (1, 'Гомель - Минск', 310),
		   (2, 'Брест - Витебск', 627.4),
		   (3, 'Минск - Могилев', 197.8);

INSERT INTO Перевозки
	VALUES (1, 1, '20211112', '20211113'),
		   (2, 2, '20220212',	'20220213'),
		   (3, 3, '20220308', '20220309');

INSERT INTO [Водители на перевозках]
	VALUES (1, 1, 200.0000),
		   (1, 2, 160.0000),
		   (2, 2, 180.0000);

SELECT * FROM Маршруты;

SELECT Код_водителя, Фамилия FROM Водители;

SELECT count(*) FROM Водители;

SELECT Distinct Top(1) * FROM [Водители на перевозках]
	WHERE [Оплата, USD] > 160;

UPDATE [Водители на перевозках] 
	SET [Оплата, USD] = 165 
	WHERE Код_перевозки = 1 AND Код_водителя = 2;

SELECT Код_водителя, Код_перевозки
	FROM [Водители на перевозках] 
	WHERE [Оплата, USD] BETWEEN 165 AND 230;

SELECT * 
	FROM Водители
	WHERE Отчество LIKE '[А-Б]%';

SELECT Название
	FROM Маршруты
	WHERE [Дальность, км] IN (627.4, 197.8);

----Создание новой БД и размещение её файлов по файловым группам
--CREATE DATABASE Ku_MyBase_3_7
--	ON PRIMARY (name='Ku_MyBase_3_mdf', filename='D:\DB\Ku_MyBase_3_mdf.mdf',
--				size=10240Kb, maxsize=unlimited, filegrowth=1024Kb),
--	FILEGROUP laba_3_7 (name='Ku_MyBase_3_ndf', filename='D:\DB\Ku_MyBase_3_ndf.ndf',
--				size=10240Kb, maxsize=500Mb, filegrowth=64Kb)
--	LOG ON (name='Ku_MyBase_3_log', filename='D:\DB\Ku_MyBase_3_log.ldf',
--				size=10240Kb, maxsize=500Mb, filegrowth=64Kb)

--USE Ku_MyBase_3_7;

--CREATE TABLE GintamaChars(
--	Name nvarchar(50),
--	Surname nvarchar(50),
--	Age int CONSTRAINT age_positive CHECK(Age>0)
--) on laba_3_7;

