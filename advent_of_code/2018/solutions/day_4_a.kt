import java.io.File
import java.text.SimpleDateFormat
import java.util.*
import java.util.Calendar


fun main(args: Array<String>) {
    val regex = Regex("\\[(\\d{4}-\\d{2}-\\d{2} \\d{2}:\\d{2})] (.+)")
    val beginsShiftRegex = Regex("Guard #(\\d+) begins shift")
    val wakesUpRegex = Regex("wakes up")
    val fallsAsleepRegex = Regex("falls asleep")

    val FALLS_ASLEEP = -1
    val WAKES_UP = -2

    val dateFormat = SimpleDateFormat("yyyy-MM-dd HH:mm")

    val schedule = ArrayList<Pair<Date, Int>>()

    File(args[0]).forEachLine { line ->
        val results = regex.find(line)!!.groupValues

        var date = dateFormat.parse(results[1])


        val c = Calendar.getInstance()
        c.time = date
        c.add(Calendar.YEAR, 1000)
        date = c.time
        val action = results[2]

        schedule.add(when {
            action.matches(beginsShiftRegex) -> {
                Pair(date, beginsShiftRegex.find(action)!!.groupValues[1].toInt())
            }
            action.matches(wakesUpRegex) -> {
                Pair(date, WAKES_UP)
            }
            action.matches(fallsAsleepRegex) -> {
                Pair(date, FALLS_ASLEEP)
            }
            else -> throw Exception("Error reading line: $line")
        })
    }

    schedule.sortBy { (first) -> first }


    val map = HashMap<Int, ArrayList<Pair<Int, Int>>>()
    var currentId = -1
    var startSleep = -1L

    schedule.forEach { (first, second) ->
        val c = GregorianCalendar.getInstance()

        when (second) {
            WAKES_UP -> {
                c.time = Date(startSleep)
                val f = c.get(Calendar.MINUTE)
                c.time = Date(first.time)
                val s = c.get(Calendar.MINUTE)

                map[currentId]!!.add(Pair(f, s))
            }
            FALLS_ASLEEP -> startSleep = first.time
            else -> {
                currentId = second
                startSleep = -1L

                map.putIfAbsent(currentId, ArrayList())
            }
        }
    }

    val id = map.map { entry ->
        Pair(entry.key, entry.value.map { (first, second) ->
            (second - first)
        })


    }.maxBy { a -> a.second.sum() }!!.first
    val minuteMap = HashMap<Int, Int>()

    map[id]!!.forEach { (first, second) ->
        for (i in first until second) {
            minuteMap.computeIfAbsent(i, { 0 })
            minuteMap.computeIfPresent(i, { _, u -> u + 1 })
        }
    }

    val minute = minuteMap.maxBy { entry -> entry.value }!!.key

    println(id * minute)

}
