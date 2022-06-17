using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest
{
    [TestClass]
    public class MajorityElement_BoyerMoorAlgorithm
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(2, FindMajorityElement(new int[]{ 2, 2, 1, 1, 3, 2, 2 }));
            Assert.AreEqual(2, FindMajorityElement(new int[]{ 2, 2, 3, 2, 2, 1, 1 }));
            // One below is invalid because this algorithm defines "majority" as having more than Floor(n/2)
            //Assert.AreEqual(1, FindMajorityElement(new int[]{ 1, 1, 2, 3, 4, 5, 6 }));
        }

        // Time O(n), space O(1)
        // The majority element is the element that appears more than Floor(n/2) times.
        public int FindMajorityElement(int[] elements)
        {
            var candidate = 0;
            var counter = 0;
            for (var i = 0; i < elements.Length; i++)
            {
                if (counter == 0)
                    candidate = elements[i];
                

                counter += elements[i] == candidate ? 1 : -1;
            }

            return candidate;
        }
    }
}
