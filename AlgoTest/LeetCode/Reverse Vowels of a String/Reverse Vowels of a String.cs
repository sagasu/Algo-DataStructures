public class Solution17 {
    public string ReverseVowels(string s) {
            var ss = s.ToCharArray();

            int a = 0, b = s.Length - 1;

            while (a < b)
            {
                while ("aeiouAEIOU".IndexOf(ss[a]) == -1 && a <= b - 1) a++;

                while ("aeiouAEIOU".IndexOf(ss[b]) == -1 && b >= a + 1) b--;

                if (a == b) return new string(ss);

                var h = ss[a];

                ss[a++] = ss[b];

                ss[b--] = h;
            }

            return new string(ss);
    }
}