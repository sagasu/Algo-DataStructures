using System.Linq;

namespace AlgoTest.LeetCode.Minimum_Penalty_for_a_Shop;

public class Minimum_Penalty_for_a_Shop
{
    public int BestClosingTime(string customers) {
        var current = customers.Count(c => c == 'N');
        
        var best = current;
        var result = customers.Length;

        for (var i = customers.Length - 1; i >= 0; --i) {
            current += customers[i] == 'Y' ? 1 : -1; 

            if (current <= best) {
                current = best;

                result = i;
            }        
        }

        return result;
    }
}