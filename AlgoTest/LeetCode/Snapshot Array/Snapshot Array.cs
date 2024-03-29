﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Snapshot_Array
{
    [TestClass]
    public class TestSnapshot_Array
    {
        [TestMethod]
        public void Test()
        {
            var sa = new SnapshotArray(1);
            sa.Set(0, 15);
            Assert.AreEqual(0, sa.Snap());
            Assert.AreEqual(1, sa.Snap());
            Assert.AreEqual(2, sa.Snap());
            Assert.AreEqual(15, sa.Get(0, 2));
            Assert.AreEqual(3, sa.Snap());
            Assert.AreEqual(4, sa.Snap());
            Assert.AreEqual(15, sa.Get(0, 0));
        }
    }

    // also out of memory solution
    public class SnapshotArray
    {

        private Dictionary<int,Dictionary<int,int>> snaps = new();
        private int snapId = 0;

        public SnapshotArray(int length)
        {
            snaps[snapId] = new Dictionary<int, int>();
        }

        public void Set(int index, int val) => snaps[snapId][index] = val;
        
        public int Snap()
        {
            var snap = new Dictionary<int, int>(snaps[snapId]);

            snaps.Add(++snapId, snap);
            return snapId-1;
        }

        public int Get(int index, int snap_id) => snaps[snap_id].ContainsKey(index) ? snaps[snap_id][index]: 0;
        
    }

    // out of memory solution
    public class SnapshotArray_Timeout
    {
        private int[] curr;
        private List<int[]> snaps = new();
        private int snapId = 0;
        public SnapshotArray_Timeout(int length)
        {
            curr = new int[length];
        }

        public void Set(int index, int val) => curr[index] = val;
        

        public int Snap()
        {
            var newArr = new int[curr.Length];
            Array.Copy(curr, newArr, curr.Length);

            snaps.Add(newArr);
            return snapId++;
        }

        public int Get(int index, int snap_id) => snaps[snap_id][index];
        
    }
}
