using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Keys_and_Rooms
{
    [TestClass]
    public class Keys_and_Rooms
    {
        [TestMethod]
        public void Test()
        {
            var t = new List<IList<int>> {new List<int> {1}, new List<int> {2}, new List<int> {3}, new List<int> { }};
            Assert.AreEqual(true, CanVisitAllRooms(t));
        }

        [TestMethod]
        public void Test2()
        {
            var t = new List<IList<int>> { new List<int> { 1, 3 }, new List<int> { 3, 0, 1 }, new List<int> { 2 }, new List<int> { 0 } };
            Assert.AreEqual(false, CanVisitAllRooms(t));
        }

        public bool CanVisitAllRooms(IList<IList<int>> rooms)
        {
            var visited = new bool[rooms.Count];
            var stack = new Stack<int>();
            stack.Push(0);

            int key;
            while (stack.TryPop(out key))
            {
                if(visited[key]) continue;
                visited[key] = true;

                foreach (var i in rooms[key])
                {
                    if(!visited[i]) stack.Push(i); 
                }
            }

            return visited.All(x => x);
        }

    }
}
