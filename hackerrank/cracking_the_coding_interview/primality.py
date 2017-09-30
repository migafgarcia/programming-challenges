#!/bin/python

import math

def is_prime(n):
    if n <= 1:
        return False
    for i in range(2, int(math.sqrt(n)) + 1):
        if n % i == 0:
            return False
    return True

p = int(raw_input().strip())
for _ in xrange(p):
    n = int(raw_input().strip())
    if is_prime(n):
        print "Prime"
    else:
        print "Not prime"
    
    
