#include<stdio.h>
#include<stdlib.h>
#include<string.h>

void exchange(int* a, int i, int j) {
    int temp = a[i];    
    a[i] = a[j];
    a[j] = temp;
}

int factorial(int n) {
    int f = 1;
    for(int i = n; i > 0; i--)
        f *= i;
    return f;
}

void print_array(int* a, int size) {
    for(int i = 0; i < size; i++)
        printf("%d ", a[i]);
    printf("\n");
}

void permutations(int** perms, int* nums, int nums_size, int col, int row) {
    int n_perms = factorial(nums_size);
    printf("nums_size: %d, col: %d, row: %d, n_perms: %d\n", nums_size, col, row, n_perms);
    print_array(nums, nums_size);

    for(int i = 0; i < n_perms; i++) {

        int current_index = i * nums_size / n_perms;

        perms[i + row][col] = nums[current_index];
        
        if(i % (n_perms / nums_size) == 0 && nums_size - 1 > 0) {
            int* nums_cpy = malloc(nums_size * sizeof(int));
            memcpy(nums_cpy, nums, nums_size * sizeof(int));

            exchange(nums_cpy, current_index, nums_size - 1);

            permutations(perms, nums_cpy, nums_size - 1, col + 1, i + row);

            free(nums_cpy);
        }
    }
}

int** permute(int* nums, int nums_size, int* return_size) {
    
    int n_perms = factorial(nums_size);
    
    int** perms = (int**) malloc(n_perms * sizeof(int*));
    
    for(int i = 0; i < n_perms; i++)
        perms[i] = (int*) malloc(nums_size * sizeof(int));

    permutations(perms, nums, nums_size, 0, 0);

    for(int i = 0; i < n_perms; i++) {
        for(int j = 0; j < nums_size; j++)
            printf("%d ", perms[i][j]);
        printf("\n");
    }

    *return_size = n_perms;
    return perms;
}