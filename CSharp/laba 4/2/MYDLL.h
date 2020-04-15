#pragma once
#ifdef MYDLL_EXPORTS
#define MYDLL_API __declspec(dllexport)
#else
#define MYDLL_API __declspec(dllimport)
#endif
extern "C" MYDLL_API double Area(int radius);
extern "C" MYDLL_API double Circumference(int radius);
extern "C" MYDLL_API double SectorArea(int radius, int angle);