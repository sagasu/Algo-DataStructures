namespace AlgoTest.LeetCode.Minimum_Number_of_Seconds_to_Make_Mountain_Height_Zero;

public class Minimum_Number_of_Seconds_to_Make_Mountain_Height_Zero
{
    public long MinNumberOfSeconds(int mountainHeight, int[] workerTimes) {
        int minW = workerTimes[0];
        int maxW = minW;
        int minIdx = 0;
        
        for (int i = 1; i < workerTimes.Length; i++) {
            int w = workerTimes[i];
            if (w < minW) {
                minW = w;
                minIdx = i; 
            } else if (w > maxW) {
                maxW = w;
            }
        }
        
        if (minIdx != 0) {
            workerTimes[minIdx] = workerTimes[0];
            workerTimes[0] = minW;
        }
        
        long ceilH = (mountainHeight + 0L + workerTimes.Length - 1) / workerTimes.Length;
        long tasks = ceilH * (ceilH + 1) / 2L;
        
        long l = tasks * minW;
        long r = tasks * maxW;
        long ans = r;
        
        while (l <= r) {
            long mid = l + ((r - l) >> 1); 
            long mid2 = mid << 1;          
            long sum = 0; 
            
            for (int i = 0; i < workerTimes.Length; i++) {
                long val = mid2 / workerTimes[i]; 
                if (val >= 2) {
                    long x = (long)System.Math.Sqrt(val);
                    if (x * (x + 1) > val) x--;
                    
                    if ((sum += x) >= mountainHeight) break;
                }
            }
            
            if (sum >= mountainHeight) {
                ans = mid;
                r = mid - 1; 
            } else {
                l = mid + 1;
            }
        }
        
        return ans;
    }
}