using System;
using System.Linq;

namespace AlgoTest.LeetCode.Minimum_Number_of_Days_to_Make_m_Bouquets;

public class Minimum_Number_of_Days_to_Make_m_Bouquets
{
    public int MinDays(int[] bloomDay, int m, int k) {
        int low = 1, high = bloomDay.Max(), ans = int.MaxValue;
        while(low <= high) {
            var mid = low + (high - low) / 2;
            if(IsPossible(bloomDay, m, k, mid)){
                ans = Math.Min(ans, mid);
                high = mid - 1;
            }
            else
                low = mid + 1;
        }

        return ans == int.MaxValue ? -1 : ans;
    }

    bool IsPossible(int[] bloomDay, int m, int k, int days){
        int bouquet = 0, count = 0;

        foreach (var t in bloomDay)
        {
            if(t <= days)
                count++;
            else{
                bouquet += count / k;
                count = 0;
            }
        }

        bouquet += count / k;

        return bouquet >= m;
    }
}