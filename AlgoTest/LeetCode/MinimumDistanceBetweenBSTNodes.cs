public class Solution {
    public int MinDiffInBST(TreeNode root) {
        var list = new List<int>();
        InOrder(root, list);
        var res = int.MaxValue;
        for(var i = 1; i<list.Count; i++){
            var d = list[i] - list[i-1];
            if(d<res){
                res = d;
            }
        }
        return res;
    }
    
    public void InOrder(TreeNode root, List<int> values){
        if(root.left !=null){
            InOrder(root.left, values);
        }
        values.Add(root.val);
        if(root.right !=null){
            InOrder(root.right, values);
        }
    }
}
