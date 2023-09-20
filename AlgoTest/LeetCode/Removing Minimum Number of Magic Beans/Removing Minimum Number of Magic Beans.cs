using System.Linq;

namespace AlgoTest.LeetCode.Removing_Minimum_Number_of_Magic_Beans;

public class Removing_Minimum_Number_of_Magic_Beans
{
    public long MinimumRemoval(int[] beans) 
        => beans.Sum(x => (long) x) - beans.OrderBy(x => x).Select((bean, i) => ((long) bean) * (beans.Length - i)).Max();
}