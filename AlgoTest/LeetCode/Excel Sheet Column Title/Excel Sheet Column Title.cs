namespace AlgoTest.LeetCode.Excel_Sheet_Column_Title;

public class Excel_Sheet_Column_Title
{
    public string ConvertToTitle(int c) =>
        (--c < 26 ? "" : ConvertToTitle(c / 26)) + (char)(c % 26 + 'A');
}