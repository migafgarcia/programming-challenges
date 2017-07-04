import java.util.HashMap;
import java.util.Scanner;

public class Contacts {

    public static void main(String[] args) {
        Scanner in = new Scanner(System.in);
        int n = in.nextInt();
        TrieNode root = new TrieNode(' ');
        for(int a0 = 0; a0 < n; a0++){
            String op = in.next();
            String contact = in.next();

            if(op.equals("add")) {
                addWord(root, contact);
            }
            else if(op.equals("find")) {
                System.out.println(findWord(root, contact));
            }
        }
        System.out.println();
    }

    private static void addWord(TrieNode root, String word) {
        TrieNode current = root;
        for(char c : word.toCharArray()) {
            TrieNode next = current.getChildren().get(c);

            if(next != null) {
                next.incrementN();
                current = next;
            }
            else {
                next = new TrieNode(c);
                current.getChildren().put(c, next);
                current = next;
            }
        }
    }

    private static int findWord(TrieNode root, String word) {
        TrieNode current = root;

        for(char c : word.toCharArray()) {
            TrieNode next = current.getChildren().get(c);
            if(next == null)
                return 0;
            else
                current = next;
        }

        return current.getN();
    }
}

class TrieNode {
    private char c;
    private int n;
    private HashMap<Character, TrieNode> children;

    public TrieNode(char c) {
        this.c = c;
        n = 1;
        children = new HashMap<>();
    }

    public char getC() {
        return c;
    }

    public int incrementN() {
        return n++;
    }

    public int getN() {
        return n;
    }

    public HashMap<Character, TrieNode> getChildren() {
        return children;
    }
}
