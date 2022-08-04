--	1 ����� ���������, ������� ���� �� ��������, � �������� ������� ���������� ����� "�����" ��� "������" � ������� ���� ��������� �� ���� ����������
-- �� ������ ������ "��������", "���������", "�������� �� ����������"
--	����������: ������������ � ������ WHERE �������� IN c ����������������� ����������� � ������� ��������
select distinct ���_��������
	from [�������� �� ����������], ���������
	where [�������� �� ����������].���_��������� = ���������.���_���������
	and
	���������.���_�������� in
	(select ���_��������
		from ��������
			where �������� like '%�����%'
			or �������� like '%������%');

--	2 ���������� ������ ������ 1 ����� �������, ����� ��� �� ��������� ��� ������� � ����������� INNER JOIN ������ FROM �������� �������. ��� ���� ��������� ���������� ������� ������ ���� ����������� ���������� ��������� �������. 
select distinct ���_��������
	from [�������� �� ����������] inner join ���������
	on [�������� �� ����������].���_��������� = ���������.���_���������
	and
	���������.���_�������� in
	(select ���_��������
		from ��������
			where �������� like '%�����%'
			or �������� like '%������%');

--	3 ���������� ������, ����������� 1 ����� ��� ������������� ����������. ����������: ������������ ���������� INNER JOIN ���� ������. 
select distinct ���_��������
	from [�������� �� ����������] inner join ���������
	on [�������� �� ����������].���_��������� = ���������.���_���������
	inner join ��������
		on ���������.���_�������� = ��������.���_��������
		and (�������� like '%�����%'
			or �������� like '%������%');

--	4 ��� ������� �������� ����� ��� ���������, �� ������� ��(�) �������(�) ���������� ������ 
-- ��� ���� ��������� ������� ������������� � ������� �������� �����������. ����������: ������������ ������������� ��������� c �������� TOP � ORDER BY. 
select *
		from [�������� �� ����������] as a
		where a.���_��������� = (
			select top(1) ���_���������
			from [�������� �� ����������] as b
			where a.���_�������� = b.���_��������
			order by b.[������, USD] desc
		);

--	5 ������������ ������ ���������, �� ���� �� �������� �� ����������
-- ����������: ������������ �������� EXISTS � ��������������� ���������. 
select *
	from ��������
	where not exists(
		select *
			from [�������� �� ����������]
			where [�������� �� ����������].���_�������� = ��������.���_��������)

--	6 �� ������ ������ [�������� �� ����������] � ��������� ������������ ������, ���������� ������� �������� ������ �� �������� � ����� 1, 2 � 3
-- ����������: ������������ ��� ����������������� ���������� � ������ SELECT; � ����������� ��������� ���������� ������� AVG. 
select top(1)
	(select avg([������, USD]) 
		from [�������� �� ����������], ���������
			where [�������� �� ����������].���_��������� = ���������.���_���������
			and 
			���������.���_�������� = 1) as [������� 1],
	(select avg([������, USD]) 
		from [�������� �� ����������], ���������
			where [�������� �� ����������].���_��������� = ���������.���_���������
			and 
			���������.���_�������� = 2) as [������� 2],
	(select avg([������, USD]) 
		from [�������� �� ����������], ���������
			where [�������� �� ����������].���_��������� = ���������.���_���������
			and 
			���������.���_�������� = 3) as [������� 3];

--	7 ������� �������(�) � ���������� ����������
-- ����������� SELECT-������, ��������������� ������� ���������� ALL ��������� � �����������.
select *
	from ��������
		where [���������, ��] >=all(
			select [���������, ��] 
				from �������� 
		);

--	8 ������� ��������, ��������� ������� ��������� ���� �� ���� �������, ���������� "�����" � ����� ��������
-- ����������� SELECT-������, ��������������� ������� ���������� ANY ��������� � �����������.
select *
	from ��������
		where [���������, ��] >any(
			select [���������, ��] 
				from ��������
				where �������� like '%�����%'
		);

