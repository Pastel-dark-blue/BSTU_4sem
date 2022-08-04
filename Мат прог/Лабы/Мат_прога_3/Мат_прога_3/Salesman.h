// Salesman.h
//	Функция salesman, решающая задачу коммивояжера 
#include "Combi3.h"

#define INF   0x7fffffff   // бесконечность 

int salesman(     // функция возвращает длину оптимального маршрута
	int n,         // [in]  количество городов 
	const int* d,  // [in]  массив [n*n] расстояний 
	int* r         // [out] массив [n] маршрут 0 x x x x 
);
