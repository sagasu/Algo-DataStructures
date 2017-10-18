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
            Merge(arr, tmp, leftStart, rightEnd, middle);
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
                    arr[index] = tmp[right];
                    right++;
                } else if (right > rightEnd)
                {
                    arr[index] = tmp[left];
                    left++;
                } else if (tmp[left] <= tmp[right])
                {
                    arr[index] = tmp[left];
                    left++;
                }
                else
                {
                    arr[index] = tmp[right];
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
