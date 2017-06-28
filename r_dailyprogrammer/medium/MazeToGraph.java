import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.*;

public class MazeToGraph {

    public static void main(String[] args) throws IOException {
        // For making the connections
        Map<Pair<Integer, Integer>, Node> nodes = new HashMap<>();

        try (BufferedReader br = new BufferedReader(new FileReader("asd.txt"))) {

            int row = 0, col = 0;

            for (String line; (line = br.readLine()) != null; ) {

                col = 0;

                for (char c : line.toCharArray()) {

                    if (c != '#') {

                        Node node = new Node();

                        Node north = nodes.get(new Pair<>(row - 1, col));

                        if (north != null) {
                            north.edges.add(node);
                            node.edges.add(north);

                        }

                        Node east = nodes.get(new Pair<>(row, col - 1));

                        if (east != null) {
                            east.edges.add(node);
                            node.edges.add(east);

                        }

                        nodes.put(new Pair<>(row, col), node);

                    }

                    col++;
                }

                row++;
            }
        }

        nodes.values().removeIf(node -> node.edges.size() < 3);

        System.out.println("n = " + nodes.values().size());

    }
}

class Pair<X, Y> {
    private final X x;
    private final Y y;

    Pair(X x, Y y) {
        this.x = x;
        this.y = y;
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

class Node {

    final List<Node> edges;

    Node() {
        this.edges = new ArrayList<>();
    }
}