import java.io.File

fun main(args: Array<String>) {
    val N = 5000
    val regex = Regex(pattern = "#(\\d+) @ (\\d+),(\\d+): (\\d+)x(\\d+)")
    val matrix = Array(N) { IntArray(N)}

    File(args[0]).forEachLine { line ->
        val results = regex.find(line)!!.groupValues

        val id = results[1].toInt()
        val x = results[2].toInt()
        val y = results[3].toInt()
        val width = results[4].toInt()
        val height = results[5].toInt()

        for(i in x until x+width) {
            for(j in y until y+height) {
                when {
                    matrix[i][j] == 0 ->
                        matrix[i][j] = id
                    else ->
                        matrix[i][j] = -1
                }
            }
        }
    }

    val count = matrix.sumBy { it.count { it == -1 } }
    println(count)

}
