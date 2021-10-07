using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.WordSearch
{
    [TestClass]
    public class WordSearch
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

        int n;
        int m;
        public bool Exist(char[][] board, string word)
        {
            n = board.Length;
            if (n == 0) return false;
            m = board[0].Length;

            var isVisited = new bool[n, m];

            var result = false;
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < m; j++)
                {
                    result = DFS(board, isVisited, i, j, word, 0);
                    if (result) return true;
                }
            }

            return result;
        }

        private bool DFS(char[][] board, bool[,] isVisited, int x, int y, string word, int wordIndex)
        {
            if (wordIndex == word.Length) return true;
            
            if (x >= n || x < 0 || y >= m || y < 0) return false;
            
            if (word[wordIndex] != board[x][y]) return false;
            
            if (isVisited[x, y]) return false;

            isVisited[x, y] = true;

            var directions = new (int, int)[] { (0, 1), (0, -1), (1, 0), (-1, 0) };

            foreach (var direction in directions)
            {
                var oneResult = DFS(board, isVisited, x + direction.Item1, y + direction.Item2, word, wordIndex + 1);
                if (oneResult) return true;
            }

            isVisited[x, y] = false;

            return false;
        }

    }
}
