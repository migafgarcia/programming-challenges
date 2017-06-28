import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.*;

public class MazeRunner {

    public static void main(String[] args) throws IOException {
        // For making the connections
        Map<Pair<Integer, Integer>, Node> nodes = new HashMap<>();

        Node start = null;
        Node goal = null;

        try (BufferedReader br = new BufferedReader(new FileReader("challenge.txt"))) {

            int row = 0, col = 0;

            for (String line; (line = br.readLine()) != null; ) {

                col = 0;

                for (char c : line.toCharArray()) {

                    if (c == ' ' || c == 'S' || c == 'm' || c == 'G') {

                        Node node = new Node(c, row, col);

                        addAndMakeConnections(nodes, node, row, col);

                        if (c == 'S')
                            start = node;
                        else if (c == 'G')
                            goal = node;
                    }

                    col++;
                }

                row++;
            }
        }

        long time = System.currentTimeMillis();

        dijkstra(nodes.values(), start);

        System.out.println("Time: " + (System.currentTimeMillis() - time) + "ms");

        Node current = goal;

        List<Node> path = new LinkedList<>();

        while (current != null) {
            path.add(0, current);
            current = current.getParent();
        }

        System.out.println(Arrays.toString(path.toArray()));
        System.out.println("Cost: " + goal.getDistance() + "HP");


    }

    private static void addAndMakeConnections(Map<Pair<Integer, Integer>, Node> nodes, Node node, int row, int col) {

        Node north = nodes.get(new Pair<>(row - 1, col));

        if (north != null) {
            north.addEdge(node);
            node.addEdge(north);
        }

        Node east = nodes.get(new Pair<>(row, col - 1));

        if (east != null) {
            east.addEdge(node);
            node.addEdge(east);
        }

        nodes.put(new Pair<>(row, col), node);
    }

    private static void dijkstra(Collection<Node> nodes, Node start) {

        PriorityQueue<Node> queue = new PriorityQueue<>();

        start.setDistance(0);

        queue.add(start);

        Node current;

        while ((current = queue.poll()) != null) {

            for (Node node : current.getEdges()) {
                int distance = current.getDistance() + (node.getC() == 'm' ? 11 : 1);

                if (distance < node.getDistance()) {
                    node.setDistance(distance);
                    node.setParent(current);
                    queue.add(node);
                }
            }
        }
    }
}

class Pair<X, Y> {
    private final X x;
    private final Y y;

    public Pair(X x, Y y) {
        this.x = x;
        this.y = y;
    }

    public X x() {
        return x;
    }

    public Y y() {
        return y;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        Pair<?, ?> pair = (Pair<?, ?>) o;

        if (x != null ? !x.equals(pair.x) : pair.x != null) return false;
        return y != null ? y.equals(pair.y) : pair.y == null;
    }

    @Override
    public int hashCode() {
        int result = x != null ? x.hashCode() : 0;
        result = 31 * result + (y != null ? y.hashCode() : 0);
        return result;
    }
}

class Node implements Comparable<Node> {

    private final char c;
    private final int row, col;
    private final List<Node> edges;
    private int distance;
    private Node parent;


    public Node(char c, int row, int col) {
        this.c = c;
        this.row = row;
        this.col = col;
        this.edges = new ArrayList<>();
        this.distance = Integer.MAX_VALUE;
    }

    public char getC() {
        return c;
    }

    public int getRow() {
        return row;
    }

    public int getCol() {
        return col;
    }

    public void addEdge(Node node) {
        edges.add(node);
    }

    public List<Node> getEdges() {
        return edges;
    }

    public int getDistance() {
        return distance;
    }

    public void setDistance(int distance) {
        this.distance = distance;
    }

    public Node getParent() {
        return parent;
    }

    public void setParent(Node parent) {
        this.parent = parent;
    }

    @Override
    public int compareTo(Node o) {
        return distance - o.getDistance();

    }

    @Override
    public String toString() {
        return (c == ' ' ? '_' : c) + "(" + row + "," + col + ")";
    }
}