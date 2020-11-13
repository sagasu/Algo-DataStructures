using System;
using System.Collections.Generic;
using System.Linq;
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
                    dic.Remove(element);
                }
                else
                {
                    dic.Add(element,1);
                }
            }

            return dic.Keys.First();
        }
    }
}
