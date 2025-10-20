namespace AlgoTest.LeetCode.Final_Value_of_Variable_After_Performing_Operations;

public class Final_Value_of_Variable_After_Performing_Operations
{
    public int FinalValueAfterOperations(string[] operations) {
        int x = 0;
        foreach (var op in operations) {
            if (op[1] == '+') x++;
            else x--;
        }
        return x;
    }
}