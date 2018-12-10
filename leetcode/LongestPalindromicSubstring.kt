class Solution {
    fun longestPalindrome(s: String): String {

        val table = HashSet<String>()

        for(size in s.length downTo 1) {
            (0..s.length - size)
                    .asSequence()
                    .map { s.substring(it, it + size) }
                    .forEach {
                        if(it.isPalindrome(table)) return it
                    }
        }

        return ""
    }

    private fun String.isPalindrome(table: HashSet<String>): Boolean {
        if(length <= 1 || table.contains(this))
            return true

        val palindrome = (0..this.length/2).none { this[it] != this[this.length - it - 1] }

        if(palindrome)
            (0..length/2)
                    .map { substring(it, length - it) }
                    .filterTo(table) { it.length > 1 }

        return palindrome
    }
}