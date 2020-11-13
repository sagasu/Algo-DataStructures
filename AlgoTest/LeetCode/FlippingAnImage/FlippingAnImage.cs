using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.FlippingAnImage
{
    [TestClass]
    public class FlippingAnImage
    {
        [TestMethod]
        public void Test()
        {
            var t = new int[][]{new int[]{1, 1, 0},new int[]{1, 0, 1},new int[]{0, 0, 0}};
            var ans = new int[][]{new int[]{1, 0, 0},new int[]{0, 1, 0},new int[]{1, 1, 1}};
            CollectionAssert.AreEqual(ans, FlipAndInvertImage(t));
        }
        public int[][] FlipAndInvertImage(int[][] A)
        {
            foreach (var elements in A)
            {
                var x = 0;
                var y = A.Length-1;
                while (x < y)
                {
                    Swap(elements, x, y);

                    x += 1;
                    y -= 1;
                }

                if (x == y)
                    elements[x] = 1 - elements[x];
            }

            return A;
        }

        private void Swap(int[] elements, int x, int y)
        {
            var temp = elements[x];
            elements[x] = 1- elements[y];
            elements[y] = 1 - temp;
        }
    }
}
