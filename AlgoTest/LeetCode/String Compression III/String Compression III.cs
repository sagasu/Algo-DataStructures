using System.Linq;
using System.Text;

namespace AlgoTest.LeetCode.String_Compression_III;

public class String_Compression_III
{
    public string CompressedString(string s) => s
        .Aggregate(
            new StringBuilder(),
            (acc, next) => acc.Length == 0 || acc[^1] != next || acc[^2] == '9' ?
                acc.Append(1).Append(next) :
                acc.Replace(acc[^2], (char)(acc[^2] + 1), acc.Length - 2, 1),
            acc => acc.ToString()
        );
}