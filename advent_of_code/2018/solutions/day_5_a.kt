import java.io.File



fun main(args: Array<String>) {

    var input = File(args[0]).readText().trim()

    var i = 0
    while(i < input.length - 1) {
        if(((input[i].isLowerCase() && input[i+1].isUpperCase()) || (input[i].isUpperCase() && input[i+1].isLowerCase()))
                && input[i].equals(input[i+1], true)) {

            input = input.removeRange(i..i+1)

            i = maxOf(i - 1, 0)
        }
        else
            i++

    }

    println(input.length)
    
}
