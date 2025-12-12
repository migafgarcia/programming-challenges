use std::fs;
use std::path::Path;

mod day1;
mod day2;
mod day3;
mod day4;
mod global;

fn main() {
    static SAMPLE_INPUT: &str = "..@@.@@@@.
@@@.@.@.@@
@@@@@.@.@@
@.@@@@..@.
@@.@@@@.@@
.@@@@@@@.@
.@.@.@.@@@
@.@@@.@@@@
.@@@@@@@@.
@.@.@@@.@.";

    println!("{}", day4::part2(SAMPLE_INPUT));


    let contents = fs::read_to_string(Path::new(global::INPUT_BASE_PATH).join("day4.txt")).unwrap();


    println!("{}", day4::part2(contents.as_str()));
}
