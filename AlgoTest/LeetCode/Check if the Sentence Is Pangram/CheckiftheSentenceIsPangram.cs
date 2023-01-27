using System.Collections.Generic;

public class CheckIfPangramSolution
{
    public bool CheckIfPangram(string sentence)
    {
                HashSet<char> visited = new HashSet<char>();
                sentence = sentence.ToLower();
                for (int i = 0; i < sentence.Length; i++)
                {
                    visited.Add(sentence[i]);
                    if (visited.Count == 26) return true;
                }
                return false;
    }
}