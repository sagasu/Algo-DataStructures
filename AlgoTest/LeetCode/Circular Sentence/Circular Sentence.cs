using System.Linq;

namespace AlgoTest.LeetCode.Circular_Sentence;

public class Circular_Sentence
{
    public bool IsCircularSentence(string sentence)
    {
        var s = sentence.Split(' ');
        for (int i = 0; i < s.Length - 1; i++)
        {
            if (s[i].Last() != s[i + 1].First())
                return false;
        }
        
        if (s.Last().Last() != s.First().First())
            return false;
        return true;
    }
}