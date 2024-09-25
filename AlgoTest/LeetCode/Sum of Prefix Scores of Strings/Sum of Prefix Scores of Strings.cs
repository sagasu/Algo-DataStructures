namespace AlgoTest.LeetCode.Sum_of_Prefix_Scores_of_Strings;

public class Sum_of_Prefix_Scores_of_Strings
{
    public int[] SumPrefixScores(string[] words) {
        TrieNode trie = new TrieNode();        
        
        foreach(string s in words)
            trie.Add(s);
        
        int[] res = new int[words.Length];        
        for(int i = 0; i < words.Length; i++)
            res[i] = trie.Search(words[i]);
        
        return res;
    }
    
    private class TrieNode{
        TrieNode[] children = new TrieNode[26];
        int counter = 0;
        
        public void Add(string s){
            TrieNode curr = this;
            foreach(char ch in s){
                if(curr.children[ch-'a'] == null)
                    curr.children[ch-'a'] = new TrieNode();
                curr = curr.children[ch-'a'];
                curr.counter++;
            }
        }
        
        public int Search(string s){
            int sum = 0;
            TrieNode curr = this;
            foreach(char ch in s){
                curr = curr.children[ch-'a'];
                sum += curr.counter;
            }
            return sum;
        }
    }
}