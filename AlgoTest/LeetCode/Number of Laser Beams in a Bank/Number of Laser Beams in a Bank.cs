using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Number_of_Laser_Beams_in_a_Bank;

[TestClass]
public class Number_of_Laser_Beams_in_a_Bank
{

    [TestMethod]
    public void Test1() => Assert.AreEqual(8, NumberOfBeams(new[] { "011001", "000000", "010100", "001000" }));
    
    [TestMethod]
    public void Test2() => Assert.AreEqual(0, NumberOfBeams(new[] { "000","111","000" }));
    
    public int NumberOfBeams(string[] bank)
    {
        var low = 0;
        var beams = 0;
        
        for (var i = 0; i < bank.Length; i++)
        {
            var current = bank[i].Sum(x => x == '1' ? 1 : 0);
            if (low == 0 && current != 0) low = current;
            else if (low != 0 && current != 0)
            {
                beams += low * current;
                low = current;
            }
        }

        return beams;
    }
}