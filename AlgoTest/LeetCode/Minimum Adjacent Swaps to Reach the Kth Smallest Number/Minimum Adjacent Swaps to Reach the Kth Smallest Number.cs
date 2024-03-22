using System;
using System.Linq;

namespace AlgoTest.LeetCode.Minimum_Adjacent_Swaps_to_Reach_the_Kth_Smallest_Number;

public class Minimum_Adjacent_Swaps_to_Reach_the_Kth_Smallest_Number
{
    public int GetMinSwaps(string num, int k)
    {
        var counter = 0;
        var numArray = num.ToArray().Select(c => c - '0').ToArray();
        var targetArray = num.ToArray().Select(c => c - '0').ToArray();

        for (var i = 0; i < k; i++)
            NextPermutation(targetArray);
        

        for (var i = 0; i < numArray.Length; i++)
        {
            if (numArray[i] != targetArray[i])
            {
                var index = Array.IndexOf(numArray, targetArray[i], i + 1);
                for (var j = index; j > i; j--)
                {
                    counter++;
                    Swap(numArray, j, j - 1);
                }
            }
        }

        return counter;
    }

    void NextPermutation(int[] array)
    {
        for (var i = array.Length - 2; i >= 0; i--)
        {
            if (array[i] < array[i + 1])
            {
                var current = array[i];
                var next = array.Skip(i + 1).Where(c => c > current).Min();
                for (var j = i + 1; j < array.Length; j++)
                {
                    if (array[j] == next)
                    {
                        Swap(array, i, j);
                        break;
                    }
                }
                
                Array.Sort(array, i + 1, array.Length - i - 1);
                return;
            }
        }
    }


    static void Swap(int[] array, int i, int j)
    {
        (array[i], array[j]) = (array[j], array[i]);
    }
}