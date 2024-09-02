using System;
using System.Linq;

namespace AlgoTest.LeetCode.Find_the_Student_that_Will_Replace_the_Chalk;

public class Find_the_Student_that_Will_Replace_the_Chalk
{
    public int ChalkReplacer(int[] chalk, int k)
    {
        k = (int)(k % chalk.Sum(c => (long)c));
        return Array.FindIndex(chalk, c => (k -= c) < 0);
    }
}