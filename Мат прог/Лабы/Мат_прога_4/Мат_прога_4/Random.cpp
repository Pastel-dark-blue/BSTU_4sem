#include "Random.h"
#include <iostream>
using namespace std;

string generRand(int len) {
	int min = 97, max = 122; // � ascii � 97 �� 122 ������ ���� ����� ���������� ��������
	string str = "";

	int AlphabetLetterNum;

	for (int i = 0; i < len; i++) {
		AlphabetLetterNum = (rand() % (max - min + 1) + min);
		str.push_back((char)AlphabetLetterNum);
	}

	return str;
}