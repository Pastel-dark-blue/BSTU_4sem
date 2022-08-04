#include "stdafx.h"

CRectD::CRectD(double l, double t, double r, double b)
{
	left = l;
	top = t;
	right = r;
	bottom = b;
}
//------------------------------------------------------------------------------
void CRectD::SetRectD(double l, double t, double r, double b)
{
	left = l;
	top = t;
	right = r;
	bottom = b;
}

//------------------------------------------------------------------------------
CSizeD CRectD::SizeD()
{
	CSizeD cz;
	cz.cx = fabs(right - left);	// ������ ������������� �������
	cz.cy = fabs(top - bottom);	// ������ ������������� �������
	return cz;
}

//----------------------------------------------------------------------------

CMatrix CreateTranslate2D(double dx, double dy)
// ��������� ������� ��� �������������� ��������� ������� ��� ��� �������� 
// �� dx �� ��� X � �� dy �� ��� Y � ������������� ������� ���������
// --- ��� ---
// ��������� ������� ��� �������������� ��������� ������� ��� �������� ������
// ������� ��������� �� -dx ��� X � �� -dy �� ��� Y ��� ������������� ��������� ������� 
{
	CMatrix TM(3, 3);
	TM(0, 0) = 1; TM(0, 2) = dx;
	TM(1, 1) = 1;  TM(1, 2) = dy;
	TM(2, 2) = 1;
	return TM;
}

//------------------------------------------------------------------------------------
CMatrix CreateRotate2D(double fi)
// ��������� ������� ��� �������������� ��������� ������� ��� ��� ��������
// �� ���� fi (��� fi>0 ������ ������� �������)� ������������� ������� ���������
// --- ��� ---
// ��������� ������� ��� �������������� ��������� ������� ��� �������� ������
// ������� ��������� �� ���� -fi ��� ������������� ��������� ������� 
// fi - ���� � ��������
{
	//	������� fmod() ���������� ������� �� ������� ������� �������� �� ������
	double fg = fmod(fi, 360.0);
	double ff = (fg / 180.0)*pi; // ������� � �������
	CMatrix RM(3, 3);
	RM(0, 0) = cos(ff); RM(0, 1) = -sin(ff);
	RM(1, 0) = sin(ff);  RM(1, 1) = cos(ff);
	RM(2, 2) = 1;
	return RM;
}


//------------------------------------------------------------------------------

CMatrix SpaceToWindow(CRectD& RS, CRect& RW)
// ���������� ������� ��������� ��������� �� ������� � �������
// RS - ������� � ������� ����������� - double
// RW - ������� � ������� ����������� - int
{
	CMatrix M(3, 3);
	CSize sz = RW.Size();	 // ������ ������� � ����
	int dwx = sz.cx;	     // ������
	int dwy = sz.cy;	     // ������
	CSizeD szd = RS.SizeD(); // ������ ������� � ������� �����������

	double dsx = szd.cx;    // ������ � ������� �����������
	double dsy = szd.cy;    // ������ � ������� �����������

	double kx = (double)dwx / dsx;   // ������� �� x
	double ky = (double)dwy / dsy;   // ������� �� y

	M(0, 0) = kx;  M(0, 1) = 0;    M(0, 2) = (double)RW.left - kx * RS.left;				
	M(1, 0) = 0;   M(1, 1) = -ky;  M(1, 2) = (double)RW.bottom + ky * RS.bottom;		
	M(2, 0) = 0;   M(2, 1) = 0;    M(2, 2) = 1;
	return M;
}

//------------------------------------------------------------------------------

void SetMyMode(CDC& dc, CRectD& RS, CRect& RW) 
// ������������� ����� ����������� MM_ANISOTROPIC � ��� ���������
// dc - ������ �� ����� CDC MFC
// RS -  ������� � ������� ����������� - int
// RW -	 ������� � ������� ����������� - int  
{
	double dsx = RS.right - RS.left;
	double dsy = RS.top - RS.bottom;
	double xsL = RS.left;
	double ysL = RS.bottom;

	int dwx = RW.right - RW.left;
	int dwy = RW.bottom - RW.top;
	int xwL = RW.left;
	int ywH = RW.bottom;

	//������������ ����� MM_ANISOTROPIC ������������ ������������� ������ ��������� ���
	//������ ����(���� ����� ������������ � ���������� ��������).��� ��������� ���������� � �������� ���� ����� ��������������� 
	//��������� SetViewportExt � SetWindowExt, ������� �������� �������� ������ CDC �� ���������� MFC :
	//virtual CSize SetWindowExt(int cx, int cy),
	//virtual CSize SetViewportExt(int cx, int cy).
	//������� SetWindowExt ������������� ��� ������� �������������� ��������� �������� ���������� xWinExt � yWinExt .
	//������� SetViewportExt ������������� ��� ������� �������������� ��������� �������� ���������� xViewExt � yViewExt.�������
	//SetViewportExt ������ �������������� ����� ������� SetWindowExt.

	//��� ��������� �������� ����� ������������ ������� SetViewportOrg � SetWindowOrg, ������� �������� �������� ������ CDC �� ���������� MFC :
	//virtual CPoint SetViewportOrg(intx, int y)
	//virtual CPoint SetWindowOrg(int x, int y)
	//��� ��������� x� y������������ ����� ����� �������� ��������������� ����������.
	dc.SetMapMode(MM_ANISOTROPIC);
	dc.SetWindowExt((int)dsx, (int)dsy);
	dc.SetViewportExt(dwx, -dwy);
	dc.SetWindowOrg((int)xsL, (int)ysL);
	dc.SetViewportOrg(xwL, ywH);
}

/////////////////////// CLASS CSunSystem //////////////////////////////////

CSunSystem::CSunSystem()            //  ����������� �� ���������
{
	double rS = 30, rE = 20, rM = 10, rMars = 15;       // ������ ������, �����, ����, �����
	double RoE = 10 * rS, RoM = 5 * rE, RoMars = 6 * rS;	 // ������ ������ �����, ����, �����
	double d = RoE + RoM + RoMars;		    // �������� �������� �������
	RS.SetRectD(-d, d, d, -d);					// ������� ������� � ������� �����������
	RW.SetRect(0, 0, 650, 650);					// ������� � ����
	Sun.SetRect(-rS, rS, rS, -rS);				// ������������� ������ - ��� ��������� �����
	Earth.SetRect(-rE, rE, rE, -rE);			// ������������� ����� - ��� ��������� �����
	Moon.SetRect(-rM, rM, rM, -rM);				// ������������� ���� - ��� ��������� �����
	Mars.SetRect(-rMars, rMars, rMars, -rMars);
	EarthOrbit.SetRect(-RoE, RoE, RoE, -RoE);	// ������������� ������ ����� - ��� ��������� �����
	MoonOrbit.SetRect(-RoM, RoM, RoM, -RoM);	// ������������� ������ ���� - ��� ��������� �����
	MarsOrbit.SetRect(-RoMars, RoMars, RoMars, -RoMars);
	fiE = 0;			// ������� ��������� ����� � ������� ��������� ������, ����
	fiM = 0;			// ������� ��������� ���� � ������� ��������� �����, ����
	fiMars = 1;
	wEarth = 5;			// ������� �������� ����� � ������� ��������� ������, ����/���.
	wMoon = 50;			// ������� �������� ���� � ������� ��������� �����, ����/���.
	wMars = -8;			// ������� �������� ����� � ������� ��������� �����, ����/���, ������� ��������� � �����������, ��������������� �������� ����� 
	dt = 0.1;			// �������� �������������, ���.
	MCoords.RedimMatrix(3);		// ������� ���������� ���� � �� ����� ( x,y,1)
	ECoords.RedimMatrix(3);		// ������� ���������� ����� � �� ������ ( x,y,1)
	MarsCoords.RedimMatrix(3);	
}

void CSunSystem::SetNewCoords()
// ������� ������ ��������� ���������� ���� ������, ��� ����� ��� ������� ����� �� ������ �������������� ���������
// ��������� ����� ���������� ������ � �� ������ ����� �������� ������� dt
{
	//------ ���������� ���� �� ������ (������ ���������� ���� ������������ �����)
	double RoM = (MoonOrbit.right - MoonOrbit.left) / 2;// ������ ������ ����    
	double ff = (fiM / 180.0)*pi;						// ������� - ������� ��������� ���� � �� ����� 
	// cos = x/RoM
	double x = RoM * cos(ff);							// x - ��������� ���������� ���� � �� �����
	// sin = y/RoM
	double y = RoM * sin(ff);							// y - ��������� ���������� ���� � �� �����	
	MCoords(0) = x;	MCoords(1) = y;   MCoords(2) = 1;	// �������� ���� � ����� � ������������ (x,y)
	
	// ------- ��������� ��� ������� ���� �������� �� ������� ���� �� ����� ������ ������������ �����
	// ���������� ���� �������� ����� 0, ����� ������������� 
	// �������: ���� �������� = ������� �������� * ���������� �������
	fiM += wMoon * dt;			
	CMatrix P = CreateRotate2D(fiM);					// ������� �������� ������ ������� ������� ���� �� �������� ����
	MCoords = P * MCoords;

	//-------- ���������� ����� �� ����� ������
	double RoE = (EarthOrbit.right - EarthOrbit.left) / 2;	// ������ ������ �����
	ff = 0;									// ������� - ������� ��������� ����� � �� ������
	x = RoE * cos(ff);										// x - ��������� ���������� ����� � �� ������
	y = RoE * sin(ff);										// y - ��������� ���������� ����� � �� ������
	ECoords(0) = x;	ECoords(1) = y;   ECoords(2) = 1;
	// ��������� ��� ������� �������� ���� 
	P = CreateTranslate2D(x,y) ;
	MCoords = P * MCoords;

	// ������ ��, ��� ����� ����� ��������� �� ����� ������
	fiE += wEarth * dt;
	P = CreateRotate2D(fiE);							// ������� �������� ������ ������� ������� ���� � �����
	MCoords = P * MCoords;	// ������� ���� ������������ �������������� ������ ����
	ECoords = P * ECoords;

	// ������� ���� ������������ ������ �� ���� ������
	double RoMars = (MarsOrbit.right - MarsOrbit.left) / 2;
	ff = (fiMars / 180.0)*pi;
	x = RoMars * cos(ff);
	y = RoMars * sin(ff);
	MarsCoords(0) = x;
	MarsCoords(1) = y;
	MarsCoords(2) = 1;

	// ������, ��� ����� ��������� ����
	fiMars += wMars * dt;
	P = CreateRotate2D(fiMars);
	MarsCoords = P * MarsCoords;
}


void CSunSystem::Draw(CDC& dc)
{
	CBrush SBrush, EBrush, MBrush, MarsBrush, *pOldBrush;
	CRect R;

	SBrush.CreateSolidBrush(RGB(249, 215, 48));
	EBrush.CreateSolidBrush(RGB(0, 149, 245));
	MBrush.CreateSolidBrush(RGB(189, 208, 228));
	MarsBrush.CreateSolidBrush(RGB(161,37,27));

	// ������ ������
	dc.SelectStockObject(NULL_BRUSH);		// ����� ����� - �� ���� ���������
	dc.Ellipse(EarthOrbit);					// ������ �����
	dc.Ellipse(MarsOrbit);

	int d = MoonOrbit.right;				// ������ ������ ����
	R.SetRect(ECoords(0) - d, ECoords(1) + d, ECoords(0) + d, ECoords(1) - d);
	dc.Ellipse(R);							// ������ ����

// ������ ������
	pOldBrush = dc.SelectObject(&SBrush);	// ���� ������
	dc.Ellipse(Sun);  // ������

// ������ �����
	d = Earth.right;						// ������ �����
	R.SetRect(ECoords(0) - d, ECoords(1) + d, ECoords(0) + d, ECoords(1) - d);
	dc.SelectObject(&EBrush);				// ���� �����
	dc.Ellipse(R);	// �����

// ������ ����
	d = Moon.right;							// ������ ����
	R.SetRect(MCoords(0) - d, MCoords(1) + d, MCoords(0) + d, MCoords(1) - d);
	dc.SelectObject(&MBrush);				// ���� ����
	dc.Ellipse(R);	// ����
// ������ ����
	d = Mars.right;
	R.SetRect(MarsCoords(0) - d, MarsCoords(1) + d, MarsCoords(0) + d, MarsCoords(1) - d);
	dc.SelectObject(&MarsBrush);
	dc.Ellipse(R);

	dc.SelectObject(pOldBrush);				//��������������� �������� �� pOldBrush 
}


void CSunSystem::GetRS(CRectD& RSX)
// RS - ���������, ���� ������������ ��������� ������� �������
{
	RSX.left = RS.left;
	RSX.top = RS.top;
	RSX.right = RS.right;
	RSX.bottom = RS.bottom;
}







