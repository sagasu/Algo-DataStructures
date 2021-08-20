using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Valid_Sudoku
{
    [TestClass]
    public class Valid_Sudoku
    {
        [TestMethod]
        public void Test()
        {
            var t =
                new char[][]{
                    new char[]{'5', '3', '.', '.', '7', '.', '.', '.', '.'}
                ,new char[]{'6', '.', '.', '1', '9', '5', '.', '.', '.'}
                ,new char[]{'.', '9', '8', '.', '.', '.', '.', '6', '.'}
                ,new char[]{'8', '.', '.', '.', '6', '.', '.', '.', '3'}
                ,new char[]{'4', '.', '.', '8', '.', '3', '.', '.', '1'}
                ,new char[]{'7', '.', '.', '.', '2', '.', '.', '.', '6'}
                ,new char[]{'.', '6', '.', '.', '.', '.', '2', '8', '.'}
                ,new char[]{'.', '.', '.', '4', '1', '9', '.', '.', '5'}
                ,new char[]{'.', '.', '.', '.', '8', '.', '.', '7', '9'}
            };
            Assert.AreEqual(true, IsValidSudoku(t));
        }
        
        [TestMethod]
        public void Test2()
        {
            var t =
                new char[][]{
                    new char[]{ '8', '3', '.', '.', '7', '.', '.', '.', '.' }
                ,new char[]{ '6', '.', '.', '1', '9', '5', '.', '.', '.' }
                ,new char[]{ '.', '9', '8', '.', '.', '.', '.', '6', '.' }
                ,new char[]{ '8', '.', '.', '.', '6', '.', '.', '.', '3' }
                ,new char[]{ '4', '.', '.', '8', '.', '3', '.', '.', '1' }
                ,new char[]{ '7', '.', '.', '.', '2', '.', '.', '.', '6' }
                ,new char[]{ '.', '6', '.', '.', '.', '.', '2', '8', '.' }
                ,new char[]{ '.', '.', '.', '4', '1', '9', '.', '.', '5' }
                ,new char[]{ '.', '.', '.', '.', '8', '.', '.', '7', '9' }
            };
            Assert.AreEqual(false, IsValidSudoku(t));
        }
        
        [TestMethod]
        public void Test3()
        {
            var t =
                new char[][]{
                    new char[]{ '.', '.', '.', '.', '5', '.', '.', '1', '.' }
                ,new char[]{ '.', '4', '.', '3', '.', '.', '.', '.', '.' }
                ,new char[]{ '.', '.', '.', '.', '.', '3', '.', '.', '1' }
                ,new char[]{ '8', '.', '.', '.', '.', '.', '.', '2', '.' }
                ,new char[]{ '.', '.', '2', '.', '7', '.', '.', '.', '.' }
                ,new char[]{ '.', '1', '5', '.', '.', '.', '.', '.', '.' }
                ,new char[]{ '.', '.', '.', '.', '.', '2', '.', '.', '.' }
                ,new char[]{ '.', '2', '.', '9', '.', '.', '.', '.', '.' }
                ,new char[]{ '.', '.', '4', '.', '.', '.', '.', '.', '.' }
            };
            Assert.AreEqual(false, IsValidSudoku(t));
        }


        public bool IsValidSudoku(char[][] board)
        {
            foreach (var row in board)
            {
                var set = new HashSet<char>();
                if (row.Any(x => x != '.' && !set.Add(x))) return false;
            }

            for (var i = 0; i < 9; i++)
            {
                var set = new HashSet<char>();
                if (board.Any(x => x[i] != '.' && !set.Add(x[i]))) return false;
            }

            for (var rowIndex = 0; rowIndex < 3; rowIndex++)
            {
                for (var sectorIndex = 0; sectorIndex < 3; sectorIndex++)
                {
                    var set = new HashSet<char>();
                    for (var columnIndex = 0; columnIndex < 3; columnIndex++)
                    {
                        var row = board[columnIndex + rowIndex * 3];
                        
                            if (!((row[sectorIndex * 3] == '.' || set.Add(row[sectorIndex * 3])) &&
                                  (row[sectorIndex * 3 + 1] == '.' || set.Add(row[sectorIndex * 3 + 1])) &&
                                  (row[sectorIndex * 3 + 2] == '.' || set.Add(row[sectorIndex * 3 + 2]))))
                                return false;
                    }
                }
            }

            return true;
        }
    }
}
