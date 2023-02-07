public class ShuffletheArray
{
    public int[] Shuffle(int[] nums, int n) {
        var ret = new int[nums.Length];
        for(var i = 0; i < n;i++){
            ret[i*2] = nums[i];
            ret[i*2+1] = nums[n+i];
        }
        return ret;
    }
}