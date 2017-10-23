using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.PrintAllSubsets
{
    class PrintAllSubsets
    {
        public void PrintAllKSizeSubsets(int[] set, int k)
        {
            PrintAllKSizeSubsets(set, new bool[set.Length], 0, k, 0);
        }

        private void PrintAllKSizeSubsets(int[] set, bool[] used, int index, int k, int currentSize)
        {
            if (currentSize == k)
            {
                for (int i = 0; i < set.Length; i++)
                {
                    if (used[i])
                    {
                        Console.Out.Write(set[i] + " ");
                    }
                }
                Console.Out.WriteLine();
                return;
            }

            if (index >= set.Length)
                return;

            used[index] = true;
            PrintAllKSizeSubsets(set, used, index + 1, k, currentSize + 1);
            used[index] = false;
            PrintAllKSizeSubsets(set, used, index + 1, k, currentSize);
        }
    }
}
