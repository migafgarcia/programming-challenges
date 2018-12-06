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

    val areas = HashMap<Int, Int>()

    val infinites = HashSet<Int>()

    points.forEach { k, _ -> areas.put(k, 0) }

    for (x in 0..xMax) {
        for (y in 0..yMax) {

            val infinite = x == 0 || y == 0 || x == xMax || y == yMax

            val distances = points.map { entry ->
                Pair(entry.key, manhattanDistance(Pair(x, y), entry.value))
            }.sortedBy { entry -> entry.second }

            if(distances[0].second < distances[1].second) {
                if(infinite) infinites.add(distances[0].first)
                areas.computeIfPresent(distances[0].first, { _, v -> v + 1 })
            }
        }
    }

    infinites.forEach { areas.remove(it) }

    println(areas.maxBy { it.value }!!.value)

}

fun manhattanDistance(p1: Pair<Int, Int>, p2: Pair<Int, Int>): Int = abs(p1.first - p2.first) + abs(p1.second - p2.second)

