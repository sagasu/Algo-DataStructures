namespace AlgoTest.LeetCode.BreakAPalidrome
{
    internal class BreakAPalidrome
    {
        public string BreakPalindrome(string palindrome)
        {
            if (palindrome == null || palindrome.Length <= 1)
                return "";

            var arr = palindrome.ToCharArray();
            var i = 0;
            for (; i < arr.Length / 2; i++)
            {
                if (arr[i] != 'a')
                {
                    arr[i] = 'a';
                    break;
                }
            }

            if (i == arr.Length / 2)
                arr[arr.Length - 1] = 'b';

            return new string(arr);
        }
    }
}
