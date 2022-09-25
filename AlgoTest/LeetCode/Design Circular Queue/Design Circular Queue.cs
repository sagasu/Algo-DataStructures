using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Design_Circular_Queue
{
    internal class MyCircularQueue
    {
        private int Size;
        private int WriteIndex = -1;
        private int ReadIndex = 0;
        private int Capacity = -1;
        private int[] internalBufferArray;

        public MyCircularQueue(int k)
        {
            this.Capacity = k;
            internalBufferArray = new int[k];
        }


        public bool EnQueue(int value)
        {
            if (IsFull()) return false;

            WriteIndex = (WriteIndex + 1) % Capacity;
            internalBufferArray[WriteIndex] = value;
            Size++;
            return true;
        }
        
        public bool DeQueue()
        {
            if (IsEmpty()) return false;

            ReadIndex = (ReadIndex + 1) % Capacity;
            Size--;

            return true;
        }
        
        public int Front()
        {
            if (IsEmpty()) return -1;

            return internalBufferArray[ReadIndex];
        }
        
        public int Rear()
        {
            if (IsEmpty()) return -1;

            return internalBufferArray[WriteIndex];
        }
        
        public bool IsEmpty()
        {
            return (Size == 0);
        }
        
        public bool IsFull()
        {
            return (Size == Capacity);
        }
    }
}
