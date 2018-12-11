fun main(args: Array<String>) {

    assert(powerLevel(3, 5, 8) == 4)
    assert(powerLevel(122, 79, 57) == -5)
    assert(powerLevel(217, 196, 39) == 0)
    assert(powerLevel(101, 153, 71) == 4)

    val serial = 6548
    val N = 300

    val grid = Array(N) { IntArray(N) }

    for(i in 0 until N)
        for(j in 0 until N)
            grid[i][j] = powerLevel(i, j, serial)

    var cell = IntArray(4)


    for(n in 1..300) {
        for (i in 0..N - n) {
            for (j in 0..N - n) {
                var sum = 0

                for (k in i until i + n)
                    for (l in j until j + n)
                        sum += grid[k][l]

                if (sum > cell[3]) {
                    cell = intArrayOf(i, j, n, sum)
                }
            }
        }
    }

    println("${cell[0]},${cell[1]},${cell[2]}")

    // 233,250,12
}

fun powerLevel(x: Int, y: Int, serial: Int): Int = ((x + 10) * y + serial) * (x + 10) / 100 % 10 - 5
