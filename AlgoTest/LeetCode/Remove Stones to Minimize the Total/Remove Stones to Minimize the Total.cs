public class Solution {
    public int MinStoneSum(int[] piles, int k) {
        PriorityQueue<int,int> heap = new();
        int ans=0;
        
        foreach(int x in piles){
            heap.Enqueue(x,-x);  //using -x as priority as poor's man Maxheap
            ans+=x; // calculating initial sum now instead of at very end
        }
        
        while(k>0){
            int y = heap.Dequeue();
            int z = y/2; //floor division out of the box for int
            heap.Enqueue(y-z,z-y); //Need to add to the heap the remaining amount y-z; and use priority -(y-z)=z-y
            ans-=z; //substract amount z from initial sum
            k--;
        }
        
        return ans;
    }
}