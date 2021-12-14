



using day_4_part_1;

List<string> input = File.ReadAllLines(args[0]).ToList();

var numbers = input[0].Split(',').Select(x => int.Parse(x));

List<BingoBoard> bingoBoards = new();

for(int i = 2; i + BingoBoard.BINGO_SIZE <= input.Count; i+= BingoBoard.BINGO_SIZE + 1) 
{
    var bingoLines = input.GetRange(i, BingoBoard.BINGO_SIZE);
    bingoBoards.Add(Utils.ReadBingoBoard(bingoLines.ToArray()));
}

foreach(int number in numbers)
{
    foreach(BingoBoard board in bingoBoards)
    {
        var unmarkedSum = board.MarkNumber(number);
        if(unmarkedSum > 0)
        {
            Console.WriteLine(unmarkedSum * number);
            return;
        }
    }
}