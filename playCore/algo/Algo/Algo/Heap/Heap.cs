using System;
using System.Collections.Generic;
using System.Text;

namespace Algo.Heap
{
    public class MinIntHeap
    {
        private int capacity = 10;
        private int size = 0;

        int[] items;

        public MinIntHeap()
        {
            items = new int[capacity];
        }

        private int getLeftChildIndex(int parentIndex) { return 2 * parentIndex + 1; }
        private int getRightChildIndex(int parentIndex) { return 2 * parentIndex + 2; }
        private int getParentIndex(int childIndex) { return (childIndex -1)/2; }

        bool hasLeftChild(int index) => getLeftChildIndex(index) < size;
        bool hasRightChild(int index) => getRightChildIndex(index) < size;
        bool hasParent(int index) => getParentIndex(index) > 0;

        int getLeftChild(int parentIndex) => items[getLeftChildIndex(parentIndex)];
        int getRightChild(int parentIndex) => items[getRightChildIndex(parentIndex)];
        int getParent(int childIndex) => items[getParentIndex(childIndex)];

        private void Swap(int indexA, int indexB) {
            var temp = items[indexA];
            items[indexA] = items[indexB];
            items[indexB] = temp;
        }

        private void EnsureCapacity() {
            if (capacity == size) {
                capacity = capacity * 2;
                Array.Resize<int>(ref items, capacity);
            }
        }
    }
}
