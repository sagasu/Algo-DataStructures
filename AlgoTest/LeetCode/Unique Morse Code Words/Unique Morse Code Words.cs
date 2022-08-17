using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Unique_Morse_Code_Words
{
    internal class Unique_Morse_Code_Words
    {
        public int UniqueMorseRepresentations(string[] words) => words
            .Select(w => string.Concat(w.Select(c =>
                ".-|-...|-.-.|-..|.|..-.|--.|....|..|.---|-.-|.-..|--|-.|---|.--.|--.-|.-.|...|-|..-|...-|.--|-..-|-.--|--.."
                    .Split('|')[c - 'a']
            )))
            .ToHashSet()
            .Count;
    }
}
