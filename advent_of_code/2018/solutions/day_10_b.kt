import java.io.File
import java.lang.Math.abs

data class Point(var position: Pair<Int, Int>, val velocity: Pair<Int, Int>)


fun main(args: Array<String>) {
    val regex = Regex("position=<([- \\d]+),([- \\d]+)> velocity=<([- \\d]+),([- \\d]+)>")

    val points = ArrayList<Point>(400)


    File(args[0]).forEachLine{ line ->

        val results = regex.find(line)!!.groupValues

        val x = results[1].trim().toInt()
        val y = results[2].trim().toInt()

        points.add(Point(Pair(x, y), Pair(results[3].trim().toInt(), results[4].trim().toInt())))

    }

    var lastDistance = Long.MAX_VALUE

    for(time in generateSequence(0) { it + 1 }) {

        val d = points.map { (position) ->
            points.map { (position1) -> manhattanDistance(position, position1)}.sum()
        }.sum()

        if(d > lastDistance) {
            println(time - 1)
            break
        }

        lastDistance = d

        points.forEach { it.position = Pair(it.position.first + it.velocity.first, it.position.second + it.velocity.second) }

    }
    
}

private fun printPoints(points: ArrayList<Point>) {
    val xMin = points.minBy { it.position.first }!!.position.first
    val yMin = points.minBy { it.position.second }!!.position.second

    val xMax = points.maxBy { it.position.first }!!.position.first
    val yMax = points.maxBy { it.position.second }!!.position.second

    val xSize = xMax - xMin + 1
    val ySize = yMax - yMin + 1
    val matrix = Array(xSize) { BooleanArray(ySize) }

    points.forEach { p ->
        matrix[p.position.first - xMin][p.position.second - yMin] = true
    }

    for (y in yMin..yMax) {
        for (x in xMin..xMax) {
            if (matrix[x - xMin][y - yMin])
                print('#')
            else
                print(' ')
        }
        println()
    }
}


fun manhattanDistance(p1: Pair<Int, Int>, p2: Pair<Int, Int>): Long = (abs(p1.first - p2.first) + abs(p1.second - p2.second)).toLong()