#include <stdlib.h>
#include <stdio.h>
#include <string.h>



void print_bit(int bit, int count) {
    fprintf(stderr, "Printing bit %d. Count = %d.\n", bit, count);
    if(bit == 1)
        printf("0 ");
    else
        printf("00 ");
        
    for(int i = 0; i < count; i++) {
        printf("0");
    }
    
}

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
int main()
{
    char MESSAGE[101];
    fgets(MESSAGE, 101, stdin);
    char* bits = (char*) malloc(9);

    // Write an action using printf(). DON'T FORGET THE TRAILING \n
    // To debug: fprintf(stderr, "Debug messages...\n");
    int current_bit = 0;
    int current_count = 0;
    int i = 0;
    while(MESSAGE[i] != '\n') {
        fprintf(stderr, "MESSAGE[%d] = %c\n", i, MESSAGE[i]);
        for(int j = 6; j >= 0; j--) {
            int bit = MESSAGE[i] >> j & 1;
            fprintf(stderr, "%d = %d\n", i, bit);
            if(current_bit == bit) {
                current_count++;
            }
            else if(current_count != 0){
                print_bit(current_bit, current_count);
                printf(" ");
                current_bit = bit;
                current_count = 1;
            }
            else {
                current_bit = bit;
                current_count = 1;
            }
            
        }
        
        
        i++;
        
    }
    print_bit(current_bit, current_count);

    return 0;
}
