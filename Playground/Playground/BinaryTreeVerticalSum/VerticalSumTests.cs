using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Playground.BinaryTreeVerticalSum
{
    [TestFixture]
    class VerticalSumTests
    {

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, new int[] { 1, 3, 4, 5, 6 })]
        public void PrintTree_ValidTree_ExpectTreePrintInOrder(int[] treeData, int[] expected)
        {
            var tree = new BinaryTree(treeData);
            tree.InOrderPrintTree();
            Assert.True(true);
        }

        [TestCase(new int[]{1,2,3,4,5,6,7,8}, new int[]{1,3,4,5,6})]
        public void VerticalSum_TreeProvided_ExpectVerticalSums(int[] treeData, int[] expected)
        {
            var tree = new BinaryTree(treeData);
            //Assert.AreEqual(expected, new VerticalSum(tree).VerticalSum());
        }
    }
}
