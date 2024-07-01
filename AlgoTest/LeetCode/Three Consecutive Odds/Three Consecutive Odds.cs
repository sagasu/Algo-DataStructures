namespace AlgoTest.LeetCode.Three_Consecutive_Odds;

public class Three_Consecutive_Odds
{
    public bool ThreeConsecutiveOdds(int[] arr) {
        if(arr == null || arr.Length < 3)
            return false;
            
        var cnt = 0;
        foreach (var t in arr)
        {
            cnt = t % 2 == 0? 0 : cnt + 1;
            if(cnt == 3)
                return true;
        }
        
        return false;
    }
}