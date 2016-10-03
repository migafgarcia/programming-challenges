import java.util.ArrayList;
import java.util.Scanner;

/**
 * Don't let the machines win. You are humanity's last hope...
 **/
class Player {

    public static void main(String args[]) {
        Scanner in = new Scanner(System.in);
        int width = in.nextInt(); // the number of cells on the X axis
        int height = in.nextInt(); // the number of cells on the Y axis
        in.nextLine();

        ArrayList<Node> nodes = new ArrayList(width * height);

        Node[] currentVerticals = new Node[width]; // stores the last top node on all columns
        Node currentHorizontal; // stores the last left node on the current line
        
        String[] lines = new String[height];

        for (int y = 0; y < height; y++) {
            currentHorizontal = null;
            lines[y] = in.nextLine(); // width characters, each either 0 or .
            for (int x = 0; x< width; x++) {
               if(lines[y].charAt(x) == '0') {
                   Node node = new Node(x, y);
                   nodes.add(node);

                   if(currentVerticals[x] == null)
                       currentVerticals[x] = node;
                   else {
                       currentVerticals[x].setBottom(node);
                       currentVerticals[x] = node;
                   }

                   if(currentHorizontal == null)
                       currentHorizontal = node;
                   else {
                       currentHorizontal.setRight(node);
                       currentHorizontal = node;
                   }
               }
            }
        }

        for(Node node : nodes) {
            System.out.println(node.toString() + " " + node.rightToString() + " " + node.bottomToString());
        }

    }
}

class Node {

    private int x, y;
    private Node right;
    private Node bottom;

    public Node(int x, int y) {
        this.x = x;
        this.y = y;
    }

    public int getX() {
        return x;
    }

    public int getY() {
        return y;
    }

    public String toString() {
        return x + " " + y;
    }

    public String rightToString() {
        if(right == null)
            return "-1 -1";
        else
            return right.getX() + " " + right.getY();
    }

    public String bottomToString() {
        if(bottom == null)
            return "-1 -1";
        else
            return bottom.getX() + " " + bottom.getY();
    }

    public void setRight(Node right) {
        this.right = right;
    }

    public void setBottom(Node bottom) {
        this.bottom = bottom;
    }

}
