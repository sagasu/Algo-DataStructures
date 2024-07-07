namespace AlgoTest.LeetCode.Water_Bottles;

public class Water_Bottles
{
    public int NumWaterBottles(int numBottles, int numExchange) {
        var result = numBottles;
        
        while(numBottles >= numExchange)
        {
            var tmp = numBottles / numExchange;
            result += tmp ;
            numBottles = tmp + numBottles % numExchange;
        }
        return result;
    }
}