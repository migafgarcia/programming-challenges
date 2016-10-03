#include <stdlib.h>
#include <stdio.h>
#include <string.h>

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 * ---
 * Hint: You can use the debug stream to print initialTX and initialTY, if Thor seems not follow your orders.
 **/
int main()
{
    
    int light_x; // the X position of the light of power
    int light_y; // the Y position of the light of power
    int current_x; // Thor's starting X position
    int current_y; // Thor's starting Y position
    scanf("%d%d%d%d", &light_x, &light_y, &current_x, &current_y);

    // game loop
    while (1) {
        int remainingTurns; // The remaining amount of turns Thor can move. Do not remove this line.
        scanf("%d", &remainingTurns);
        
        if(light_x > current_x) { // Move east
            current_x++;
            if(light_y > current_y) { // Move south
                current_y++;
                printf("SE\n");
            }
            else if(light_y < current_y) { // Move north
                current_y--;
                printf("NE\n");
            }
            else {
                printf("E\n");
            }
                
        }
        else if(light_x < current_x) { // Move west
            current_x--;
            if(light_y > current_y) { // Move south
                current_y++;
                printf("SW\n");
            }
            else if(light_y < current_y) { // Move north
                current_y--;
                printf("NW\n");
            }
            else {
                printf("W\n");
            }
        }
        else {
            if(light_y > current_y) { // Move south
                current_y++;
                printf("S\n");
            }
            else if(light_y < current_y) { // Move north
                current_y--;
                printf("N\n");
            }
            else {
                printf("ERROR\n");
            }
        }
    }

    return 0;
}
