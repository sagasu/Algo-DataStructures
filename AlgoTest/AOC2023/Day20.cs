using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using AlgoTest.LeetCode.The_Number_of_Weak_Characters_in_the_Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.AOC2023;

public static class MathHelpers
{
    public static T GreatestCommonDivisor<T>(T a, T b) where T : INumber<T>
    {
        while (b != T.Zero)
        {
            var temp = b;
            b = a % b;
            a = temp;
        }

        return a;
    }

    public static T LeastCommonMultiple<T>(T a, T b) where T : INumber<T>
        => a / GreatestCommonDivisor(a, b) * b;
    
    public static T LeastCommonMultiple<T>(this IEnumerable<T> values) where T : INumber<T>
        => values.Aggregate(LeastCommonMultiple);
}

[TestClass]
public class Day20
{
    [TestMethod]
    public void Test()
    {
        var input = data.Split('\n', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).Select(x => x.Split(new [] {' ', '-', '>', ','}, StringSplitOptions.RemoveEmptyEntries).ToArray());
        var modules = new Dictionary<string, Module>();
        // Types:
        // 0 == broadcaster
        // 1 == % flip flop
        // 2 == & conjunction
        foreach (var i in input)
        {
            var type = 0;
            var name = i[0];
            switch (i[0][0])
            {
                case 'b': // broadcaster
                    type = 0;
                    break;
                case '%': // flip flop
                    type = 1;
                    name = i[0][1..];
                    break;
                case '&': // conjunction
                    type = 2;
                    name = i[0][1..];
                    break;
            }
            modules[name] = new Module(name, type, i[1..]);
        }

        var endPoints = modules.SelectMany(x => x.Value.Outputs).ToHashSet().Where(x => !modules.ContainsKey(x))
            .ToHashSet();
        
        // fill sourceMemory where relevant
        foreach (var module in modules.Where(x => x.Value.Type == 2).Select(x => x.Key))
        {
            modules[module].SourceMemory = modules
                .Where(x => x.Value.Outputs.Contains(module))
                .Select(x => x.Key)
                .ToDictionary(x => x, _ => false);
        }

        if (2 == 1)
        {
            var low = 0;
            var high = 0;
            for (long i = 0; i < 1000; i++)
            {
                var signals = new Queue<Signal>();
                signals.Enqueue(new Signal("broadcaster", false, "button"));
                while (signals.Count > 0)
                {
                    var signal = signals.Dequeue();
                    low += signal.IsHigh ? 0 : 1;
                    high += signal.IsHigh ? 1 : 0;
                    if (endPoints.Contains(signal.TargetName)) continue;
                    modules[signal.TargetName].Process(signal, signals);
                }
            }

            Console.WriteLine(low * high);
        }
        
        // the node before the end-point is (in my input) a conjunction - find all nodes that send to that node and when they first send a high signal
        var conjunction = modules.Where(x => x.Value.Outputs.Contains(endPoints.Single())).Select(x => x.Key).Single();
        var relevantNodes = modules.Where(x => x.Value.Outputs.Contains(conjunction)).Select(x => x.Key).ToHashSet();
        var push = 0;
        long firstHigh = 1;
        while (relevantNodes.Count > 0)
        {
            push++;
            var signals = new Queue<Signal>();
            signals.Enqueue(new Signal("broadcaster", false, "button"));
            while (signals.Count > 0)
            {
                var signal = signals.Dequeue();
                if (signal.IsHigh && relevantNodes.Contains(signal.SourceName))
                {
                    relevantNodes.Remove(signal.SourceName);
                    firstHigh = MathHelpers.LeastCommonMultiple(firstHigh, push);
                }
                if (endPoints.Contains(signal.TargetName)) continue;
                modules[signal.TargetName].Process(signal, signals);
            }
        }

        Console.WriteLine(firstHigh);
    }
    
    private class Module(string name, int type, string[] outputs)
    {
        private string Name { get; } = name;
        public int Type { get; } = type;
        private bool Memory { get; set; }
        public string[] Outputs { get; } = outputs;
        public Dictionary<string, bool> SourceMemory = new();

        public void Process(Signal signal, Queue<Signal> signals)
        {
            switch (Type)
            {
                case 0:
                    Send(signal.IsHigh, signals);
                    return;
                case 1 when signal.IsHigh:
                    return;
                case 1:
                    Memory = !Memory;
                    Send(Memory, signals);
                    return;
                default:
                    SourceMemory[signal.SourceName] = signal.IsHigh;
                    Send(!SourceMemory.All(x => x.Value), signals);
                    break;
            }
        }

        private void Send(bool signal, Queue<Signal>signals)
        {
            foreach (var output in Outputs)
            {
                signals.Enqueue(new Signal(output, signal, Name));
            }
            
        }
    }

    private record Signal(string TargetName, bool IsHigh, string SourceName)
    {
        public readonly string TargetName = TargetName;
        public readonly bool IsHigh = IsHigh;
        public readonly string SourceName = SourceName;
    }
    
    
    private string data = """
                            %ng -> vz
                            %hv -> zz
                            %cn -> fv, kp
                            %sc -> sm
                            &rt -> jf, hv, bs, kt, fn
                            %bc -> fv
                            %sb -> gk
                            %vz -> gk, lg
                            %sm -> mx
                            %kp -> fv, pq
                            &gk -> mx, sc, vq, bz, ng, zk, sm
                            %bs -> rt, mk
                            %pn -> rt
                            %rq -> sl, xd
                            %jr -> fv, bc
                            %vm -> rt, pn
                            %rk -> gk, sb
                            %gs -> xt
                            %dc -> sl
                            %bz -> gk, sc
                            %ql -> sl, fz
                            %kt -> bt
                            %gn -> fv, hk
                            broadcaster -> bs, rq, cn, bz
                            %rl -> rh, gk
                            &hj -> rx
                            %vj -> rt, rr
                            %jx -> fv, bf
                            &ks -> hj
                            %rh -> gk, vq
                            %hk -> jx
                            %fn -> vj
                            %jl -> mr, sl
                            %vq -> ng
                            %mr -> sl, dc
                            %fk -> cc
                            %jc -> fk, sl
                            &jf -> hj
                            %lg -> gk, rk
                            %zz -> jg, rt
                            %pq -> lx, fv
                            %xt -> gn
                            %bf -> fv, jr
                            &qs -> hj
                            %gv -> sl, jl
                            %bt -> rt, fn
                            %mm -> sl, ql
                            %jg -> vm, rt
                            %lx -> gs
                            %rr -> hv, rt
                            &fv -> xt, qs, gs, cn, lx, hk
                            %mx -> rl
                            &zk -> hj
                            &sl -> fk, rq, fz, xd, ks
                            %fz -> jc
                            %mk -> rt, kt
                            %xd -> mm
                            %cc -> sl, gv
                          """;
}