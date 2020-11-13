using System.Collections.Generic;

namespace Algo.Fibonacci
{
    public class Fibonacci
    {
        private Dictionary<int, int> Mem = new Dictionary<int, int>();
        public int Calculate(int n) {
            if (Mem.ContainsKey(n))
                return Mem[n];

            if (n == 1) return 1;
            if (n == 2) return 1;

            var fib = Calculate(n - 1) + Calculate(n - 2);
            Mem.Add(n, fib);

            return fib;
        }
    }
}
