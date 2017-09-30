#!/bin/python

table = dict()

def climb(n):
    if table.has_key(n):
        return table[n]
        
    if n == 0:
        return 1
    if n < 0:
        return 0
    
    total = 0
    
    total += climb(n - 1)
    total += climb(n - 2)
    total += climb(n - 3)
    
    table[n] = total
    return total
    
    
s = int(raw_input().strip())
for a0 in xrange(s):
    n = int(raw_input().strip())
    print climb(n)
