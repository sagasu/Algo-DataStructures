using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.Other
{
    [TestClass]
    public class Problem2
    {
        [TestMethod]
        public void TesT()
        {
            var ar = new int[] {3, 4, 5, 1, 2};
            Bubble(ar);
            CollectionAssert.AreEqual(new int[]{1,2,3,4,5}, ar);
        }

        // This is O(n^2) even if the arr is sorted
        public void Bubble(int[] arr)
        {
            for(var i = 0; i < arr.Length; i++)
            for (var j = 1; j < arr.Length; j++)
            {
                if (arr[j] < arr[j - 1])
                    Swap(arr, j);
            }
        }


        [TestMethod]
        public void Test_TrueBubble()
        {
            var ar = new int[] { 3, 4, 5, 1, 2 };
            TrueBubble(ar);
            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4, 5 }, ar);
        }

        public void TrueBubble(int[] arr)
        {
            var isSwap = true;
            while (isSwap)
            {
                isSwap = false;
                for (var j = 1; j < arr.Length; j++)
                    if (arr[j] < arr[j - 1])
                    {
                        Swap(arr, j);
                        isSwap = true;
                    }
                
            }
        }

        public void Swap(int[] arr, int index)
        {
            var temp = arr[index];
            arr[index] = arr[index - 1];
            arr[index - 1] = temp;
        }
    }
}
