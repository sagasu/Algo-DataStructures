using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.AsteroidCollision
{
    [TestClass]
    public class AsteroidCollisionSolution
    {

        [TestMethod]
        public void Test()
        {
            //var t = new int[] {5, 10, -5};
            //CollectionAssert.AreEqual(new int[]{5,10}, AsteroidCollision(t));
            
            var t= new int[] { 10, 2, -5};
            CollectionAssert.AreEqual(new int[]{10}, AsteroidCollision(t));

            //var t = new int[] { 8, -8 };
            //CollectionAssert.AreEqual(new int[] { }, AsteroidCollision(t));
        }

        public int[] AsteroidCollision(int[] asteroids)
        {
            if (asteroids == null || asteroids.Length == 0 ||asteroids.Length == 1)
                return asteroids;

            var stack = new Stack<int>();
            stack.Push(asteroids[0]);
            for (var i = 1; i < asteroids.Length; i++)
            {
                var asteroid = asteroids[i];
                if (asteroid > 0)
                {
                    stack.Push(asteroid);
                }
                else
                {
                    Colide(stack, asteroid);
                }
            }

            return stack.Reverse().ToArray();
        }

        private void Colide(Stack<int> stack, int asteroid)
        {
            if (stack.Count == 0)
            {
                stack.Push(asteroid);
                return;
            }

            if (stack.Peek() > 0)
            {
                var pop = stack.Pop();
                if (pop == -asteroid) return;
                if(pop > -asteroid)
                    stack.Push(pop);
                else
                    Colide(stack, asteroid);
            }
            else
            {
                stack.Push(asteroid);
            }
        }
    }
}
