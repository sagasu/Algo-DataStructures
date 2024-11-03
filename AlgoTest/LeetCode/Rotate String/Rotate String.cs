namespace AlgoTest.LeetCode.Rotate_String;

public class Rotate_String
{
    public bool RotateString(string s, string goal) => s.Length ==goal.Length && (s+s).Contains(goal);
}