-- ���� �� Shop �� ����������, ������� �
if not exists (
	select * from sys.databases
	where name = 'Shop')
begin
	create database Shop;
end;

use Shop;
-- ���� ������� �� ����������, ������� �

-- ������� � ������ ������� (������������, ���������������)
if not exists (
	select * from sys.objects
	where object_id = object_id('TypesEnum'))
begin
	create table TypesEnum(
		Name nvarchar(20) primary key,
	);
end;

-- ������� � �������������-���������������
if not exists (
	select * from sys.objects
	where object_id = object_id('Organization'))
begin
	create table Organization(
		Id int primary key identity(1,1),
		Organization nvarchar(50) not null,
		Country nvarchar(30),
		Region nvarchar(30),
		City nvarchar(30),
		Street nvarchar(30),
		House int,
		Phone varchar(20),
	);
end;

-- ������� � ����������� � �������
if not exists (
	select * from sys.objects
	where object_id = object_id('Good'))
begin
	create table Good(
		Id int primary key identity(1,1),
		Name varchar(50) not null,
		Width_cm float,
		Height_cm float,
		Length_cm float,
		Weight_kg float,
		Type nvarchar(20) foreign key references TypesEnum(Name),
		Date datetime,
		Amount int,
		Price_$ float,
		ManufacturerId int foreign key references Organization(Id),
		Photo varchar(max),
	);
end;

insert TypesEnum values('������������'),('���������������');

insert Organization values
	('�������� ���', '������', '����������� �������', '���������', '��������', 13, '+375(44)554-78-21');

insert Organization values
	('�������� ���', '������', '����������� �������', '���������', '��������', 14, '+375(44)554-78-22');

insert Good values 
	('������ �������', null, null, null, 1, '���������������', 07-05-2022, null, 1.7, 1, cast('D:\���\OOP_Course2_Term2\Lab10\red_apples.jpg' as varbinary(max)));

