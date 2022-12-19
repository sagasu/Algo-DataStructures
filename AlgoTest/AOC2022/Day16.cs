using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.AOC2022
{

    [TestClass]
    public class Day16
    {
        [TestMethod]
        public void Test1()
        {

            var data = realData.ToArray();
            var defs = ParseInput();
            ComputeNodeDistances(defs);

            //bitmask des nodes non-zero
            int visitable = 0;
            for (int i = 0; i < nzNodes.Length; i++)
            {
                visitable += 1 << i;
            }

            var part1 = RecursiveSolvePartA(namesIndex["AA"], 30, visitable, 0, "");

            Assert.AreEqual(1991, part1.Item1);
        }
        public const int infinity = 999999999;
        public Dictionary<string, HashSet<string>> adjacency = new Dictionary<string, HashSet<string>>();
        public int[,] nodeDist = new int[0, 0];
        public string[] names = new string[0];
        public Dictionary<string, int> namesIndex = new Dictionary<string, int>();

        public int[] nzNodes = new int[0];
        public int[] nodesFlow = new int[0];

        public (int, string) RecursiveSolvePartA(int current, int tLeft, int visitable, int cummulFlow, string path)
        {
            var newFlow = current == 0 ? 0 : cummulFlow + (tLeft * nodesFlow[current]);

            int bestVal = -1;
            int bestIdx = -1;
            string bestPath = "";
            if (visitable != 0)
            {
                for (int i = 0; i < nzNodes.Length; i++)
                {
                    int flag = 1 << i;
                    if ((visitable & flag) == 0)
                    {
                        continue;
                    }

                    var dist = nodeDist[current, nzNodes[i]];
                    if (dist > tLeft || dist == 0)
                    {
                        continue;
                    }


                    (var cur, var p) = RecursiveSolvePartA(nzNodes[i], tLeft - dist - 1, visitable - flag, newFlow, path);

                    if (cur > bestVal)
                    {
                        bestIdx = i;
                        bestVal = cur;
                        bestPath = p;
                    }
                }
            }

            if (visitable == 0 || bestIdx == -1)
            {
                return (newFlow, names[current] + path);
            }

            if (current == 0)
            {
                return (bestVal, bestPath);
            }

            return (bestVal, names[current] + bestPath);
        }

        public void ComputeNodeDistances(Dictionary<string, ValveDefinition> defs)
        {
            names = defs.Keys.OrderBy(n => n).ToArray();
            nodesFlow = new int[names.Length];

            for (int n = 0; n < names.Length; n++)
            {
                namesIndex[names[n]] = n;
                nodesFlow[n] = defs[names[n]].FlowRate;
            }
            nzNodes = defs.Where(kv => kv.Value.FlowRate > 0).Select(kv => namesIndex[kv.Key]).ToArray();

            nodeDist = new int[0, 0];
            foreach (var d in defs)
            {
                adjacency[d.Key] = new HashSet<string>(d.Value.Connections);
            }

            // Floyd-Warshall
            nodeDist = new int[names.Length, names.Length];
            for (int i = 0; i < names.Length; i++)
            {
                for (int j = 0; j < names.Length; j++)
                {
                    if (i == j)
                    {
                        nodeDist[i, j] = 0;
                    }
                    else if (adjacency[names[i]].Contains(names[j]))
                    {
                        nodeDist[i, j] = 1;
                        nodeDist[j, i] = 1;
                    }
                    else
                    {
                        nodeDist[i, j] = infinity;
                        nodeDist[j, i] = infinity;
                    }
                }
            }

            for (int k = 0; k < names.Length; k++)
            {
                for (int i = 0; i < names.Length; i++)
                {
                    for (int j = 0; j < names.Length; j++)
                    {
                        if (nodeDist[i, j] > nodeDist[i, k] + nodeDist[k, j])
                        {
                            nodeDist[i, j] = nodeDist[i, k] + nodeDist[k, j];
                        }
                    }
                }
            }

        }



        [TestMethod]
        public void Test2()
        {
            var data = realData;


            Assert.AreEqual(27625, 2);
        }
        public struct ValveDefinition
        {
            public string Name;
            public int FlowRate;
            public string[] Connections;
        }

        public Dictionary<string, ValveDefinition> ParseInput()
        {
            var lines = realData;
            var defs = new Dictionary<string, ValveDefinition>();
            var pattern = @"Valve (.+) has flow rate=(.+); tunnel.? lead.? to valve.? (.+)";

            foreach (var line in lines)
            {
                var matches = Regex.Matches(line, pattern);
                foreach (Match match in matches)
                {
                    var n = match.Groups[1].Value;
                    defs[n] = new ValveDefinition
                    {
                        Name = n,
                        FlowRate = int.Parse(match.Groups[2].Value),
                        Connections = match.Groups[3].Value.Split(',').Select(s => s.Trim()).ToArray()
                    };
                }
            }

            return defs;
        }

        private string[] testData = new[]
        {
            "Valve AA has flow rate=0; tunnels lead to valves DD, II, BB",
            "Valve BB has flow rate=13; tunnels lead to valves CC, AA",
            "Valve CC has flow rate=2; tunnels lead to valves DD, BB",
            "Valve DD has flow rate=20; tunnels lead to valves CC, AA, EE",
            "Valve EE has flow rate=3; tunnels lead to valves FF, DD",
            "Valve FF has flow rate=0; tunnels lead to valves EE, GG",
            "Valve GG has flow rate=0; tunnels lead to valves FF, HH",
            "Valve HH has flow rate=22; tunnel leads to valve GG",
            "Valve II has flow rate=0; tunnels lead to valves AA, JJ",
            "Valve JJ has flow rate=21; tunnel leads to valve II",
        };



        private string[] realData = new[]
        {
            "Valve OK has flow rate=0; tunnels lead to valves RW, FX",
"Valve JY has flow rate=13; tunnel leads to valve TT",
"Valve FX has flow rate=16; tunnels lead to valves OK, LF, GO, IV",
"Valve TD has flow rate=0; tunnels lead to valves XZ, ED",
"Valve VF has flow rate=9; tunnels lead to valves DS, LU, TR, WO",
"Valve TT has flow rate=0; tunnels lead to valves XZ, JY",
"Valve KR has flow rate=8; tunnels lead to valves VL, CI, GO, JJ, TQ",
"Valve HN has flow rate=0; tunnels lead to valves YG, AA",
"Valve MC has flow rate=24; tunnels lead to valves MI, EE, TH, YG",
"Valve XM has flow rate=0; tunnels lead to valves AF, JL",
"Valve XE has flow rate=0; tunnels lead to valves XP, AF",
"Valve ZF has flow rate=0; tunnels lead to valves EM, EI",
"Valve DS has flow rate=0; tunnels lead to valves VF, LF",
"Valve AF has flow rate=7; tunnels lead to valves AW, XE, CI, BJ, XM",
"Valve NL has flow rate=0; tunnels lead to valves KF, EM",
"Valve LF has flow rate=0; tunnels lead to valves FX, DS",
"Valve XZ has flow rate=25; tunnels lead to valves TD, TT",
"Valve TQ has flow rate=0; tunnels lead to valves AA, KR",
"Valve WO has flow rate=0; tunnels lead to valves VF, NE",
"Valve TH has flow rate=0; tunnels lead to valves LU, MC",
"Valve AA has flow rate=0; tunnels lead to valves TQ, KF, HN, XP, TY",
"Valve KB has flow rate=0; tunnels lead to valves WP, XL",
"Valve IV has flow rate=0; tunnels lead to valves PK, FX",
"Valve MI has flow rate=0; tunnels lead to valves JF, MC",
"Valve EX has flow rate=22; tunnels lead to valves JL, ZZ, SL",
"Valve ZZ has flow rate=0; tunnels lead to valves EX, JS",
"Valve KF has flow rate=0; tunnels lead to valves NL, AA",
"Valve PK has flow rate=11; tunnels lead to valves IV, HP",
"Valve TR has flow rate=0; tunnels lead to valves DI, VF",
"Valve YG has flow rate=0; tunnels lead to valves HN, MC",
"Valve JL has flow rate=0; tunnels lead to valves EX, XM",
"Valve VL has flow rate=0; tunnels lead to valves JS, KR",
"Valve XP has flow rate=0; tunnels lead to valves AA, XE",
"Valve TY has flow rate=0; tunnels lead to valves JS, AA",
"Valve EM has flow rate=4; tunnels lead to valves JJ, NL, ZF, WP, AW",
"Valve BJ has flow rate=0; tunnels lead to valves WK, AF",
"Valve JJ has flow rate=0; tunnels lead to valves EM, KR",
"Valve RW has flow rate=14; tunnels lead to valves NE, OK",
"Valve EI has flow rate=0; tunnels lead to valves ZF, JS",
"Valve SL has flow rate=0; tunnels lead to valves HP, EX",
"Valve EE has flow rate=0; tunnels lead to valves MC, XL",
"Valve WK has flow rate=0; tunnels lead to valves BJ, JS",
"Valve AW has flow rate=0; tunnels lead to valves EM, AF",
"Valve XL has flow rate=21; tunnels lead to valves EE, KB",
"Valve JF has flow rate=0; tunnels lead to valves MI, ED",
"Valve LU has flow rate=0; tunnels lead to valves TH, VF",
"Valve CI has flow rate=0; tunnels lead to valves AF, KR",
"Valve ED has flow rate=23; tunnels lead to valves JF, TD",
"Valve JS has flow rate=3; tunnels lead to valves VL, ZZ, EI, TY, WK",
"Valve NE has flow rate=0; tunnels lead to valves RW, WO",
"Valve DI has flow rate=12; tunnel leads to valve TR",
"Valve WP has flow rate=0; tunnels lead to valves KB, EM",
"Valve GO has flow rate=0; tunnels lead to valves FX, KR",
"Valve HP has flow rate=0; tunnels lead to valves SL, PK",
        };
    }


}
