using System;

namespace AlgoTest.LeetCode.Distribute_Coins_in_Binary_Tree;

public class Distribute_Coins_in_Binary_Tree
{
    public int DistributeCoins(TreeNode root) {
        var (_, totalMoves) = Traverse(root);
        return totalMoves;
    
        (int, int) Traverse(TreeNode node) {
            if (node == null) return (0, 0);
            var (localMovesL, totalMovesL) = Traverse(node.left); 
            var (localMovesR, totalMovesR) = Traverse(node.right); 
            var localMoves = localMovesL + localMovesR + node.val - 1;
            return (localMoves, totalMovesL + totalMovesR + Math.Abs(localMoves));
        }
    }
}