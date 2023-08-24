using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Text_Justification;

public class Text_Justification
{
    public IList<string> FullJustify(string[] words, int maxWidth) {
        var result = new List<string>();
        var current = new List<StringBuilder>();
        var numOfLetters = 0;
        var last = words.Length;
        var index = 1;
			
        foreach (var word in words)
        {
            if (numOfLetters + word.Length + current.Count > maxWidth)
            {
                for (var i = 0; i < (maxWidth - numOfLetters); i++)
                {
                    if (current.Count == 1)
                        current[0].Append(" ");
                    else
                        current[i % (current.Count - 1)].Append(" ");
                }

                result.Add(string.Join("", current));

                current = new List<StringBuilder>();
                numOfLetters = 0;
            }

            current.Add(new StringBuilder(word));
            numOfLetters += word.Length;
                
            if(index == last) //final word, only add space at the end of the collection
            {
                var final = string.Join(" ", current);
                var fLength = final.Length;
                for (var i = 0; i < (maxWidth - fLength); i++)
                    final = final + " ";
                
                result.Add(final);
            }
            index++;
        }

        return result;
    }
}