namespace AlgoTest.LeetCode.Pass_the_Pillow;

public class Pass_the_Pillow
{
    public int PassThePillow(int n, int time) {
        var div = time/(n-1);
        var mod = time%(n-1);
        return div%2 == 0 ? 1+mod : n-mod;
    }
}