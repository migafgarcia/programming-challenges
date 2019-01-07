import java.util.HashSet;

public class Solution {
    public ListNode getIntersectionNode(ListNode headA, ListNode headB) {
        HashSet<ListNode> nodes = new HashSet<>();

        ListNode current = headA;

        while(current != null) {
            nodes.add(current);
            current = current.next;
        }

        current = headB;

        while(current != null) {
            if(nodes.contains(current))
                return current;
            current = current.next;
        }

        return null;


    }
}