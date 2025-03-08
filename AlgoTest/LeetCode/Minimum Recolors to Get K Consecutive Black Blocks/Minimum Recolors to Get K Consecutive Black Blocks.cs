namespace AlgoTest.LeetCode.Minimum_Recolors_to_Get_K_Consecutive_Black_Blocks;

public class Minimum_Recolors_to_Get_K_Consecutive_Black_Blocks
{
    public int MinimumRecolors(string blocks, int k) {
        // prime the sliding window with the first k elements
        int head=0, whiteCount=0;
        for(;head<k;) {
            if(blocks[head++]=='W') whiteCount++;
        }
        // advance the window and find the minimum white count
        int tail=0, minWhiteCount=whiteCount;
        for(;head<blocks.Length;) {
            if(blocks[head++]=='W') whiteCount++;
            if(blocks[tail++]=='W') whiteCount--;
            if(whiteCount<minWhiteCount) minWhiteCount=whiteCount;
        }
        return minWhiteCount;
    }
}