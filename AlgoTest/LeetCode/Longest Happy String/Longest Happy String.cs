using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Longest_Happy_String;

public class Longest_Happy_String
{
    public string LongestDiverseString(int a, int b, int c)
    {
        var comparer = Comparer<int>.Create((a, b) => b - a);
        var queue = new PriorityQueue<char, int>(comparer);
        queue.EnqueueRange([('a', a), ('b', b), ('c', c)]);

        var result = new StringBuilder();
        while (TryAppendNext());
        return result.ToString();

        bool TryAppendNext()
        {
            if (!queue.TryDequeue(out var letter, out var count) || count == 0)
                return false;

            if (result is [.., var x, var y] &&
                letter == x && letter == y &&
                !TryAppendNext())
                return false;

            queue.Enqueue(letter, --count);
            result.Append(letter);
            return true;
        }
    }
}