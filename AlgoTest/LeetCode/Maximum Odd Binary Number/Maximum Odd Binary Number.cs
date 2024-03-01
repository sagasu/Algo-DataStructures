using System.Linq;

namespace AlgoTest.LeetCode.Maximum_Odd_Binary_Number;

public class Maximum_Odd_Binary_Number
{
    public string MaximumOddBinaryNumber(string s) {
        var counter=s.Count(c=>c=='1');
        return new string('1',counter-1)+new string('0',s.Length-counter)+'1';
    }
}