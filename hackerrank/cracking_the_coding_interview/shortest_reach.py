#!/bin/python

class Graph:
    def __init__(self, n):
        self.n = n
        self.nodes = [[] for _ in range(n)]
        
    def connect(self, a, b):
        self.nodes[a].append(b)
        self.nodes[b].append(a)
        
    def find_all_distances(self, s):
        distances = [-1 for _ in range(n)]
        distances[s] = 0
        
        inbox = [s]
        outbox = []
        

        while len(inbox) > 0 or len(outbox) > 0:

            if len(outbox) == 0:
                while len(inbox) > 0:
                    outbox.append(inbox.pop())
            curr = outbox.pop()
            for i in self.nodes[curr]:
                if distances[i] == -1:
                    inbox.append(i)
                    distances[i] = distances[curr] + 6
                
            
        return distances
            
        

t = input()
for i in range(t):
    n,m = [int(x) for x in raw_input().split()]
    graph = Graph(n)
    for i in xrange(m):
        x,y = [int(x) for x in raw_input().split()]
        graph.connect(x-1,y-1) 
    s = input()
    distances = graph.find_all_distances(s-1)
    
    for d in distances:
        if d != 0:
            print d,
    print 
    
