import java.util.*

class Solution {

    fun threeSum(nums: IntArray): List<List<Int>> {
        val solution = HashSet<Triple<Int, Int, Int>>()
        
        for (i in IntRange(0, nums.lastIndex)) {
            val sols = twoSum(nums, IntRange(i + 1, nums.lastIndex), -nums[i])
            sols.forEach { pair ->
                val list = arrayListOf(pair.first, pair.second, nums[i]).sorted()
                solution.add(Triple(list[0], list[1], list[2]))
            }
        }

        return solution.map { it.toList() }
    }

    fun bruteForceThreeSum(nums: IntArray): List<List<Int>> {
        val solution = HashSet<Triple<Int, Int, Int>>()
        
        for (i in IntRange(0, nums.lastIndex)) {
            for (j in IntRange(i + 1, nums.lastIndex)) {
                for (k in IntRange(j + 1, nums.lastIndex)) {
                    if (nums[i] + nums[j] + nums[k] == 0) {
                        val list = arrayListOf(nums[i], nums[j], nums[k]).sorted()
                        solution.add(Triple(list[0], list[1], list[2]))
                    }
                }
            }
        }

        return solution.map { it.toList() }
    }

    fun twoSum(nums: IntArray, range: IntRange, target: Int): List<Pair<Int, Int>> {

        val solution = LinkedList<Pair<Int, Int>>()
        val map = HashMap<Int, Int>()

        for (i in range) {
            if (map.contains(nums[i])) {
                solution.add(Pair(nums[map.getValue(nums[i])], nums[i]))
            } else {
                map[target - nums[i]] = i
            }
        }

        return solution
    }
}
