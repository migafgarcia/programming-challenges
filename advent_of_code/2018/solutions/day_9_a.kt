import java.io.File
import java.util.*

data class Player(var score: Int = 0)

fun main(args: Array<String>) {

    val input = File(args[0]).readText().split(" ").mapNotNull { it.toIntOrNull() }

    assert(score(10, 1618) == 8317)
    assert(score(13, 7999) == 146373)
    assert(score(17, 1104) == 2764)
    assert(score(21, 6111) == 54718)
    assert(score(30, 5807) == 37305)

    println(score(input[0], input[1]))
}

fun score(nPlayers: Int, lastMarble: Int): Int {

    val circle = LinkedList<Int>(listOf(0))
    val players = Array(nPlayers) { Player() }

    var currentPlayer = 0
    var currentMarblePos = 0

    for (i in 1..lastMarble) {
        if (i % 23 == 0) {
            currentMarblePos = (currentMarblePos + circle.size - 7) % circle.size
            players[currentPlayer].score += circle.removeAt(currentMarblePos) + i
        } else {
            val target = (currentMarblePos + 2) % (circle.size)

            currentMarblePos = if(target == 0) {
                circle.add(i)
                circle.size - 1
            } else {
                circle.add(target, i)
                target
            }
        }
        currentPlayer = (currentPlayer + 1) % nPlayers
    }

    return players.maxBy { it.score }!!.score
}
