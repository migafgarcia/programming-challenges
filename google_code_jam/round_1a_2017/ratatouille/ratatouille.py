#! /usr/bin/python

# https://code.google.com/codejam/contest/5304486/dashboard

from __future__ import print_function

t = int(raw_input())

for case in range(t):
	print("Case #" + str(case + 1) + ": ", end = '')
	n, p = [int(x) for x in raw_input().split()]
	r = [int(x) for x in raw_input().split()]
	q = list()

	for _ in range(n):
		q.append([int(x) for x in raw_input().split()])



	
	c = 0
	for package in range(p):
		# print('package = ', end = '')
		# print(package)
		servings = list()
		flag = False
		for ingredient in range(n):
			# print('ingredient = ', end = '')
			# print(ingredient)
			if ingredient == 0:
				for k in range(51):
					if q[ingredient][package] >= r[ingredient] * k * 0.9 and q[ingredient][package] <= r[ingredient] * k * 1.1:
						# print(k, end = '')
						# print(" servings")
						# print(r[ingredient] * k * 0.9, end = '')
						# print(" <= ", end = '')
						# print(q[ingredient][package], end = '')
						# print(" <= ", end = '')
						# print(r[ingredient] * k * 1.1)
						servings.append(k)
						flag = True
				if len(servings) == 0: break
			else:
				servings_flag = False
				for s in servings:
					if q[ingredient][package] >= r[ingredient] * s * 0.9 and q[ingredient][package] <= r[ingredient] * s * 1.1:
						# print(servings, end = '')
						# print(" servings")
						# print(r[ingredient] * s * 0.9, end = '')
						# print(" <= ", end = '')
						# print(q[ingredient][package], end = '')
						# print(" <= ", end = '')
						# print(r[ingredient] * s * 1.1)
						servings_flag = True
				flag = servings_flag
		if flag:
			c +=1



			

	print(c)