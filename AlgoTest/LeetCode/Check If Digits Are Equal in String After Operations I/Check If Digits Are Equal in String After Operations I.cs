namespace AlgoTest.LeetCode.Check_If_Digits_Are_Equal_in_String_After_Operations_I;

public class Check_If_Digits_Are_Equal_in_String_After_Operations_I
{
    public bool HasSameDigits(string s) {
        int iteration = 0;
        char[] arr = s.ToCharArray();

        while (arr.Length - iteration != 2) {
            for (int i = 0; i < arr.Length - 1 - iteration; i++) {
                arr[i] = (char)(((arr[i] - '0') + (arr[i + 1] - '0')) % 10 + '0');
            }
            iteration++;
        }

        return arr[0] == arr[1];
    }
}