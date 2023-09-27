namespace AlgoTest.LeetCode.Decoded_String_at_Index;

public class Decoded_String_at_Index
{
    public string DecodeAtIndex(string s, int k) {
        int i;
        long n = 0;

        for(i = 0; n < k; i++) 
            n = s[i] >= '2' && s[i] <= '9' ? n * (s[i] - '0') : n + 1;
        
        for (i--; i > 0; i--) {
            if (s[i] >= '2' && s[i] <= '9') {
                n /= s[i] - '0';
                k = (int)(k%n);
            }
            else {
                if (k % n == 0) 
                    break;
                
                n--;
            }
        }

        return s[i].ToString();
    }
}