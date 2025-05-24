using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Find_Words_Containing_Character;

public class Find_Words_Containing_Character
{
    public IList<int> FindWordsContaining(string[] words, char x) {

        var wcc = new List<int>();
        for(int i=0; i<words.Count(); i++){
            if(words[i].Contains(x)){
                wcc.Add(i);
            }
        }
        return wcc;
    }
}