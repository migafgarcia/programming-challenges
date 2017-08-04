// https://www.hackerrank.com/challenges/ctci-find-the-running-median

#include <math.h>
#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <assert.h>
#include <limits.h>
#include <stdbool.h>

#define MIN 0
#define MAX 10000

#define PARENT(i) (i - 1) / 2
#define LEFT(i) 2 * i + 1
#define RIGHT(i) 2 * i + 2

typedef struct Heap {
	int* a;
	int heapsize;
} Heap;

// Helper functions
void print_array(int* a, int size);
void exchange(int* a, int i, int j);

// Heap related functions
void print_heap(Heap* h);
int peek(Heap* h);

void min_insert(Heap* h, int val);
void max_insert(Heap* h, int val);

int min_poll(Heap* h);
int max_poll(Heap* h);

void min_heapify(Heap* h, int i);
void max_heapify(Heap* h, int i);

void heap_decrease_value(Heap* h, int i, int val);
void heap_increase_value(Heap* h, int i, int val);

// Challenge related functions
void add_number(Heap* hmax, Heap* hmin, int n);

int main() {

 	int n;

    scanf("%d",&n);

	// below
    Heap* hmax = (Heap *) malloc(sizeof(Heap));
    hmax->a = (int *) malloc(n * sizeof(int));
    hmax->heapsize = 0;

    // above
    Heap* hmin = (Heap *) malloc(sizeof(Heap));
    hmin->a = (int *) malloc(n * sizeof(int));
    hmin->heapsize = 0;

 	for(int a_i = 0; a_i < n; a_i++) {

 		// print_heap(hmax);
 		// print_heap(hmin);

 		int current;
   		scanf("%d",&current);

   		add_number(hmax, hmin, current);

   		if(hmin->heapsize == hmax->heapsize) {
   			printf("%.1f\n", (float) (peek(hmin) + peek(hmax)) / 2);
   		}
   		else {
   			printf("%.1f\n", (float) peek(hmax));
   		}
	}

    return 0;
}

void print_array(int* a, int size) {
	for(int i = 0; i < size; i++) {
		printf("%d ", a[i]);
	}
	printf("\n");
}


void exchange(int* a, int i, int j) {
	int temp = a[i];	
	a[i] = a[j];
	a[j] = temp;
}

void print_heap(Heap* h) {
	printf("==\nArray: ");
	print_array(h->a, h->heapsize);
	printf("Heapsize: %d\n==\n", h->heapsize);
}

int peek(Heap* h) {
	return h->a[0];
}

void min_insert(Heap* h, int val) {
	h->heapsize++;
	h->a[h->heapsize - 1] = MAX + 1;
	heap_decrease_value(h, h->heapsize - 1, val);
}

void max_insert(Heap* h, int val) {
	h->heapsize++;
	h->a[h->heapsize - 1] = MIN - 1;
	heap_increase_value(h, h->heapsize - 1, val);
}

int min_poll(Heap* h) {
	int min = h->a[0];
	h->a[0] = h->a[h->heapsize - 1];
	h->heapsize--;
	min_heapify(h, 0);
	return min;
}

int max_poll(Heap* h) {
	int max = h->a[0];
	h->a[0] = h->a[h->heapsize - 1];
	h->heapsize--;
	max_heapify(h, 0);
	return max;
}

void min_heapify(Heap* h, int i) {
	int l = LEFT(i);
	int r = RIGHT(i);

	int smallest = i;
	if(l < h->heapsize && h->a[l] < h->a[i])
		smallest = l;
	if(r < h->heapsize && h->a[r] < h->a[smallest])
		smallest = r;

	if(smallest != i) {
		exchange(h->a, i, smallest);
		min_heapify(h, smallest);
	}
}

void max_heapify(Heap* h, int i) {
	int l = LEFT(i);
	int r = RIGHT(i);

	int largest = i;
	if(l < h->heapsize && h->a[l] > h->a[i])
		largest = l;
	if(r < h->heapsize && h->a[r] > h->a[largest])
		largest = r;

	if(largest != i) {
		exchange(h->a, i, largest);
		max_heapify(h, largest);
	}
}

void heap_decrease_value(Heap* h, int i, int val) {
	h->a[i] = val;

	while(i > 0 && h->a[PARENT(i)] > h->a[i]) {
		exchange(h->a, i, PARENT(i));
		i = PARENT(i);
	}
}

void heap_increase_value(Heap* h, int i, int val) {
	h->a[i] = val;

	while(i > 0 && h->a[PARENT(i)] < h->a[i]) {
		exchange(h->a, i, PARENT(i));
		i = PARENT(i);
	}
}

void add_number(Heap* hmax, Heap* hmin, int n) {

	if(hmax->heapsize == hmin->heapsize) {
		if(hmin->heapsize > 0 && n > peek(hmin)) {
			max_insert(hmax, min_poll(hmin));
			min_insert(hmin, n);
		}
		else
			max_insert(hmax, n);
	}
	else {
		if(n < peek(hmax)) {
			min_insert(hmin, max_poll(hmax));
			max_insert(hmax, n);
		}
		else
			min_insert(hmin, n);
	}

}