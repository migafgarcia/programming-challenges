
class Solution {

    fun addTwoNumbers(l1: ListNode?, l2: ListNode?): ListNode? {


        var carry = 0
        var l3: ListNode? = null

        var a = l1
        var b = l2
        var c: ListNode? = null

        while(a != null || b != null) {
            val v1 = a?.`val` ?: 0
            val v2 = b?.`val` ?: 0

            var curr = v1 + v2 + carry

            carry = curr / 10

            val n = ListNode(curr % 10)

            if(l3 == null)
                l3 = n

            if(c != null)
                c.next = n

            c = n

            if (a != null)
                a = a.next

            if (b != null)
                b = b.next
        }

        if(carry > 0) {
            val n = ListNode(carry)

            if(c != null)
                c.next = n
        }

        return l3

    }
}