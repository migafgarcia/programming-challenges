// https://www.hackerrank.com/challenges/ctci-merge-sort

#include <stdio.h>
#include <stdlib.h>


unsigned long long mergesort(int* a, int start, int end);
unsigned long long merge(int* a, int start, int middle, int end);

int main(){

    int t;

    scanf("%d",&t);

    for(int a0 = 0; a0 < t; a0++) {

        int n; 

        scanf("%d",&n);

        int *arr = malloc(sizeof(int) * n);

        for(int arr_i = 0; arr_i < n; arr_i++) {
           scanf("%d",&arr[arr_i]);
        }

        unsigned long long swaps = mergesort(arr, 0, n - 1);

        printf("%llu\n", swaps);
    }

    return 0;
}

unsigned long long mergesort(int* a, int start, int end) {

	// printf("START = %d, END = %d\n", start, end);
	if(start >= end)
		return 0;
	unsigned long long swaps = 0;
	int middle = (start + end) / 2;

	swaps += mergesort(a, start, middle);
	swaps += mergesort(a, middle + 1 , end);
	swaps += merge(a, start, middle, end);

	return swaps;
}

unsigned long long merge(int* a, int start, int middle, int end) {
	// printf("START = %d, MIDDLE = %d, END = %d\n", start, middle, end);
	unsigned long long total_swaps = 0, swaps = 0;
	int left, right, t,  n = ((end - start) + 1);

	int* temp = malloc(sizeof(int) * n);

	for(left = start, right = middle + 1, t = 0; t < n; t++) {
		if(left == middle + 1) {
			temp[t] = a[right++];
		}
		else if(right == end + 1) {
			temp[t] = a[left++];
			total_swaps += swaps;

		}
		else if(a[right] < a[left]) {
			temp[t] = a[right++];
			swaps++;
		}
		else {
			temp[t] = a[left++];
			total_swaps += swaps;
		}

		
		//printf("SWAPS = %llu, TOTAL SWAPS = %llu\n", swaps, total_swaps);
	}

	for(int i = 0; i < n; i++) {
		a[start + i] = temp[i];
	}

	return total_swaps;
}