using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Simplify_Path
{
    [TestClass]
    public class Simplify_PathSolution
    {
        [TestMethod]
        public void Test() => Assert.AreEqual("/home", SimplifyPath("/home/"));
        
        [TestMethod]
        public void Test2() =>
            Assert.AreEqual("/", SimplifyPath("/../"));
        
        
        [TestMethod]
        public void Test3() => Assert.AreEqual("/home/foo", SimplifyPath("/home//foo/"));
        
        public string SimplifyPath(string path)
        {
            var stack = new Stack<string>();
            var paths = path.Split('/',StringSplitOptions.RemoveEmptyEntries);
            for (var i = 0; i < paths.Length; i++)
            {
                if (paths[i] == ".") continue;
                if (paths[i] == "..") stack.TryPop(out _);
                else stack.Push(paths[i]);
            }

            return "/" + string.Join('/', stack.Reverse());
        }
    }
}
