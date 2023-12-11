using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Element_Appearing_More_Than_25__In_Sorted_Array;

[TestClass]
public class Element_Appearing_More_Than_25__In_Sorted_Array
{
    [TestMethod]
    public void Test() => Assert.AreEqual(6, FindSpecialInteger(new[] { 1, 2, 2, 6, 6, 6, 6, 7, 10 }));
    
    [TestMethod]
    public void Test2() => Assert.AreEqual(3, FindSpecialInteger(new[] {1,2,3,3 }));
    
    public int FindSpecialInteger(int[] arr)
    {
        var quater = arr.Length * 0.25;
        var previous = arr[0];
        var sum = 1;
        for (var i = 1; i < arr.Length; i++)
        {
            if (arr[i] == previous) sum++;
            else
            {
                if (sum > quater) return previous;
                previous = arr[i];
                sum = 1;
            }
        }

        return arr[^1];
    }
}