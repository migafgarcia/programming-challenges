class Solution {
public:
    int singleNumber(vector<int>& nums) {
        int total = 0;
        for(int elem : nums)
            total ^= elem;
        return total;
    }
};