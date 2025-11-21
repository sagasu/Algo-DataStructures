using System;

namespace AlgoTest.LeetCode.Set_Intersection_Size_At_Least_Two;

public class Set_Intersection_Size_At_Least_Two
{
    public int IntersectionSizeTwo(int[][] intervals) {
        Array.Sort(intervals, (a, b) => {
            if (a[1] != b[1]) return a[1].CompareTo(b[1]);
            return b[0].CompareTo(a[0]);
        });

        int count = 0;
        int a = -1, b = -1;

        foreach (var inr in intervals) {
            int start = inr[0], end = inr[1];

            bool aIn = (a >= start && a <= end);
            bool bIn = (b >= start && b <= end);

            if (aIn && bIn) {
                continue;
            }

            if (aIn) {
                b = a;
                a = end;
                count++;
            } else {
                b = end - 1;
                a = end;
                count += 2;
            }
        }

        return count;
    }
}