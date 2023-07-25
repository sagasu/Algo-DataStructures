public class PeakIndexinaMountainArray {
    public int PeakIndexInMountainArray(int[] arr) => helper(arr, 0, arr.Length -1);
    
    public int helper(int[] arr, int start, int end) {
        var mid = (start + end + 1)/2;

        if(arr[mid-1] < arr[mid] && arr[mid] > arr[mid+1]) 
            return mid;
        
        if(arr[mid-1] < arr[mid] && arr[mid] < arr[mid+1]) 
            return helper(arr, mid, end);
        
        return helper(arr, start, mid);
    }
}