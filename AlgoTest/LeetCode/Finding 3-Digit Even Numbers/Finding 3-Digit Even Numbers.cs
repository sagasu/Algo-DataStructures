using System.Collections.Generic;

namespace AlgoTest.LeetCode.Finding_3_Digit_Even_Numbers;

public class Finding_3_Digit_Even_Numbers
{
    public int[] FindEvenNumbers(int[] digits)
    {
        List<int> result = new List<int>();

        for (int i = 100; i < 1000; i += 2)
        {
            int three = i / 100;
            int two = (i / 10) % 10;
            int one = i % 10;

            List<int> temp = new List<int>(digits);

            if (temp.Contains(three))
            {
                temp.Remove(three);
                if (temp.Contains(two))
                {
                    temp.Remove(two);
                    if (temp.Contains(one))
                    {
                        result.Add(i);
                    }
                }
            }
        }

        return result.ToArray();
    }
}