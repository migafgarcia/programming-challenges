
fn count_adjacent(matrix: &Vec<Vec<char>>, r: usize, c: usize) -> i32 {

    let rows = matrix.len();
    let cols = matrix[r].len();
    let mut count = 0;

    for dr in -1_isize..=1 {
        for dc in -1_isize..=1 {
            if dr == 0 && dc == 0 {
                continue;
            }

            let nr: isize = r as isize + dr;
            let nc: isize = c as isize + dc;

            if nr >= 0 && nr < rows as isize && nc >= 0 && nc < cols as isize {
                if matrix[nr as usize][nc as usize] == '@' {
                    count += 1;
                }
            }
        }
    }
    count

}

pub fn part1(input: &str) -> i32 {
    let char_matrix: Vec<Vec<char>> = input
        .lines()
        .map(|line| line.chars().collect())
        .collect();
    let mut count = 0;

    for r in 0..char_matrix.len() {
        for c in 0..char_matrix[r].len() {
            if (char_matrix[r][c] == '@' && count_adjacent(&char_matrix, r, c) < 4) {
                count += 1;
            }
        }
    }

    count
}


fn count_adjacent_part2(matrix: &Vec<Vec<i32>>, round_n: i32, r: usize, c: usize) -> i32 {

    let rows = matrix.len();
    let cols = matrix[r].len();
    let mut count = 0;

    for dr in -1_isize..=1 {
        for dc in -1_isize..=1 {
            if dr == 0 && dc == 0 {
                continue; // skip the current cell
            }

            let nr: isize = r as isize + dr;
            let nc: isize = c as isize + dc;

            if nr >= 0 && nr < rows as isize && nc >= 0 && nc < cols as isize {
                if matrix[nr as usize][nc as usize] >= round_n {
                    count += 1;
                }
            }
        }
    }
    count

}


pub fn part2(input: &str) -> i32 {
    let mut char_matrix: Vec<Vec<i32>> = input
        .lines()
        .map(|line| line.chars().map(|x| if x == '@' { 0 } else  { -1 }).collect())
        .collect();

    let mut result = 0;
    let mut current_round = 0;

    loop {
        let mut count = 0;


        for r in 0..char_matrix.len() {
            for c in 0..char_matrix[r].len() {
                if char_matrix[r][c] >= current_round {
                    if count_adjacent_part2(&char_matrix, current_round, r, c) >= 4 {
                        char_matrix[r][c] = current_round + 1;
                    }
                    else {
                        count += 1;
                    }
                }
            }
        }

        current_round += 1;
        result += count;
        if count == 0 { break; }
    }
    result
}


#[cfg(test)]
mod day4_tests {
    use std::fs;
    use std::path::Path;
    use crate::global;
    use super::*;

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

    #[test]
    fn part1_sample() {
        let result = part1(SAMPLE_INPUT);
        assert_eq!(result, 13);
    }

    #[test]
    fn part1_puzzle() {
        let contents = fs::read_to_string(Path::new(global::INPUT_BASE_PATH).join("day4.txt")).unwrap();
        let result = part1(contents.as_str());
        assert_eq!(result, 1478);
    }

    #[test]
    fn part2_sample() {
        let result = part2(SAMPLE_INPUT);
        assert_eq!(result, 43);
    }

    #[test]
    fn part2_puzzle() {
        let contents = fs::read_to_string(Path::new(global::INPUT_BASE_PATH).join("day4.txt")).unwrap();
        let result = part2(contents.as_str());
        assert_eq!(result, 9120);
    }

}
