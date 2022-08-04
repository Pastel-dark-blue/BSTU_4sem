--USE master
--CREATE database Ku_MyBase_3

USE Ku_MyBase_3

CREATE TABLE �������� (
	���_�������� int PRIMARY KEY,
	������� nvarchar(50),
	��� nvarchar(50),
	�������� nvarchar(50),
	���� smallint CONSTRAINT experience_positive CHECK(���� > 0),
);

CREATE TABLE �������� (
	���_�������� int PRIMARY KEY,
	�������� nvarchar(50),
	[���������, ��] float CONSTRAINT distance_positive CHECK([���������, ��] > 0),
);

CREATE TABLE ���������(
	���_��������� int PRIMARY KEY,
	���_�������� int FOREIGN KEY REFERENCES ��������(���_��������),
	����_�������� datetime,
	����_����������� datetime,
);

CREATE TABLE [�������� �� ����������] (
	���_��������� int FOREIGN KEY REFERENCES ���������(���_���������),
	���_�������� int FOREIGN KEY REFERENCES ��������(���_��������),
	[������, USD] smallmoney CONSTRAINT payment_positive CHECK([������, USD] > 0),
	PRIMARY KEY (���_���������, ���_��������),
);

----������� ������� "���" � ������� "��������", ������ ��� ��������� �������� � �����������
--ALTER TABLE ��������
--	ADD ��� nchar(1)
--		DEFAULT '�'
--		CONSTRAINT gender_male_female CHECK(��� IN ('�', '�'));

----������� �����������
--ALTER TABLE ��������
--	DROP CONSTRAINT DF__��������__���__4CA06362, gender_male_female;

----������� �������
--ALTER TABLE ��������
--	DROP COLUMN ���;

INSERT INTO ��������
	VALUES (1, '��������', '�����', '����������', 5),
		   (2, '�������', '����', '���������', 2);

INSERT INTO ��������
	VALUES (1, '������ - �����', 310),
		   (2, '����� - �������', 627.4),
		   (3, '����� - �������', 197.8);

INSERT INTO ���������
	VALUES (1, 1, '20211112', '20211113'),
		   (2, 2, '20220212',	'20220213'),
		   (3, 3, '20220308', '20220309');

INSERT INTO [�������� �� ����������]
	VALUES (1, 1, 200.0000),
		   (1, 2, 160.0000),
		   (2, 2, 180.0000);

SELECT * FROM ��������;

SELECT ���_��������, ������� FROM ��������;

SELECT count(*) FROM ��������;

SELECT Distinct Top(1) * FROM [�������� �� ����������]
	WHERE [������, USD] > 160;

UPDATE [�������� �� ����������] 
	SET [������, USD] = 165 
	WHERE ���_��������� = 1 AND ���_�������� = 2;

SELECT ���_��������, ���_���������
	FROM [�������� �� ����������] 
	WHERE [������, USD] BETWEEN 165 AND 230;

SELECT * 
	FROM ��������
	WHERE �������� LIKE '[�-�]%';

SELECT ��������
	FROM ��������
	WHERE [���������, ��] IN (627.4, 197.8);

----�������� ����� �� � ���������� � ������ �� �������� �������
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

