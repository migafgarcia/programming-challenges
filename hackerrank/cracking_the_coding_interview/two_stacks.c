// https://www.hackerrank.com/challenges/ctci-queue-using-two-stacks

#include <stdio.h>
#include <string.h>
#include <math.h>
#include <stdlib.h>

#define SIZE 512000

int main() {

    int q;

    scanf("%d", &q);

    int inbox[SIZE];
    int inbox_i = 0;

    int outbox[SIZE];
    int outbox_i = 0;

    for(int i = 0; i < q; i++) {

    	printf("INBOX_I = %d, OUTBOX_I = %d\n", inbox_i, outbox_i);
    	int action;

    	scanf("%d", &action);

    	if(action == 1) {
    		int n;
    		scanf("%d", &n);

    		inbox[inbox_i++] = n;

    		printf("ADDED = %d\n", n);

    	}
    	else if(action == 2) {
    		if(outbox_i == 0) 
    			while(inbox_i > 0)
    				outbox[outbox_i++] = inbox[--inbox_i];
    		
			outbox_i--;

    	}
    	else {
    		if(outbox_i == 0) 
    			while(inbox_i > 0)
    				outbox[outbox_i++] = inbox[--inbox_i];
    		printf("%d\n", outbox[outbox_i - 1]);

    	}

    }
    return 0;
}
 
