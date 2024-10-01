namespace AlgoTest.LeetCode.Check_If_Array_Pairs_Are_Divisible_by_k;

public class Check_If_Array_Pairs_Are_Divisible_by_k
{
    public bool CanArrange(int[] numbers, int k) 
    {
        var remainderCount = new int[k];

        foreach (var num in numbers)
        {
            var remainder = num % k;
            if(remainder < 0)
                remainder += k;

            remainderCount[remainder]++;
        }

        if(remainderCount[0] % 2 != 0)
            return false;

        for(var i = 1; i < k; i++)
            if(remainderCount[i] != remainderCount[k - i])
                return false;
        
        return true;
    }
}