using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Smallest_Number_in_Infinite_Set
{
    [TestClass]
    public class SmallestNumberinInfiniteSet
    {
        [TestMethod]
        public void Test()
        {
            var sis = new SmallestInfiniteSet();
            Assert.AreEqual(1, sis.PopSmallest());
            Assert.AreEqual(2, sis.PopSmallest());
            sis.AddBack(1);
            Assert.AreEqual(1, sis.PopSmallest());
            sis.AddBack(1);
            sis.AddBack(1);
            Assert.AreEqual(1, sis.PopSmallest());
            Assert.AreEqual(3, sis.PopSmallest());
            Assert.AreEqual(4, sis.PopSmallest());
            Assert.AreEqual(5, sis.PopSmallest());
            sis.AddBack(1);
            sis.AddBack(3);
            sis.AddBack(2);
            Assert.AreEqual(1, sis.PopSmallest());
            Assert.AreEqual(2, sis.PopSmallest());
            Assert.AreEqual(3, sis.PopSmallest());
            Assert.AreEqual(6, sis.PopSmallest());
        }

        [TestMethod]
        public void Test2()
        {
            var sis = new SmallestInfiniteSet();
            sis.AddBack(580);
            sis.AddBack(607);
            Assert.AreEqual(1, sis.PopSmallest());
        }
    }

    internal class SmallestInfiniteSet
    {
        private readonly Stack<int> _stack = new();
        public SmallestInfiniteSet()
        {
            for(var num =1000; num > 0; num--)
            {
                _stack.Push(num);
            }
        }

        public int PopSmallest()
        {
            return _stack.Pop();
        }

        public void AddBack(int num)
        {
            var smallest = 0;
            var tempStack = new Stack<int>();
            int queueValue;

            if (_stack.Count == 0)
            {
                _stack.Push(num);
                return;
            }

            while (_stack.TryPeek(out smallest))
            {
                if (smallest == num) break;
                if (smallest > num)
                {
                    _stack.Push(num);
                    break;
                }

                _stack.Pop();
                tempStack.Push(smallest);
            }

            while (tempStack.TryPeek(out queueValue))
            {
                tempStack.Pop();
                _stack.Push(queueValue);
            }



        }
    }
}
