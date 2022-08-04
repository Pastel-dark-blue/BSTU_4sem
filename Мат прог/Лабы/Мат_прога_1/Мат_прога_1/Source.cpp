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

	start = clock(); // ������ �������� �������, ������������ ��� ���������� �����
	for (int i = 0; i < CYCLE; i++) {
		av1 += auxil::iget(-100, 100);
		av2 += auxil::dget(-100, 100);
	}
	end = clock(); // ���������� ��������

	cout << "���������� ������:\t" << CYCLE;
	cout << "\n������� �������� (int):\t" << av1 / CYCLE;
	cout << "\n������� �������� (double):\t" << av2 / CYCLE;
	// ���������� ���������� ��������� ������, ��������� � ������ ������� ���������. 
	cout << "\n����������������� \n\t(�.�):\t" << (end - start);
	// � ������� ������� CLOCKS_PER_SEC ������� �������� ���������� ���������� ������ �� 1 �������.
	cout << "\n\t(���):\t" << ((double)(end - start)) / ((double)CLOCKS_PER_SEC); 
	cout << endl;
}