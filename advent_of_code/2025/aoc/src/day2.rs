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
