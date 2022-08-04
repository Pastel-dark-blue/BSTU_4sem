use UNIVERSITY;

--------------------------------------------- 1
select * from TEACHER
where PULPIT = 'исит'
for xml path('teacher'), root('teachers');



--------------------------------------------- 2
select	AUDITORIUM_NAME as [auditorium_name],
		rtrim(aud_type.AUDITORIUM_TYPE) as [type],
		AUDITORIUM_CAPACITY as [capacity]
from AUDITORIUM auditorium inner join AUDITORIUM_TYPE aud_type
on auditorium.AUDITORIUM_TYPE = aud_type.AUDITORIUM_TYPE
where aud_type.AUDITORIUM_TYPE in ('ЛК-К', 'ЛК')
for xml auto, 
	root ('AUDITORIUM'), 
	elements



--------------------------------------------- 3
go
declare @handler int = 0, -- дескриптор созданныго xml-документа
		@xmlText varchar(2000) = '<?xml version="1.0" encoding="windows-1251"?>
		<предметы>
			<предмет код_предмета="Зе" наименование="Зельеварение" кафедра="ох"/>
			<предмет код_предмета="А" наименование="Астрономия" кафедра="исит"/>
			<предмет код_предмета="За" наименование="Заклинания" кафедра="ох"/>
		</предметы>';

-- создание xml-документа из текста и возврат дескриптора для доступа к документу
exec sp_xml_preparedocument @handler output, @xmlText; 

-- Для преобразования XML-данных в строки таблицы предназначена функция OPENXML
select * from openxml(@handler, '/предметы/предмет', 0)
with ([код_предмета] char(10), [наименование] varchar(100), [кафедра] char(20));

-- добавляем данные в таблицу SUBJECT
insert into SUBJECT 
select * from openxml(@handler, '/предметы/предмет', 0)
with ([код_предмета] char(10), [наименование] varchar(100), [кафедра] char(20));



--------------------------------------------- 4
-- паспортные данные
declare @passportInfo_1 varchar(2000) = 
	'<passport_details>
		<серия>MP</серия>
		<номер>1234112</номер>
		<дата_выдачи>03.05.2022</дата_выдачи>
		<адрес_прописки>
			<страна>Беларусь</страна>
			<город>Волковыск</город>
			<улица>Восточная</улица>
			<дом>65</дом>
		</адрес_прописки>
	</passport_details>';

declare @passportInfo_2 varchar(2000) = 
	'<passport_details>
		<серия>MP</серия>
		<номер>048765</номер>
		<дата_выдачи>04.05.2022</дата_выдачи>
		<адрес_прописки>
			<страна>Россия</страна>
			<город>Иркутск</город>
			<улица>Красноказачья</улица>
			<дом>124</дом>
		</адрес_прописки>
	</passport_details>';

declare @passportInfo_3 varchar(2000) = 
	'<passport_details>
		<серия>MP</серия>
		<номер>09876543</номер>
		<дата_выдачи>05.05.2022</дата_выдачи>
		<адрес_прописки>
			<страна>Россия</страна>
			<город>Воркута</город>
			<улица>Ленина</улица>
			<дом>37</дом>
		</адрес_прописки>
	</passport_details>';

-- для обновления
declare @passportInfo_3_update varchar(2000) = 
	'<passport_details>
		<серия>MP</серия>
		<номер>09876543</номер>
		<дата_выдачи>05.05.2022</дата_выдачи>
		<адрес_прописки>
			<страна>Россия</страна>
			<город>Воркута</город>
			<улица>Транспортная</улица>
			<дом>19</дом>
		</адрес_прописки>
	</passport_details>';

-- вставка строк в таблицу STUDENT
insert into STUDENT (IDGROUP, NAME, BDAY, INFO)
	values	(3, 'студент_1', getdate(), @passportInfo_1),
			(3, 'студент_2', getdate(), @passportInfo_2),
			(3, 'студент_3', getdate(), @passportInfo_3);

-- Обновление
update STUDENT 
	set INFO = @passportInfo_3_update
where NAME = 'студент_3';

-- вывод добавленных строк
select	NAME as [ФИО],
		INFO.value('(/passport_details/серия)[1]', 'varchar(5)') as [серия паспорта],
		INFO.value('(/passport_details/номер)[1]', 'varchar(15)') as [номер],
		INFO.query('(/passport_details/адрес_прописки)') as [адрес_прописки]
from STUDENT
where INFO is not null;



--------------------------------------------- 5
-- создаем схему и добавляем в БД UNIVERSITY
use UNIVERSITY
go
create xml schema collection Student as 
N'<?xml version="1.0" encoding="utf-16" ?>
<xs:schema attributeFormDefault="unqualified" 
           elementFormDefault="qualified"
           xmlns:xs="http://www.w3.org/2001/XMLSchema">
    <xs:element name="студент">  
		<xs:complexType><xs:sequence>
			<xs:element name="паспорт" maxOccurs="1" minOccurs="1">
				<xs:complexType>
					<xs:attribute name="серия" type="xs:string" use="required" />
					<xs:attribute name="номер" type="xs:unsignedInt" use="required"/>
					<xs:attribute name="дата"  use="required" >  
						<xs:simpleType>  
							<xs:restriction base ="xs:string">
								<xs:pattern value="[0-9]{2}.[0-9]{2}.[0-9]{4}"/>
							</xs:restriction> 	
						</xs:simpleType>
					</xs:attribute> 
			   </xs:complexType> 
		   </xs:element>
		   <xs:element maxOccurs="3" name="телефон" type="xs:unsignedInt"/>
		   <xs:element name="адрес">   
			   <xs:complexType>
				   <xs:sequence>
					   <xs:element name="страна" type="xs:string" />
					   <xs:element name="город" type="xs:string" />
					   <xs:element name="улица" type="xs:string" />
					   <xs:element name="дом" type="xs:string" />
					   <xs:element name="квартира" type="xs:string" />
				   </xs:sequence>
			   </xs:complexType>  
		   </xs:element>
	   </xs:sequence></xs:complexType>
   </xs:element>
</xs:schema>';

-- удаляем из столбца INFO значения, ибо далее мы зотим установить для этих значений схему (шаблон),
-- а текущие данные с этом столбце не соответствуют этой схеме, из-за чего появится ошибка
update STUDENT 
	set INFO = NULL;

-- делаем INFO типизированным столбцом XML-типа
alter table STUDENT 
alter column INFO xml(Student);

-- некорректные xml-данные
go
declare @passportInfo varchar(2000) = 
	'<passport_details>
		<серия>MP</серия>
		<номер>09876543</номер>
		<дата_выдачи>05.05.2022</дата_выдачи>
		<адрес_прописки>
			<страна>Россия</страна>
			<город>Воркута</город>
			<улица>Ленина</улица>
			<дом>28</дом>
		</адрес_прописки>
	</passport_details>';

insert into STUDENT (IDGROUP, NAME, BDAY, INFO)
	values	(3, 'студент', getdate(), @passportInfo);

-- корректные
go
declare @passportInfo varchar(2000) = 
	'<студент>
		<паспорт серия="MP" номер="09876543" дата="05.05.2022"/>
		<телефон>290231036</телефон>
		<адрес>
			<страна>Россия</страна>
			<город>Воркута</город>
			<улица>Ленина</улица>
			<дом>28</дом>
			<квартира>6</квартира>
		</адрес>
	</студент>';

insert into STUDENT (IDGROUP, NAME, BDAY, INFO)
	values	(3, 'студент', getdate(), @passportInfo);

-- убираем схему из определения типа столбца
alter table STUDENT 
alter column INFO xml;

-- удаляем схему
drop XML SCHEMA COLLECTION Student;	

--------------------------> создание своей схемы <--------------------------
use UNIVERSITY
go
create xml schema collection MySchema as 
N'<?xml version="1.0" encoding="utf-16" ?>
<xs:schema attributeFormDefault="unqualified" 
           elementFormDefault="qualified"
           xmlns:xs="http://www.w3.org/2001/XMLSchema">
    <xs:element name="паспорные_данные">  
		<xs:complexType>
			<xs:sequence>
			   <xs:element maxOccurs="1" minOccurs="1" name="серия" type="xs:string"/>
			   <xs:element maxOccurs="1" minOccurs="1" name="номер" type="xs:string"/>
			   <xs:element maxOccurs="1" minOccurs="1" name="дата_выдачи">
					<xs:simpleType>
						<xs:restriction base="xs:string">
							<xs:pattern value="[0-9]{2}.[0-9]{2}.[0-9]{4}"/>
						</xs:restriction>
					</xs:simpleType>
			   </xs:element>
			   <xs:element name="адрес_прописки">   
				   <xs:complexType>
					   <xs:sequence>
						   <xs:element name="страна" type="xs:string" />
						   <xs:element name="город" type="xs:string" />
						   <xs:element name="улица" type="xs:string" />
						   <xs:element name="дом" type="xs:string" />
						   <xs:element name="квартира" type="xs:string" />
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

-- вставка строки
go
declare @passportInfo varchar(2000) = 
	'<паспорные_данные>
		<серия>MP</серия>
		<номер>09876543</номер>
		<дата_выдачи>05.05.2022</дата_выдачи>
		<адрес_прописки>
			<страна>Россия</страна>
			<город>Воркута</город>
			<улица>Ленина</улица>
			<дом>28</дом>
			<квартира>6</квартира>
		</адрес_прописки>
	</паспорные_данные>';

insert into STUDENT (IDGROUP, NAME, BDAY, INFO)
	values	(3, 'студент', getdate(), @passportInfo);

-- убираем схему из определения типа столбца
alter table STUDENT 
alter column INFO xml;

-- удаляем схему
drop XML SCHEMA COLLECTION mySchema;	
