import kotlin.math.abs

class Solution {
    fun reverse(x: Int): Int {
        var result = 0
        var tmp = x
        var number = 0
        while (tmp != 0) {
            number = tmp % 10
            tmp /= 10
            if(abs(result) > Integer.MAX_VALUE / 10 || (abs(result) == Integer.MAX_VALUE / 10) && number > 7)
                return 0

            result = (result * 10) + number
        }


        return result

    }
}