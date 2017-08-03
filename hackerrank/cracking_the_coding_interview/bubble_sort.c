// https://www.hackerrank.com/challenges/ctci-bubble-sort

#include <math.h>
#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <assert.h>
#include <limits.h>
#include <stdbool.h>

void swap(int *a, int i, int j);

int main() {

    int n;

    scanf("%d", &n);

    int *a = malloc(sizeof(int) * n);

    for (int a_i = 0; a_i < n; a_i++)
        scanf("%d", &a[a_i]);

    int total_swaps = 0;

    for (int i = 0; i < n; i++) {
        // Track number of elements swapped during a single array traversal
        int number_of_swaps = 0;

        for (int j = 0; j < n - 1; j++) {
            // Swap adjacent elements if they are in decreasing order
            if (a[j] > a[j + 1]) {
                swap(a, j, j + 1);
                number_of_swaps++;
            }
        }

        // If no elements were swapped during a traversal, array is sorted
        if (number_of_swaps == 0)
            break;

        total_swaps += number_of_swaps;
    }

    printf
    ("Array is sorted in %d swaps.\nFirst Element: %d\nLast Element: %d\n",
    total_swaps, a[0], a[n - 1]);
    return 0;
}

void swap(int *a, int i, int j) {
    int temp = a[i];
    a[i] = a[j];
    a[j] = temp;
}
