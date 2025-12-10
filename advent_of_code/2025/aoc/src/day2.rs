use nom::{IResult, Parser};
use nom::multi::separated_list0;
use nom::bytes::complete::{tag};
use nom::character::complete::digit1;
use nom::combinator::{map_res, recognize};
use nom::sequence::separated_pair;

fn num_len(n: u64) -> u32 {
    (n as f32).log10().floor() as u32 + 1
}

fn input_parser(s: &str) -> IResult<&str, Vec<(u64, u64)>> {
    separated_list0(tag(","), range_parser).parse(s)
}

fn range_parser(s: &str) -> IResult<&str, (u64, u64)> {
    separated_pair(digit_parser, tag("-"), digit_parser).parse(s)
}

fn digit_parser(s: &str) -> IResult<&str, u64> {
    map_res(recognize(digit1), str::parse).parse(s)
}

pub fn part1(s: &str) -> u64 {

    let (_, ranges) = input_parser(s).unwrap();
    let mut result: u64 = 0;

    for (from, to) in ranges {
        for num in from..=to {

            let len = num_len(num);

            // check if number is divisible by 2
            if len % 2 != 0 {
                continue;
            }

            let half_len = len / 2;

            let first_half = num / 10_u64.pow(half_len);
            let second_half = num % 10_u64.pow(half_len);

            if first_half == second_half {
                result += num;
            }
        }
    }
    result
}


pub fn part2(s: &str) -> u64 {

    let (_, ranges) = input_parser(s).unwrap();
    let mut result: u64 = 0;

    for (from, to) in ranges {
        'num: for num in from..=to {

            let len = num_len(num);

            'parts: for n_parts in 2..=len {

                // check if number is divisible by 2
                if len % n_parts != 0 {
                    continue;
                }

                let part_size = len / n_parts;
                let mut remaining_num = num;

                let mut previous_part :Option<u64> = None;

                while remaining_num > 0 {
                    let current_part = remaining_num % 10_u64.pow(part_size);
                    remaining_num = remaining_num / 10_u64.pow(part_size);

                    if previous_part.is_some_and(|x| x != current_part) {
                        continue 'parts;
                    }

                    previous_part = Some(current_part);
                }

                result += num;
                continue 'num;
            }

        }
    }
    result

}


#[cfg(test)]
mod day2_tests {
    use std::fs;
    use std::path::Path;
    use crate::global;
    use super::*;

    static SAMPLE_INPUT: &str = "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124";

    #[test]
    fn part1_sample() {
        let result = part1(SAMPLE_INPUT);
        assert_eq!(result, 1227775554);
    }

    #[test]
    fn part1_puzzle() {
        let contents = fs::read_to_string(Path::new(global::INPUT_BASE_PATH).join("day2.txt")).unwrap();
        let result = part1(contents.as_str());
        assert_eq!(result, 23701357374);
    }

    #[test]
    fn part2_sample() {
        let result = part2(SAMPLE_INPUT);
        assert_eq!(result, 4174379265);
    }

    #[test]
    fn part2_puzzle() {
        let contents = fs::read_to_string(Path::new(global::INPUT_BASE_PATH).join("day2.txt")).unwrap();
        let result = part2(contents.as_str());
        assert_eq!(result, 34284458938);
    }
}