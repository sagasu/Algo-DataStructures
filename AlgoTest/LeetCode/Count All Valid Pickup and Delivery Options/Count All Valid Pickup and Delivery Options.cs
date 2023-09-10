namespace AlgoTest.LeetCode.Count_All_Valid_Pickup_and_Delivery_Options;

public class Count_All_Valid_Pickup_and_Delivery_Options
{
    public int CountOrders(int n)
    {
        const int modulo = 1_000_000_007;
        var res = 1L;

        for (var i = 1; i <= n; ++i)
            res = res * i * (2 * i - 1) % modulo;
        
        return (int)res;
    }
}