
pub fn part1(input: &str) -> i32 {
    let mut current: i32 = 50;
    let mut result = 0;

    for line in input.lines() {
        let mut num : i32 = 0;

        // getting the direction
        let direction: i32 = if line.starts_with('L') { -1 } else { 1 };

        // parsing the number
        for c in (&line[1..]).chars() {
            num = num * 10 + c.to_digit(10).unwrap() as i32;
        }

        // update the current number
        current = (current + num * direction).rem_euclid(100);

        // current = (current + (num * direction)) % 100;
        //
        // if current < 0 {
        //     current += 100;
        // }

        // count the zeros
        if current == 0 {
            result += 1;
        }
    }

    result

}


pub fn part2(input: &str) -> i32 {
    let mut current: i32 = 50;
    let mut result = 0;

    for line in input.lines() {
        let mut num : i32 = 0;

        // getting the direction
        let direction: i32 = if line.starts_with('L') { -1 } else { 1 };

        // parsing the number
        for c in (&line[1..]).chars() {
            num = num * 10 + c.to_digit(10).unwrap() as i32;
        }

        let new_current = current + num * direction;

        // count the zeros
        result += new_current.abs().div_euclid(100);

        if (current > 0 && new_current < 0) || new_current == 0{
            result += 1;
        }

        // update the current number
        current = new_current.rem_euclid(100);

    }

    result

}
