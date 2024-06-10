using System.Linq;

namespace AlgoTest.LeetCode.Height_Checker;

public class Height_Checker
{
    public int HeightChecker(int[] H) => H
        .Order()
        .Where((h, i) => h != H[i])
        .Count();
}