// https://www.hackerrank.jom/challenges/ctci-connected-cell-in-a-grid

#include <stdio.h>
#include <stdlib.h>

#define IN_BOUNDS(i, j, n, m) i >= 0 && i < n && j >= 0 && j < m

typedef struct Pair {
	int i, j;
} Pair;


int main() {
    int n; 
    scanf("%d",&n);
    int m; 
    scanf("%d",&m);
    int grid[n][m];
    int visited[n][m];
    Pair* stack = (Pair *) malloc(sizeof(Pair) * m * n);
    int stack_size = 0;
    int largest_cluster = 0;

    for(int i = 0; i < n; i++) {
       for(int j = 0; j < m; j++) {
          scanf("%d",&grid[i][j]);
          visited[i][j] = 0;
       }
    }
    
    for(int i = 0; i < n; i++) {
       for(int j = 0; j < m; j++) {
          if(grid[i][j] > 0 && visited[i][j] == 0) {

          	int current_size = 0;
          	
          	stack[stack_size].i = i;
			stack[stack_size].j = j;
			visited[i][j] = 1;
			stack_size++;

  			while(stack_size > 0) {
				//printf("stack_size = %d\n", stack_size);

  				current_size++;
  				stack_size--;
  				int curr_i = stack[stack_size].i;
  				int curr_j = stack[stack_size].j;

  				//printf("current_size = %d, curr_i = %d, curr_j = %d\n", current_size, curr_i, curr_j);
  				
  				if(IN_BOUNDS(curr_i - 1, curr_j - 1, n, m) && grid[curr_i - 1][curr_j - 1] > 0 && visited[curr_i - 1][curr_j - 1] == 0) {
  					visited[curr_i - 1][curr_j - 1] = 1;
	  				stack[stack_size].i = curr_i - 1;
	  				stack[stack_size].j = curr_j - 1;
	  				stack_size++;
	          	}

	  			if(IN_BOUNDS(curr_i - 1, curr_j, n, m) && grid[curr_i - 1][curr_j] > 0 && visited[curr_i - 1][curr_j] == 0) {
	  				visited[curr_i - 1][curr_j] = 1;
	  				stack[stack_size].i = curr_i - 1;
	  				stack[stack_size].j = curr_j;
	  				stack_size++;
	  			}

	  			if(IN_BOUNDS(curr_i - 1, curr_j + 1, n, m) && grid[curr_i - 1][curr_j + 1] > 0 && visited[curr_i - 1][curr_j + 1] == 0) {
	  				visited[curr_i - 1][curr_j + 1] = 1;
	  				stack[stack_size].i = curr_i - 1;
	  				stack[stack_size].j = curr_j + 1;
	  				stack_size++;
	  			}

	  			if(IN_BOUNDS(curr_i, curr_j - 1, n, m) && grid[curr_i][curr_j - 1] > 0 && visited[curr_i][curr_j - 1] == 0) {
	  				visited[curr_i][curr_j - 1] = 1;
	  				stack[stack_size].i = curr_i;
	  				stack[stack_size].j = curr_j - 1;
	  				stack_size++;
	  			}

	  			if(IN_BOUNDS(curr_i, curr_j + 1, n, m) && grid[curr_i][curr_j + 1] > 0 && visited[curr_i][curr_j + 1] == 0) {
	  				visited[curr_i][curr_j + 1] = 1;
	  				stack[stack_size].i = curr_i;
	  				stack[stack_size].j = curr_j + 1;
	  				stack_size++;
	  			}

	  			if(IN_BOUNDS(curr_i + 1, curr_j - 1, n, m) && grid[curr_i + 1][curr_j - 1] > 0 && visited[curr_i + 1][curr_j - 1] == 0) {
	  				visited[curr_i + 1][curr_j - 1] = 1;
	  				stack[stack_size].i = curr_i + 1;
	  				stack[stack_size].j = curr_j - 1;
	  				stack_size++;
	  			}

	  			else if(IN_BOUNDS(curr_i + 1, curr_j, n, m) && grid[curr_i + 1][curr_j] > 0 && visited[curr_i + 1][curr_j] == 0) {
	  				visited[curr_i + 1][curr_j] = 1;
	  				stack[stack_size].i = curr_i + 1;
	  				stack[stack_size].j = curr_j;
	  				stack_size++;
	  			}

	  			if(IN_BOUNDS(curr_i + 1, curr_j + 1, n, m) && grid[curr_i + 1][curr_j + 1] > 0 && visited[curr_i + 1][curr_j + 1] == 0) {
	  				visited[curr_i + 1][curr_j + 1] = 1;
	  				stack[stack_size].i = curr_i + 1;
	  				stack[stack_size].j = curr_j + 1;
	  				stack_size++;
	  			}

  			}

  			if(current_size > largest_cluster)
  				largest_cluster = current_size;
          }


		

       }
    }

  	printf("%d\n", largest_cluster);

    return 0;
}



