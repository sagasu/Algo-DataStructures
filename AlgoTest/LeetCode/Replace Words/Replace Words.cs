using System.Collections.Generic;

namespace AlgoTest.LeetCode.Replace_Words;

public class Replace_Words
{
    public string ReplaceWords(IList<string> dictionary, string sentence) {
        HashSet<string> set = new();
        List<string> ans = new();

        foreach(var word in dictionary)
            set.Add(word);
        

        foreach(var word in sentence.Split(' '))
        {
            var prefix = "";
            foreach (var t in word)
            {
                prefix += t;
                if(set.Contains(prefix))
                    break;
            }

            ans.Add(prefix);
        }

        return string.Join(' ', ans);
    }
}