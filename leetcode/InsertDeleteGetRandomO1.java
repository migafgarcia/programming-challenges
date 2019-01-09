
import java.util.ArrayList;
import java.util.Collections;
import java.util.HashMap;
import java.util.Random;

/**
 * Your RandomizedSet object will be instantiated and called as such:
 * RandomizedSet obj = new RandomizedSet();
 * boolean param_1 = obj.insert(val);
 * boolean param_2 = obj.remove(val);
 * int param_3 = obj.getRandom();
 */
class RandomizedSet {

    private Random random = new Random();
    private HashMap<Integer, Integer> values = new HashMap<>();
    private ArrayList<Integer> list = new ArrayList<>();
    private int lastInsertedIndex = -1;

    /**
     * Initialize your data structure here.
     */
    public RandomizedSet() {
    }

    /**
     * Inserts a value to the set. Returns true if the set did not already contain the specified element.
     */
    public boolean insert(int val) {
        if (values.containsKey(val))
            return false;
        values.put(val, ++lastInsertedIndex);
        if (lastInsertedIndex < list.size())
            list.set(lastInsertedIndex, val);
        else
            list.add(val);
        return true;
    }

    /**
     * Removes a value from the set. Returns true if the set contained the specified element.
     */
    public boolean remove(int val) {
        if (!values.containsKey(val))
            return false;

        int index = values.remove(val);
        int lastInsertedValue = list.get(lastInsertedIndex);
        Collections.swap(list, index, lastInsertedIndex);
        lastInsertedIndex--;
        values.computeIfPresent(lastInsertedValue, (key, value) -> index);
        return true;
    }

    /**
     * Get a random element from the set.
     */
    public int getRandom() {
        return list.get(random.nextInt(lastInsertedIndex + 1));
    }
}

