import sys
import math

# game loop
while 1:
    enemy_1 = raw_input() # name of enemy 1
    dist_1 = int(raw_input()) # distance to enemy 1
    enemy_2 = raw_input() # name of enemy 2
    dist_2 = int(raw_input()) # distance to enemy 2

    # Write an action using print
    # To debug: print >> sys.stderr, "Debug messages..."

    if dist_1 < dist_2:
        print enemy_1
    else:
        print enemy_2
