#include "pch.h"

using namespace std;

const double PI = 3.141592653589793238463;

__declspec(dllexport)
extern "C" __declspec(dllexport) double __stdcall Area(int radius)
{
	return PI * radius * radius;
}

extern "C" __declspec(dllexport) double __stdcall Circumference(int radius)
{
	return PI * radius * 2;
}

extern "C" __declspec(dllexport) double __stdcall SectorArea(int radius, int angle)
{
	return PI * radius * radius * angle / 360;
}

