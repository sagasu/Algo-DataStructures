namespace AlgoTest.LeetCode.Decode_Ways_Again;

public class Decode_Ways
{
    public int NumDecodings(string s) {
        var n = s.Length;

        if (n == 0) return 0;
        if (n == 1) 
            return isValid(s[0]) ? 1 : 0;
        
        var prePre = 1;
        var pre = isValid(s[0]) ? 1 : 0;

        for (int i = 1; i < n; i++) {
            var cur = 0;
            if (isValid(s[i])) 
                cur += pre;

            if (isValid(s[i - 1], s[i])) 
                cur += prePre;
            

            if (cur == 0) 
                return 0;
            

            prePre = pre;
            pre = cur;
        }

        return pre;
    }

    private bool isValid(char c) {
        if ('1' <= c && c <= '9') return true;
        
        return false;
    }

    private bool isValid(char c1, char c2) {
        if (c1 == '1') 
            return true;
        
        if (c1 == '2' && ('0' <= c2 && c2 <= '6')) 
            return true;
        
        return false;
    }
}