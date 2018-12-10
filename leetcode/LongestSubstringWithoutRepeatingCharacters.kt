

class Solution {
    fun lengthOfLongestSubstring(s: String): Int {

        var maxLength = 0
        val currentSubstring = HashMap<Char,Int>()

        var i = 0
        while(i < s.length) {
            if(currentSubstring.contains(s[i]) ) {
                i = currentSubstring.getOrDefault(s[i], 0) + 1
                currentSubstring.clear()
                continue
            }

            currentSubstring.put(s[i], i)
            maxLength = if(currentSubstring.size > maxLength) currentSubstring.size else maxLength

            i++
        }


        return maxLength
    }
}