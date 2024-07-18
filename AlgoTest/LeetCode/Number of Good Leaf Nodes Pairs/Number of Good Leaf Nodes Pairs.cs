using System.Collections.Generic;

namespace AlgoTest.LeetCode.Number_of_Good_Leaf_Nodes_Pairs;

public class Number_of_Good_Leaf_Nodes_Pairs
{
    public int CountPairs(TreeNode root, int distance) {
        int count = 0;
        GetLeafDistances(root, distance, ref count);
        return count;
    }

    private List<int> GetLeafDistances(TreeNode node, int distance, ref int count) {
        if (node == null) return new List<int>();
        
        if (node.left == null && node.right == null) {
            return new List<int> { 1 };
        }
        
        List<int> leftDistances = GetLeafDistances(node.left, distance, ref count);
        List<int> rightDistances = GetLeafDistances(node.right, distance, ref count);
        
        foreach (int leftDist in leftDistances) {
            foreach (int rightDist in rightDistances) {
                if (leftDist + rightDist <= distance) {
                    count++;
                }
            }
        }
        
        List<int> currentDistances = new List<int>();
        foreach (int leftDist in leftDistances) {
            if (leftDist + 1 <= distance) {
                currentDistances.Add(leftDist + 1);
            }
        }
        foreach (int rightDist in rightDistances) {
            if (rightDist + 1 <= distance) {
                currentDistances.Add(rightDist + 1);
            }
        }
        
        return currentDistances;
    }
}