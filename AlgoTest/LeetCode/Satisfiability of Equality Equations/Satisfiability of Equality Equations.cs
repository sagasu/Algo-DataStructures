using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Satisfiability_of_Equality_Equations
{
    internal class Satisfiability_of_Equality_Equations
    {
        public bool EquationsPossible(string[] equations)
        {
            var uf = Enumerable.Range(0, 26 + 'a').ToArray();
            var eqs = equations.Where(x => x[1] == '=').Select(x => (x[0], x[3]));
            var neqs = equations.Where(x => x[1] == '!').Select(x => (x[0], x[3]));

            foreach (var (a, b) in eqs)
                uf[GetRoot(a)] = GetRoot(b);
            

            foreach (var (a, b) in neqs)
                if (GetRoot(a) == GetRoot(b)) return false;
            

            return true;

            int GetRoot(int i)
            {
                while (uf[i] != i)
                    i = uf[i] = uf[uf[i]];
                
                return i;
            }
        }
	}
}
