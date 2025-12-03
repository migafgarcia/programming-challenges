mod day1;
mod day2;
mod global;

use std::fs;
use std::path::Path;

fn main() {
    let test_input = "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124";

    assert_eq!(day2::part1(test_input), 1227775554);

    let contents = fs::read_to_string(Path::new(global::INPUT_BASE_PATH).join("day2.txt")).unwrap();

    let result_part1 = day2::part1(contents.as_str());

    assert_eq!(result_part1, 23701357374);

    assert_eq!(day2::part2(test_input), 4174379265);

    let result_part2 = day2::part2(contents.as_str());

    println!("{}", result_part2);
}
