using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Find_Common_Characters;

public class Find_Common_Characters
{
    public IList<string> CommonChars(string[] words) 
    {
        var common = words[0].ToCharArray();

        for(int i=1; i<words.Length; i++)
            common = Intersect(common, words[i].ToCharArray()).ToArray();

        return common.Select(x=>x.ToString()).ToArray();
    }

    private IEnumerable<T> Intersect<T>(IEnumerable<T> source, IEnumerable<T> target)
    {
        var list = target.ToList();
        foreach (T item in source)
        {
            if (list.Contains(item))
            {
                list.Remove(item);
                yield return item;
            }
        }
    }
}