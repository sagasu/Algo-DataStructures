using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Construct_Quad_Tree
{
    internal class Construct_Quad_Tree
    {
        public Node Construct(int[][] grid) => Construct(grid, 0, grid.Length - 1, 0, grid[0].Length - 1);
        
        public Node Construct(int[][] grid, int xlow, int xhigh, int ylow, int yhigh)
        {
            if (xlow == xhigh || AreAllElementsSame(grid, xlow, xhigh, ylow, yhigh))
                return new Node(grid[xlow][ylow] == 1, true);
            
            var node = new Node(true, false);
            var midX = (xlow + xhigh) / 2;
            var midY = (ylow + yhigh) / 2;

            node.topLeft = Construct(grid, xlow, midX, ylow, midY);
            node.topRight = Construct(grid, xlow, midX, midY + 1, yhigh);
            node.bottomLeft = Construct(grid, midX + 1, xhigh, ylow, midY);
            node.bottomRight = Construct(grid, midX + 1, xhigh, midY + 1, yhigh);

            return node;
        }

        public bool AreAllElementsSame(int[][] grid, int xlow, int xhigh, int ylow, int yhigh)
        {
            var oneFound = false;
            var zeroFound = false;
            for (var i = xlow; i <= xhigh; i++)
            {
                for (var j = ylow; j <= yhigh; j++)
                {
                    if (grid[i][j] == 1) oneFound = true;
                    else zeroFound = true;
                    
                    if (oneFound == true && zeroFound == true) return false;
                }
            }

            return true;
        }
    }

    public class Node
    {
        public bool val;
        public bool isLeaf;
        public Node topLeft;
        public Node topRight;
        public Node bottomLeft;
        public Node bottomRight;

        public Node()
        {
            val = false;
            isLeaf = false;
            topLeft = null;
            topRight = null;
            bottomLeft = null;
            bottomRight = null;
        }

        public Node(bool _val, bool _isLeaf)
        {
            val = _val;
            isLeaf = _isLeaf;
            topLeft = null;
            topRight = null;
            bottomLeft = null;
            bottomRight = null;
        }

        public Node(bool _val, bool _isLeaf, Node _topLeft, Node _topRight, Node _bottomLeft, Node _bottomRight)
        {
            val = _val;
            isLeaf = _isLeaf;
            topLeft = _topLeft;
            topRight = _topRight;
            bottomLeft = _bottomLeft;
            bottomRight = _bottomRight;
        }
    }
}
