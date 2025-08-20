using System;

namespace AlgoTest.LeetCode.Minimum_Time_to_Repair_Cars;

public class Minimum_Time_to_Repair_Cars
{
    public long RepairCars(int[] ranks, int cars) {
        long l = 0, h = (long)1E14, m, f; for (int i; l < h; _ = f < cars ? l = ++m : h = m) for (f = i = 0, m = (l + h) / 2; f < cars && i < ranks.Length;) f += (long)Math.Sqrt(m / ranks[i++]); return l;
       
        
    }
}