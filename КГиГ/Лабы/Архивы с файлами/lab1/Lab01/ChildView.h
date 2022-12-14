
// ChildView.h: интерфейс класса CChildView
//


#pragma once


// Окно CChildView

class CChildView : public CWnd
{
// Создание
public:
	CChildView();

	vector<CMatrix> arr;				// создаем вектор
	ControllerCMatrix controller;		// и контроллер (класс для операций с матрицами)
// Атрибуты
public:

// Операции
public:

// Переопределение
	protected:
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);

// Реализация
public:
	virtual ~CChildView();

	// Созданные функции схемы сообщений
protected:
	afx_msg void OnPaint();
	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnTestMatrix();			// тестирование матриц
	afx_msg void OnTestFunctions();			// функций 
	afx_msg void OnTestHello();
};

