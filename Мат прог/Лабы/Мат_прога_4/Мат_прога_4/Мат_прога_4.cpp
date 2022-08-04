// --- main  
#include <iostream>
#include "Random.h"
#include "Levenshtein.h"
#include "Matrix.h"
#include <iomanip>

using namespace std;

#define N 6

int main()
{
    setlocale(LC_ALL, "rus");

    // ------------1
    string S1 = generRand(300);
    string S2 = generRand(250);
    cout << "S1 = " << S1 << endl << "S2 = " << S2 << endl;

    // ------------2
    clock_t t1 = 0, t2 = 0, t3 = 0, t4 = 0;
    int lx = S1.length();
    int ly = S2.length();

    // должно быть так, но будет считать слишком медленно
    //int x[]{ 12,15,20,30,60,150,300 };
    //int y[]{ 10,13,17,25,50,125,250 };

    // поэтому берем значения поменьше
    float x[]{ 0.64, 0.8, 0.96, 1.6, 3.2, 8 };
    float y[]{ 0.64, 0.8, 0.96, 1.6, 3.2, 8 };

    cout << "\n\n-- расстояние Левенштейна -----";
    cout << "\n\n-- длина строки --- рекурсия -- дин.програм. ---\n";

    for (int i = 0; i < min(sizeof(x)/sizeof(float), sizeof(y) / sizeof(float)); i++) {
        // рекурсия
        t1 = clock();
        levenshtein_r(x[i], S1, y[i], S2);
        t2 = clock();
        
        // дин.програм.
        t3 = clock();
        levenshtein(x[i], S1, y[i], S2);
        t4 = clock();

        cout << right << setw(2) << x[i] << "/" << setw(2) << y[i]
            << "        " << left << setw(10) << (t2 - t1)
            << "   " << setw(10) << (t4 - t3) << endl;
    }

    // ------------5
    // N - в define выше
    int Mc[N + 1] = { 10, 15, 80, 23, 50, 40, 71 }, 
        Ms[N][N], 
        r = 0, 
        rd = 0;
    
    // Ms - массив массивов, заполняем его нулями 
    memset(Ms, 0, sizeof(int) * N * N); // заполнить первые sizeof(int) * N * N байт значением 0
    t1 = clock();
    r = OptimalM(1, N, N, Mc, OPTIMALM_PARM(Ms));
    t2 = clock();
    setlocale(LC_ALL, "rus");
    cout << endl;
    cout << endl << "-- расстановка скобок (рекурсивное решение) " << endl;
    cout << endl << "затраченное время(сек):  " << ((double)(t2 - t1)) / ((double)CLOCKS_PER_SEC) << endl;
    cout << endl << "размерности матриц: ";
    for (int i = 1; i <= N; i++) cout << "(" << Mc[i - 1] << "," << Mc[i] << ") ";
    cout << endl << "минимальное количество операций умножения: " << r;
    cout << endl << endl << "матрица S" << endl;
    for (int i = 0; i < N; i++)
    {
        cout << endl;
        for (int j = 0; j < N; j++)  cout << Ms[i][j] << "  ";
    }
    cout << endl;

    memset(Ms, 0, sizeof(int) * N * N);
    t3 = clock();
    rd = OptimalMD(N, Mc, OPTIMALM_PARM(Ms));
    t4 = clock();
    cout << endl
        << "-- расстановка скобок (динамическое программирование) " << endl;
    cout << endl << "затраченное время(сек):  " << ((double)(t4 - t3)) / ((double)CLOCKS_PER_SEC) << endl;
    cout << endl << "размерности матриц: ";
    for (int i = 1; i <= N; i++)
        cout << "(" << Mc[i - 1] << "," << Mc[i] << ") ";
    cout << endl << "минимальное количество операций умножения: "
        << rd;
    cout << endl << endl << "матрица S" << endl;
    for (int i = 0; i < N; i++)
    {
        cout << endl;
        for (int j = 0; j < N; j++)  cout << Ms[i][j] << "  ";
    }
    cout << endl << endl;

    cout << endl;
    system("pause");
    return 0;
}
