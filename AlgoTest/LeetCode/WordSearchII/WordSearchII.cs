using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoTest.LeetCode.WordSearchII
{
    public class WordSearchII
    {
        public IList<string> FindWords(char[][] board, string[] words)
        {
            for (var row = 0; row < board.Length; row++)
            {
                for (var column = 0; column < board[row].Length; column++)
                {
                    for (var i = 0; i < words.Length; i++)
                    {
                        if (board[row][column] == words[i][0])
                        {
                            FindWord(board, row, column, words[i], 0,new List<string>{Hash(row,column)});
                        }
                    }
                    
                }
            }

            return foundWords.ToList();
        }

        private string Hash(int row, int column) => $"{row},{column}";

        private void FindWord(char[][] board, int row, int column, string word, int index, List<string> visited)
        {
            if (word.Length == index+1)
            {
                foundWords.Add(word);
                return;
            }

            if (row > 0 && board[row - 1][column] == word[index + 1] && !visited.Contains(Hash(row - 1, column)))
            {
                visited.Add(Hash(row-1, column));
                FindWord(board, row - 1, column, word, index + 1, visited);
                visited.RemoveAt(visited.Count-1);
            }

            if (row < board.Length - 1 && board[row + 1][column] == word[index + 1] && !visited.Contains(Hash(row + 1, column)))
            {
                visited.Add(Hash(row + 1, column));
                FindWord(board, row + 1, column, word, index + 1, visited);
                visited.RemoveAt(visited.Count - 1);
            }

            if (column < board[0].Length - 1 && board[row][column + 1] == word[index + 1] && !visited.Contains(Hash(row, column+1)))
            {
                visited.Add(Hash(row, column+1));
                FindWord(board, row, column + 1, word, index + 1, visited);
                visited.RemoveAt(visited.Count - 1);
            }

            if (column > 0 && board[row][column - 1] == word[index + 1] && !visited.Contains(Hash(row, column-1)))
            {
                visited.Add(Hash(row, column-1));
                FindWord(board, row, column - 1, word, index + 1, visited);
                visited.RemoveAt(visited.Count - 1);
            }
        }


        HashSet<string> foundWords = new HashSet<string>();
    }
}
