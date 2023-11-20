using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.MinimumAmountofTimetoCollectGarbage;

[TestClass]
public class MinimumAmountofTimetoCollectGarbage
{
    [TestMethod]
    public void Test() => Assert.AreEqual(21, GarbageCollection(new[] { "G", "P", "GP", "GG" }, new[] { 2, 4, 3 }));
    [TestMethod]
    public void Test2() => Assert.AreEqual(37, GarbageCollection(new[] { "MMM","PGM","GP" }, new[] { 3,10 }));
    
    public int GarbageCollection(string[] garbage, int[] travel)
    {
        var glassTime = 0;
        var metalTime = 0;
        var paperTime = 0;
        
        var glassDistance = 0;
        var metalDistance = 0;
        var paperDistance = 0;

        
        for (var i = 0; i < garbage.Length; i++)
        {
            foreach (var garbageType in garbage[i])
            {
                switch (garbageType)
                {
                    case 'P':
                        paperTime += 1;
                        paperTime += paperDistance;
                        paperDistance = 0;
                        break;
                    case 'G':
                        glassTime += 1;
                        glassTime += glassDistance;
                        glassDistance = 0;
                        break;
                    case 'M':
                        metalTime += 1;
                        metalTime += metalDistance;
                        metalDistance = 0;
                        break;
                }
            }

            if (travel.Length > i)
            {
                glassDistance += travel[i];
                paperDistance += travel[i];
                metalDistance += travel[i];
            }
        }

        return glassTime + paperTime + metalTime;
    }
}