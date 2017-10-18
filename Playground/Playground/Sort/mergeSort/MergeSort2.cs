using System;
using System.ServiceModel.Channels;

namespace Playground.Sort.mergeSort
{
    class MergeSort2
    {
        public void Sort(int[] arr)
        {
            var tmp = new int[arr.Length];

            Sort(arr,tmp, 0, arr.Length -1);
        }

        private void Sort(int[] arr, int[] tmp, int leftStart, int rightEnd)
        {
            if (leftStart >= rightEnd)
                return;

            var middle = (leftStart + rightEnd) / 2;
            Sort(arr, tmp, leftStart, middle);
            Sort(arr, tmp, middle + 1, rightEnd);
            Merge(arr, tmp, leftStart, rightEnd);
        }

        private void Merge(int[] arr, int[] tmp, int leftStart, int rightEnd)
        {
            var middle = (leftStart + rightEnd) / 2;
            var index = leftStart;
            var left = leftStart;
            var right = middle + 1;
            while (left <= middle && right <= rightEnd)
            {
                if (arr[left] <= arr[right])
                {
                    tmp[index] = arr[left];
                    left++;
                }
                else
                {
                    tmp[index] = arr[right];
                    right++;
                }

                index++;
            }

            Array.Copy(arr, left, tmp, index, middle - left + 1);
            Array.Copy(arr, right, tmp, index, rightEnd - right + 1);
            Array.Copy(tmp, leftStart, arr, leftStart, rightEnd - leftStart + 1);
        }
    }
}
