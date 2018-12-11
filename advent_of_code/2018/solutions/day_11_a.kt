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

    var cell = Triple(0,0,0)

    for(i in 0..N - 3) {
        for(j in 0..N - 3) {
            var sum = 0

            for(k in i until i+3)
                for(l in j until j+3)
                    sum += grid[k][l]

            if(sum > cell.third)
                cell = Triple(i,j,sum)
        }
    }

    println("${cell.first},${cell.second}")
}

fun powerLevel(x: Int, y: Int, serial: Int): Int = ((x + 10) * y + serial) * (x + 10) / 100 % 10 - 5
