#!/bin/python

import sys

table = dict()

def make_change(coins, n):
    
    if table.has_key(len(coins)) and table[len(coins)].has_key(n):
        return table[len(coins)][n]
    if n == 0:
        return 1
    if n < 0:
        return 0
    
    total = 0      
    for i in range(len(coins)):
        change = make_change(coins[i:], n - coins[i])
        total += change

    if not table.has_key(len(coins)):
        table[len(coins)] = dict()
    table[len(coins)][n] = total
    
    return total

n,m = raw_input().strip().split(' ')
n,m = [int(n),int(m)]
coins = map(int,raw_input().strip().split(' '))
print make_change(coins, n) 
