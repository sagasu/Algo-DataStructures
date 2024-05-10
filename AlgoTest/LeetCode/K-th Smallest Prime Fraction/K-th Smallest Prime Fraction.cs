using System.Collections.Generic;

namespace AlgoTest.LeetCode.K_th_Smallest_Prime_Fraction;

public class K_th_Smallest_Prime_Fraction
{
    public int[] KthSmallestPrimeFraction(int[] arr, int k) {
        var len=arr.Length;
        var heap=new PriorityQueue<int[], double>();
        
        for(var i=0;i<len;i++)
        {
            for(var j=len-1;j>i;j--)
            {
                var f=(double)arr[i]/(double)arr[j];
                if(heap.Count<k)
                {
                    heap.Enqueue(new int[]{arr[i], arr[j]}, -1*f);
                    continue;
                }
                
                var top=(double)heap.Peek()[0]/(double)heap.Peek()[1];
                if(top > f)
                {
                    heap.Dequeue();
                    heap.Enqueue(new int[]{arr[i], arr[j]}, -1*f);
                }
                else 
                    break;
            }
        }

        return heap.Dequeue();
    }
}