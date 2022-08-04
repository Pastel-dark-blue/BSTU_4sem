-- если БД Shop не существует, создаем её
if not exists (
	select * from sys.databases
	where name = 'Shop')
begin
	create database Shop;
end;

use Shop;
-- если таблицы не существует, создаем её

-- таблица с типами товаров (промышленный, потребительский)
if not exists (
	select * from sys.objects
	where object_id = object_id('TypesEnum'))
begin
	create table TypesEnum(
		Name nvarchar(20) primary key,
	);
end;

-- таблица с организациями-производителями
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

-- таблица с информацией о товарах
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

insert TypesEnum values('промышленный'),('потребительский');

insert Organization values
	('Яблочный бог', 'Россия', 'Ярославская область', 'Ярославль', 'Вишневая', 13, '+375(44)554-78-21');

insert Organization values
	('Грушевый бог', 'Россия', 'Ярославская область', 'Ярославль', 'Вишневая', 14, '+375(44)554-78-22');

insert Good values 
	('Яблоки красные', null, null, null, 1, 'потребительский', 07-05-2022, null, 1.7, 1, cast('D:\ООП\OOP_Course2_Term2\Lab10\red_apples.jpg' as varbinary(max)));

