using System;

namespace AlgoTest.LeetCode.Check_if_Grid_can_be_Cut_into_Sections;

public class Check_if_Grid_can_be_Cut_into_Sections
{
    public bool CheckValidCuts(int n, int[][] rectangles) {
        return CheckCuts(rectangles, 0) || CheckCuts(rectangles, 1);
    }
    private bool CheckCuts(int[][] rectangles, int dim) {
        Array.Sort(rectangles, (a, b) => a[dim].CompareTo(b[dim]));

        int gapCount = 0;
        int furthestEnd = rectangles[0][dim + 2];

        for (int i = 1; i < rectangles.Length; i++) {
            int[] rect = rectangles[i];

            if (furthestEnd <= rect[dim]) {
                gapCount++;
            }

            furthestEnd = Math.Max(furthestEnd, rect[dim + 2]);
        }

        return gapCount >= 2;
    }
}