using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day_4_part_1
{

    internal class BingoBoard
    {
        public static int BINGO_SIZE = 5;
        readonly List<int>[] rows = new List<int>[BINGO_SIZE];
        readonly List<int>[] cols = new List<int>[BINGO_SIZE];

        public bool Solved { get; private set; } = false;
        public int UnmarkedSumByColumn { get; private set; } = 0;
        public int UnmarkedSumByRow { get; private set; } = 0;

        public BingoBoard(List<int>[] rows, List<int>[] cols, int unmarkedSum)
        {
            this.rows = rows;
            this.cols = cols;
            this.UnmarkedSumByColumn = unmarkedSum;
            this.UnmarkedSumByRow = unmarkedSum;
        }

        public int MarkNumber(int number)
        {

            for(int i = 0; i < BINGO_SIZE; i++)
            {

                var nItemsRemoved = rows[i].RemoveAll(x => x == number);
                UnmarkedSumByRow -= number * nItemsRemoved; 
                if (rows[i].Count == 0)
                {
                    Solved = true;
                    return UnmarkedSumByRow;
                }

                nItemsRemoved = cols[i].RemoveAll(x => x == number);
                UnmarkedSumByColumn -= number * nItemsRemoved;

                if (cols[i].Count == 0)
                {
                    Solved = true;
                    return UnmarkedSumByColumn;
                }

            }
            return 0;
        }

    }
}
