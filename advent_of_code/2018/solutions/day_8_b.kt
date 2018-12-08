import java.io.File
import java.util.*

data class Node(val children: ArrayList<Node>, val metadata: ArrayList<Int>)

fun main(args: Array<String>) {

    val inputItr = File(args[0]).readLines().first().split(" ").map { it.toInt() }.iterator()

    val nodes = LinkedList<Node>()

    val root = readInput(inputItr, nodes)

    println(root.value())

}

fun readInput(itr: Iterator<Int>, nodes: LinkedList<Node>): Node {
    val nChildren = itr.next()
    val nMetadata = itr.next()

    val node = Node(ArrayList(nChildren), ArrayList(nMetadata))

    repeat(nChildren) {
        node.children.add(readInput(itr, nodes))
    }

    repeat(nMetadata) {
        node.metadata.add(itr.next())
    }

    nodes.add(node)

    return node
}

fun Node.value(): Int {
    return if(children.isEmpty()) metadata.sum()
    else metadata.mapNotNull { children.getOrNull(it - 1) }.sumBy { it.value() }
}