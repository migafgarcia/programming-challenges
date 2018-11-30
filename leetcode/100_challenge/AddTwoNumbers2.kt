
class Solution {

    fun addTwoNumbers(l1: ListNode?, l2: ListNode?): ListNode? {

        val p1 = listToNumber(l1)
        val p2 = listToNumber(l2)
        val p3 = Pair(p1.first + p2.first, Math.max(p1.second, p2.second))

        println("v1: $p1")
        println("v2: $p2")
        println("v3: $p3")

        return numberToList(p3)
    }

    fun listToNumber(list: ListNode?): Pair<Long, Long> {
        var cursor = list
        var v1: Long = 0
        var v1Size: Long = 1

        while(cursor != null) {
            v1 += cursor.`val` * v1Size
            v1Size *= 10
            cursor = cursor.next
        }

        return Pair(v1, v1Size)
    }

    fun numberToList(number: Pair<Long, Long>): ListNode? {
        var list: ListNode? = null
        var tempNumber = number.first
        var tempSize = number.second

        while(tempNumber != 0L) {
            val curr = tempNumber / tempSize
            tempNumber -= curr * tempSize
            tempSize /= 10
            if(curr == 0L)
                continue
            val n = ListNode(curr.toInt())
            if(list == null)
                list = n
            else {
                n.next = list
                list = n
            }
        }
        return list
    }

}