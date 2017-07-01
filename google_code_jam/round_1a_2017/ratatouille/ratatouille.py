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

	bounds = [[tuple() for x in range(p)] for y in range(n)]

	for package in range(p):
		for ingredient in range(n):
			current = get_bounds(r[ingredient], q[ingredient][package])

			if current[0] <= current[1]:
				bounds[ingredient][package] = (current[0], current[1], False)

	# without binary search
	for bound in bounds[0]:
		if len(bound) == 0:
			continue
		flag = True
		for ingredient in range(1, n):
			inner_flag = False
			for package in range(p):
				if len(bounds[ingredient][package]) == 0 or bounds[ingredient][package][2]:
					continue
				if bounds_overlap(bound, bounds[ingredient][package]):
					inner_flag = True
					break
			if not inner_flag:
				flag = False
				break
		if flag:
			c += 1

	print(c)