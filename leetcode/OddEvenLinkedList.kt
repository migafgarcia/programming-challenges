//class ListNode(var `val`: Int = 0) {
//    var next: ListNode? = null
//}

class Solution {
    fun oddEvenList(head: ListNode?): ListNode? {

        var oddHead: ListNode? = null
        var oddCurrent: ListNode? = null

        var evenHead: ListNode? = null
        var evenCurrent: ListNode? = null

        var current = head
        var odd = true

        while (current != null) {
            if(odd) {
                if(oddHead == null) {
                    oddHead = current
                    oddCurrent = oddHead
                }
                else if (oddCurrent != null) {
                    oddCurrent.next = current
                    oddCurrent = oddCurrent.next
                }
            }
            else {
                if(evenHead == null) {
                    evenHead = current
                    evenCurrent = evenHead
                }
                else if (evenCurrent != null) {
                    evenCurrent.next = current
                    evenCurrent = evenCurrent.next
                }
            }

            current = current.next
            odd = !odd
        }


        if (evenCurrent != null) {
            evenCurrent.next = null
        }
        if (oddCurrent != null) {
            oddCurrent.next = evenHead
        }

        return head

    }
}