import java.util.*;

class Solution {
    public List<List<String>> groupAnagrams(String[] strs) {

        HashMap<String, LinkedList<String>> groups = new HashMap<>();

        for (String str : strs) {
            char[] arr = str.toCharArray();
            
            Arrays.sort(arr);

            String key = new String(arr);

            if(!groups.containsKey(key))
                groups.put(key, new LinkedList<>());

            groups.get(key).add(str);
        }

        return new ArrayList<>(groups.values());

    }
}