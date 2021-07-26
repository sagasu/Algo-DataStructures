/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public TreeNode SortedArrayToBST(int[] nums) {
        TreeNode Build(int left, int right){
            if(left == right) return new TreeNode(nums[left]);
            if(left > right) return null;
            
            var middle = (int)((left + right) / 2);
            var current = new TreeNode(nums[middle]){
                left = Build(left, middle -1),
                right = Build(middle + 1, right)
            };
            return current;
        }
        return Build(0, nums.Length -1);
    }
}
