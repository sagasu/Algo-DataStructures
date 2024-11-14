using System.Linq;

namespace AlgoTest.LeetCode.Minimized_Maximum_of_Products_Distributed_to_Any_Store;

public class Minimized_Maximum_of_Products_Distributed_to_Any_Store
{
    public int MinimizedMaximum(int n, int[] quantities)
        {
            var left = 1;
            var right = quantities.Max();
    
            while (left < right)
            {
                var mid = left + (right - left) / 2;
                var stores = quantities.Sum(q => (q + mid - 1) / mid);
                if (stores <= n)
                    right = mid;
                else
                    left = mid + 1;
            }
    
            return left;
        }
}