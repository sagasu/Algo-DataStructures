﻿using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.AOC2023;

[TestClass]
public class Day18_Part2
{
    [TestMethod]
    public void Test()
    {
        var result = SolvePart2(data.Split('\n',StringSplitOptions.TrimEntries));
        Console.WriteLine(result);
    }

    public static long SolvePart2(IEnumerable<string> input)
    {
        var (currR, currC) = (0, 0);
        var points = new List<(long,long)>{(0, 0)};
        long dugPoints = 0;

        foreach (var line in input)
        {
            var lineArr = line.Split(' ');

            var code = lineArr[2][2..7];
            var distance = int.Parse(code, System.Globalization.NumberStyles.HexNumber);
            dugPoints += distance;
            var dir = lineArr[2][7];
            var (dR, dC) = GetDirectionP2(dir, distance);

            (currR, currC) = (currR + dR, currC + dC);
            points.Add((currR, currC));
        }

        var area = CalculateArea(points.ToArray());
        var pointsInside = CalculateInsidePoints(area, dugPoints);
        return dugPoints + pointsInside;
    }

    public static long CalculateInsidePoints(long area, long boundary) => area - boundary / 2 + 1;

    public static long CalculateArea((long, long)[] points)
    {
        long sum = 0;
        for (int i = 0; i < points.Length - 1; i++)
        {
            var (r1, c1) = points[i];
            var (r2, c2) = points[i + 1];
            sum += ((c2 + c1) * (r1 - r2));
        }

        return Math.Abs(sum / 2);
    }

    public static (int, int) GetDirectionP1(char ch, int distance) =>
        ch switch
        {
            'R' => (0, distance),
            'L' => (0, -distance),
            'D' => (distance, 0),
            'U' => (-distance, 0),
            _ => throw new Exception($"OOPS: {ch} {distance}")
        };

    public static (int, int) GetDirectionP2(char ch, int distance) =>
        ch switch
        {
            '0' => (0, distance),
            '2' => (0, -distance),
            '1' => (distance, 0),
            '3' => (-distance, 0),
            _ => throw new Exception($"OOPS: {ch} {distance}")
        };

    private string data = """
                            R 5 (#2f3630)
                            U 9 (#54a1a3)
                            R 5 (#05bce0)
                            U 3 (#008843)
                            R 5 (#6690d0)
                            U 4 (#008841)
                            R 5 (#651d10)
                            U 7 (#830023)
                            R 8 (#4750a2)
                            U 7 (#6a1001)
                            R 3 (#114a72)
                            D 5 (#21dbf3)
                            R 3 (#4523f2)
                            U 4 (#3a1e43)
                            R 4 (#2eef10)
                            D 4 (#352183)
                            R 5 (#2eef12)
                            D 6 (#1fd943)
                            L 7 (#5c0bd2)
                            D 5 (#32d3b1)
                            L 5 (#47d3d0)
                            D 3 (#3032e1)
                            R 2 (#47d3d2)
                            D 4 (#4dee61)
                            R 4 (#044a92)
                            D 4 (#494b23)
                            R 2 (#132772)
                            D 3 (#2186a3)
                            R 7 (#49e542)
                            U 3 (#864783)
                            R 3 (#3afdd2)
                            U 5 (#2ab8d1)
                            R 6 (#2d5072)
                            D 5 (#362ab1)
                            R 4 (#2d5070)
                            U 5 (#46eaa1)
                            R 9 (#183c12)
                            U 3 (#494b21)
                            R 3 (#584d32)
                            U 4 (#6a1003)
                            R 3 (#618682)
                            U 4 (#5a1853)
                            R 6 (#30cf00)
                            U 6 (#6b3a23)
                            R 5 (#5e1260)
                            U 2 (#20b7d3)
                            R 3 (#1d2ec0)
                            U 10 (#89f613)
                            R 5 (#16c5b0)
                            U 3 (#26b1d3)
                            R 4 (#475e70)
                            U 3 (#007223)
                            R 5 (#3cf870)
                            U 3 (#851f83)
                            R 8 (#326e40)
                            U 5 (#043ad3)
                            R 4 (#2eb0a0)
                            U 5 (#26e791)
                            R 3 (#0b6950)
                            U 7 (#323af1)
                            L 3 (#0b6952)
                            U 3 (#4ffc41)
                            L 4 (#721f70)
                            U 8 (#0137b1)
                            R 4 (#5c9d22)
                            U 3 (#55ff21)
                            R 5 (#5c9d20)
                            U 3 (#3b2d71)
                            R 5 (#721f72)
                            U 7 (#1fa921)
                            R 8 (#3012f0)
                            D 5 (#4c6a91)
                            R 8 (#61af70)
                            D 4 (#4c6a93)
                            R 6 (#2e21b0)
                            D 2 (#7df243)
                            R 2 (#108f72)
                            D 9 (#239da3)
                            R 5 (#1f8fb0)
                            D 8 (#8e8b71)
                            R 5 (#5a6f50)
                            D 2 (#8e8b73)
                            R 3 (#159190)
                            D 5 (#5f70a3)
                            L 5 (#012372)
                            D 3 (#04bf23)
                            L 5 (#72bbe2)
                            D 6 (#04bf21)
                            L 3 (#1bb142)
                            D 3 (#0f6693)
                            L 4 (#108f70)
                            D 6 (#0ecae3)
                            L 6 (#407170)
                            D 8 (#10ff11)
                            L 7 (#18f910)
                            D 6 (#10ff13)
                            R 2 (#483d30)
                            D 6 (#30a891)
                            R 4 (#1ed8b0)
                            D 5 (#688901)
                            R 4 (#130de0)
                            D 6 (#4d20e1)
                            R 5 (#4b1000)
                            U 7 (#877bf1)
                            R 2 (#395410)
                            U 4 (#877bf3)
                            R 4 (#167f10)
                            D 2 (#486f11)
                            R 7 (#54e8d0)
                            D 2 (#504301)
                            R 2 (#8035e2)
                            D 7 (#433471)
                            R 3 (#8035e0)
                            D 3 (#26cad1)
                            R 3 (#4b3dc0)
                            D 5 (#802d11)
                            R 2 (#05af00)
                            D 4 (#3b3f31)
                            R 5 (#0dfed0)
                            D 8 (#3b4341)
                            L 6 (#489830)
                            D 3 (#3b4343)
                            L 3 (#4e0bd0)
                            D 7 (#0f7fd1)
                            R 6 (#1c6dd0)
                            D 2 (#318d21)
                            R 3 (#0cb8f2)
                            D 6 (#68acd1)
                            R 2 (#432822)
                            D 3 (#218ee1)
                            R 11 (#661ec2)
                            U 3 (#218ee3)
                            R 5 (#0b10d2)
                            U 4 (#2233f1)
                            L 3 (#2a5330)
                            U 3 (#0df7d1)
                            L 9 (#5ff680)
                            U 4 (#2b9701)
                            R 12 (#8b68d0)
                            U 3 (#2b9703)
                            L 5 (#086f10)
                            U 7 (#1f1431)
                            R 4 (#6937b0)
                            U 5 (#2cce51)
                            R 3 (#26cb50)
                            D 8 (#3ee1c1)
                            R 6 (#3c8a40)
                            D 5 (#7e7211)
                            R 7 (#7190e0)
                            D 3 (#036101)
                            R 6 (#6110b0)
                            D 3 (#89da01)
                            L 12 (#1f2cc0)
                            D 3 (#2b7181)
                            L 4 (#3942b0)
                            D 5 (#10f821)
                            L 2 (#61ae90)
                            D 6 (#04dee1)
                            L 6 (#2fc950)
                            D 2 (#04dee3)
                            L 8 (#353d90)
                            D 4 (#1e21b1)
                            L 3 (#46fa00)
                            D 4 (#3ea393)
                            R 5 (#5c2e32)
                            D 5 (#361be3)
                            R 6 (#2ddc12)
                            U 4 (#4b1a83)
                            R 6 (#135722)
                            U 6 (#521483)
                            R 9 (#7382b2)
                            D 6 (#239da3)
                            R 3 (#3ed420)
                            D 4 (#3a0c73)
                            R 6 (#5a68d0)
                            D 3 (#76f053)
                            L 5 (#244ec0)
                            D 4 (#062573)
                            L 8 (#053c50)
                            D 5 (#0bfac3)
                            R 3 (#123e30)
                            D 7 (#21c2c3)
                            R 6 (#0b11b0)
                            D 3 (#6781f3)
                            R 9 (#720e70)
                            D 3 (#7ddd13)
                            L 11 (#33d6f0)
                            D 2 (#1b2d83)
                            L 7 (#5f0280)
                            D 5 (#579183)
                            R 4 (#5f0282)
                            D 6 (#5c9303)
                            R 3 (#3c6770)
                            D 4 (#2b6333)
                            R 5 (#4f28a0)
                            U 5 (#55d573)
                            R 6 (#2b03a0)
                            U 5 (#244bd3)
                            R 5 (#644122)
                            U 7 (#08ab63)
                            R 7 (#232bc2)
                            U 5 (#71f5e3)
                            R 4 (#060d22)
                            U 3 (#168c63)
                            R 4 (#44efa2)
                            D 3 (#17c163)
                            R 9 (#2ed822)
                            D 6 (#17c161)
                            R 10 (#4b9682)
                            D 6 (#168c61)
                            R 6 (#1ab282)
                            D 3 (#490b43)
                            L 6 (#639022)
                            D 4 (#447151)
                            L 5 (#0596c0)
                            U 4 (#2fba61)
                            L 5 (#0596c2)
                            D 4 (#201131)
                            L 3 (#1f9c52)
                            D 3 (#0c4a23)
                            R 9 (#266412)
                            D 3 (#68bea3)
                            R 7 (#266410)
                            D 4 (#1f3423)
                            R 3 (#51d9c2)
                            D 6 (#1f6633)
                            R 8 (#7382b0)
                            U 8 (#01fca3)
                            R 7 (#3271f0)
                            U 4 (#7ee903)
                            R 6 (#581210)
                            D 7 (#7ee901)
                            R 2 (#12dd60)
                            U 7 (#15a1a3)
                            R 6 (#7c30f0)
                            U 2 (#591961)
                            R 3 (#69efd0)
                            U 4 (#591963)
                            L 9 (#32e7e0)
                            U 3 (#574071)
                            L 3 (#50c6a0)
                            U 3 (#0be261)
                            L 5 (#6ae5c0)
                            U 3 (#5c08b1)
                            L 3 (#7158d0)
                            U 2 (#36fe01)
                            L 4 (#325c22)
                            U 9 (#305be1)
                            R 3 (#325c20)
                            U 2 (#36c0a1)
                            R 3 (#1687d0)
                            U 7 (#6e3d91)
                            R 4 (#69abb2)
                            U 4 (#0a66d1)
                            R 4 (#3091a2)
                            U 6 (#548a01)
                            R 3 (#47a5c2)
                            U 3 (#2a9553)
                            R 5 (#795b32)
                            U 3 (#2a9551)
                            R 8 (#181b72)
                            U 7 (#43b071)
                            R 4 (#443e90)
                            U 2 (#3926e1)
                            R 4 (#6c3760)
                            U 4 (#694dd3)
                            R 6 (#4b1d30)
                            U 3 (#032dd1)
                            R 6 (#101060)
                            U 4 (#032dd3)
                            L 6 (#49c630)
                            U 7 (#694dd1)
                            L 2 (#1df000)
                            U 3 (#2ff181)
                            L 8 (#3617e2)
                            D 6 (#3a3c41)
                            L 3 (#51c8c2)
                            D 4 (#5c01b1)
                            L 11 (#0ca2b0)
                            U 2 (#4333b1)
                            L 3 (#812b52)
                            U 8 (#6f4601)
                            L 3 (#379b22)
                            U 2 (#07d291)
                            L 7 (#49e292)
                            U 7 (#709721)
                            L 4 (#1db7a2)
                            U 8 (#58c9d1)
                            L 6 (#52d210)
                            U 5 (#64a341)
                            L 3 (#1054c0)
                            U 7 (#64a343)
                            L 4 (#61a0b0)
                            U 10 (#187211)
                            L 4 (#5b9920)
                            U 4 (#05d301)
                            L 3 (#0c8ef0)
                            U 8 (#09f161)
                            L 4 (#7fa590)
                            U 4 (#516f31)
                            L 3 (#408e12)
                            D 6 (#3ccd51)
                            L 2 (#4ba672)
                            D 10 (#1fb771)
                            L 3 (#3d8200)
                            U 8 (#195531)
                            L 3 (#6bcfe0)
                            U 9 (#484041)
                            L 5 (#3ae112)
                            U 5 (#6d6931)
                            R 4 (#3ae110)
                            U 7 (#05dd71)
                            L 4 (#4c5332)
                            U 6 (#5df683)
                            L 10 (#3aebd2)
                            U 3 (#5f3f53)
                            L 3 (#815352)
                            U 6 (#5f3f51)
                            L 4 (#28ac32)
                            U 4 (#5df681)
                            R 4 (#3cb5e2)
                            U 2 (#7662f1)
                            R 4 (#322d10)
                            U 8 (#1a81a3)
                            R 5 (#3e2ba0)
                            D 4 (#1a81a1)
                            R 3 (#362bc0)
                            D 6 (#3e19c1)
                            R 5 (#234960)
                            U 5 (#2d2853)
                            R 7 (#56bab0)
                            U 4 (#2d2851)
                            R 8 (#4d6be0)
                            U 5 (#5ad541)
                            R 8 (#1d6e52)
                            U 6 (#077851)
                            L 7 (#45b722)
                            U 3 (#077853)
                            L 7 (#52cf22)
                            U 4 (#07d441)
                            R 7 (#77bb62)
                            U 4 (#1a8641)
                            R 7 (#4c1bf2)
                            U 3 (#2ca611)
                            R 3 (#18b8e2)
                            D 3 (#57ff81)
                            R 4 (#60c622)
                            D 7 (#42e791)
                            R 4 (#1a7550)
                            D 6 (#2645b1)
                            R 5 (#1a7552)
                            D 8 (#4ea9d1)
                            R 6 (#797f00)
                            D 2 (#02b451)
                            R 4 (#375b52)
                            D 7 (#28c491)
                            R 7 (#5e30f2)
                            D 9 (#3f4341)
                            L 7 (#11cf50)
                            D 5 (#82e171)
                            R 3 (#655ee0)
                            D 3 (#189ea1)
                            R 3 (#772e32)
                            D 10 (#177941)
                            R 4 (#06baa2)
                            D 11 (#561461)
                            R 2 (#5c8dd2)
                            D 7 (#561463)
                            R 6 (#36fc22)
                            D 5 (#0cea13)
                            R 2 (#4cc760)
                            D 4 (#4dfe53)
                            R 6 (#323630)
                            U 9 (#566003)
                            R 7 (#7efd92)
                            D 9 (#40f433)
                            R 6 (#080d32)
                            D 8 (#6cf311)
                            R 5 (#35bf72)
                            D 3 (#3b7973)
                            R 8 (#06a632)
                            D 4 (#252293)
                            R 4 (#06a630)
                            D 5 (#35ed03)
                            R 7 (#4d1cd2)
                            D 2 (#4cf4f3)
                            R 3 (#1dd4e2)
                            D 3 (#2b92f3)
                            R 4 (#117530)
                            D 4 (#5ac883)
                            R 12 (#117532)
                            U 4 (#48ca43)
                            R 7 (#708b12)
                            D 5 (#068663)
                            R 5 (#4247e2)
                            D 7 (#704161)
                            R 4 (#4b2b22)
                            D 8 (#13ea71)
                            R 4 (#699472)
                            D 5 (#4d6551)
                            R 5 (#8503c0)
                            D 2 (#281c91)
                            R 2 (#8503c2)
                            D 9 (#33a0c1)
                            L 5 (#4e8ad2)
                            D 3 (#825f21)
                            L 5 (#26aab2)
                            D 8 (#097c71)
                            L 6 (#169832)
                            D 4 (#457031)
                            L 7 (#8cee10)
                            U 5 (#251221)
                            L 3 (#71dce0)
                            U 3 (#331751)
                            L 6 (#7cfe10)
                            D 5 (#617961)
                            L 9 (#7cfe12)
                            U 5 (#04b4d1)
                            L 8 (#379ae0)
                            D 8 (#0c88f1)
                            L 4 (#0ee942)
                            D 8 (#297c01)
                            R 5 (#5a78a2)
                            D 6 (#3db043)
                            R 5 (#7eadd2)
                            D 4 (#3db041)
                            R 5 (#4e5622)
                            D 2 (#381fa1)
                            R 6 (#2cfd90)
                            D 4 (#36bd23)
                            R 3 (#4d18c0)
                            D 4 (#36bd21)
                            R 3 (#1a3d70)
                            D 2 (#6644a1)
                            R 12 (#868912)
                            D 4 (#5cb351)
                            R 3 (#868910)
                            D 4 (#3b3501)
                            R 5 (#1cddb0)
                            D 4 (#4cc9b1)
                            L 9 (#040250)
                            D 6 (#38c721)
                            L 7 (#23e920)
                            D 3 (#08dde3)
                            L 8 (#2c48f0)
                            D 4 (#08dde1)
                            L 2 (#414710)
                            D 4 (#3c36b1)
                            L 8 (#467ab0)
                            D 3 (#034323)
                            L 4 (#67f960)
                            D 6 (#034321)
                            L 9 (#675f90)
                            D 6 (#338083)
                            L 5 (#2b4702)
                            D 6 (#035ab3)
                            L 6 (#4d5642)
                            D 7 (#035ab1)
                            L 8 (#40ff22)
                            D 3 (#495523)
                            L 5 (#83a372)
                            D 5 (#1a5d23)
                            L 8 (#4ef3c2)
                            D 4 (#7515a3)
                            L 9 (#40d0f0)
                            D 5 (#143e73)
                            L 8 (#2ec480)
                            U 8 (#070d81)
                            R 4 (#344d10)
                            U 4 (#070d83)
                            R 5 (#2eb4b0)
                            U 5 (#681243)
                            R 3 (#51a710)
                            U 5 (#8a2821)
                            R 7 (#2faba0)
                            U 5 (#8a2823)
                            R 3 (#3849b0)
                            U 6 (#375b63)
                            L 8 (#3790d0)
                            U 7 (#2f77d1)
                            L 6 (#444dd0)
                            U 3 (#85afe3)
                            L 6 (#656d90)
                            U 6 (#85afe1)
                            L 2 (#1152b0)
                            U 3 (#334491)
                            R 4 (#362670)
                            U 7 (#819361)
                            L 4 (#4fd202)
                            U 3 (#718a21)
                            L 5 (#17bf92)
                            D 10 (#3334f1)
                            L 2 (#43c272)
                            D 4 (#40f041)
                            L 5 (#3afbc2)
                            D 6 (#742533)
                            L 8 (#0ae4c2)
                            U 6 (#146731)
                            L 8 (#2aec82)
                            D 2 (#89fa61)
                            L 3 (#044562)
                            D 4 (#1e14a1)
                            R 2 (#7b0a82)
                            D 4 (#1e14a3)
                            R 7 (#4b7812)
                            D 2 (#09cdc1)
                            R 5 (#3c3502)
                            D 2 (#70eb41)
                            R 12 (#4b7400)
                            D 3 (#5c8043)
                            L 12 (#6085c0)
                            D 3 (#5c8041)
                            L 4 (#5b0330)
                            D 4 (#74bce1)
                            L 12 (#6f6142)
                            D 2 (#0f2211)
                            L 5 (#40e5b0)
                            D 5 (#72afc1)
                            L 7 (#40e5b2)
                            D 3 (#160a51)
                            L 3 (#7a6c72)
                            D 6 (#3ade81)
                            L 4 (#6c12d2)
                            U 10 (#0d3851)
                            L 5 (#4e1680)
                            D 10 (#65ba61)
                            L 5 (#185f10)
                            D 3 (#65ba63)
                            L 6 (#3ca040)
                            D 7 (#6970e1)
                            L 3 (#49ad52)
                            D 2 (#0c8481)
                            L 8 (#3e7a82)
                            D 3 (#0c8483)
                            L 5 (#1aee02)
                            D 4 (#35e721)
                            L 4 (#39f672)
                            D 5 (#07f333)
                            L 6 (#730842)
                            D 6 (#0fe7b3)
                            L 3 (#6079e2)
                            D 9 (#74e4d3)
                            L 7 (#6079e0)
                            D 4 (#1c77b3)
                            L 3 (#3299b2)
                            U 4 (#6649e3)
                            L 5 (#496642)
                            U 5 (#618563)
                            L 4 (#36e332)
                            D 4 (#084843)
                            L 6 (#670e22)
                            D 9 (#164f23)
                            L 5 (#3c5360)
                            D 5 (#467003)
                            L 3 (#3c5362)
                            U 3 (#3980d3)
                            L 3 (#275e32)
                            U 6 (#19ea63)
                            L 4 (#855df0)
                            U 2 (#5ec993)
                            L 9 (#66f342)
                            U 7 (#4ac7a3)
                            L 5 (#1e6ab2)
                            U 8 (#2bd3a3)
                            L 4 (#5f6272)
                            U 5 (#3b2031)
                            L 4 (#1c1fa0)
                            U 5 (#534711)
                            R 3 (#1c1fa2)
                            U 5 (#3474d1)
                            R 5 (#572be2)
                            D 4 (#2cdf53)
                            R 6 (#3bb0e2)
                            U 4 (#5e9073)
                            R 4 (#3bb0e0)
                            U 4 (#376c53)
                            L 3 (#193f72)
                            U 3 (#484e83)
                            L 4 (#799b82)
                            U 5 (#52f273)
                            R 4 (#376190)
                            U 5 (#3650a3)
                            L 5 (#7def10)
                            D 2 (#20fa83)
                            L 2 (#089240)
                            D 11 (#49c3a3)
                            L 3 (#768be0)
                            U 4 (#42fa23)
                            L 5 (#5ab362)
                            U 4 (#593983)
                            L 8 (#5e6ba2)
                            D 4 (#593981)
                            R 4 (#7b4fc2)
                            D 9 (#44a9c3)
                            L 2 (#086692)
                            D 3 (#7ce9f3)
                            L 4 (#68b430)
                            U 6 (#5ab7c1)
                            L 4 (#430330)
                            D 6 (#0b1593)
                            L 5 (#1ca4a0)
                            D 5 (#0b1591)
                            R 10 (#429f80)
                            D 2 (#5ab7c3)
                            R 2 (#292be0)
                            D 4 (#7a8693)
                            R 3 (#12dfd2)
                            D 10 (#2244f3)
                            L 4 (#4eeb62)
                            D 10 (#4831c3)
                            L 6 (#25aa50)
                            U 8 (#379b33)
                            L 3 (#25aa52)
                            U 3 (#145863)
                            L 5 (#480492)
                            U 4 (#69feb1)
                            L 7 (#593592)
                            U 4 (#4c6b91)
                            L 5 (#312212)
                            U 3 (#26df43)
                            R 12 (#68b362)
                            U 4 (#6e94f3)
                            L 5 (#28bd52)
                            U 4 (#1aea03)
                            L 8 (#615f22)
                            U 2 (#6fb163)
                            L 2 (#40b8a2)
                            U 7 (#09d633)
                            L 7 (#044e02)
                            U 8 (#1a4333)
                            L 4 (#172d00)
                            U 2 (#4509c3)
                            L 6 (#4de1d0)
                            U 7 (#818a41)
                            L 4 (#0ce4b0)
                            U 7 (#0745d1)
                            R 6 (#520370)
                            U 2 (#5a7db3)
                            R 8 (#2f93c0)
                            U 4 (#2e5263)
                            L 4 (#147e00)
                            U 3 (#44d303)
                            L 7 (#245640)
                            U 4 (#17d933)
                            L 3 (#4f6820)
                            U 3 (#17d931)
                            L 10 (#488c50)
                            D 3 (#108b33)
                            L 4 (#300e60)
                            D 3 (#887d43)
                            R 7 (#4272d0)
                            D 8 (#657091)
                            L 7 (#63d120)
                            D 3 (#230cb1)
                            R 4 (#04e1b0)
                            D 6 (#4ba9a3)
                            L 7 (#055c40)
                            U 2 (#3ee173)
                            L 4 (#454062)
                            U 6 (#2af563)
                            L 3 (#40a642)
                            U 6 (#4ddf13)
                            L 6 (#85e6a0)
                            U 6 (#090df3)
                            L 9 (#055c42)
                            U 2 (#4ac2b3)
                            L 3 (#2ae1a0)
                            U 5 (#43af51)
                            R 6 (#860900)
                            U 5 (#43af53)
                            L 6 (#057bb0)
                            U 3 (#570c13)
                            R 4 (#515d92)
                            U 3 (#09a031)
                            L 7 (#45b7f2)
                            U 5 (#09a033)
                            R 6 (#1f50d2)
                            U 7 (#4e6373)
                            L 6 (#5df030)
                            U 7 (#004663)
                            R 7 (#10f120)
                            U 4 (#5f4883)
                            L 12 (#10f122)
                            U 2 (#441aa3)
                            L 3 (#1c7242)
                            U 4 (#4849a3)
                            R 7 (#7026d2)
                            U 4 (#442943)
                            R 8 (#5c5152)
                            U 5 (#563813)
                            L 4 (#5c5150)
                            U 4 (#1460b3)
                            L 5 (#1d3272)
                            U 6 (#1d15d3)
                            R 5 (#4fe282)
                            U 3 (#6a04c1)
                            L 6 (#2ca912)
                            U 5 (#1d2623)
                            L 6 (#298bb2)
                            U 3 (#1d2621)
                            L 9 (#3a4e82)
                            U 4 (#2abf71)
                            L 5 (#01c5d2)
                            U 4 (#7f5d41)
                            L 6 (#0149b2)
                            U 4 (#66f8c3)
                            L 5 (#53acd2)
                            U 6 (#55caa3)
                            L 3 (#676e82)
                            U 8 (#5c69a3)
                            R 5 (#5d7ed2)
                            U 2 (#1d90a3)
                            R 3 (#579cb2)
                            U 3 (#631003)
                            R 9 (#6ffcb2)
                            U 5 (#2e98f3)
                            R 2 (#036c22)
                            U 3 (#2bd763)
                            L 5 (#478442)
                            U 7 (#7a8373)
                            L 9 (#5da862)
                            U 4 (#13a8d3)
                          """;
}