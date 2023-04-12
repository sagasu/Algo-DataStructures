using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Course_Schedule
{
    [TestClass]
    public class Course_Schedule
    {
        [TestMethod]
        public void Test()
        {
            Assert.IsTrue(CanFinish(2, new int[][]{new int[]{1,0}}));
        }
        
        
        [TestMethod]
        public void Test2() => Assert.IsFalse(CanFinish(2, new int[][]{new int[]{1,0}, new int[]{0,1} }));
        
        [TestMethod]
        public void Test3() => Assert.IsTrue(CanFinish(1, new int[][]{}));
        
        [TestMethod]
        public void Test4() => Assert.IsTrue(CanFinish(5, new int[][]{new int[]{ 1, 4}, new int[]{2, 4}, new []{3, 1}, new int[]{3, 2} }));
        

        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            if(prerequisites.Length == 0) return true;
            var courses = new int[numCourses];
            foreach (var prerequisite in prerequisites) courses[prerequisite[0]]++;

            var stack = new Stack<int>();
            var found = 0;
            for (var i = 0; i < courses.Length; i++)
                if (courses[i] == 0)
                {
                    stack.Push(i);
                    found++;
                }
            

            while (stack.Count > 0)
            {
                var course = stack.Pop();
                for (var i = 0; i < prerequisites.Length; i++)
                {
                    if (prerequisites[i][1] == course)
                    {
                        courses[prerequisites[i][0]]--;
                        if (courses[prerequisites[i][0]] == 0)
                        {
                            stack.Push(prerequisites[i][0]);
                            found++;
                            if (found == numCourses) return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}
