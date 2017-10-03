class Solution(object):
    def hammingDistance(self, x, y):
        """
        :type x: int
        :type y: int
        :rtype: int
        """
        z = x ^ y
        count = 0
        for i in range(32):
            if z & 1 == 1:
                count += 1
            z >>= 1
        return count