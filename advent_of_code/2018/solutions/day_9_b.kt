import java.io.File
import java.util.*



fun main(args: Array<String>) {

    val input = File(args[0]).readText().split(" ").mapNotNull { it.toIntOrNull() }

    assert(score(9, 25) == 32L)
    assert(score(10, 1618) == 8317L)
    assert(score(13, 7999) == 146373L)
    assert(score(17, 1104) == 2764L)
    assert(score(21, 6111) == 54718L)
    assert(score(30, 5807) == 37305L)

    println(score(input[0], input[1] * 100))
}

fun score(nPlayers: Int, lastMarble: Int): Long {

    val circle = LinkedList<Int>()
    val players = LongArray(nPlayers)

    circle.add(0)

    for (i in 1..lastMarble) {
        if (i % 23 == 0) {
            circle.rotate(7)
            players[i % nPlayers] = players[i % nPlayers] + circle.removeLast() + i
            circle.rotate(-1)
        } else {
            circle.rotate(-1)
            circle.addLast(i)
        }
    }

    return players.max()!!
}

private fun <E> LinkedList<E>.rotate(n: Int) {
    if(n > 0)
        repeat(n) {
            addFirst(removeLast())
        }
    else
        repeat(-n) {
            addLast(removeFirst())
        }
}




