#include <iostream>
#include <iomanip>

#include "Combi1.h"
#include "Combi2.h"
#include "Combi3.h"
#include "Combi4.h"

#include "BoatC.h"
#include "Auxil.h"

void task1();
void task2();
void task3();
void task4();
void task5();
void task6();

int main()
{
    setlocale(LC_ALL, "rus");

    std::cout << "===================== ������� 1 =====================" << std::endl;
    task1();
    std::cout << "===================== ������� 2 =====================" << std::endl;
    task2();
    std::cout << "===================== ������� 3 =====================" << std::endl;
    task3();
    std::cout << "===================== ������� 4 =====================" << std::endl;
    task4();
    std::cout << "===================== ������� 5 =====================" << std::endl;
    task5();
    std::cout << "===================== ������� 6 =====================" << std::endl;
    task6();

    return 0;
}

void task1() {
    //---------------  ������ ���������� ���������� ��������� ���� ����������� 
    char  AA[][2] = { "A", "B", "C", "D" };
    std::cout << " - ��������� ��������� ���� ����������� -";
    std::cout << std::endl << "�������� ���������: ";
    std::cout << "{ ";
    for (int i = 0; i < sizeof(AA) / 2; i++)
        std::cout << AA[i] << ((i < sizeof(AA) / 2 - 1) ? ", " : " ");
    std::cout << "}";
    std::cout << std::endl << "��������� ���� �����������  ";
    combi1::subset s1(sizeof(AA) / 2);     // �������� ����������   
    int  n = s1.getfirst();                // ������ (������) ������������    
    while (n >= 0)                         // ���� ���� ������������ 
    {
        std::cout << std::endl << "{ ";
        for (int i = 0; i < n; i++)
            std::cout << AA[s1.ntx(i)] << ((i < n - 1) ? ", " : " ");
        std::cout << "}";
        n = s1.getnext();                  // c�������� ������������ 
    };
    std::cout << std::endl << "�����: " << s1.count() << std::endl;
}

void task2() {
    //---------------  ������ ���������� ���������� ���������
    char  AA[][2] = { "A", "B", "C", "D", "E" };
    std::cout << " --- ��������� ��������� ---";
    std::cout << std::endl << "�������� ���������: ";
    std::cout << "{ ";
    for (int i = 0; i < sizeof(AA) / 2; i++)
        std::cout << AA[i] << ((i < sizeof(AA) / 2 - 1) ? ", " : " ");
    std::cout << "}";
    std::cout << std::endl << "��������� ��������� ";
    combi2::xcombination xc(sizeof(AA) / 2, 3);
    std::cout << "�� " << xc.n << " �� " << xc.m;
    int  n = xc.getfirst();
    while (n >= 0)
    {
        std::cout << std::endl << xc.nc << ": { ";
        for (int i = 0; i < n; i++)
            std::cout << AA[xc.ntx(i)] << ((i < n - 1) ? ", " : " ");
        std::cout << "}";
        n = xc.getnext();
    };
    std::cout << std::endl << "�����: " << xc.count() << std::endl;
}

void task3() {
    //---------------  ������ ���������� ���������� ������������
    char  AA[][2] = { "A", "B", "C", "D" };
    std::cout << std::endl << " --- ��������� ������������ ---";
    std::cout << std::endl << "�������� ���������: ";
    std::cout << "{ ";
    for (int i = 0; i < sizeof(AA) / 2; i++)
        std::cout << AA[i] << ((i < sizeof(AA) / 2 - 1) ? ", " : " ");
    std::cout << "}";
    std::cout << std::endl << "��������� ������������ ";
    combi3::permutation p(sizeof(AA) / 2);
    __int64  n = p.getfirst();
    while (n >= 0)
    {
        std::cout << std::endl << std::setw(4) << p.np << ": { ";
        for (int i = 0; i < p.n; i++)
            std::cout << AA[p.ntx(i)] << ((i < p.n - 1) ? ", " : " ");
        std::cout << "}";
        n = p.getnext();
    };
    std::cout << std::endl << "�����: " << p.count() << std::endl;
}

#define N (sizeof(AA)/2)
#define M 3
void task4()
{
    //---------------  ������ ������������� ���������� ������������ 
    char  AA[][2] = { "A", "B", "C", "D" };
    std::cout << std::endl << " --- ��������� ���������� ---";
    std::cout << std::endl << "�������� ���������: ";
    std::cout << "{ ";
    for (int i = 0; i < N; i++)
        std::cout << AA[i] << ((i < N - 1) ? ", " : " ");
    std::cout << "}";
    std::cout << std::endl << "��������� ����������  ��  " << N << " �� " << M;
    combi4::accomodation s(N, M);
    int  n = s.getfirst();
    while (n >= 0) {
        std::cout << std::endl << std::setw(2) << s.na << ": { ";
        for (int i = 0; i < 3; i++)
            std::cout << AA[s.ntx(i)] << ((i < n - 1) ? ", " : " ");
        std::cout << "}";
        n = s.getnext();
    };
    std::cout << std::endl << "�����: " << s.count() << std::endl;
}

#define NN 8
#define MM 5
void task5()
{
    //---------------  ������ ������� ������ �� ����������� ���������� ����������� �� �����
    // ��� (� ��� 8 ����������� � ����� �� 100 �� 200 ��, �� ������� ����� ������������� ���� ���� ���������)
    // ��� ��� ��������� ��������������� ����� �� 1 ��
    int v[NN];
    for (int i = 0; i < NN; i++) 
        v[i] = auxil::iget(100, 200);

    // ����� (����� ��� 8 ����������� �� 10 �� 100 �.�.)
    int c[NN];
    // ����������� ��� ����������� ��� ������� ����� 50-120 ��
    int minv[NN];
    // ������������ ��� ����������� ��� ������� ����� 150-850 ��
    int maxv[NN];
    for (int i = 0; i < NN; i++) {
        v[i] = auxil::iget(100, 200);
        c[i] = auxil::iget(10, 100);
        minv[i] = auxil::iget(50, 120);
        maxv[i] = auxil::iget(150, 850);
    }

    short r[MM];
    int cc = boat_�(
        MM,    // [in]  ���������� ���� ��� �����������
        minv,  // [in]  ����������� ��� ���������� �� ������  ����� 
        maxv,  // [in]  ������������ ��� ���������� �� ������  �����  
        NN,    // [in]  ����� �����������  
        v,     // [in]  ��� ������� ����������  
        c,     // [in]  ����� �� ��������� ������� ����������   
        r      // [out] ������  ��������� �����������  
    );

    std::cout << std::endl << "- ������ � ���������� ����������� �� ����� � �������� ���������-";
    std::cout << std::endl << "- ����� ���������� �����������   : " << NN;
    std::cout << std::endl << "- ���������� ���� ��� �����������  : " << MM;
    std::cout << std::endl << "- �����������  ��� ����������  : ";
    for (int i = 0; i < MM; i++) std::cout << std::setw(3) << minv[i] << " ";
    std::cout << std::endl << "- ������������ ��� ����������  : ";
    for (int i = 0; i < MM; i++) std::cout << std::setw(3) << maxv[i] << " ";
    std::cout << std::endl << "- ��� �����������      : ";
    for (int i = 0; i < NN; i++) std::cout << std::setw(3) << v[i] << " ";
    std::cout << std::endl << "- ����� �� ���������     : ";
    for (int i = 0; i < NN; i++) std::cout << std::setw(3) << c[i] << " ";
    std::cout << std::endl << "- ������� ���������� (0,1,...,m-1) : ";
    for (int i = 0; i < MM; i++) std::cout << r[i] << " ";
    std::cout << std::endl << "- ����� �� ���������     : " << cc;
    std::cout << std::endl << std::endl;
}

#define SPACE(n) std::setw(n)<<" "
#define NN 8
void task6() {
    //---------------  ������  �����������������  �������  ������  �  ����������  ����������� �� �����
    int v[NN + 1], c[NN + 1], minv[NN + 1], maxv[NN + 1];
    short r[NN];
    auxil::start();
    // ��������� �������� � �������� �����, �������, ���. � ����. �����
    for (int i = 0; i <= NN; i++) {
        v[i] = auxil::iget(100, 200);
        c[i] = auxil::iget(10, 100);
        minv[i] = auxil::iget(50, 120);
        maxv[i] = auxil::iget(150, 850);
    }

    std::cout << std::endl << "-- ������ � ���������� ����������� -- ";
    std::cout << std::endl << "-- ����� �����������: " << NN;
    std::cout << std::endl << "-- ���������� ------ ����������������� -- ";
    std::cout << std::endl << "       ����             ����������  ";
    clock_t t1, t2;
    // i++ - ����������� ���������� ����
    for (int i = 4; i <= NN; i++) {
        // �������� ����������������� 
        t1 = clock();
        boat_�(i, minv, maxv, NN, v, c, r);
        t2 = clock();

        std::cout << std::endl << SPACE(7) << std::setw(2) << i
            << SPACE(15) << std::setw(6) << (t2 - t1);
    }
}