using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Count_All_Possible_Routes
{
    internal class Count_All_Possible_Routes
    {
        public int CountRoutes(int[] locations, int start, int finish, int fuel) {
            cache = new int[locations.Length][];
            for(int i=0;i<locations.Length;i++)
            {
                cache[i] = new int[fuel+1];
                Array.Fill(cache[i],-1);
            }
            return DP(locations,start,finish,fuel);
        }

        private int[][] cache;
        private int MOD = (int)Math.Pow(10,9)+7;

        private int DP(int[] locations, int curr, int finish, int fuel)
        {
            if(cache[curr][fuel] != -1)
                return cache[curr][fuel];
            int result = curr == finish ? 1 : 0;
            for(int i=0;i<locations.Length;i++)
            {
                int fuelReq = Math.Abs(locations[i]-locations[curr]);
                if(i!=curr && fuelReq <= fuel)
                    result = (result + DP(locations,i,finish,fuel-fuelReq)) % MOD;
            }
            return cache[curr][fuel] = result;
        }
    }
}
