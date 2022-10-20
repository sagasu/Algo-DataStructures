public class Solution {
    public IList<string> TopKFrequent(string[] words, int k) {
        
       var dict = new  Dictionary<string,int>();
        
        for(var i = 0; words.Length > i ; i++){
            
            if(dict.ContainsKey(words[i])){
                dict[ words[i] ] = dict[ words[i] ] + 1;
            }else{
                dict.Add( words[i], 1);
            }
 
        }
        
      var di =  dict.OrderByDescending(i => i.Value).ThenBy(i =>i.Key).Take(k); 
        
        IList<string> result = new  List<string>();
        
        foreach(KeyValuePair<string,int> d in di)
                 result.Add(d.Key);
        
        return result;
         
    }
}