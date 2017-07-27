# https://www.hackerrank.com/challenges/ctci-ransom-note

def ransom_note(magazine, ransom):
	m_dict = dict()

	for i in magazine:
		m_dict[i] = m_dict.get(i, 0) + 1

	for i in ransom:
		if m_dict.get(i, 0) == 0:
			return False
		else:
			m_dict[i] = max(0, m_dict[i] - 1)

	return True

m, n = map(int, raw_input().strip().split(' '))
magazine = raw_input().strip().split(' ')
ransom = raw_input().strip().split(' ')
answer = ransom_note(magazine, ransom)
if(answer):
    print "Yes"
else:
    print "No"
    
 
