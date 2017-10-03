class Solution(object):
    def twoSum(self, nums, target):
        """
        :type nums: List[int]
        :type target: int
        :rtype: List[int]
        """
        table = dict()
    
        for i in range(len(nums)):
            if nums[i] in table:
                return table[nums[i]], i
            else:
                table[target - nums[i]] = i
