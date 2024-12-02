using System.Linq;

namespace AlgoTest.LeetCode.Check_If_a_Word_Occurs_As_a_Prefix_of_Any_Word_in_a_Sentence;

public class Check_If_a_Word_Occurs_As_a_Prefix_of_Any_Word_in_a_Sentence
{
    public int IsPrefixOfWord(string sentence, string searchWord) 
    {
        var words = sentence.Split(' ').ToList();
        for(var i = 0; i < words.Count; i++)
            if(words[i].StartsWith(searchWord))
                return i + 1;
        return -1;
    }
}