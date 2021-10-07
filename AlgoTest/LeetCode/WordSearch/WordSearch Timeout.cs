using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.WordSearch
{
    [TestClass]
    public class WordSearch_Timeout
    {
        [TestMethod]
        public void Test()
        {
            //var t = new char[][]
            //{
            //    new char[] {'A', 'B', 'C', 'E'},
            //    new char[] {'S', 'F', 'C', 'S'},
            //    new char[] {'A', 'D', 'E', 'E'}
            //};

            //Assert.IsTrue(Exist(t, "ABCCED"));
            //Assert.IsTrue(Exist(t, "SEE"));
            //Assert.IsFalse(Exist(t, "ABCB"));

            //var t = new char[][]
            //{
            //    new char[] {'A', 'B'},
            //};
            //Assert.IsTrue(Exist(t, "AB"));
            

            var t = new char[][]
            {
                new char[] {'A', 'A'},
            };
            Assert.IsFalse(Exist(t, "AAA"));
        }

        [TestMethod]
        public void Test2()
        {
            var t = new char[][]
            {
                new char[] {'A', 'A', 'A', 'A', 'A', 'A'}, new char[] {'A', 'A', 'A', 'A', 'A', 'A'},
                new char[] {'A', 'A', 'A', 'A', 'A', 'A'}, new char[] {'A', 'A', 'A', 'A', 'A', 'A'},
                new char[] {'A', 'A', 'A', 'A', 'A', 'A'}, new char[] {'A', 'A', 'A', 'A', 'A', 'A'}
            };
            Assert.IsFalse(Exist(t,"AAAAAAAAAAAAAAB"));
        }

        public bool Exist(char[][] board, string word)
        {
            for (var row = 0; row < board.Length; row++)
            {
                for (var col = 0; col < board[row].Length; col++)
                {
                    if (board[row][col] == word[0] && Exist(board, word, row, col, 0,new List<string>{GetHash(row,col)}))
                        return true;
                }
            }

            return false;
        }

        private bool Exist(char[][] board, string word, int row, int col, int index, List<string> taken)
        {
            if (word.Length <= index + 1)
                return true;

            if (row > 0 && !taken.Any(x => GetHash(row - 1, col) == x) && board[row-1][col] == word[index + 1])
            {
                taken.Add(GetHash(row -1,col));
                if (Exist(board, word, row -1, col, index + 1, taken))
                    return true;
                taken.RemoveAt(taken.Count -1);
            }

            if (row < board.Length-1 && !taken.Any(x => GetHash(row + 1, col) == x) && board[row + 1][col] == word[index + 1])
            {
                taken.Add(GetHash(row + 1, col));
                if (Exist(board, word, row + 1, col, index + 1, taken))
                    return true;
                taken.RemoveAt(taken.Count - 1);
            }

            if (col > 0 && !taken.Any(x => GetHash(row, col - 1) == x) && board[row][col - 1] == word[index + 1])
            {
                taken.Add(GetHash(row, col - 1));
                if (Exist(board, word, row, col - 1, index + 1, taken))
                    return true;
                taken.RemoveAt(taken.Count - 1);
            }

            if (col < board[row].Length - 1 && !taken.Any(x => GetHash(row, col + 1) == x) && board[row][col + 1] == word[index + 1])
            {
                taken.Add(GetHash(row, col + 1));
                if (Exist(board, word, row, col + 1, index + 1, taken))
                    return true;
                taken.RemoveAt(taken.Count - 1);
            }

            return false;
        }

        private static string GetHash(int row, int col)
        {
            return $"{row}_{col}";
        }

    }
}
