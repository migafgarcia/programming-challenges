// Link: https://www.codingame.com/games/puzzles/?puzzleId=2

#include <stdlib.h>
#include <stdio.h>
#include <string.h>

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
int main()
{
    int road; // the length of the road before the gap.
    scanf("%d", &road);
    int gap; // the length of the gap.
    scanf("%d", &gap);
    int platform; // the length of the landing platform.
    scanf("%d", &platform);

    // game loop
    while (1) {
        
        
        int speed; // the motorbike's speed.
        scanf("%d", &speed);
        int x; // the position on the road of the motorbike.
        scanf("%d", &x);
        if(x + speed >= road + gap && x < road)
            printf("JUMP\n");
        else if(speed < gap + 1 && x < road)
            printf("SPEED\n");
        else if(speed > gap + 1 && x < road)
            printf("SLOW\n");
        
        else if(x >= road + gap) {
            printf("SLOW\n");
        }
        else {
            printf("WAIT\n");
        }

    }

    return 0;
}