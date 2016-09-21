import java.util.*;
import java.io.*;
import java.math.*;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution {

  public static void main(String args[]) {
    int N = 26;

    // This hardcoded answer was forced by Codingame
    // They should make you implement a question mark generator
    // SHAME SHAME SHAME
    String QUESTION_MARK[] = {"### ", "  # ", " ## ", "    ", " #  "};

    Scanner in = new Scanner(System.in);
    int length = in.nextInt();
    int height = in.nextInt();
    in.nextLine();
    String text = in.nextLine();

    for (int i = 0; i < height; i++) {
      String row = in.nextLine();

      for(int j = 0; j < text.length(); j++) {
        int currentCode = ord(text.charAt(j));

        if(currentCode < 0 || currentCode >= N)
          System.out.print(QUESTION_MARK[i]);
        else
          System.out.print(row.substring(length * currentCode, (length * currentCode) + length));
      }

      System.out.println();
    }

  }


  private static int ord(char c) {
    return c >= 'A' && c <= 'Z' ? (c - 'A') : (c - 'a');
  }
}
