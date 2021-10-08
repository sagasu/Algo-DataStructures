using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Implement_Trie__Prefix_Tree_
{
    class Trie
    {

        TrieNode root;
        public Trie()
        {
            root = new TrieNode();
        }
        public void Insert(string word)
        {
            var n = word.Length;
            TrieNode curNode = root;
            for (int i = 0; i < n; i++)
            {
                var index = word[i] - 'a';
                if (curNode.nodes[index] == null)
                {
                    curNode.nodes[index] = new TrieNode();
                }
                curNode = curNode.nodes[index];

                if (i == n - 1)
                {
                    curNode.isWord = true;
                }
            }
        }
        public bool Search(string word)
        {
            var n = word.Length;
            TrieNode curNode = root;
            for (int i = 0; i < n; i++)
            {
                var index = word[i] - 'a';
                if (curNode.nodes[index] == null)
                {
                    return false;
                }
                curNode = curNode.nodes[index];
            }
            return curNode.isWord;
        }
        public bool StartsWith(string prefix)
        {
            var n = prefix.Length;
            TrieNode curNode = root;
            for (int i = 0; i < n; i++)
            {
                var index = prefix[i] - 'a';
                if (curNode.nodes[index] == null)
                {
                    return false;
                }
                curNode = curNode.nodes[index];
            }
            return true;
        }
    }

    class TrieNode
    {
        public TrieNode[] nodes;
        public bool isWord;

        public TrieNode()
        {
            nodes = new TrieNode[26];
            isWord = false;
        }
    }
}
