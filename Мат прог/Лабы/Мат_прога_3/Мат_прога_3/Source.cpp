// main 
#include <iostream>
#include <iomanip> 
#include <tchar.h>
#include <stdio.h>
#include "Salesman.h"

#define N 5

int _tmain(int argc, _TCHAR* argv[])
{
    setlocale(LC_ALL, "rus");

    int d[N][N] = { //0   1    2    3     4        
                   {  INF,  16, 29,  INF,   8 },    //  0
                   { 8,   INF,  23,  60,  76 },    //  1
                   { 10,  24,   INF,  86,   57 },    //  2 
                   { 25,  50,  32,   INF,   24 },    //  3
                   { 85,  74,  52,  21,    INF } };   //  4 
    int r[N];                     // ��������� 
    int s = salesman(
        N,          // [in]  ���������� ������� 
        (int*)d,          // [in]  ������ [n*n] ���������� 
        r           // [out] ������ [n] ������� 0 x x x x  

    );
    std::cout << std::endl << "-- ������ ������������ -- ";
    std::cout << std::endl << "-- ����������  �������: " << N;
    std::cout << std::endl << "-- ������� ���������� : ";
    for (int i = 0; i < N; i++) {
        std::cout << std::endl;
        for (int j = 0; j < N; j++)
            if (d[i][j] != INF) std::cout << std::setw(3) << d[i][j] << " ";
            else std::cout << std::setw(3) << "INF" << " ";
    }
    std::cout << std::endl << "-- ����������� �������: ";
    for (int i = 0; i < N; i++) std::cout << r[i] << "-->"; std::cout << 0;
    std::cout << std::endl << "-- ����� ��������     : " << s;
    std::cout << std::endl;
    system("pause");
    return 0;
}

