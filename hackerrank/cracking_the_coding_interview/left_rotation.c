
// https://www.hackerrank.com/challenges/ctci-array-left-rotation

#include <stdio.h>
#include <stdlib.h>

int main() {

	int size;
	int rotations;

	scanf("%d %d", &size, &rotations);

	int* array = (int*) malloc(size * sizeof(int));

	for(int i = 0; i < size; i++)
		scanf("%d ", &array[i]);

	for(int i = 0; i < size; i++)
		printf("%d ", array[(i + rotations) % size]);

}
