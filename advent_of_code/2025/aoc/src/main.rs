use std::fs;
use std::path::Path;

mod day1;
mod day2;
mod day3;
mod global;

fn main() {
    let test_input = "987654321111111
811111111111119
234234234234278
818181911112111";



    // assert_eq!(day3::part1("89192"), 99);

    // assert_eq!(day3::part1(test_input), 357);

    // assert_eq!(day3::part1("2394435233234444443212426444434324334444445645433344444344424164444243544324645633244244434434344683"), 98);

    let contents = fs::read_to_string(Path::new(global::INPUT_BASE_PATH).join("day3.txt")).unwrap();
    //
    // for line in contents.lines() {
    //     let result = day3::part1(line);
    //     let result_n2 = day3::part1_n2(line);
    //
    //     if result != result_n2 {
    //         println!("{}", line);
    //     }
    //
    // }

    // let result_part1 = day3::part1(contents.as_str());

    // assert_eq!(result_part1, 17412);

    // assert_eq!(result_part1, 357);
    //
    assert_eq!(day3::part2(test_input), 3121910778619);
    //
    let result_part2 = day3::part2(contents.as_str());
    //
    println!("{}", result_part2);
}
