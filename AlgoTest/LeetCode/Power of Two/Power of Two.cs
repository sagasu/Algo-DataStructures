namespace AlgoTest.LeetCode.Power_of_Two;

public class Power_of_Two
{
    public bool IsPowerOfTwo(int n) {
        if (n <= 0) return false;
        var result = 1;
        
        for (var i = 0; i < 31; i++) 
            if (n == (result << i)) 
                return true;
        return false;
    }
}