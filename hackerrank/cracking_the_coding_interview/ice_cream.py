#!/bin/python

t = int(raw_input().strip())
for a0 in xrange(t):
    money = int(raw_input().strip())
    n = int(raw_input().strip())
    costs = map(int, raw_input().strip().split(' '))
    
    table = dict()
    
    for i in range(n):
        if costs[i] in table:
            print table[costs[i]] + 1, i + 1
            break
        else:
            table[money - costs[i]] = i