import java.io.File

fun main(args: Array<String>) {

    var currentFrequency = 0
    val history = HashSet<Int>()
    val file = File(args[0])

    var bf = file.bufferedReader()
    var itr = bf.lines().iterator()

    while(true) {

        if(!itr.hasNext()) {
            bf.close()
            bf = file.bufferedReader()
            itr = bf.lines().iterator()
        }

        currentFrequency += itr.next().toInt()

        if(history.contains(currentFrequency)) {
            bf.close()
            println(currentFrequency)
            break
        }

        history.add(currentFrequency)
    }


}

