using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.CourseSchedule
{
    [TestClass]
    public class CourseSchedule
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(true, CanFinish(2, new int[][] { new[] { 1, 0 } }));
            Assert.AreEqual(false, CanFinish(2, new int[][] { new[] { 1, 0 }, new[] { 0, 1 } }));
            // this one is an interesting one, because it looks like a problem makes an assumption that really number of courses available is cumCourse
            // And simply not all courses are named in prerequisites list. If they don't exist there it means that they don't have a prerequisite. 
            Assert.AreEqual(true, CanFinish(3, new int[][] { new[] { 1, 0 } }));
        }

        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            int[] pre = new int[numCourses];

            for (var i = 0; i < prerequisites.Length; i++)
            {
                pre[prerequisites[i][0]] += 1;
            }

            var courses = 0;
            Stack<int> st = new Stack<int>(numCourses);
            for (var i = 0; i < numCourses; i++)
            {
                if (pre[i] == 0)
                {
                    st.Push(i);
                    courses += 1;
                }
            }

            if (courses >= numCourses)
                return true;

            while (st.Count > 0)
            {
                var element = st.Pop();
                for (var i = 0; i < prerequisites.Length; i++)
                {
                    if (prerequisites[i][1] == element)
                    {
                        pre[prerequisites[i][0]] -= 1;
                        if (pre[prerequisites[i][0]] == 0)
                        {
                            st.Push(prerequisites[i][0]);
                            courses += 1;
                            if (courses >= numCourses)
                                return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}
