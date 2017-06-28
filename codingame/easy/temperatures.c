#include <stdlib.h>
#include <stdio.h>
#include <string.h>

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
int main()
{
    int n; // the number of temperatures to analyse
    scanf("%d", &n); fgetc(stdin);
    char temps[257]; // the n temperatures expressed as integers ranging from -273 to 5526
    fgets(temps, 257, stdin); // the n temperatures expressed as integers ranging from -273 to 5526
    fprintf(stderr, "temps = %s\n", temps);
    char* token = strtok(temps, " ");
    int current = 0;
    while(token != NULL) {
        int n = atoi(token);
        if(current == 0) {
            current = n;   
        }
        else if(abs(n) < abs(current)) {
            current = n;   
        }
        else if(abs(n) == abs(current)) {
            if(n > current)
                current = n;
        }
        token = strtok(NULL, " ");
    }
    
    
    printf("%d\n", current);
    return 0;
}
