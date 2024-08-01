using System.Linq;

namespace AlgoTest.LeetCode.Number_of_Senior_Citizens;

public class Number_of_Senior_Citizens
{
    public int CountSeniors(string[] details) => details.Count(detail => int.Parse(detail[^4..^2]) > 60);
}