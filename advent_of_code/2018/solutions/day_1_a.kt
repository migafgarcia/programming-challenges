import java.io.File

fun main(args: Array<String>) {

    var currentFrequency = 0

    File(args[0]).forEachLine { line ->
        currentFrequency += line.toInt()
    }

    println(currentFrequency)

}