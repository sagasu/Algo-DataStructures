namespace AlgoTest.LeetCode.Water_Bottles_II;

public class Water_Bottles_II
{
    public int MaxBottlesDrunk(int numBottles, int numExchange) {
        int totalDrunk = numBottles;   
        int emptyBottles = numBottles; 

        while (emptyBottles >= numExchange) {
            emptyBottles -= numExchange;
            numExchange++;  
            totalDrunk++;   
            emptyBottles++; 
        }

        return totalDrunk;
    }
}