

class Solution {
    fun generateParenthesis(n: Int): List<String> {
        val combinations = ArrayList<String>()

        combinations(n, n, n, "", combinations)

        return combinations
    }

    fun combinations(n: Int, open: Int, close: Int, currentString: String, combinations: ArrayList<String>) {

        if(open == 0 && close == 0) {
            combinations.add(currentString)
            return
        }

        if(open > 0)
            combinations(n,  open - 1, close, "$currentString(", combinations)

        if(close > 0 && close > open)
            combinations(n, open, close - 1, "$currentString)", combinations)
    }
}
