using System.Linq;

namespace AlgoTest.LeetCode.Check_If_N_and_Its_Double_Exist;

public class Check_If_N_and_Its_Double_Exist
{
    public bool CheckIfExist(int[] arr) => arr.Count(i => i == 0) > 1 || arr.Where(i => i != 0).Any(x => arr.Contains(x * 2));
}