import java.io.File
import java.lang.Math.abs

fun main(args: Array<String>) {

    val ids = generateSequence(1) { it + 1 }
    val points = ids.zip(File(args[0]).readLines().map { line ->
        val s = line.split(",").map { it.trim() }
        Pair(s[0].toInt(), s[1].toInt())
    }.asSequence()).toMap()

    val xMax = points.values.maxBy { it.first }!!.first
    val yMax = points.values.maxBy { it.second }!!.second

    var region = 0

    (0..xMax).forEach { x ->
        (0..yMax)
                .forEach { y ->
                    val sum = points.map { entry ->
                        manhattanDistance(Pair(x, y), entry.value)
                    }.sumBy { it }

                    if(sum < 10000)
                        region++
                }

    }

    println(region)
}

fun manhattanDistance(p1: Pair<Int, Int>, p2: Pair<Int, Int>): Int = abs(p1.first - p2.first) + abs(p1.second - p2.second)

