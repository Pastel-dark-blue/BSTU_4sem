USE UNIVERSITY;
--1
SELECT AUDITORIUM.AUDITORIUM, AUDITORIUM_TYPE.AUDITORIUM_TYPENAME
	FROM AUDITORIUM INNER JOIN AUDITORIUM_TYPE
	ON AUDITORIUM.AUDITORIUM_TYPE = AUDITORIUM_TYPE.AUDITORIUM_TYPE;

--2
SELECT AUDITORIUM.AUDITORIUM, AUDITORIUM_TYPE.AUDITORIUM_TYPENAME
	FROM AUDITORIUM INNER JOIN AUDITORIUM_TYPE
	ON AUDITORIUM.AUDITORIUM_TYPE = AUDITORIUM_TYPE.AUDITORIUM_TYPE AND
	AUDITORIUM_TYPE.AUDITORIUM_TYPENAME LIKE '%���������%';

--3
SELECT AUDITORIUM.AUDITORIUM, AUDITORIUM_TYPE.AUDITORIUM_TYPENAME
	FROM AUDITORIUM, AUDITORIUM_TYPE
	WHERE AUDITORIUM.AUDITORIUM_TYPE = AUDITORIUM_TYPE.AUDITORIUM_TYPE;

SELECT AUDITORIUM.AUDITORIUM, AUDITORIUM_TYPE.AUDITORIUM_TYPENAME
	FROM AUDITORIUM, AUDITORIUM_TYPE
	WHERE AUDITORIUM.AUDITORIUM_TYPE = AUDITORIUM_TYPE.AUDITORIUM_TYPE AND
	AUDITORIUM_TYPE.AUDITORIUM_TYPENAME LIKE '%���������%';

--4
SELECT  FACULTY.FACULTY_NAME  AS ���������,
		PULPIT.PULPIT_NAME AS �������,
		PROFESSION.PROFESSION_NAME AS �������������,
		SUBJECT.SUBJECT_NAME AS ����������,
		STUDENT.NAME AS [��� ��������],
		CASE PROGRESS.NOTE
			WHEN 6 THEN '�����'
			WHEN 7 THEN '����'
			WHEN 8 THEN '������'
		END AS ������
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
SELECT  FACULTY.FACULTY_NAME  AS ���������,
		PULPIT.PULPIT_NAME AS �������,
		PROFESSION.PROFESSION_NAME AS �������������,
		SUBJECT.SUBJECT_NAME AS ����������,
		STUDENT.NAME AS [��� ��������],
		CASE PROGRESS.NOTE
			WHEN 6 THEN '�����'
			WHEN 7 THEN '����'
			WHEN 8 THEN '������'
		END AS ������
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
SELECT PULPIT.PULPIT_NAME AS �������,
	isnull(TEACHER.TEACHER_NAME, '***') AS �������������
	FROM PULPIT LEFT JOIN TEACHER
	ON PULPIT.PULPIT = TEACHER.PULPIT;

--7.1 
SELECT PULPIT.PULPIT_NAME AS �������,
	isnull(TEACHER.TEACHER_NAME, '***') AS �������������
	FROM TEACHER LEFT JOIN PULPIT
	ON PULPIT.PULPIT = TEACHER.PULPIT;

--7.2 
SELECT PULPIT.PULPIT_NAME AS �������,
	isnull(TEACHER.TEACHER_NAME, '***') AS �������������
	FROM TEACHER RIGHT JOIN PULPIT
	ON PULPIT.PULPIT = TEACHER.PULPIT;

--8 
--������� ��� ������� ��� ��������
CREATE TABLE ������(
	�� int identity(1,1) PRIMARY KEY,
	�������� nvarchar(50)
);

CREATE TABLE ������(
	�� int identity(16,1) PRIMARY KEY,
	����� int FOREIGN KEY
					references ������ (��),
	����_������ datetime,
);

--��������� �������
INSERT INTO ������
	VALUES
		('������'),
		('��������� ������'),
		('�������������'),
		('���������� ���'),
		('DVD "�������"'),
		('����� ��� ��������'),
		('���������'),
		('�����');

INSERT INTO ������
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

--8.1 (��������������� FULL JOIN)
SELECT ������.��������, ������.����_������, ������.��
	FROM ������ FULL JOIN ������
	ON ������.�� = ������.�����;

SELECT ������.��������, ������.����_������, ������.��
	FROM ������ FULL JOIN ������
	ON ������.�� = ������.�����;

--8.2 (���������� FULL OUTER JOIN ���� ������ �������� ������������ LEFT OUTER JOIN � RIGHT OUTER JOIN ���������� ���� ������)
SELECT ������.��������, ������.����_������, ������.��
	FROM ������ LEFT JOIN ������
	ON ������.�� = ������.�����
UNION 
SELECT ������.��������, ������.����_������, ������.��
	FROM ������ RIGHT JOIN ������
	ON ������.�� = ������.�����;

--8.3 (���������� FULL OUTER JOIN �������� ���������� INNER JOIN ���� ������)
SELECT ������.��������, ������.����_������, ������.��
	FROM ������ INNER JOIN ������
	ON ������.�� = ������.�����;

--8.4 (������, ��������� �������� �������� ������ ����� (� �������� FULL OUTER JOIN) ������� � �� �������� ������ ������)
--�������� ��� �������� ������� ����� (LEFT JOIN ������)
SELECT ������.�� as ��_������,
	������.�������� as ��������_������,
	������.�� as ��_������
	FROM ������ FULL JOIN ������
	ON ������.�� = ������.�����
	WHERE ������.�� IS NOT NULL;

--�������� ��� �������� ������� �����, ����� ���, ��� ������������� ��������� �� ������� ������ (LEFT JOIN � ����������� INNER JOIN'�)
SELECT ������.�� as ��_������,
	������.�������� as ��������_������,
	������.�� as ��_������
	FROM ������ FULL JOIN ������
	ON ������.�� = ������.�����
	WHERE ������.�� IS NOT NULL AND ������.����� IS NULL;

--8.5 (������, ��������� �������� �������� ������ ������ ������� � �� ���������� ������ �����)
--�������� ��� �������� ������� ������ (RIGHT JOIN ������)
SELECT ������.�� as ��_������,
	������.�������� as ��������_������,
	������.�� as ��_������
	FROM ������ FULL JOIN ������
	ON ������.�� = ������.�����
	WHERE ������.�� IS NOT NULL;

--�������� ��� �������� ������� ������, ����� ���, ��� ������������� ��������� �� ������� ����� (RIGHT JOIN � ����������� INNER JOIN'�)
SELECT ������.�� as ��_������,
	������.�������� as ��������_������,
	������.�� as ��_������
	FROM ������ FULL JOIN ������
	ON ������.�� = ������.�����
	WHERE ������.�� IS NOT NULL AND ������.�� IS NULL;

--8.6 (������, ��������� �������� �������� ������ ������ ������� � ����� ������)
SELECT ������.�� AS [�� ������],
	������.����_������ AS [���� ������],
	������.����� [�� ������ �� ������],
	������.�� AS [�� ������],
	������.�������� AS [�������� ������]
	FROM ������ FULL JOIN ������
	ON ������.�� = ������.�����;

--9
SELECT AUDITORIUM.AUDITORIUM, AUDITORIUM_TYPE.AUDITORIUM_TYPENAME
	FROM AUDITORIUM CROSS JOIN AUDITORIUM_TYPE
	WHERE AUDITORIUM.AUDITORIUM_TYPE = AUDITORIUM_TYPE.AUDITORIUM_TYPE;

