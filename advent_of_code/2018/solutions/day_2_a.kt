import java.io.File

fun main(args: Array<String>) {

    val file = File(args[0])

    var twos = 0
    var threes = 0

    file.forEachLine { line ->
        val letters = line.countLetters()
        val twoTimes = letters.count { entry -> entry.value == 2 }
        val threeTimes = letters.count { entry -> entry.value == 3 }

        if (twoTimes > 0)
            twos += 1
        if (threeTimes > 0)
            threes += 1
    }

    println(twos * threes)
}

fun String.countLetters(): HashMap<Char, Int> {
    val letters = HashMap<Char, Int>()

    this.forEach { c ->
        letters.computeIfAbsent(c, { 0 })
        letters.computeIfPresent(c, { _, count -> count + 1 })
    }

    return letters
}

