import java.io.File

fun main(args: Array<String>) {

    val file = File(args[0])

    val history = ArrayList<String>()

    file.forEachLine { line ->
        history.forEach { s ->
            val diff = stringDiff(s, line)
            if(diff.length == s.length - 1)
                println(diff)
        }
        history.add(line)
    }

}

fun stringDiff(s1: String, s2: String): String {

    if(s1.length != s2.length)
        throw IllegalArgumentException("Strings must have same size")

    val diff = StringBuilder()

    val itr1 = s1.iterator()
    val itr2 = s2.iterator()
    while(itr1.hasNext() && itr2.hasNext()) {
        val c1 = itr1.nextChar()
        val c2 = itr2.nextChar()
        if (c1 == c2)
            diff.append(c1)
    }

    return diff.toString()

}

