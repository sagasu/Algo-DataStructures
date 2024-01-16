using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Insert_Delete_GetRandom_O_1____Duplicates_allowed;

public class Insert_Delete_GetRandom_O_1____Duplicates_allowed
{

        Dictionary<int, HashSet<int>> idx = new();
        List<int> list = new();
        Random rand = new();

        public bool Insert(int val) {
            if (!idx.TryGetValue(val, out var indices))
                idx[val] = indices = new HashSet<int>();
            indices.Add(list.Count);
            list.Add(val);
            return indices.Count == 1;
        }

        public bool Remove(int val) {
            if (!idx.TryGetValue(val, out var indices) || indices.Count == 0)
                return false;
            var indexToRemove = indices.Last();
            list[indexToRemove] = list.Last();
            indices.Remove(indexToRemove);
            idx[list.Last()].Add(indexToRemove);
            idx[list.Last()].Remove(list.Count - 1);
            list.RemoveAt(list.Count - 1);
            return true;
        }

        public int GetRandom() => list[rand.Next(list.Count)];
    
}