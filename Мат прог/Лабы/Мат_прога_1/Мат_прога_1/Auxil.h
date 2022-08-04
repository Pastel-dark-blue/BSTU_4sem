#pragma once
#include <iostream>
#include <cstdlib> // для функций rand() и srand()
#include <ctime> // для функции time()

namespace auxil
{
	void   start();                         // старт  генератора сл. чисел
	double dget(double rmin, double rmax); // получить случайное число 
	int    iget(int rmin, int rmax);        // получить  случайное число
};
