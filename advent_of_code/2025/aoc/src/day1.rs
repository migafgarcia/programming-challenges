



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

#[cfg(test)]
mod day1_tests {
    use std::fs;
    use std::path::Path;
    use crate::global;
    use super::*;

    static SAMPLE_INPUT: &str = "L68
L30
R48
L5
R60
L55
L1
L99
R14
L82";


    #[test]
    fn part1_sample() {
        let result = part1(SAMPLE_INPUT);
        assert_eq!(result, 3);
    }

    #[test]
    fn part1_puzzle() {
        let contents = fs::read_to_string(Path::new(global::INPUT_BASE_PATH).join("day1.txt")).unwrap();
        let result = part1(contents.as_str());
        assert_eq!(result, 1081);
    }

    #[test]
    fn part2_sample() {
        let result = part2(SAMPLE_INPUT);
        assert_eq!(result, 6);
    }

    #[test]
    fn part2_puzzle() {
        let contents = fs::read_to_string(Path::new(global::INPUT_BASE_PATH).join("day1.txt")).unwrap();
        let result = part2(contents.as_str());
        assert_eq!(result, 6689);
    }
}