using System;
using System.ServiceModel.Channels;

namespace Playground.Sort.mergeSort
{
    class MergeSort3
    {
        public void Sort(int[] arr)
        {
            var tmp = (int[])arr.Clone();

            Sort(arr,tmp, 0, arr.Length -1);
        }

        private void Sort(int[] arr, int[] tmp, int leftStart, int rightEnd)
        {
            if (leftStart >= rightEnd)
                return;

            var middle = leftStart + (rightEnd - leftStart) / 2;
            Sort(tmp, arr, leftStart, middle);
            Sort(tmp, arr, middle + 1, rightEnd);
            Merge(tmp, arr, leftStart, rightEnd, middle);
        }

        private void Merge(int[] arr, int[] tmp, int leftStart, int rightEnd, int middle)
        {
            var index = leftStart;
            var left = leftStart;
            var right = middle + 1;
            while (left <= middle || right <= rightEnd)
            {
                if (left > middle)
                {
                    tmp[index] = arr[right];
                    right++;
                } else if (right > rightEnd)
                {
                    tmp[index] = arr[left];
                    left++;
                } else if (arr[left] <= arr[right])
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

            //Array.Copy(arr, left, tmp, index, middle - left + 1);
            //Array.Copy(arr, right, tmp, index, rightEnd - right + 1);
            //Array.Copy(tmp, leftStart, arr, leftStart, rightEnd - leftStart + 1);
        }
    }
}
