

pub fn part1(input: &str) -> i32 {
    let mut result = 0;

    for line in input.lines().map(|x| x.chars().rev()) {
        let mut previous_max_digit : Option<i32> = None;
        let mut current_max: Option<i32> = None;

        for c in line {
            let current = c.to_digit(10).unwrap() as i32;

            if previous_max_digit.is_none() {
                previous_max_digit = Some(current);
                continue;
            }

            let num = current * 10 + previous_max_digit.unwrap();

            if previous_max_digit.is_some_and(|x| current > x) {
                previous_max_digit = Some(current);
            }

            if current_max.is_none() {
                current_max = Some(num);
                continue;
            }
            else if current_max.is_some_and(|x| num > x) {
                current_max = Some(num);
            }


        }

        result += current_max.unwrap();

    }

    result

}

pub fn part1_n2(input: &str) -> i32 {
    let n = 2;

    let mut result = 0;

    for line in input.lines().map(|line| line.as_bytes()) {
        let mut max = 0;
        for i in 0..line.len() {
            let i_char = line[i] as char;
            let i_current = i_char.to_digit(10).unwrap() as i32;
            for j in i+1..line.len() {
                let j_char = line[j] as char;
                let j_current = j_char.to_digit(10).unwrap() as i32;

                let current_num = i_current * 10 + j_current;

                if current_num > max {
                    max = current_num;
                }
            }
        }

        result += max;

    }

    result
}


pub fn part2(input: &str) -> i32 {
    0
}
