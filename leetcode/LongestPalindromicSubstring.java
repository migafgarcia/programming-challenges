import java.util.HashSet;

class Solution {
    public String longestPalindrome(String s) {

        HashSet<Pair<Integer, Integer>> palindromes = new HashSet<>();
        Pair<Integer, Integer> tmp = new Pair<>(0, 0);
        Pair<Integer, Integer> longestPalindrome = new Pair<>(0, 0);

        for (int palindromeSize = 1; palindromeSize <= s.length(); palindromeSize++) {
            for (int i = 0; i <= s.length() - palindromeSize; i++) {

                tmp.setBoth(i + 1, i + palindromeSize - 1);

                if (palindromes.contains(tmp) && s.charAt(i) == s.charAt(i + palindromeSize) || isPalindrome(s, i, i + palindromeSize)) {
                    Pair<Integer, Integer> pair = new Pair<>(i, i + palindromeSize);
                    palindromes.add(pair);
                    if (palindromeSize > longestPalindrome.getSecond() - longestPalindrome.getFirst()) {
                        longestPalindrome = pair;
                    }
                }
            }
        }

        return s.substring(longestPalindrome.getFirst(), longestPalindrome.getSecond());
    }

    private boolean isPalindrome(String s, int a, int b) {
        if (b == a + 2)
            return s.charAt(a) == s.charAt(a + 1);
        for (int i = 0; i < (b - a) / 2; i++)
            if (s.charAt(a + i) != s.charAt(b - i - 1))
                return false;
        return true;
    }
}

class Pair<A, B> {
    private A first;
    private B second;

    public Pair(A first, B second) {
        this.first = first;
        this.second = second;
    }

    public A getFirst() {
        return first;
    }

    public B getSecond() {
        return second;
    }

    public void setBoth(A first, B second) {
        this.first = first;
        this.second = second;
    }

    @Override
    public String toString() {
        return "Pair{" +
                "first=" + first +
                ", second=" + second +
                '}';
    }
}