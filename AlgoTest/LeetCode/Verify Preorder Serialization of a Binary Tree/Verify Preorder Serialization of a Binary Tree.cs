using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Verify_Preorder_Serialization_of_a_Binary_Tree
{
    [TestClass]
    public class Verify_Preorder_Serialization_of_a_Binary_Tree
    {

        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(true, IsValidSerialization("9,3,4,#,#,1,#,#,2,#,6,#,#"));
            Assert.AreEqual(false, IsValidSerialization("1,#"));
            Assert.AreEqual(false, IsValidSerialization("9,#,#,1"));
        }

        public bool IsValidSerialization(string preorder)
        {
            var tree = preorder.Split(',');
            var index = 0;
            var good = true;

            void Preorder()
            {
                if (index >= tree.Length)
                {
                    good = false;
                    return;
                }

                if (tree[index] == "#")
                {
                    index += 1;
                    return;
                }

                index += 1;
                Preorder();
                Preorder();
            }

            Preorder();
            return good && index == tree.Length;
        }
    }
}
