#include "Auxil.h"
#define CYCLE 100000

using namespace std;

int main() {
	double av1 = 0,
		av2 = 0;

	clock_t start = 0,
		end = 0;

	setlocale(LC_ALL, "rus");

	auxil::start();

	start = clock(); // начало подсчета времени, необходимого для выполнения цикла
	for (int i = 0; i < CYCLE; i++) {
		av1 += auxil::iget(-100, 100);
		av2 += auxil::dget(-100, 100);
	}
	end = clock(); // завершение подсчета

	cout << "количество циклов:\t" << CYCLE;
	cout << "\nсреднее значение (int):\t" << av1 / CYCLE;
	cout << "\nсреднее значение (double):\t" << av2 / CYCLE;
	// Возвращает количество временных тактов, прошедших с начала запуска программы. 
	cout << "\nпродолжительность \n\t(у.е):\t" << (end - start);
	// С помощью макроса CLOCKS_PER_SEC функция получает количество пройденных тактов за 1 секунду.
	cout << "\n\t(сек):\t" << ((double)(end - start)) / ((double)CLOCKS_PER_SEC); 
	cout << endl;
}