USE [Курносенко ПРОДАЖИ]
GO
/****** Object:  Table [dbo].[ЗАКАЗЧИКИ]    Script Date: 13.02.2022 15:18:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ЗАКАЗЧИКИ](
	[Наименование_фирмы] [nvarchar](20) NOT NULL,
	[Адрес] [nvarchar](50) NULL,
	[Расчетный_счет] [nvarchar](15) NULL,
 CONSTRAINT [PK_ЗАКАЗЧИКИ] PRIMARY KEY CLUSTERED 
(
	[Наименование_фирмы] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ЗАКАЗЫ]    Script Date: 13.02.2022 15:18:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ЗАКАЗЫ](
	[Номер_заказа] [nvarchar](10) NOT NULL,
	[Наименование_товара] [nvarchar](20) NULL,
	[Цена_продажи] [real] NULL,
	[Количество] [int] NULL,
	[Дата_поставки] [date] NULL,
	[Заказчик] [nvarchar](20) NULL,
 CONSTRAINT [PK_ЗАКАЗЫ_1] PRIMARY KEY CLUSTERED 
(
	[Номер_заказа] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ТОВАРЫ]    Script Date: 13.02.2022 15:18:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ТОВАРЫ](
	[Наименование] [nvarchar](20) NOT NULL,
	[Цена] [real] NULL,
	[Количество] [int] NULL,
 CONSTRAINT [PK_ТОВАРЫ] PRIMARY KEY CLUSTERED 
(
	[Наименование] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ЗАКАЗЧИКИ] ([Наименование_фирмы], [Адрес], [Расчетный_счет]) VALUES (N'Аркейн', N'г. Заун, ул. Сестёр 2 дом 100', N'110293839')
INSERT [dbo].[ЗАКАЗЧИКИ] ([Наименование_фирмы], [Адрес], [Расчетный_счет]) VALUES (N'Ветролом', N'г. ???, ул. Велосипедистов 6 дом 6', N'323553532')
INSERT [dbo].[ЗАКАЗЧИКИ] ([Наименование_фирмы], [Адрес], [Расчетный_счет]) VALUES (N'Гинтама', N'г. ???, ул. Ёродзуя 25 дом 16', N'492944921')
INSERT [dbo].[ЗАКАЗЧИКИ] ([Наименование_фирмы], [Адрес], [Расчетный_счет]) VALUES (N'Джоджо', N'г. Минск, ул. Джостаров 19 дом 3', N'292829444')
INSERT [dbo].[ЗАКАЗЧИКИ] ([Наименование_фирмы], [Адрес], [Расчетный_счет]) VALUES (N'Магическая битва', N'г. Токио, ул. Проклятий 7 дом 1', N'977937379')
INSERT [dbo].[ЗАКАЗЧИКИ] ([Наименование_фирмы], [Адрес], [Расчетный_счет]) VALUES (N'Салли-кромсали', N'г. Нокфелл, Апартаменты Эддисона', N'178913238')
INSERT [dbo].[ЗАКАЗЧИКИ] ([Наименование_фирмы], [Адрес], [Расчетный_счет]) VALUES (N'Стальной алхимик', N'деревня Ризембург, ул. Алхимии 25 дом 16', N'091329091')
INSERT [dbo].[ЗАКАЗЧИКИ] ([Наименование_фирмы], [Адрес], [Расчетный_счет]) VALUES (N'Хантер×Хантер', N'г. ???, ул. Хантеров 2 дом 15', N'609464600')
INSERT [dbo].[ЗАКАЗЧИКИ] ([Наименование_фирмы], [Адрес], [Расчетный_счет]) VALUES (N'Человек-бензопила', N'г. Токио, ул. Дьяволов 47 дом 17', N'109328748')
GO
INSERT [dbo].[ЗАКАЗЫ] ([Номер_заказа], [Наименование_товара], [Цена_продажи], [Количество], [Дата_поставки], [Заказчик]) VALUES (N'1', N'Деревянный меч', 40, 2, CAST(N'2022-02-12' AS Date), N'Гинтама')
INSERT [dbo].[ЗАКАЗЫ] ([Номер_заказа], [Наименование_товара], [Цена_продажи], [Количество], [Дата_поставки], [Заказчик]) VALUES (N'2', N'Горный велосипед', 200, 6, CAST(N'2021-07-23' AS Date), N'Ветролом')
INSERT [dbo].[ЗАКАЗЫ] ([Номер_заказа], [Наименование_товара], [Цена_продажи], [Количество], [Дата_поставки], [Заказчик]) VALUES (N'3', N'Бензопила', 110, 5, CAST(N'2019-10-16' AS Date), N'Человек-бензопила')
INSERT [dbo].[ЗАКАЗЫ] ([Номер_заказа], [Наименование_товара], [Цена_продажи], [Количество], [Дата_поставки], [Заказчик]) VALUES (N'4', N'Протез лица', 3890, 1, CAST(N'2013-09-09' AS Date), N'Салли-кромсали')
INSERT [dbo].[ЗАКАЗЫ] ([Номер_заказа], [Наименование_товара], [Цена_продажи], [Количество], [Дата_поставки], [Заказчик]) VALUES (N'5', N'Гитара', 67, 1, CAST(N'2015-08-02' AS Date), N'Салли-кромсали')
INSERT [dbo].[ЗАКАЗЫ] ([Номер_заказа], [Наименование_товара], [Цена_продажи], [Количество], [Дата_поставки], [Заказчик]) VALUES (N'6', N'Кинжал', 60, 1, CAST(N'2018-03-04' AS Date), N'Магическая битва')
GO
INSERT [dbo].[ТОВАРЫ] ([Наименование], [Цена], [Количество]) VALUES (N'Бензопила', 110, 63)
INSERT [dbo].[ТОВАРЫ] ([Наименование], [Цена], [Количество]) VALUES (N'Гитара', 67, 210)
INSERT [dbo].[ТОВАРЫ] ([Наименование], [Цена], [Количество]) VALUES (N'Горный велосипед', 200, 101)
INSERT [dbo].[ТОВАРЫ] ([Наименование], [Цена], [Количество]) VALUES (N'Деревянный меч', 40, 15)
INSERT [dbo].[ТОВАРЫ] ([Наименование], [Цена], [Количество]) VALUES (N'Доспехи', 5700, 1)
INSERT [dbo].[ТОВАРЫ] ([Наименование], [Цена], [Количество]) VALUES (N'Кинжал', 60, 2)
INSERT [dbo].[ТОВАРЫ] ([Наименование], [Цена], [Количество]) VALUES (N'Протез лица', 3890, 1)
INSERT [dbo].[ТОВАРЫ] ([Наименование], [Цена], [Количество]) VALUES (N'Протез руки', 1900, 2)
GO
ALTER TABLE [dbo].[ЗАКАЗЫ]  WITH CHECK ADD  CONSTRAINT [FK_ЗАКАЗЫ_ЗАКАЗЧИКИ] FOREIGN KEY([Заказчик])
REFERENCES [dbo].[ЗАКАЗЧИКИ] ([Наименование_фирмы])
GO
ALTER TABLE [dbo].[ЗАКАЗЫ] CHECK CONSTRAINT [FK_ЗАКАЗЫ_ЗАКАЗЧИКИ]
GO
ALTER TABLE [dbo].[ЗАКАЗЫ]  WITH CHECK ADD  CONSTRAINT [FK_ЗАКАЗЫ_ТОВАРЫ] FOREIGN KEY([Наименование_товара])
REFERENCES [dbo].[ТОВАРЫ] ([Наименование])
GO
ALTER TABLE [dbo].[ЗАКАЗЫ] CHECK CONSTRAINT [FK_ЗАКАЗЫ_ТОВАРЫ]
GO
