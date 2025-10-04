using System;

namespace AlgoTest.LeetCode.Maximum_Tastiness_of_Candy_Basket;

public class Maximum_Tastiness_of_Candy_Basket
{
    public int MaximumTastiness(int[] price, int k) {
        int len = price.Length;
        Array.Sort(price);

        int low = 0, high = price[len-1]-price[0], res = 0;
        while(low <= high)
        {
            int mid = (low+high)/2, cnt = 1;
            for(int i = 1, j = 0; i < len && cnt < k; i++)
            {
                if(price[i]-price[j] >= mid)
                {
                    cnt++;
                    j = i;
                }
            }

            if(cnt >= k)
            {
                res = mid;
                low = mid+1;
            }
            else
                high = mid-1;
        }

        return res;
    }
}