use std::cmp::{max, min};

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


pub fn part2(input: &str) -> u64 {
    let mut result: u64 = 0;
    let n = 12;
    let mut v: Vec<u64> = vec![0; n + 1];
    for line in input.lines().map(|x| x.chars().rev()) {
        v.fill(0);
        for (i, c) in line.enumerate() {
            let current_digit = c.to_digit(10).unwrap() as u64;
            for size in (1..=min(n,i)).rev() {
                let current = current_digit * 10_u64.pow(size as u32) + v[size-1];
                v[size] = max(current, v[size]);
            }
            v[0] = max(v[0], current_digit);
        }
        result += v[n-1];
    }

    result
}


#[cfg(test)]
mod day3_tests {
    use std::fs;
    use std::path::Path;
    use crate::global;
    use super::*;

    static SAMPLE_INPUT: &str = "987654321111111
811111111111119
234234234234278
818181911112111";

    #[test]
    fn part1_sample() {
        let result = part1(SAMPLE_INPUT);
        assert_eq!(result, 357);
    }

    #[test]
    fn part1_puzzle() {
        let contents = fs::read_to_string(Path::new(global::INPUT_BASE_PATH).join("day3.txt")).unwrap();
        let result = part1(contents.as_str());
        assert_eq!(result, 17412);
    }

    #[test]
    fn part2_sample() {
        let result = part2(SAMPLE_INPUT);
        assert_eq!(result, 3121910778619);
    }

    #[test]
    fn part2_puzzle() {
        let contents = fs::read_to_string(Path::new(global::INPUT_BASE_PATH).join("day3.txt")).unwrap();
        let result = part2(contents.as_str());
        assert_eq!(result, 172681562473501);
    }

    #[test]
    fn part1_both_methods_produce_same_output() {
        let contents = fs::read_to_string(Path::new(global::INPUT_BASE_PATH).join("day3.txt")).unwrap();
        let result = part1(contents.as_str());
        let result_n2 = part1_n2(contents.as_str());
        assert_eq!(result, result_n2);
    }
}
