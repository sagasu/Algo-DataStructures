using System.Linq;

namespace AlgoTest.LeetCode.Append_Characters_to_String_to_Make_Subsequence;

public class Append_Characters_to_String_to_Make_Subsequence
{
        public int AppendCharacters(string s, string t) {
            if (string.IsNullOrEmpty(t))
                return 0;

            var start = 0;

            foreach (var t1 in s.Where(t1 => t1 == t[start]))
            {
                start += 1;

                if (start >= t.Length)
                    return 0;
            }

            return t.Length - start;
        }
    
}