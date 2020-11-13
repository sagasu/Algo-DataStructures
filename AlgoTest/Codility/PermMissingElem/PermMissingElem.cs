using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.Codility.PermMissingElem
{
    [TestClass]
    public class PermMissingElem
    {
        [TestMethod]
        public void Test()
        {
            var t = new int[]{2,3,1,5};
            solution(t);

        }

        public int solution(int[] A)
        {
            if (A == null)
                return 0;

            if (A.Length == 1)
                return A[0];

            var max = 0;
            var min = int.MaxValue;
            foreach (var i in A)
            {
                if (i > max)
                    max = i;
                if (i < min)
                    min = i;
            }

            var hashSet = new HashSet<int>(Enumerable.Range(min, max));

            foreach (var i in A)
            {
                hashSet.Remove(i);
            }

            
            return hashSet.Count == 0 ? min - 1 : hashSet.First();
        }
    }
}
