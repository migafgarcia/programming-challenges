// https://www.hackerrank.com/challenges/ctci-making-anagrams
import java.util.Scanner;

public class MakingAnagrams {
    public static int numberNeeded(String first, String second) {

        int[] chars = new int[26];

        for(int i = 0; i < first.length(); i++)
            chars[first.charAt(i) - 'a']++;

        for(int i = 0; i < second.length(); i++)
            chars[second.charAt(i) - 'a']--;

        int a = 0;
        for (int i : chars)
           a += Math.abs(i);

        return a;
    }

    public static void main(String[] args) {
        Scanner in = new Scanner(System.in);
        String a = in.next();
        String b = in.next();
        System.out.println(numberNeeded(a, b));
    }
}
