using System;

namespace AlgoTest.LeetCode.Complement_of_Base_10_Integer;

public class Complement_of_Base_10_Integer
{
    public int BitwiseComplement(int n) {
        string bin = Convert.ToString(n, 2);
        string rev = "";

        foreach (char c in bin)
        {
            if (c == '1'){
                rev += '0';
            }     
            else{
                rev += '1';
            }        
        }

        return Convert.ToInt32(rev, 2);
    }
}