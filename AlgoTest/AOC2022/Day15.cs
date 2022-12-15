using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.AOC2022
{

    [TestClass]
    public class Day15
    {



        [TestMethod]
        public void Test1()
        {
            var isInTestMode = false;
            var data = realData.ToArray();
            var sensors =
                data.Select(line =>
                        line.Split(new[] { "Sensor at x=", ", y=", ": closest beacon is at x=" }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(item => int.Parse(item))
                            .ToArray()
                    )
                    .Select(row => new Sensor(row[0], row[1], new Beacon(row[2], row[3])));


            var knownBeacons = sensors.Select(item => item.NearestBeacon).Distinct().ToList();

            var targetY = isInTestMode ? 10 : 2000000;
            var coverage =
                sensors
                    .SelectMany(item => item.GetInfluenceAtY(targetY))
                    .Distinct()
                    .Except(knownBeacons.Where(item => item.Y == targetY).Select(item => item.X))
                    .OrderBy(item => item)
                    .ToList();

            var part1 = coverage.Count;
            
            Assert.AreEqual(4724228, part1);
        }

      


        [TestMethod]
        public void Test2()
        {
            var data = realData;
            var isInTestMode = false;
            var minX = 0;
            var minY = 0;
            var maxX = isInTestMode ? 20 : 4000000;
            var maxY = isInTestMode ? 20 : 4000000;
            var sensors =
                data.Select(line =>
                        line.Split(new[] { "Sensor at x=", ", y=", ": closest beacon is at x=" }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(item => int.Parse(item))
                            .ToArray()
                    )
                    .Select(row => new Sensor(row[0], row[1], new Beacon(row[2], row[3])));

            (int x, int y) uncovered = default;
            bool done = false;
            for (int y = minY; y <= maxY && !done; y++)
            {
                var inRangeSensors = sensors.Where(item => y >= item.YLowerBound && y <= item.YUpperBound);
                var xRangesCovered =
                    inRangeSensors
                        .Select(item => item.GetInfluenceRangeAtY(y, (minX, maxX)))
                        .OrderBy(item => item.lowerBound)
                        .ThenBy(item => item.upperBound)
                        .ToList();

                var coveredRange = xRangesCovered[0];
                foreach (var range in xRangesCovered.Skip(1))
                {
                    if (coveredRange.upperBound + 1 < range.lowerBound)
                    {
                        done = true;
                        uncovered = (coveredRange.upperBound + 1, y);
                        break;
                    }
                    coveredRange = (Math.Min(coveredRange.lowerBound, range.lowerBound), Math.Max(coveredRange.upperBound, range.upperBound));
                }

                if (!done && coveredRange.lowerBound != minX)
                {
                    done = true;
                    uncovered = (minX, y);
                    break;
                }

                if (!done && coveredRange.upperBound != maxX)
                {
                    done = true;
                    uncovered = (maxX, y);
                    break;
                }
            }
            
            var part2 = (uncovered.x * 4000000L + uncovered.y);

            Assert.AreEqual(13622251246513, part2);
        }
        record Sensor(int X, int Y, Beacon NearestBeacon)
        {
            private int BeaconDistance => Math.Abs(this.X - this.NearestBeacon.X) + Math.Abs(this.Y - this.NearestBeacon.Y);

            public IEnumerable<int> GetInfluenceAtY(int y, (int min, int max)? xBounds = null)
            {
                var yDistance = Math.Abs(this.Y - y);
                var horizontalEffect = this.BeaconDistance - yDistance;

                if (horizontalEffect > 0)
                {
                    return Enumerable
                        .Range(this.X - horizontalEffect, 1 + (2 * horizontalEffect))
                        .Where(item => !xBounds.HasValue || (item >= xBounds.Value.min && item <= xBounds.Value.max));
                }
                else
                {
                    return Enumerable.Empty<int>();
                }
            }

            public (int lowerBound, int upperBound) GetInfluenceRangeAtY(int y, (int min, int max) xBounds)
            {
                var yDistance = Math.Abs(this.Y - y);
                var horizontalEffect = this.BeaconDistance - yDistance;

                var lowerBound = Math.Max(xBounds.min, this.X - horizontalEffect);
                var upperBound = Math.Min(xBounds.max, lowerBound + (2 * horizontalEffect));

                return (lowerBound, upperBound);
            }

            public bool IsWithinRange(int x, int y) => (Math.Abs(this.X - x) + Math.Abs(this.Y - y)) <= this.BeaconDistance;

            public int YLowerBound => this.Y - this.BeaconDistance;
            public int YUpperBound => this.Y + this.BeaconDistance;
        }

        record Beacon(int X, int Y);

        private string[] testData = new[]
        {
            "Sensor at x=2, y=18: closest beacon is at x=-2, y=15",
            "Sensor at x=9, y=16: closest beacon is at x=10, y=16",
            "Sensor at x=13, y=2: closest beacon is at x=15, y=3",
            "Sensor at x=12, y=14: closest beacon is at x=10, y=16",
            "Sensor at x=10, y=20: closest beacon is at x=10, y=16",
            "Sensor at x=14, y=17: closest beacon is at x=10, y=16",
            "Sensor at x=8, y=7: closest beacon is at x=2, y=10",
            "Sensor at x=2, y=0: closest beacon is at x=2, y=10",
            "Sensor at x=0, y=11: closest beacon is at x=2, y=10",
            "Sensor at x=20, y=14: closest beacon is at x=25, y=17",
            "Sensor at x=17, y=20: closest beacon is at x=21, y=22",
            "Sensor at x=16, y=7: closest beacon is at x=15, y=3",
            "Sensor at x=14, y=3: closest beacon is at x=15, y=3",
            "Sensor at x=20, y=1: closest beacon is at x=15, y=3",
        };



        private string[] realData = new[]
        {
            "Sensor at x=1638847, y=3775370: closest beacon is at x=2498385, y=3565515",
"Sensor at x=3654046, y=17188: closest beacon is at x=3628729, y=113719",
"Sensor at x=3255262, y=2496809: closest beacon is at x=3266439, y=2494761",
"Sensor at x=3743681, y=1144821: closest beacon is at x=3628729, y=113719",
"Sensor at x=801506, y=2605771: closest beacon is at x=1043356, y=2000000",
"Sensor at x=2933878, y=5850: closest beacon is at x=3628729, y=113719",
"Sensor at x=3833210, y=12449: closest beacon is at x=3628729, y=113719",
"Sensor at x=2604874, y=3991135: closest beacon is at x=2498385, y=3565515",
"Sensor at x=1287765, y=1415912: closest beacon is at x=1043356, y=2000000",
"Sensor at x=3111474, y=3680987: closest beacon is at x=2498385, y=3565515",
"Sensor at x=2823460, y=1679092: closest beacon is at x=3212538, y=2537816",
"Sensor at x=580633, y=1973060: closest beacon is at x=1043356, y=2000000",
"Sensor at x=3983949, y=236589: closest beacon is at x=3628729, y=113719",
"Sensor at x=3312433, y=246388: closest beacon is at x=3628729, y=113719",
"Sensor at x=505, y=67828: closest beacon is at x=-645204, y=289136",
"Sensor at x=1566406, y=647261: closest beacon is at x=1043356, y=2000000",
"Sensor at x=2210221, y=2960790: closest beacon is at x=2498385, y=3565515",
"Sensor at x=3538385, y=1990300: closest beacon is at x=3266439, y=2494761",
"Sensor at x=3780372, y=2801075: closest beacon is at x=3266439, y=2494761",
"Sensor at x=312110, y=1285740: closest beacon is at x=1043356, y=2000000",
"Sensor at x=51945, y=2855778: closest beacon is at x=-32922, y=3577599",
"Sensor at x=1387635, y=2875487: closest beacon is at x=1043356, y=2000000",
"Sensor at x=82486, y=3631563: closest beacon is at x=-32922, y=3577599",
"Sensor at x=3689149, y=3669721: closest beacon is at x=3481800, y=4169166",
"Sensor at x=2085975, y=2190591: closest beacon is at x=1043356, y=2000000",
"Sensor at x=712588, y=3677889: closest beacon is at x=-32922, y=3577599",
"Sensor at x=22095, y=3888893: closest beacon is at x=-32922, y=3577599",
"Sensor at x=3248397, y=2952817: closest beacon is at x=3212538, y=2537816",
        };
    }


}
