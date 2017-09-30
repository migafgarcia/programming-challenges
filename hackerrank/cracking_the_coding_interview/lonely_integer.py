#!/bin/python

import sys

def lonely_integer(a):
    result = 0
    for n in a:
        result ^= n
    return result
    

n = int(raw_input().strip())
a = map(int,raw_input().strip().split(' '))
print lonely_integer(a)