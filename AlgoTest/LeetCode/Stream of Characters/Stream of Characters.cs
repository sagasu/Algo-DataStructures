using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoTest.LeetCode.Stream_of_Characters
{
    public class StreamChecker
    {

        public class TrieNode
        {
            public char val;
            public TrieNode[] children;
            public bool isWord;
            public TrieNode(char ch)
            {
                this.val = ch;
                this.children = new TrieNode[26];
            }
        }
        public class Trie
        {
            public TrieNode root;
            public Trie()
            {
                root = new TrieNode('_');
            }
            public void AddWord(string str)
            {
                var curroot = root;
                foreach (var t in str)
                {
                    var cur = t - 'a';
                    if (curroot.children[cur] == null) curroot.children[cur] = new TrieNode(t);
                    curroot = curroot.children[cur];
                }
                curroot.isWord = true;
            }
        }

        readonly StringBuilder sb = new StringBuilder();
        readonly Trie trie;

        public StreamChecker(string[] words)
        {
            trie = new Trie();
            foreach (var w in words)
            {
                trie.AddWord(new string(w.Reverse().ToArray()));
            }
        }

        public bool Query(char letter)
        {
            sb.Append(letter);
            var str = sb.ToString();
            var r = trie.root;
            for (var i = str.Length - 1; i >= 0; i--)
            {
                if (r.children[str[i] - 'a'] == null) return false;
                r = r.children[str[i] - 'a'];
                if (r.isWord) return true;
            }
            return false;
        }
    }

}
