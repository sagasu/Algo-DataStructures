using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Minimum_Cost_to_Hire_K_Workers;

public class Minimum_Cost_to_Hire_K_Workers
{
    public double MincostToHireWorkers(int[] quality, int[] wage, int K) {
        var len = quality.Length;
        var w = new Worker[len];
        for (int i = 0; i < len; i++) w[i] = new Worker(quality[i], wage[i]);
        w = w.OrderBy(x => x.ratio).ToArray();
        var res = w[K - 1].ratio * w.Take(K).Sum(x => x.quality);
        var first = new List<int> (w.Take(K).Select(x => x.quality));
        first.Sort();
        var sum = first.Sum();
        for(int i = K; i < len; i++) {
            var worker = w[i];
            if (worker.quality <= first[K - 1]) {
                var j = 0;
                while (worker.quality > first[j]) j++;
                first.Insert(j, worker.quality);
                sum -= first[K];
                sum += worker.quality;
                res = Math.Min(res, sum * w[i].ratio);
            }
        }
        return res;
    }

    private class Worker {
        public Worker(int quality, int wage) {
            this.quality = quality;
            this.wage = wage;
            this.ratio = ((double)wage) / quality;
        }
        public int quality;
        public int wage;
        public double ratio;
    }
}