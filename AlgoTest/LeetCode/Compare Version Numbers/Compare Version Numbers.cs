namespace AlgoTest.LeetCode.Compare_Version_Numbers;

public class Compare_Version_Numbers
{
    public int CompareVersion(string a, string b) {
        int i = 0, j = 0, n = a.Length, m = b.Length;
        while (i < n || j < m) {
            long x = 0, y = 0;
            // scoop number from a
            while (i < n && a[i] != '.') x = x * 10 + (a[i++] - '0');
            if (i < n && a[i] == '.') i++;
            // scoop number from b
            while (j < m && b[j] != '.') y = y * 10 + (b[j++] - '0');
            if (j < m && b[j] == '.') j++;
            if (x < y) return -1;
            if (x > y) return 1;
        }
        return 0;
    }
}