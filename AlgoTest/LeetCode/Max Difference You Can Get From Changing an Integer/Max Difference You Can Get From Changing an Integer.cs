namespace AlgoTest.LeetCode.Max_Difference_You_Can_Get_From_Changing_an_Integer;

public class Max_Difference_You_Can_Get_From_Changing_an_Integer
{
    public int MaxDiff(int num) {
        var numStr = num.ToString();
        var max = num;
        var min = num;

        foreach (var c in numStr)
        {
            if (c != '9')
            {
                var maxStr = numStr.Replace(c, '9');
                max = int.Parse(maxStr);
                break;
            }
        }

        for (var i = 0; i < numStr.Length; i++)
        {
            if (i == 0)
            {
                if (numStr[i] != '1')
                {
                    var minStr = numStr.Replace(numStr[i], '1');
                    min = int.Parse(minStr);
                    break;
                }
            }
            else if (i > 0 && numStr[i] != '0' && numStr[i] != '1')
            {
                var minStr = numStr.Replace(numStr[i], '0');
                min = int.Parse(minStr);
                break;
            }

        }
        return max - min;
    }
}