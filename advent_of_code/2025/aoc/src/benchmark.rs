use std::fs;
use std::path::Path;
use divan::{Bencher, black_box};

mod day1;
mod day2;
mod day3;
mod global;

fn main() { divan::main(); }

#[divan::bench(
    args = [
        ("day1.txt", day1::part1 as fn(&str) -> i32),
        ("day1.txt", day1::part2 as fn(&str) -> i32),
        ("day3.txt", day3::part1 as fn(&str) -> i32),
        ("day3.txt", day3::part1_n2 as fn(&str) -> i32),
        // ("day3.txt", day3::part2 as fn(&str) -> i32),
    ]
)]
fn bench_all_i32(bencher: Bencher, (input_file, func): (&'static str, fn(&str) -> i32)) {
    let contents = fs::read_to_string(
        Path::new(global::INPUT_BASE_PATH).join(input_file)
    ).unwrap();

    bencher
        .bench(|| {
            func(black_box(contents.as_str()));
        });
}


#[divan::bench(
    args = [
        ("day2.txt", day2::part1 as fn(&str) -> u64),
        ("day2.txt", day2::part2 as fn(&str) -> u64),
    ]
)]
fn bench_all_u64(bencher: Bencher, (input_file, func): (&'static str, fn(&str) -> u64)) {
    let contents = fs::read_to_string(
        Path::new(global::INPUT_BASE_PATH).join(input_file)
    ).unwrap();

    bencher
        .bench(|| {
            func(black_box(contents.as_str()));
        });
}