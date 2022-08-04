#pragma once

#include "stdafx.h"
#include "CMatrix.h"
#include "LibGraph.h"
#include "math.h"
CRectD::CRectD(double l, double t, double r, double b)
{
	left = l;
	top = t;
	right = r;
	bottom = b;
}
void CRectD::SetRectD(double l, double t, double r, double b)
{
	left = l;
	top = t;
	right = r;
	bottom = b;
}
CSizeD CRectD::SizeD()
{
	CSizeD cz;
	cz.cx = fabs(right - left); // Ширина прямоугольной области
	cz.cy = fabs(top - bottom); // Высота прямоугольной области
	return cz;
}
CMatrix SpaceToWindow(CRectD& RS, CRect& RW)
// Функция обновлена
// Возвращает матрицу пересчета координат из мировых в оконные
// RS - область в мировых координатах - double
// RW - область в оконных координатах - int
{
	CMatrix M(3, 3);
	CSize sz = RW.Size(); // Размер области в ОКНЕ
	int dwx = sz.cx; // Ширина
	int dwy = sz.cy; // Высота
	CSizeD szd = RS.SizeD(); // Размер области в МИРОВЫХ координатах
	double dsx = szd.cx; // Ширина в мировых координатах
	double dsy = szd.cy; // Высота в мировых координатах

	double kx = (double)dwx / dsx; // Масштаб по x
	double ky = (double)dwy / dsy; // Масштаб по y
	M(0, 0) = kx; M(0, 1) = 0; M(0, 2) = (double)RW.left - kx * RS.left; // Обновлено
	M(1, 0) = 0; M(1, 1) = -ky; M(1, 2) = (double)RW.bottom + ky * RS.bottom; // Обновлено
	M(2, 0) = 0; M(2, 1) = 0; M(2, 2) = 1;
	return M;
}

CMatrix VectorMult(CMatrix& V1, CMatrix& V2){
// Вычисляет векторное произведение векторов V1 и V2
// Векторное произведение — это псевдовектор, перпендикулярный плоскости, построенной по двум 
// сомножителям,
// являющийся результатом бинарной операции «векторное умножение» над векторами в трѐхмерном 
// Евклидовом пространстве.
// Векторное произведение полезно для «измерения» перпендикулярности векторов — длина векторного 
// произведения двух векторов
// равна произведению их длин, если они перпендикулярны, и уменьшается до нуля, если векторы параллельны 
// либо антипараллельны.

	int b1 = (V1.cols() == 1) && (V1.rows() == 3);
	int b2 = (V2.cols() == 1) && (V2.rows() == 3);
	int b = b1 && b2;

	if (!b)
	{
		char* error = "VectorMult: неправильные размерности векторов! ";
		MessageBox(NULL, error, "Ошибка", MB_ICONSTOP);
		exit(1);
	}
	CMatrix W(3);
	W(0) = V1(1) * V2(2) - V1(2) * V2(1);
	//double x=W(0);
	W(1) = -(V1(0) * V2(2) - V1(2) * V2(0));
	//double y=W(1);
	W(2) = V1(0) * V2(1) - V1(1) * V2(0);
	//double z=W(2);
	return W;
}
double ScalarMult(CMatrix& V1, CMatrix& V2)
// Вычисляет скалярное произведение векторов V1 и V2
// Скаля́рное произведе́ние — операция над двумя векторами, результатом которой является число (скаляр), 
// не зависящее от системы координат и характеризующее длины векторов-сомножителей и угол между ними. 
// Данной операции соответствует умножение длины вектора x на проекцию вектора y на вектор x. Эта операция 
// обычно рассматривается как коммутативная и линейная по каждому сомножителю.
{
	int b1 = (V1.cols() == 1) && (V1.rows() == 3);
	int b2 = (V2.cols() == 1) && (V2.rows() == 3);
	int b = b1 && b2;
	if (!b)
	{
		char* error = "ScalarMult: неправильные размерности векторов! ";
		MessageBox(NULL, error, "Ошибка", MB_ICONSTOP);
		exit(1);
	}
	double p = V1(0) * V2(0) + V1(1) * V2(1) + V1(2) * V2(2);
	return p;
}
CMatrix CreateViewCoord(double r, double fi, double q)
// Создает матрицу пересчета точки из мировой системы координат в видовую
// (r,fi,q)- координата ТОЧКИ НАБЛЮДЕНИЯ(начало видовой системы координат)
// в мировой сферической системе координат( углы fi и q в градусах)
{
	double fg = fmod(fi, 360.0);
	double ff = (fg / 180.0) * pi; // Перевод в радианы
	fg = fmod(q, 360.0);
	double qq = (fg / 180.0) * pi; // Перевод в радианы
	CMatrix VM(4, 4); // Матрица пересчета
	VM(0, 0) = -sin(ff); VM(0, 1) = cos(ff);
	VM(1, 0) = -cos(qq) * cos(ff); VM(1, 1) = -cos(qq) * sin(ff); VM(1, 2) = sin(qq);
	VM(2, 0) = -sin(qq) * cos(ff); VM(2, 1) = -sin(qq) * sin(ff); VM(2, 2) = -cos(qq); VM(2, 3) = r;
	VM(3, 3) = 1;
	return VM;
}
CMatrix SphereToCart(CMatrix& PView){
// Преобразует сферические координаты PView точки в декартовы
// PView(0) - r
// PView(1) - fi - азимут(отсчет от оси X), град.
// PView(2) - q - угол(отсчетот оси Z), град.
// Результат: R(0)- x, R(1)- y, R(2)- z

	CMatrix R(3);
	double r = PView(0);
	double fi = PView(1); // Градусы
	double q = PView(2); // Градусы
	double fi_rad = (fi / 180.0) * pi; // Перевод fi в радианы
	double q_rad = (q / 180.0) * pi; // Перевод q в радианы
	R(0) = r * sin(q_rad) * cos(fi_rad); // x- координата точки наблюдения

	R(1) = r * sin(q_rad) * sin(fi_rad); // y- координата точки наблюдения
	R(2) = r * cos(q_rad); // z- координата точки наблюдения
	return R;
}