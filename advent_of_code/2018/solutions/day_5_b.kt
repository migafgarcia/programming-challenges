import java.io.File



fun main(args: Array<String>) {

    val input = File(args[0]).readText().trim()

    val removals = HashMap<Char,Int>()

    for(c in 'a'..'z') {
        var current = input
        var i = 0
        while (i < current.length) {
            if(current[i].equals(c, true)) {
                current = current.removeRange(i..i)
                i = maxOf(i - 1, 0)
            }
            else if (i < current.length - 1 && ((current[i].isLowerCase() && current[i + 1].isUpperCase()) || (current[i].isUpperCase() && current[i + 1].isLowerCase()))
                    && current[i].equals(current[i + 1], true)) {

                current = current.removeRange(i..i + 1)

                i = maxOf(i - 1, 0)
            } else
                i++

        }

        removals.put(c, current.length)

    }

    println(removals.minBy { entry -> entry.value })
}
