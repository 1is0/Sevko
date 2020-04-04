// 2.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <stdio.h>
#include <math.h>


// Factorial
int fact(int n) {
	if (n == 1 || n == 0) {
		return 1;
	}
	return n * fact(n - 1);
}
// Cycle
void Cycle(double x, int n, double e) {
	int counter = 1;
	double sinx = 0;
	int N = 0;
	double series = 0;
	sinx = sin(x);
	while (counter <= n) {
		series += (pow(-1, (double)counter - 1) * pow(x, 2 * (double)counter - 1)) / fact(2 * counter - 1);
		if (fabs(series - sinx) < e && N == 0) {
			N = counter;
		}
		counter++;
	}
	printf("sin x = %lf\n\n", sinx);
	printf("series = %lf\n", series);
	if (N == 0) {
		while (fabs(series - sinx) > e) {
			series += (pow(-1, (double)counter - 1) * pow(x, 2 * (double)counter - 1)) / fact(2 * counter - 1);
			counter++;
		}
		N = counter;
	}
	printf("when n = %d, the error is less than e = %lf\n\n", N, e);
}
// Recursion
double Rec(double x, int n, double e) {
	static double series = 0;
	series += (pow(-1, (double)n - 1) * pow(x, 2 * (double)n - 1)) / fact(2 * n - 1);
	n--;
	if (n > 0) {
		return Rec(x, n, e);
	}
	printf("series = %lf\n", series);
	return 0;
}

int main()
{
	double x = 0;
	int n = 0;
	double e = 0;
	int check;
	printf("Enter x ");
	check = scanf_s("%lf", &x);
	fflush(stdin);
	if (!check) {
		printf("Invalid input. Try more");
		exit(0);
	}
	printf("Enter the number of members in a row n ");
	check = scanf_s("%d", &n);
	fflush(stdin);
	if (!check) {
		printf("Invalid input. Try more");
		exit(0);
	}
	printf("Enter math error e ");
	check = scanf_s("%lf", &e);
	fflush(stdin);
	if (!check) {
		printf("Invalid input. Try more");
		exit(0);
	}
	Cycle(x, n, e);
	Rec(x, n, e);
	return 0;
}
