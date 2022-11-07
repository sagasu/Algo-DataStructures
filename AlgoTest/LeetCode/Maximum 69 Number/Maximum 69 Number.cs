public class Solution {
    public int Maximum69Number (int num) {
        var n = new StringBuilder(num.ToString());
        var firstIndex = n.ToString().IndexOf('6');
        if(firstIndex == -1) return num;
        n[firstIndex] = '9';
        return int.Parse(n.ToString());
    }
}