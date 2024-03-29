﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.AOC2022
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    namespace AlgoTest.AOC2021
    {
        [TestClass]
        public class Day2
        {
            private Dictionary<string, int> playDic = new Dictionary<string, int>()
            {
                { "X", 1 },
                { "Y", 2 },
                { "Z", 3 },
            };

            private Dictionary<string, int> scoreDic = new Dictionary<string, int>()
            {
                { "AX", 3 },
                { "AY", 6 },
                { "AZ", 0 },
                { "BX", 0 },
                { "BY", 3 },
                { "BZ", 6 },
                { "CX", 6 },
                { "CY", 0 },
                { "CZ", 3 },
            };

            private Dictionary<string, (int, string)> score2Dic = new Dictionary<string, (int, string)>()
            {
                { "AX", (0,"Z") },
                { "AY", (3,"X") },
                { "AZ", (6,"Y") },
                { "BX", (0,"X") },
                { "BY", (3,"Y") },
                { "BZ", (6,"Z") },
                { "CX", (0,"Y") },
                { "CY", (3,"Z") },
                { "CZ", (6,"X") },
            };

            [TestMethod]
            public void Test1()
            {
                var data = realData;
                var score = 0;
                for (var i = 0; i < data.Length; i++)
                {
                    var sc = data[i].Item1 + data[i].Item2;
                    score += scoreDic[sc] + playDic[data[i].Item2];
                }

                Assert.AreEqual(13809, score);
            }

            [TestMethod]
            public void Test2()
            {
                var data = realData;
                var score = 0;
                for (var i = 0; i < data.Length; i++)
                {
                    var sc = data[i].Item1 + data[i].Item2;
                    score += score2Dic[sc].Item1 + playDic[score2Dic[sc].Item2];
                }

                Assert.AreEqual(12316, score);
            }

            (string, string)[] realData = new[]
            {
                ("C","X"),
("C","X"),
("A","Y"),
("C","X"),
("B","Y"),
("A","X"),
("A","Z"),
("B","Y"),
("C","Z"),
("C","Z"),
("B","X"),
("C","Z"),
("B","Y"),
("C","Z"),
("B","Y"),
("A","Z"),
("B","Y"),
("C","X"),
("C","X"),
("C","X"),
("B","X"),
("C","Z"),
("C","X"),
("C","Z"),
("C","X"),
("A","Y"),
("B","Y"),
("B","Z"),
("A","X"),
("C","X"),
("C","Z"),
("C","Z"),
("A","Z"),
("B","Y"),
("C","Z"),
("C","X"),
("C","X"),
("C","Z"),
("B","Y"),
("C","Z"),
("C","Z"),
("C","X"),
("B","X"),
("B","X"),
("A","Y"),
("C","Z"),
("C","Z"),
("B","Y"),
("B","Y"),
("C","Z"),
("C","X"),
("A","Z"),
("C","X"),
("C","Z"),
("C","Z"),
("B","X"),
("C","Z"),
("C","Z"),
("B","Y"),
("A","Y"),
("B","X"),
("C","X"),
("C","X"),
("C","Z"),
("C","X"),
("A","Y"),
("C","X"),
("C","Z"),
("A","Z"),
("B","Y"),
("C","Z"),
("C","X"),
("C","X"),
("C","Z"),
("C","Z"),
("C","Z"),
("A","Z"),
("C","Z"),
("A","Z"),
("A","Z"),
("C","X"),
("B","Y"),
("C","X"),
("C","X"),
("A","Z"),
("C","X"),
("A","Y"),
("C","Z"),
("C","Z"),
("A","Y"),
("A","Z"),
("C","Z"),
("C","Z"),
("A","Y"),
("C","Z"),
("C","Y"),
("B","Y"),
("B","Y"),
("A","Z"),
("A","Y"),
("C","Z"),
("C","Z"),
("A","Z"),
("C","Z"),
("A","Y"),
("B","Z"),
("C","X"),
("C","Z"),
("C","X"),
("B","Y"),
("C","Z"),
("C","X"),
("B","Y"),
("B","X"),
("A","Y"),
("C","Z"),
("C","Z"),
("C","Z"),
("B","Z"),
("A","Y"),
("C","Z"),
("C","Z"),
("C","X"),
("C","Z"),
("C","X"),
("A","Y"),
("C","Z"),
("C","Z"),
("C","X"),
("B","Y"),
("B","X"),
("B","Y"),
("C","Z"),
("C","X"),
("B","X"),
("C","Z"),
("C","Z"),
("A","Y"),
("C","Z"),
("A","Z"),
("A","Y"),
("C","Z"),
("A","Y"),
("C","X"),
("A","Y"),
("C","Y"),
("A","Z"),
("C","X"),
("C","X"),
("B","Y"),
("B","Y"),
("A","Y"),
("A","Z"),
("C","Z"),
("C","X"),
("C","Z"),
("A","Y"),
("B","Y"),
("A","Y"),
("B","X"),
("C","Z"),
("C","Z"),
("A","Z"),
("A","Y"),
("C","X"),
("C","X"),
("C","X"),
("A","Z"),
("B","Y"),
("C","Z"),
("C","Z"),
("C","Z"),
("C","X"),
("B","Z"),
("C","Z"),
("C","Z"),
("B","Z"),
("C","Z"),
("A","Z"),
("B","Y"),
("A","Y"),
("C","Z"),
("B","Y"),
("B","X"),
("B","X"),
("C","X"),
("C","Z"),
("A","X"),
("C","Z"),
("C","X"),
("C","X"),
("C","X"),
("C","X"),
("C","X"),
("B","Y"),
("C","X"),
("C","X"),
("A","Y"),
("A","Y"),
("C","Z"),
("C","Z"),
("B","X"),
("C","Z"),
("C","Z"),
("C","Z"),
("C","Z"),
("A","Z"),
("C","Z"),
("A","Z"),
("B","Y"),
("B","Y"),
("C","Z"),
("B","Y"),
("C","Z"),
("C","Z"),
("C","Z"),
("C","X"),
("B","Y"),
("B","Y"),
("C","Z"),
("A","Z"),
("C","Z"),
("C","X"),
("B","Y"),
("C","Z"),
("A","Z"),
("C","Z"),
("C","X"),
("C","Z"),
("C","Z"),
("C","X"),
("C","X"),
("B","Z"),
("A","Y"),
("B","X"),
("C","Z"),
("B","Y"),
("C","X"),
("C","X"),
("C","Z"),
("C","Z"),
("B","X"),
("B","X"),
("B","Y"),
("A","X"),
("C","X"),
("A","Z"),
("A","Z"),
("C","Z"),
("B","Y"),
("C","Z"),
("A","Z"),
("B","X"),
("C","X"),
("B","Y"),
("A","Z"),
("C","X"),
("A","X"),
("A","Z"),
("B","Y"),
("B","X"),
("B","Y"),
("A","Y"),
("C","Z"),
("C","Z"),
("B","X"),
("C","Z"),
("C","X"),
("B","Y"),
("C","Z"),
("C","Z"),
("A","Y"),
("B","Y"),
("A","Z"),
("A","Y"),
("C","X"),
("C","X"),
("C","Z"),
("A","Z"),
("C","Z"),
("B","Z"),
("A","Z"),
("A","Y"),
("C","X"),
("C","Z"),
("C","X"),
("B","Z"),
("C","Z"),
("B","Y"),
("A","Y"),
("B","X"),
("A","Y"),
("C","Z"),
("A","Y"),
("C","Z"),
("C","X"),
("B","Y"),
("C","X"),
("A","Y"),
("A","Z"),
("C","Z"),
("B","Y"),
("C","X"),
("A","Y"),
("C","X"),
("C","Z"),
("C","X"),
("B","Y"),
("C","X"),
("C","Z"),
("C","Z"),
("A","Z"),
("B","Y"),
("C","X"),
("B","X"),
("A","Z"),
("C","X"),
("C","X"),
("A","Y"),
("B","X"),
("C","X"),
("A","Z"),
("C","Z"),
("C","Z"),
("C","Z"),
("B","Y"),
("A","Y"),
("C","X"),
("C","Z"),
("C","Z"),
("A","Z"),
("C","Z"),
("A","Y"),
("C","X"),
("C","X"),
("C","X"),
("A","Z"),
("B","Y"),
("C","Z"),
("A","Y"),
("C","Z"),
("C","Z"),
("C","X"),
("C","Z"),
("A","Z"),
("C","Z"),
("B","Y"),
("C","X"),
("C","X"),
("C","Z"),
("B","Z"),
("B","Y"),
("C","X"),
("C","X"),
("A","Y"),
("A","Z"),
("A","Z"),
("A","X"),
("C","X"),
("A","Y"),
("B","Y"),
("A","Y"),
("A","Z"),
("B","Y"),
("B","Y"),
("A","Y"),
("B","Y"),
("C","X"),
("A","Z"),
("B","X"),
("C","Z"),
("A","Z"),
("B","X"),
("A","Y"),
("B","X"),
("B","Y"),
("A","Y"),
("A","X"),
("C","Z"),
("B","Z"),
("B","X"),
("B","Z"),
("C","Z"),
("C","X"),
("B","X"),
("B","Y"),
("A","Y"),
("B","Y"),
("B","Y"),
("B","Y"),
("A","Z"),
("A","Y"),
("B","X"),
("A","Y"),
("C","X"),
("B","Y"),
("B","X"),
("B","Y"),
("C","X"),
("A","Y"),
("C","X"),
("A","Y"),
("C","Z"),
("C","Z"),
("A","Z"),
("C","Z"),
("C","X"),
("C","X"),
("A","Z"),
("C","X"),
("C","X"),
("C","X"),
("A","Y"),
("A","Z"),
("A","Z"),
("C","Z"),
("B","X"),
("C","X"),
("C","X"),
("C","Z"),
("A","Y"),
("C","X"),
("C","X"),
("B","X"),
("C","Z"),
("C","Z"),
("C","X"),
("B","Z"),
("C","X"),
("C","X"),
("C","Z"),
("A","Y"),
("C","X"),
("A","Z"),
("C","Z"),
("C","X"),
("B","X"),
("B","Y"),
("C","X"),
("C","Z"),
("C","X"),
("C","Z"),
("A","Z"),
("C","Z"),
("C","X"),
("C","Z"),
("C","Z"),
("A","Z"),
("B","X"),
("C","X"),
("C","Z"),
("C","X"),
("C","X"),
("C","Z"),
("C","X"),
("C","Z"),
("A","Z"),
("A","Z"),
("A","Z"),
("C","Z"),
("C","X"),
("A","Z"),
("C","Z"),
("C","Z"),
("C","Z"),
("A","Z"),
("B","Y"),
("C","X"),
("B","Y"),
("C","X"),
("C","Z"),
("B","Y"),
("C","X"),
("C","X"),
("A","Z"),
("A","Z"),
("C","X"),
("C","Z"),
("C","X"),
("C","Z"),
("A","Z"),
("A","Y"),
("C","Z"),
("C","Z"),
("A","Y"),
("B","Y"),
("B","Y"),
("C","Z"),
("B","Y"),
("B","X"),
("B","Z"),
("A","Y"),
("A","Z"),
("C","X"),
("B","Y"),
("B","Z"),
("B","Y"),
("B","Z"),
("C","Z"),
("B","Y"),
("C","Z"),
("C","Z"),
("B","Y"),
("B","X"),
("B","Z"),
("C","X"),
("A","Z"),
("C","X"),
("C","X"),
("C","X"),
("A","Z"),
("C","Z"),
("A","Z"),
("C","Z"),
("A","Y"),
("C","Y"),
("B","Y"),
("A","Z"),
("B","Y"),
("C","Z"),
("A","Z"),
("A","Y"),
("B","X"),
("C","X"),
("C","X"),
("C","X"),
("C","Z"),
("C","X"),
("B","X"),
("C","Z"),
("A","Y"),
("C","Z"),
("A","X"),
("B","Y"),
("B","Z"),
("C","Z"),
("B","Y"),
("C","Z"),
("B","X"),
("B","Y"),
("C","Z"),
("B","X"),
("A","Z"),
("B","X"),
("B","Y"),
("A","Y"),
("B","Z"),
("C","X"),
("C","Z"),
("A","Z"),
("A","Y"),
("A","Z"),
("C","X"),
("C","Z"),
("B","Z"),
("A","Z"),
("A","Z"),
("C","X"),
("C","Z"),
("C","X"),
("C","X"),
("A","Z"),
("C","X"),
("C","X"),
("C","X"),
("B","X"),
("A","Y"),
("B","Y"),
("B","X"),
("B","Y"),
("C","Z"),
("B","Y"),
("B","Z"),
("C","Z"),
("C","X"),
("B","Y"),
("C","Z"),
("C","Z"),
("C","Z"),
("C","Z"),
("C","Z"),
("C","Z"),
("A","Z"),
("A","Z"),
("A","Z"),
("C","X"),
("C","Z"),
("B","Y"),
("C","Z"),
("C","Z"),
("C","Z"),
("C","Z"),
("C","X"),
("C","X"),
("A","Z"),
("B","Y"),
("A","Z"),
("B","Z"),
("C","X"),
("C","X"),
("C","Z"),
("C","Z"),
("C","X"),
("A","Y"),
("C","X"),
("A","Y"),
("C","Z"),
("A","Z"),
("C","Z"),
("B","X"),
("C","Z"),
("C","Z"),
("C","X"),
("C","X"),
("C","Z"),
("B","Z"),
("A","Y"),
("B","X"),
("A","Y"),
("B","Y"),
("A","Y"),
("A","Z"),
("A","Z"),
("C","Z"),
("B","X"),
("C","Z"),
("C","X"),
("C","Z"),
("C","Z"),
("A","Z"),
("C","X"),
("A","Y"),
("C","X"),
("A","Z"),
("C","Z"),
("C","X"),
("C","Z"),
("A","Z"),
("C","X"),
("C","X"),
("C","X"),
("C","X"),
("B","X"),
("B","Y"),
("C","X"),
("C","Z"),
("C","Z"),
("C","Z"),
("C","Z"),
("A","Z"),
("A","Z"),
("A","Y"),
("C","Z"),
("C","X"),
("C","Z"),
("C","Z"),
("C","Z"),
("A","Y"),
("C","X"),
("A","Z"),
("C","Y"),
("A","Z"),
("C","Z"),
("C","X"),
("A","Y"),
("C","Z"),
("C","X"),
("C","X"),
("A","Z"),
("B","Y"),
("C","Z"),
("A","Z"),
("C","Z"),
("C","Z"),
("C","Z"),
("B","Y"),
("C","X"),
("C","X"),
("A","X"),
("A","Y"),
("C","Z"),
("A","Z"),
("C","Z"),
("B","Y"),
("C","X"),
("B","X"),
("C","X"),
("C","X"),
("A","Y"),
("C","Z"),
("C","Z"),
("C","Z"),
("C","X"),
("A","Z"),
("B","Y"),
("A","Y"),
("B","Z"),
("B","Z"),
("B","X"),
("A","Z"),
("B","X"),
("B","X"),
("A","Z"),
("A","Z"),
("C","Y"),
("B","Y"),
("C","Z"),
("A","X"),
("C","Z"),
("B","X"),
("C","Z"),
("A","Y"),
("A","Y"),
("C","Z"),
("C","Z"),
("A","Z"),
("B","Y"),
("C","Z"),
("C","Z"),
("C","Z"),
("C","X"),
("A","Y"),
("C","X"),
("B","Y"),
("B","Y"),
("C","X"),
("C","Z"),
("C","X"),
("B","X"),
("A","Y"),
("A","Y"),
("C","Z"),
("C","Z"),
("C","Z"),
("C","Z"),
("C","Z"),
("B","X"),
("C","Z"),
("A","Y"),
("B","X"),
("A","Y"),
("A","Z"),
("C","Z"),
("C","X"),
("B","Y"),
("B","Y"),
("C","Z"),
("C","Z"),
("C","Z"),
("B","Y"),
("C","X"),
("B","Y"),
("A","Y"),
("B","X"),
("C","Z"),
("C","Z"),
("A","Y"),
("C","X"),
("C","Z"),
("A","Y"),
("C","X"),
("C","X"),
("A","Z"),
("C","Z"),
("B","X"),
("A","Z"),
("B","Y"),
("C","Z"),
("A","Z"),
("B","X"),
("C","Z"),
("B","Y"),
("C","Z"),
("B","Y"),
("C","X"),
("C","Z"),
("B","X"),
("C","X"),
("B","Y"),
("C","X"),
("A","Y"),
("C","Z"),
("C","Z"),
("C","X"),
("B","Y"),
("C","X"),
("C","Z"),
("C","X"),
("C","Z"),
("A","Z"),
("A","Y"),
("C","X"),
("C","Z"),
("C","Z"),
("A","Z"),
("C","X"),
("B","Z"),
("A","Z"),
("B","Y"),
("C","X"),
("A","Z"),
("C","Z"),
("B","Y"),
("C","X"),
("C","X"),
("C","Z"),
("C","Z"),
("B","Y"),
("A","Z"),
("C","Z"),
("C","X"),
("C","Z"),
("A","Z"),
("C","X"),
("A","Z"),
("C","Z"),
("C","X"),
("C","X"),
("C","Z"),
("B","X"),
("C","Z"),
("C","Z"),
("C","Z"),
("B","Y"),
("A","X"),
("B","Y"),
("C","X"),
("A","Z"),
("B","X"),
("A","Z"),
("C","Z"),
("C","X"),
("C","Z"),
("C","Z"),
("B","Y"),
("B","X"),
("C","Z"),
("B","Z"),
("B","Y"),
("B","X"),
("C","X"),
("C","X"),
("C","X"),
("C","Z"),
("B","Y"),
("C","Z"),
("C","Z"),
("C","Z"),
("C","Z"),
("C","Z"),
("C","Z"),
("C","X"),
("C","Z"),
("A","Y"),
("C","X"),
("B","X"),
("A","Y"),
("C","X"),
("C","X"),
("C","Z"),
("C","Z"),
("C","X"),
("B","X"),
("B","Y"),
("B","Y"),
("C","Z"),
("B","X"),
("C","X"),
("C","X"),
("C","Z"),
("C","Z"),
("A","Y"),
("C","Z"),
("A","Y"),
("C","Z"),
("C","Z"),
("B","Y"),
("A","Z"),
("B","X"),
("B","X"),
("C","Z"),
("C","Z"),
("A","Y"),
("A","Y"),
("C","Z"),
("C","Z"),
("C","X"),
("A","Y"),
("A","Y"),
("C","Z"),
("A","Z"),
("C","X"),
("B","Z"),
("A","Y"),
("C","X"),
("B","Z"),
("A","Y"),
("C","X"),
("B","Y"),
("C","X"),
("C","X"),
("C","Z"),
("A","X"),
("C","Y"),
("A","Y"),
("B","Z"),
("B","Y"),
("A","X"),
("B","Y"),
("A","Z"),
("C","Z"),
("C","X"),
("C","X"),
("C","X"),
("C","Y"),
("B","Y"),
("C","Z"),
("A","Z"),
("C","X"),
("C","X"),
("C","Z"),
("C","Z"),
("C","X"),
("C","Z"),
("B","Y"),
("C","Z"),
("C","X"),
("B","Y"),
("A","Z"),
("C","X"),
("B","Y"),
("C","Z"),
("C","X"),
("B","Y"),
("A","Z"),
("B","X"),
("C","Z"),
("B","X"),
("B","X"),
("C","Z"),
("C","Z"),
("C","X"),
("B","Y"),
("A","Y"),
("B","X"),
("B","X"),
("A","Y"),
("B","Y"),
("B","Y"),
("B","X"),
("A","Z"),
("A","Y"),
("C","Z"),
("B","Y"),
("C","Z"),
("A","Z"),
("C","Z"),
("C","X"),
("A","Z"),
("C","X"),
("C","Z"),
("C","X"),
("B","Y"),
("C","X"),
("A","Z"),
("B","X"),
("C","Z"),
("C","X"),
("C","X"),
("B","Y"),
("A","Y"),
("C","Z"),
("C","X"),
("A","Y"),
("A","X"),
("C","Z"),
("B","Y"),
("B","X"),
("C","X"),
("C","X"),
("C","X"),
("C","Z"),
("A","Z"),
("B","Y"),
("A","Y"),
("B","Y"),
("B","X"),
("B","Y"),
("B","Y"),
("A","Z"),
("B","Y"),
("B","Y"),
("B","Y"),
("C","Z"),
("C","X"),
("A","Z"),
("A","X"),
("B","Z"),
("C","X"),
("C","X"),
("C","X"),
("C","X"),
("C","Z"),
("A","Z"),
("B","Y"),
("A","Z"),
("B","Y"),
("C","X"),
("A","Z"),
("A","Y"),
("C","Z"),
("C","X"),
("B","X"),
("A","Z"),
("B","Y"),
("C","Z"),
("A","Z"),
("C","X"),
("A","Z"),
("A","Y"),
("B","Y"),
("C","Z"),
("B","Y"),
("C","X"),
("A","Z"),
("A","Z"),
("A","X"),
("C","Z"),
("C","X"),
("A","Y"),
("B","Y"),
("B","X"),
("C","Z"),
("A","Z"),
("C","X"),
("B","X"),
("B","Y"),
("A","Z"),
("C","X"),
("B","Y"),
("C","X"),
("C","Z"),
("C","Z"),
("B","Y"),
("A","Z"),
("A","Y"),
("C","X"),
("B","Y"),
("C","X"),
("C","X"),
("C","Z"),
("C","Z"),
("C","X"),
("A","X"),
("C","X"),
("A","Z"),
("C","Z"),
("B","X"),
("B","X"),
("C","X"),
("B","X"),
("B","Y"),
("C","X"),
("C","X"),
("A","Y"),
("B","Y"),
("C","Z"),
("C","Z"),
("C","Z"),
("C","Z"),
("C","Z"),
("C","Z"),
("A","Z"),
("B","X"),
("C","X"),
("B","Y"),
("B","Y"),
("C","X"),
("C","Z"),
("A","Z"),
("C","X"),
("C","Z"),
("C","Z"),
("C","X"),
("A","Z"),
("C","Z"),
("A","Z"),
("C","Z"),
("A","Y"),
("C","X"),
("C","X"),
("B","Y"),
("C","X"),
("C","Z"),
("B","X"),
("A","Y"),
("C","Z"),
("C","X"),
("B","Y"),
("B","X"),
("A","Y"),
("C","X"),
("A","Z"),
("C","Z"),
("C","X"),
("C","X"),
("A","Y"),
("B","Y"),
("C","Z"),
("B","Z"),
("C","Z"),
("C","X"),
("B","Y"),
("C","Z"),
("C","X"),
("A","Y"),
("C","X"),
("C","Z"),
("C","X"),
("C","X"),
("B","X"),
("C","X"),
("B","Y"),
("C","X"),
("C","Z"),
("C","X"),
("B","X"),
("B","X"),
("C","Z"),
("A","Y"),
("C","Z"),
("C","Y"),
("B","X"),
("A","Z"),
("C","X"),
("A","Z"),
("B","Z"),
("A","Y"),
("C","Z"),
("C","Z"),
("A","Z"),
("B","Z"),
("A","Z"),
("C","X"),
("C","Z"),
("C","Z"),
("A","Z"),
("A","Y"),
("C","Z"),
("C","X"),
("A","Y"),
("B","Y"),
("B","X"),
("A","Z"),
("A","Y"),
("C","X"),
("B","X"),
("A","Y"),
("C","Z"),
("B","Y"),
("C","X"),
("C","X"),
("C","X"),
("B","X"),
("A","Z"),
("B","Y"),
("B","Y"),
("A","Z"),
("C","X"),
("B","X"),
("B","X"),
("A","Y"),
("C","Z"),
("C","X"),
("C","X"),
("A","Y"),
("C","X"),
("C","X"),
("C","Z"),
("C","X"),
("A","Y"),
("B","Y"),
("C","Z"),
("A","Z"),
("C","Z"),
("A","Z"),
("A","Z"),
("A","Y"),
("C","X"),
("C","X"),
("C","X"),
("A","Y"),
("A","Y"),
("B","Y"),
("B","Z"),
("A","Z"),
("C","X"),
("C","Z"),
("C","X"),
("C","Z"),
("B","X"),
("C","X"),
("C","X"),
("B","X"),
("C","Z"),
("C","X"),
("B","Y"),
("B","X"),
("C","Z"),
("A","Z"),
("C","Z"),
("B","Y"),
("C","Z"),
("C","Z"),
("B","X"),
("A","Y"),
("B","Y"),
("A","Z"),
("B","Y"),
("C","X"),
("C","X"),
("A","Z"),
("C","Z"),
("C","X"),
("C","Z"),
("C","X"),
("A","Z"),
("C","X"),
("A","Z"),
("C","X"),
("A","Y"),
("A","Z"),
("C","X"),
("C","Z"),
("B","Y"),
("C","Z"),
("A","Z"),
("C","Y"),
("B","Z"),
("B","Y"),
("A","Z"),
("C","Z"),
("A","X"),
("A","Z"),
("C","Z"),
("C","X"),
("C","X"),
("A","Y"),
("C","Z"),
("C","X"),
("C","Z"),
("C","Z"),
("C","Z"),
("B","Y"),
("C","Z"),
("C","X"),
("C","Z"),
("B","Y"),
("C","Z"),
("B","Y"),
("C","Z"),
("C","Z"),
("C","Z"),
("C","Z"),
("C","Z"),
("B","Y"),
("C","Z"),
("B","Y"),
("A","Y"),
("C","X"),
("B","Y"),
("A","Y"),
("C","X"),
("A","Z"),
("A","Y"),
("C","Z"),
("B","Y"),
("C","Z"),
("C","X"),
("A","Y"),
("B","Y"),
("C","X"),
("C","X"),
("C","X"),
("A","Y"),
("A","Z"),
("B","X"),
("B","X"),
("B","X"),
("B","Y"),
("C","Z"),
("B","Y"),
("C","Z"),
("C","Z"),
("B","Y"),
("A","X"),
("C","X"),
("A","Y"),
("C","Z"),
("B","Y"),
("B","Y"),
("C","Z"),
("C","Z"),
("C","X"),
("C","Z"),
("C","Z"),
("B","Y"),
("C","Z"),
("C","X"),
("A","Y"),
("A","Z"),
("C","X"),
("B","Z"),
("C","X"),
("B","Y"),
("C","Z"),
("C","X"),
("A","Y"),
("A","Z"),
("C","Z"),
("C","X"),
("C","Z"),
("C","X"),
("C","X"),
("C","X"),
("C","X"),
("C","Z"),
("C","X"),
("B","Y"),
("A","Y"),
("C","X"),
("C","Z"),
("A","Z"),
("B","Y"),
("C","Z"),
("C","X"),
("C","Z"),
("B","Y"),
("A","Z"),
("A","Y"),
("A","Y"),
("B","Y"),
("B","Y"),
("A","Z"),
("B","X"),
("A","Y"),
("C","X"),
("C","X"),
("A","Y"),
("C","X"),
("A","Y"),
("B","Y"),
("C","Z"),
("A","X"),
("B","X"),
("A","Y"),
("A","Z"),
("C","Z"),
("B","X"),
("C","Z"),
("B","Y"),
("C","X"),
("B","Y"),
("C","Z"),
("A","Z"),
("A","Y"),
("C","X"),
("C","Z"),
("B","X"),
("B","Y"),
("C","Z"),
("C","Z"),
("A","Z"),
("C","Z"),
("B","Z"),
("C","X"),
("C","X"),
("C","Z"),
("C","Z"),
("C","Z"),
("C","X"),
("C","X"),
("C","Z"),
("B","Y"),
("C","Z"),
("B","Z"),
("C","X"),
("A","Y"),
("C","Z"),
("B","Y"),
("C","X"),
("A","Y"),
("C","Z"),
("B","X"),
("C","Z"),
("A","Z"),
("C","Z"),
("C","X"),
("A","Y"),
("A","Y"),
("A","Y"),
("C","Z"),
("C","Z"),
("A","Y"),
("A","X"),
("C","Z"),
("C","Z"),
("C","X"),
("C","Z"),
("A","Z"),
("A","Z"),
("C","Z"),
("C","X"),
("C","Z"),
("B","Y"),
("A","Y"),
("B","Z"),
("B","Y"),
("C","X"),
("C","Z"),
("C","X"),
("B","X"),
("B","Y"),
("C","X"),
("C","X"),
("C","X"),
("A","Z"),
("A","Y"),
("C","X"),
("C","Z"),
("C","X"),
("B","Y"),
("C","Z"),
("B","X"),
("C","Z"),
("B","Y"),
("A","Z"),
("C","X"),
("B","Y"),
("C","X"),
("B","X"),
("A","Z"),
("C","X"),
("B","Y"),
("A","Y"),
("C","Z"),
("C","X"),
("A","Y"),
("C","X"),
("B","Y"),
("B","X"),
("C","Z"),
("C","X"),
("C","X"),
("C","Z"),
("C","X"),
("C","X"),
("A","Y"),
("A","X"),
("C","Z"),
("C","Z"),
("C","Z"),
("B","Y"),
("C","Z"),
("A","Z"),
("B","X"),
("C","Z"),
("C","X"),
("C","X"),
("A","Y"),
("A","Z"),
("B","Y"),
("B","Y"),
("C","Z"),
("C","Z"),
("A","Y"),
("A","Z"),
("A","Z"),
("C","Z"),
("B","Y"),
("B","Y"),
("C","Z"),
("B","Y"),
("C","X"),
("C","X"),
("C","Z"),
("A","Z"),
("C","X"),
("C","X"),
("B","Y"),
("B","Y"),
("C","Z"),
("B","Y"),
("C","Z"),
("C","Z"),
("C","Z"),
("C","Z"),
("C","X"),
("C","Z"),
("B","Y"),
("C","Z"),
("C","Z"),
("B","X"),
("C","Z"),
("C","Z"),
("C","X"),
("B","Y"),
("C","Z"),
("A","Z"),
("A","Z"),
("A","Z"),
("C","X"),
("B","Y"),
("C","Z"),
("A","Y"),
("B","X"),
("C","X"),
("C","X"),
("A","X"),
("A","Y"),
("B","X"),
("C","Z"),
("C","X"),
("C","Z"),
("C","Z"),
("B","Y"),
("C","Z"),
("C","Z"),
("B","Z"),
("C","Z"),
("C","Z"),
("B","X"),
("A","Y"),
("C","X"),
("A","Z"),
("B","Y"),
("A","Z"),
("C","X"),
("B","X"),
("B","X"),
("C","Z"),
("A","X"),
("B","Z"),
("A","Z"),
("B","Y"),
("C","X"),
("C","Z"),
("B","Z"),
("C","X"),
("B","X"),
("C","Z"),
("A","Z"),
("B","X"),
("C","Z"),
("C","Z"),
("A","Z"),
("A","Y"),
("C","Z"),
("C","Z"),
("B","X"),
("A","Z"),
("C","Z"),
("B","Y"),
("B","Y"),
("C","Z"),
("B","Y"),
("C","Z"),
("C","Z"),
("C","Z"),
("C","Z"),
("C","Z"),
("C","Z"),
("C","Z"),
("C","X"),
("A","Y"),
("C","Z"),
("C","Z"),
("C","X"),
("C","Z"),
("B","Y"),
("B","X"),
("B","Y"),
("A","Z"),
("C","Z"),
("B","Y"),
("B","X"),
("C","Z"),
("B","X"),
("C","Y"),
("C","X"),
("B","Y"),
("C","Z"),
("B","Y"),
("A","Z"),
("B","Y"),
("C","X"),
("C","Z"),
("B","X"),
("C","Z"),
("A","Y"),
("C","Z"),
("B","X"),
("A","Z"),
("A","Y"),
("B","Y"),
("C","Z"),
("A","Y"),
("B","Y"),
("C","X"),
("A","Z"),
("A","Y"),
("C","Z"),
("C","Z"),
("A","Y"),
("B","X"),
("C","X"),
("B","Y"),
("A","Y"),
("C","X"),
("B","X"),
("C","X"),
("C","Z"),
("C","Z"),
("B","Y"),
("A","Z"),
("B","Y"),
("A","Z"),
("A","Y"),
("A","Z"),
("B","X"),
("A","Y"),
("C","X"),
("B","Y"),
("C","Z"),
("C","Z"),
("A","Z"),
("C","Z"),
("C","Z"),
("C","X"),
("C","Z"),
("C","Z"),
("B","Y"),
("A","Z"),
("C","X"),
("A","Y"),
("C","Z"),
("A","X"),
("A","Z"),
("C","Z"),
("B","Y"),
("C","X"),
("C","Y"),
("A","Y"),
("B","X"),
("B","Y"),
("C","Z"),
("C","Z"),
("B","X"),
("B","X"),
("C","Y"),
("B","Y"),
("B","X"),
("C","X"),
("C","Z"),
("A","Z"),
("C","Z"),
("A","Z"),
("C","Z"),
("C","Z"),
("A","Z"),
("B","X"),
("C","Z"),
("C","X"),
("C","Z"),
("B","Y"),
("B","X"),
("A","Z"),
("C","Z"),
("B","X"),
("C","Z"),
("B","Z"),
("C","Z"),
("B","Y"),
("B","Y"),
("C","Z"),
("B","Y"),
("A","Y"),
("A","Z"),
("A","Z"),
("C","X"),
("A","X"),
("C","X"),
("C","Z"),
("C","Z"),
("A","Y"),
("C","Z"),
("C","Z"),
("C","Z"),
("A","Y"),
("B","X"),
("C","Z"),
("C","X"),
("B","X"),
("C","X"),
("C","X"),
("B","Y"),
("C","Z"),
("B","X"),
("C","X"),
("B","Y"),
("A","Y"),
("C","Z"),
("C","X"),
("C","X"),
("A","Z"),
("B","Y"),
("C","Z"),
("B","Y"),
("C","Z"),
("B","Z"),
("B","Y"),
("B","Y"),
("A","Y"),
("B","Y"),
("B","Y"),
("A","X"),
("A","Y"),
("C","Z"),
("C","X"),
("B","X"),
("C","Z"),
("C","X"),
("C","X"),
("B","Y"),
("C","Z"),
("C","Z"),
("B","Y"),
("A","Y"),
("B","Y"),
("C","Z"),
("C","X"),
("C","Z"),
("C","Z"),
("C","X"),
("A","Y"),
("A","Y"),
("C","Z"),
("A","Y"),
("C","X"),
("C","Z"),
("A","Z"),
("A","Z"),
("C","Z"),
("B","Y"),
("A","X"),
("A","X"),
("B","X"),
("A","Z"),
("C","X"),
("C","X"),
("C","X"),
("C","X"),
("A","Z"),
("A","Z"),
("C","X"),
("B","X"),
("B","Y"),
("C","X"),
("B","Y"),
("B","Z"),
("A","Z"),
("A","Y"),
("C","X"),
("B","Y"),
("B","Y"),
("C","Z"),
("B","X"),
("B","X"),
("C","Z"),
("B","Y"),
("C","Z"),
("C","Z"),
("B","Y"),
("C","Z"),
("C","X"),
("C","Z"),
("B","Y"),
("C","X"),
("C","Z"),
("C","Z"),
("C","X"),
("B","X"),
("C","Z"),
("C","X"),
("C","X"),
("C","Y"),
("C","Z"),
("B","Y"),
("C","X"),
("C","X"),
("A","Y"),
("C","X"),
("C","X"),
("C","Z"),
("C","X"),
("C","Z"),
("C","Z"),
("C","Z"),
("A","X"),
("C","Z"),
("C","Y"),
("C","Z"),
("C","Z"),
("C","Z"),
("C","Z"),
("A","X"),
("C","Z"),
("B","X"),
("C","Z"),
("C","X"),
("B","Y"),
("C","X"),
("A","Z"),
("C","Z"),
("C","X"),
("B","Y"),
("B","Y"),
("A","Z"),
("A","Y"),
("C","X"),
("A","Z"),
("C","Z"),
("C","Z"),
("A","Y"),
("A","Z"),
("A","X"),
("C","Z"),
("A","Z"),
("C","Z"),
("C","Z"),
("C","Z"),
("A","Z"),
("A","Y"),
("A","Z"),
("A","Z"),
("A","Y"),
("A","Y"),
("C","X"),
("A","Y"),
("A","Y"),
("C","Z"),
("C","Z"),
("C","Z"),
("B","X"),
("C","X"),
("C","Z"),
("B","X"),
("C","Z"),
("C","Z"),
("C","Z"),
("C","Z"),
("C","Z"),
("B","Y"),
("C","Z"),
("B","Y"),
("C","Z"),
("C","X"),
("A","Z"),
("C","Z"),
("B","X"),
("B","Y"),
("C","X"),
("B","Y"),
("C","X"),
("C","X"),
("A","Y"),
("C","Z"),
("C","X"),
("C","X"),
("C","Z"),
("C","X"),
("C","X"),
("C","Z"),
("B","Y"),
("B","X"),
("C","X"),
("B","X"),
("B","Y"),
("C","X"),
("A","Z"),
("B","Y"),
("A","Z"),
("B","Y"),
("A","Z"),
("A","Y"),
("C","Z"),
("C","Z"),
("C","X"),
("B","Y"),
("A","Y"),
("A","Y"),
("C","X"),
("B","Y"),
("C","X"),
("A","Z"),
("A","Z"),
("C","X"),
("A","X"),
("C","X"),
("A","Z"),
("C","X"),
("C","Z"),
("C","X"),
("A","Y"),
("C","X"),
("B","Y"),
("B","Y"),
("C","X"),
("A","Z"),
("C","Z"),
("C","Z"),
("B","X"),
("C","Z"),
("C","Z"),
("A","Y"),
("C","Z"),
("B","Y"),
("A","Z"),
("A","X"),
("C","Z"),
("C","X"),
("B","Y"),
("A","Z"),
("C","X"),
("B","X"),
("A","Z"),
("A","Z"),
("C","Z"),
("A","Z"),
("C","Z"),
("C","Z"),
("A","X"),
("C","X"),
("A","Z"),
("C","X"),
("A","Y"),
("B","Y"),
("C","Z"),
("B","Y"),
("B","X"),
("C","Z"),
("A","X"),
("B","Z"),
("A","Z"),
("A","Z"),
("C","Z"),
("A","Z"),
("C","Z"),
("A","Z"),
("C","X"),
("C","X"),
("C","X"),
("C","X"),
("A","Z"),
("C","Z"),
("C","X"),
("B","Y"),
("A","Z"),
("B","Y"),
("A","Y"),
("C","Z"),
("A","Z"),
("C","X"),
("C","Z"),
("B","Y"),
("C","X"),
("A","Y"),
("B","X"),
("A","Y"),
("B","X"),
("B","Y"),
("C","Z"),
("A","Y"),
("B","Y"),
("A","Y"),
("B","Y"),
("C","Z"),
("C","X"),
("C","X"),
("C","X"),
("C","Z"),
("B","Y"),
("C","Z"),
("B","X"),
("C","X"),
("A","Y"),
("A","X"),
("B","Y"),
("A","Z"),
("C","Z"),
("A","Y"),
("A","Z"),
("C","X"),
("B","Y"),
("A","Z"),
("C","Z"),
("C","X"),
("C","Y"),
("C","X"),
("A","Z"),
("A","Y"),
("C","X"),
("A","Y"),
("C","X"),
("C","X"),
("A","Z"),
("B","Y"),
("C","Z"),
("C","X"),
("B","X"),
("B","Y"),
("A","Z"),
("A","Z"),
("B","X"),
("B","Y"),
("C","X"),
("B","Y"),
("C","Z"),
("B","Y"),
("C","Y"),
("B","Y"),
("B","X"),
("B","Y"),
("A","Y"),
("B","Y"),
("C","Z"),
("B","X"),
("B","Y"),
("C","Z"),
("A","Z"),
("C","Z"),
("B","X"),
("A","Y"),
("B","X"),
("C","Z"),
("B","Y"),
("A","Y"),
("C","Z"),
("C","Z"),
("C","Y"),
("C","Z"),
("A","Y"),
("C","X"),
("A","Y"),
("C","Z"),
("C","Z"),
("C","Z"),
("C","Z"),
("C","Z"),
("C","X"),
("C","Z"),
("C","Z"),
("B","Y"),
("C","X"),
("C","Z"),
("B","X"),
("C","X"),
("C","Z"),
("C","X"),
("A","Z"),
("C","X"),
("C","X"),
("C","Z"),
("C","X"),
("C","X"),
("C","Z"),
("A","Z"),
("B","X"),
("B","Y"),
("C","Z"),
("A","Z"),
("C","X"),
("B","X"),
("B","Y"),
("C","Z"),
("C","Z"),
("A","Y"),
("C","X"),
("C","Z"),
("C","X"),
("C","Z"),
("B","Y"),
("C","X"),
("C","Z"),
("C","X"),
("C","X"),
("C","Z"),
("C","X"),
("B","X"),
("C","X"),
("C","Z"),
("A","Y"),
("A","Y"),
("A","Y"),
("C","Z"),
("C","Z"),
("B","X"),
("C","X"),
("A","Z"),
("C","Z"),
("C","X"),
("C","Z"),
("B","X"),
("C","Z"),
("B","Z"),
("C","X"),
("A","Y"),
("C","Z"),
("A","Y"),
("C","X"),
("B","Y"),
("B","Y"),
("A","Z"),
("C","Z"),
("C","Z"),
("C","Z"),
("A","Z"),
("C","X"),
("A","Y"),
("C","Z"),
("A","Y"),
("C","Z"),
("A","Z"),
("A","Z"),
("B","Y"),
("C","Z"),
("A","Z"),
("C","X"),
("A","Y"),
("C","Z"),
("C","Z"),
("C","X"),
("C","X"),
("C","X"),
("A","X"),
("B","Z"),
("C","Z"),
("C","X"),
("A","Y"),
("A","Z"),
("C","Z"),
("B","X"),
("B","Y"),
("C","X"),
("C","Z"),
("B","X"),
("B","Y"),
("C","X"),
("B","X"),
("C","Z"),
("C","X"),
("C","X"),
("C","X"),
("C","X"),
("A","Y"),
("A","Z"),
("A","Y"),
("B","Y"),
("C","Z"),
("B","Y"),
("B","Y"),
("C","Z"),
("A","X"),
("C","Z"),
("B","X"),
("C","Z"),
("C","Z"),
("A","Z"),
("B","Y"),
("C","Z"),
("C","Z"),
("A","Y"),
("A","Z"),
("A","Z"),
("A","Z"),
("B","X"),
("C","X"),
("C","X"),
("B","Y"),
("C","Z"),
("C","X"),
("B","Y"),
("A","Y"),
("C","X"),
("C","Z"),
("C","Z"),
("C","X"),
("C","Y"),
("A","Y"),
("A","Z"),
("C","X"),
("C","X"),
("A","Z"),
("B","X"),
("C","Z"),
("A","X"),
("C","Z"),
("C","X"),
("C","Z"),
("A","X"),
("A","Z"),
("C","X"),
("B","Y"),
("C","Z"),
("C","Z"),
("B","X"),
("A","Y"),
("B","Y"),
("C","Z"),
("C","Z"),
("A","Z"),
("A","Y"),
("C","Z"),
("C","Z"),
("A","X"),
("B","Y"),
("C","Z"),
("C","Z"),
("B","Y"),
("C","X"),
("C","Z"),
("B","X"),
("B","Y"),
("A","Z"),
("C","Z"),
("C","X"),
("C","X"),
("C","Z"),
("B","Z"),
("B","Y"),
("C","Z"),
("C","X"),
("A","Y"),
("C","X"),
("A","Y"),
("A","Z"),
("B","Y"),
("B","X"),
("C","Z"),
("A","Z"),
("C","Z"),
("C","Z"),
("C","Z"),
("A","Y"),
("B","Y"),
("A","Z"),
("B","Y"),
("C","Z"),
("C","X"),
("B","Y"),
("C","Z"),
("A","Y"),
("C","Z"),
("A","Z"),
("C","Z"),
("C","Z"),
("C","Z"),
("A","Z"),
("C","X"),
("B","Y"),
("C","Z"),
("A","Z"),
("C","Z"),
("C","Z"),
("A","Z"),
("C","Z"),
("C","X"),
("B","Z"),
("C","Z"),
("C","Z"),
("A","Z"),
("C","Z"),
("C","Z"),
("B","Y"),
("B","X"),
("C","Z"),
("C","Z"),
("B","Y"),
("A","Y"),
("C","Z"),
("A","Z"),
("A","Z"),
("C","Z"),
("C","X"),
("C","X"),
("B","X"),
("C","X"),
("A","Y"),
("B","X"),
("A","Y"),
("C","Z"),
("C","X"),
("B","Y"),
("C","Z"),
("C","X"),
("C","X"),
("C","X"),
("B","X"),
("B","Z"),
("C","Z"),
("B","Y"),
("C","X"),
("A","Z"),
("C","Z"),
("C","Z"),
("A","Z"),
("A","Z"),
("C","Z"),
("C","Z"),
("A","Z"),
("A","Z"),
("A","Z"),
("C","Z"),
("A","Z"),
("C","Y"),
("A","Z"),
("C","Z"),
("C","Z"),
("C","X"),
("C","X"),
("C","Z"),
("C","Z"),
("A","Z"),
("C","Z"),
("A","Z"),
("C","X"),
("C","X"),
("C","X"),
("A","Y"),
("A","Z"),
("A","Z"),
("A","Y"),
("B","X"),
("C","Z"),
("C","Z"),
("B","X"),
("C","Z"),
("C","X"),
("B","Y"),
("C","Z"),
("C","X"),
("C","X"),
("B","Y"),
("B","Y"),
("A","Y"),
("A","Z"),
("B","X"),
("C","X"),
("B","Y"),
("B","Y"),
("B","Y"),
("C","Z"),
("C","X"),
("C","X"),
("A","Y"),
("B","Z"),
("A","Z"),
("A","Z"),
("B","X"),
("C","X"),
("A","Y"),
("C","X"),
("C","Z"),
("C","X"),
("A","Y"),
("A","Z"),
("C","Z"),
("A","Z"),
("C","Z"),
("C","X"),
("C","X"),
("A","Z"),
("B","X"),
("B","X"),
("B","Y"),
("C","Z"),
("C","Z"),
("C","X"),
("C","X"),
("C","X"),
("B","Y"),
("C","Z"),
("C","X"),
("B","X"),
("C","Z"),
("C","X"),
("B","X"),
("A","Y"),
("B","Y"),
("C","Z"),
("A","Z"),
("A","Y"),
("C","Z"),
("A","Y"),
("A","Y"),
("C","Z"),
("B","Y"),
("C","Z"),
("B","Z"),
("C","Z"),
("A","Z"),
("C","X"),
("C","X"),
("C","Z"),
("B","X"),
("C","X"),
("B","Y"),
("C","Z"),
("B","X"),
("C","Z"),
("C","X"),
("B","X"),
("B","Y"),
("B","Z"),
("B","X"),
("A","Y"),
("C","X"),
("C","Z"),
("C","Z"),
("A","Y"),
("B","X"),
("A","Y"),
("C","X"),
("C","Z"),
("B","Y"),
("C","Z"),
("C","Z"),
("C","Z"),
("A","Z"),
("A","Z"),
("A","Y"),
("C","Z"),
("B","Y"),
("C","Z"),
("C","X"),
("B","Y"),
("C","Z"),
("C","Z"),
("A","X"),
("C","X"),
("B","Y"),
("A","Z"),
("C","Z"),
("C","X"),
("A","Z"),
("A","Y"),
("C","Z"),
("C","Z"),
("B","X"),
("C","Z"),
("A","Z"),
("A","Y"),
("C","X"),
("A","Y"),
("C","Z"),
("C","X"),
("C","X"),
("C","X"),
("B","Y"),
("C","X"),
("A","Y"),
("C","X"),
("B","Y"),
("B","X"),
("A","Y"),
("B","X"),
("A","Y"),
("B","Z"),
("C","Z"),
("A","Z"),
("B","Y"),
("B","X"),
("C","Z"),
("C","Z"),
("C","X"),
("B","Y"),
("A","Z"),
("A","Z"),
("A","Y"),
("A","Y"),
("C","Z"),
("A","Z"),
("A","Z"),
("B","Y"),
("C","X"),
("C","Z"),
("C","Z"),
("C","Z"),
("A","Y"),
("A","Z"),
            };

            (string, string)[] testdata = new[]
            {
                ("A","Y"),
                ("B","X"),
                ("C","Z"),
            };
        }
    }

}
