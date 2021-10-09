using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoTest.LeetCode.WordSearchII
{
    public class WordSearchII
    {
        public List<string> FindWords(char[][] board, string[] words)
        {
            var root = BuildTrieFrom(words);
            var foundWords = new List<string>();
            for (var row = 0; row < board.Length; row++)
            for (var col = 0; col < board[0].Length; col++)
                Dfs(row, col, root);

            return foundWords;

            void Dfs(int row, int col, TrieNode node)
            {
                var letter = board[row][col];
                if (letter == '#' || node.Next[letter - 'a'] == null)
                    return;

                node = node.Next[letter - 'a'];
                if (node.Word != null)
                {
                    foundWords.Add(node.Word);
                    node.Word = null;
                }

                board[row][col] = '#';
                if (row > 0) Dfs(row - 1, col, node);
                if (col > 0) Dfs(row, col - 1, node);
                if (row < board.Length - 1) Dfs(row + 1, col, node);
                if (col < board[0].Length - 1) Dfs(row, col + 1, node);
                board[row][col] = letter;
            }
        }

        private static TrieNode BuildTrieFrom(IEnumerable<string> words)
        {
            var root = new TrieNode();
            foreach (var word in words)
                word.Aggregate(root, (node, c) => node.Next[c - 'a'] ??= new TrieNode())
                    .Word = word;
            return root;
        }

        public class TrieNode
        {
            public readonly TrieNode[] Next = new TrieNode[26];
            public string Word;
        }
    }
}
