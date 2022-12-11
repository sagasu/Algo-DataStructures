using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.AOC2022
{
    public class Monkey
    {
        public int Id;
        public Queue<long> Items;
        readonly Func<long, long> OperationFunc;
        readonly Func<long, bool> TestFunc;
        readonly int MonkeyFalse;
        readonly int MonkeyTrue;

        public int InspectionsCount = 0;

        public Monkey(int id, long[] items, Func<long, long> operation, Func<long, bool> test, int monkeyTrue, int monkeyFalse)
        {
            Id = id;
            Items = new Queue<long>(items);
            OperationFunc = operation;
            TestFunc = test;
            MonkeyTrue = monkeyTrue;
            MonkeyFalse = monkeyFalse;
        }

        public long Inspect(long worryLevel)
        {
            InspectionsCount++;
            return OperationFunc(worryLevel);
        }

        public int Test(long worryLevel)
        {
            return TestFunc(worryLevel) ? MonkeyTrue : MonkeyFalse;
        }
    }

    [TestClass]
    public class Day11
    {
        private int visited = 0;
        [TestMethod]
        public void Test1()
        {
            var data = realData;

            var line = 0;

            List<Monkey> monkeys = new();

            while (line < data.Length)
            {
                int id = int.Parse(data[line++].Substring(7, 1));
                string[] items = data[line++][18..].Split(", ");
                string operation = data[line++][19..];
                int divisor = int.Parse(data[line++][21..]);
                int monkeyTrue = int.Parse(data[line++][29..]);
                int monkeyFalse = int.Parse(data[line++][30..]);

                monkeys.Add(new Monkey(
                    id: id,
                    items: items.Select(item => long.Parse(item)).ToArray(),
                    operation: GetOperation(operation),
                    test: GetTest(divisor),
                    monkeyTrue,
                    monkeyFalse
                ));

                line += 1;
            }

            long worryLevel;
            int itemsCount;
            int rounds = 20;
            for (int round = 0; round < rounds; round++)
            {
                foreach (Monkey monkey in monkeys)
                {
                    itemsCount = monkey.Items.Count;
                    for (int i = 0; i < itemsCount; i++)
                    {
                        worryLevel = monkey.Items.Dequeue();

                        worryLevel = monkey.Inspect(worryLevel) / 3;

                        int toMonkey = monkey.Test(worryLevel);

                        monkeys[toMonkey].Items.Enqueue(worryLevel);
                    }
                }
            }

            var topMonkeys = monkeys
                .Select(item => item.InspectionsCount)
                .OrderByDescending(item => item)
                .Take(2)
                .ToArray();
            var monkeyBusiness = (topMonkeys[0] * topMonkeys[1]);
            Assert.AreEqual(50616, monkeyBusiness);
        }

        public Func<long, long> GetOperation(string command)
        {
            Func<long, long, long> oper;
            if (command.Contains(" * "))
                oper = (a, b) => a * b;
            else
                oper = (a, b) => a + b;

            string[] variables = command.Split(new char[] { '+', '*' }, StringSplitOptions.TrimEntries);
            if (variables[1] != "old")
                return a => oper(a, long.Parse(variables[1]));
            return a => oper(a, a);
        }

        public Func<long, bool> GetTest(int divisor)
        {
            return a => a % divisor == 0;
        }


        [TestMethod]
        public void Test2()
        {
            var data = realData;
            
            Assert.AreEqual("RFKZCPEF", "RFKZCPEF");
        }


        private string[] testData = new[]
        {
            "Monkey 0:",
            "  Starting items: 79, 98",
            "  Operation: new = old * 19",
            "  Test: divisible by 23",
            "    If true: throw to monkey 2",
            "    If false: throw to monkey 3",
            "",
            "Monkey 1:",
            "  Starting items: 54, 65, 75, 74",
            "  Operation: new = old + 6",
            "  Test: divisible by 19",
            "    If true: throw to monkey 2",
            "    If false: throw to monkey 0",
            "",
            "Monkey 2:",
            "  Starting items: 79, 60, 97",
            "  Operation: new = old * old",
            "  Test: divisible by 13",
            "    If true: throw to monkey 1",
            "    If false: throw to monkey 3",
            "",
            "Monkey 3:",
            "  Starting items: 74",
            "  Operation: new = old + 3",
            "  Test: divisible by 17",
            "    If true: throw to monkey 0",
            "    If false: throw to monkey 1",
        };



        private string[] realData = new[]
        {
            "Monkey 0:",
            "  Starting items: 78, 53, 89, 51, 52, 59, 58, 85",
            "  Operation: new = old * 3",
            "  Test: divisible by 5",
            "    If true: throw to monkey 2",
            "    If false: throw to monkey 7",
            "",
            "Monkey 1:",
            "  Starting items: 64",
            "  Operation: new = old + 7",
            "  Test: divisible by 2",
            "    If true: throw to monkey 3",
            "    If false: throw to monkey 6",
            "",
            "Monkey 2:",
            "  Starting items: 71, 93, 65, 82",
            "  Operation: new = old + 5",
            "  Test: divisible by 13",
            "    If true: throw to monkey 5",
            "    If false: throw to monkey 4",
            "",
            "Monkey 3:",
            "  Starting items: 67, 73, 95, 75, 56, 74",
            "  Operation: new = old + 8",
            "  Test: divisible by 19",
            "    If true: throw to monkey 6",
            "    If false: throw to monkey 0",
            "",
            "Monkey 4:",
            "  Starting items: 85, 91, 90",
            "  Operation: new = old + 4",
            "  Test: divisible by 11",
            "    If true: throw to monkey 3",
            "    If false: throw to monkey 1",
            "",
            "Monkey 5:",
            "  Starting items: 67, 96, 69, 55, 70, 83, 62",
            "  Operation: new = old * 2",
            "  Test: divisible by 3",
            "    If true: throw to monkey 4",
            "    If false: throw to monkey 1",
            "",
            "Monkey 6:",
            "  Starting items: 53, 86, 98, 70, 64",
            "  Operation: new = old + 6",
            "  Test: divisible by 7",
            "    If true: throw to monkey 7",
            "    If false: throw to monkey 0",
            "",
            "Monkey 7:",
            "  Starting items: 88, 64",
            "  Operation: new = old * old",
            "  Test: divisible by 17",
            "    If true: throw to monkey 2",
            "    If false: throw to monkey 5",
        };
    }


}
