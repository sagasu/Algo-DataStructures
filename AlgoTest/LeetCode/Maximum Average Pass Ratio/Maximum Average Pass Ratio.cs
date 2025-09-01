using System.Collections.Generic;

namespace AlgoTest.LeetCode.Maximum_Average_Pass_Ratio;

public class Maximum_Average_Pass_Ratio
{
    public double MaxAverageRatio(int[][] classes, int extraStudents) {
        int n = classes.Length;
        var maxHeap = new PriorityQueue<(int pass, int total), double>(
            Comparer<double>.Create((a, b) => b.CompareTo(a))
        );

        foreach (var cls in classes) {
            int pass = cls[0], total = cls[1];
            maxHeap.Enqueue((pass, total), Gain(pass, total));
        }

        while (extraStudents-- > 0) {
            var (pass, total) = maxHeap.Dequeue();
            pass++;
            total++;
            maxHeap.Enqueue((pass, total), Gain(pass, total));
        }

        double sum = 0;
        while (maxHeap.Count > 0) {
            var (pass, total) = maxHeap.Dequeue();
            sum += (double)pass / total;
        }

        return sum / n;
    }

    private double Gain(int pass, int total) {
        return (double)(pass + 1) / (total + 1) - (double)pass / total;
    }
}