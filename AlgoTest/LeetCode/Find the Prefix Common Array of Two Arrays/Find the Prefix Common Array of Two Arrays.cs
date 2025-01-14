namespace AlgoTest.LeetCode.Find_the_Prefix_Common_Array_of_Two_Arrays;

public class Find_the_Prefix_Common_Array_of_Two_Arrays
{
    public int[] FindThePrefixCommonArray(int[] A, int[] B) {
        var n = A.Length;
        var prefixCommonArray = new int[n];
        var frequency = new int[n + 1];
        var commonCount = 0;

        for (int currentIndex = 0; currentIndex < n; ++currentIndex) {
            frequency[A[currentIndex]] += 1;
            if (frequency[A[currentIndex]] == 2) ++commonCount;

            frequency[B[currentIndex]] += 1;
            if (frequency[B[currentIndex]] == 2) ++commonCount;

            prefixCommonArray[currentIndex] = commonCount;
        }

        return prefixCommonArray;
    }
}