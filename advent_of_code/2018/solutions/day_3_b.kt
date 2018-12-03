import java.io.File

data class Square(val id: Int, val x: Int, val y: Int, val width: Int, val height: Int)

data class MutablePair<X,Y>(var first: X, var second: Y)

fun main(args: Array<String>) {
    val regex = Regex(pattern = "#(\\d+) @ (\\d+),(\\d+): (\\d+)x(\\d+)")

    val squares = ArrayList<MutablePair<Square,Boolean>>()

    File(args[0]).forEachLine { line ->
        val results = regex.find(line)!!.groupValues

        val id = results[1].toInt()
        val x = results[2].toInt()
        val y = results[3].toInt()
        val width = results[4].toInt()
        val height = results[5].toInt()

        val square = Square(id, x, y, width, height)
        var intersect = false

        squares.forEach { s ->
            if(intersect(s.first, square)) {
                intersect = true
                s.second = true
            }
        }
        squares.add(MutablePair(square, intersect))
    }

    println(squares.find { p -> !p.second })

}

fun intersect(a: Square, b: Square): Boolean {
    return (a.x < (b.x + b.width)) &&
            ((a.x + a.width) > b.x) &&
            (a.y < (b.y + b.height)) &&
            ((a.y + a.height) > b.y)
}
