#pragma once
#include <iostream>
#include <cstdlib> // ��� ������� rand() � srand()
#include <ctime> // ��� ������� time()

namespace auxil
{
	void   start();                         // �����  ���������� ��. �����
	double dget(double rmin, double rmax); // �������� ��������� ����� 
	int    iget(int rmin, int rmax);        // ��������  ��������� �����
};
