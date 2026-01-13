using System;

namespace AlgoTest.LeetCode.Separate_Squares_I;

public class Separate_Squares_I
{
    public double SeparateSquares(int[][] squares) {
        double max_y = 0, total_area = 0;
        foreach (int[] sq in squares) {
            int y = sq[1], l = sq[2];
            total_area += (double)l * l;
            max_y = Math.Max(max_y, (double)(y + l));
        }

        double lo = 0, hi = max_y;
        double eps = 1e-5;
        while (Math.Abs(hi - lo) > eps) {
            double mid = (hi + lo) / 2;
            if (Check(mid, squares, total_area)) {
                hi = mid;
            } else {
                lo = mid;
            }
        }

        return hi;
    }

    private bool Check(double limit_y, int[][] squares, double total_area) {
        double area = 0;
        foreach (int[] sq in squares) {
            int y = sq[1], l = sq[2];
            if (y < limit_y) {
                area += (double)l * Math.Min(limit_y - y, (double)l);
            }
        }
        return area >= total_area / 2;
    }
}