using System.Linq;

namespace AlgoTest.LeetCode.Reverse_Prefix_of_Word;

public class Reverse_Prefix_of_Word
{
    public string ReversePrefix(string word, char ch) =>
        new string(word.Substring(0, word.IndexOf(ch) + 1).Reverse().ToArray()) 
        + word.Remove(0, word.IndexOf(ch) + 1);
}