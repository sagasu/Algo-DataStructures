using System.Collections.Generic;

namespace AlgoTest.Validate_Stack_Sequences
{
    internal class Validate_Stack_Sequences
    {
        public bool ValidateStackSequences(int[] pushed, int[] popped)
        {
            var st = new Stack<int>();
            var j = 0;

            foreach (var item in pushed)
            {
                st.Push(item);
                while (st.Count > 0 && st.Peek() == popped[j])
                {
                    st.Pop();
                    j++;
                }
            }

            return j == popped.Length;
        }
    }
}
