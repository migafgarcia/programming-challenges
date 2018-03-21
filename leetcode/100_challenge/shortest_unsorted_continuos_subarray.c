#include<stdio.h>

int main(int argc, char** argv) {

}

int findUnsortedSubarray(int* nums, int size) {
    int global = 0;
	int current = -1;

    for(int i = 0; i  < size - 1; i++) {
    	if(current == -1) {
			if(nums[i] > nums[i + 1]) {
				current = 2;
			}
    	}

    	else {
			if(nums[i] > nums[i + 1]) {
				global = current;
				current = -1;
			}
			else {
				current++;
			}
    	}


		printf("%d\n", current);
    }
    
    
}