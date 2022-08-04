---------------------------------- уровень 1
use examDB;
-- 1
select CUST, COUNT(*), AVG(AMOUNT)
from ORDERS
group by CUST
order by AVG(AMOUNT)

-- 2
select SALESREPS.*, AMOUNT
from SALESREPS inner join ORDERS
on SALESREPS.EMPL_NUM=ORDERS.REP
where ORDERS.AMOUNT>15000
order by(AMOUNT)

-- 3
select	sum(QTY_ON_HAND) as [amount],
		avg(PRICE) as [avg price],
		MFR_ID
from PRODUCTS
group by(MFR_ID)

-- 4
select CUST_NUM, ORDER_NUM
from CUSTOMERS c left join ORDERS o
on c.CUST_NUM=o.CUST
where ORDER_NUM is null
group by  CUST_NUM, ORDER_NUM;

-- 5
select ord.*
from OFFICES o inner join SALESREPS s
on o.OFFICE=s.REP_OFFICE
inner join ORDERS ord
on ord.REP=s.MANAGER
where o.REGION like '%east%'

---------------------------------- уровень 2
go
create procedure addStringOffices 
	@office int,
	@city varchar(15), 
	@region varchar(10),
	@mgr int,
	@target decimal(9,2),
	@sales decimal(9,2)
as
begin try
	insert into OFFICES values(@office, @city, @region, @mgr, @target, @sales);
end try
begin catch
	print 'Номер ошибки: ' + cast(error_number() as varchar(100));
	print 'Сообщение: ' + cast(error_message() as varchar(100));
	print 'Строка возникновения ошибки: ' + cast(error_line() as varchar(100));
	print 'Уровень серезности: ' + cast(error_severity() as varchar(100));
	print 'Процедура, где возникла ошибка: ' + cast(error_procedure() as varchar(100));
end catch;

exec addStringOffices 23, 'city', 'region', 108, 45.7, 98.453;

-- 2
go
create function ordersAmountFunc (@company varchar(20))
returns int
as 
begin

	declare @a int = (select count(*)
	from ORDERS o inner join CUSTOMERS c
	on o.CUST=c.CUST_NUM
	where c.COMPANY=@company);

	if @a = 0
		set @a=-1;
	
	return @a;
end;

go
print 'Заказов от компании First Corp.: ' + cast(dbo.ordersAmountFunc('First Corp.') as varchar(10));

-- 3
go
create function amountMoreThan(@price decimal(9,2))
returns int
as
begin
	return (select count(*)
		from SALESREPS s inner join ORDERS o
		on s.EMPL_NUM=o.REP
		where o.AMOUNT>@price)
end;

go
print dbo.amountMoreThan(31349);

-- 4
go
create proc amoutProducts @mfrId char(3)
as
begin 
	declare @a int = (select count(*) 
		from PRODUCTS
		where MFR_ID=@mfrId);

	if @a =0 
		set @a=-1;

	return @a;
end;

declare @am int;
exec @am = amoutProducts 'ACI';
print @am;

-- 5
go
create procedure findOrders 
	@company varchar(20), @startDate date, @endDate date
as
begin
	declare @a int = (select count(*)
	from ORDERS o inner join CUSTOMERS c
	on o.CUST=c.CUST_NUM
	where COMPANY=@company 
	and ORDER_DATE between @startDate and @endDate);

	if @a=0
		set @a=-1

	return @a;
end;

declare @amount int;
exec @amount=findOrders 'Jones Mfg.', '20071218', '20090101';
print @amount;