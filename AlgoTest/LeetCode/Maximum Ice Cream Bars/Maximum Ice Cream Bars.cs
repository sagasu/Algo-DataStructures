using System.Linq;

public class MaxIceCreamSolution
{
    public int MaxIceCream(int[] costs, int coins) => costs
    .OrderBy(c => c)
    .TakeWhile(c => (coins -= c) >= 0)
    .Count();
}