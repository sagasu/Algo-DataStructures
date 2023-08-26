public class MaximumLengthofPairChain {
     public int FindLongestChain(int[][] pairs)
    {
        Array.Sort(pairs, (object arr1, object arr2) => ((int[])arr1)[1].CompareTo(((int[])arr2)[1]));

        var result = 0;
        var curr = int.MinValue;
        foreach(var p in pairs)
        {
            if(curr < p[0])
            {
                result++;
                curr = p[1];
            }
        }

        return result;

    }
}