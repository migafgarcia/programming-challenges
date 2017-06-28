#! /usr/bin/python

# https://code.google.com/codejam/contest/5304486/dashboard

from __future__ import print_function

t = int(raw_input())

for case in range(t):
	print("Case #" + str(case + 1) + ":")
	letters = list()
	dim = raw_input().split()
	r = int(dim[0])
	c = int(dim[1])

	m = [[0 for x in range(c)] for y in range(r)] 

	for i in range(r):
		line = list(raw_input())
		for j in range(c):
			m[i][j] = line[j]
			if line[j] != '?':
				letters.append((line[j], (i, j)))

	for l in letters:
		row = l[1][0]
		col = l[1][1]
		for i in range(0, row):
			if m[i][col] != '?':
				break
			else:
				m[i][col] = l[0]

	for l in letters:
		row = l[1][0]
		col = l[1][1]
		for i in range(row + 1, r):
			if m[i][col] != '?':
				break
			else:
				m[i][col] = l[0]
	
	previous = None
	for i in range(r):
		for j in range(c):
			if m[i][j] != '?':
				previous = m[i][j]
			elif previous is not None:
				m[i][j] = previous
		previous = None

	for i in reversed(range(r)):
		for j in reversed(range(c)):
			if m[i][j] != '?':
				previous = m[i][j]
			elif previous is not None:
				m[i][j] = previous
		previous = None
	

	for i in range(r):
		for j in range(c):
			print(m[i][j], end='')
		print()




