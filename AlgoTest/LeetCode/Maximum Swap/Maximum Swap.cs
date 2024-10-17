namespace AlgoTest.LeetCode.Maximum_Swap;

public class Maximum_Swap
{
    public int MaximumSwap(int num)
    {
        var number = num.ToString().ToCharArray();
        var n = number.Length;

        var maximumIndex = new int[n];
        for (int index = n - 1; index >= 0; index--)
        {
            maximumIndex[index] = index == n - 1 || number[index] > number[maximumIndex[index + 1]]
                ? index
                : maximumIndex[index + 1];
        }

        for (var index = 0; index < number.Length; index++)
        {
            if (number[index] == number[maximumIndex[index]]) continue;

            (number[index], number[maximumIndex[index]]) = (number[maximumIndex[index]], number[index]);
            break;
        }

        return int.Parse(new string(number));
    }
}