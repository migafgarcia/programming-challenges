// https://www.hackerrank.com/challenges/ctci-balanced-brackets

#include <math.h>
#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <assert.h>
#include <limits.h>
#include <stdbool.h>

#define SIZE 512000

bool is_balanced(char expression[]) {
	char stack[SIZE];
	int stack_size = 0;

	for(int i = 0; expression[i] != '\0'; i++) {
		char current = expression[i];

		if(current == '{' || current == '(' || current == '[')
			stack[stack_size++] = current;
		else {
			
			if(stack_size == 0)
				return false;

			char matching = stack[--stack_size];

			// this could all go in the same boolean expression
			if(current == '}' && matching == '{')
				continue;
			else if(current == ')' && matching == '(')
				continue;
			else if(current == ']' && matching == '[')
				continue;
			else
				return false;
		}


	}

	if(stack_size > 0)
		return false;
	else
		return true;

}

int main(){
	int t; 
	scanf("%d",&t);
	for(int a0 = 0; a0 < t; a0++) {
		char* expression = (char *)malloc(SIZE * sizeof(char));
		scanf("%s",expression);
		bool answer = is_balanced(expression);
		if(answer)
			printf("YES\n");
		else
			printf("NO\n");
	}
	return 0;
}