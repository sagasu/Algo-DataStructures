using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.HackerRank.CountingValleys
{
    [TestClass]
    public class CountingValleys
    {
        [TestMethod]
        public void CountingValleysTest()
        {
            var n = 8;
            var s = "UDDDUDUU";
            Assert.AreEqual(1, GetNumberOfValleys(n, s));
        }

        public int GetNumberOfValleys(int n, string s)
        {
            var valleyCount = 0;
            var level = 0;
            foreach (var direction in s)
            {
                if (direction == 'U')
                {
                    level = level + 1;
                }
                else
                {
                    if (level == 0)
                        valleyCount += 1;
                    level = level - 1;
                }


            }
            return valleyCount;
        }
    }
}
