#include <iostream>
#include "Graph.h"
#include "BFS.h"
#include "DFS.h"

int main()
{
	setlocale(LC_ALL, "rus");

	int m[7][7] = {
				  {0, 0, 1, 1, 0, 0, 0},
				  {0, 0, 0, 0, 0, 0, 0},
				  {0, 0, 0, 0, 0, 1, 0},
				  {0, 1, 1, 0, 1, 0, 1},
				  {0, 1, 0, 0, 0, 0, 1},
				  {0, 0, 0, 0, 0, 0, 1},
				  {0, 0, 0, 0, 0, 0, 0},
	};
	graph::AMatrix g1(7, (int*)m);
	std::cout << std::endl;
	std::cout << std::endl << "-- матрица смежности орграфа" << std::endl;
	for (int i = 0; i < g1.n_vertex; i++)
	{
		std::cout << std::endl;
		for (int j = 0; j < g1.n_vertex; j++) std::cout << g1.get(i, j) << " ";
	};
	std::cout << std::endl;

	graph::AList g2(g1);
	std::cout << std::endl;
	std::cout << std::endl << "-- списки смежных вершин орграфа" << std::endl;
	for (int i = 0; i < g1.n_vertex; i++)
	{
		std::cout << std::endl << i << ": ";
		for (int j = 0; j < g2.size(i); j++) std::cout << g2.get(i, j) << " ";
	}
	std::cout << std::endl;

	graph::AList g5(7, (int*)m);
	BFS b33(g5, 0);
	std::cout << std::endl;
	std::cout << std::endl << "-- поиск в ширину (орграф)" << std::endl;
	std::cout << std::endl << " порядок закрашивания вершин в чёрный" << std::endl;
	int k2;
	while ((k2 = b33.get()) != BFS::NIL) std::cout << k2 << " ";
	std::cout << std::endl;
	DFS b3(g5);
	std::cout << std::endl;
	std::cout << std::endl << "-- поиск в глубину (орграф) " << std::endl;
	std::cout << std::endl << " порядок закрашивания вершин в чёрный" << std::endl;
	for (int i = 0; i < g5.n_vertex; i++) std::cout << b3.get(i) << " ";
	std::cout << std::endl;
	reverse(b3.topological_sort.begin(), b3.topological_sort.end()); // согласно алгоритму переворачиваем полученную последовательность

	std::cout << std::endl << "Топологическая сортировка (орграф)" << std::endl;
	for (std::vector <int>::iterator i(b3.topological_sort.begin()); i != b3.topological_sort.end(); ++i) std::cout << *i << ' ';
	std::cout << std::endl;

	system("pause");
	return 0;
}
