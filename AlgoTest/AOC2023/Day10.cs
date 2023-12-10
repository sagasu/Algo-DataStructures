﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.AOC2023;

[TestClass]
public class Day10
{
    [TestMethod]
    public void Test()
    {
        var lines = data.Split('\n', StringSplitOptions.TrimEntries);
        var (start, vector1, vector2) = FindStartPointAndInitialVectors(lines);

        var forward = start + vector1;
        var backward = start + vector2;

        var moves = 1;
        do
        {
            Move(forward, vector1, lines, out vector1);
            forward += vector1;
            Move(backward, vector2, lines, out vector2);
            backward += vector2;
            moves++;
        } while (forward != backward);

        Console.WriteLine(moves);
    }

    private static void Move(Point point, Size vector, string[] lines, out Size nextVector)
    {
        nextVector = vector;
        if (vector == new Size(0, -1))
        {
            MoveUp(point, lines, out nextVector);
        }
        else if (vector == new Size(0, 1))
        {
            MoveDown(point, lines, out nextVector);
        }
        else if (vector == new Size(-1, 0))
        {
            MoveLeft(point, lines, out nextVector);
        }
        else if (vector == new Size(1, 0))
        {
            MoveRight(point, lines, out nextVector);
        }
    }

    private static void MoveUp(Point point, string[] lines, out Size nextVector)
    {
        var next = GetMapValue(point.X, point.Y, lines);
        nextVector = next switch
        {
            '|' => new(0, -1),
            '7' => new(-1, 0),
            'F' => new(1, 0),
            _ => throw new ArgumentNullException($"Invalid character enountered - {next}")
        };
    }

    private static void MoveDown(Point point, string[] lines, out Size nextVector)
    {
        var next = GetMapValue(point.X, point.Y, lines);
        nextVector = next switch
        {
            '|' => new(0, 1),
            'L' => new(1, 0),
            'J' => new(-1, 0),
            _ => throw new ArgumentNullException($"Invalid character enountered - {next}")
        };
    }

    private static void MoveLeft(Point point, string[] lines, out Size nextVector)
    {
        var next = GetMapValue(point.X, point.Y, lines);
        nextVector = next switch
        {
            '-' => new(-1, 0),
            'L' => new(0, -1),
            'F' => new(0, 1),
            _ => throw new ArgumentNullException($"Invalid character enountered - {next}")
        };
    }

    private static void MoveRight(Point point, string[] lines, out Size nextVector)
    {
        var next = GetMapValue(point.X, point.Y, lines);
        nextVector = next switch
        {
            '-' => new(1, 0),
            'J' => new(0, -1),
            '7' => new(0, 1),
            _ => throw new ArgumentNullException($"Invalid character enountered - {next}")
        };
    }

    private static (Point, Size, Size) FindStartPointAndInitialVectors(string[] lines)
    {
        Point start = default;
        for (int y = 0; y < lines.Length; y++)
        {
            var x = lines[y].IndexOf('S');
            if (x >= 0)
            {
                start = new(x, y);
            }
        }

        var up = GetMapValue(start.X, start.Y - 1, lines);
        var down = GetMapValue(start.X, start.Y + 1, lines);
        var left = GetMapValue(start.X - 1, start.Y, lines);
        var right = GetMapValue(start.X + 1, start.Y, lines);

        List<Size> vectors = new();
        if ("|7F".Contains(up))
        {
            vectors.Add(new(0, -1));
        }

        if ("|LJ".Contains(down))
        {
            vectors.Add(new(0, 1));
        }

        if ("-LF".Contains(left))
        {
            vectors.Add(new(-1, 0));
        }

        if ("-J7".Contains(right))
        {
            vectors.Add(new(1, 0));
        }

        return (start, vectors.FirstOrDefault(), vectors.Skip(1).FirstOrDefault());
    }

    private static char GetMapValue(int x, int y, string[] lines)
    {
        if (x < 0 || x >= lines[0].Length || y < 0 || y >= lines.Length)
        {
            return char.MinValue;
        }

        return lines[y][x];
    }

    [TestMethod]
    public void Test2()
    {
        string oldpipes = "|-LJ7F", newpipes = "│─└┘┐┌";
        string[] validPipes = { "|7F", "-J7", "|LJ", "-LF" };
        string[] nextDirection = { "NWE", "ENS", "SEW", "WNS" };
        var directions = "NESW";
        int[] lookSN = { -1, 0, 1, 0 };
        int[] lookEW = { 0, 1, 0, -1 };
        int[] upordownvalues = { 2, 0, 1, -1, 1, -1 };


        int answer = 0, answer2 = 0;

        var ground = new List<char[]>();
        var pipeline = new List<char[]>();

        int startEW = -1, startSN = 0;
        foreach (var line in data.Split('\n', StringSplitOptions.TrimEntries))
        {
            var groundline = line.ToCharArray();
            ground.Add(groundline);
            if (startEW == -1)
                startEW = line.IndexOf('S');
            if (startEW == -1)
                startSN++;

            pipeline.Add(new string('.', line.Length).ToCharArray());
        }

        Console.WriteLine("Found S at {0} east and {1} south (0-indexed from NW corner)", startEW, startSN);

        int traceEW = startEW, traceSN = startSN, stepcount = 0;
        pipeline[traceSN][traceEW] = newpipes[oldpipes.IndexOf('7')];
        ;
        var looknext = 0;
        var foundFirst = false;
        do
        {
            stepcount++;
            Console.Write("Step {0} @ (E{1},S{2}) on '{3}:", stepcount, traceEW, traceSN, ground[traceSN][traceEW]);
            int pipeHit;

            do
            {
                if (traceEW + lookEW[looknext] >= 0 && traceEW + lookEW[looknext] < ground[traceSN].Length &&
                    traceSN + lookSN[looknext] >= 0 && traceSN + lookSN[looknext] < ground.Count)
                {
                    var groundChar = ground[traceSN + lookSN[looknext]][traceEW + lookEW[looknext]];
                    pipeHit = validPipes[looknext].IndexOf(groundChar);

                    if (pipeHit != -1)
                    {
                        // Console.WriteLine("\nFound {0} looking '{1}': Full loop completed in {2} steps.", groundChar, looking[i], stepcount);
                        Console.Write("Found {0} looking '{1}' Going E{2}, S{3}", groundChar, directions[looknext],
                            lookEW[looknext], lookSN[looknext]);
                        traceEW += lookEW[looknext];
                        traceSN += lookSN[looknext];
                        pipeline[traceSN][traceEW] = newpipes[oldpipes.IndexOf(groundChar)];
                        looknext = directions.IndexOf(nextDirection[looknext][pipeHit]);
                        Console.WriteLine(" and looking next to '{0}'.", directions[looknext]);
                        foundFirst = true;
                        break;
                    }

                    if (groundChar == 'S')
                    {
                        Console.WriteLine("\nFull loop completed after {0} steps.", stepcount);
                        traceEW += lookEW[looknext];
                        traceSN += lookSN[looknext];
                        break;
                    }
                }

                looknext++; // Loop until fornd first pipe
                if (looknext > 3)
                {
                    Console.WriteLine("Failed to fint a starting pipe!");
                    break;
                }
            } while (!foundFirst);
        } while ((traceEW != startEW || traceSN != startSN));

        answer = stepcount / 2;
        Console.WriteLine("The answer to part one is: {0}", answer);

        bool inside;
        int upordown, pipeIndex;
        Console.WriteLine("PIPELINE MAP WITH ENCLOSED TILES ('0'):");
        foreach (char[] groundline in pipeline)
        {
            inside = false;
            upordown = 0;
            foreach (char c in groundline)
            {
                if (inside && c == '.')
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write('I');
                    answer2++;
                }
                else
                {
                    pipeIndex = newpipes.IndexOf(c);
                    if (pipeIndex >= 0)
                    {
                        upordown += upordownvalues[pipeIndex];
                        if (Math.Abs(upordown) == 2)
                        {
                            upordown = 0;
                            inside = !inside;
                        }
                    }

                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(c);
                }
            }

            Console.WriteLine();
        }

        Console.WriteLine("The answer to part two is: {0}", answer2);
    }

    private string data = """
                            |-L.FL-FJFL.|7FJ7F|F7-7F77.FL7---.7FF77--.|-F|FF--7FF7F-7F--77FFFJFJF7.F-LF7LFJJ.F|.|77F7F---7FLL.|FFJ.FF7-77..F77.-F-7FL-FF|77F-FFLL-FJ-|.J
                            |7JF77-|L7J-F-JJL7|-|LJLF-|7.|.LLLJ7|-7.LFJFF--JF7L7|||FJ|F-J77L|F7.L-FJF----L7.FF.FJ-J-L-7|L|LJ7FJJJ.F|L-7L7.FF-|-7F-|J..||LJ-|-J-.|L|J|LF|
                            LJ-LL|F7|LL7LLL-|-F7||..||..FJ.FJJF-7JJ|.7JLL--7|L7LJLJ|FJL-77|..FFJ7FJ7L7-|-JL.F--7LJJ|LJJ.F-|L7.FF-L7-F-7F77|J7||FLFJ|FFLL7.|JFJJ--J|.7-7|
                            |.FJ.|F7-7L77|||L7JL-7LF777-JJ.|7F-L7JFJ7|F-|.LLJ|L---7||F--J7JFLF|JF-.--7||J.|F-.7LLLFF7||7F777L7FJ-||LJ7|||F|L-7.JJ.||7||J7.|-LL.7J.F7L7--
                            F-7LF||.FLJL-7|FF|L7FL-L||F-7|FL7LJ|L7L|.LLJ|FJJLF---7|||L---7L7|L|7||FLFLJ|-FF-7|777FJ7|-FFJ|L77LL-F.JJJL7LLJ.|L7FJFF-77LF-7-|-|77L|7.L--7|
                            F-JF-L7--J|JLL7-|LJ|F|J7L|J.J-|F7J7F|JF-7.|LF7F77L--7||LJF---JL-JJ|LJ7FJL7L|JLFJF|7FF7.-JJFL7|-F77J-777JF|L7J.|--L|J7|7LJ7JFJJ..|-J--7.L7.FJ
                            L7J|7||J--L-F7.||LFL-JF7.F7.|.FL7.FF7L|7F|FF-7F-7F7FJLJF7L----7JFFJJ.J|7L|7L7JLL|JFFJ7.|.|F-J|FJL7|F7-|F7JF|FF.|.||7L-J7LF-||.L7J7L7FJ7.L-.|
                            L7.L-FJJJF|FJ-.|JF--J7FJ7LLJ-..LJF||L-7F-7-L7|L7|||L--7|L-----J-FF-F7FL77|---F7JLL-|JF-77FL-7LJF-JFJ|-|-7-7L-7-7-JLJ-|L7-JJLF7-J-7|L77JFJJ.|
                            LL-|FJL7.L|J7|-L7F.|FL-.FJJ.F-F-F-7L-7LJFJ|F|L-JLJL7F7|L----7|.F7F7F7JJ-L--|JJ7|-7-LF|FJF7J|L-7||FJFJ.LLJ.77||.L.LF7LF-F77F-J.F7-J7L-F7FJF-.
                            FJ.|J7L77-7LL7J-7---FJ-FL---|||FJFJLLL-7|F7FL-----7||||F--7FJ-FJ||LJ||..LF7|JL--F||.FJL7||LF-7|L7|FJF7-.F-LJ.-7.F7.77F7||7-|L7LJJJFJ.FJJF-L.
                            |.F|F7-.|.JJ.L..L|JL7..FJL|FF-7L7L-7F--JLJ|7LF7F--JLJLJ|F7LJJFL7||F-J--J7|7..F|-FL|FL7FJ|L7L7LJFJ|L7||7F|J|L7.F7F77.FJ||L--7--7|7.L-7L-77J|7
                            LF-LL.L7J.FF-.F-||--.|-|-F--|FJ7L-7|L--7F7|F-J||F7F---7|||F7LFFJLJL7JL|.FF-77FF7JJF77|||L7L-JF-JLL7||L7F7|F-|.||||LFL7||F7FJ-LJ-77J-J7.LJF7J
                            FF.|..7JJ7FLJ7|L-7F|F|.|7LLL|L7F--JL7F7||LJL7FJLJLJLF7|||LJL7FJF---J-|F77|JL7L|||FJL-JL-7L--7L7F7FJ|L7||L7L-F-J|||F7F||||LJ7LLJ.7JFFLF-L7LJ-
                            L.FJ-|77--F||F77JJLF-7-J7F7LL7||F--7||LJL7|FJL-7F--7|||LJF--JL7|F-7JF--F7|.L7.|L7L----7FJF7FJFJ||L7|FJ||FJ77L-7LJ||L-JLJL7-|..-.|F7--77LJ-|J
                            F|.L7||--FLJ7.L7F-J|FJJFF7FF7||LJF7||L7F7L7L7F-JL-7||||F-JLF-7|LJFJ7JFLF--77L-L7|7FF-7|L7||L7L7||FJ|L7LJ|F7F-7|F-JL--7F--J7F|J-F|7|LLJL7JF|.
                            J|LF|FJFFL.|F7LLJ|.|L7F7||FJLJL--JLJL7LJL7L7|L--7FJLJLJ|LF-JFJ|F-JF7.|.L7FJF7JFJL7FJFJ|FJ||7L7||LJFJ7L7FJ||L7|||F-7F7||F7LLJJ7.FJ.F77JF|F7|F
                            ||JFJ|F|J|7|JJL|-7-L7LJ|||L-7F7F--7F7L7F7L7LJF--JL--7F7L7|F-JFJL-7||-F-7||FJL7L7FJL7L-JL7||F-JLJF-JLF-JL-J|FJLJLJFJ|LJLJ|7J.F|7LJL|--7FJF|||
                            L7--.LLJJ--|.FFJF-7-L-7||L-7LJ||F7LJL7LJL7L-7L-7F7F-J|L7LJL77L7F-J|L7L7|||L-7|FJL7FJF-7FJ||L-7F7|F7JL7F7F-JL--7F-J|L--7FJF77J|F|JLL7FLFLLJ|F
                            .JLLF77.L-.|.LJ-7||FF-J||F-JF7LJ|L--7L-7FJF7|F-J||L--JLL-7FJF7||F7L7|FJ||L7FJLJF-JL-J||L7|L-7LJ|||L7FJ|||JF7F-J|F--7F-JL-JL7F---7JJ|F-JJ7LL-
                            7-F7|FLJ7|7L-|.FJFL-L-7||L7FJL7LL-7FJF7|L-JLJL-7|L7F-7F7FJ|FJLJLJL7||L7||FJL-7FJF7F7F7|FJ|F-JF7|||FJ|FJLJFJ|L-7||F-JL--7F-7LJF--JJ7||||.7F|.
                            L7LL|J|FFJ7FL7.FFJFFF-JLJFJL7FJF7FJ|FJ||F7F---7||FJL7||||FJ|F-7F7FJ||FJLJL7FFJL-J||LJLJL7|L-7||||||L||F7FJFJF-JLJ|F7F7FJL7L7FJF7.F7J-FF.FL-7
                            LJ.LL7-J-JL|F|F---7FJF7F7L-7|L7|LJFJL7|LJLJF7FJLJL-7|LJ|||L||7LJLJJ|||F---JFJF---JL---7FJ|F-J|LJ||L7||||L7||L---7LJ|||L7FJ-|L-JL-J|.F-JFF.L7
                            FJF|.L--L|-FLFL--7|L7||||F-J|FJL-7L7FJ|7F--JLJF----JL-7LJL7|L---7F7|LJL-7F7|FJF-7F-7F7|L7|L-7L7FJ|FJ|||L7|L7-F-7L-7LJL-JL-7L--7F--J.|.7JL|L|
                            F-|77FJLFFJ|J.|F7|L7LJLJ||F-JL7F7L7|L7L7L----7L----7F7L-7FJ|F---J||L---7||LJL7L7|L7|||L7||F-JFJL-J|FJ||FJ|FJFJFJF7|F---7F7L7.LLJJJ.--7J.F777
                            |..77-L-7-.LF7FJLJFJ7FF-J|L--7||L7||FJFJF7F7L|F---7|||F7|L7|L--7FJL7F7FJ||F7FJFJ|FJLJL7|||L7FJF7F-JL7LJL7|L-JFJFJLJ|F7F|||FJ-LJ|LLL.J|F-F.|.
                            -7-LL|7FJ7L-|-|F-7L--7L-7|F7L|||FJ||L7|F|||L7||JF7LJ|LJ|L7||F--JL7FJ||L7|||LJL|FJL---7||||FJ|FJLJF--JF--J|F--JFJF--J|L7|||L7JFFF7L|7.L|F77J7
                            F|7J.-J-LL7L-JLJ7L7F-JF-JLJL-JLJ|FJL7|L7||L7LJL7||F7L-7L7|||L-7F7|L7|L7|||L---JL7F-7FJ||LJL-J|FF7L-7FJ|F-JL7F7L7L7F7|FJLJL-J-F-7.F|F7JL-JFFF
                            FLF.LLL7|.|-7.F7F7||F7L-------7FJL7FJL7|||LL7F-J|||L--JFJ|||F-J|||FJL7||LJF-----JL7||FJ|F---7L-J|F7||F7L--7|||.|FJ|LJ|F7.F7|7L7L7-J|FJL|LLJJ
                            LJ.|7|LF|7J.LFJLJLJLJL7F--7F--JL--JL7FJ|||F-JL-7||L---7|FJLJL-7|LJL77|||F-JF-7-F7FJLJ|7LJF--JF--J|||LJ|FF7|||L-JL-JF7LJ|FJL77FJFJ|.JJ7F-J|||
                            FF-|-J|LJ||7LL--7F7F7FJL-7|L-7F7F-7FJ|FJ|||F---J|L-7F-J||F----JL--7L7|LJ|F7L7L7||L--7L--7L--7L--7|||F-JFJLJLJF7F7F-JL--J|F7L-JFJJ-LJL-J.|F--
                            -J||-LJJF-F-J7L-LJLJ|L---JL--J|||FJ|FJ|FJ||L-7F-JF7|L-7LJL-7F-7F7L|FJL7FJ|L7L7|||F7FJF--JF7.|F--J|||L-7L--7F-JLJ|L------J|L---J7|-J7FFL77||J
                            LL||7.|LJ.|L-7L7-F-7|F7F-7F7F7|LJL7LJFJL7||F-JL--J||F7|F-7FJ|FJ|L-JL7FJL-JFJF||||||L7|F-7||FJL7F7|LJF-JFF-J|F--7L-7F-7F--J7F7|F7777LFL.LF-77
                            .LL-F-77J.J7-|-F7|FJLJLJ-LJLJLJ-F7L-7|F7|LJ|F7F7F-J|||LJFJL7|L7L---7LJF---JF7|||LJ|FJLJFJ||L7FJ||L-7L--7L-7LJF7L-7||FJL----JL-JL77FF|-|-7|LL
                            F7.F|-|--7JFF77|||L7F---7|F7FFF7|L--J|||L-7LJLJ||F7LJ|F7L7FJL7|F7F-JF7|F--7||||L-7LJF--JFJ|FJL7||F7L7F-JF7|F-JL-7|||L7F--------7L7----|FJ-7L
                            L|-L--|FFFF7||FJ|L7|L--7|FJL7FJ|L---7|||F7|F---JLJL7FJ||7||F7||||L7FJLJ|F-J||||F7L-7|F77L7|L7FJ||||L||F7|||L---7LJLJFJL-------7|FJ-77JF77.7J
                            F--||.F--7||||L7|J|L---JLJF7|L7|7F--JLJ|||||F-7F7F-JL7|L7|||||||L7||F7FJ|F7|||||L7FJ||L7FJL7||FJ||L7|||LJLJF7F7L--7-L-7F7F----J||--J-7LLJ-JJ
                            LJFJ|FL-7LJLJL-JL7L----7F7|||FJL7L---7F||LJ||FJ||L7F-J|FJ|LJ||LJ-||LJ|L7LJ||||||FJL7||FJ|-FJ|||FJL7||||F---JLJL--7L--7|||L-7..LLJ7|.|F7FJ7L7
                            |.L7L-|-|F7F-7F-7|-F7F7LJ|||LJF7L77F7|FJL-7|||FJ|FJL-7|L7|F-JL--7LJF7L7L7FJ|||LJ|F-J|||FJFJFJ||L7FJ||||L---7F---7|F--JLJL--J-FF7JLL-F7LJ||J.
                            -J-LJ7LFLJ|L7|L7|L-JLJL-7LJL7FJL7L-J|||F7FJ||||7LJF--JL7||L7F7F7L7FJL7L7|L7|||F7|L-7||||FL7|FJL7|L7||LJF---J|F7FJ|L-7F-7F7F7-FJ|-|.F777F|JFJ
                            |F-LL7F|J.|FJL-JL7F----7|.F7LJF7L--7LJLJ|L7|||L--7L7F7FJ||J||LJ|FJ|F7L-J|F|||LJ||F-J||LJF-J||F-J|FJLJF7L----J|||-L--JL7||LJL7|FJJ|-|L-7JJ.L7
                            L-J.|L7JJ.LJ.F7F7LJ|F7FJL7|L--JL--7L7F7.|FJLJ|F--J.LJ|L7||FJL7FJL7LJL7F7|FJ|L7FJ|L7-|L-7L7FJ||JFJL7F-JL------JLJF7F7F7|||F--J|L-77.|F-JJ7JF|
                            |-7F|J|.|.F7.|LJL---J|L-7LJF7F7F-7L-J|L7|L7F-JL---7F7|FJLJ|F7|L7FJF7F||||L7|L|L7L7L7|F-J.||JLJFJF-JL-----------7|||||||LJL7F7|F-J7-|L-7.F.-L
                            F7L7|L|F-7|L-JF-----7L--JF7|LJLJFL---JFJ|FJL-7F7F7||LJL--7LJ||-LJFJL7LJ||J||FJFJ7|FJLJF--J|F--JFJFF7F---------7LJ||LJLJF7FJ|||L7F7FJF-J7|F..
                            .FFFJ.|7.F|F7FJF-7F7L--7FJ||F7LF7F----JFLJF7FJ|||||L7F7F7|FFJL--7|F7L--JL7|||FJF-JL-7.L7F7|L--7||FJLJF-------7L--J|F---JLJFJ||FJ|LJFJ|7L|J.F
                            --7|LJ-JF-LJLJ|L7LJL---JL7LJ||FJ|L-7F--7F7||L7|LJ||7||LJ|L7L7F-7|||L7F-7FJ||LJ-L7F--JF7LJLJF--JL7L7F-JJF-----JF---JL--7F77|FJ||FJF7L-7--J||J
                            FLLJ-LF7J||F-7F7L---7F7F-JF7||L7L-7LJF7|||||7LJF7LJFJL-7|FJFJL7LJLJFJL7||FJ|F---JL---JL-7F-JF-7FJFJ|FF7L-----7|F------J||FJL7|LJFJ|F7|F|FFL7
                            JL---77J|--L7LJL-7F-J|LJF-JLJ|7|F7L--JLJ|LJL---JL-7|F7FJ|L7|F7L--7FJF7|||L7||F7F7F7F-7F7||F-JFJL7L-JFJL------J|L---7F--J|L7FJ|F-JLLJ||7LFJFJ
                            .|L7||JF--JL|F7F7||F7|F-JF7F7L-J||F7F7JFJF7F7F7F--J|||L7L7||||F-7|L7|||||FJ|||||LJ|L7||||LJ-FJF7|F7FJF----7F7.|F---J|F--JF|L-JL-7L|-LJ--77FL
                            L7LLJ.LJ.|FLLJ||||LJ||L--JLJL7F-JLJLJL-JFJLJ|||L--7|||FJ7||||||FLJF||||LJL7||||L-7|FJ||||F--JFJLJ|LJFJF---J|L7||F7F7||F7|FJF---7L7-7L|-L-7J|
                            .J7.LL7F--J-||LJ|L-7||F-7F7F7LJF----7F--JF7.LJL7F-J|||L-7|||||L7F--J|LJ-F-J|||L7FJ|||LJ||L7F7L7FSL--J.L--7.L7||LJLJLJLJL7L7L--7|FJF-F|7|LL-7
                            F||JJFFFJ|FFFF-7L7FJLJL7|||||F7L---7||F7F|L---7||F7|||F7||||||FJL7F7L--7|F7|||FJ|FJL--7|L7LJL7||L----7F--JF7|||F--------JFJF--JLJ7L7F777|.|L
                            FL77.F777FF7JL7L-JL7LF7|LJ||LJL----JLJ||FJF7F7||LJ|LJ||LJ||||||F-J|L7F7|LJ|||||FJ|F7F-JL-JF77LJL---7FJL---JLJLJL----7.F7-|FJF--7F7L7J|JL-.L|
                            |.L-77JL7F7F7.L--7FJFJ|L-7|L----------JLJFJ|||||F-JF7||F7LJLJLJ|F7|FJ||L-7||||||FJ|||F-7LFJ|F-7F7F-J|F7F--------7F--JFJL7|L-JF7LJL--77--J7L-
                            L7FL7J|L7|LJL----JL-JFJF-J|F-7|F7F--7F7F-JFLJLJLJF-J||LJL7|F--7LJLJL7||F-JLJ||LJL-JLJ|FJFJFJ|FJ||L-7LJ|L-----7F7LJF-7|F-J|F--JL7F---J..F|LF|
                            |.|LJL|-FL----------7|-L-7|L7L7||L-7|||L7F-----7LL7FJL7F7L7|F-J-F---J||L-7F-JL7FF7F-7|L7L7L-JL7||F7L-7|F----7LJ|F7L7||L--JL---7LJ7|7-J-7|-7|
                            |.LF7FJF7F7-F7F-----JL-7FJ|7L7LJL--JLJL7LJF----JF-J|F7LJL7LJL-7FL----J|F-JL7F7|FJ||FJL7|FJF7F7LJLJ|F7||L---7|F7LJL7|||F--7F7F7L--7F77.LLJLJ7
                            L7LJ7J|LFJL7||L-------7|L7|F7L--------7L7FJF---7L-7LJL--7L-7F7|F------JL-7FJ|||L7LJL--JLJFJLJL--7FJ|||L----J|||F-7LJLJL-7||||L7F7LJL-7-LJ||J
                            F|7LF-7FJF7LJL--------JL-JLJL---7F7F--J7LJ.L7F-JF-JF7F--JF7LJ|||F7F-7F7F7||FJ||7L----7F-7L7F--7FJL-J|L7F---7||LJFJF-----JLJ|L7LJ|F7F-J7F-|J|
                            77-7L7LJFJL7F7F7F7F7F---7F-7F7F7LJLJF7F7FF7-|L-7|F-JLJLF-JL-7LJ||LJFJ||||||L7||F-----JL7L-JL-7LJF--7L-J|F--JLJF7L7L---7-F7FJFJLFJ||L-7F|F7LL
                            ||LJ.L7FJF-J|LJLJ||LJ-F-J|FJ|LJL-7F7|||L-JL7|F-J|L----7L-7F-JLLLJF-JFJ|||||FJ|||F----7FJF----JF7L-7L7F7|L-----JL7|F7F7L7||L-JF7|FJL--JFF777|
                            F-.J7LLJF|F-JF77FJ|F--JF7|L-J.F--J|LJLJF7F7LJL--JF----JF7|L7F7|JL|F7|F||LJ|||LJLJF---JL7L7F-7FJ|F-J7LJLJF------7|LJLJL7|||F77||LJLF7|F7|L77|
                            F-|LJ7.|F||F-JL-JFJL7F-JLJF7F7L7F-JF-7FJ|||F7F7F7|F-7F7|||FJ||77LLJLJFJL7.||F----JF7F7FJL|L7LJFJL-7F---7L-----7LJF---7LJ|LJL-JL---J|FJLJFJF7
                            .FL77F|LFLJL--7F7|F7||F---JLJL7LJF-J-LJFJ|LJ||LJLJL7||||LJ|FJL7-|.|L-L-7|-LJL--7F7||||L7FJFJF-JF7FJL7F7L------JF7|F--JF7|F------7F-J|F-7L-J|
                            FL7|L77FJ|FF-7|||||LJ|L7F7F-7FJF7L----7L7L-7LJF7FF7|LJLJF-JL7FJ-F--7|L.LJ-||F--J|||LJ|FJL7L7|F-JLJF7LJ|F-------JLJL---J||L7F---7|L--J|LL7F7|
                            FJ77.L-7JFLL7|LJ||L--J|LJLJFJL-JL-----JLL-7L7FJL7|||F7F7L7JFJL7.|FLFF-FJ|7.LL7F7|LJF7||F7L7||L7F--JL--J|F--7F7F--------J|FJ|F--JL7F-7L-7||LJ
                            |LFL-7.-JFJFJL-7LJF-7-F7F7LL--7F7F-7F7F7F7L-J|F-J||||LJL7L-JF-JF77-|J7J-J7-|.||LJF7||LJ|L7LJL-JL-------JL-7|||L---------JL-JL-7LF||||F-J||JJ
                            -.F|-L.L-F-JF-7|FFJFJFJLJL-7F-J|||JLJ||||L--7|L--JLJL--7L---JF-J|-7|J||7LJ7LLLJJF|LJL7-|FJF--7F7F7F-------J||L7F-7F-----7F7F7FJF7LJ-||JLLJ..
                            LF-|JL|JLL-7|FJL-JFJFJF-7F7|L7FJ||F--J|||F--J|F-7F7F7F7L-----JF-J-|J-|FFJ|-JFLF|-L-7FJFJ|FJF7LJLJ|L---7F-7FLJ|LJFJ|F-7F7LJLJ|L-JL7J|LJ77.|F7
                            FL.|..L-JF7LJL---7L-JFJFLJ||FJ|LLJL---JLJL-7FJL7LJ|||||F-7F7F7L-7-|J7L--7FJFFFFJ7LFJL7L7|L-JL7F-7L7F7|LJLL----77L-JL7LJL7.F7L---7L--7-LF-7.7
                            |FJ77F-J-||F----7L--7L7F--J|L-JF------7F---J|F-JF7LJLJ|L7|||||F7|J|F|F-7|J|F-J|F7FJF-JFJL7F7FJ||L7LJL---------JF7.F7|F-7L-JL---7L7F-J7-|-F7|
                            L||L--JF-JLJF7F7L--7L-JL--7L--7L-----7||-F7FJL7FJL--7FL7|||LJ||LJ.|-F-J|.F7JF7F||L7|F7L7FJ||L-JF7L-------------J|FJ||L7L--7F--7L7LJ||.||L7-J
                            .JJJ.J||F7F-JLJL7F7L7F7|F7L-7FJF-----J|L-JLJF-JL7F-7L-7||LJ7FLJJF77L-7||F-JLF7FJL-JLJ|FJ|FJL-7FJL----7F---------JL7||FJ.F7LJF7L7L---77F--|-L
                            FL|.FJFLJ||F----J|L7LJ|FJL--J|-L-7F7F7L7F7F7L---JL7L7FJ|L7F--7JFJL-7||-|L|.|||L-----7LJFJL--7|L-----7|L----7F7F7F7|LJL-7|L7FJL7|F---J-JJFF-L
                            -.FJ|.F|7LJL-----J|L-7|L----7|F7JLJLJL7|||||F7F7F7L7||FL7LJF-J7F|-LL77.J.77FJL------JF7L-7FFJL7F----JL--7F7LJ||||LJF7F-J|FJ|F-JLJF7J.FJ-F|7|
                            L-F-7-F|J7FF7F----77FJL-----JLJ|F-----JLJ||||LJ|||FJ|L-7|F7L7-L.|JJL|J-F7.LL--7F7F7F7||F7L7L7FJL----7F-7|||F7LJLJF-J|L--JL-JL---7||7F7J|FJFL
                            LFJL|LJL|F-J|L--7FJFJF----7F--7LJF---7F77LJ|L-7||LJFL--JLJL-J.FJ.777L7FF7.L7.|LJ||LJLJLJL7L-JL7F7F77LJFJLJLJL7F-7L-7|F-7F7F-----J|L7-J.-J7F7
                            7J.|JF|7-L-7|JF7|L-JFJF-7FJ|F-JF7|F-7LJL-7FJF7||L-----7F7-F--7JJ-F7J-FL-..LLF7JLLJJ-F7.F-JF7F7LJLJL--7L-----7LJ7L--J|L7|||L------JFJ7|||FFL|
                            |7L.L||JLF-JL-JLJF7FJ7L7LJFJL7FJ||L7L----J|FJLJL7F----J|L-JF7|J.FF7-F7F||7L||L----7FJL7L--JLJL7F-7F-7L-----7L-7F7F7-L-JLJ|F7F-7F--JF7FF--JL|
                            |7-|.L|..L---7F7FJ||F--JF7L7FJ|FJL7L---7F7LJF---JL--7F7|F--JLJF7FJ|7F7J7F7FFL----7|L7FJF7F7F77LJFJ|FJF----7L7FJ|LJL--7F--J|LJJLJF--JL7J.|.FJ
                            FJ7L|J|FF--7FJ|LJ7LJL--7|L7|L-JL--JF7F7LJL7|L------7LJLJL-----J|L7L--7.-JL-F.LF--JL-JL7|LJLJL-7FL-JL7|F-7FJ|LJFJF----JL--7L---7FJF7F7|.FJ-|7
                            L7|J|JL-L-7|L7|F-------JL7LJF----7-||||F-7L-7F7.F-7L7F7F7F7F7F-J-|F--J7|-J|JFLL-----7FJL-7F7F-JF7JF7LJL7|L----JFJFF77F-7FJF--7LJFJ||||F--|.|
                            L|.FF7|LLFJL7LJL-7F------JF7L---7L-JLJLJF|F-J|L7|FJ7LJLJLJLJLJJFFJ|L|FF-7|F7JLF-7F--J|F-7LJ||F7|L7|L---JL---7F7|F7|L-JFJL7L-7|F7|7||||7LF-|7
                            -L-FFFJ7FL-7|F--7LJF------J|F---JF----7F7LJF7|FJ||FF7F----7F--7-L7L7|7L7L-7LF|L7|L--7|L7L--JLJ||FJL--------7|||LJLJF7FJF-JF-J|||L7||LJL7|J|L
                            JLLLJ|-F---J|L-7|F7L7F7F--7|L--7FJLF--J|||FJ||L-J|FJLJF---J|F-JF-JFJF7|L7FJF7F7|L---JL-JF-7F-7LJL7F--------J||L7F--JLJ-L-7L-7LJL-JLJJ|J.F7F7
                            LL7LL||L---7L7FJLJL7||LJF-JL--7LJF-JF-7|L7|FJ|F--J|F--JF7F7|L-7L-7|-|L7||L7|LJLJF7F-7F-7|FJ|JL7F7|L----7F7F7LJJ|L-------7|F7L---7L|7L|-F-JLJ
                            .F|7|.F-7F7L7|L--7FJLJF7L----7L7JL-7|FJ|FJ||FJL-7FJ|F--JLJLJF-JF7||FJFJFJFJ|F--7|LJLLJFJ|L-JF7LJ||7F7F7LJLJL--7L-------7|LJ|F-7FJ.L7-|L.FJJ7
                            LJ|FF-L7LJL-JL-7FJL7F7||F7F-7L7L-7FJ||J|L-JLJF7FJL7LJF------JF7||||L7L7L7|-LJF7LJF----JFJF--JL--JL-JLJ|F-----7L-------7|L-7||L||-L-F77.FFJ.J
                            ||L77FFJF-----7LJF7LJLJLJ|L7||L-7|L-JL7|F--7FJLJF7|F7L-7F--7FJLJLJL7|FJL|L7F7|L-7L----7L7L-7F7F7F7F7F7LJF--7LL--------JL--JLJ-LJ.|.L--FJ.F||
                            .F7FF7L-JJF7F-JF-JL-7F--7|FJL---JL---7LJL-7|L---JLJ|L7FJL7FJL7F---7|||7-|FJ||L7FJF7F--JFJF7LJLJLJLJLJL--JF-JF7F----------7F7F7J.F77FL-L|.F7-
                            F|FFJL7F7F||L-7|FF7|LJF-J|L7F---7F--7|F-7FJL--7F7F-JF||F7|L-7LJF--JLJL7FJ|FJ|FJ|-||L7F-JFJL7F7F-7F7F-----JF7|||F--------7LJLJL-7-7-|F--F7JL|
                            -FLL-7LJL-JL--J|FJ|F7JL-7L-J|F--J|F-JLJFJL---7|||L--7|||||F-JF7L----7FJL7|L7|L7|FJL7||F7L-7LJ||FJ||L------JLJLJL7JF----7L------J.|J|F-FLJ..F
                            LLLF-JF-7F7F-7FJL7LJL---JF7FJ|F7FJL7-F7L---7FJLJ|F--JLJ||||F7||JF7F7||J.||FJ|FJLJF7|LJ||F-JF7LJL-J||F7F7F--7F7F7L7|F---J7F7F----7JJLF77-77.|
                            |LFL-7L7||||FJL7LL7F-7F7FJ|L7LJ||F-JFJL---7||F-7LJF7F7FJLJLJLJ|FJLJLJL7FJ|L7|L7F-JLJ7FJ|L--JL7F-7FJFJLJ|L7FLJLJL-J||F7F--JLJF---J-LJ|L|---77
                            J7|JLL7|||||L--JF7||FJ|||FJFJF-J|L--JF----JLJ|FJF7|LJ|L-7F----JL-----7|L7|FJL-JL7F7-FJFJ|F7F7||FJL7L-7FJFL-----7F7|||||F---7L7F7F7|FF777L-JF
                            |F7J.F||LJLJF7F7|LJ|L7|LJL-JJL--JF---JF----7F|L-J|L7FJF-J|F7FF7F--7JFJ|FJ|L----7LJ|FJFJJFJ||LJ|L-7|JFJL--------J|LJLJ|||F-7L-J|LJL7FJ|7--JFJ
                            L7J.-L||F---JLJLJF7L7LJFF---7F--7L-7F7L7F--JFJF7FJFJL7L-7||L7|||F-JFJFJ|FJ|F--7L-7LJFJF7|FJL7FJF-JL-JF7F----7F-7|F---J|||FJF7.L-7FJ|FJ..FFF7
                            ||.L|JLJL7F7F-7F7|L-JF7FJF-7LJF-JF-J||FJL7F-JFJ||FJF-JF-JLJFJ||||7FJFJFJ|F-JF-JF7L7FJFJ|||JLLJJL7F7F7|||F-7FJL7|||JF-7|LJL7|L7F7|L7|L77-FLL-
                            |77||7|.LLJ||FJ|||F--JLJFJFJF7L--JF7|LJF-J|F-J.LJL7L7.L---7L7||||FJFJ|L7LJF-JF7|L-J|FJFJ|L7F7F--J|||LJLJL7LJ-FJ||L7L7||F--J|FJ||L7||FJF-7JJJ
                            |J|-7-JFLLFJ|L7|||L----7|-L-JL----JLJF7L-7||LF77F7L7L7F7F7|FJ|||||FJF77L-7|F7||L7F-JL7|F|FJ||L--7|LJF-7F-J|F7|FJ|FJ7||||JF7|L7|L7|LJL-JFJJ||
                            |.|LJL|7|.L7|FJ|LJF----J|F-------7F--J|F-J|L7|L7||FJFJ||||||FJ||||L7|L--7|||||L-J|LF-JL7|L7|L7F7LJF7L7LJF--JLJL-JL--JLJL-JLJFJL7||F---7||.F7
                            7FJ7JFJ-LF7LJL-JF7L-----JL------7|L--7LJF-JFJ|FJ|||FJFJLJLJLJFJ|||FJL7F7||LJ|L--7L7L-7FJL7|L7||L7FJ|FJF-JF7F7F---7F-7F-7F7F7L--JLJL-7-LJ77L-
                            FJF|-|J-J|--FLF-JL--7F----------JL---JF7L7FJF||FJLJL7|F--7F--JFJ|||F7LJ||L-7|F7J|FJF7|L-7||FJ||FJL7|L-JF-JLJLJJF7LJFLJL|||||F7F7F7F7L77|||7|
                            F7F-7|F|FL-77JL----7|L-7F7F7F7F-----7FJL-JL7FJ|L--7FJLJF7|L7F7|FJ|||L7FJ|F7||||FJ|FJ||F-J||L7|||F7||F7FL---7LF7|L-----7||||LJLJ||||L7L77JLFJ
                            |-J|-|F|7J.LL-.F7F7||F-J|LJLJLJF-7F-JL---7FJL7|F7FJ|F7FJ||FJ||||FJ||FJL7LJLJ||LJFJL7|||F-J|FJ|||||||||F7F--JFJLJF---7FJLJ|L---7||LJ||FJ|.7.|
                            7FFJF-F--.|F-JF|LJLJLJF7|F-77F7|FJL7LF7F7||F7||||L7||||FJ||7|||||FJ||F7L---7||F-J.L||||L-7||FJ||||||||||L-7J|F-7L--7||F7.|F7F7|LJJF7LJF-..F7
                            -FJFJF|JJ7L|JL|L---7F7|LJL7L-JLJL--JFJ||||||||LJ|FJ||LJ|FJL7||||||FJ|||F-7FJ||L7F7FJ||L7FJ||L7||||||||||F7L-JL7|F7FJ|LJL7|||||L---JL--7|FLF-
                            L|-|F7.L7--7FF-F---J|||F--JF7F7F-7F-JFJ|LJ||||F-J|FJ|FFJL7FJ|LJ|||L7||||FJL7||FJ|||J||-||-LJFJ|LJ||||LJ|||F7F-J||LJLL-7FJ|||||F-7F7F--J--LJ|
                            .|FJF-7-LLLLFJ.L---7|||L7F-JLJ||FJ|F-JFJF-J|LJL7FJL7L7L-7|L7L-7|||FJ|||||F7|LJL7|||FJL7||F7-|FJF-J|||F-J||||L-7|L7F-7L|L7LJLJ|L7|||L-7J|LJF7
                            F7J|L|-.J.|.JJ.LLF-J||L7LJF---J|L7|L-7|JL-7|F--JL7FJFJF7LJFJF7||||L7||LJ||LJFF7LJ||L7FJ|LJL7|L7L7FJ||L-7|LJ|F-JL7LJFJFJFJLF7FL-JLJL--JL7-7LJ
                            LJ.FLJ|.|F-7|7-JJ|F7|L-JF7L----JFJL7FJL7-FJ|L7F7FJL7L-JL-7L7|LJLJ|FJ|L7J|L-7FJL--J|.|L7|F-7|L7L7||||L7FJL-7|L--7|F-JJL7L-7|L------7L|7F|.|J|
                            L77JLF|7|.L|LJ7.|LJLJF--J|F-----JF-JL-7L7L7L7LJ||F-JF--7FJFJL--7FJ|FJFJFJF7|L-7F7FJFJFJ|L7||FJFJ|L7|FJL7F-J|F-7|LJ|F-7|F7LJF------J-F|J|7.LL
                            ||J7F7LJ-7|L-LL7F|L||L--7|L7F-7F7L7F--JFJLL7|F-J||F7L7LLJFJF7F-J|FJL-JFJFJ||F-J|||||FJFJFJ||L7||L7|||F-JL7FLJ||L---JFJ|||F-JF-----7L||LJ7F7|
                            LJ-L7LF7.F7|7LJLF|7FF7F-JL7LJ-LJ|FJL--7|J7|LJL-7|||L7L--7|FJ||F-JL7F--JFJ7LJL-7||L7|||L7|FJL7LJF7LJ||L--7L---7L7F7F-JFJ||L-7|F----J|LJ7L7JL7
                            L||LL-L|77-FL-J.LLF-J|L7F7L-----J|-F7FJL7FFF7F7LJ|L7|F-7|||-|||F-7||F-7L7F----J||FJ|L-7LJ|F7|F-JL--JL7F-JF7F-J.|||L-7L7||F7LJ|F--7L7.L7-L.LL
                            7--7..7L|-J|L-7F.FL-7L7LJL---7F-7L7|LJF7L7FJLJL--JFJ||FJ||L7||LJ-LJ|L7L7|L-7F-7|LJFJF7L-7|||||F7F7F7FJ|F7||L--7|||F7||||LJ|F7LJF-JF77F7JL-7.
                            |J7|..JFL.F|7L7JFF|7L7L------JL7L7|L7FJL7|L7F--7F7L7|||FJ|FJ|L-7FF-JFJFJ|F-JL7||F7|FJL--JLJ||||LJ|||L7LJLJ|F--JLJLJLJFJL-7|||F7L--JL-7LF7.L7
                            .FF.J-JF-L-7--F.F.F7FJF-7F7F---J-LJFJ|F7LJFJ|F7||L7|||||FJL7|F7|FJF7L7|FJL7F7||||LJL------7|||||FJ|L7|7F--JL------7F7L7F-JLJ||L7F7F-7|7LL-J|
                            .F|.L|.F7JFJJL7.LF|LJFJ|LJLJF----77L7LJL-7|FJ|||L7|||||||F7|||LJ|FJ|FJLJF-J|||LJL7F7F7F7F7|LJ||FJFJFJL7|F--7F7F---J||L|L---7LJJLJLJLLJJJ.|JF
                            FLJJFFFF77J-J7|..FJF7|F--7F-JF--7L7F|F7F-JLJFJLJFJ|||||||||||L-7||FJL--7L--J||F--J|||LJ||LJF7LJL7||L7FJ||F-J|||LF7FJL7L7F--J7L7JJ7..LL7FF77J
                            L-JJL7-7J--7JLJ.LL-JLJL-7|L--JF7L7L-J|||7F--JF7FJFJ||||||||||F-JLJL-7F-JF7F-J|L7F7||L-7LJ7FJ|F--J|F-JL7|||F7||L-J||F-JFJL-7JJ7|FFF7FFJ-7LJL.
                            FL7-|J.L7LJJF-F--F------JL-7F-JL-JF-7||L7|F7FJLJFJFJ|||||||||L7-F7JFJL--J|L-7|F|||||F7L7F7|FJL7F7|L-7FJ||LJ|||F-7LJL-7L---JJLFJ7F|-JJ7LL7-|7
                            77|.|L7LL7J--.L.-L----7F7F7LJF-7F-JFJ||FJLJ|L7F7L7L7||||LJLJ|FJFJL-JF7F-7|F-J|FJ|||||L7LJLJ|F-J||||FJL7LJF-J|||FJF7F7L----77FL7|JL77J|F|-FL7
                            J-77J7L7LF-7L-LFJ|L|L|LJLJ|F7|FJL77L7||L7F-JFJ|L-JFJLJ|L---7|L7L-7F7|LJ.||L-7|L7|||LJFJF-7FJL--J||FJF7L7FJF7|||L7||||F7F7FJ77JF--LJJ-LJJLJJJ
                            |..--|LJ7.FJJ.L--F-F7F7F7FJ|LJ|F-JF-J|L7||F7L7L7F7L--7L7F7FJ|FJF-J||L--7LJF7||7|||L-7L7|-LJF7F7.LJ|FJ|FJL7|||LJFJ|LJLJLJLJ.JJ.---JJ|JF7|-FJJ
                            L-J-F|.FJF|FFF-7J.L|LJLJLJFJF-JL7|L-7L7||LJL7|FJ||F--JFJ|LJF|L7|F7|L7F7|F-JLJL7LJL--JFJL---JLJL77FJL7||L||||L7JL7L-----7J77|F|-7LFJ|-LF--J|7
                            LJ7LJJ.LJ-F|JL7L7--L-7F-7FJL|F7FJF--JFJ|L--7||L-J|L-7|L7L--7L-JLJ||FJ|||L-7F-7L-7|F--JF-7F-----JFJF7||L-7||L7|F-JF-7F--JLFJL-LJF7F7|.FF7-J7.
                            F-LF7.JJ|L-F7F7FJ7|JFJ|FJL-7||||FJF7FJL|F-7|||F--JF7L-7L---JF----J|L7||L7F||LL7FJFJF-7L7|L7F7F-7|FJ|||F7|LJLLJL7FJFJL---77.L77L-JJLF|.JJJ7.J
                            |-LL-7JF7.FL-|J7|F7FL-JL7F-JLJ||L7||L-7||FJ|LJL--7|L-7L-7F7JL-7F7FJ|||L-JFJL7FJL7L7|FJFJL7LJLJFJ||FJ||||L7F-7F-JL7|F-7F7L7JJL7|L-F--|-LJ.FF.
                            L7LF-7LJJF|FL.LJ7J.F.F7FJL-7F-J|JLJL7FJLJ|FJ7F7F-JL-7|F-J|L-7F|||L7FJL--7L7FJ|F7|-LJL7L-7L7F7FJFJ||FJ||L7LJFJL-7FJ|L7LJL-J|-|F|LF7.LJ.LF|FJ7
                            LJFL-J7.L-LF-F-L|JLF7|LJF7FJL7FJF---JL7F7LJ-FJ|L--7FJ|L--JF-J-LJL-JL-7F-JFJL7||||F---JF7|FJ||L7|FJ|L7LJLL7FJF--J|.L7L--7JL7-F|F7JL-.L|7LL|-7
                            JFJLL-L7J.||F7JLJ7J||L7FJ||FFJ||L7F7F7LJL-7-L7L---JL7|F-7FJ.F|-|-|JJLLJJFL-7|||LJL7F7FJ|||FJL7|LJLL7L7F--J|LL7F7L-7L7F7|.|L7LL7J||LJ.FF7||F-
                            .|J||7JF-7FJ-J-FJFFJL-JL7LJFL7L7L||LJ|F-7FJF-JF7F7F7|||FJ|7-J7.|FF-L7J-LF--J||L-7FJ||L7LJ||7FJ||7..L-JL--7L-7LJ|F-J||||L7---7L|-FFFJF-JLF7J.
                            FJ7JFLFF..JJ||F--LL---7FJJ-FJL7|FJ|F-JL7LJFJF7|LJ||LJ||L7|-.LJ7LJ||7||LFJF-7|L7FJL-JL7L-7|L7L7L-7-J|.F7.FJF7L7FJL7F-LJL-JJ|.|.|JLJ||-|F.-|..
                            F.F----J.F|LF7F7-|JLJ-||JL.F-L||L-J|F-7L-7L7|||F-JL-7|L7||.|7FF7FFFJ-L-L7|FJ|7LJ.LF7FJF-J|FJ-L7FJ7JF-|L-JFJ|FJL-7L7.L..|L7JF7-|J7-F.L7JFJJ7F
                            LLJL|FJJ7LF-J7|7F||J|.||F|F--7LJJFFJ|FJF7L7LJLJL7F7FJL-J||.LLLLJJL7.7J|LLJL7|7F---JLJFJ-FJL7-LLJJLFJFL7F7L7LJJ..|FJ7..FJ7.LLJ|.FF-J--7F-.77|
                            -7JLF||-|LJJ..LJJ||FJ-LJ7J-J.7JFF-L-JL7||FJ-J.LFJ|||J...LJ--7L7J|7J7L-L77.FJL7L-----7L-7|F7|J|FJJL.F|L||L7|J|.-FJ|JF-77..FFJFFLJ-7L-J.F.JJ--
                            J777L|7L--LJF-|7L7J7.LJ7F.|..F.|.J.L|.LJ|||-J-FL7|||LL..||.LFFJF--F-.F|F-7L--JJLLLF-JF-JLJ||F77.FL.|J.|||LJL---L7|7LLFF7-FJJLLJ|F7.|.7|J|F|J
                            L--J.7|.|.FF7--7.J-F|--F|-7.FL7|7..FL-J-LJ-7|JLF||LJ7|7.FFJ7JLL7F7JJ.F|J.FJ.JJ.7.LL7FJJL7LLJ-J77FJ-|FFLJJ7|.|FFL||--7|J.|.L77L-L|7FL7-|L7-77
                            LJ-LJ.F-|.7|...||7F77|F|J-.|FLFL77-|J.|.|JLJJ|LLLJ|-F|77-||L|.F-FJJ.|-LJ7L7J.F--7LLLJ.FJJ.F|J-|||.F|FFJ|||7.|-J-LJ.L--7L--|FFJJ7.F7J|-JL-.F7
                            7JFF.FF-L-LJJJ-7JL7LLL|7JJ.LJJLLLFJLFJ7JJL.LL--JJLJ..JLL-FF---J.J.F.L.J.|-|LFF--7-L|-LF.J-JJJLLF--L-|J.L|L|.J-J.LLJJ-L|.|-L-F---J.LJJJ.FJL|7
                          """;
}