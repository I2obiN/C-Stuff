// Famous square root inverse algorithm from Quake 3

#include "stdafx.h"
#include <iostream>
#include <stdio.h>

using namespace std;

float Q_rsqrt(float number) {
	long i;
	float x2, y;
	const float threehalfs = 1.5F;

	x2 = number * 0.5F;
	y = number;

	// i == pointer to value of memory y, cast as long
	i = *(long *)&y;

	// Shift bit of i 1 and deduct by magic number
	i = 0x5f3759df - (i >> 1);

	// cast back to float, y points to value @ memory of i
	y = *(float*)&i;

	y = y * (threehalfs - (x2 * y * y));   // 1st iteration

	// Return approx..
	return y;
}

int main()
{
	double x = Q_rsqrt(32);
	cout << x;
}
