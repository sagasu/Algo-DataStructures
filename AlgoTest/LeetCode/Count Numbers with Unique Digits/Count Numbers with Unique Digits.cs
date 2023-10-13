namespace AlgoTest.LeetCode.Trips_and_Users;

public class CountNumberswithUniqueDigits
{
    public int CountNumbersWithUniqueDigits(int n) {
        if(n > 10)
            n = 10;
        if(n < 1)
            return 1;
        
        var sum = 10;
        var factorial = 9;
        
        for(var i =1; i<n; i++){
            factorial = factorial * (10 - i);
            
            sum += factorial;
        }
        
        return sum;
    }
}