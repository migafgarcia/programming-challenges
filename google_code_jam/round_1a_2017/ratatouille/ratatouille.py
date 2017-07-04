#! /usr/bin/python

# https://code.google.com/codejam/contest/5304486/dashboard

from __future__ import print_function
from __future__ import division
import math
from operator import itemgetter

def get_bounds(r, p):
	"""
		r -> recipe
		p -> quantity in package

	"""

	lower = (p * 10) / (r * 11)
	
	upper = (p * 10) / (r * 9)

	return (math.ceil(lower), math.floor(upper))

def bounds_overlap(b1, b2):
	return not (b2[1] < b1[0] or b1[1] < b2[0])

t = int(raw_input())

for case in range(t):
	print("Case #" + str(case + 1) + ": ", end = '')
	n, p = [int(x) for x in raw_input().split()]
	r = [int(x) for x in raw_input().split()]
	q = list()

	for _ in range(n):
		q.append([int(x) for x in raw_input().split()])

	c = 0

	bounds = [list() for y in range(n)]

	for package in range(p):
		for ingredient in range(n):
			current = get_bounds(r[ingredient], q[ingredient][package])

			if current[0] <= current[1]:
				bounds[ingredient].append((current[0], current[1]))

	used = [[False for x in range(len(bounds[y]))] for y in range(len(bounds))] 

	for bound in range(len(bounds[0])):
		to_use = [(0, bound)]
		for i in range(1, len(bounds)):
			for j in range(len(bounds[i])):
				if not used[i][j] and bounds_overlap(bounds[0][bound], bounds[i][j]):
					to_use.append((i,j))
					break
		if len(to_use) == n:
			c += 1
			for i in to_use:
				used[i[0]][i[1]] = True





	print(c)
