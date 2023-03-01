using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Sort_an_Array
{
    [TestClass]
    public class Sort_an_Array
    {
        [TestMethod]
        public void Test()
        {
            int[] arr = { 5, 4, 3, 1, 2 };
            QuickSort(arr);
            Assert.IsTrue(arr is [ 1, 2, 3, 4, 5 ]);
        }
        
        [TestMethod]
        public void Test2()
        {
            int[] arr = { 5, 2,3,1 };
            QuickSort(arr);
            Assert.IsTrue(arr is [ 1, 2, 3, 5 ]);
        }

        [TestMethod]
        public void Test3()
        {
            int[] arr = { 5, 1, 1, 2, 0, 0 };
            QuickSort(arr);
            Assert.IsTrue(arr is [ 0, 0, 1, 1, 2, 5 ]);
        }


        public void QuickSort(int[] arr)
        {
            void QuickSort(int left, int right)
            {
                if (left < right)
                {
                    var pivot = Partition(left, right);
                    if (pivot > 1) QuickSort(left, pivot - 1);
                    if (pivot + 1 < right) QuickSort(pivot + 1, right);
                }
                //Partition(0, arr.Length - 1);
            }

            int Partition(int left, int right)
            {
                var pivot = arr[left];

                while (true)
                {
                    while (arr[left] < pivot) left++;

                    while (arr[right] > pivot) right--;

                    if (left < right && arr[left] != arr[right])
                    {
                        (arr[left], arr[right]) = (arr[right], arr[left]);
                        //left++;
                        //right--;
                    }
                    else return right;
                }
                return right;//should never be called
            }

            QuickSort(0, arr.Length-1);
        }

        
    }

    
}
