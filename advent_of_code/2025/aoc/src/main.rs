mod day1;

use std::fs;

fn main() {
    let s = "L68
L30
R48
L5
R60
L55
L1
L99
R14
L82";

    assert_eq!(day1::day1part1(s), 3);

    let contents = fs::read_to_string(r"input.txt").unwrap();

    let result_part1 = day1::day1part1(contents.as_str());

    println!("{}", result_part1);

    assert_eq!(day1::day1part2(s), 6);

    let result_part2 = day1::day1part2(contents.as_str());

    println!("{}", result_part2);
}
