// https://www.hackerrank.com/challenges/ctci-comparator-sorting/

class Checker implements Comparator<Player> {
    public int compare(Player p1, Player p2) {
        int score = p2.score - p1.score;
        return score != 0 ? score : p1.name.compareTo(p2.name);
    }
}