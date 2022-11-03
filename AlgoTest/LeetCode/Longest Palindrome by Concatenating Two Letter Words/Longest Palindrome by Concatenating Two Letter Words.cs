public class Solution {
    public int LongestPalindrome(string[] words) {
        Dictionary<string,int> map = new();
        HashSet<string> visited = new();

        foreach(string word in words){
            if(!map.ContainsKey(word))
                map.Add(word, 0);
            map[word]++;
        }

        int counter = 0, extra = 0;
        foreach(string key in map.Keys){
            if(visited.Contains(key)) continue;
            if(key[0] == key[1]){
                counter += map[key]%2 == 0 ? map[key]*2 : map[key]*2-2;
                if(map[key]%2 != 0) extra = 2;
            } else{
                string key2 = new String(key.Reverse().ToArray());
                if(map.ContainsKey(key2)){
                    counter += Math.Min(map[key], map[key2])*4;
                    visited.Add(key2);
                }
            }
        }
        return counter+extra;
    }
}