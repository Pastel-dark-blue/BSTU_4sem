#include "Auxil.h" 

namespace auxil {
	// старт  генератора случайных чисел
	void start() {
		srand((unsigned)time(0)); // устанавливаем значение системных часов в качестве стартового числа
	};

	// получить случайное число типа double в диапазоне [rmin, rmax]
	double dget(double rmin, double rmax) {
		return ((double)rand() / (double)RAND_MAX) * (rmax - rmin) + rmin;
	};

	// получить случайное число типа int в диапазоне [rmin, rmax]
	int iget(int rmin, int rmax) {
		return (int)dget((double)rmin, (double)rmax);
	};
}