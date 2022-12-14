
// ChildView.cpp: реализация класса CChildView
//

#include "stdafx.h"
#include "Lab04.h"
#include "ChildView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CChildView

CChildView::CChildView()
{		
	IsData = 0;
}

CChildView::~CChildView()
{
}

// Реализация карты сообщений
BEGIN_MESSAGE_MAP(CChildView, CWnd)
	ON_WM_PAINT()
	// сообщения меню выбора
	ON_COMMAND(ID_LAB_PLANETS, &CChildView::OnLabplanetsPlanets)
	ON_WM_TIMER()
	ON_WM_LBUTTONDBLCLK()
	ON_WM_RBUTTONDBLCLK()
END_MESSAGE_MAP()



// Обработчики сообщений CChildView

BOOL CChildView::PreCreateWindow(CREATESTRUCT& cs) 
{
	if (!CWnd::PreCreateWindow(cs))
		return FALSE;

	cs.dwExStyle |= WS_EX_CLIENTEDGE;
	cs.style &= ~WS_BORDER;
	cs.lpszClass = AfxRegisterWndClass(CS_HREDRAW|CS_VREDRAW|CS_DBLCLKS, 
		::LoadCursor(nullptr, IDC_ARROW), reinterpret_cast<HBRUSH>(COLOR_WINDOW+1), nullptr);

	return TRUE;
}

void CChildView::OnPaint()
{
	CPaintDC dc(this); // контекст устройства для рисования

	if (IsData == 1)
	{
		SunSystem.GetRS(RS);
		RW = SunSystem.GetRW();
		SetMyMode(dc, RS, RW);			// Устанавливает режим отображения MM_ANISOTROPIC
		SunSystem.Draw(dc);
		dc.SetMapMode(MM_TEXT);			// Устанавливает режим отображения MM_TEXT

	}
}

	void CChildView::OnLabplanetsPlanets()	// PLANETS
	{
		SunSystem.SetDT(0);				// Для начального состояния
		SunSystem.SetNewCoords();
		SunSystem.SetDT(0.1);			//Обновление координат через 0.1 сек.
		dT_Timer = 40;					// Миллисекунд
		IsData = 1;
		Invalidate();

	}

	void CChildView::OnTimer(UINT_PTR nIDEvent)
	{
		SunSystem.SetNewCoords();
		Invalidate();
		CWnd::OnTimer(nIDEvent);

	}

	void CChildView::OnLButtonDblClk(UINT nFlags, CPoint point)
	{
		SetTimer(1, dT_Timer, NULL);
		CWnd::OnLButtonDblClk(nFlags, point);
	}

	void CChildView::OnRButtonDblClk(UINT nFlags, CPoint point)
	{
		KillTimer(1);
		CWnd::OnRButtonDblClk(nFlags, point);
	}
