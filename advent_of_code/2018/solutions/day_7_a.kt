import java.io.File
import java.util.*

data class Node(val id: Char, val children: ArrayList<Node>, var discovered: Boolean = false, var finished: Boolean = false)

fun main(args: Array<String>) {
    val regex = Regex("Step ([A-Z]) must be finished before step ([A-Z]) can begin\\.")

    val nodes = HashMap<Char, Node>()

    File(args[0]).forEachLine { line ->
        val results = regex.find(line)!!.groupValues
        val from = results[1][0]
        val to = results[2][0]

        nodes.computeIfAbsent(from, { t -> Node(t, ArrayList()) })
        nodes.computeIfAbsent(to, { t -> Node(t, ArrayList()) })

        nodes[to]?.let { nodes[from]!!.children.add(it) }
    }

    val list = LinkedList<Node>()

    nodes.values.sortedBy { it.id }.reversed().forEach { dfs(it, list) }

    list.forEach { print(it.id) }

}

fun dfs(node: Node, list: LinkedList<Node>) {
    if(node.finished)
        return
    if(node.discovered)
        throw Exception("Node $node already visited")

    node.discovered = true

    node.children.sortedBy { it.id }.reversed().forEach { dfs(it, list) }

    node.finished = true

    list.addFirst(node)

}
