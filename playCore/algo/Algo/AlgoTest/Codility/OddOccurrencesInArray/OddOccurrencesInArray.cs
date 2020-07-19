using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.Codility.OddOccurrencesInArray
{
    public class OddOccurrencesInArray
    {
        public int solution(int[] A)
        {
            var dic = new Dictionary<int, int>();
            foreach (var element in A)
            {
                if (dic.ContainsKey(element))
                {
                    dic[element] += 1;
                }
                else
                {
                    dic.Add(element,1);
                }
            }

            foreach (var dicKey in dic.Keys)
            {
                if (dic[dicKey] == 1) return dicKey;
            }

            throw new ArgumentException("Incorrect collection");
        }
    }
}
