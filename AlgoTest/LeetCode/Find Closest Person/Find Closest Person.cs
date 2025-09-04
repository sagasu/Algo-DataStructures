using System;

namespace AlgoTest.LeetCode.Find_Closest_Person;

public class Find_Closest_Person
{
    public int FindClosest(int x, int y, int z) {
        int a = Math.Abs(x - z);
        int b = Math.Abs(y - z);

        if (a == b) {
            return 0;   // Both x and y are equally close to z
        } else if (a < b) {
            return 1;   // x is closer to z
        } else {
            return 2;   // y is closer to z
        }
    }
}