using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace day_4_part_1
{
    internal class Utils
    {
        public static BingoBoard ReadBingoBoard(string[] bingoLines)
        {
            List<int>[] byRow = new List<int>[5];
            List<int>[] byColumn = new List<int>[5];
            List<int> col = new();
            int unmarkedSum = 0;
            for (int i = 0; i < bingoLines.Length; i++)
            {

                var line = Regex.Split(bingoLines[i].Trim(), " +").Select(x => int.Parse(x.Trim())).ToArray();
                byRow[i] = line.ToList();
                for(int j = 0; j < line.Length; j++)
                {
                    if (byColumn[j] == null) byColumn[j] = new();
                    byColumn[j].Add(line[j]);
                    unmarkedSum += line[j];
                }
            }

            return new BingoBoard(byRow, byColumn, unmarkedSum);
        }

    }
}
