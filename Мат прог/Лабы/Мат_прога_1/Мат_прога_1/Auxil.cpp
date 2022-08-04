#include "Auxil.h" 

namespace auxil {
	// �����  ���������� ��������� �����
	void start() {
		srand((unsigned)time(0)); // ������������� �������� ��������� ����� � �������� ���������� �����
	};

	// �������� ��������� ����� ���� double � ��������� [rmin, rmax]
	double dget(double rmin, double rmax) {
		return ((double)rand() / (double)RAND_MAX) * (rmax - rmin) + rmin;
	};

	// �������� ��������� ����� ���� int � ��������� [rmin, rmax]
	int iget(int rmin, int rmax) {
		return (int)dget((double)rmin, (double)rmax);
	};
}