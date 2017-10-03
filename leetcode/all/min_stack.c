#include <stdlib.h>
#include <stdio.h>
#include <limits.h>


#define PARENT(i) (i - 1) / 2
#define LEFT(i) 2 * i + 1
#define RIGHT(i) 2 * i + 2


typedef struct Heap {
	int* a;
	int heapsize;
} Heap;


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

void heap_decrease_value(Heap* h, int i, int val) {
	h->a[i] = val;

	while(i > 0 && h->a[PARENT(i)] > h->a[i]) {
		exchange(h->a, i, PARENT(i));
		i = PARENT(i);
	}
}

int min_heapify(Heap* h, int i) {
	int l = LEFT(i);
	int r = RIGHT(i);

	int smallest = i;
	if(l < h->heapsize && h->a[l] < h->a[i])
		smallest = l;
	if(r < h->heapsize && h->a[r] < h->a[smallest])
		smallest = r;

	if(smallest != i) {
		exchange(h->a, i, smallest);
		return min_heapify(h, smallest);
	}

	return i;
}

void min_insert(Heap* h, int val) {
	h->heapsize++;
	h->a[h->heapsize - 1] = INT_MAX;
	heap_decrease_value(h, h->heapsize - 1, val);
}


int min_poll(Heap* h) {
	int min = h->a[0];
	h->a[0] = h->a[h->heapsize - 1];
	h->heapsize--;
	min_heapify(h, 0);
	return min;
}

void min_remove(Heap* h, int x) {
	int index = -1;
	for(int i = 0; i < h->heapsize; i++) {
		if(h->a[i] == x) {
			index = i;
			break;
		}
	}

	if(index == -1) {
		printf("Element doesnt exist\n");
		return;
	}

	exchange(h->a, index, h->heapsize - 1);
	h->heapsize--;

	int i = min_heapify(h, 0);
	printf("INDEX IS %d\n", i);
}


typedef struct {
	int* stack;
	Heap* heap;
    int max_size;
    int size;
} MinStack;

/** initialize your data structure here. */
MinStack* minStackCreate(int maxSize) {
	MinStack* min_stack = (MinStack *) malloc(sizeof(MinStack));

	min_stack->max_size = maxSize;
	min_stack->size = 0;

	min_stack->heap = (Heap *) malloc(sizeof(Heap));
    min_stack->heap->a = (int *) malloc(maxSize * sizeof(int));
    min_stack->heap->heapsize = 0;

    min_stack->stack = (int *) malloc(maxSize * sizeof(int));
    return min_stack;
}

void minStackPush(MinStack* obj, int x) {
	obj->stack[obj->size++] = x;
	min_insert(obj->heap, x);
}

void minStackPop(MinStack* obj) {
	int remove = obj->stack[--obj->size];
	min_remove(obj->heap, remove);
}

int minStackTop(MinStack* obj) {
	return obj->stack[obj->size - 1];
}

int minStackGetMin(MinStack* obj) {
	return peek(obj->heap);
}

void minStackFree(MinStack* obj) {
    // TODO not needed for the problem
}

/**
 * Your MinStack struct will be instantiated and called as such:
 * struct MinStack* obj = minStackCreate(maxSize);
 * minStackPush(obj, x);
 * minStackPop(obj);
 * int param_3 = minStackTop(obj);
 * int param_4 = minStackGetMin(obj);
 * minStackFree(obj);
 */