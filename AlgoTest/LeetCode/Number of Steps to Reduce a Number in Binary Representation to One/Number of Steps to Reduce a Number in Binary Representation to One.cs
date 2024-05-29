namespace AlgoTest.LeetCode.Number_of_Steps_to_Reduce_a_Number_in_Binary_Representation_to_One;

public class Number_of_Steps_to_Reduce_a_Number_in_Binary_Representation_to_One
{
    public int NumSteps(string s)
    {
        var res = 0;
        var carry = 0;
        for (var i = s.Length - 1; i > 0; i--)
        {
            if (s[i] - '0' + carry == 1)
            {
                res++;
                carry = 1;
            }
            res++;
        }

        return res + carry;
    }
}