using System.Collections.Generic;

namespace AlgoTest.LeetCode.Sentence_Similarity_III;

public class Sentence_Similarity_III
{
    public bool AreSentencesSimilar(string sentence1, string sentence2)
    {
        var dq1 = new LinkedList<string>(sentence1.Split(" "));
        var dq2 = new LinkedList<string>(sentence2.Split(" "));

        while (dq1.Count != 0 && dq2.Count != 0 && dq1.First.Value.Equals(dq2.First.Value))
        {
            dq1.RemoveFirst();
            dq2.RemoveFirst();
        }

        while (dq1.Count != 0 && dq2.Count != 0 && dq1.Last.Value.Equals(dq2.Last.Value))
        {
            dq1.RemoveLast();
            dq2.RemoveLast();
        }
        return dq1.Count == 0 || dq2.Count == 0;
    }
}