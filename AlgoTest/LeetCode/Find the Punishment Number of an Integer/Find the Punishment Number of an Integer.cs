using System.Linq;

namespace AlgoTest.LeetCode.Find_the_Punishment_Number_of_an_Integer;

public class Find_the_Punishment_Number_of_an_Integer
{
    public int PunishmentNumber(int n) => new[]
        {
            1, 9, 10, 36, 45, 55, 82, 91, 99, 100, 235,
            297, 369, 370, 379, 414, 657, 675, 703, 756,
            792, 909, 918, 945, 964, 990, 991, 999, 1000
        }
        .TakeWhile(x => x <= n)
        .Sum(x => x * x);
}