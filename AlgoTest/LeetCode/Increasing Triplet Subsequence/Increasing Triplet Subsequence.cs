public class IncreasingTripletSubsequence {
    public bool IncreasingTriplet(int[] nums) {
        var n = nums.Length;

        var min1 = int.MaxValue;
        var min2 = int.MaxValue;

        for (int i = 0; i < n; i++) {
            var cur = nums[i];
            if (cur > min1 && cur > min2) {
                return true;
            }

            if (cur < min1) {
                min1 = nums[i];
            } else if (cur < min2 && cur > min1) {
                min2 = nums[i];
            }
        }

        return false;
    }
}