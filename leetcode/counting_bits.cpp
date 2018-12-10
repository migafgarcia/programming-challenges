class Solution {
public:
    vector<int> countBits(int num) {
        vector<int> result;
        result.resize(num + 1);
        
        for(int i = 0; i <= num; i++) {
            int mod = i % 2;
            int div = i / 2;
            
            result[i] = mod + result[div];
        }
        
        return result;
    }
};