public class PutMarblesinBags {
    public long PutMarbles(int[] weights, int k) {
        int n = weights.Length - 1;
        int[] neighbourSum = new int[n];
        for (int i = 0; i < n; i++)
        {
            neighbourSum[i] = weights[i] + weights[i + 1];
        }
        Array.Sort(neighbourSum);

        long result = 0;
        for (int i = 0; i < k - 1; i++)
        {
            result += neighbourSum[n - 1 - i] - neighbourSum[i];
        }
        return result;
    }
}