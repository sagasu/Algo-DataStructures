namespace AlgoTest.LeetCode.Add_Binary;

public class Add_Binary
{
    public string AddBinary(string a, string b) {
        int i = a.Length - 1;
        int j = b.Length - 1;
        int carry = 0;
        var result = new System.Text.StringBuilder();

        while (i >= 0 || j >= 0 || carry > 0) {
            int bitA = (i >= 0) ? a[i] - '0' : 0;
            int bitB = (j >= 0) ? b[j] - '0' : 0;

            int sum = bitA + bitB + carry;
            result.Insert(0, (sum % 2).ToString());
            carry = sum / 2;

            i--;
            j--;
        }

        return result.ToString();
    }
}