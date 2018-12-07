import java.io.File
import java.util.*

data class Task(val id: Char, val incoming: ArrayList<Task>, val outgoing: ArrayList<Task>, var discovered: Boolean = false, var finished: Boolean = false, var executed: Boolean = false)

data class Worker(var currentTask: Task? = null, var timeLeft: Int = 0)


fun main(args: Array<String>) {
    val regex = Regex("Step ([A-Z]) must be finished before step ([A-Z]) can begin\\.")

    val nodes = HashMap<Char, Task>()
    val taskList = LinkedList<Task>()
    val workers = arrayOf(Worker(), Worker(), Worker(), Worker(), Worker())
    val sequence = generateSequence(0) { it + 1 }


    File(args[0]).forEachLine { line ->
        val results = regex.find(line)!!.groupValues
        val from = results[1][0]
        val to = results[2][0]

        nodes.computeIfAbsent(from, { t -> Task(t, ArrayList(), ArrayList()) })
        nodes.computeIfAbsent(to, { t -> Task(t, ArrayList(), ArrayList()) })

        nodes[to]?.let { nodes[from]!!.outgoing.add(it) }
        nodes[from]?.let { nodes[to]!!.incoming.add(it) }
    }

    nodes.values.sortedBy { it.id }.reversed().forEach { dfs(it, taskList) }

    for (time in sequence) {

        workers.filter { it.currentTask != null }.forEach { worker ->
            worker.timeLeft--

            if (worker.timeLeft == 0) {
                worker.currentTask!!.executed = true
                worker.currentTask = null
            }
        }

        val freeWorkers = workers.filter { it.currentTask == null }

        val availableTasks = taskList.filter { task -> task.incoming.none { task -> !task.executed } }

        availableTasks.zip(freeWorkers).forEach { (first, second) ->
            taskList.remove(first)
            second.currentTask = first
            second.timeLeft = taskTime(first.id)
        }


//        print("$time ")
//
//        workers.forEach {
//            if(it.currentTask == null)
//                print(". ")
//            else
//                print("${it.currentTask!!.id} ")
//        }
//
//        println()

        if (taskList.isEmpty() && workers.none { it.currentTask != null }) {
            println(time)
            break
        }
    }

}

fun dfs(task: Task, list: LinkedList<Task>) {
    if (task.finished)
        return
    if (task.discovered)
        throw Exception("Task $task already visited")

    task.discovered = true

    task.outgoing.sortedBy { it.id }.reversed().forEach { dfs(it, list) }

    task.finished = true

    list.addFirst(task)
}

fun taskTime(id: Char): Int = 60 + (id - 'A' + 1)
