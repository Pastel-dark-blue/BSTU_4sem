use Ku_MyBase_2;

-- 1
go
create view [????????????? ?????????] as
	select * from ????????;

-- 2 ????????????? ?????????? ?????? "????????" ? "???????? ?? ??????????", ?????????? ???_????????, ??? ???????? ? ???_?????????
go
create view [????????_?????????] as
	select	????????.???_????????,
			????????.???????,
			????????.???,
			????????.????????,
			[???????? ?? ??????????].???_?????????
	from ???????? inner join [???????? ?? ??????????]
	on ????????.???_???????? = [???????? ?? ??????????].???_????????;

-- 3 ????????????? ? ?????????? ?? ?????? ?? 5 ???, ?????? ????????? ?????????? ????????? INSERT, UPDATE ? DELETE
go
create view [???????? ?? ?????? ?? 5 ???] as
	select * from ????????
	where ???? >= 5;

-- ????????????? ?????? 3 ????????? ????????????? INSERT, UPDATE ? DELETE
-- ?????? ?????? ?? ????????????? ??????? "???? >= 5", ??????? ?? ??????? ? ?????????????, ???? ???????? ? ??????? 
go
insert [???????? ?? ?????? ?? 5 ???] values('??????', '?????????', '????????????', 4);

-- 4 ?????????? ????????????? ?????? 3 ? ?????? WITH CHECK OPTION
go
create view [???????? ?? ?????? ?? 5 ??? ? ?????????] as
	select * from ????????
	where ???? >= 5
	WITH CHECK OPTION;

-- ?????? ?????? ?? ????????????? ??????? "???? >= 5", ??????? ?? ??????? ? ?????????????
-- ? ??? ??? ? ????????????? ??????? ????? WITH CHECK OPTION, ?? ??? ?????? ? ? ??????? ?? ???????
-- ??????? ??????
go
insert [???????? ?? ?????? ?? 5 ??? ? ?????????] values('?????', '???????', '???????', 4);

-- 5
go
create view [????????????? ????????? ? ???????????] as
	select TOP 10 * from ????????
	order by ????????;

-- 6
go
alter view dbo.[????????_?????????] 
with schemabinding
as
	select	????????.???_????????,
			????????.???????,
			????????.???,
			????????.????????,
			[???????? ?? ??????????].???_?????????
	from dbo.???????? inner join dbo.[???????? ?? ??????????]
	on ????????.???_???????? = [???????? ?? ??????????].???_????????;

