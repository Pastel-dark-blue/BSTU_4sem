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

    std::cout << "===================== ЗАДАНИЕ 1 =====================" << std::endl;
    task1();
    std::cout << "===================== ЗАДАНИЕ 2 =====================" << std::endl;
    task2();
    std::cout << "===================== ЗАДАНИЕ 3 =====================" << std::endl;
    task3();
    std::cout << "===================== ЗАДАНИЕ 4 =====================" << std::endl;
    task4();
    std::cout << "===================== ЗАДАНИЕ 5 =====================" << std::endl;
    task5();
    std::cout << "===================== ЗАДАНИЕ 6 =====================" << std::endl;
    task6();

    return 0;
}

void task1() {
    //---------------  Пример применения генератора множества всех подмножеств 
    char  AA[][2] = { "A", "B", "C", "D" };
    std::cout << " - Генератор множества всех подмножеств -";
    std::cout << std::endl << "Исходное множество: ";
    std::cout << "{ ";
    for (int i = 0; i < sizeof(AA) / 2; i++)
        std::cout << AA[i] << ((i < sizeof(AA) / 2 - 1) ? ", " : " ");
    std::cout << "}";
    std::cout << std::endl << "Генерация всех подмножеств  ";
    combi1::subset s1(sizeof(AA) / 2);     // создание генератора   
    int  n = s1.getfirst();                // первое (пустое) подмножество    
    while (n >= 0)                         // пока есть подмножества 
    {
        std::cout << std::endl << "{ ";
        for (int i = 0; i < n; i++)
            std::cout << AA[s1.ntx(i)] << ((i < n - 1) ? ", " : " ");
        std::cout << "}";
        n = s1.getnext();                  // cледующее подмножество 
    };
    std::cout << std::endl << "всего: " << s1.count() << std::endl;
}

void task2() {
    //---------------  Пример применения генератора сочетаний
    char  AA[][2] = { "A", "B", "C", "D", "E" };
    std::cout << " --- Генератор сочетаний ---";
    std::cout << std::endl << "Исходное множество: ";
    std::cout << "{ ";
    for (int i = 0; i < sizeof(AA) / 2; i++)
        std::cout << AA[i] << ((i < sizeof(AA) / 2 - 1) ? ", " : " ");
    std::cout << "}";
    std::cout << std::endl << "Генерация сочетаний ";
    combi2::xcombination xc(sizeof(AA) / 2, 3);
    std::cout << "из " << xc.n << " по " << xc.m;
    int  n = xc.getfirst();
    while (n >= 0)
    {
        std::cout << std::endl << xc.nc << ": { ";
        for (int i = 0; i < n; i++)
            std::cout << AA[xc.ntx(i)] << ((i < n - 1) ? ", " : " ");
        std::cout << "}";
        n = xc.getnext();
    };
    std::cout << std::endl << "всего: " << xc.count() << std::endl;
}

void task3() {
    //---------------  Пример применения генератора перестановок
    char  AA[][2] = { "A", "B", "C", "D" };
    std::cout << std::endl << " --- Генератор перестановок ---";
    std::cout << std::endl << "Исходное множество: ";
    std::cout << "{ ";
    for (int i = 0; i < sizeof(AA) / 2; i++)
        std::cout << AA[i] << ((i < sizeof(AA) / 2 - 1) ? ", " : " ");
    std::cout << "}";
    std::cout << std::endl << "Генерация перестановок ";
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
    std::cout << std::endl << "всего: " << p.count() << std::endl;
}

#define N (sizeof(AA)/2)
#define M 3
void task4()
{
    //---------------  Пример использования генератора перестановок 
    char  AA[][2] = { "A", "B", "C", "D" };
    std::cout << std::endl << " --- Генератор размещений ---";
    std::cout << std::endl << "Исходное множество: ";
    std::cout << "{ ";
    for (int i = 0; i < N; i++)
        std::cout << AA[i] << ((i < N - 1) ? ", " : " ");
    std::cout << "}";
    std::cout << std::endl << "Генерация размещений  из  " << N << " по " << M;
    combi4::accomodation s(N, M);
    int  n = s.getfirst();
    while (n >= 0) {
        std::cout << std::endl << std::setw(2) << s.na << ": { ";
        for (int i = 0; i < 3; i++)
            std::cout << AA[s.ntx(i)] << ((i < n - 1) ? ", " : " ");
        std::cout << "}";
        n = s.getnext();
    };
    std::cout << std::endl << "всего: " << s.count() << std::endl;
}

#define NN 8
#define MM 5
void task5()
{
    //---------------  Пример решения задачи об оптимальном размещении контейнеров на судне
    // вес (у нас 8 контейнеров с весом от 100 до 200 кг, по заданию нужно сгенерировать веса этом диапазоне)
    // код для генерации псевдослучайных чисел из 1 лр
    int v[NN];
    for (int i = 0; i < NN; i++) 
        v[i] = auxil::iget(100, 200);

    // доход (доход для 8 контейнеров от 10 до 100 у.е.)
    int c[NN];
    // минимальный вес контейнеров для каждого места 50-120 кг
    int minv[NN];
    // максимальный вес контейнеров для каждого места 150-850 кг
    int maxv[NN];
    for (int i = 0; i < NN; i++) {
        v[i] = auxil::iget(100, 200);
        c[i] = auxil::iget(10, 100);
        minv[i] = auxil::iget(50, 120);
        maxv[i] = auxil::iget(150, 850);
    }

    short r[MM];
    int cc = boat_с(
        MM,    // [in]  количество мест для контейнеров
        minv,  // [in]  минимальный вес контейнера на каждом  месте 
        maxv,  // [in]  максимальный вес контейнера на каждом  месте  
        NN,    // [in]  всего контейнеров  
        v,     // [in]  вес каждого контейнера  
        c,     // [in]  доход от перевозки каждого контейнера   
        r      // [out] номера  выбранных контейнеров  
    );

    std::cout << std::endl << "- Задача о размещении контейнеров на судне с условием центровки-";
    std::cout << std::endl << "- общее количество контейнеров   : " << NN;
    std::cout << std::endl << "- количество мест для контейнеров  : " << MM;
    std::cout << std::endl << "- минимальный  вес контейнера  : ";
    for (int i = 0; i < MM; i++) std::cout << std::setw(3) << minv[i] << " ";
    std::cout << std::endl << "- максимальный вес контейнера  : ";
    for (int i = 0; i < MM; i++) std::cout << std::setw(3) << maxv[i] << " ";
    std::cout << std::endl << "- вес контейнеров      : ";
    for (int i = 0; i < NN; i++) std::cout << std::setw(3) << v[i] << " ";
    std::cout << std::endl << "- доход от перевозки     : ";
    for (int i = 0; i < NN; i++) std::cout << std::setw(3) << c[i] << " ";
    std::cout << std::endl << "- выбраны контейнеры (0,1,...,m-1) : ";
    for (int i = 0; i < MM; i++) std::cout << r[i] << " ";
    std::cout << std::endl << "- доход от перевозки     : " << cc;
    std::cout << std::endl << std::endl;
}

#define SPACE(n) std::setw(n)<<" "
#define NN 8
void task6() {
    //---------------  Оценка  продолжительности  решения  задачи  о  размещении  контейнеров на судне
    int v[NN + 1], c[NN + 1], minv[NN + 1], maxv[NN + 1];
    short r[NN];
    auxil::start();
    // генерация значений в массивах весов, доходов, мин. и макс. весов
    for (int i = 0; i <= NN; i++) {
        v[i] = auxil::iget(100, 200);
        c[i] = auxil::iget(10, 100);
        minv[i] = auxil::iget(50, 120);
        maxv[i] = auxil::iget(150, 850);
    }

    std::cout << std::endl << "-- Задача о размещении контейнеров -- ";
    std::cout << std::endl << "-- всего контейнеров: " << NN;
    std::cout << std::endl << "-- количество ------ продолжительность -- ";
    std::cout << std::endl << "       мест             вычисления  ";
    clock_t t1, t2;
    // i++ - увеличиваем количество мест
    for (int i = 4; i <= NN; i++) {
        // замеряем продолжительность 
        t1 = clock();
        boat_с(i, minv, maxv, NN, v, c, r);
        t2 = clock();

        std::cout << std::endl << SPACE(7) << std::setw(2) << i
            << SPACE(15) << std::setw(6) << (t2 - t1);
    }
}