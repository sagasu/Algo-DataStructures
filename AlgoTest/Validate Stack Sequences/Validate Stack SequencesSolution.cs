using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.Validate_Stack_Sequences
{
    [TestClass]
    public class Validate_Stack_SequencesSolution
    {
        [TestMethod]
        public void Test() =>
            Assert.IsTrue(ValidateStackSequences(new int[] { 1, 2, 3, 4, 5 }, new int[] { 4, 5, 3, 2, 1 }));

        public bool ValidateStackSequences(int[] pushed, int[] popped)
        {
            var stack = new Stack<int>();
            var poppedInx = 0;
            for (var i = 0; i < pushed.Length; i++)
            {
                var item = pushed[i];
                stack.Push(item);
                while(stack.Count >0 && stack.Peek() == popped[poppedInx])
                {
                    stack.Pop();
                    poppedInx++;
                }
            }

            return poppedInx == popped.Length;
        }
    }
}
