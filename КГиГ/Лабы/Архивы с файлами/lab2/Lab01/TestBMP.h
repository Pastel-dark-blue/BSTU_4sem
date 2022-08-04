#pragma once
#include <Windows.h>
#define define_X 20
#define define_Y 20

int ShowBitMap(HWND hWnd, HANDLE hBit, int x, int y);
int ClientToBmp(HWND hwnd, RECT& r, char* name);
