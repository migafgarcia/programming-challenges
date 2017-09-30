#!/bin/python

max = 30

table = [0 for _ in range(max + 1)]
table[1] = 1

def fibonacci(n):
    if n == 0 or n == 1:
        return n
    
    for i in range(2, n + 1):
        table[i] = table[i - 1] + table[i - 2]
        
    return table[n]
        
        
    
n = int(raw_input())
print(fibonacci(n))