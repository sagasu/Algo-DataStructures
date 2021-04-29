using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Find_First_and_Last_Position_of_Element_in_Sorted_Array
{
    [TestClass]
    public class Find_First_and_Last_Position_of_Element_in_Sorted_Array
    {
        [TestMethod]
        public void Test()
        {
            var t = new int[] {5, 7, 7, 8, 8, 10};
            CollectionAssert.AreEqual(new int[]{3,4}, SearchRange(t, 8));
        }
        
        [TestMethod]
        public void Test2()
        {
            var t = new int[] { 5, 7, 7, 8, 8, 10 };
            CollectionAssert.AreEqual(new int[]{-1,-1}, SearchRange(t, 6));
        }
        
        [TestMethod]
        public void Test3()
        {
            var t = new int[] {};
            CollectionAssert.AreEqual(new int[]{-1,-1}, SearchRange(t, 0));
        }
        
        [TestMethod]
        public void Test4()
        {
            var t = new int[] {2, 2};
            CollectionAssert.AreEqual(new int[]{ 0, 1}, SearchRange(t, 2));
        }
        
        [TestMethod]
        public void Test5()
        {
            var t = new int[] {1};
            CollectionAssert.AreEqual(new int[]{ 0, 0}, SearchRange(t, 1));
        }

        public int[] SearchRange(int[] nums, int target)
        {
            if (nums.Length == 0) return new[] {-1, -1};

            int BST(int trg)
            {
                var start = 0;
                var end = nums.Length;

                bool Good(int mid) => nums[mid] >= trg;

                while (start < end)
                {
                    var mid = (start + end) / 2;
                    if (Good(mid)) end = mid;
                    else start = mid + 1;
                }

                return start;
            }

            var ans = new int[] {BST(target), BST(target + 1) - 1};
            if(ans[0] >= nums.Length || nums[ans[0]] != target) return new int[]{ -1, -1};
            return ans;
        }
    }
}
