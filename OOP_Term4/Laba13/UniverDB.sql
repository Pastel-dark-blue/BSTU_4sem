create database Univer;
use Univer;

create table Subject(
	Id int identity(1,1) primary key,
	Subject nvarchar(170) unique,
);

create table Student(
	Id int identity(1,1) primary key,
	Fio nvarchar(200),
	Faculty nvarchar(200),
	Spec nvarchar(200),
	Group_ int,
	Subgroup int,
	Course int,
);

create table StudSub(
	Id int identity(1,1) primary key,
	StudId int foreign key references Student(Id),
	SubId int foreign key references Subject(Id),
	Mark int,
	MissedHours int,
);


insert into Subject values('���'), ('�����'), ('��'), ('���');

insert into Student values	('���������� �.�.', '���', '������', 7, 2, 2),
							('������� �.�.', '���', '������', 7, 2, 2),
							('������� ������', '���', '??', 10, 2, 3),
							('���� ����', '���', '������', 7, 2, 2),
							('������ ��������', '����', '??', 3, 2, 2),
							('���-�� �� �� �����', '??', '??', 3, 1, 4);

insert into StudSub values	(3, 4, 7, 4),
							(4, 2, 7, 8),
							(5, 5, 7, 6),
							(6, 4, 4, 5),
							(7, 3, 4, 8),
							(3, 2, 4, 9),
							(4, 3, 4, 5),
							(4, 3, 3, 6),
							(4, 3, 8, 5),
							(5, 5, 2, 9),
							(3, 2, 8, 9);