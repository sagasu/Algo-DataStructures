using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Dota2_Senate
{
    internal class Dota2_Senate
    {
        public string PredictPartyVictory(string senate)
        {
            var queue = new Queue<char>();
            var toDeleteMap = new Dictionary<char, int>();
            toDeleteMap.Add('R', 0);
            toDeleteMap.Add('D', 0);

            foreach (var s in senate) queue.Enqueue(s);
            

            while (queue.Count > 0)
            {
                var count = queue.Count;
                var isDeleted = false;

                while (count-- > 0)
                {
                    var currentSenate = queue.Dequeue();
                    var toDelete = currentSenate == 'D' ? 'R' : 'D';

                    if (toDeleteMap[currentSenate] == 0)
                    {
                        toDeleteMap[toDelete]++;
                        queue.Enqueue(currentSenate);
                    }
                    else
                    {
                        isDeleted = true;
                        toDeleteMap[currentSenate]--;
                    }
                }

                if (!isDeleted) break;
                
            }

            return toDeleteMap['R'] == 0 ? "Radiant" : "Dire";
        }
    }
}
