use UNIVERSITY;

--------------------------------------------- 1
select * from TEACHER
where PULPIT = '����'
for xml path('teacher'), root('teachers');



--------------------------------------------- 2
select	AUDITORIUM_NAME as [auditorium_name],
		rtrim(aud_type.AUDITORIUM_TYPE) as [type],
		AUDITORIUM_CAPACITY as [capacity]
from AUDITORIUM auditorium inner join AUDITORIUM_TYPE aud_type
on auditorium.AUDITORIUM_TYPE = aud_type.AUDITORIUM_TYPE
where aud_type.AUDITORIUM_TYPE in ('��-�', '��')
for xml auto, 
	root ('AUDITORIUM'), 
	elements



--------------------------------------------- 3
go
declare @handler int = 0, -- ���������� ���������� xml-���������
		@xmlText varchar(2000) = '<?xml version="1.0" encoding="windows-1251"?>
		<��������>
			<������� ���_��������="��" ������������="������������" �������="��"/>
			<������� ���_��������="�" ������������="����������" �������="����"/>
			<������� ���_��������="��" ������������="����������" �������="��"/>
		</��������>';

-- �������� xml-��������� �� ������ � ������� ����������� ��� ������� � ���������
exec sp_xml_preparedocument @handler output, @xmlText; 

-- ��� �������������� XML-������ � ������ ������� ������������� ������� OPENXML
select * from openxml(@handler, '/��������/�������', 0)
with ([���_��������] char(10), [������������] varchar(100), [�������] char(20));

-- ��������� ������ � ������� SUBJECT
insert into SUBJECT 
select * from openxml(@handler, '/��������/�������', 0)
with ([���_��������] char(10), [������������] varchar(100), [�������] char(20));



--------------------------------------------- 4
-- ���������� ������
declare @passportInfo_1 varchar(2000) = 
	'<passport_details>
		<�����>MP</�����>
		<�����>1234112</�����>
		<����_������>03.05.2022</����_������>
		<�����_��������>
			<������>��������</������>
			<�����>���������</�����>
			<�����>���������</�����>
			<���>65</���>
		</�����_��������>
	</passport_details>';

declare @passportInfo_2 varchar(2000) = 
	'<passport_details>
		<�����>MP</�����>
		<�����>048765</�����>
		<����_������>04.05.2022</����_������>
		<�����_��������>
			<������>������</������>
			<�����>�������</�����>
			<�����>�������������</�����>
			<���>124</���>
		</�����_��������>
	</passport_details>';

declare @passportInfo_3 varchar(2000) = 
	'<passport_details>
		<�����>MP</�����>
		<�����>09876543</�����>
		<����_������>05.05.2022</����_������>
		<�����_��������>
			<������>������</������>
			<�����>�������</�����>
			<�����>������</�����>
			<���>37</���>
		</�����_��������>
	</passport_details>';

-- ��� ����������
declare @passportInfo_3_update varchar(2000) = 
	'<passport_details>
		<�����>MP</�����>
		<�����>09876543</�����>
		<����_������>05.05.2022</����_������>
		<�����_��������>
			<������>������</������>
			<�����>�������</�����>
			<�����>������������</�����>
			<���>19</���>
		</�����_��������>
	</passport_details>';

-- ������� ����� � ������� STUDENT
insert into STUDENT (IDGROUP, NAME, BDAY, INFO)
	values	(3, '�������_1', getdate(), @passportInfo_1),
			(3, '�������_2', getdate(), @passportInfo_2),
			(3, '�������_3', getdate(), @passportInfo_3);

-- ����������
update STUDENT 
	set INFO = @passportInfo_3_update
where NAME = '�������_3';

-- ����� ����������� �����
select	NAME as [���],
		INFO.value('(/passport_details/�����)[1]', 'varchar(5)') as [����� ��������],
		INFO.value('(/passport_details/�����)[1]', 'varchar(15)') as [�����],
		INFO.query('(/passport_details/�����_��������)') as [�����_��������]
from STUDENT
where INFO is not null;



--------------------------------------------- 5
-- ������� ����� � ��������� � �� UNIVERSITY
use UNIVERSITY
go
create xml schema collection Student as 
N'<?xml version="1.0" encoding="utf-16" ?>
<xs:schema attributeFormDefault="unqualified" 
           elementFormDefault="qualified"
           xmlns:xs="http://www.w3.org/2001/XMLSchema">
    <xs:element name="�������">  
		<xs:complexType><xs:sequence>
			<xs:element name="�������" maxOccurs="1" minOccurs="1">
				<xs:complexType>
					<xs:attribute name="�����" type="xs:string" use="required" />
					<xs:attribute name="�����" type="xs:unsignedInt" use="required"/>
					<xs:attribute name="����"  use="required" >  
						<xs:simpleType>  
							<xs:restriction base ="xs:string">
								<xs:pattern value="[0-9]{2}.[0-9]{2}.[0-9]{4}"/>
							</xs:restriction> 	
						</xs:simpleType>
					</xs:attribute> 
			   </xs:complexType> 
		   </xs:element>
		   <xs:element maxOccurs="3" name="�������" type="xs:unsignedInt"/>
		   <xs:element name="�����">   
			   <xs:complexType>
				   <xs:sequence>
					   <xs:element name="������" type="xs:string" />
					   <xs:element name="�����" type="xs:string" />
					   <xs:element name="�����" type="xs:string" />
					   <xs:element name="���" type="xs:string" />
					   <xs:element name="��������" type="xs:string" />
				   </xs:sequence>
			   </xs:complexType>  
		   </xs:element>
	   </xs:sequence></xs:complexType>
   </xs:element>
</xs:schema>';

-- ������� �� ������� INFO ��������, ��� ����� �� ����� ���������� ��� ���� �������� ����� (������),
-- � ������� ������ � ���� ������� �� ������������� ���� �����, ��-�� ���� �������� ������
update STUDENT 
	set INFO = NULL;

-- ������ INFO �������������� �������� XML-����
alter table STUDENT 
alter column INFO xml(Student);

-- ������������ xml-������
go
declare @passportInfo varchar(2000) = 
	'<passport_details>
		<�����>MP</�����>
		<�����>09876543</�����>
		<����_������>05.05.2022</����_������>
		<�����_��������>
			<������>������</������>
			<�����>�������</�����>
			<�����>������</�����>
			<���>28</���>
		</�����_��������>
	</passport_details>';

insert into STUDENT (IDGROUP, NAME, BDAY, INFO)
	values	(3, '�������', getdate(), @passportInfo);

-- ����������
go
declare @passportInfo varchar(2000) = 
	'<�������>
		<������� �����="MP" �����="09876543" ����="05.05.2022"/>
		<�������>290231036</�������>
		<�����>
			<������>������</������>
			<�����>�������</�����>
			<�����>������</�����>
			<���>28</���>
			<��������>6</��������>
		</�����>
	</�������>';

insert into STUDENT (IDGROUP, NAME, BDAY, INFO)
	values	(3, '�������', getdate(), @passportInfo);

-- ������� ����� �� ����������� ���� �������
alter table STUDENT 
alter column INFO xml;

-- ������� �����
drop XML SCHEMA COLLECTION Student;	

--------------------------> �������� ����� ����� <--------------------------
use UNIVERSITY
go
create xml schema collection MySchema as 
N'<?xml version="1.0" encoding="utf-16" ?>
<xs:schema attributeFormDefault="unqualified" 
           elementFormDefault="qualified"
           xmlns:xs="http://www.w3.org/2001/XMLSchema">
    <xs:element name="���������_������">  
		<xs:complexType>
			<xs:sequence>
			   <xs:element maxOccurs="1" minOccurs="1" name="�����" type="xs:string"/>
			   <xs:element maxOccurs="1" minOccurs="1" name="�����" type="xs:string"/>
			   <xs:element maxOccurs="1" minOccurs="1" name="����_������">
					<xs:simpleType>
						<xs:restriction base="xs:string">
							<xs:pattern value="[0-9]{2}.[0-9]{2}.[0-9]{4}"/>
						</xs:restriction>
					</xs:simpleType>
			   </xs:element>
			   <xs:element name="�����_��������">   
				   <xs:complexType>
					   <xs:sequence>
						   <xs:element name="������" type="xs:string" />
						   <xs:element name="�����" type="xs:string" />
						   <xs:element name="�����" type="xs:string" />
						   <xs:element name="���" type="xs:string" />
						   <xs:element name="��������" type="xs:string" />
					   </xs:sequence>
				   </xs:complexType>  
			   </xs:element>
		   </xs:sequence>
	   </xs:complexType>
   </xs:element>
</xs:schema>';

update STUDENT 
	set INFO = NULL;

alter table STUDENT 
alter column INFO xml(mySchema);

-- ������� ������
go
declare @passportInfo varchar(2000) = 
	'<���������_������>
		<�����>MP</�����>
		<�����>09876543</�����>
		<����_������>05.05.2022</����_������>
		<�����_��������>
			<������>������</������>
			<�����>�������</�����>
			<�����>������</�����>
			<���>28</���>
			<��������>6</��������>
		</�����_��������>
	</���������_������>';

insert into STUDENT (IDGROUP, NAME, BDAY, INFO)
	values	(3, '�������', getdate(), @passportInfo);

-- ������� ����� �� ����������� ���� �������
alter table STUDENT 
alter column INFO xml;

-- ������� �����
drop XML SCHEMA COLLECTION mySchema;	
